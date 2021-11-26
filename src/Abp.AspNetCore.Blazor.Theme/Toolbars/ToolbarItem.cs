using System;
using JetBrains.Annotations;
using Volo.Abp;

namespace Abp.AspNetCore.Blazor.Theme
{
    public class ToolbarItem
    {
        public Type ComponentType
        {
            get;
        }
      

        public int Order { get; set; }

        public ToolbarItem([NotNull] Type componentType, int order = 0)
        {
            Order = order;
            ComponentType = Check.NotNull(componentType, nameof(componentType));
        }
    }
}