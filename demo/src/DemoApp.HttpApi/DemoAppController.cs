using DemoApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoApp
{
    public abstract class DemoAppController : AbpController
    {
        protected DemoAppController()
        {
            LocalizationResource = typeof(DemoAppResource);
        }
    }
}
