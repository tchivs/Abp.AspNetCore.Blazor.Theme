# Abp VNext Blazor Themes 
[![](https://img.shields.io/nuget/dt/Tchivs.Abp.AspNetCore.Blazor.Theme?color=004880&label=downloads&logo=NuGet)](https://www.nuget.org/packages/Tchivs.Abp.AspNetCore.Blazor.Theme/)[![](https://img.shields.io/nuget/vpre/Tchivs.Abp.AspNetCore.Blazor.Theme?color=%23004880&label=NuGet&logo=nuget)](https://www.nuget.org/packages/Tchivs.Abp.AspNetCore.Blazor.Theme/)[![GitHub](https://img.shields.io/github/license/tchivs/Abp.AspNetCore.Blazor.Theme?color=%231281c0)](LICENSE)

Abp VNext Blazor第三方主题的实现

## 项目介绍

由于Abp NVext所使用的BlazorUI为[Blazorise](https://github.com/Megabit/Blazorise)，所以想适配其他的UI组件,同时支持Server与WebAssembly模式。

[具体实现过程](https://www.cnblogs.com/tchivs/p/15603214.html)


**已适配的Blazor UI**
- [BootstrapBlazor](https://gitee.com/LongbowEnterprise/BootstrapBlazor)

**已适配的模块**

- [x] 用户管理
- [x] 角色管理
- [x] 租户管理（还有个配置页面没做）

### 模块说明


- Abp.AspNetCore.Blazor.Theme >	 主题公共模块
- Abp.AspNetCore.Blazor.Theme.Server >	 Server模式主题公共模块
- Abp.AspNetCore.Blazor.Theme.WebAssembly >	 WebAssembly模式主题公共模块
- themes/bootstrap
	- Abp.AspNetCore.Blazor.Theme.Bootstrap > BootstrapBlazor主题公共模块，引用了```Abp.AspNetCore.Blazor.Theme```
	- Abp.AspNetCore.Blazor.Theme.Bootstrap.Server >	 BootstrapBlazor Server模式主题模块，引用了```Abp.AspNetCore.Blazor.Theme.Server```
	- Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly >		BootstrapBlazor WebAssembly模式主题模块，引用了```Abp.AspNetCore.Blazor.Theme.WebAssembly```
- modules
	- feature-management（租户特征管理-未完成）
	- tenant-management（租户管理）
	- identity(用户管理、角色管理、等权限管理页面)
## 快速开始

### 1.新建Abp模块

```cmd
abp new DemoModule -t module
```

### 2.替换模块中的主题

#### 2.1 打开DemoModule.Blazor

这是模块的Blazor公共项目，一般在这里面编写相关页面和组件

1. 移除依赖```Volo.Abp.AspNetCore.Components.Web.Theming```,替换为```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap```。
2. 打开```DemoModuleBlazorModule```
  2.1 把DependsOn中依赖的模块名```AbpAspNetCoreComponentsWebThemingModule```改为```AbpAspNetCoreBlazorThemeBootstrapModule```
  2.2 引用```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap``` ```Tchivs.Abp.AspNetCore.Blazor.Theme```命名空间
3. 打开```_Imports.razor```,删除```@using Volo.Abp.BlazoriseUI``` ```@using Blazorise``` ```@using Blazorise.DataGrid```,添加```@using BootstrapBlazor.Components``` ```@using Tchivs.Abp.AspNetCore.Blazor.Theme``` ```@using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap``` ```@using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Components```

#### 2.2 打开DemoModule.Blazor.Server
这个是模块的ssr模式下引用的类库，这个简单，只需要替换依赖就行。

1. 移除依赖```Volo.Abp.AspNetCore.Components.Server.Theming```，替换为```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Server```
2. 打开```DemoAppBlazorServerModule```
  2.1 把DependsOn中依赖的模块名```AbpAspNetCoreComponentsServerThemingModule```改为```AbpAspNetCoreBlazorThemeBootstrapServerModule```
  2.2 引用```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap```命名空间

### 2.3 DemoModule.Blazor.WebAssembly
这个是模块的wasm模式下引用的类库，由上。
1. 移除依赖```Volo.Abp.AspNetCore.Components.WebAssembly.Theming```，替换为```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly```
2. 打开```DemoAppBlazorWebAssemblyModule```
  2.1 把DependsOn中依赖的模块名```AbpAspNetCoreComponentsWebAssemblyThemingModule```改为```AbpAspNetCoreBlazorThemeBootstrapWebAssemblyModule```
  2.2 引用```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap```命名空间

此时关于模块的替换已经完成。在Blazor/Pages中写自己的页面就可以了。

但是Blazor的宿主还没替换主题，关于宿主的替换，比较麻烦。可以看[具体实现过程](https://www.cnblogs.com/tchivs/p/15603214.html)或者DemoApp中Host的实现,后续会采用直接创建模板的形式这样就不需要手动替换了
。


## Demo

### 简要说明

- ```IdentityServer``` 应用程序是其他应用程序使用的身份验证服务器,它有自己的appsettings.json包含数据库连接字符串和其他配置，需要初始化数据库
- ```HttpApi.Host``` 托管模块的HTTP API. 它有自己的appsettings.json包含数据库连接字符串和其他配置
- ```Blazor.HostBlazor``` WebAssembly模式的启动程序，它有自己的appsettings.json(位于wwwroot中)包含HTTP API服务器地址和IdentityServer等配置，前后端分离，需要先启动前面两个程序才能正常使用
- ```Blazor.Server.HostBlazor``` Server模式的启动程序，它有自己的appsettings.json ~~包含数据库连接字符串和其他配置，但是它内部默认集成了IdentityServer和HttpApi.Host模块，相当于前后端不分离，所以它可以直接用。~~ 包含HTTP API服务器地址和IdentityServer等配置，前后端分离，需要先启动HTTP API和IdentityServer程序才能正常使用

### 启动过程

1. 切换到DemoApp.IdentityServer目录执行```dotnet ef database update```初始化数据库，启动DemoApp.IdentityServer(需要启动redis)
2. 启动DemoApp.HttpApi.Host（如果在DemoApp中新建了数据库则也需要dotnet ef database update，但默认是没有的所以可以直接打开）
3. 启动DemoApp.Blazor.Host(wasm)和DemoApp.Blazor.Server.Host(ssr)

## 致谢
- [官方文档](https://docs.abp.io/zh-Hans/abp/latest)
- [BootstrapBlazor](https://gitee.com/LongbowEnterprise/BootstrapBlazor)
