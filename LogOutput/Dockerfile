# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore && \
    dotnet publish -o out -c Release

# Publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /out
COPY --from=build /app/out .
CMD ["dotnet", "LogOutput.dll"]
