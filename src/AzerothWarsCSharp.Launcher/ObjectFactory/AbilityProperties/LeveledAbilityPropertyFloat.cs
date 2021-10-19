using System.Text;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyFloat : LeveledAbilityProperty<float>, ILeveledAbilityPropertyReadable
  {
    private readonly bool _isPercentage;

    public string ToConcatenatedString(int level = 0)
    {
      StringBuilder stringBuilder = new();
      stringBuilder.Append($"|n|cffecce87{Name}|r: ");
      for (int i = 0; i < Values.Count; i++)
      {
        if (i + 1 == level || level == 0)
        {
          var number = Values[i];
          if (_isPercentage)
          {
            stringBuilder.Append(number.ToString("n0"));
            stringBuilder.Append('%');
          }
          else
          {
            stringBuilder.Append(number);
          }
          if (i < Values.Count - 1 && level == 0)
          {
            stringBuilder.Append('/');
          }
        }
      }
      return stringBuilder.ToString();
    }

    public LeveledAbilityPropertyFloat(string name, float defaultValue = 0, bool isPercentage = false) : base(name, defaultValue)
    {
      _isPercentage = isPercentage;
    }
  }
}