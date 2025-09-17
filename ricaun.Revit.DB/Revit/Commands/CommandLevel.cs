using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace ricaun.Revit.DB.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CommandLevel : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            Document document = uiapp.ActiveUIDocument.Document;

            var firstLevel = document.GetFirstElementType<LevelType>();

            Console.WriteLine($"LevelType: {firstLevel?.Name}");

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Level Duplicate");

                for (int i = 0; i < 1000; i++)
                {
                    var name = $"{nameof(Level)} {DateTime.Now.Ticks}";
                    firstLevel.Duplicate(name);
                }

                transaction.Commit();
            }

            Console.WriteLine($"LevelType: {document.SelectElementTypes<LevelType>().GetElementCount()}");

            return Result.Succeeded;
        }
    }
}
