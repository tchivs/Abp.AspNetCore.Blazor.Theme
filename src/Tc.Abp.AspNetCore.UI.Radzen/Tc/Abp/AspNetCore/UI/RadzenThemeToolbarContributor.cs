using Tc.Abp.AspNetCore.Components;
using Tc.Abp.AspNetCore.Toolbars;

namespace Tc.Abp.AspNetCore.UI;

public class RadzenThemeToolbarContributor : IToolbarContributor
{
    public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name == StandardToolbars.Main)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(NavThemeBar)));
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
        }
        return Task.CompletedTask;
    }
}