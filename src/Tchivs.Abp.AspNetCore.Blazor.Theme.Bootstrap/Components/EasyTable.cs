using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Components
{
   
    public class EasyTable<TAppService, TItem, TKey, TGetListInput, TCreateInput,
        TUpdateInput> :ReadOnlyTable<TAppService,TItem,TKey,TGetListInput>
        where TAppService : ICrudAppService<TItem, TKey, TGetListInput, TCreateInput,
            TUpdateInput>, IReadOnlyAppService<TItem,TItem, TKey, TGetListInput>
        where TItem : class, IEntityDto<TKey>, new()
        where TCreateInput : class, new()
        where TUpdateInput : class, new()
        where TGetListInput :PagedAndSortedResultRequestDto, new()
    {
        #region properties

        [Parameter] public string? CreatePolicyName { get; set; }
        [Parameter] public string? UpdatePolicyName { get; set; }
        [Parameter] public string? DeletePolicyName { get; set; }
        protected bool HasCreatePermission { get; set; }
        protected bool HasUpdatePermission { get; set; }
        protected bool HasDeletePermission { get; set; }

        #endregion
        protected  override async Task OnInitializedAsync()
        {
            await SetPermissionsAsync();
            await InvokeAsync(StateHasChanged);
        }
        protected virtual async Task SetPermissionsAsync()
        {
            if (CreatePolicyName != null)
            {
                HasCreatePermission = await AuthorizationService.IsGrantedAsync(CreatePolicyName);
            }

            if (UpdatePolicyName != null)
            {
                HasUpdatePermission = await AuthorizationService.IsGrantedAsync(UpdatePolicyName);
            }

            if (DeletePolicyName != null)
            {
                HasDeletePermission = await AuthorizationService.IsGrantedAsync(DeletePolicyName);
            }
        }
        protected virtual async Task<bool> OnSaveAsync(TItem model, ItemChangedType type)
        {
            bool result = false;
            try
            {
                if (type == ItemChangedType.Add)
                {
                    await AppService.CreateAsync(ObjectMapper.Map<TItem, TCreateInput>(model));
                }
                else
                {
                    await AppService.UpdateAsync(model.Id, ObjectMapper.Map<TItem, TUpdateInput>(model));
                }

                result = true;
            }
            catch (Exception e)
            {
                await this.HandleErrorAsync(e);
                result = false;
            }

            return result;
        }
        protected virtual   Task<bool> OnDeleteAsync(  IEnumerable<TItem> items)
        {
            return OnDeleteAsync(items.ToArray());
        }
        protected virtual async Task<bool> OnDeleteAsync(params TItem[] items)
        {
            bool success = false;
            try
            {
                foreach (var item in items)
                {
                    await this.AppService.DeleteAsync(item.Id);
                }
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                await HandleErrorAsync(e);
            }

            return success;
        }
    }
}