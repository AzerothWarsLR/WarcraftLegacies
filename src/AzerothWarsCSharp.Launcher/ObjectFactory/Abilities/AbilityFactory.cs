using System.Drawing;
using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public abstract class AbilityFactory<T> : IObjectFactory<T> where T : Ability
  {
    /// <summary>
    /// How many levels this ability has.
    /// </summary>
    public int Levels { get; set; }

    public void GenerateButtonPositions(T ability)
    {
      ability.ArtButtonPositionNormalX = ButtonPosition.X;
      ability.ArtButtonPositionNormalY = ButtonPosition.Y;
      ability.ArtButtonPositionResearchX = ButtonPosition.X;
      ability.ArtButtonPositionResearchY = 0;
    }

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
    public string TextName { get; set; } = "PLACEHOLDERTEXTNAME";

    public Point ButtonPosition { get; set; }
  }
}