using TextCopy;
using System.CommandLine;

RootCommand rootCommand = new("Generate a GUID and copy it to the clipboard");
rootCommand.SetHandler(GenerateGuid);
return await rootCommand.InvokeAsync(args);

void GenerateGuid()
{
    Guid guid = Guid.NewGuid();
    Console.WriteLine(guid);
    ClipboardService.SetText(guid.ToString());
}