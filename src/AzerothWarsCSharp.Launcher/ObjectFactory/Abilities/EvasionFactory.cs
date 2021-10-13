using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public sealed class EvasionFactory : PassiveAbilityFactory<DemonHunterEvasion>
  {
    public LeveledAbilityProperty<float> ChanceToEvade { get; set; } = new("Evasion chance");

    protected override string GenerateTooltipExtended(int level)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Gives a chance to evade incoming attacks.");
      stringBuilder.Append("|n");
      stringBuilder.Append(ChanceToEvade.ToConcatenatedString(level, true));
      return stringBuilder.ToString();
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