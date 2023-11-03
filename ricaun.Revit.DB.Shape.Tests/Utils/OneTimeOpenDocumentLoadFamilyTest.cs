using Autodesk.Revit.DB;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Tests.Utils
{
    /// <summary>
    /// OneTimeOpenDocumentLoadFamilyTest
    /// </summary>
    public class OneTimeOpenDocumentLoadFamilyTest : OneTimeOpenDocumentTest
    {
        protected virtual string FamilyName => null;
        protected Family Family { get; private set; }
        protected FamilyInstance FamilyInstance { get; private set; }

        protected Solid FamilyInstanceSolid()
        {
            return FamilyInstanceSolids()
                .FirstOrDefault();
        }

        protected IEnumerable<Solid> FamilyInstanceSolids()
        {
            return FamilyInstance.get_Geometry(new Options())
                    .OfType<GeometryInstance>()
                    .SelectMany(e => e.GetInstanceGeometry())
                    .OfType<Solid>()
                    .Where(s => s.SurfaceArea > 0);
        }

        [SetUp]
        public void LoadFamilySetup()
        {
            if (Family is not null) return;

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("LoadFamily");
                if (document.LoadFamily(FamilyName, out Family family))
                {
                    Family = family;
                }
                transaction.Commit();
            }

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("NewFamilyInstance");
                var symbol = Family.GetFamilySymbolIds()
                    .Select(document.GetElement)
                    .OfType<FamilySymbol>()
                    .FirstOrDefault();
                if (symbol.IsActive == false) symbol.Activate();
                FamilyInstance = document.Create.NewFamilyInstance(XYZ.Zero, symbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                transaction.Commit();
            }
        }
    }
}