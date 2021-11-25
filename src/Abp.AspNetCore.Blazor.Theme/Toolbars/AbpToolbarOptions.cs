using System.Collections.Generic;
using JetBrains.Annotations;

namespace Abp.AspNetCore.Blazor.Theme
{
    public class AbpToolbarOptions
    {
        [NotNull]
        public List<IToolbarContributor> Contributors { get; }

        public AbpToolbarOptions()
        {
            Contributors = new List<IToolbarContributor>();
        }
    }
}
