using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.UI.Navigation;
using static Tchivs.Abp.TenantManagement.Bootstrap.Blazor.IdentityBlazorMenuContributor;

namespace Tchivs.Abp.Identity.Bootstrap.Blazor
{
    public partial class IdentityBlazorMenuContributor : IMenuContributor
    {
        public virtual Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var administrationMenu = context.Menu.GetAdministration();
            //身份标识管理
            var identityResource = context.GetLocalizer<IdentityResource>();
            var identityMenuItem = new ApplicationMenuItem(IdentityMenuNames.GroupName,
                identityResource["Menu:IdentityManagement"],
                icon: "far fa-id-card");
            administrationMenu.AddItem(identityMenuItem);
            identityMenuItem.AddItem(new ApplicationMenuItem(
                IdentityMenuNames.Roles,
                identityResource["Roles"], icon: "fa fa-lock",
                url: "/identity/roles").RequirePermissions(Volo.Abp.Identity.IdentityPermissions.Roles.Default));
            identityMenuItem.AddItem(new ApplicationMenuItem(
                IdentityMenuNames.Users,
                identityResource["Users"], icon: "fa fa-user",
                url: "/identity/users").RequirePermissions(Volo.Abp.Identity.IdentityPermissions.Users.Default));


            return Task.CompletedTask;
        }
    }
}