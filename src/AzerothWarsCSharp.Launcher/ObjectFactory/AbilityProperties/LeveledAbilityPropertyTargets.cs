using System.Collections.Generic;
using System.Linq;
using System.Text;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyTargets : LeveledAbilityProperty<IEnumerable<Target>>
  {
    protected override string ValueToString(IEnumerable<Target> value)
    {
      var stringBuilder = new StringBuilder();
      var targets = value.ToList();
      var i = 0;
      foreach (var target in targets)
      {
        i++;
        stringBuilder.Append($"{target}");
        if (i < targets.Count)
        {
          stringBuilder.Append(", ");
        }
      }
      return stringBuilder.ToString();
    }

    public LeveledAbilityPropertyTargets(string name, IEnumerable<Target> defaultValue) : base(name, defaultValue)
    {

    }
  }
}