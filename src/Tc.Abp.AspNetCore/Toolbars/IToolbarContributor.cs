using System.Threading.Tasks;

namespace Tc.Abp.AspNetCore.Toolbars;

public interface IToolbarContributor
{
    Task ConfigureToolbarAsync(IToolbarConfigurationContext context);
}
