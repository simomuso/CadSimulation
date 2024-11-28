// See https://aka.ms/new-console-template for more information
public class ApplicationOptions
{
    public string FilesystemPath { get; set; } = null!;
    public Uri? ServiceUri { get; set; } = null!;
    public bool UseJsonFormat { get; set; }
}
