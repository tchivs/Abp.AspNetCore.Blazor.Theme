using Tc.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Bundling;

namespace Tc.Abp.UI.MasaBlazor.WebAssembly;

public class MasaBlazorBundleContributor : IBundleContributor
{
    public   void AddScripts(BundleContext context)
    {
       
        foreach (var script in MasaBlazorThemeConst.SCRIPTS)
        {
            context.Add(script);
        }
    }
    public   void AddStyles(BundleContext context)
    {
        foreach (var style in MasaBlazorThemeConst.STYLES)
        {
            context.Add(style);
        }
    }
}