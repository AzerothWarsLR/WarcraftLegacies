using War3Api.Object;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyDetectionType : LeveledAbilityProperty<DetectionType>, ILeveledAbilityPropertyReadable
  {
    protected override string ValueToString(DetectionType value)
    {
      return value.ToString();
    }

    public LeveledAbilityPropertyDetectionType(string name, DetectionType defaultValue = default) : base(name, defaultValue)
    {

    }
  }
}