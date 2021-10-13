using System.Collections.Generic;
using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class CloudOfFogFactory : ActiveAbilityFactory<CloudOfFog>
  {
    public LeveledAbilityProperty<float> AttackSpeedModifier { get; set; } = new("Attack speed modifier");
    public LeveledAbilityProperty<float> CastRange { get; set; } = new("Cast range");
    public LeveledAbilityProperty<IEnumerable<Target>> TargetsAllowed { get; set; } = new("Targets allowed");
    public LeveledAbilityProperty<SilenceFlags> AttacksPrevented { get; set; } = new("Attacks prevented");
    public LeveledAbilityProperty<float> Duration { get; set; } = new("Duration");
    public LeveledAbilityProperty<float> ChanceToMiss { get; set; } = new("Chance to miss");

    protected override string GenerateTooltipExtended(int level)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Cast on enemy buildings with ranged attacks to stop the buildings from attacking.");
      stringBuilder.Append("|n");
      stringBuilder.Append(AttackSpeedModifier.ToConcatenatedString(level, true));
      stringBuilder.Append(CastRange.ToConcatenatedString(level));
      stringBuilder.Append(TargetsAllowed.ToConcatenatedString(level));
      stringBuilder.Append(AttacksPrevented.ToConcatenatedString(level));
      stringBuilder.Append(Duration.ToConcatenatedString(level));
      stringBuilder.Append(ChanceToMiss.ToConcatenatedString(level, true));
      stringBuilder.Append(ManaCost.ToConcatenatedString(level));
      stringBuilder.Append(Cooldown.ToConcatenatedString(level));
      return stringBuilder.ToString();
    }

    protected override void ApplyStats(CloudOfFog ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsTargetsAllowed[i + 1] = TargetsAllowed[i];
        ability.StatsDurationNormal[i + 1] = Duration[i];
        ability.StatsDurationHero[i + 1] = Duration[i];
        ability.DataAttacksPrevented[i + 1] = AttacksPrevented[i];
        ability.DataAttackSpeedModifier[i + 1] = AttackSpeedModifier[i];
        ability.DataChanceToMiss[i + 1] = ChanceToMiss[i];
      }
    }

    public override CloudOfFog Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new CloudOfFog(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }
  }
}