using Tc.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Bundling;

namespace Tc.Abp.UI.Radzen.WebAssembly;

public class RadzenBundleContributor : IBundleContributor
{
    public   void AddScripts(BundleContext context)
    {
       
        foreach (var script in RadzenThemeConst.SCRIPTS)
        {
            context.Add(script);
        }
    }
    public   void AddStyles(BundleContext context)
    {
        foreach (var style in RadzenThemeConst.STYLES)
        {
            context.Add(style);
        }
    }
}