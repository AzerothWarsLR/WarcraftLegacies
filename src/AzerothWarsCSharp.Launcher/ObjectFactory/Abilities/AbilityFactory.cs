using System.Drawing;
using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public abstract class AbilityFactory<T> : IObjectFactory<T> where T : Ability
  {
    public string ArrayToConcatenatedString(float[] array, bool isPercentage = false)
    {
      StringBuilder stringBuilder = new();
      foreach (var number in array)
      {
        if (isPercentage) {
          stringBuilder.Append(number*100);
        } else
        {
          stringBuilder.Append(number);
        }
        stringBuilder.Append('/');
      }
      return stringBuilder.ToString();
    }

    public string ArrayToConcatenatedString(int[] array)
    {
      StringBuilder stringBuilder = new();
      foreach (var number in array)
      {
        stringBuilder.Append(number);
        stringBuilder.Append('/');
      }
      return stringBuilder.ToString();
    }

    /// <summary>
    /// How many levels this ability has.
    /// </summary>
    public int Levels { get; set; }

    /// <summary>
    /// Generate a new ability instance.
    /// </summary>
    /// <param name="newRawCode"></param>
    /// <returns></returns>
    public abstract T Generate(string newRawCode);

    /// <summary>
    /// The icon for the ability.
    /// </summary>
    public string ArtIcon { get; set; }

    /// <summary>
    /// Name of the ability.
    /// </summary>
    public string TextName { get; set; }

    public Point ButtonPosition { get; set; }
  }
}