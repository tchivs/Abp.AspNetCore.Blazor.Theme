using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Console = System.Console;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Components
{
#if NET6_0_OR_GREATER
    [CascadingTypeParameter(nameof(TItem))]
#endif
    public partial class TableEx<TAppService, TItem, TKey, TGetListInput, TCreateInput,
        TUpdateInput> : EasyTable<TAppService, TItem, TKey, TGetListInput, TCreateInput,
        TUpdateInput> where TAppService : ICrudAppService<TItem, TKey, TGetListInput, TCreateInput,
            TUpdateInput>
        where TItem : class, IEntityDto<TKey>, new()
        where TCreateInput : class, new()
        where TUpdateInput : class, new()
        where TGetListInput : PagedAndSortedResultRequestDto, new()
    {
        [Inject]
        [NotNull]
        public IStringLocalizer<AbpUiResource>? Localizer { get; set; }
        #region properties

        [Parameter] public string? AddModalTitle { get; set; }

        /// <summary>
        /// 获得/设置 表格 Toolbar 按钮模板
        /// </summary>
        [Parameter]
        public RenderFragment? TableToolbarTemplate { get; set; }

        [Parameter] public bool AutoGenerateColumns { get; set; }

        /// <summary>
        /// 获得/设置 删除按钮异步回调方法
        /// </summary>
        [Parameter]
        public Func<IEnumerable<TItem>, Task<bool>>? OnDeleteCallBackAsync { get; set; }

        /// <summary>
        /// 获得/设置 新建按钮回调方法
        /// </summary>
        [Parameter]
        public Func<Task<TCreateInput>>? OnAddAsync { get; set; }

        /// <summary>
        /// 获得/设置 TableHeader 实例
        /// </summary>
        [Parameter]
        public RenderFragment<TItem>? TableColumns { get; set; }

        [Parameter] public RenderFragment<TItem>? RowButtonTemplate { get; set; }
        [Parameter] public RenderFragment<TCreateInput>? AddTemplate { get; set; }
        [Parameter] public RenderFragment<TUpdateInput>? EditTemplate { get; set; }
        [Parameter] public Size AddSize { get; set; } = Size.Medium;
        [Parameter] public Size EditSize { get; set; } = Size.Medium;
        private readonly TGetListInput _getListInput = new TGetListInput();
        private Table<TItem> table;

        #endregion

        #region methods

        /// <summary>
        /// 行尾列编辑按钮点击回调此方法
        /// </summary>
        /// <param name="item"></param>
        EventCallback<MouseEventArgs> ClickEditButtonCallback(TItem item) =>
            EventCallback.Factory.Create<MouseEventArgs>(this, () => EditAsync(item));

        protected override Task<bool> OnDeleteAsync(IEnumerable<TItem> items)
        {
            if (this.OnDeleteCallBackAsync != null)
            {
                return OnDeleteCallBackAsync(items);
            }
            else
            {
                return base.OnDeleteAsync(items);
            }
        }

        private async Task EditAsync(TItem item)
        {
            TUpdateInput editInput = ObjectMapper.Map<TItem, TUpdateInput>(item);
             var Id = item.Id;

            await this.DialogService.ShowEditDialog(new EditDialogOption<TUpdateInput>()
            {
                IsScrolling = table.ScrollingDialogContent,
                ShowLoading = true,
                Title = table.AddModalTitle,
                DialogBodyTemplate = this.EditTemplate,
                Model = editInput,
                Size = this.EditSize,
                RowType = table.EditDialogRowType,
                ItemsPerRow = table.EditDialogItemsPerRow,
                LabelAlign = table.EditDialogLabelAlign,
                OnCloseAsync = async () => { },
                OnSaveAsync = async context =>
                {
                    await table.ToggleLoading(true);
                    var valid = false;
                    try
                    {
                        await this.AppService.UpdateAsync(Id, (TUpdateInput) context.Model);
                        valid = true;
                    }
                    catch (Exception e)
                    {
                        valid = false;
                        await this.HandleErrorAsync(e);
                    }
                    finally
                    {
                        await table.ToggleLoading(false);
                        //  table.SelectedRows?.Clear();
                    }

                    if (valid)
                    {
                        await InvokeAsync(table.QueryAsync);
                    }

                    return valid;
                }
            });
        }

        public async Task AddAsync()
        {
            TCreateInput createInput;
            if (OnAddAsync == null)
            {
                createInput = new TCreateInput();
            }
            else
            {
                createInput = await OnAddAsync();
            }

            await this.DialogService.ShowEditDialog(new EditDialogOption<TCreateInput>()
            {
                IsScrolling = table.ScrollingDialogContent,
                ShowLoading = true,
                Title = AddModalTitle ?? table.AddModalTitle,
                DialogBodyTemplate = this.AddTemplate,
                Model = createInput,
                Size = this.AddSize,
                RowType = table.EditDialogRowType,
                ItemsPerRow = table.EditDialogItemsPerRow,
                LabelAlign = table.EditDialogLabelAlign,
                OnCloseAsync = async () => { },
                OnSaveAsync = async context =>
                {
                    await table.ToggleLoading(true);
                    var valid = false;
                    try
                    {
                        await this.AppService.CreateAsync((TCreateInput) context.Model);
                        valid = true;
                    }
                    catch (Exception e)
                    {
                        valid = false;
                        await this.HandleErrorAsync(e);
                    }
                    finally
                    {
                        await table.ToggleLoading(false);
                        table.SelectedRows?.Clear();
                    }

                    if (valid)
                    {
                        await InvokeAsync(table.QueryAsync);
                    }

                    return valid;
                }
            });
        }

        public async Task EditAsync()
        {
            TUpdateInput editInput;
            if (table.SelectedRows == null || table.SelectedRows.Count == 0)
            {
                var option = new ToastOption
                {
                    Category = ToastCategory.Information,
                    Title = table.EditButtonToastTitle
                };
                option.Content = string.Format(table.EditButtonToastNotSelectContent,
                    Math.Ceiling(option.Delay / 1000.0));
                await Toast.Show(option);
                return;
            }

            var item = table.SelectedRows[0];
            await EditAsync(item);
        }

        protected async Task<bool> ConfirmDelete()
        {
            var ret = false;
            if (table.SelectedRows == null)
            {
                var option = new ToastOption
                {
                    Category = ToastCategory.Information,
                    Title = table.DeleteButtonToastTitle
                };
                option.Content = string.Format(table.DeleteButtonToastContent, Math.Ceiling(option.Delay / 1000.0));
                await Toast.Show(option);
            }
            else
            {
                ret = true;
            }

            return ret;
        }

        protected async Task DeleteAsync()
        {
            var ret = false;
            var rows = table.SelectedRows;
            if (rows == null)
            {
                return;
            }

            await table.ToggleLoading(true);
            ret = await OnDeleteAsync(rows);
            var option = new ToastOption
            {
                Title = this.table.DeleteButtonToastTitle,
                Category = ret ? ToastCategory.Success : ToastCategory.Error
            };
            option.Content = string.Format(this.table.DeleteButtonToastResultContent,
                ret ? table.SuccessText : table.FailText, Math.Ceiling(option.Delay / 1000.0));

            if (ret)
            {
                await InvokeAsync(table.QueryAsync);
            }

            if (table.ShowToastAfterSaveOrDeleteModel || ret)
            {
                await Toast.Show(option);
            }

            await table.ToggleLoading(false);
        }

        protected async Task DeleteAsync(TItem item)
        {
            var ret = false;
            await table.ToggleLoading(true);
            if (OnDeleteCallBackAsync != null)
            {
                ret = await OnDeleteCallBackAsync(new[] {item});
            }
            else
            {
                await this.AppService.DeleteAsync(item.Id);
                ret = true;
            }

            var option = new ToastOption()
            {
                Title = table.DeleteButtonToastTitle
            };
            option.Category = ret ? ToastCategory.Success : ToastCategory.Error;
            option.Content = string.Format(table.DeleteButtonToastResultContent,
                ret ? table.SuccessText : table.FailText, Math.Ceiling(option.Delay / 1000.0));

            if (ret)
            {
                await InvokeAsync(table.QueryAsync);
            }

            if (table.ShowToastAfterSaveOrDeleteModel || ret)
            {
                await Toast.Show(option);
            }

            await table.ToggleLoading(false);
        }

        #endregion
    }
}