// See https://aka.ms/new-console-template for more information

using Cliff.Infrastructure;
using Cliff.Template.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new IocModule("Cliff.Template", "Cliff.Template cli application")
	.Build();

var cliService = serviceProvider.GetService<ICliService>();

if (cliService is null)
{
	Console.WriteLine("Warning! CLI Service was not found");
	return;
}

await cliService.ExecuteAsync(args);
