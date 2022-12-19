using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Tc.Abp.AspNetCore.Components.Server;
using Volo.Abp.UI.Navigation;

namespace Tc.Abp.AspNetCore.UI.Server
{
    internal class DefaultMenuContributor : BaseDefaultMenuContributor
    {
        public DefaultMenuContributor(IConfiguration configuration) : base(configuration)
        {
        }
        protected override ApplicationMenuItem CreateManageMenu(IStringLocalizer l, string authServerUrl)
        {
            var item= base.CreateManageMenu(l, authServerUrl);
            item.Icon = "manage_accounts";
            return item;
        }
        protected override ApplicationMenuItem CreateLogoutMenu(IStringLocalizer l)
        {
            var item =  base.CreateLogoutMenu(l);
            item.Icon = "logout";
            return item;
        }
    }
}
