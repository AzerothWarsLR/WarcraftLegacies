using MacroTools.FactionSystem;

namespace MacroTools.Powers
{
  public sealed class DummyPower : Power
  {
    public DummyPower(string name, string description)
    {
      Name = name;
      Description = description;
    }

    public override void OnAdd(player whichPlayer)
    {
    }

    public override void OnRemove(player whichPlayer)
    {
    }
  }
}