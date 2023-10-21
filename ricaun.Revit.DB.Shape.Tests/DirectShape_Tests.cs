using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Tests
{

    public class DirectShape_Tests : OneTimeOpenDocumentTransactionTest
    {
        [Test]
        public void DirectShape_Point()
        {
            var point = Point.Create(XYZ.Zero);
            var directShape = document.CreateDirectShape(point);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Point>(directShape, 1);
        }

        [Test]
        public void DirectShape_Point_Transformed()
        {
            var point = Point.Create(XYZ.Zero)
                .CreateTransformed(Transform.CreateTranslation(XYZ.BasisZ));

            var directShape = document.CreateDirectShape(point);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Point>(directShape, 1);
        }

        [Test]
        public void DirectShape_Line()
        {
            var line = Line.CreateBound(XYZ.Zero, XYZ.BasisZ);
            var directShape = document.CreateDirectShape(line);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Line>(directShape, 1);
        }

        [Test]
        public void DirectShape_LineUnbound_Should_Fail()
        {
            var line = Line.CreateUnbound(XYZ.Zero, XYZ.BasisZ);
            Assert.Throws<Autodesk.Revit.Exceptions.ArgumentException>(() => document.CreateDirectShape(line));
        }

        [Test]
        public void DirectShape_Line_Transformed()
        {
            var line = Line.CreateBound(XYZ.Zero, XYZ.BasisZ)
                .CreateTransformed(Transform.CreateTranslation(XYZ.BasisZ));
            var directShape = document.CreateDirectShape(line);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Line>(directShape, 1);
        }

        [Test]
        public void DirectShape_Arc()
        {
            var arc = Arc.Create(XYZ.Zero, 1, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
            var directShape = document.CreateDirectShape(arc);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Arc>(directShape, 1);
        }

        [Test]
        public void DirectShape_Ellipse()
        {
            var ellipse = Ellipse.CreateCurve(XYZ.Zero, 1, 2, XYZ.BasisX, XYZ.BasisY, 0, Math.PI);
            var directShape = document.CreateDirectShape(ellipse);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Ellipse>(directShape, 1);
        }

        IList<XYZ> controlPoints = new List<XYZ>() { XYZ.Zero, XYZ.BasisX, 2.0 * XYZ.BasisX + XYZ.BasisY, 3.0 * XYZ.BasisX, 4.0 * XYZ.BasisX };
        IList<double> weights = new List<double>() { 1.0, 1.0, 1.0, 1.0, 1.0 };

        [Test]
        public void DirectShape_HermiteSpline()
        {
            var hermiteSpline = HermiteSpline.Create(controlPoints, false, new HermiteSplineTangents() { StartTangent = XYZ.BasisX, EndTangent = XYZ.BasisX });
            var directShape = document.CreateDirectShape(hermiteSpline);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<HermiteSpline>(directShape, 1);
        }

        [Test]
        public void DirectShape_NurbSpline()
        {
            var nurbSpline = NurbSpline.CreateCurve(controlPoints, weights);
            var directShape = document.CreateDirectShape(nurbSpline);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<NurbSpline>(directShape, 1);
        }

        [Test]
        public void DirectShape_CylindricalHelix()
        {
            var cylindricalHelix = CylindricalHelix.Create(XYZ.Zero, 1, XYZ.BasisY, XYZ.BasisX, 1.0, 0, 10 * Math.PI);
            var directShape = document.CreateDirectShape(cylindricalHelix);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<CylindricalHelix>(directShape, 1);
        }


        [Test]
        public void DirectShape_PolyLine()
        {
            var polyline = PolyLine.Create(controlPoints);
            var directShape = document.CreateDirectShape(polyline);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<PolyLine>(directShape, 1);
        }

        [Test]
        public void DirectShape_PolyLine_Transformed()
        {
            var polyline = PolyLine.Create(controlPoints)
                .CreateTransformed(Transform.CreateTranslation(XYZ.BasisZ));

            var directShape = document.CreateDirectShape(polyline);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<PolyLine>(directShape, 1);
        }

        [Test]
        public void DirectShape_BoxLines()
        {
            var lines = ShapeCreator.CreateBoxLines(XYZ.Zero, 1);
            var directShape = document.CreateDirectShape(lines);

            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Line>(directShape, 12);
        }

        [Test]
        public void DirectShape_Gizmo()
        {
            var gizmo = ShapeCreator.CreateGizmo(document);
            var directShape = document.CreateDirectShape(gizmo);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Solid>(directShape, 1);
        }

        [Test]
        public void DirectShape_Gizmo_Transformed()
        {
            var gizmo = ShapeCreator.CreateGizmo(document)
                .CreateTransformed(Transform.CreateTranslation(XYZ.BasisZ));

            var directShape = document.CreateDirectShape(gizmo);
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Solid>(directShape, 1);
        }

        [Test]
        public void DirectShapeType_Gizmo()
        {
            var gizmo = ShapeCreator.CreateGizmo(document);
            var directShapeType = document.CreateDirectShapeType(gizmo);

            var directShape = directShapeType.Create();
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Solid>(directShape, 1);
        }

        [Test]
        public void DirectShapeType_Gizmo_Transformed()
        {
            var gizmo = ShapeCreator.CreateGizmo(document);
            var directShapeType = document.CreateDirectShapeType(gizmo);

            var directShape = directShapeType.Create(Transform.CreateTranslation(XYZ.BasisZ));
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Solid>(directShape, 1);
        }

        [Test]
        public void DirectShapeType_BoxLines()
        {
            var lines = ShapeCreator.CreateBoxLines(XYZ.Zero, 1);
            var directShapeType = document.CreateDirectShapeType(lines);

            var directShape = directShapeType.Create();
            Assert.IsNotNull(directShape);
            AssertUtils.Geometry<Line>(directShape, 12);
        }

        [Test]
        public void DirectShape_Delete()
        {
            var gizmo = ShapeCreator.CreateGizmo(document);
            var directShape = document.CreateDirectShape(gizmo);
            var directShapeId = directShape.Id;

            var elementIds = document.DeleteDirectShape();
            Assert.Contains(directShapeId, elementIds.ToList());
        }

        [Test]
        public void DirectShape_Delete_BuiltInCategory()
        {
            var gizmo = ShapeCreator.CreateGizmo(document);
            var directShape = document.CreateDirectShape(gizmo, BuiltInCategory.OST_ElectricalEquipment);
            var directShapeId = directShape.Id;

            var elementIds = document.DeleteDirectShape(BuiltInCategory.OST_ElectricalEquipment);
            Assert.Contains(directShapeId, elementIds.ToList());
            Assert.AreEqual(1, elementIds.Count);
        }
    }
}