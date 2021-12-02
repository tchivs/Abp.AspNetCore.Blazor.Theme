using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Components
{
#if NET6_0_OR_GREATER
    [CascadingTypeParameter(nameof(TItem))]
    [CascadingTypeParameter(nameof(TKey))]
    [CascadingTypeParameter(nameof(TCreateInput))]
    [CascadingTypeParameter(nameof(TUpdateInput))]
#endif
    public partial class AbpEditModal<TKey, TItem, TCreateInput, TUpdateInput>
                where TItem : class, IEntityDto<TKey>, new()
        where TCreateInput : class, new()
        where TUpdateInput : class, new()
    {
        private string? rootCss => CssBuilder
                  .Default("row")
                  .AddClass("g-3")
                  .AddClass("tm", Width != null)
                  .AddClass("form-inline", this.IsInline)
                  .Build();
         
        [Parameter, NotNull] public AddOrUpdateContext<TKey,TItem,TCreateInput,TUpdateInput>? Model { get; set; }
        [Parameter] public RenderFragment<TCreateInput>? CreateTemplate { get; set; }
        [Parameter] public RenderFragment<TUpdateInput>? UpdateTemplate { get; set; }
        [Parameter] public bool IsInline { get; set; }
        [Parameter] public double? Width { get; set; }
         
      

    }
}
