using System;
using System.Net.Http;
using Tchivs.Abp.AspNetCore.Blazor.Theme;
using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap;
using DemoApp.Blazor.WebAssembly;
using IdentityModel;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Autofac.WebAssembly;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Components;

namespace DemoApp.Blazor.Host
{
    [DependsOn(
        typeof(AbpAutofacWebAssemblyModule),
        typeof(AbpAccountApplicationContractsModule),
         typeof(AbpIdentityApplicationContractsModule),
        typeof(DemoAppBlazorWebAssemblyModule)
    )]
    public class DemoAppBlazorHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
            var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();
            ConfigureAuthentication(builder);
            ConfigureHttpClient(context, environment);
            ConfigureRouter(context);
            ConfigureUI(builder);
            ConfigureMenu(context);
            ConfigureAutoMapper(context);
        }

        private void ConfigureRouter(ServiceConfigurationContext context)
        { 
            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(this.GetType().Assembly);
            });
        }

        private void ConfigureMenu(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DemoAppHostMenuContributor(context.Services.GetConfiguration()));
            });
        }

        
        private static void ConfigureAuthentication(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("AuthServer", options.ProviderOptions);
     
                options.ProviderOptions.DefaultScopes.Add("DemoApp");
            });
        }

        private static void ConfigureUI(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#ApplicationContainer");
        }

        private static void ConfigureHttpClient(ServiceConfigurationContext context, IWebAssemblyHostEnvironment environment)
        {
            context.Services.AddTransient(sp => new HttpClient
            {
                BaseAddress = new Uri(environment.BaseAddress)
            });
        }

        private void ConfigureAutoMapper(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<DemoAppBlazorHostModule>();
            });
        }
    }
}
