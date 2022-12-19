using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Tc.Abp.AspNetCore.Toolbars;

namespace Tc.Abp.AspNetCore.Components
{
    public abstract class NavToolbarBase : TcAbpComponentBase, IDisposable
    {
        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        protected IToolbarManager ToolbarManager { get; set; }
        protected List<RenderFragment> MainToolbarItemRenders { get; set; } = new List<RenderFragment>();
        protected List<RenderFragment> LeftToolbarItemRenders { get; set; } = new List<RenderFragment>();

        protected override async Task OnInitializedAsync()
        {
            await GetToolbarItemRendersAsync(StandardToolbars.Main, MainToolbarItemRenders);
            await GetToolbarItemRendersAsync(StandardToolbars.Left, LeftToolbarItemRenders);
            AuthenticationStateProvider.AuthenticationStateChanged += AuthenticationStateProviderOnAuthenticationStateChanged;
        }

        private async Task GetToolbarItemRendersAsync(string name, List<RenderFragment> toolbarItemRenders)
        {
            var toolbar = await ToolbarManager.GetAsync(name);

            toolbarItemRenders.Clear();

            var sequence = 0;
            foreach (var item in toolbar.Items)
            {
                toolbarItemRenders.Add(builder =>
                {
                    builder.OpenComponent(sequence++, item.ComponentType);
                    builder.CloseComponent();
                });
            }
        }
        private async void AuthenticationStateProviderOnAuthenticationStateChanged(Task<AuthenticationState> task)
        {
            await GetToolbarItemRendersAsync(StandardToolbars.Main, MainToolbarItemRenders);
            await GetToolbarItemRendersAsync(StandardToolbars.Left, LeftToolbarItemRenders);
            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            AuthenticationStateProvider.AuthenticationStateChanged -= AuthenticationStateProviderOnAuthenticationStateChanged;
        }
    }
}
