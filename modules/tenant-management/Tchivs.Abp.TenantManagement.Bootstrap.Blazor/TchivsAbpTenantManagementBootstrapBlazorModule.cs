using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using Tchivs.Abp.AspNetCore.Blazor.Theme;
using Tchivs.Abp.FeatureManagement.Bootstrap.Blazor;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.Threading;
using Volo.Abp.UI.Navigation;

namespace Tchivs.Abp.TenantManagement.Bootstrap.Blazor
{

    [DependsOn(
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(TchivsAbpFeatureManagementBootstrapBlazorModule)
    )]
    public partial class TchivsAbpTenantManagementBootstrapBlazorModule:AbpModule{

        private static readonly OneTimeRunner OneTimeRunner = new();

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<TchivsAbpTenantManagementBootstrapBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpTenantManagementBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new TenantManagementBlazorMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(TchivsAbpTenantManagementBootstrapBlazorModule).Assembly);
            });
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            OneTimeRunner.Run(() =>
            {
                ModuleExtensionConfigurationHelper
                    .ApplyEntityConfigurationToUi(
                        TenantManagementModuleExtensionConsts.ModuleName,
                        TenantManagementModuleExtensionConsts.EntityNames.Tenant,
                        createFormTypes: new[] { typeof(TenantCreateDto) },
                        editFormTypes: new[] { typeof(TenantUpdateDto) }
                    );
            });
        }
    }
}