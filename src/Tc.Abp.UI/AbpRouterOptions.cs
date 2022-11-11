using System.Reflection;

namespace Tc.Abp.UI;

public class AbpRouterOptions
{
    public Assembly AppAssembly { get=>AppType.Assembly;   }
    public Type AppType { get; set; }
    public Type DefaultLayout { get; set; }
    public Type NotFoundLayout { get; set; }
    public List<Assembly> AdditionalAssemblies { get; }
    public AbpRouterOptions()
    {
        AdditionalAssemblies = new List<Assembly>();
    }
}

