using System;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Components;

namespace Tc.Abp.AspNetCore.UI
{
    public class ThemeService : Volo.Abp.DependencyInjection.IScopedDependency
    {
        public class Theme
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public string Primary { get; set; }
            public string Secondary { get; set; }
            public string Base { get; set; }
            public string Header { get; set; }
            public string Sidebar { get; set; }
            public string Content { get; set; }
            public string TitleText { get; set; }
            public string ContentText { get; set; }
            public bool Premium { get; set; }
        }
        public static readonly Theme[] Themes = new[]
        {
            new Theme {
                Text = "Material",
                Value = "material",
                Primary = "#4340d2",
                Secondary = "#e91e63",
                Base = "#f5f5f5",
                Header = "#4340d2",
                Sidebar = "#ffffff",
                Content = "#ffffff",
                TitleText = "#212121",
                ContentText = "#bdbdbd"
            },
            new Theme {
                Text = "Material Dark",
                Value = "material-dark",
                Premium = true,
                Primary = "#bb86fc",
                Secondary = "#01a299",
                Base = "#121212",
                Header = "#333333",
                Sidebar = "#252525",
                Content = "#252525",
                TitleText = "#ffffff",
                ContentText = "#a0a0a0"
            },
            new Theme {
                Text = "Fluent",
                Value = "fluent",
                Premium = true,
                Primary = "#0078d4",
                Secondary = "#2b88d8",
                Base = "#f5f5f5",
                Header = "white",
                Sidebar = "gray",
                Content = "white",
                TitleText = "black",
                ContentText = "black"
            },
            new Theme {
                Text = "Standard",
                Value = "standard",
                Primary = "#1151f3",
                Secondary = "rgba(17, 81, 243, 0.16)",
                Base = "#f4f5f9",
                Header = "#ffffff",
                Sidebar = "#262526",
                Content = "#ffffff",
                TitleText = "#262526",
                ContentText = "#afafb2"
            },
            new Theme {
                Text = "Default",
                Value = "default",
                Primary = "#ff6d41",
                Secondary = "#35a0d7",
                Base = "#f6f7fa",
                Header = "#ffffff",
                Sidebar = "#3a474d",
                Content = "#ffffff",
                TitleText = "#28363c",
                ContentText = "#95a4a8"
            },
            new Theme {
                Text = "Dark",
                Value="dark",
                Primary = "#ff6d41",
                Secondary = "#35a0d7",
                Base = "#28363c",
                Header = "#38474e",
                Sidebar = "#38474e",
                Content = "#38474e",
                TitleText = "#ffffff",
                ContentText = "#a8b4b8"
            },
            new Theme {
                Text = "Humanistic",
                Value = "humanistic",
                Primary = "#d64d42",
                Secondary = "#3ba5fc",
                Base = "#f3f5f7",
                Header = "#ffffff",
                Sidebar = "#30445f",
                Content = "#ffffff",
                TitleText = "#2b3a50",
                ContentText = "#7293b6"
            },
            new Theme {
                Text = "Software",
                Value = "software",
                Primary = "#598087",
                Secondary = "#80a4ab",
                Base = "#f6f7fa",
                Header = "#ffffff",
                Sidebar = "#3a474d",
                Content = "#ffffff",
                TitleText = "#28363c",
                ContentText = "#95a4a8"
            }
        };

        public const string DefaultTheme = "material";
        public const string QueryParameter = "theme";

        public string CurrentTheme { get; set; } = DefaultTheme;
     
        public void Initialize(NavigationManager navigationManager)
        {
            var uri = new Uri(navigationManager.ToAbsoluteUri(navigationManager.Uri).ToString());
            var query = HttpUtility.ParseQueryString(uri.Query);
            var value = query.Get(QueryParameter);

            if (Themes.Any(theme => theme.Value == value))
            {
                CurrentTheme = value;
            }
        }

        public void Change(NavigationManager navigationManager, string theme)
        {
            var url = navigationManager.GetUriWithQueryParameter(QueryParameter, theme);

            navigationManager.NavigateTo(url, true);
        }
    }
}