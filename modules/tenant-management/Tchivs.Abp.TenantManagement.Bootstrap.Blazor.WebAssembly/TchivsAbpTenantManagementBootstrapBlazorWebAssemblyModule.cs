using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchivs.Abp.FeatureManagement.Bootstrap.Blazor.WebAssembly;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Tchivs.Abp.TenantManagement.Bootstrap.Blazor.WebAssembly
{
    [DependsOn(
        typeof(TchivsAbpTenantManagementBootstrapBlazorModule),
        typeof(TchivsAbpFeatureManagementBootstrapBlazorWebAssemblyModule),
        typeof(AbpTenantManagementHttpApiClientModule)
        )]
    public class TchivsAbpTenantManagementBootstrapBlazorWebAssemblyModule : AbpModule
    {

    }
}
