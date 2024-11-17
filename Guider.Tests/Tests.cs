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
}