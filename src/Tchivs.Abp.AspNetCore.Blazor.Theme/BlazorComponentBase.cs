using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components;
using Tchivs.Abp.Shared.Localization;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme
{
    public abstract class BlazorComponentBase: AbpComponentBase
    {
       [Inject,NotNull]protected IJSRuntime? JsRuntime { get; set; }
        [Inject, NotNull] protected NavigationManager? Navigation { get; set; }

        protected BlazorComponentBase( )
        {
            
            LocalizationResource = typeof(BlazorUIResource);
        }
        /// <summary>
        /// 导航到页面
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        protected async Task NavigateToAsync(string uri, string? target = null)
        {
            if (target == "_blank")
            {
                await JsRuntime.InvokeVoidAsync("open", uri, target);
            }
            else
            {
                Navigation?.NavigateTo(uri);
            }
        }
    }
}