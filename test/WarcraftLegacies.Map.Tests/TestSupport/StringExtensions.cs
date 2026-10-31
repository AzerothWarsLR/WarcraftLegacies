namespace WarcraftLegacies.Map.Tests.TestSupport;

public static class StringExtensions
{
  public static bool IsModelPath(this string text) =>
    (text.EndsWith(".mdx") || text.EndsWith(".mdl")) && !text.ToLower().EndsWith("_portrait.mdx");

  public static string NormalizeModelPath(this string text)
  {
    var path = text.ToLower().Replace(@"\\", "\\").Replace("/", "\\");
    return path.EndsWith(".mdl") ? path[..^4] + ".mdx" : path;
  }
}
