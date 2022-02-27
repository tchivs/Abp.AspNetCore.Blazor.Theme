# Abp VNext Blazor Themes 
[![](https://img.shields.io/nuget/dt/Tchivs.Abp.AspNetCore.Blazor.Theme?color=004880&label=downloads&logo=NuGet)](https://www.nuget.org/packages/Tchivs.Abp.AspNetCore.Blazor.Theme/)[![](https://img.shields.io/nuget/vpre/Tchivs.Abp.AspNetCore.Blazor.Theme?color=%23004880&label=NuGet&logo=nuget)](https://www.nuget.org/packages/Tchivs.Abp.AspNetCore.Blazor.Theme/)[![GitHub](https://img.shields.io/github/license/tchivs/Abp.AspNetCore.Blazor.Theme?color=%231281c0)](LICENSE)

Abp VNext Blazor�����������ʵ��

## ��Ŀ����

����Abp NVext��ʹ�õ�BlazorUIΪ[Blazorise](https://github.com/Megabit/Blazorise)������������������UI���,ͬʱ֧��Server��WebAssemblyģʽ��

[����ʵ�ֹ���](https://www.cnblogs.com/tchivs/p/15603214.html)


**�������Blazor UI**
- [BootstrapBlazor](https://gitee.com/LongbowEnterprise/BootstrapBlazor)

**�������ģ��**

- [x] �û�����
- [x] ��ɫ����
- [x] �⻧�������и�����ҳ��û����

### ģ��˵��


- Abp.AspNetCore.Blazor.Theme >	 ���⹫��ģ��
- Abp.AspNetCore.Blazor.Theme.Server >	 Serverģʽ���⹫��ģ��
- Abp.AspNetCore.Blazor.Theme.WebAssembly >	 WebAssemblyģʽ���⹫��ģ��
- themes/bootstrap
	- Abp.AspNetCore.Blazor.Theme.Bootstrap > BootstrapBlazor���⹫��ģ�飬������```Abp.AspNetCore.Blazor.Theme```
	- Abp.AspNetCore.Blazor.Theme.Bootstrap.Server >	 BootstrapBlazor Serverģʽ����ģ�飬������```Abp.AspNetCore.Blazor.Theme.Server```
	- Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly >		BootstrapBlazor WebAssemblyģʽ����ģ�飬������```Abp.AspNetCore.Blazor.Theme.WebAssembly```
- modules
	- feature-management���⻧��������-δ��ɣ�
	- tenant-management���⻧����
	- identity(�û�������ɫ������Ȩ�޹���ҳ��)
## ���ٿ�ʼ

### 1.�½�Abpģ��

```cmd
abp new DemoModule -t module
```

### 2.�滻ģ���е�����

#### 2.1 ��DemoModule.Blazor

����ģ���Blazor������Ŀ��һ�����������д���ҳ������

1. �Ƴ�����```Volo.Abp.AspNetCore.Components.Web.Theming```,�滻Ϊ```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap```��
2. ��```DemoModuleBlazorModule```
  2.1 ��DependsOn��������ģ����```AbpAspNetCoreComponentsWebThemingModule```��Ϊ```AbpAspNetCoreBlazorThemeBootstrapModule```
  2.2 ����```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap``` ```Tchivs.Abp.AspNetCore.Blazor.Theme```�����ռ�
3. ��```_Imports.razor```,ɾ��```@using Volo.Abp.BlazoriseUI``` ```@using Blazorise``` ```@using Blazorise.DataGrid```,���```@using BootstrapBlazor.Components``` ```@using Tchivs.Abp.AspNetCore.Blazor.Theme``` ```@using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap``` ```@using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Components```

#### 2.2 ��DemoModule.Blazor.Server
�����ģ���ssrģʽ�����õ���⣬����򵥣�ֻ��Ҫ�滻�������С�

1. �Ƴ�����```Volo.Abp.AspNetCore.Components.Server.Theming```���滻Ϊ```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Server```
2. ��```DemoAppBlazorServerModule```
  2.1 ��DependsOn��������ģ����```AbpAspNetCoreComponentsServerThemingModule```��Ϊ```AbpAspNetCoreBlazorThemeBootstrapServerModule```
  2.2 ����```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap```�����ռ�

### 2.3 DemoModule.Blazor.WebAssembly
�����ģ���wasmģʽ�����õ���⣬���ϡ�
1. �Ƴ�����```Volo.Abp.AspNetCore.Components.WebAssembly.Theming```���滻Ϊ```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly```
2. ��```DemoAppBlazorWebAssemblyModule```
  2.1 ��DependsOn��������ģ����```AbpAspNetCoreComponentsWebAssemblyThemingModule```��Ϊ```AbpAspNetCoreBlazorThemeBootstrapWebAssemblyModule```
  2.2 ����```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap```�����ռ�

��ʱ����ģ����滻�Ѿ���ɡ���Blazor/Pages��д�Լ���ҳ��Ϳ����ˡ�

����Blazor��������û�滻���⣬�����������滻���Ƚ��鷳�����Կ�[����ʵ�ֹ���](https://www.cnblogs.com/tchivs/p/15603214.html)����DemoApp��Host��ʵ��,���������ֱ�Ӵ���ģ�����ʽ�����Ͳ���Ҫ�ֶ��滻��
��


## Demo

### ��Ҫ˵��

- ```IdentityServer``` Ӧ�ó���������Ӧ�ó���ʹ�õ������֤������,�����Լ���appsettings.json�������ݿ������ַ������������ã���Ҫ��ʼ�����ݿ�
- ```HttpApi.Host``` �й�ģ���HTTP API. �����Լ���appsettings.json�������ݿ������ַ�������������
- ```Blazor.HostBlazor``` WebAssemblyģʽ���������������Լ���appsettings.json(λ��wwwroot��)����HTTP API��������ַ��IdentityServer�����ã�ǰ��˷��룬��Ҫ������ǰ�����������������ʹ��
- ```Blazor.Server.HostBlazor``` Serverģʽ���������������Լ���appsettings.json ~~�������ݿ������ַ������������ã��������ڲ�Ĭ�ϼ�����IdentityServer��HttpApi.Hostģ�飬�൱��ǰ��˲����룬����������ֱ���á�~~ ����HTTP API��������ַ��IdentityServer�����ã�ǰ��˷��룬��Ҫ������HTTP API��IdentityServer�����������ʹ��

### ��������

1. �л���DemoApp.IdentityServerĿ¼ִ��```dotnet ef database update```��ʼ�����ݿ⣬����DemoApp.IdentityServer(��Ҫ����redis)
2. ����DemoApp.HttpApi.Host�������DemoApp���½������ݿ���Ҳ��Ҫdotnet ef database update����Ĭ����û�е����Կ���ֱ�Ӵ򿪣�
3. ����DemoApp.Blazor.Host(wasm)��DemoApp.Blazor.Server.Host(ssr)

## ��л
- [�ٷ��ĵ�](https://docs.abp.io/zh-Hans/abp/latest)
- [BootstrapBlazor](https://gitee.com/LongbowEnterprise/BootstrapBlazor)
