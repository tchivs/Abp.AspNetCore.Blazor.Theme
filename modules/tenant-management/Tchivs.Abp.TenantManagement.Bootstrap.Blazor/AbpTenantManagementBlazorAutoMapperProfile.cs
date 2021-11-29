using AutoMapper;
using Volo.Abp.TenantManagement;

namespace Tchivs.Abp.TenantManagement.Bootstrap.Blazor
{
   
        public class AbpTenantManagementBlazorAutoMapperProfile : Profile
        {
            public AbpTenantManagementBlazorAutoMapperProfile()
            {
                CreateMap<TenantDto, TenantUpdateDto>()
                    .MapExtraProperties();
            }
        }
    
}