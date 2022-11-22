using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;

namespace Tc.Abp.AspNetCore.Components
{
    public class LoginDisplay : LoginDisplayBase, IDisposable
    { 

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [CanBeNull]
        protected SignOutSessionStateManager SignOutManager;
 

        protected override async Task OnInitializedAsync()
        {
            await OnInitializedAsync();
            LazyGetService(ref SignOutManager);
            AuthenticationStateProvider.AuthenticationStateChanged +=
                AuthenticationStateProviderOnAuthenticationStateChanged;
        }

        private async void AuthenticationStateProviderOnAuthenticationStateChanged(Task<AuthenticationState> task)
        {
            Menu = await MenuManager.GetAsync(StandardMenus.User);
            await InvokeAsync(StateHasChanged);
        }
        public override void Dispose()
        {
            base.Dispose();
            AuthenticationStateProvider.AuthenticationStateChanged -=
                AuthenticationStateProviderOnAuthenticationStateChanged;
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
