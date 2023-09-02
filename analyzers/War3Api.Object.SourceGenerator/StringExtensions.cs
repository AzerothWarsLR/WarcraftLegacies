namespace War3Api.Object.SourceGenerator
{
  public static class StringExtensions
  {
    public static string ToCamelCase(this string input) => char.ToLowerInvariant(input[0]) + input.Substring(1);
  }
}