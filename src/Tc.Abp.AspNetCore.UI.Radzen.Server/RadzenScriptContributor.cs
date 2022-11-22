using Tc.Abp.AspNetCore.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tc.Abp.AspNetCore.Radzen.Server
{
    public class RadzenScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            foreach (var script in RadzenThemeConst.SCRIPTS)
            {
                context.Files.AddIfNotContains($"/{script}");
            }
        }
    }
}
