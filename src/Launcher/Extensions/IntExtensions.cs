namespace Launcher.Extensions
{
  public static class IntExtensions
  {
    public static string IdToFourCc(this int value)
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

      return result;
    }
  }
}