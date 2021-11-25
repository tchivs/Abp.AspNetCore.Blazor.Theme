using Abp.AspNetCore.Blazor.Theme.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Abp.AspNetCore.Blazor.Theme
{
    public class BlazorComponentBase: AbpComponentBase
    {
        protected BlazorComponentBase()
        {
            LocalizationResource = typeof(BlazorUIResource);
        }
    }
}