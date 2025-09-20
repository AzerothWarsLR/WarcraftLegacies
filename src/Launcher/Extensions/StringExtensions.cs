namespace Launcher.Extensions;

public static class StringExtensions
{
  public static string RemoveEnd(this string str, int len)
  {
    if (str.Length < len)
    {
      return string.Empty;
    }

    return str[..^len];
  }
}
