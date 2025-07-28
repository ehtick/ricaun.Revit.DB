# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.0.0] / 2025-07-22
### Features
- `ricaun.Revit.DB` with `Select` extension for `Element` and `ElementType`.
### Updates
- Remove `2017` support.
- Add `ricaun.Revit.DB.Generator` to generate `ricaun.Revit.DB` code select extension.
- Update `FilterRuleBuiltInParameterExtension` to support `Filter` extension to `Equals`.
- Update `FilterRuleBuiltInParameterExtension` to support `Filter` with inverted options.
- Update `ElementIdExtension` to fix `ElementIdValue`.
- Add `FilterBuiltInCategoryExtension` to support filter by `BuiltInCategory`.
- Update `InverseRule` in `FilterRuleExtension`.
### Tests
- Add `ricaun.Revit.DB.Tests` to test `Select` extension for `Element` and `ElementType`.
- Add `RevitFilterExtensionTest` tests for `ElementFilterExtension`.
- Add `RevitElementIdExtensionTest` and `RevitElementIdToElementExtensionTest` tests for `ElementIdExtension`.
- Add `RevitFilterCategoryExtension` tests for `FilterBuiltInCategoryExtension`.
- Add `RevitSelectElementExtensionTest` tests for select and get elements with filters.
- Add `RevitRuleExtensionTest` test for `FilterRuleExtension`.
### Shapes
- Add `CreateSwept` to `ShapeCreator` to create a swept solid.
### Generator
- Add `SelectElements<T>` and `SelectElementTypes<T>` in the generator to generate `Select` extension methods for `Element` and `ElementType`.

## [0.4.0] / 2024-09-23 - 2025-03-22
### Features
- Support `SymbolPackageFormat`.
### Shapes
- Add `BRepBuilderExtension` with extension for face and solid.
### Tests
- Add `Shape_BRepBuilder_Tests` to test `BRepBuilderExtension`.

## [0.3.2] / 2024-06-14
### Shapes
- Update Colors using the `System.Windows.Media.Colors` as reference.
- Update `MaterialUtils` and `GraphicsStyleUtils` with default 9 colors.
- Add `ColorExtension` with `ColorEquals`, `Lerp`, `ToColor` and `ToColorWithTransparency`.
- Add `ColorExtension` with `ToHex` for `Color` and `ColorWithTransparency`
- Update `CreateBoxLines` with `graphicsStyleId`
- Add `CreateLines` in `ShapeCreator`
### Tests
- Test all color names in `System.Windows.Media.Colors` with `Colors`.
- Test all 9 colors in `MaterialUtils` and `GraphicsStyleUtils`.
- Test for `ColorExternsion`
- Test `MaterialId` and `GraphicsStyleId`.
- Test `CreateLines` with `closed` and `GraphicsStyleId`.

## [0.3.1] / 2024-01-09 - 2024-04-13
### Features
- Support Revit 2025
### Tests
- Test in Revit 2025 / 2024

## [0.3.0] / 2023-10-24 - 2023-11-01
### Shape
- Rename `indexes` to `indices`.
- Rename shape `Pointer` to `Cone`
- Add `LevelOfDetail` methods to Triangulate face/solid.
- Update `VerticesExtension` with `GetMaterialId` and `GetTriangleMaterialIds`.
- Update `MaterialUtils` with `GetColor` and `GetColorWithTransparency`
- Add `CreatePyramid` and `CreatePrism`
- Add internal `CreateCircleLoopVertices`
- Change `Gizmo` to return `Solid[]`
- Add `Arrow` and `Gizmo` with sides options (max sides 10).
- Update `GetFaces` to `GetFacesRegions`
### Shape.Tests
- Test Triangulate Vertices `LevelOfDetail`
- Test `GetMaterialId` and `GetTriangleMaterialIds`.
- Test Material `ColorWithTransparency`
- Test `CreatePyramid` and `CreatePrism`
- Test `Arrow` and `Gizmo` with sides.
- Test `GetFaces` to `GetFacesRegions` with `Box2021.rfa`

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
[1.0.0]: ../../compare/0.4.0...1.0.0
[0.4.0]: ../../compare/0.3.2...0.4.0
[0.3.2]: ../../compare/0.3.1...0.3.2
[0.3.1]: ../../compare/0.3.0...0.3.1
[0.3.0]: ../../compare/0.2.0...0.3.0
[0.2.0]: ../../compare/0.1.0...0.2.0
[0.1.0]: ../../compare/0.1.0