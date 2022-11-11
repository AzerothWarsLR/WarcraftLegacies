using War3Api.Object;
using War3Api.Object.Enums;

namespace WarcraftLegacies.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyMorphFlags : LeveledAbilityProperty<MorphFlags>, ILeveledAbilityPropertyReadable
  {
    protected override string ValueToString(MorphFlags value)
    {
      return "notImplemented";
    }

    public LeveledAbilityPropertyMorphFlags(string name, MorphFlags defaultValue = default) : base(name, defaultValue)
    {

    }
  }
}