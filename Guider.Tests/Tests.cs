using System.Text.RegularExpressions;

namespace Guider.Tests;

public sealed class Tests
{
    private static readonly CliRunner CliRunner = new(Path.Combine(Directory.GetCurrentDirectory(), "../../../../Guider.Console"));

    [Test]
    public void OutputsValidGuid()
    {
        // Act
        var (exitCode, output) = CliRunner.Run("");
        bool valid = Guid.TryParse(output, out Guid guid);
        
        // Assert
        valid.Should().Be(true);
        exitCode.Should().Be(0);
    }
    
    [Test]
    public void UsesMajorMinorPatchVersioning()
    {
        // Act
        var (exitCode, output) = CliRunner.Run("--version");
        bool valid = Regex.IsMatch(output, @"^\d+\.\d+\.\d+$");
        
        // Assert
        valid.Should().Be(true);
        exitCode.Should().Be(0);
    }
    
    [Test]
    public void UsesCustomToolName()
    {
        // Act
        var (exitCode, output) = CliRunner.Run("--help");
        
        // Assert
        output.Should().NotContain("Guider.Console");
        exitCode.Should().Be(0);
    }
}