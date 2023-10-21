using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using NUnit.Framework;
using System;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class RevitTests
    {
        [Test]
        public void RevitTests_VersionName(Application application)
        {
            Assert.IsNotNull(application);
            Console.WriteLine(application.VersionName);
        }
    }
}