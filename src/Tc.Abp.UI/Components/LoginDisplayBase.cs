using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Volo.Abp.UI.Navigation;

namespace Tc.Abp.UI.Components
{
    public abstract class LoginDisplayBase : TcAbpComponentBase, IDisposable
    {
        [Inject]
        protected IMenuManager MenuManager { get; set; }
        [Inject]
        protected ApplicationMenu Menu { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Menu = await MenuManager.GetAsync(StandardMenus.User);

            Navigation.LocationChanged += OnLocationChanged;
        }

        protected virtual void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            InvokeAsync(StateHasChanged);
        }

        public virtual void Dispose()
        {
            Navigation.LocationChanged -= OnLocationChanged;
        }
    }
}
