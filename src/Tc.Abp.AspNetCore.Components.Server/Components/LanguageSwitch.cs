using Microsoft.AspNetCore.Components;
using Volo.Abp.Localization;
using System.Globalization;

namespace Tc.Abp.UI.Components
{
    public class LanguageSwitch : LanguageSwitchBase
    {

        protected override Task ChangeLanguageAsync(LanguageInfo language)
        {
            var relativeUrl = Navigation.Uri.RemovePreFix(Navigation.BaseUri).EnsureStartsWith('/');
            Navigation.NavigateTo(
                $"/Abp/Languages/Switch?culture={language.CultureName}&uiCulture={language.UiCultureName}&returnUrl={relativeUrl}",
                forceLoad: true
                );
            return Task.CompletedTask;
        }

        protected override Task<LanguageInfo> GetCurrentLanguageAsync()
        {
            return Task.FromResult(Languages.FindByCulture(
               CultureInfo.CurrentCulture.Name,
               CultureInfo.CurrentUICulture.Name
               ));
        }
    }
}
