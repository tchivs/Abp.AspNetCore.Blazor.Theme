using Tchivs.Abp.AspNetCore.Blazor.Theme.Localization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.Authorization;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.ExceptionHandling.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme
{


    [DependsOn(
        typeof(AbpExceptionHandlingModule), typeof(Volo.Abp.AutoMapper.AbpAutoMapperModule),
        typeof(AbpAspNetCoreComponentsWebModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule),
        typeof(AbpValidationModule),
        typeof(AbpUiNavigationModule)
    )]
    public class AbpAspNetCoreBlazorThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton(typeof(AbpBlazorMessageLocalizerHelper<>));

            ConfigureLocalization(context);
            ConfigureRouter(context);
        }
        private void ConfigureLocalization(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreBlazorThemeModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<BlazorUIResource>("zh-Hans")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/BlazorUI");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("BlazorUI", typeof(BlazorUIResource));
            });
        }
        private void ConfigureRouter(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options => { options.AppAssembly = typeof(AbpAspNetCoreBlazorThemeModule).Assembly; });
        }
    }
}