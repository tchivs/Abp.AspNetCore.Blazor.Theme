using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Localization;
using Volo.Abp.UI.Navigation;

namespace Tchivs.Abp.TenantManagement.Bootstrap.Blazor
{
    public partial class TenantManagementBlazorMenuContributor : IMenuContributor
    {
        public virtual Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var administrationMenu = context.Menu.GetAdministration();

            var l = context.GetLocalizer<AbpTenantManagementResource>();

            var tenantManagementMenuItem = new ApplicationMenuItem(
                TenantManagementMenuNames.GroupName,
                l["Menu:TenantManagement"],
                icon: "fa fa-users"
            );
            administrationMenu.AddItem(tenantManagementMenuItem);

            tenantManagementMenuItem.AddItem(new ApplicationMenuItem(
                TenantManagementMenuNames.Tenants,
                l["Tenants"],
                url: "/tenant-management/tenants"
            ).RequirePermissions(TenantManagementPermissions.Tenants.Default)) ;

            return Task.CompletedTask;
        }
    }
}