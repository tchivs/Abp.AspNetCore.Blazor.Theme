using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Tc.Abp.UI;

[DependsOn(typeof(TcAbpUIModule))]
public class TcAbpUIBootstrapBlazorModule:AbpModule
    {
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        
    }
}
