using War3Api.Object;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyDefenseType : LeveledAbilityProperty<DefenseTypeInt>
  {
    protected override string ValueToString(DefenseTypeInt value)
    {
      return value.ToString();
    }

    public LeveledAbilityPropertyDefenseType(string name, DefenseTypeInt defaultValue = default) : base(name, defaultValue)
    {

    }
  }
}