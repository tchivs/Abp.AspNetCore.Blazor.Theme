using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tc.Abp.UI.AntDesign.Server
{
    public class AntDesignStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            foreach (var css in AntDesignThemeConst.STYLES)
            {
                context.Files.AddIfNotContains($"/{css}");
            }
        }
    }
}
