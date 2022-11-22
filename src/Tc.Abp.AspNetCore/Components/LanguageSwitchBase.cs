using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Localization;

namespace Tc.Abp.AspNetCore.Components
{
    public abstract class LanguageSwitchBase : TcAbpComponentBase
    {
        [Inject]
        public ILanguageProvider LanguageProvider { get; set; }
        protected IReadOnlyList<LanguageInfo> Languages { get; private set; }
        protected LanguageInfo CurrentLanguage;
        protected override async Task OnInitializedAsync()
        {
            Languages = await LanguageProvider.GetLanguagesAsync();
            CurrentLanguage = await GetCurrentLanguageAsync();

        }
        protected abstract Task<LanguageInfo> GetCurrentLanguageAsync();

        protected abstract Task ChangeLanguageAsync(LanguageInfo language);
    }
}
