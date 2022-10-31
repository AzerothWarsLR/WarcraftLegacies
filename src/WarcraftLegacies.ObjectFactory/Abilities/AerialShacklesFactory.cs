using WarcraftLegacies.ObjectFactory.AbilityProperties;
using System.Collections.Generic;
using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;

namespace WarcraftLegacies.ObjectFactory.Abilities
{
  public class AerialShacklesFactory : ActiveAbilityFactory<AerialShackles>
  {
    public LeveledAbilityPropertyFloat DamagePerSecond { get; set; } = new("Damage per second");
    public LeveledAbilityPropertyFloat CastRange { get; set; } = new("Cast range");
    public LeveledAbilityPropertyTargets TargetsAllowed { get; set; } = new("Targets allowed", new List<Target>());
    public LeveledAbilityPropertyFloat DurationUnit { get; set; } = new("Duration (unit)");
    public LeveledAbilityPropertyFloat DurationHero { get; set; } = new("Duration (hero)");

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

    public AerialShacklesFactory() : base()
    {
      Properties.Add(DamagePerSecond);
      Properties.Add(CastRange);
      Properties.Add(TargetsAllowed);
      Properties.Add(DurationUnit);
      Properties.Add(DurationHero);
    }
  }
}
