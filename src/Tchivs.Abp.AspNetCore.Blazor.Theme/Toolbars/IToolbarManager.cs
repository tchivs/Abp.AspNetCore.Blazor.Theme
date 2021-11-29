using System.Threading.Tasks;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme
{
    public interface IToolbarManager
    {
        Task<Toolbar> GetAsync(string name);
    }
}
