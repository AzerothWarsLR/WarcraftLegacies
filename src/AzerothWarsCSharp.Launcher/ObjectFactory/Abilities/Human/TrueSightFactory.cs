using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human
{
  public sealed class TrueSightFactory : PassiveAbilityFactory<DetectGeneral>
  {
    public LeveledAbilityPropertyFloat CastRange { get; set; } = new("Detection radius", 900);
    public LeveledAbilityPropertyDetectionType DetectionType { get; set; } = new("Detection type", War3Api.Object.Enums.DetectionType.Both);
    public LeveledAbilityPropertyTargets TargetsAllowed { get; set; } = new("Targets allowed", new Target[] { Target.Vulnerable, Target.Invulnerable });

    protected override void ApplyStats(DetectGeneral ability)
    {
      ability.StatsLevels = Levels;
      for (var i = 0; i < Levels; i++)
      {
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.DataDetectionType[i + 1] = DetectionType[i];
        ability.StatsTargetsAllowed[i + 1] = TargetsAllowed[i];
      }
    }

    public override DetectGeneral Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new DetectGeneral(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public TrueSightFactory() : base()
    {
      Properties.Add(CastRange);
      Properties.Add(DetectionType);
      Properties.Add(TargetsAllowed);
    }
  }
}