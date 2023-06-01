# CumulocityCoreLibrary

## Usage

Use the public factory to access `API` classes. The factory is available as a singleton and groups `API` classes by category.

```csharp
using Com.Cumulocity.Client.Supplementary;

var factory = new CumulocityCoreLibrary(...);
var api = factory.Applications.ApplicationsApi;
```

In addition, each `API` class provides a public initializer.

```csharp
var api = ApplicationsApi()
```

The `HttpClient` needs to be an argument for creating each `API` class and for creating the creating.

### Configure request information

Additional request information need to be configured for each `API` class, such as HTTP scheme, host name or additional headers (i.e. Authorization header). The client is using the `System.Net` library and thus a `HttpClient` needs to be configured. Before creating the API classes, make sure that the `BaseAdress` configured as followed:

```csharp
var uri = new Uri(...);
var httpClient = new HttpClient();
httpClient.BaseAddress = uri;
var factory = new CumulocityCoreLibrary(httpClient);
```

### Use your own domain model

The CumulocityCoreLibrary allows custom data models. The following classes are designed to be extensible:

- `Alarm`, `AuditRecord`, `CategoryOptions`, `CustomProperties`, `Event`, `ManagedObject`, `Measurement`, `Operation`

Those classes allow to add an arbitrary number of additional properties as a list of key-value pairs. These properties are known as custom fragments and can be of any type. Each custom fragment is identified by a unique name. Thus, developers can propagate their custom fragments using:

```csharp
Alarm.Serialization.RegisterAdditionalProperty(String, Type);
```

Each of the extensible objects contains a dictionary object holding instances of custom fragments. Use the custom fragment's key to access its value.
### Tests

Example usage is explained within the `Test` project. To configure the tests, it's required to specify host and credentials. Locate the appsettings.test.json file and configure the settings:

```json
{
	"Configuration": {
		"Hostname": "http://... or https://...",
		"Username": "...",
		"Password": "***"
	}
}
```

### Basic Authentication

The client sends HTTP requests with the `Authorization` header. Use the `NetworkCredential` class to pass user name and password.

```csharp
using System;
using System.Net;
using System.Net.Http;

var httpClientHandler = new HttpClientHandler()
{
	Credentials = new NetworkCredential("userName", ",***")
};
var httpClient = new HttpClient(httpClientHandler);
```

## Contribution

If you've spotted something that doesn't work as you'd expect, or if you have a new feature you'd like to add, we're happy to accept contributions and bug reports.

For bug reports, please raise an issue directly in this repository by selecting the `issues` tab and then clicking the `new issue` button. Please ensure that your bug report is as detailed as possible and allows us to reproduce your issue easily.

In the case of new contributions, please create a new branch from the latest version of `main`. When your feature is complete and ready to evaluate, raise a new pull request.

---

These tools are provided as-is and without warranty or support. They do not constitute part of the Software AG product suite. Users are free to use, fork and modify them, subject to the license agreement. While Software AG welcomes contributions, we cannot guarantee to include every contribution in the master project.
