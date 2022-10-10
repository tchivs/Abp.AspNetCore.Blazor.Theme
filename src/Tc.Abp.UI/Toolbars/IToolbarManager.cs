using System.Threading.Tasks;

namespace Tc.Abp.UI.Toolbars;

public interface IToolbarManager
{
    Task<Toolbar> GetAsync(string name);
}
