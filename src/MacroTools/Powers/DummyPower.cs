using WarcraftLegacies.MacroTools.FactionSystem;
using War3Api;

namespace WarcraftLegacies.MacroTools.Powers
{
  public class DummyPower : Power
  {
    public DummyPower(string name, string description, string iconName)
    {
      Name = name;
      Description = description;
      IconName = iconName;
    }

    public override void OnAdd(Common.player whichPlayer)
    {
    }

    public override void OnRemove(Common.player whichPlayer)
    {
    }
  }
}