using Volo.Abp.Ui.Branding;

namespace DemoApp.Blazor.Host
{
    public class DemoAppHostBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DemoApp|wasm";
    }
}
