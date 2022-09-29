using Tc.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Bundling;

namespace Tc.Abp.UI.AntDesign.WebAssembly;

public class AntDesignBundleContributor : IBundleContributor
{
    public   void AddScripts(BundleContext context)
    {
       
        foreach (var script in AntDesignThemeConst.SCRIPTS)
        {
            context.Add(script);
        }
    }
    public   void AddStyles(BundleContext context)
    {
        foreach (var style in AntDesignThemeConst.STYLES)
        {
            context.Add(style);
        }
    }
}