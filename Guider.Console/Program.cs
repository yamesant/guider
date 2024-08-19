using TextCopy;

Guid guid = Guid.NewGuid();
Console.WriteLine($"Here is the GUID: {guid}");
ClipboardService.SetText(guid.ToString());