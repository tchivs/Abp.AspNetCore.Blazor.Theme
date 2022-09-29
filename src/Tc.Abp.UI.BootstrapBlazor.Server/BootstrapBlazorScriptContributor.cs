using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tc.Abp.UI.BootstrapBlazor.Server
{
    public class BootstrapBlazorScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            foreach (var script in BootstrapBlazorThemeConst.SCRIPTS)
            {
                context.Files.AddIfNotContains($"/{script}");
            }
        }
    }
}
