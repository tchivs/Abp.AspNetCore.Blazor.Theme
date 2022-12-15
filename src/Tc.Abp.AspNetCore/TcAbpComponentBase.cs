using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Volo.Abp.AspNetCore.Components;
using JetBrains.Annotations;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.Users;
using Microsoft.Extensions.Configuration;

namespace Tc.Abp.AspNetCore;
public abstract class TcAbpComponentBase : AbpComponentBase
{
    protected TcAbpComponentBase()
    {
        this.LocalizationResource = typeof(Localization.BlazorResource);
    }
    public IConfiguration Configuration => LazyGetRequiredService(ref _configuration);
    IConfiguration _configuration;
    [Inject] public NavigationManager Navigation { get; set; }
    [Inject]
    public IJSRuntime JsRuntime { get; set; }

    public bool IsWebAssembly { get => OperatingSystem.IsBrowser(); }

    protected virtual async Task NavigateToAsync(string uri, string target = null)
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
    string GetBaseRedirectUrl()
    {
        if (IsWebAssembly)
        {
            return $"authentication/login";
        }
        else
        {
            return $"account/login";
        }
    }
    protected virtual string GetRedirectUrl()
    {
        var baseUrl = GetBaseRedirectUrl();
        var selfUrl = Configuration["App:SelfUrl"];
        if (string.IsNullOrEmpty(selfUrl))
        {
            return baseUrl;

        }
        string returnUrl = Uri.EscapeDataString(Navigation.Uri);
        if (returnUrl == selfUrl)
        {
            return baseUrl;
        }
        return $"{baseUrl}?returnUrl={returnUrl}";
    }
    protected virtual void RedirectToLogin()
    {
        string url = this.GetRedirectUrl();
        if (IsWebAssembly)
        {
            Navigation.NavigateTo(url);
        }
        else
        {
            Navigation.NavigateTo(url, true);
        }
    }
}

