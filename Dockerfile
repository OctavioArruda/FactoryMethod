# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the solution file and restore dependencies
COPY *.sln .
COPY src/FactoryMethodExample.Api/*.csproj ./src/FactoryMethodExample.Api/
COPY src/FactoryMethodExample.Application/*.csproj ./src/FactoryMethodExample.Application/
COPY src/FactoryMethodExample.Domain/*.csproj ./src/FactoryMethodExample.Domain/
COPY src/FactoryMethodExample.Infrastructure/*.csproj ./src/FactoryMethodExample.Infrastructure/
# Add additional lines for other projects in your solution, if applicable

RUN dotnet restore

# Copy the entire project and build the application
COPY . .
#RUN dotnet build -c Release --no-restore
RUN dotnet build -c Release

# Stage 2: Publish the application
FROM build AS publish
#RUN dotnet publish -c Release -o /app --no-restore
RUN dotnet publish -c Release -o /app

# Stage 3: Final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FactoryMethodExample.Api.dll"]
