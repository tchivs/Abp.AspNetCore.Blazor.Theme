using Tc.Abp.AspNetCore.Components;
using Tc.Abp.AspNetCore.Toolbars;

namespace Tc.Abp.AspNetCore.UI.Server
{
    public class RadzenServerThemeToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name == StandardToolbars.Main)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(RadzenLanguageSwitch)));
            }
            return Task.CompletedTask;
        }
    }
}
