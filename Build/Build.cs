using Nuke.Common;
using Nuke.Common.Execution;
using ricaun.Nuke;
using ricaun.Nuke.Components;

class Build : NukeBuild, IPublishPack, IPrePack, ICompileExample, ITest
{
    string IHazExample.Name => "ricaun.Revit.DB.*";
    public static int Main() => Execute<Build>(x => x.From<IPublishPack>().Build);
}
