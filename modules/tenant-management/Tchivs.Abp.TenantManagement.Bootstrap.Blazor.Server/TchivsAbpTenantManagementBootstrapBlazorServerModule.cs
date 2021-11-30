using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchivs.Abp.FeatureManagement.Bootstrap.Blazor.Server;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.TenantManagement.Bootstrap.Blazor.Server
{
    [DependsOn(
 typeof(TchivsAbpTenantManagementBootstrapBlazorModule),
        typeof(TchivsAbpFeatureManagementBootstrapBlazorServerModule)
           )]
    public class TchivsAbpTenantManagementBootstrapBlazorServerModule : AbpModule
    {

    }
}
