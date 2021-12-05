namespace AzerothWarsCSharp.MacroTools
{
  public struct Color
  {
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }
    public int A { get; set; }

    public Color(int r, int g, int b, int a)
    {
      R = r;
      G = g;
      B = b;
      A = a;
    }
  }
}