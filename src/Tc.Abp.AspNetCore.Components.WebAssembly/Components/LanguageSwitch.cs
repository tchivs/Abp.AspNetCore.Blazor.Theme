using Microsoft.AspNetCore.Components;
using Volo.Abp.Localization;
using System.Globalization;
using Microsoft.JSInterop;

namespace Tc.Abp.UI.Components
{
    public class LanguageSwitch : LanguageSwitchBase
    {

        protected override async Task ChangeLanguageAsync(LanguageInfo language)
        {
            await JsRuntime.InvokeVoidAsync(
            "localStorage.setItem",
            "Abp.SelectedLanguage", language.UiCultureName
            );

            await JsRuntime.InvokeVoidAsync("location.reload");
        }

        protected override async Task<LanguageInfo> GetCurrentLanguageAsync()
        {
            var selectedLanguageName = await JsRuntime.InvokeAsync<string>(
          "localStorage.getItem",
          "Abp.SelectedLanguage"
          );
            return Languages.FindByCulture(selectedLanguageName);
        }
    }
}
