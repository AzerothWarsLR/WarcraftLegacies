using War3Api.Object;
using War3Api.Object.Abilities;
using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human
{
  public class FlareFactory : ActiveAbilityFactory<Flare>
  {
    public LeveledAbilityPropertyFloat EffectDelay = new("Effect delay", 0.8f);
    public LeveledAbilityPropertyDetectionType DetectionType = new("Detection type", War3Api.Object.DetectionType.Both);
    public LeveledAbilityPropertyFloat AreaOfEffect = new("Area of effect", 1800);
    public LeveledAbilityPropertyFloat CastRange = new("Cast range", 99999);
    public LeveledAbilityPropertyFloat Duration = new("Duration", 15);

    protected override void ApplyStats(Flare ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataEffectDelay[i + 1] = EffectDelay[i];
        ability.DataDetectionType[i + 1] = DetectionType[i];
        ability.StatsAreaOfEffect[i + 1] = AreaOfEffect[i];
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsDurationHero[i + 1] = Duration[i];
        ability.StatsDurationNormal[i + 1] = Duration[i];
      }
    }

    public override Flare Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new Flare(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public FlareFactory() : base()
    {
      Properties.Add(DetectionType);
      Properties.Add(AreaOfEffect);
      Properties.Add(CastRange);
      Properties.Add(Duration);
    }
  }
}