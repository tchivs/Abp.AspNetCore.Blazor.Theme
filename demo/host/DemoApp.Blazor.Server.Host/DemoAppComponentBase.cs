using DemoApp.Localization;
using Volo.Abp.AspNetCore.Components;

namespace DemoApp.Blazor.Server.Host
{
    public abstract class DemoAppComponentBase : AbpComponentBase
    {
        protected DemoAppComponentBase()
        {
            LocalizationResource = typeof(DemoAppResource);
        }
    }
}
