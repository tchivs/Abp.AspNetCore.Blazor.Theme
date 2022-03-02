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
        [Parameter] public RenderFragment<AddOrUpdateContext<TKey, TItem, TCreateInput, TUpdateInput>>? EditTemplate { get; set; }
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
        /// <summary>
        /// 是否直接绑定AddOrUpdateContext的Source，这样在更新或者删除时就可以直接共用一个模板。保存时会mapper到相应的dto
        /// </summary>
        [Parameter] public bool BindSourceContext { get; set; } = false;
        [Parameter] public Size AddSize { get; set; } = Size.Medium;
        [Parameter] public Size UpdateSize { get; set; } = Size.Medium;
        private readonly TGetListInput _getListInput = new TGetListInput();
        private Table<TItem> table;

        #endregion

        #region methods
        /// <summary>
        /// 行尾列编辑按钮点击回调此方法
        /// </summary>
        /// <param name="item"></param>
        EventCallback<MouseEventArgs> ClickEditButtonCallback(TItem item) =>
            EventCallback.Factory.Create<MouseEventArgs>(this, () => UpdateAsync(item));

        protected override Task<bool> OnDeleteAsync(params TItem[] items)
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

        private Task UpdateAsync(TItem item)
        {
            //item传入编辑时，如果绑定的是Context的Source，则需要拷贝一份item否则编辑的时候表格内容也会变化。
            return EditAsync(ItemChangedType.Update, this.BindSourceContext ? TransReflection<TItem, TItem>(item) : item);
        }
        private TOut TransReflection<TIn, TOut>(TIn tIn)
        {
            TOut tOut = Activator.CreateInstance<TOut>();
            var tInType = tIn.GetType();
            foreach (var itemOut in tOut.GetType().GetProperties())
            {
                var itemIn = tInType.GetProperty(itemOut.Name); ;
                if (itemIn != null)
                {
                    itemOut.SetValue(tOut, itemIn.GetValue(tIn));
                }
            }
            return tOut;
        }
        public Task AddAsync()
        {
            return EditAsync();
        }
        public virtual async Task EditAsync(ItemChangedType itemChangedType = ItemChangedType.Add, TItem? item = null)
        {

            Size size = Size.Medium;
            TCreateInput? createInput = default;
            TUpdateInput? updateInput = default;
            string title = string.Empty;
            if (itemChangedType == ItemChangedType.Add)
            {
                size = AddSize;
                title = table.AddModalTitle;
                if (OnAddAsync == null)
                {
                    createInput = new TCreateInput();
                }
                else
                {
                    createInput = await OnAddAsync();
                }
            }
            else
            {
                title = table.EditModalTitle;
                if (item == null)
                {
                    throw new NullReferenceException(nameof(item));
                }
                size = UpdateSize;
                updateInput = this.ObjectMapper.Map<TItem, TUpdateInput>(item);
            }
            var context = new AddOrUpdateContext<TKey, TItem, TCreateInput, TUpdateInput>(item, itemChangedType, createInput, updateInput, this.BindSourceContext);
            await this.DialogService.ShowEditDialog(new EditDialogOption<AddOrUpdateContext<TKey, TItem, TCreateInput, TUpdateInput>>()
            {
                IsScrolling = table.ScrollingDialogContent,
                ShowLoading = true,
                Title = title,
                DialogBodyTemplate = this.EditTemplate,
                Model = context,
                Size = size,
                RowType = table.EditDialogRowType,
                ItemsPerRow = table.EditDialogItemsPerRow,
                LabelAlign = table.EditDialogLabelAlign,
                OnCloseAsync = async () => { },
                OnEditAsync = async context =>
                {
                    var valid = false;
                    try
                    {
                        if (context.Model is AddOrUpdateContext<TKey, TItem, TCreateInput, TUpdateInput> ctx)
                        {
                            if (ctx.ItemChangedType == ItemChangedType.Add)
                            {
                                TCreateInput create;
                                if (ctx.BindSource)
                                {
                                    create = this.ObjectMapper.Map<TItem, TCreateInput>(ctx.Source);
                                }
                                else
                                {
                                    create = ctx.GetCreateInput();
                                }
                                await this.AppService.CreateAsync(create);
                            }
                            else
                            {
                                TUpdateInput update;
                                if (ctx.BindSource)
                                {
                                    update = this.ObjectMapper.Map<TItem, TUpdateInput>(ctx.Source);
                                }
                                else
                                {
                                    update = ctx.GetUpdateInput();
                                }
                                var r = await this.AppService.UpdateAsync(ctx.GetId(), update);
                            }
                            valid = true;
                        }
                    }
                    catch (Exception e)
                    {
                        valid = false; 
                        await this.Message.Warn(e.Message);
                    }
                    finally
                    {
                       
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
        public async Task UpdateAsync()
        {
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
            await UpdateAsync(table.SelectedRows[0]);
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
            ret = await OnDeleteAsync(rows.ToArray());
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
        #endregion
    }
}