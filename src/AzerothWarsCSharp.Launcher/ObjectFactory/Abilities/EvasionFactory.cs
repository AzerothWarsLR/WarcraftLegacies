using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class EvasionFactory : PassiveAbilityFactory<Evasion>
  {
    public float[] ChanceToEvade { get; set; }

    private void GenerateTooltip(Evasion ability)
    {
      ability.TextTooltipLearnExtended = $"Gives a {ArrayToConcatenatedString(ChanceToEvade, true)} chance to avoid an attack.";
      ability.TextTooltipLearn = $"Learn {TextName} - [|cffffcc00Level %d|r]";
      ability.TextName = TextName;
      for (var i = 0; i < Levels; i++)
      {
        ability.TextTooltipNormal[i+1] = $"{TextName} - [|cffffcc00Level {i+1}|r]";
        ability.TextTooltipNormalExtended[i+1] = $"Gives a {ChanceToEvade[i] * 100:n0}% chance to avoid an attack.";
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
      GenerateTooltip(newAbility);
      return newAbility;
    }
  }
}