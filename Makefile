nuget:
	dotnet build Cliff.sln -c Release
	dotnet test Cliff.InfrastructureTests/Cliff.InfrastructureTests.csproj
	dotnet test Cliff.UnitTests/Cliff.UnitTests.csproj
	dotnet pack Cliff/Cliff.csproj -o .

template:
	#dotnet new -u Cliff.Template
	dotnet pack Cliff.Template/Cliff.Template.csproj -o .
	dotnet new -i Cliff.Template.1.0.0.nupkg
