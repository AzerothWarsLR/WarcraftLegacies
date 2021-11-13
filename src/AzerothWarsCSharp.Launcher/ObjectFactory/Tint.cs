namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public struct Tint
  {
    public float Red { get; set; }
    public float Green { get; set; }
    public float Blue { get; set; }

    public Tint(int red = 255, int green = 255, int blue = 255)
    {
      Red = red;
      Green = green;
      Blue = blue;
    }
  }
}