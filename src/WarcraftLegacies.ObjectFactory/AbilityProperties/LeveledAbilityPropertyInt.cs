namespace WarcraftLegacies.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyInt : LeveledAbilityProperty<int>
  {
    protected override string ValueToString(int value)
    {
      return value.ToString("n0");
    }

    public LeveledAbilityPropertyInt(string name, int defaultValue = 0) : base(name, defaultValue)
    {

    }
  }
}