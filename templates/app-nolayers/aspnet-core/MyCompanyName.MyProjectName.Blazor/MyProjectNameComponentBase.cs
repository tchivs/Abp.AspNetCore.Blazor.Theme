using Localization.Resources.AbpUi;
//using Tc.Abp.UI.Localization;
using Volo.Abp.AspNetCore.Components;

namespace MyCompanyName.MyProjectName.Blazor;

public abstract class MyProjectNameComponentBase : AbpComponentBase
{
    protected MyProjectNameComponentBase()
    {
        LocalizationResource = typeof(AbpUiResource);
    }
}
