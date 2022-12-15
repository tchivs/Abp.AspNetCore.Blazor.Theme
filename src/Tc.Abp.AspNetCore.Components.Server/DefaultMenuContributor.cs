using Volo.Abp.UI.Navigation;
using Volo.Abp.Authorization.Permissions;
using Microsoft.Extensions.Configuration;
using Tc.Abp.AspNetCore.Localization;
using Microsoft.Extensions.Localization;

namespace Tc.Abp.AspNetCore.Components.Server;

public abstract class BaseDefaultMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public BaseDefaultMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    protected virtual Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<BlazorResource>();
        //var accountStringLocalizer = context.GetLocalizer<BlazorResource>();
        var authServerUrl = _configuration["AuthServer:Authority"] ?? "";
        context.Menu.AddItem(this.CreateManageMenu(l, authServerUrl));
        context.Menu.AddItem(CreateLogoutMenu(l));
        return Task.CompletedTask;
    }

    protected virtual ApplicationMenuItem CreateManageMenu(IStringLocalizer l, string authServerUrl)
    {
        var manage = new ApplicationMenuItem("Account.Manage", l["MyAccount"],
        $"{authServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}", icon: "fa fa-cog", order: 1000, null, "_blank").RequireAuthenticated();
        return manage;
    }
    protected virtual ApplicationMenuItem CreateLogoutMenu(IStringLocalizer l)
    {
        return new ApplicationMenuItem("Account.Logout", l["Logout"], url: "Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000).RequireAuthenticated();
    }
}
