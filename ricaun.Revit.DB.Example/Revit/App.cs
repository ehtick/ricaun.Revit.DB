using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System;

namespace ricaun.Revit.DB.Example.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("ricaun.Revit.DB");
            //ribbonPanel.CreatePushButton<ricaun.Revit.DB.Quaternion.Revit.Commands.QuaternionCommand>("Quaternion\rView")
            //    .SetLargeImage("Resources/Revit.ico");

            ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeCommand>("Shape\rCreator")
                .SetLargeImage("Resources/Revit.ico");

            ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeBoxCommand>("Shape Box\rCreator")
                .SetLargeImage("Resources/Revit.ico");

            ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeArrowCommand>("Shape Arrow\rCreator")
                .SetLargeImage("Resources/Revit.ico");

            ribbonPanel.RowStackedItems(
                ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeGizmoCommand>("Shape Gizmo\rCreator")
                    .SetLargeImage("Resources/Revit.ico"),

                ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeGizmoSidesCommand>("Shape Gizmo Sides\rCreator")
                    .SetLargeImage("Resources/Revit.ico"),

                ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeGizmoFullCommand>("Shape Gizmo Full\rCreator")
                    .SetLargeImage("Resources/Revit.ico")
            );
            ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeColorsCommand>("Shape\rColors")
                .SetLargeImage("Resources/Revit.ico");
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            return Result.Succeeded;
        }
    }

}