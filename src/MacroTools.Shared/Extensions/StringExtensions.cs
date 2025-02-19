namespace MacroTools.Shared.Extensions
{
  public static class StringExtensions
  {
    public static string Reverse(this string s)
    {
      var charArray = s.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }
  }
}