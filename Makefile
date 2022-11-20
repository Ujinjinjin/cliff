nuget:
	dotnet build Cliff.sln -c Release
	dotnet test Cliff.InfrastructureTests/Cliff.InfrastructureTests.csproj
	dotnet test Cliff.UnitTests/Cliff.UnitTests.csproj
	dotnet pack Cliff/Cliff.csproj -o .
