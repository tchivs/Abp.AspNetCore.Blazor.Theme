using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
namespace Tchivs.Abp.Identity.Bootstrap.Blazor.WebAssembly
{
    [DependsOn(
        typeof(TchivsAbpIdentityBootstrapBlazorModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(AbpAspNetCoreBlazorThemeBootstrapWebAssemblyModule)
        )]
    public class TchivsAbpIdentityBootstrapBlazorWebAssemblyModule : AbpModule
    {

    }
}
