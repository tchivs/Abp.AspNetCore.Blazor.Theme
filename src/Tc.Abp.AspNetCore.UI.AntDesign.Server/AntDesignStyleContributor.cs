using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tc.Abp.AspNetCore.UI.Server
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
