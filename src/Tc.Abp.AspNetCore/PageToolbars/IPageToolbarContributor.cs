using System.Threading.Tasks;

namespace Tc.Abp.AspNetCore.PageToolbars;

public interface IPageToolbarContributor
{
    Task ContributeAsync(PageToolbarContributionContext context);
}
