using Tc.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Bundling;

namespace Tc.Abp.UI.MudBlazor.WebAssembly;

public class MudBlazorBundleContributor : IBundleContributor
{
    public   void AddScripts(BundleContext context)
    {
       
        foreach (var script in MudBlazorThemeConst.SCRIPTS)
        {
            context.Add(script);
        }
    }
    public   void AddStyles(BundleContext context)
    {
        foreach (var style in MudBlazorThemeConst.STYLES)
        {
            context.Add(style);
        }
    }
}