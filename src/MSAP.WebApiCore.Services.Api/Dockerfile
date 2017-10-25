FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY /src/MSAP.WebApiCore.Services.Api/*.csproj ./
COPY /src/MSAP.WebApiCore.Application/*.csproj ./
COPY /src/MSAP.WebApiCore.Domain/*.csproj 
COPY /src/MSAP.WebApiCore.Infra.Data/*.csproj ./
COPY /src/MSAP.WebApiCore.Infra.CrossCutting.EventBus/*.csproj ./
COPY /src/MSAP.WebApiCore.Infra.CrossCutting.EventBusRabbitMQ/*.csproj 
COPY /src/MSAP.WebApiCore.Infra.CrossCutting.IoC/*.csproj ./


RUN dotnet restore

# Copy everything else and build
COPY /src/MSAP.WebApiCore.Services.Api/ ./

RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MSAP.WebApiCore.Services.Api.dll"]
