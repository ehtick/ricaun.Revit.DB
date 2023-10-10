using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using NUnit.Framework;
using System;

namespace ricaun.Revit.DB.Shape.Tests.Utils
{
    /// <summary>
    /// OneTimeOpenDocumentTest
    /// </summary>
    public class OneTimeOpenDocumentTest
    {
        protected Document document;
        protected Application application;
        protected virtual string FileName => "";

        [OneTimeSetUp]
        public void NewProjectDocument(Application application)
        {
            this.application = application;
            if (string.IsNullOrEmpty(FileName))
            {
                this.document = application.NewProjectDocument(UnitSystem.Metric);
                return;
            }
            this.document = application.OpenDocumentFile(FileName);
        }

        [OneTimeTearDown]
        public void CloseProjectDocument()
        {
            this.document.Close(false);
            this.document.Dispose();
        }

    }
}