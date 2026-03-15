using MacroTools.Factions;

namespace WarcraftLegacies.Source.Factions.Sentinels.Powers;

public sealed class DummyPower : Power
{
  public DummyPower(string name, string description, string iconName)
  {
    Name = name;
    Description = description;
    IconName = iconName;
  }

  public override void OnAdd(player whichPlayer)
  {
  }

  public override void OnRemove(player whichPlayer)
  {
  }
}
