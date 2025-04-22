using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// Utility class for creating DirectShape elements.
    /// </summary>
    public static class DirectShapeUtils
    {
        /// <summary>
        /// DirectShape default BuiltInCategory
        /// </summary>
        public const BuiltInCategory ConstBuiltInCategory = BuiltInCategory.OST_GenericModel;

        /// <summary>
        /// Delete all DirectShape elements in the document with the specified category.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="builtInCategory">The category for the DirectShape element. The default value is <see cref="ConstBuiltInCategory"/>.</param>
        /// <returns></returns>
        public static ICollection<ElementId> DeleteDirectShape(this Document document,
            BuiltInCategory builtInCategory = ConstBuiltInCategory)
        {
            var elementIds = new FilteredElementCollector(document)
                .OfCategory(builtInCategory)
                .OfClass(typeof(DirectShape))
                .ToElementIds();

            return document.Delete(elementIds);
        }

        /// <summary>
        /// Creates a DirectShape element with the specified geometry and category.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="geometryObjects">The geometry objects for the DirectShape element.</param>
        /// <param name="builtInCategory">The category for the DirectShape element. The default value is <see cref="ConstBuiltInCategory"/>.</param>
        /// <returns>The created DirectShape element.</returns>
        public static DirectShape CreateDirectShape(this Document document,
            IEnumerable<GeometryObject> geometryObjects,
            BuiltInCategory builtInCategory = ConstBuiltInCategory)
        {
            // Obtains the ElementId of the BuiltInCategory
            ElementId categoryId = new ElementId(builtInCategory);

            // Creates a DirectShape element
            DirectShape ds = DirectShape.CreateElement(document, categoryId);

            // Sets the geometry objects of the DirectShape element
            ds.SetShape(new List<GeometryObject>(geometryObjects));

            // Sets the name of the DirectShape element as the name of the category
            ds.SetName(ds.Category.Name);

            // Returns the created DirectShape element
            return ds;
        }
        /// <summary>
        /// Creates a DirectShape element with the specified geometry and category.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="geometryObject">The geometry object for the DirectShape element.</param>
        /// <param name="builtInCategory">The category for the DirectShape element. The default value is <see cref="ConstBuiltInCategory"/>.</param>
        /// <returns>The created DirectShape element.</returns>
        public static DirectShape CreateDirectShape(this Document document,
            GeometryObject geometryObject,
            BuiltInCategory builtInCategory = ConstBuiltInCategory)
        {
            return CreateDirectShape(document, new[] { geometryObject }, builtInCategory);
        }

        /// <summary>
        /// Creates a DirectShapeType type with the specified geometry and category. 
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="geometryObjects">The geometry objects for the DirectShape element.</param>
        /// <param name="typeName">The name of the DirectShapeType. The default value is the Category Name.</param>
        /// <param name="builtInCategory">The category for the DirectShape element. The default value is <see cref="ConstBuiltInCategory"/>.</param>
        /// <returns>The created DirectShapeType type.</returns>
        public static DirectShapeType CreateDirectShapeType(this Document document,
            IEnumerable<GeometryObject> geometryObjects,
            string typeName = null,
            BuiltInCategory builtInCategory = ConstBuiltInCategory)
        {
            if (string.IsNullOrWhiteSpace(typeName))
                typeName = Category.GetCategory(document, builtInCategory).Name;

            DirectShapeType directShapeType =
                DirectShapeType.Create(document, typeName, new ElementId(builtInCategory));

            // Sets the geometry objects of the DirectShapeType type
            directShapeType.SetShape(new List<GeometryObject>(geometryObjects));

            // Store DirectShapeType in the library
            DirectShapeLibrary.GetDirectShapeLibrary(document)
                .AddDefinitionType(directShapeType.GetDefinitionId(), directShapeType.Id);

            return directShapeType;
        }

        /// <summary>
        /// Creates a DirectShapeType type with the specified geometry and category. 
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="geometryObject">The geometry object for the DirectShape element.</param>
        /// <param name="typeName">The name of the DirectShapeType. The default value is the Category Name.</param>
        /// <param name="builtInCategory">The category for the DirectShape element. The default value is <see cref="ConstBuiltInCategory"/>.</param>
        /// <returns>The created DirectShapeType type.</returns>
        public static DirectShapeType CreateDirectShapeType(this Document document,
            GeometryObject geometryObject,
            string typeName = null,
            BuiltInCategory builtInCategory = ConstBuiltInCategory)
        {
            return CreateDirectShapeType(document, new[] { geometryObject }, typeName, builtInCategory);
        }

        /// <summary>
        /// Create a DirectShape element with a DirectShapeType and Transform.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="directShapeType">The DirectShapeType type for the DirectShape element.</param>
        /// <param name="transform">The transform location and rotation for the DirectShape element.</param>
        /// <returns>The created DirectShape element.</returns>
        public static DirectShape CreateDirectShape(this Document document,
            DirectShapeType directShapeType,
            Transform transform = null)
        {
            transform = transform ?? Transform.Identity;

            DirectShape directShape = DirectShape.CreateElementInstance(document, directShapeType.Id,
                directShapeType.Category.Id, directShapeType.GetDefinitionId(), transform);

            // Sets the name of the DirectShape element as the name of the category
            directShape.SetName(directShape.Category.Name);

            return directShape;
        }

        /// <summary>
        /// Create a DirectShape element with a DirectShapeType and Transform.
        /// </summary>
        /// <param name="directShapeType">The DirectShapeType type for the DirectShape element.</param>
        /// <param name="transform">The transform location and rotation for the DirectShape element.</param>
        /// <returns>The created DirectShape element.</returns>
        public static DirectShape Create(this DirectShapeType directShapeType,
            Transform transform = null)
        {
            return directShapeType.Document.CreateDirectShape(directShapeType, transform);
        }

        /// <summary>
        /// Get the definition id of the DirectShapeType type using the Id of the type.
        /// </summary>
        /// <param name="directShapeType">The DirectShapeType type.</param>
        /// <returns>The definition id of the DirectShapeType type.</returns>
        public static string GetDefinitionId(this DirectShapeType directShapeType)
        {
            return directShapeType.Id.ToString();
        }
    }
}
