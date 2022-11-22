using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.Authorization;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;
using Tc.Abp.AspNetCore.Localization;
using Localization.Resources.AbpUi;
using Tc.Abp.AspNetCore.Components;
using Volo.Abp.Validation.Localization;

namespace Tc.Abp.AspNetCore;
[DependsOn(
typeof(AbpValidationModule),
typeof(AbpAspNetCoreComponentsWebModule),
typeof(AbpDddApplicationContractsModule),
typeof(AbpAuthorizationModule),
typeof(AbpUiNavigationModule),
typeof(AbpExceptionHandlingModule)
)]
public class TcAbpAspNetCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton(typeof(AbpBlazorMessageLocalizerHelper<>));
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TcAbpAspNetCoreModule>();
        });
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<BlazorResource>("zh-Hans")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddBaseTypes(typeof(AbpUiResource))
                .AddVirtualJson("/Localization/Blazor");
        });
        Configure<AbpRouterOptions>(options =>
        {
            options.AppType = typeof(App);
        });
        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Blazor", typeof(BlazorResource));
        });
    }
}
