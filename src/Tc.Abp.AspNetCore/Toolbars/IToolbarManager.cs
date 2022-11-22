using System.Threading.Tasks;

namespace Tc.Abp.AspNetCore.Toolbars;

public interface IToolbarManager
{
    Task<Toolbar> GetAsync(string name);
}
