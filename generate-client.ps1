dotnet restore

# Build API project
dotnet build InheritanceExample\InheritanceExample.csproj --no-restore

# Build generator project
dotnet build InheritanceExample.ClientGenerator\InheritanceExample.ClientGenerator.csproj --no-restore

# Generate swagger.json
Write-Host Generate swagger.json
dotnet swagger tofile --output "swagger.json" "InheritanceExample\bin\Debug\net8.0\InheritanceExample.dll" v1

# Generate client files
Write-Host Generate client files
dotnet InheritanceExample.ClientGenerator\bin\Debug\net8.0\InheritanceExample.ClientGenerator.dll --swaggerFile swagger.json --output InheritanceExample.Client\Generated\Client.cs