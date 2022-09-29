
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Bootstrap;

namespace Tc.Abp.AspNetCore.Components.Server;
    public class BlazorGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_framework/blazor.server.js");
            context.Files.AddIfNotContains("/_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
        }
    }
    //public class BlazorGlobalStyleContributor : BundleContributor
    //{
    //    public override void ConfigureBundle(BundleConfigurationContext context)
    //    {
    //        var name = typeof(Abp.UI.TchivsAbpUIModule).Namespace;
    //        context.Files.AddIfNotContains($"/_content/{name}/libs/fortawesome/css/all.css");
    //        context.Files.AddIfNotContains($"/_content/{name}/libs/fortawesome/css/v4-shims.css");
    //    }
    //}
