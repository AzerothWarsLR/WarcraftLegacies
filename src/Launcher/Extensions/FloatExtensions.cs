namespace Launcher.Extensions;

public static class FloatExtensions
{
  public static int RoundToNearestMultipleOf(this float val, float multiple)
  {
    var rem = val % multiple;
    var result = val - rem;
    if (rem >= multiple / 2)
    {
      result += multiple;
    }

    return (int)result;
  }
}
