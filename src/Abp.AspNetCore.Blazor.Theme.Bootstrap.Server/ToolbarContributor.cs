﻿using System.Threading.Tasks;
using Abp.AspNetCore.Blazor.Theme.Bootstrap.Server.Components;

namespace Abp.AspNetCore.Blazor.Theme.Bootstrap
{
    public class ToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name == StandardToolbars.Right)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
                context.Toolbar.Items.Add(new ToolbarItem(typeof(HeaderUser)));
            }

            return Task.CompletedTask;
        }
    }
}