using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using Volo.Abp.UI.Navigation;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly.Components
{
    public partial class HeaderUser : BlazorComponentBase, IDisposable
    {
        [Inject, NotNull]
        protected IMenuManager? MenuManager { get; set; }

        protected AuthenticationStateProvider? AuthenticationStateProvider;

        protected SignOutSessionStateManager? SignOutManager;

        protected ApplicationMenu? Menu { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (MenuManager != null && Navigation != null)
            {

                Menu = await MenuManager.GetAsync(StandardMenus.User);

                Navigation.LocationChanged += OnLocationChanged;

                LazyGetRequiredService(ref AuthenticationStateProvider);
                LazyGetRequiredService(ref SignOutManager);

                if (AuthenticationStateProvider != null)
                {
                    AuthenticationStateProvider.AuthenticationStateChanged += async (task) =>
                    {
                        Menu = await MenuManager.GetAsync(StandardMenus.User);
                        await InvokeAsync(StateHasChanged);
                    };
                }
            }
        }

        protected virtual void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            if(Navigation!=null)Navigation.LocationChanged -= OnLocationChanged;
        }

       

        private async Task BeginSignOut()
        {
            if (SignOutManager != null)
            {
                await SignOutManager.SetSignOutState();
                await NavigateToAsync("authentication/logout");
            }
        }
    }
}
