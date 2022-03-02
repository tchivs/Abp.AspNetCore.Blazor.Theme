using Volo.Abp.Bundling;

namespace DemoApp.Blazor.Host;

public class DemoAppBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
