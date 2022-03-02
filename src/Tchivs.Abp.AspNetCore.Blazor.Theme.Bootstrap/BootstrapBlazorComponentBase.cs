using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.DependencyInjection;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap
{
    public abstract class BootstrapBlazorComponentBase : BlazorComponentBase
    {
        [Inject]
        [NotNull]
        protected DialogService? DialogService { get; set; }
        [Inject]
        [NotNull]
        protected ToastService? Toast { get; set; }
    }
    [Dependency(ReplaceServices = true)]
    public class UiMessageService : IUiMessageService, IScopedDependency
    {
        [Inject]
        [NotNull]
        public MessageService? MessageService { get; set; }
        public Task<bool> Confirm(string message, string title = null, Action<UiMessageOptions> options = null)
        {

            throw new NotImplementedException();
        }
        async Task Show(Color color, string message, Action<UiMessageOptions> options = null)
        {
            await this.MessageService.Show(new MessageOption()
            {
                Content = message,
                Color = color,
            });
        }
        public Task Error(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            return this.Show(Color.Danger, message, options);
        }

        public Task Info(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            return this.Show(Color.Info, message, options);
        }

        public Task Success(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            return this.Show(Color.Success, message, options);
        }

        public Task Warn(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            return this.Show(Color.Warning, message, options);
        }
    }
}