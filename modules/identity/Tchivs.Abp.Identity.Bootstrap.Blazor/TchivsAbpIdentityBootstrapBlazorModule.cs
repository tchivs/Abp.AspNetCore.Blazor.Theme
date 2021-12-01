using Tchivs.Abp.AspNetCore.Blazor.Theme;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Modularity;
using Volo.Abp.Identity;
using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap;
using Volo.Abp.Threading;
using Volo.Abp.UI.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.ObjectExtending;

namespace Tchivs.Abp.Identity.Bootstrap.Blazor
{

    [DependsOn(
        typeof(AbpAspNetCoreBlazorThemeBootstrapModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule)
   
    )]
    public class TchivsAbpIdentityBootstrapBlazorModule : AbpModule
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<TchivsAbpIdentityBootstrapBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpIdentityBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new IdentityBlazorMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(TchivsAbpIdentityBootstrapBlazorModule).Assembly);
            });
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            OneTimeRunner.Run(() =>
            {
                ModuleExtensionConfigurationHelper
                    .ApplyEntityConfigurationToUi(
                        IdentityModuleExtensionConsts.ModuleName,
                        IdentityModuleExtensionConsts.EntityNames.Role,
                        createFormTypes: new[] { typeof(IdentityRoleCreateDto) },
                        editFormTypes: new[] { typeof(IdentityRoleUpdateDto) }
                    );

                ModuleExtensionConfigurationHelper
                    .ApplyEntityConfigurationToUi(
                        IdentityModuleExtensionConsts.ModuleName,
                        IdentityModuleExtensionConsts.EntityNames.User,
                        createFormTypes: new[] { typeof(IdentityUserCreateDto) },
                        editFormTypes: new[] { typeof(IdentityUserUpdateDto) }
                    );
            });
        }
    }
}