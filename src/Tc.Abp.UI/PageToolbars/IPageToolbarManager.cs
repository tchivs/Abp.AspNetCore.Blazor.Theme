using System.Threading.Tasks;

namespace Tc.Abp.UI.PageToolbars;

public interface IPageToolbarManager
{
    Task<PageToolbarItem[]> GetItemsAsync(PageToolbar toolbar);
}
