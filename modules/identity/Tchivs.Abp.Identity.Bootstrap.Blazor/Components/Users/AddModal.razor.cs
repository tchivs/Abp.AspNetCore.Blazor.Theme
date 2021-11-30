using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;

namespace Tchivs.Abp.Identity.Bootstrap.Blazor.Components.Users
{
    public partial class AddModal: IResultDialog
    {
     //   [Parameter] public Guid Id { get; set; }
        [Parameter, NotNull] public IdentityUserCreateDto? Context { get; set; }
        [Inject,NotNull] private IIdentityUserAppService? AppService { get; set; }
        public AddModal( )
        {
           
            LocalizationResource = typeof(IdentityResource);
        }
        protected override async Task OnInitializedAsync()
        {
            Roles = new List<SelectedItem>();
            var result = await this.AppService.GetAssignableRolesAsync();
            foreach (var item in result.Items)
            {
                Roles.Add(new SelectedItem(item.Name, item.Name));
            }
        }



        public List<SelectedItem> Roles { get; set; } = new List<SelectedItem>();
        public Task OnClose(DialogResult result)
        {
            return  Task.CompletedTask;
        }
    }
}