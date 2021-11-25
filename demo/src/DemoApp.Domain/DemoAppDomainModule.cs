using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace DemoApp
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(DemoAppDomainSharedModule)
    )]
    public class DemoAppDomainModule : AbpModule
    {

    }
}
