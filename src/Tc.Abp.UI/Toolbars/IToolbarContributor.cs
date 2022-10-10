using System.Threading.Tasks;

namespace Tc.Abp.UI.Toolbars;

public interface IToolbarContributor
{
    Task ConfigureToolbarAsync(IToolbarConfigurationContext context);
}
