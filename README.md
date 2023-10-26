# AuthSchema

AuthSchema is a REST API written in C# using .NET Core 5.0 and following the layered architecture pattern. The API aims to provide a Single Sign-On (SSO) service for authentication and user creation of various types.

## Installation

To run the application, you must have .NET Core 5.0 SDK installed. After installing the SDK, follow these steps:

Open the terminal in the project folder and run the following command:

```bash
dotnet run
```


## Usage
Open the browser and access the following address:

```
http://localhost:5000/swagger
```

## Architecture

The API follows the layered architecture pattern, separating responsibilities into different layers:

- The WebAPI layer is responsible for exposing API endpoints using the HTTP protocol.
- The Application layer is responsible for implementing the API's business rules.
- The Infrastructure layer is responsible for implementing integration with the database and other external services.
- The Domain layer is responsible for representing entities and business rules of the application.


## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
