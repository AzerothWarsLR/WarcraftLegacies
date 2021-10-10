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

    protected void ApplyButtonPositions(T ability)
    {
      ability.ArtButtonPositionNormalX = ButtonPosition.X;
      ability.ArtButtonPositionNormalY = ButtonPosition.Y;
      ability.ArtButtonPositionResearchX = ButtonPosition.X;
      ability.ArtButtonPositionResearchY = 0;
    }

    protected abstract void ApplyStats(T ability);

    protected abstract void ApplyTooltipLearnExtended(T ability);

    protected abstract void ApplyTooltipNormalExtended(T ability);

    /// <summary>
    /// Applies essential features like mana cost and cooldown.
    /// </summary>
    /// <param name="ability"></param>
    protected abstract void ApplyCore(T ability);

    public void Apply(T ability)
    {
      ability.StatsLevels = Levels;
      ability.TextName = TextName;
      ApplyButtonPositions(ability);
      ApplyCore(ability);
      ApplyStats(ability);
      ApplyTooltipLearnExtended(ability);
      ApplyTooltipNormalExtended(ability);
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