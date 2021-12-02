using System;
using BootstrapBlazor.Components;
using Volo.Abp.Application.Dtos;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Components
{
    public class AddOrUpdateContext<TKey, TItem, TCreateInput, TUpdateInput>
        where TItem : class, IEntityDto<TKey>, new()
        where TCreateInput : class, new()
        where TUpdateInput : class, new()
    {
        public AddOrUpdateContext(TItem? source = null, ItemChangedType itemChangedType = ItemChangedType.Add, TCreateInput? createInput = null, TUpdateInput? updateInput = null,bool bindSource=false)
        {
            this.BindSource = bindSource; 
            if (itemChangedType == ItemChangedType.Add)
            {
                if (createInput == null)
                {
                    throw new ArgumentNullException(nameof(createInput));//添加时source必须要有值
                }
                this.CreateInput = createInput;
            }
            else
            {
                if (source == null || updateInput == null)
                {
                    throw new ArgumentNullException(nameof(source));//更新时source必须要有值
                }
                this.UpdateInput = updateInput;
            }

            Source = source??new TItem();
            ItemChangedType = itemChangedType;
        }
        public TItem Source { get; }
        public TCreateInput? CreateInput { get; }
        public TUpdateInput? UpdateInput { get; }
        public ItemChangedType ItemChangedType { get; }
        /// <summary>
        /// 是否直接绑定到Source字段，保存的时候会把Source mapper to dto;
        /// </summary>
        public bool BindSource { get; }
        public TCreateInput GetCreateInput()
        {
            if (this.BindSource)
            {
                throw new ApplicationException("BindSource为true时，不能读取CreateInput");
            }
            return this.CreateInput ?? throw new NullReferenceException();
        }
        public TUpdateInput GetUpdateInput()
        {
            if (this.BindSource)
            {
                throw new ApplicationException("BindSource为true时，不能读取UpdateInput");
            }
            return this.UpdateInput ?? throw new NullReferenceException();
        }
        public TKey GetId()
        {
            if (Source == null)
            {
                throw new NullReferenceException(nameof(Source));
            }
            return Source.Id;
        }
    }
}