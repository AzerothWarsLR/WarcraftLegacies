namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public struct Tint
  {
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public Tint(int red = 255, int green = 255, int blue = 255)
    {
      Red = red;
      Green = green;
      Blue = blue;
    }
  }
}