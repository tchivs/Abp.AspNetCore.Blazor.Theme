using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName;

[DependsOn(typeof(Tc.Abp.UI.TcAbpUIModule))]
public class MyCompanyNameMyProjectNameBlazorSharedModule:AbpModule
{

}
