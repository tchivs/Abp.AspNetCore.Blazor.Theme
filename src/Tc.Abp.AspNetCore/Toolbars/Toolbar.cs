using System.Collections.Generic;
using Volo.Abp;
using JetBrains.Annotations;

namespace Tc.Abp.AspNetCore.Toolbars;

public class Toolbar
{
    public string Name { get; }

    public List<ToolbarItem> Items { get; }

    public Toolbar([NotNull] string name)
    {
        Name = Check.NotNull(name, nameof(name));
        Items = new List<ToolbarItem>();
    }
}
