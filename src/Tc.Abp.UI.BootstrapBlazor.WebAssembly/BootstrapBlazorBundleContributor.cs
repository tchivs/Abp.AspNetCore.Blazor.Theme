using Tc.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Bundling;

namespace Tc.Abp.UI.BootstrapBlazor.WebAssembly;

public class BootstrapBlazorBundleContributor : IBundleContributor
{
    public   void AddScripts(BundleContext context)
    {
       
        foreach (var script in BootstrapBlazorThemeConst.SCRIPTS)
        {
            context.Add(script);
        }
    }
    public   void AddStyles(BundleContext context)
    {
        foreach (var style in BootstrapBlazorThemeConst.STYLES)
        {
            context.Add(style);
        }
    }
}