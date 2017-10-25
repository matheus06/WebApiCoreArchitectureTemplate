FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY /src/MSAP.WebApiCore.Services.Api/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY /src/MSAP.WebApiCore.Services.Api/ ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MSAP.WebApiCore.Services.Api.dll"]
