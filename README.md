# Abp VNext Themes 
Abp VNext第三方主题的实现，目前实现了BootstrapBlazor主题。
## 简介

- Abp.AspNetCore.Blazor.Theme >	 主题公共模块
- Abp.AspNetCore.Blazor.Theme.Server >	 Server模式主题公共模块
- Abp.AspNetCore.Blazor.Theme.WebAssembly >	 WebAssembly模式主题公共模块
- themes/bootstrap
	- Abp.AspNetCore.Blazor.Theme.Bootstrap > BootstrapBlazor主题公共模块，引用了```Abp.AspNetCore.Blazor.Theme```
	- Abp.AspNetCore.Blazor.Theme.Bootstrap.Server >	 BootstrapBlazor Server模式主题模块，引用了```Abp.AspNetCore.Blazor.Theme.Server```
	- Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly >		BootstrapBlazor WebAssembly模式主题模块，引用了```Abp.AspNetCore.Blazor.Theme.WebAssembly```

该项目用于替换Abp Blazor的几个模块：

- ```Volo.Abp.AspNetCore.Components.Web.BasicTheme``` 替换为 ```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap```
- ```Volo.Abp.AspNetCore.Components.Server.BasicTheme``` 替换为 ```Abp.AspNetCore.Blazor.Theme.Server```
- ```Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme``` 替换为 ```Abp.AspNetCore.Blazor.Theme.WebAssembly```
- ```Volo.Abp.AspNetCore.Components.Server.Theming``` 替换为 ```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Server```
- ```Volo.Abp.AspNetCore.Components.WebAssembly.Theming``` 替换为 ```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly```