using System.IO;
// run install-package System.Management.Automation
// run install-package Microsoft.PowerShell.SDK
using System.Management.Automation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

app.MapGet("/pwsh", (string arg1, string arg2) =>
{
string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
// read file content
string myScript = File.ReadAllText(_filePath + "/script.ps1");



	var result = PowerShell.Create().AddScript(myScript).AddParameter("arg1", arg1).AddParameter("arg2", arg2).Invoke();
	if (result.Count > 0)
	{
		foreach (var PSObject in result)
		{
			return PSObject.ToString();

		}

	}
	return "error occured";


});

app.Run();

