using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertySilenceFlags : LeveledAbilityProperty<SilenceFlags>, ILeveledAbilityPropertyReadable
  {
    protected override string ValueToString(SilenceFlags value)
    {
      return "notImplemented";
    }

    public LeveledAbilityPropertySilenceFlags(string name, SilenceFlags defaultValue = default) : base(name, defaultValue)
    {

    }
  }
}