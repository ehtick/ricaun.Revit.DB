using Autodesk.Revit.DB;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Tests
{
    public class RevitElementIdToElementExtensionTest : Utils.OneTimeOpenDocumentTest
    {
        [Test]
        public void ToElements_WhenEmptyList()
        {
            var elementIds = new List<ElementId>();
            var elements = elementIds.ToElements<Element>(document);
            Console.WriteLine(elementIds);

            Assert.AreEqual(0, elements.Count());
        }

        [Test]
        public void ToElements_WhenEmptyEnumerable()
        {
            var elementIds = new List<ElementId>() { ElementId.InvalidElementId }.Where(e => e.IsValid());
            var elements = elementIds.ToElements<Element>(document);
            Console.WriteLine(elementIds);

            Assert.AreEqual(0, elements.Count());
        }

        [Test]
        public void ProjectInformation()
        {
            var id = document.ProjectInformation.Id;
            Assert.IsTrue(id.IsValid());

            var element = id.ToElement(document);
            Assert.IsNotNull(element);

            var projectInfo = id.ToElement<ProjectInfo>(document);
            Assert.IsNotNull(projectInfo);

            Assert.AreEqual(projectInfo.Id, element.Id);
        }

        [Test]
        public void ProjectInformationSelect()
        {
            var id = document.ProjectInformation.Id;
            Assert.IsTrue(id.IsValid());

            var elementIds = document.GetElementIds<ProjectInfo>();
            var elements = elementIds.ToElements(document);

            Assert.AreEqual(1, elements.Count());

            var projectInfos = elementIds.ToElements<ProjectInfo>(document);

            Assert.AreEqual(1, projectInfos.Count());
        }

        [Test]
        public void ProjectInformationNotFamilyInstance()
        {
            var id = document.ProjectInformation.Id;
            Assert.IsTrue(id.IsValid());

            var element = id.ToElement<FamilyInstance>(document);
            Assert.IsNull(element);
        }

        [Test]
        public void ProjectInformationToElementIds()
        {
            var projectInfos = document.GetElements<ProjectInfo>();
            Assert.AreEqual(1, projectInfos.Count());

            var projectInfoIds = projectInfos.ToElementIds();
            Assert.AreEqual(1, projectInfoIds.Count());
        }

        [Test]
        public void ProjectInformationToElementIds_HashSet()
        {
            var projectInfos = document.GetElements<ProjectInfo>();
            var elements = new List<Element>(projectInfos);
            elements.AddRange(projectInfos);

            Assert.AreEqual(2, elements.Count);
            var elementIds = elements.ToElementIds();
            Assert.AreEqual(1, elementIds.Count());
        }
    }
}
