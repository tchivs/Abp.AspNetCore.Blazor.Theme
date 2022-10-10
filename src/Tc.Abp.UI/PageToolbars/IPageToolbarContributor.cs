using System.Threading.Tasks;

namespace Tc.Abp.UI.PageToolbars;

public interface IPageToolbarContributor
{
    Task ContributeAsync(PageToolbarContributionContext context);
}
