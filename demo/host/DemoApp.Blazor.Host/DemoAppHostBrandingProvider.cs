using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DemoApp.Blazor.Host;
[Dependency(ReplaceServices = true)]

public class DemoAppHostBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DemoApp|wasm";
}
