using System.Diagnostics;

namespace Guider.Tests;

public sealed class CliRunner
{
    private readonly string _cliProjectPath;
    private readonly Process _process;

    public CliRunner(string cliProjectPath)
    {
        _cliProjectPath = cliProjectPath;
        _process = new Process();
        _process.StartInfo.FileName = "dotnet";
        _process.StartInfo.RedirectStandardOutput = true;
    }

    public (int exitCode, string output) Run(string args)
    {
        _process.StartInfo.Arguments = $"run --project {_cliProjectPath} -- {args}";
        _process.Start();
        string output = _process.StandardOutput.ReadToEnd();
        _process.WaitForExit();
        return (_process.ExitCode, output);
    }
}