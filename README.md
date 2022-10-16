# GraphQL Service

## APIs that are used to collect market data:
    * Coingecko


## EF Core
    * dotnet tool update --global dotnet-ef

    * dotnet ef migrations add InitialCreate --project Graph.DataAccess --startup-project Graph.API --context <>
    * dotnet ef database update --project Graph.DataAccess --startup-project Graph.API