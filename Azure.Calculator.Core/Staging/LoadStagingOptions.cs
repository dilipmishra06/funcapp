namespace Fl.Azure.Calculator.Core;

public record LoadStagingOptions(string? CloseOfBusinessDate = null)
{
    public static LoadStagingOptions Default => new();
}
