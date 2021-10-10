using System.Text;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class EvasionFactory : PassiveAbilityFactory<Evasion>
  {
    public LeveledAbilityProperty<float> ChanceToEvade { get; set; } = new("Evasion chance");

    private void GenerateTooltipLearnExtended(Evasion ability)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Gives a chance to evade incoming attacks.");
      stringBuilder.Append("|n");
      stringBuilder.Append(ChanceToEvade.ToConcatenatedString(true));
      ability.TextTooltipLearnExtended = stringBuilder.ToString();
    }

    private void GenerateTooltip(Evasion ability)
    {
      ability.TextTooltipLearn = $"Learn {TextName} - [|cffffcc00Level %d|r]";
      ability.TextName = TextName;
      for (var i = 0; i < Levels; i++)
      {
        ability.TextTooltipNormal[i+1] = $"{TextName} - [|cffffcc00Level {i+1}|r]";
        ability.TextTooltipNormalExtended[i+1] = $"Gives a {ChanceToEvade.ValueToString(i, true)}% chance to avoid an attack.";
        ability.DataChanceToEvade[i+1] = ChanceToEvade[i];
      }
    }

    private void GenerateCoreEvasion(Evasion ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataChanceToEvade[i + 1] = ChanceToEvade[i];
      }
      ability.ArtIconNormal = ArtIcon;
      ability.ArtIconResearch = ArtIcon;
      ability.StatsLevels = Levels;
      ability.ArtButtonPositionNormalX = ButtonPosition.X;
      ability.ArtButtonPositionNormalY = ButtonPosition.Y;
    }

    public override Evasion Generate(string newRawCode)
    {
      var newAbility = new Evasion(newRawCode);
      GenerateCoreEvasion(newAbility);
      GenerateTooltipLearnExtended(newAbility);
      GenerateTooltip(newAbility);
      GenerateButtonPositions(newAbility);
      return newAbility;
    }
  }
}