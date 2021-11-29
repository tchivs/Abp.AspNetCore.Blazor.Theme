using System.Threading.Tasks;
using DemoApp.MultiTenancy;
using Volo.Abp.UI.Navigation;

namespace DemoApp.Blazor.Server.Host.Menus
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
            var administration = context.Menu.GetAdministration();
            context.Menu.Items.Insert(0,
                new ApplicationMenuItem("Index", displayName: "Index", "/", icon: "fa fa-home"));
            // if (MultiTenancyConsts.IsEnabled)
            // {
            //     administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            // }
            // else
            // {
            //     administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            // }
            //
            // administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            // administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

            return Task.CompletedTask;
        }
    }
}
