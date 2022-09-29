using Volo.Abp.Bundling;
namespace Tchivs.Abp.AspNetCore.Components.WebAssembly;
    public class BasicBundleContributor : IBundleContributor
    {
        public virtual void AddScripts(BundleContext context)
        {
            context.Add("_content/Microsoft.AspNetCore.Components.WebAssembly.Authentication/AuthenticationService.js");
            context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
            context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/lang-utils.js");
        }
        public virtual void AddStyles(BundleContext context)
        {
       
        }
    }
