using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tc.Abp.UI.MasaBlazor.Server
{
    public class MasaBlazorStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            foreach (var css in MasaBlazorThemeConst.STYLES)
            {
                context.Files.AddIfNotContains($"/{css}");
            }
        }
    }
}
