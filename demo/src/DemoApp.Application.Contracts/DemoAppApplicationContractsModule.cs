using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace DemoApp
{
    [DependsOn(
        typeof(DemoAppDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class DemoAppApplicationContractsModule : AbpModule
    {

    }
}
