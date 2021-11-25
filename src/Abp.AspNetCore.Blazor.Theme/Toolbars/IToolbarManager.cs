using System.Threading.Tasks;

namespace Abp.AspNetCore.Blazor.Theme
{
    public interface IToolbarManager
    {
        Task<Toolbar> GetAsync(string name);
    }
}
