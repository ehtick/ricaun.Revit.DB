using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System;

namespace ricaun.Revit.Debug.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("ricaun.Revit.DB");
            ribbonPanel.CreatePushButton<ricaun.Revit.DB.Quaternion.Revit.Commands.QuaternionCommand>("Quaternion\rView")
                .SetLargeImage("/UIFrameworkRes;component/ribbon/images/revit.ico");

            ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeCommand>("Shape\rCreator")
                .SetLargeImage("/UIFrameworkRes;component/ribbon/images/revit.ico");

            ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeBoxCommand>("Shape Box\rCreator")
                .SetLargeImage("/UIFrameworkRes;component/ribbon/images/revit.ico");

            ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeArrowCommand>("Shape Arrow\rCreator")
                .SetLargeImage("/UIFrameworkRes;component/ribbon/images/revit.ico");

            ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeGizmoCommand>("Shape Gizmo\rCreator")
                .SetLargeImage("/UIFrameworkRes;component/ribbon/images/revit.ico");

            ribbonPanel.CreatePushButton<ricaun.Revit.DB.Shape.Revit.Commands.ShapeColorsCommand>("Shape\rColors")
                .SetLargeImage("/UIFrameworkRes;component/ribbon/images/revit.ico");
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            return Result.Succeeded;
        }
    }

}