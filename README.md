# Deploying .NET Aspire to Azure with App Service, Azure SQL and Application Insights

## 🤔 What is it?

Sample repo for the Dan Does Code Blog Post (TODO: Add link)

## 🎉 Getting Started

### Prerequisites
- [Docker](https://www.docker.com/get-started/) / [Podman](https://podman.io/get-started)
- [Dotnet 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

### Running the Solution

1. Change directory

    Windows:
    ```ps
    cd tools\AppHost\
    ```

    Mac/Linux:
    ```bash
    cd tools/AppHost/
    ```

2. Run the solution

    ```bash
    dotnet run
    ```

> **NOTE:** The first time you run the solution, it may take a while to download the docker images, create the DB, and seed the data.

4. Open https://localhost:7255/scalar/v1 in your browser to see it running ️🏃‍♂️
