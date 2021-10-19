using System.Collections.Generic;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyTargets : LeveledAbilityProperty<IEnumerable<Target>>
  {
    protected override string ValueToString(IEnumerable<Target> value)
    {
      return "notImplemented";
    }

    public LeveledAbilityPropertyTargets(string name, IEnumerable<Target> defaultValue = default) : base(name, defaultValue)
    {

    }
  }
}