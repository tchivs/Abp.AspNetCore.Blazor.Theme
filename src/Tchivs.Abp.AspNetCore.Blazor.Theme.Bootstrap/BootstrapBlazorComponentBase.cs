using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

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
}