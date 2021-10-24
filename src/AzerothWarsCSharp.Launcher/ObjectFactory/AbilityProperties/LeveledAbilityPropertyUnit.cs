using System.Collections.Generic;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyBuffs : LeveledAbilityProperty<IEnumerable<Buff>>
  {
    protected override string ValueToString(IEnumerable<Buff> value)
    {
      return value.ToString();
    }

    public LeveledAbilityPropertyBuffs(string name, IEnumerable<Buff> defaultValue = default) : base(name, defaultValue)
    {

    }
  }
}