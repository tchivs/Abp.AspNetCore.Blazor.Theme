using System.Threading.Tasks;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme
{
    public interface IToolbarContributor
    {
        Task ConfigureToolbarAsync(IToolbarConfigurationContext context);
    }
}