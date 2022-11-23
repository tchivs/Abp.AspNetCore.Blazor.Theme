using Microsoft.Extensions.DependencyInjection;
using Tc.Abp.AspNetCore.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tc.Abp.AspNetCore.UI.Server
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
