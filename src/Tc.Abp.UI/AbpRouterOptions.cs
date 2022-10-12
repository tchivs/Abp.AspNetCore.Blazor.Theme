using System.Reflection;

namespace Tc.Abp.UI;

public class AbpRouterOptions
{
    public Assembly AppAssembly { get; set; }
    public Type AppType { get; set; }
    public Type DefaultLayout { get; set; }
    public Type NotFoundLayout { get; set; }
    public List<Assembly> AdditionalAssemblies { get; }
    public string BundleStyle { get; set; }
    public string BundleScript { get; set; }
    public AbpRouterOptions()
    {
        AdditionalAssemblies = new List<Assembly>();
    }
}

