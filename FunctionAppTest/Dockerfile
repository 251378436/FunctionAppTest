FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY ./ClassLibrary1 ./ClassLibrary1
RUN cd ClassLibrary1

WORKDIR /app/ClassLibrary1
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o /app/out

WORKDIR /app
# Copy everything
COPY ./FunctionAppTest ./FunctionAppTest
RUN cd FunctionAppTest

WORKDIR /app/FunctionAppTest
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "FunctionAppTest.dll"]