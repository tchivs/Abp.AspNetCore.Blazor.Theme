# Abp VNext Themes 
Abp VNext�����������ʵ�֣�Ŀǰʵ����BootstrapBlazor���⡣
## ���

- Abp.AspNetCore.Blazor.Theme >	 ���⹫��ģ��
- Abp.AspNetCore.Blazor.Theme.Server >	 Serverģʽ���⹫��ģ��
- Abp.AspNetCore.Blazor.Theme.WebAssembly >	 WebAssemblyģʽ���⹫��ģ��
- themes/bootstrap
	- Abp.AspNetCore.Blazor.Theme.Bootstrap > BootstrapBlazor���⹫��ģ�飬������```Abp.AspNetCore.Blazor.Theme```
	- Abp.AspNetCore.Blazor.Theme.Bootstrap.Server >	 BootstrapBlazor Serverģʽ����ģ�飬������```Abp.AspNetCore.Blazor.Theme.Server```
	- Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly >		BootstrapBlazor WebAssemblyģʽ����ģ�飬������```Abp.AspNetCore.Blazor.Theme.WebAssembly```

����Ŀ�����滻Abp Blazor�ļ���ģ�飺

- ```Volo.Abp.AspNetCore.Components.Web.BasicTheme``` �滻Ϊ ```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap```
- ```Volo.Abp.AspNetCore.Components.Server.BasicTheme``` �滻Ϊ ```Abp.AspNetCore.Blazor.Theme.Server```
- ```Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme``` �滻Ϊ ```Abp.AspNetCore.Blazor.Theme.WebAssembly```
- ```Volo.Abp.AspNetCore.Components.Server.Theming``` �滻Ϊ ```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.Server```
- ```Volo.Abp.AspNetCore.Components.WebAssembly.Theming``` �滻Ϊ ```Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly```

## Demo

��Ҫ˵����

- ```IdentityServer``` Ӧ�ó���������Ӧ�ó���ʹ�õ������֤������,�����Լ���appsettings.json�������ݿ������ַ������������ã���Ҫ��ʼ�����ݿ�
- ```HttpApi.Host``` �й�ģ���HTTP API. �����Լ���appsettings.json�������ݿ������ַ�������������
- ```Blazor.HostBlazor``` WebAssemblyģʽ���������������Լ���appsettings.json(λ��wwwroot��)����HTTP API��������ַ��IdentityServer�����ã�ǰ��˷��룬��Ҫ������ǰ�����������������ʹ��
- ```Blazor.Server.HostBlazor``` Serverģʽ���������������Լ���appsettings.json ~~�������ݿ������ַ������������ã��������ڲ�Ĭ�ϼ�����IdentityServer��HttpApi.Hostģ�飬�൱��ǰ��˲����룬����������ֱ���á�~~ ����HTTP API��������ַ��IdentityServer�����ã�ǰ��˷��룬��Ҫ������HTTP API��IdentityServer�����������ʹ��

�������̣�

1. �л���DemoApp.IdentityServerĿ¼ִ��```dotnet ef database update```��ʼ�����ݿ⣬����DemoApp.IdentityServer
2. ����DemoApp.HttpApi.Host�������DemoApp���½������ݿ���Ҳ��Ҫdotnet ef database update����Ĭ����û�е����Կ���ֱ�Ӵ򿪣�
3. ����DemoApp.Blazor.Host(wasm)��DemoApp.Blazor.Server.Host(ssr)
