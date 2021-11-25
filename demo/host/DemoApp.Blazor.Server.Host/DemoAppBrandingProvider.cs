﻿using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DemoApp.Blazor.Server.Host
{
    [Dependency(ReplaceServices = true)]
    public class DemoAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DemoApp";
    }
}
