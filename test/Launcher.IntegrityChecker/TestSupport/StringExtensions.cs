namespace Launcher.IntegrityChecker.TestSupport;

public static class StringExtensions
{
  public static bool IsModelPath(this string text) =>
    (text.EndsWith(".mdx") || text.EndsWith(".mdl")) && !text.ToLower().EndsWith("_portrait.mdx");

  public static string NormalizeModelPath(this string text)
  {
    return text.ToLower().Replace(@"\\", "\\").Replace("/", "\\");
  }
}
