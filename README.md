# KawaiiAPI.NET

KawaiiAPI.NET is a C# client library that allows you to interact with the Kawaii.Red API to retrieve random GIF URLs based on different categories. Whether you're building a fun application, a website, or just want to add some cuteness to your project, this library makes it easy to fetch adorable GIFs.

## Installation

You can install the KawaiiAPI.NET library via NuGet Package Manager

```mathematica
Install-Package KawaiiAPI.NET
```

Or by using the .NET CLI:

```csharp
dotnet add package KawaiiAPI.NET
``` 

## Getting Started
1.  **Obtain an API Token**: To use the KawaiiAPI.NET library, you need an API token from Kawaii.Red. You can sign up on their website to get a token. https://kawaii.red/
    
2.  **Initialize the Client**: Once you have an API token, you can create an instance of the `KawaiiClient` class. If you don't provide a token, the client will use the anonymous token by default.
    

```csharp
using KawaiiAPI.NET; 
// Initialize the client with your API token  
var client = new KawaiiClient("your-api-token");
```

3. **Retrieve Random GIFs**: You can use the `GetRandomGifAsync` method to retrieve a random GIF URL from a specific category. Pass the desired `KawaiiGifType` to the method.

```csharp
using KawaiiAPI.NET.Enums;

// Get a random GIF URL from a specific category
string gifUrl = await client.GetRandomGifAsync(KawaiiGifType.Cats);`
```

## Examples
### Simple example
Here's an example of how you can use the KawaiiAPI.NET library to retrieve a random ``hug`` GIF:

```csharp
using System;
using System.Threading.Tasks;
using KawaiiAPI.NET;
using KawaiiAPI.NET.Enums;

class Program
{
    static async Task Main(string[] args)
    {
        var kawaiiclient = new KawaiiClient("your-api-token");

        try
        {
            string catGifUrl = await kawaiiclient.GetRandomGifAsync(KawaiiGifType.Hug);
            Console.WriteLine($"Random Cat GIF URL: {hugGifUrl}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
```
### Example using Dependency Injection

```csharp
using System;
using Microsoft.Extensions.DependencyInjection;
using KawaiiAPI.NET;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a service collection
            var services = new ServiceCollection();

            // Register KawaiiClient in the service collection
            services.AddSingleton<KawaiiClient>(sp =>
            {
                var apiKey = "your-api-key"; // Replace with your actual API key
                return new KawaiiClient(apiKey);
            });

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Get an instance of KawaiiClient from the service provider
            var kawaiiClient = serviceProvider.GetRequiredService<KawaiiClient>();

            // Now you can use the kawaiiClient to get random GIF URLs
            try
            {
                var randomGifUrl = kawaiiClient.GetRandomGifAsync(KawaiiGifType.Cats).GetAwaiter().GetResult();
                Console.WriteLine($"Random GIF URL: {randomGifUrl}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
```

## Discord Bot Example
[here](https://github.com/FabiChan99/KawaiiAPI.NET.ExampleBot)


## Contributions and Issues

Contributions, issues, and feature requests are welcome! If you encounter any problems while using the library or have suggestions for improvements, please [open an issue](https://github.com/FabiChan99/KawaiiAPI.NET/issues) on GitHub.

## License

This project is licensed under the [MIT License](https://github.com/FabiChan99/KawaiiAPI.NET/blob/master/LICENSE.txt). Feel free to use, modify, and distribute the library according to the terms of the license.


_Note: This library is not officially affiliated with KawaiiAPI. Make sure to review their API usage guidelines before integrating this library into your project._
