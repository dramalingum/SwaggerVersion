# Splitting up swagger documentation
This project provides an example of how to configure Swagger in order to achieve:

- Separating API calls into multiple swagger JSON files.
- Displaying the API calls in separate parts of the Swagger UI.

### Project Setup
This is a **.Net Core 2.1** API project and requires the following packages:

- Swashbuckle.AspNetCore
- Swashbuckle.AspNetCore.SwaggerUI

### Swagger configuration
In the Startup.cs file we'll do 2 things:

1. Define the swagger documents in the `ConfigureServices()` method:
    ```
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info { Title = "TestApp", Version = "v1" });
        c.SwaggerDoc("apim", new Info { Title = "APIM", Version = "apim" });
        c.CustomSchemaIds(x => x.FullName);
    });
    ```
    The above code defines 2 swagger documents (`v1` and `apim`)
    
2. Configure the swagger UI to use multiple documents in the `Configure()` method:
    ```
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.SwaggerEndpoint("/swagger/apim/swagger.json", "APIM");
    });
    ```
    The above code will configure 2 swagger UI pages that point to the 2 different swagger documents that were defined in the previous step and will make them available via a drop down in the swagger page.
    
### Assigning Controller methods to the Swagger documents
There are a few ways to achieve this which you can refer to in the [Swashbuckle documentation](https://github.com/domaindrivendev/Swashbuckle.AspNetCore#generate-multiple-swagger-documents). 
This example uses the `ApiExplorerSettings` attribute to assign API methods exclusively to specific Swagger document by specifying the 'GroupName':
```
[ApiExplorerSettings(GroupName = "apim")]
[HttpGet]
public ActionResult<IEnumerable<string>> Get()
{
    return new string[] { "value1", "value2" };
}
```
The code above will setup this particular API method to `apim` swagger doccument **only**. 
If we want API methods to appear in all swagger documents then we should not set up the API method with the `ApiExplorerSettings` attribute at all e.g. the project has a `SharedController` that will show in both swagger documents because this attribute has not been specified.