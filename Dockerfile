# syntax=docker/dockerfile:1 
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /app

# copy csproject and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MovieCharactersAPI.dll"] 