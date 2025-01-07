using System;
using System.CommandLine;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;

var rootCommand = new RootCommand();

var swaggerFile = new Option<FileInfo>("--swaggerFile", "The path to the swagger JSON definition file");
rootCommand.AddOption(swaggerFile);

var output = new Option<FileInfo>("--output", "The path to output the generated file to");
rootCommand.AddOption(output);

rootCommand.SetHandler(
	async (swaggerFileInfo, outputInfo) => await RunAsync(swaggerFileInfo, outputInfo),
	swaggerFile,
	output);

return await rootCommand.InvokeAsync(args);

static async Task RunAsync(FileInfo swaggerFile, FileInfo output)
{
	if (Directory.Exists(output.DirectoryName))
		Directory.Delete(output.DirectoryName, true);

	Console.WriteLine("Ensure output directory: " + output.DirectoryName);
	Directory.CreateDirectory(output.DirectoryName);
	
	var swaggerJson = File.ReadAllText(swaggerFile.FullName);
	var document = await OpenApiDocument.FromJsonAsync(swaggerJson);

	var clientProjectNamespace = Assembly.GetExecutingAssembly().FullName
		!.Split(',')[0]
		.Replace(".ClientGenerator", ".Client");

	var settings = new CSharpClientGeneratorSettings
	{
		CSharpGeneratorSettings =
		{
			Namespace = clientProjectNamespace,
			// JsonPolymorphicSerializationStyle = CSharpJsonPolymorphicSerializationStyle.NJsonSchema
		}
	};

	var generator = new CSharpClientGenerator(document, settings);
	var code = generator.GenerateFile();
	File.WriteAllText(output.FullName, code);
}
