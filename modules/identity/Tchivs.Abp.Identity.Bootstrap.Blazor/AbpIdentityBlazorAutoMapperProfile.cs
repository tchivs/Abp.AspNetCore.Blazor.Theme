using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;

namespace Tchivs.Abp.Identity.Bootstrap.Blazor
{
    public class AbpIdentityBlazorAutoMapperProfile : Profile
    {
        public AbpIdentityBlazorAutoMapperProfile()
        {
            CreateMap<IdentityUserDto, IdentityUserUpdateDto>()
                .MapExtraProperties()
                .Ignore(x => x.Password)
                .Ignore(x => x.RoleNames);

            CreateMap<IdentityUserDto, IdentityUserCreateDto>() 
                .Ignore(x => x.Password)
                .Ignore(x => x.RoleNames);
            
            CreateMap<IdentityRoleDto, IdentityRoleUpdateDto>();
            CreateMap<IdentityRoleDto, IdentityRoleCreateDto>();
        }
    }
}