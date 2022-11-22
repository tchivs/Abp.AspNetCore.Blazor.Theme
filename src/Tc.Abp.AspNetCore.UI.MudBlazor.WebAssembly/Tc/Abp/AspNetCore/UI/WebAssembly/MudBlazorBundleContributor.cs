using Tc.Abp.AspNetCore.Components.WebAssembly;
using Tc.Abp.AspNetCore.UI;
using Volo.Abp.Bundling;

namespace Tc.Abp.AspNetCore.UI.WebAssembly;

public class MudBlazorBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

        foreach (var script in MudBlazorThemeConst.SCRIPTS)
        {
            context.Add(script);
        }
    }
    public void AddStyles(BundleContext context)
    {
        foreach (var style in MudBlazorThemeConst.STYLES)
        {
            context.Add(style);
        }
    }
}