using System.Collections.Generic;
using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class AerialShacklesFactory : ActiveAbilityFactory<AerialShackles>
  {
    public LeveledAbilityProperty<float> DamagePerSecond { get; set; } = new("Damage per second");
    public LeveledAbilityProperty<float> CastRange { get; set; } = new("Cast range");
    public LeveledAbilityProperty<IEnumerable<Target>> TargetsAllowed { get; set; } = new("Targets allowed");
    public LeveledAbilityProperty<float> DurationUnit { get; set; } = new("Duration (unit)");
    public LeveledAbilityProperty<float> DurationHero { get; set; } = new("Duration (hero)");

    protected override string GenerateTooltipExtended(int level)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Magically binds a target unit, so that it cannot move or attack and takes damage per second.");
      stringBuilder.Append("|n");
      stringBuilder.Append(DamagePerSecond.ToConcatenatedString(level));
      stringBuilder.Append(CastRange.ToConcatenatedString(level));
      //stringBuilder.Append(TargetsAllowed.ToConcatenatedString(level));
      stringBuilder.Append(DurationUnit.ToConcatenatedString(level));
      stringBuilder.Append(DurationHero.ToConcatenatedString(level));
      stringBuilder.Append(ManaCost.ToConcatenatedString(level));
      stringBuilder.Append(Cooldown.ToConcatenatedString(level));
      return stringBuilder.ToString();
    }

    protected override void ApplyStats(AerialShackles ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataDamagePerSecond[i+1] = DamagePerSecond[i];
        ability.StatsCastRange[i + 1] = CastRange[i];
        //ability.StatsTargetsAllowed[i + 1] = TargetsAllowed[i];
        ability.StatsDurationHero[i + 1] = DurationUnit[i];
        ability.StatsDurationHero[i + 1] = DurationHero[i];
      }
      ability.StatsLevels = Levels;
      ability.ArtButtonPositionNormalX = ButtonPosition.X;
      ability.ArtButtonPositionNormalY = ButtonPosition.Y;
    }

    public override AerialShackles Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new AerialShackles(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }
  }
}
