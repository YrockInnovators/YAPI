# Yapi

A simple web-api that serves as the data-feeder to yrock mobile from the yrock website

## Getting Started

### Prerequisites

Here things you need

- [Visual Studio](https://www.visualstudio.com/)

## People to blame

The following personnel is/are responsible for managing this project.

- [actchua@periapsys.com](mailto:actchua@periapsys.com)

## Developer's Guide

The project uses the ff. technology:

- WebAPi 2
- [.Net framework 4.6.1](https://www.microsoft.com/en-ph/download/details.aspx?id=49981)
- [EntityFramework 6](https://www.asp.net/entity-framework)
- [MySQL.Data](https://www.nuget.org/packages/MySql.Data)
	- Used to connect to the MySQL server

Solution structure:

- Yapi.Web
	- The main WebApi project
- Yapi.EF
	- Contains the EntityFramework module
	- All of the data-manipulations were done here
	
Additional:

1.Create ```ConnectionStrings.config``` that contains your connection. Follow the format below and edit the parameters accordingly:

```html
<connectionStrings>
  <add name="YapiContext" connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=MySql.Data.MySqlClient;provider connection string=&quot;server=[SERVER];persistsecurityinfo=True;user id=[USER_ID];password=[PASSWORD];database=[DATABASE]&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>
```

2.Create ```AppSettingsSecrets.config``` that contain the core settings. You may need to do extra research:

```html
<appSettings>
  <add key="blogCategory" value="[INT]" />
</appSettings>
```

3.Place the two beside your ```Web.config```