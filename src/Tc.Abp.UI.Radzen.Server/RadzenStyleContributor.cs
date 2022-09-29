using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tc.Abp.UI.Radzen.Server
{
    public class RadzenStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            foreach (var css in RadzenThemeConst.STYLES)
            {
                context.Files.AddIfNotContains($"/{css}");
            }
        }
    }
}
