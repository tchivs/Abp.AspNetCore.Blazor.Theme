using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tc.Abp.AspNetCore.UI.Server
{
    public class BootstrapBlazorStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            foreach (var css in BootstrapBlazorThemeConst.STYLES)
            {
                context.Files.AddIfNotContains($"/{css}");
            }
        }
    }
}
