using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace Tc.Abp.UI.Components;

public partial class DynamicLayoutComponent : ComponentBase
{
    [Inject]
    protected IOptions<AbpDynamicLayoutComponentOptions> AbpDynamicLayoutComponentOptions { get; set; }
}