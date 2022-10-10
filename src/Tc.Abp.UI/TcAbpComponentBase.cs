using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Volo.Abp.AspNetCore.Components;
using JetBrains.Annotations;

namespace Tc.Abp.UI;
public abstract class TcAbpComponentBase : AbpComponentBase
{
    protected TcAbpComponentBase()
    {
        this.LocalizationResource = typeof(Localization.BlazorResource);
    }
    [Inject, NotNull] public NavigationManager Navigation { get; set; }
    [Inject, NotNull] public IJSRuntime JsRuntime { get; set; }
    public bool IsWebAssembly { get => OperatingSystem.IsBrowser(); }
    protected async Task NavigateToAsync(string uri, string target = null)
    {
        if (target == "_blank")
        {
            await JsRuntime.InvokeVoidAsync("open", uri, target);
        }
        else
        {
            Navigation.NavigateTo(uri);
        }
    }

}

