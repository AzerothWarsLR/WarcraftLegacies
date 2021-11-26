using AzerothWarsCSharp.ObjectFactory.AbilityProperties;
using War3Api.Object;

namespace AzerothWarsCSharp.ObjectFactory.Abilities
{
  public abstract class ToggledAbilityFactory<T> : AbilityFactory<T> where T : Ability
  {
    protected override void ApplyName(T ability)
    {
      ability.TextName = TextName;
      ability.TextTooltipLearn = $"Learn {TextName} - [|cffffcc00Level %d|r]";
      for (var i = 1; i < Levels + 1; i++)
      {
        ability.TextTooltipNormal[i] = $"Activate {TextName} - [|cffffcc00Level {Levels}|r]";
        ability.TextTooltipTurnOff[i] = $"Deactivate {TextName} - [|cffffcc00Level {Levels}|r]";
      }
    }

    protected override void ApplyIcons(T ability)
    {
      ability.ArtIconNormal = @$"ReplaceableTextures\CommandButtons\BTN{Icon}On.blp";
      ability.ArtIconTurnOff = @$"ReplaceableTextures\CommandButtons\BTN{Icon}Off.blp";
      ability.ArtIconResearch = @$"ReplaceableTextures\CommandButtons\BTN{Icon}On.blp";
    }

    protected override void ApplyCore(T ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.StatsManaCost[i + 1] = ManaCost[i];
        ability.StatsCooldown[i + 1] = Cooldown[i];
      }
    }

    /// <summary>
    /// How much mana the ability costs.
    /// </summary>
    public LeveledAbilityPropertyInt ManaCost { get; set; } = new("Mana cost", 0);

    /// <summary>
    /// The time the unit with the ability has to wait before using the ability again.
    /// </summary>
    public LeveledAbilityPropertyInt Cooldown { get; set; } = new("Cooldown", 0);

    public ToggledAbilityFactory() : base()
    {
      Properties.Add(ManaCost);
      Properties.Add(Cooldown);
    }
  }
}
