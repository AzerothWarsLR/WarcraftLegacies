using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;
using System.Collections.Generic;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class CloudOfFogFactory : ActiveAbilityFactory<CloudOfFog>
  {
    public LeveledAbilityPropertyFloat AttackSpeedModifier { get; set; } = new("Attack speed modifier");
    public LeveledAbilityPropertyFloat CastRange { get; set; } = new("Cast range");
    public LeveledAbilityPropertyTargets TargetsAllowed { get; set; } = new("Targets allowed", new List<Target>());
    public LeveledAbilityPropertySilenceFlags AttacksPrevented { get; set; } = new("Attacks prevented");
    public LeveledAbilityPropertyFloat Duration { get; set; } = new("Duration");
    public LeveledAbilityPropertyFloat ChanceToMiss { get; set; } = new("Chance to miss");

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

    public CloudOfFogFactory() : base()
    {
      Properties.Add(AttackSpeedModifier);
      Properties.Add(CastRange);
      Properties.Add(TargetsAllowed);
      Properties.Add(AttacksPrevented);
      Properties.Add(Duration);
      Properties.Add(ChanceToMiss);
    }
  }
}