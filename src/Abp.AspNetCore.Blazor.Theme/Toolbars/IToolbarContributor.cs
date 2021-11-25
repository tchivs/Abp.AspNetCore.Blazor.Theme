using System.Threading.Tasks;

namespace Abp.AspNetCore.Blazor.Theme
{
    public interface IToolbarContributor
    {
        Task ConfigureToolbarAsync(IToolbarConfigurationContext context);
    }
}