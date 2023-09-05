namespace Launcher.IntegrityChecker
{
  public static class StringExtensions
  {
    public static bool IsModelPath(this string text) => 
      (text.EndsWith(".mdx") || text.EndsWith(".mdl")) && !text.ToLower().EndsWith("_portrait.mdx");

    public static string CleanModelPath(this string text)
    {
      return text.Replace("/", "\\");
    }
  }
}