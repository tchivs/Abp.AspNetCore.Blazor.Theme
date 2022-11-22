using System.Threading.Tasks;

namespace Tc.Abp.AspNetCore.PageToolbars;

public interface IPageToolbarManager
{
    Task<PageToolbarItem[]> GetItemsAsync(PageToolbar toolbar);
}
