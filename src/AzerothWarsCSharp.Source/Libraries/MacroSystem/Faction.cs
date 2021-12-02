using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries.MacroSystem
{
  public class Faction
  {
    public string Icon { get; }
    public int ControlPointCount { get; set; } = 0;
    public int Income { get; set; } = 0;
    public string Name { get; }
    public string PrefixColor { get; }
    
    public Faction(string name, playercolor playerColor, string prefixColor, string iconName)
    {
      Name = name;
      Icon = iconName;
      PrefixColor = prefixColor;
    }
  }
}