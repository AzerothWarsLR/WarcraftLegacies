using WarcraftLegacies.ObjectFactory.AbilityProperties;
using System.Collections.Generic;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;

namespace WarcraftLegacies.ObjectFactory.Abilities
{
  public class ControlMagicFactory : ActiveAbilityFactory<ControlMagic>
  {
    public LeveledAbilityPropertyFloat ManaPerSummonedHitpoint { get; set; } = new("Mana cost per hit points of target summoned unit");
    public LeveledAbilityPropertyTargets TargetsAllowed { get; set; } = new("Targets allowed", new List<Target>());
    public LeveledAbilityPropertyInt MaximumCreepLevel { get; set; } = new("Maximum creep level");
    public LeveledAbilityPropertyFloat CastRange { get; set; } = new("Cast range");
    public LeveledAbilityPropertyFloat Duration { get; set; } = new("Duration");

    protected override void ApplyStats(ControlMagic ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsTargetsAllowed[i + 1] = TargetsAllowed[i];
        ability.StatsDurationNormal[i + 1] = Duration[i];
        ability.StatsDurationHero[i + 1] = Duration[i];
        ability.DataManaPerSummonedHitpoint[i + 1] = ManaPerSummonedHitpoint[i];
        ability.DataMaximumCreepLevel[i + 1] = MaximumCreepLevel[i];
      }
    }

    public override ControlMagic Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new ControlMagic(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public ControlMagicFactory() : base()
    {
      Properties.Add(ManaPerSummonedHitpoint);
      Properties.Add(CastRange);
      Properties.Add(TargetsAllowed);
      Properties.Add(MaximumCreepLevel);
      Properties.Add(Duration);
    }
  }
}