using WCSharp.Shared.Data;

namespace WarcraftLegacies.MacroTools.Mechanics.TwilightHammer
{
  public sealed class Continent
  {
    public Continent(string name, Rectangle area)
    {
      Name = name;
      Area = area;
    }

    public string Name { get; }
    public Rectangle Area { get; }
  }
}