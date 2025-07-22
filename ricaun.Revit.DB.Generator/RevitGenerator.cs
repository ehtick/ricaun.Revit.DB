using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ricaun.Revit.DB.Generator
{
    [Generator]
    public class RevitGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var nameSpaceName = "ricaun.Revit.DB";
            var fileName = "FilteredElementCollectorDocumentExtension";

            Invoke($"{fileName}A.g.cs", nameSpaceName, fileName, () => CreateAll());
            Invoke($"{fileName}AViewId.g.cs", nameSpaceName, fileName, () => CreateAll("ElementId viewId"));
            Invoke($"{fileName}ACollection.g.cs", nameSpaceName, fileName, () => CreateAll("ICollection<ElementId> elementIds"));
            Invoke($"{fileName}T.g.cs", nameSpaceName, fileName, () => CreateAllT());
            Invoke($"{fileName}TViewId.g.cs", nameSpaceName, fileName, () => CreateAllT("ElementId viewId"));
            Invoke($"{fileName}TCollection.g.cs", nameSpaceName, fileName, () => CreateAllT("ICollection<ElementId> elementIds"));

            void Invoke(string fileName, string nameSpaceName, string className, Func<SourceText> action)
            {
                context.RegisterPostInitializationOutput(postInitializationContext =>
                    postInitializationContext.AddSource(fileName, SourceText.From(
                        $$"""
                        using System;
                        using System.Collections.Generic;
                        using Autodesk.Revit.DB;
                        namespace {{nameSpaceName}}
                        {
                            /// <summary> {{className}} Generator </summary>
                            public static partial class {{className}}
                            {
                        {{action.Invoke()}}
                            }
                        }
                        """, Encoding.UTF8)));
            }

            SourceText CreateAll(string param = null)
            {
                var source = SourceText.From(
                    $$"""
                    {{CreateSelect("SelectElements", "FilteredElementCollector", "Select", "WhereElementIsNotElementType", param)}}
                    {{CreateSelect("SelectElementTypes", "FilteredElementCollector", "Select", "WhereElementIsElementType", param)}}
                    {{CreateSelect("GetElements", "IList<Element>", "SelectElements", "ToElements", param)}}
                    {{CreateSelect("GetElementTypes", "IList<Element>", "SelectElementTypes", "ToElements", param)}}
                    {{CreateSelect("GetElementIds", "ICollection<ElementId>", "SelectElements", "ToElementIds", param)}}
                    {{CreateSelect("GetElementTypeIds", "ICollection<ElementId>", "SelectElementTypes", "ToElementIds", param)}}
                    {{CreateSelect("GetFirstElement", "Element", "SelectElements", "FirstElement", param)}}
                    {{CreateSelect("GetFirstElementType", "Element", "SelectElementTypes", "FirstElement", param)}}
                    {{CreateSelect("GetFirstElementId", "ElementId", "SelectElements", "FirstElementId", param)}}
                    {{CreateSelect("GetFirstElementTypeId", "ElementId", "SelectElementTypes", "FirstElementId", param)}}
                    """, Encoding.UTF8);
                return source;
            }

            SourceText CreateAllT(string param = null)
            {
                var source = SourceText.From(
                    $$"""
                    {{CreateSelect("Select<TElement>", "FilteredElementCollector", "Select", "WhereElementIs<TElement>", param, "where TElement : Element")}}
                    {{CreateSelect("GetElements<TElement>", "IEnumerable<TElement>", "Select<TElement>", "ToElements<TElement>", param, "where TElement : Element")}}
                    {{CreateSelect("GetElementTypes<TElement>", "IEnumerable<TElement>", "Select<TElement>", "ToElements<TElement>", param, "where TElement : ElementType")}}
                    {{CreateSelect("GetElementIds<TElement>", "ICollection<ElementId>", "Select<TElement>", "ToElementIds", param, "where TElement : Element")}}
                    {{CreateSelect("GetElementTypeIds<TElement>", "ICollection<ElementId>", "Select<TElement>", "ToElementIds", param, "where TElement : ElementType")}}
                    {{CreateSelect("GetFirstElement<TElement>", "TElement", "Select<TElement>", "FirstElement<TElement>", param, "where TElement : Element")}}
                    {{CreateSelect("GetFirstElementType<TElement>", "TElement", "Select<TElement>", "FirstElement<TElement>", param, "where TElement : ElementType")}}
                    {{CreateSelect("GetFirstElementId<TElement>", "ElementId", "Select<TElement>", "FirstElementId", param, "where TElement : Element")}}
                    {{CreateSelect("GetFirstElementTypeId<TElement>", "ElementId", "Select<TElement>", "FirstElementId", param, "where TElement : ElementType")}}
                    """, Encoding.UTF8);
                return source;
            }

            SourceText CreateSelect(string name, string result, string methodName, string methodExtension, string param = null, string where = null)
            {
                var source = SourceText.From(
                    $$"""
                            {{Create(name, result, methodName, methodExtension, where, param)}}
                            {{Create(name, result, methodName, methodExtension, where, param, "BuiltInCategory category")}}
                            {{Create(name, result, methodName, methodExtension, where, param, "BuiltInCategory category", "params IEnumerable<ElementFilter> filters")}}
                            {{Create(name, result, methodName, methodExtension, where, param, "params IEnumerable<ElementFilter> filters")}}
                    """, Encoding.UTF8);
                return source;
            }

            string Create(string name, string result, string methodName, string methodExtension, string where, params IEnumerable<string> args)
            {
                args = args.OfType<string>();
                if (!string.IsNullOrEmpty(where))
                    where += " ";

                var methodArgs = string.Join(", ", args.Select(arg => arg.Trim().Split(' ').Last()));

                var list = new List<string>();
                list.Add("this Document document");
                list.AddRange(args);
                string mainArgs = string.Join(", ", list);
                return
                    $$"""
                    /// <summary> Generator </summary>
                    public static {{result}} {{name}}({{mainArgs}}) {{where}}=> document.{{methodName}}({{methodArgs}}).{{methodExtension}}();
                    """;
            }
        }
    }
}