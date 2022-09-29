using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tc.Abp.UI.MasaBlazor.Server
{
    public class MasaBlazorScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            foreach (var script in MasaBlazorThemeConst.SCRIPTS)
            {
                context.Files.AddIfNotContains($"/{script}");
            }
        }
    }
}
