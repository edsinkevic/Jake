<!-- GETTING STARTED -->

## Getting Started

### Docker route (best if you already have it set up on your machine):
* <a href='https://docs.docker.com/engine/install/'>Docker installation guide</a>
```sh
docker build -t jake . && docker run -p 5000:80 jake:latest
```

* The OpenAI specification can be accessed here: http://localhost:5000/swagger/index.html (HTTP, not HTTPS)

### .NET CLI route:
* <a href='https://dotnet.microsoft.com/en-us/download'>.NET runtime installation guide</a> (.NET 6) - in you prefer
  installing the needed dependencies on your machine uncontainerized
```sh
dotnet run --project Application/Application.csproj
```

* The OpenAI specification can be accessed here: https://localhost:5000/swagger/index.html
