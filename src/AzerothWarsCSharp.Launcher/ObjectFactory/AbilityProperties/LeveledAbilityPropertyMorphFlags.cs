using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public class LeveledAbilityPropertyMorphFlags : LeveledAbilityProperty<MorphFlags>, ILeveledAbilityPropertyReadable
  {
    public string ToConcatenatedString(int level = 0)
    {
      StringBuilder stringBuilder = new();
      stringBuilder.Append($"|n|cffecce87{Name}|r: ");
      for (int i = 0; i < Values.Count; i++)
      {
        if (i + 1 == level || level == 0)
        {
          stringBuilder.Append(Values[i]);
          if (i < Values.Count - 1 && level == 0)
          {
            stringBuilder.Append('/');
          }
        }
      }
      return stringBuilder.ToString();
    }

    public LeveledAbilityPropertyMorphFlags(string name, MorphFlags defaultValue = default) : base(name, defaultValue)
    {

    }
  }
}