using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Tests.Utils;

namespace ricaun.Revit.DB.Tests
{
    public class RevitSelectExtensionTest : OneTimeOpenDocumentTest
    {
        [Test]
        public void SelectExtensions()
        {
            {
                document.Select();
                document.Select(BuiltInCategory.INVALID);
                document.Select(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.Select(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.Select(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.Select(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.Select(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.Select([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.SelectElements();
                document.SelectElements(BuiltInCategory.INVALID);
                document.SelectElements(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElements(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElements(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.SelectElements(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElements(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElements([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.SelectElementTypes();
                document.SelectElementTypes(BuiltInCategory.INVALID);
                document.SelectElementTypes(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElementTypes(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElementTypes(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.SelectElementTypes(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElementTypes(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElementTypes([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.Select<Element>();
                document.Select<Element>(BuiltInCategory.INVALID);
                document.Select<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.Select<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.Select<Element>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.Select<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.Select<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.Select<Element>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.SelectElements<Element>();
                document.SelectElements<Element>(BuiltInCategory.INVALID);
                document.SelectElements<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElements<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElements<Element>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.SelectElements<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElements<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElements<Element>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.SelectElementTypes<ElementType>();
                document.SelectElementTypes<ElementType>(BuiltInCategory.INVALID);
                document.SelectElementTypes<ElementType>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElementTypes<ElementType>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElementTypes<ElementType>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.SelectElementTypes<ElementType>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElementTypes<ElementType>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.SelectElementTypes<ElementType>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
            }

            {
                document.GetElements();
                document.GetElements(BuiltInCategory.INVALID);
                document.GetElements(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElements(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElements(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetElements(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElements(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElements([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetElementTypes();
                document.GetElementTypes(BuiltInCategory.INVALID);
                document.GetElementTypes(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypes(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypes(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetElementTypes(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypes(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypes([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetElements<Element>();
                document.GetElements<Element>(BuiltInCategory.INVALID);
                document.GetElements<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElements<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElements<Element>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetElements<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElements<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElements<Element>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetElementTypes<ElementType>();
                document.GetElementTypes<ElementType>(BuiltInCategory.INVALID);
                document.GetElementTypes<ElementType>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypes<ElementType>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypes<ElementType>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetElementTypes<ElementType>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypes<ElementType>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypes<ElementType>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
            }

            {
                document.GetElementIds();
                document.GetElementIds(BuiltInCategory.INVALID);
                document.GetElementIds(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementIds(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementIds(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetElementIds(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementIds(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementIds([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetElementTypeIds();
                document.GetElementTypeIds(BuiltInCategory.INVALID);
                document.GetElementTypeIds(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypeIds(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypeIds(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetElementTypeIds(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypeIds(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypeIds([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetElementIds<Element>();
                document.GetElementIds<Element>(BuiltInCategory.INVALID);
                document.GetElementIds<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementIds<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementIds<Element>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetElementIds<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementIds<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementIds<Element>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetElementTypeIds<ElementType>();
                document.GetElementTypeIds<ElementType>(BuiltInCategory.INVALID);
                document.GetElementTypeIds<ElementType>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypeIds<ElementType>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypeIds<ElementType>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetElementTypeIds<ElementType>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypeIds<ElementType>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetElementTypeIds<ElementType>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
            }

            {
                document.GetFirstElement();
                document.GetFirstElement(BuiltInCategory.INVALID);
                document.GetFirstElement(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElement(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElement(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetFirstElement(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElement(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElement([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetFirstElementType();
                document.GetFirstElementType(BuiltInCategory.INVALID);
                document.GetFirstElementType(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementType(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementType(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetFirstElementType(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementType(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementType([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetFirstElement<Element>();
                document.GetFirstElement<Element>(BuiltInCategory.INVALID);
                document.GetFirstElement<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElement<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElement<Element>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetFirstElement<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElement<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElement<Element>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetFirstElementType<ElementType>();
                document.GetFirstElementType<ElementType>(BuiltInCategory.INVALID);
                document.GetFirstElementType<ElementType>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementType<ElementType>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementType<ElementType>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetFirstElementType<ElementType>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementType<ElementType>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementType<ElementType>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
            }

            {
                document.GetFirstElementId();
                document.GetFirstElementId(BuiltInCategory.INVALID);
                document.GetFirstElementId(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementId(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementId(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetFirstElementId(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementId(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementId([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetFirstElementTypeId();
                document.GetFirstElementTypeId(BuiltInCategory.INVALID);
                document.GetFirstElementTypeId(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementTypeId(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementTypeId(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetFirstElementTypeId(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementTypeId(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementTypeId([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetFirstElementId<Element>();
                document.GetFirstElementId<Element>(BuiltInCategory.INVALID);
                document.GetFirstElementId<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementId<Element>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementId<Element>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetFirstElementId<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementId<Element>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementId<Element>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);

                document.GetFirstElementTypeId<ElementType>();
                document.GetFirstElementTypeId<ElementType>(BuiltInCategory.INVALID);
                document.GetFirstElementTypeId<ElementType>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementTypeId<ElementType>(BuiltInCategory.INVALID, new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementTypeId<ElementType>(BuiltInCategory.INVALID, [new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
                document.GetFirstElementTypeId<ElementType>(new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementTypeId<ElementType>(new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID));
                document.GetFirstElementTypeId<ElementType>([new ElementCategoryFilter(BuiltInCategory.INVALID), new ElementCategoryFilter(BuiltInCategory.INVALID)]);
            }
        }
    }
}
