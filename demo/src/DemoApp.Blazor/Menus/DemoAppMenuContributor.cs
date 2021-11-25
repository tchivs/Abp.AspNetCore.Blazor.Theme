using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace DemoApp.Blazor.Menus
{
    public class DemoAppMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(DemoAppMenus.Prefix, displayName: "DemoApp", "/DemoApp", icon: "fa fa-globe"));
            
            return Task.CompletedTask;
        }
    }
}