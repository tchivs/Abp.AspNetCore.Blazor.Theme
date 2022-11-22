using System.Threading.Tasks;

namespace Tc.Abp.AspNetCore.PageToolbars;

public abstract class PageToolbarContributor : IPageToolbarContributor
{
    public abstract Task ContributeAsync(PageToolbarContributionContext context);
}
