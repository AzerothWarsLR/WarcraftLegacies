namespace Launcher.Services
{
  public sealed class DirectoryEnumerationOptions
  {
    public required string Path { get; init; }
    public string SearchPattern { get; init; }
  }
}