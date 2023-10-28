using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ConnectorGizmoCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;
            View view = uidoc.ActiveView;
            Selection selection = uidoc.Selection;

            var elements = selection.GetElementIds().Select(id => document.GetElement(id));
            var conenctors = elements.SelectMany(GetConnectors);

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("DirectShapeType");

                document.DeleteDirectShape();

                var gizmoType = document.CreateDirectShapeType(ShapeCreator.CreateGizmo(document));

                foreach (var conenctor in conenctors)
                {
                    if (conenctor.Domain == Domain.DomainUndefined) continue;
                    gizmoType.Create(conenctor.CoordinateSystem);
                }

                transaction.Commit();
            }

            return Result.Succeeded;
        }

        public static IEnumerable<Connector> GetConnectors(Element element)
        {
            if (element is null)
                return Enumerable.Empty<Connector>();

            ConnectorManager connectorManager = null;

            if (element is FamilyInstance instance)
            {
                if (instance.MEPModel is MEPModel model)
                    connectorManager = model.ConnectorManager;
            }
            else if (element is MEPSystem system)
            {
                connectorManager = system.ConnectorManager;
            }
            else if (element is MEPCurve curve)
            {
                connectorManager = curve.ConnectorManager;
            }

            if (connectorManager is ConnectorManager)
                return connectorManager.Connectors.OfType<Connector>();

            return Enumerable.Empty<Connector>();
        }
    }
}
