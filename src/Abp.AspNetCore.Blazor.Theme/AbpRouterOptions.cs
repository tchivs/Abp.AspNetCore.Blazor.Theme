using Abp.AspNetCore.Blazor.Theme.Localization;
using System.Reflection;
using Volo.Abp.AspNetCore.Components;

namespace Abp.AspNetCore.Blazor.Theme
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