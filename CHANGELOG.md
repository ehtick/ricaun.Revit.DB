# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.3.0] / 2023-10-24
### Shape
- Rename `indexes` to `indices`.
- Rename shape `Pointer` to `Cone`
- Add `LevelOfDetail` methods to Triangulate face/solid.
- Update `VerticesExtension` with `GetMaterialId` and `GetTriangleMaterialIds`.
- Update `MaterialUtils` with `GetColor` and `GetColorWithTransparency`
### Shape.Tests
- Test Triangulate Vertices `LevelOfDetail`
- Test `GetMaterialId` and `GetTriangleMaterialIds`.
- Test Material `ColorWithTransparency`

## [0.2.0] / 2023-10-01 - 2023-10-21
### Shape
- Create Project `ricaun.Revit.DB.Shape`
- Update `SolidExtension` - `GetOrigin`
- Add `GraphicsStyleUtils` to create LineColor
- Add `VerticesExtension` for vertices
- Update `TessellatedShapeCreator`
- Add `XYZUtils`
### Shape.Tests
- Create Project `ricaun.Revit.DB.Shape.Tests`
- Tests for `MaterialUtils`
- Tests for `Colors`
- Tests for `TransformUtils`
- Tests for `ShapeCreator` (Box, BoxLine, Cylinder, Pointer, Sphere, Arrow, Gizmo)
- Tests for `DirectShapeUtils`
- Tests for `TessellatedShapeCreator`
- Tests for `Vertices`

## [0.1.0] / 2023-10-01
### Quaternion
- Create Project `ricaun.Revit.DB.Quaternion`
- Create Project `ricaun.Revit.DB.Quaternion.Tests`
### DB
- Change csproj to `IncludeBuildOutput` false

## [0.0.1] / 2023-09-30
- Create Project `ricaun.Revit.DB`

[vNext]: ../../compare/0.1.0...HEAD
[0.3.0]: ../../compare/0.2.0...0.3.0
[0.2.0]: ../../compare/0.1.0...0.2.0
[0.1.0]: ../../compare/0.1.0