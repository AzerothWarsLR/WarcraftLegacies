namespace Launcher.Services
{
  public sealed class PathData
  {
    public required string AbsolutePath { get; init; }
    
    public required string RelativePath { get; init; }
  }
}