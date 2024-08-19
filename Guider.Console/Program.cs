using TextCopy;

Guid guid = Guid.NewGuid();
Console.WriteLine(guid);
ClipboardService.SetText(guid.ToString());