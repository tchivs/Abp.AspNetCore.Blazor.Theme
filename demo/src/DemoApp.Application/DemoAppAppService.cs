using DemoApp.Localization;
using Volo.Abp.Application.Services;

namespace DemoApp
{
    public abstract class DemoAppAppService : ApplicationService
    {
        protected DemoAppAppService()
        {
            LocalizationResource = typeof(DemoAppResource);
            ObjectMapperContext = typeof(DemoAppApplicationModule);
        }
    }
}
