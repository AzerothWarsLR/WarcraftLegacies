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

    protected override void ApplyTooltipLearnExtended(AerialShackles ability)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Magically binds a target unit, so that it cannot move or attack and takes damage per second.");
      stringBuilder.Append("|n");
      stringBuilder.Append(DamagePerSecond.ToConcatenatedString());
      stringBuilder.Append(CastRange.ToConcatenatedString());
      //stringBuilder.Append(TargetsAllowed.ToConcatenatedString());
      stringBuilder.Append(DurationUnit.ToConcatenatedString());
      stringBuilder.Append(DurationHero.ToConcatenatedString());
      stringBuilder.Append(ManaCost.ToConcatenatedString());
      stringBuilder.Append(Cooldown.ToConcatenatedString());
      ability.TextTooltipLearnExtended = stringBuilder.ToString();
    }

    protected override void ApplyTooltipNormalExtended(AerialShackles ability)
    {
      ability.TextName = TextName;
      for (var i = 0; i < Levels; i++)
      {
        ability.TextTooltipNormal[i + 1] = $"{TextName} - [|cffffcc00Level {i + 1}|r]";
        ability.TextTooltipNormalExtended[i + 1] = $"Magically binds a target enemy air unit, so " +
          $"that it cannot move or attack and takes {DamagePerSecond.ValueToString(i)} damage per second. " +
          $"|nLasts {DurationUnit.ValueToString(i)} seconds.";
      }
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
