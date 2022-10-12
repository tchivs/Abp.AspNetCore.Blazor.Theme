using Tc.Abp.UI;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName;

[DependsOn(typeof(Tc.Abp.UI.TcAbpUIModule))]
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
