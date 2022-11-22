using Tc.Abp.AspNetCore;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName;

[DependsOn(typeof(TcAbpAspNetCoreModule))]
public class MyCompanyNameMyProjectNameBlazorSharedModule:AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(MyCompanyNameMyProjectNameBlazorSharedModule).Assembly);
        });
    }


}
