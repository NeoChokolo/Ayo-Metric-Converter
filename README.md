# Ayo Metric Converter Technical Test

**Hosted Link** : http://aries-hr.southafricanorth.cloudapp.azure.com/metric-converter/swagger/index.html

**NB** Should the project fail to compile for whatever reason a post man project has been loaded to test against the deployed version of the API.

## Tech

Project uses a number of technology stack:

- .Net Core 3.1
- SQL Server Database

## Run the app

Run the following command in the **Terminal**:
- Clone the repo
```dotnetcli
git clone https://github.com/NeoChokolo/Ayo-Metric-Converter.git
```
- Restore nuget packages
```dotnetcli
dotnet restore
```
- **Run the SQL file "AyoConverter.sql" contained in the project solution to create the database, tables and initial data**

```dotnetcli
dotnet run 
alternatively press F5 on visual studio/visual code
```


## Main Nugets Used

| Name | Nuget Url |
| ------ | ------ |
| Swagger |  |
| Jace |  |
| AutoMapper |  |
| Microsoft Entity Framework Core |  |

## License

MIT
