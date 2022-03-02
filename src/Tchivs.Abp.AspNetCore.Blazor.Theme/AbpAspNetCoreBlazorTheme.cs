using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Tchivs.Abp.Shared;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.Authorization;
using Volo.Abp.AutoMapper;
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
        typeof(AbpExceptionHandlingModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpAspNetCoreComponentsWebModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule),
        typeof(TchivsAbpSharedModule),
        typeof(AbpUiNavigationModule)

    )]
    public class AbpAspNetCoreBlazorThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton(typeof(AbpBlazorMessageLocalizerHelper<>));

           
            ConfigureRouter(context);
        }
      
        private void ConfigureRouter(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options => { options.AppAssembly = typeof(AbpAspNetCoreBlazorThemeModule).Assembly; });
        }
    }
}