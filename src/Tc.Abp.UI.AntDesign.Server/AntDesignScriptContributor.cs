using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tc.Abp.UI.AntDesign.Server
{
    public class AntDesignScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            foreach (var script in AntDesignThemeConst.SCRIPTS)
            {
                context.Files.AddIfNotContains($"/{script}");
            }
        }
    }
}
