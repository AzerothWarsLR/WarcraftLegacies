using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyUnit : LeveledAbilityProperty<Unit>
  {
    protected override string ValueToString(Unit value)
    {
      return value.TextName;
    }

    public LeveledAbilityPropertyUnit(string name, Unit defaultValue = default) : base(name, defaultValue)
    {

    }
  }
}