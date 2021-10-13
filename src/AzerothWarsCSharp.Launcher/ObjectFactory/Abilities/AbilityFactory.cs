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

    public bool IsHeroAbility { get; set; } = false;

    protected void ApplyButtonPositions(T ability)
    {
      ability.ArtButtonPositionNormalX = ButtonPosition.X;
      ability.ArtButtonPositionNormalY = ButtonPosition.Y;
      ability.ArtButtonPositionResearchX = ButtonPosition.X;
      ability.ArtButtonPositionResearchY = 0;
    }

    protected abstract void ApplyStats(T ability);

    protected abstract void ApplyIcons(T ability);

    /// <summary>
    /// Creates a string which instructs a reader as to how this ability functions.
    /// If level is 0, return a Learn tooltip which contains all information. 
    /// Otherwise, return a level-specific normal tooltip.
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    protected abstract string GenerateTooltipExtended(int level = 0);

    /// <summary>
    /// Applies essential features like mana cost and cooldown.
    /// </summary>
    /// <param name="ability"></param>
    protected abstract void ApplyCore(T ability);

    public void Apply(T ability)
    {
      ability.StatsLevels = Levels;
      ability.TextName = TextName;
      ability.TextEditorSuffix = EditorSuffix;
      ability.TextTooltipLearnExtended = GenerateTooltipExtended();
      for (var i = 1; i < Levels+1; i++)
      {
        ability.TextTooltipNormalExtended[i] = GenerateTooltipExtended(i);
      }
      //ability.StatsHeroAbility = IsHeroAbility;
      ApplyCore(ability);
      ApplyStats(ability);
      ApplyIcons(ability);
      ApplyButtonPositions(ability);
    }

    //CreateInstance abstract method

    /// <summary>
    /// Generate a new ability instance.
    /// </summary>
    /// <param name="newRawCode"></param>
    /// <returns></returns>
    public abstract T Generate(string newRawCode, ObjectDatabase objectDatabase);

    /// <summary>
    /// The icon for the ability.
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// Name of the ability.
    /// </summary>
    public string TextName { get; set; } = "PLACEHOLDERTEXTNAME";

    public Point ButtonPosition { get; set; }

    public string EditorSuffix { get; set; } = "";
  }
}