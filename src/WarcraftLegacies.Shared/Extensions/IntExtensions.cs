using System;

namespace WarcraftLegacies.Shared.Extensions
{
  public static class IntExtensions
  {
    public static string IdToFourCc(this int value, bool reverse = false)
    {
      const string charMap =
        ".................................!.#$%&'()*+,-./0123456789:;<=>.@ABCDEFGHIJKLMNOPQRSTUVWXYZ[.]^_`abcdefghijklmnopqrstuvwxyz{|}~.................................................................................................................................";
      var result = "";
      var remainingValue = value;

      for (var i = 0; i < 4; i++)
      {
        var charValue = remainingValue % 256;

        remainingValue /= 256;
        result += charMap[charValue];
      }

      return reverse ? Reverse(result) : result;
    }

    private static string Reverse(string s)
    {
      var charArray = s.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }
  }
}