using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Material_Tests : OneTimeOpenDocumentTransactionTest
    {
        public ElementId MaterialId => Material.Id;
        public ElementId GraphicsStyleId => GraphicsStyle.Id;

        public Material Material { get; set; }
        public GraphicsStyle GraphicsStyle { get; set; }

        [SetUp]
        public void SetupMaterial()
        {
            Material = MaterialUtils.CreateMaterialWhite(document);
            GraphicsStyle = GraphicsStyleUtils.CreateLineColorWhite(document);
        }

        [TearDown]
        public void TearDownMaterial()
        {
            document.Delete(Material.Id);
            document.Delete(GraphicsStyle.GraphicsStyleCategory.Id);

        }

        [Test]
        public void CreateBox_Material()
        {
            var solid = ShapeCreator.CreateBox(XYZ.Zero, 1, MaterialId);
            AssertUtils.Material(solid, MaterialId, ElementId.InvalidElementId);
        }

        [Test]
        public void CreateBox_Material_GraphicsStyle()
        {
            var solid = ShapeCreator.CreateBox(XYZ.Zero, 1, MaterialId, GraphicsStyleId);
            AssertUtils.Material(solid, MaterialId, GraphicsStyleId);
        }

        [Test]
        public void CreateSphere_Material()
        {
            var solid = ShapeCreator.CreateSphere(XYZ.Zero, 1, MaterialId);
            AssertUtils.Material(solid, MaterialId, ElementId.InvalidElementId);
        }

        [Test]
        public void CreateSphere_Material_GraphicsStyle()
        {
            var solid = ShapeCreator.CreateSphere(XYZ.Zero, 1, MaterialId, GraphicsStyleId);
            AssertUtils.Material(solid, MaterialId, GraphicsStyleId);
        }

        [Test]
        public void CreateCylinder_Material()
        {
            var solid = ShapeCreator.CreateCylinder(XYZ.Zero, 1, materialId: MaterialId);
            AssertUtils.Material(solid, MaterialId, ElementId.InvalidElementId);
        }

        [Test]
        public void CreateCylinder_Material_GraphicsStyle()
        {
            var solid = ShapeCreator.CreateCylinder(XYZ.Zero, 1, materialId: MaterialId, graphicsStyleId: GraphicsStyleId);
            AssertUtils.Material(solid, MaterialId, GraphicsStyleId);
        }

        [Test]
        public void CreatePointer_Material()
        {
            var solid = ShapeCreator.CreatePointer(XYZ.Zero, 1, materialId: MaterialId);
            AssertUtils.Material(solid, MaterialId, ElementId.InvalidElementId);
        }

        [Test]
        public void CreatePointer_Material_GraphicsStyle()
        {
            var solid = ShapeCreator.CreatePointer(XYZ.Zero, 1, materialId: MaterialId, graphicsStyleId: GraphicsStyleId);
            AssertUtils.Material(solid, MaterialId, GraphicsStyleId);
        }

        [Test]
        public void CreateArrow_Material()
        {
            var solid = ShapeCreator.CreateArrow(MaterialId);
            AssertUtils.Material(solid, MaterialId, ElementId.InvalidElementId);
        }

        [Test]
        public void CreateArrow_Material_GraphicsStyle()
        {
            var solid = ShapeCreator.CreateArrow(MaterialId, GraphicsStyleId);
            AssertUtils.Material(solid, MaterialId, GraphicsStyleId);
        }

        [Test]
        public void CreateGizmo_Material()
        {
            var solid = ShapeCreator.CreateGizmo(MaterialId, MaterialId, MaterialId);
            AssertUtils.Material(solid, MaterialId, ElementId.InvalidElementId);
        }

        [Test]
        public void CreateGizmo_Material_GraphicsStyle()
        {
            var solid = ShapeCreator.CreateGizmo(MaterialId, MaterialId, MaterialId, GraphicsStyleId);
            AssertUtils.Material(solid, MaterialId, GraphicsStyleId);
        }

        [Test]
        public void CreateGizmo_Document()
        {
            var materialRed = MaterialUtils.CreateMaterialRed(document);
            var materialGreen = MaterialUtils.CreateMaterialGreen(document);
            var materialBlue = MaterialUtils.CreateMaterialBlue(document);

            var solid = ShapeCreator.CreateGizmo(document);
            AssertGizmo(solid, materialRed.Id, materialGreen.Id, materialBlue.Id, ElementId.InvalidElementId);
        }

        [Test]
        public void CreateGizmo_Document_GraphicsStyle()
        {
            var materialRed = MaterialUtils.CreateMaterialRed(document);
            var materialGreen = MaterialUtils.CreateMaterialGreen(document);
            var materialBlue = MaterialUtils.CreateMaterialBlue(document);

            var solid = ShapeCreator.CreateGizmo(document, GraphicsStyleId);
            AssertGizmo(solid, materialRed.Id, materialGreen.Id, materialBlue.Id, GraphicsStyleId);
        }

        private void AssertGizmo(Solid solid,
            ElementId materialElementIdRed,
            ElementId materialElementIdGreen,
            ElementId materialElementIdBlue,
            ElementId graphicsStyleId)
        {
            AssertUtils.Material(solid, new[] { materialElementIdRed, materialElementIdGreen, materialElementIdBlue }, graphicsStyleId);
        }
    }
}