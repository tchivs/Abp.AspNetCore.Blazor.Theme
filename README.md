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

## Demo

简要说明：

- ```IdentityServer``` 应用程序是其他应用程序使用的身份验证服务器,它有自己的appsettings.json包含数据库连接字符串和其他配置，需要初始化数据库
- ```HttpApi.Host``` 托管模块的HTTP API. 它有自己的appsettings.json包含数据库连接字符串和其他配置
- ```Blazor.HostBlazor``` WebAssembly模式的启动程序，它有自己的appsettings.json(位于wwwroot中)包含HTTP API服务器地址和IdentityServer等配置，前后端分离，需要先启动前面两个程序才能正常使用
- ```Blazor.Server.HostBlazor``` Server模式的启动程序，它有自己的appsettings.json ~~包含数据库连接字符串和其他配置，但是它内部默认集成了IdentityServer和HttpApi.Host模块，相当于前后端不分离，所以它可以直接用。~~ 包含HTTP API服务器地址和IdentityServer等配置，前后端分离，需要先启动HTTP API和IdentityServer程序才能正常使用

启动过程：

1. 切换到DemoApp.IdentityServer目录执行```dotnet ef database update```初始化数据库，启动DemoApp.IdentityServer
2. 启动DemoApp.HttpApi.Host（如果在DemoApp中新建了数据库则也需要dotnet ef database update，但默认是没有的所以可以直接打开）
3. 启动DemoApp.Blazor.Host(wasm)和DemoApp.Blazor.Server.Host(ssr)
