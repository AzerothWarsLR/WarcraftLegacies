namespace AzerothWarsCSharp.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyFloat : LeveledAbilityProperty<float>
  {
    private readonly bool _isPercentage;

    protected override string ValueToString(float value)
    {
      if (_isPercentage)
      {
        return (value*100).ToString("n0") + "%";
      }
      else
      {
        return value.ToString("n0");
      }
    }

    public LeveledAbilityPropertyFloat(string name, float defaultValue = 0, bool isPercentage = false) : base(name, defaultValue)
    {
      _isPercentage = isPercentage;
    }
  }
}