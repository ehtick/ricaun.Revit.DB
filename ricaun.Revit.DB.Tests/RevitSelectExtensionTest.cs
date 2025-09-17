using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Tests.Utils;

namespace ricaun.Revit.DB.Tests
{
    public class RevitSelectExtensionTest : OneTimeOpenDocumentTest
    {
        ElementCategoryFilter Filter = new(BuiltInCategory.INVALID);
        BuiltInCategory Category = BuiltInCategory.INVALID;

        [Test]
        public void SelectExtensions()
        {
            {
                document.Select();
                document.Select(Category);
                document.Select(Category, Filter);
                document.Select(Category, Filter, Filter);
                document.Select(Category, [Filter, Filter]);
                document.Select(Filter);
                document.Select(Filter, Filter);
                document.Select([Filter, Filter]);

                document.SelectElements();
                document.SelectElements(Category);
                document.SelectElements(Category, Filter);
                document.SelectElements(Category, Filter, Filter);
                document.SelectElements(Category, [Filter, Filter]);
                document.SelectElements(Filter);
                document.SelectElements(Filter, Filter);
                document.SelectElements([Filter, Filter]);

                document.SelectElementTypes();
                document.SelectElementTypes(Category);
                document.SelectElementTypes(Category, Filter);
                document.SelectElementTypes(Category, Filter, Filter);
                document.SelectElementTypes(Category, [Filter, Filter]);
                document.SelectElementTypes(Filter);
                document.SelectElementTypes(Filter, Filter);
                document.SelectElementTypes([Filter, Filter]);

                document.Select<Element>();
                document.Select<Element>(Category);
                document.Select<Element>(Category, Filter);
                document.Select<Element>(Category, Filter, Filter);
                document.Select<Element>(Category, [Filter, Filter]);
                document.Select<Element>(Filter);
                document.Select<Element>(Filter, Filter);
                document.Select<Element>([Filter, Filter]);

                document.SelectElements<Element>();
                document.SelectElements<Element>(Category);
                document.SelectElements<Element>(Category, Filter);
                document.SelectElements<Element>(Category, Filter, Filter);
                document.SelectElements<Element>(Category, [Filter, Filter]);
                document.SelectElements<Element>(Filter);
                document.SelectElements<Element>(Filter, Filter);
                document.SelectElements<Element>([Filter, Filter]);

                document.SelectElementTypes<ElementType>();
                document.SelectElementTypes<ElementType>(Category);
                document.SelectElementTypes<ElementType>(Category, Filter);
                document.SelectElementTypes<ElementType>(Category, Filter, Filter);
                document.SelectElementTypes<ElementType>(Category, [Filter, Filter]);
                document.SelectElementTypes<ElementType>(Filter);
                document.SelectElementTypes<ElementType>(Filter, Filter);
                document.SelectElementTypes<ElementType>([Filter, Filter]);
            }

            {
                document.GetElements();
                document.GetElements(Category);
                document.GetElements(Category, Filter);
                document.GetElements(Category, Filter, Filter);
                document.GetElements(Category, [Filter, Filter]);
                document.GetElements(Filter);
                document.GetElements(Filter, Filter);
                document.GetElements([Filter, Filter]);

                document.GetElementTypes();
                document.GetElementTypes(Category);
                document.GetElementTypes(Category, Filter);
                document.GetElementTypes(Category, Filter, Filter);
                document.GetElementTypes(Category, [Filter, Filter]);
                document.GetElementTypes(Filter);
                document.GetElementTypes(Filter, Filter);
                document.GetElementTypes([Filter, Filter]);

                document.GetElements<Element>();
                document.GetElements<Element>(Category);
                document.GetElements<Element>(Category, Filter);
                document.GetElements<Element>(Category, Filter, Filter);
                document.GetElements<Element>(Category, [Filter, Filter]);
                document.GetElements<Element>(Filter);
                document.GetElements<Element>(Filter, Filter);
                document.GetElements<Element>([Filter, Filter]);

                document.GetElementTypes<ElementType>();
                document.GetElementTypes<ElementType>(Category);
                document.GetElementTypes<ElementType>(Category, Filter);
                document.GetElementTypes<ElementType>(Category, Filter, Filter);
                document.GetElementTypes<ElementType>(Category, [Filter, Filter]);
                document.GetElementTypes<ElementType>(Filter);
                document.GetElementTypes<ElementType>(Filter, Filter);
                document.GetElementTypes<ElementType>([Filter, Filter]);
            }

            {
                document.GetElementIds();
                document.GetElementIds(Category);
                document.GetElementIds(Category, Filter);
                document.GetElementIds(Category, Filter, Filter);
                document.GetElementIds(Category, [Filter, Filter]);
                document.GetElementIds(Filter);
                document.GetElementIds(Filter, Filter);
                document.GetElementIds([Filter, Filter]);

                document.GetElementTypeIds();
                document.GetElementTypeIds(Category);
                document.GetElementTypeIds(Category, Filter);
                document.GetElementTypeIds(Category, Filter, Filter);
                document.GetElementTypeIds(Category, [Filter, Filter]);
                document.GetElementTypeIds(Filter);
                document.GetElementTypeIds(Filter, Filter);
                document.GetElementTypeIds([Filter, Filter]);

                document.GetElementIds<Element>();
                document.GetElementIds<Element>(Category);
                document.GetElementIds<Element>(Category, Filter);
                document.GetElementIds<Element>(Category, Filter, Filter);
                document.GetElementIds<Element>(Category, [Filter, Filter]);
                document.GetElementIds<Element>(Filter);
                document.GetElementIds<Element>(Filter, Filter);
                document.GetElementIds<Element>([Filter, Filter]);

                document.GetElementTypeIds<ElementType>();
                document.GetElementTypeIds<ElementType>(Category);
                document.GetElementTypeIds<ElementType>(Category, Filter);
                document.GetElementTypeIds<ElementType>(Category, Filter, Filter);
                document.GetElementTypeIds<ElementType>(Category, [Filter, Filter]);
                document.GetElementTypeIds<ElementType>(Filter);
                document.GetElementTypeIds<ElementType>(Filter, Filter);
                document.GetElementTypeIds<ElementType>([Filter, Filter]);
            }

            {
                document.GetFirstElement();
                document.GetFirstElement(Category);
                document.GetFirstElement(Category, Filter);
                document.GetFirstElement(Category, Filter, Filter);
                document.GetFirstElement(Category, [Filter, Filter]);
                document.GetFirstElement(Filter);
                document.GetFirstElement(Filter, Filter);
                document.GetFirstElement([Filter, Filter]);

                document.GetFirstElementType();
                document.GetFirstElementType(Category);
                document.GetFirstElementType(Category, Filter);
                document.GetFirstElementType(Category, Filter, Filter);
                document.GetFirstElementType(Category, [Filter, Filter]);
                document.GetFirstElementType(Filter);
                document.GetFirstElementType(Filter, Filter);
                document.GetFirstElementType([Filter, Filter]);

                document.GetFirstElement<Element>();
                document.GetFirstElement<Element>(Category);
                document.GetFirstElement<Element>(Category, Filter);
                document.GetFirstElement<Element>(Category, Filter, Filter);
                document.GetFirstElement<Element>(Category, [Filter, Filter]);
                document.GetFirstElement<Element>(Filter);
                document.GetFirstElement<Element>(Filter, Filter);
                document.GetFirstElement<Element>([Filter, Filter]);

                document.GetFirstElementType<ElementType>();
                document.GetFirstElementType<ElementType>(Category);
                document.GetFirstElementType<ElementType>(Category, Filter);
                document.GetFirstElementType<ElementType>(Category, Filter, Filter);
                document.GetFirstElementType<ElementType>(Category, [Filter, Filter]);
                document.GetFirstElementType<ElementType>(Filter);
                document.GetFirstElementType<ElementType>(Filter, Filter);
                document.GetFirstElementType<ElementType>([Filter, Filter]);
            }

            {
                document.GetFirstElementId();
                document.GetFirstElementId(Category);
                document.GetFirstElementId(Category, Filter);
                document.GetFirstElementId(Category, Filter, Filter);
                document.GetFirstElementId(Category, [Filter, Filter]);
                document.GetFirstElementId(Filter);
                document.GetFirstElementId(Filter, Filter);
                document.GetFirstElementId([Filter, Filter]);

                document.GetFirstElementTypeId();
                document.GetFirstElementTypeId(Category);
                document.GetFirstElementTypeId(Category, Filter);
                document.GetFirstElementTypeId(Category, Filter, Filter);
                document.GetFirstElementTypeId(Category, [Filter, Filter]);
                document.GetFirstElementTypeId(Filter);
                document.GetFirstElementTypeId(Filter, Filter);
                document.GetFirstElementTypeId([Filter, Filter]);

                document.GetFirstElementId<Element>();
                document.GetFirstElementId<Element>(Category);
                document.GetFirstElementId<Element>(Category, Filter);
                document.GetFirstElementId<Element>(Category, Filter, Filter);
                document.GetFirstElementId<Element>(Category, [Filter, Filter]);
                document.GetFirstElementId<Element>(Filter);
                document.GetFirstElementId<Element>(Filter, Filter);
                document.GetFirstElementId<Element>([Filter, Filter]);

                document.GetFirstElementTypeId<ElementType>();
                document.GetFirstElementTypeId<ElementType>(Category);
                document.GetFirstElementTypeId<ElementType>(Category, Filter);
                document.GetFirstElementTypeId<ElementType>(Category, Filter, Filter);
                document.GetFirstElementTypeId<ElementType>(Category, [Filter, Filter]);
                document.GetFirstElementTypeId<ElementType>(Filter);
                document.GetFirstElementTypeId<ElementType>(Filter, Filter);
                document.GetFirstElementTypeId<ElementType>([Filter, Filter]);
            }
        }
    }
}
