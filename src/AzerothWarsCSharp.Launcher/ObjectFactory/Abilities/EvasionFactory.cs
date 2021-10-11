using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public sealed class EvasionFactory : PassiveAbilityFactory<DemonHunterEvasion>
  {
    public LeveledAbilityProperty<float> ChanceToEvade { get; set; } = new("Evasion chance");

    protected override void ApplyTooltipLearnExtended(DemonHunterEvasion ability)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Gives a chance to evade incoming attacks.");
      stringBuilder.Append("|n");
      stringBuilder.Append(ChanceToEvade.ToConcatenatedString(true));
      ability.TextTooltipLearnExtended = stringBuilder.ToString();
    }

    protected override void ApplyTooltipNormalExtended(DemonHunterEvasion ability)
    {
      ability.TextTooltipLearn = $"Learn {TextName} - [|cffffcc00Level %d|r]";
      ability.TextName = TextName;
      for (var i = 0; i < Levels; i++)
      {
        ability.TextTooltipNormal[i+1] = $"{TextName} - [|cffffcc00Level {i+1}|r]";
        ability.TextTooltipNormalExtended[i+1] = $"Gives a {ChanceToEvade.ValueToString(i, true)}% chance to avoid an attack.";
      }
    }

    protected override void ApplyStats(DemonHunterEvasion ability)
    {
      ability.StatsLevels = Levels;
      ability.StatsHeroAbility = true;
      ability.StatsItemAbility = false;
      for (var i = 0; i < Levels; i++)
      {
        ability.DataChanceToEvade[i+1] = ChanceToEvade[i];
      }
    }

    public override DemonHunterEvasion Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new DemonHunterEvasion(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }
  }
}