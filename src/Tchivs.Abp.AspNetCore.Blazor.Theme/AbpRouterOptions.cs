using System.Collections.Generic;
using System.Reflection;
using Volo.Abp.AspNetCore.Components;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme
{
    public class AbpRouterOptions
    {
        public Assembly? AppAssembly { get; set; }

        public List<Assembly>  AdditionalAssemblies { get; }

        public AbpRouterOptions()
        {
            AdditionalAssemblies = new List<Assembly>();
        }
    }
}