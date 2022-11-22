using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace Tc.Abp.AspNetCore.Components;

public partial class DynamicLayoutComponent : ComponentBase
{
    [Inject]
    protected IOptions<AbpDynamicLayoutComponentOptions> AbpDynamicLayoutComponentOptions { get; set; }
}