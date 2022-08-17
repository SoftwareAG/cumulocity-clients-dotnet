# CumulocityCoreLibrary

## Usage

Use the public factory to access `API` classes. The factory is available as a singleton and groups `API` classes by category.

```csharp
using Com.Cumulocity.Client.Supplementary;

var factory = CumulocityCoreLibrary.INSTANCE;
var api = factory.Applications.ApplicationsApi;
```

In addition, each `API` class provides a public initializer.

```csharp
var api = ApplicationsApi()
```

### Configure request information

Additional request information need to be configured for each `API` class, such as HTTP scheme, host name or additional headers (i.e. Authorization header). The client is using the `System.Net` library and thus a `HttpClient` needs to be configured. Before creating the API classes, make sure that the `BaseAdress` configured as followed:

```csharp
var uri = new Uri(...);
factory.HttpClient.BaseAddress = uri;
```

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
factory.HttpClient = httpClient;
```
