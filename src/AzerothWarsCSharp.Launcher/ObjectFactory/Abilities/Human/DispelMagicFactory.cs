using War3Api.Object;
using War3Api.Object.Abilities;
using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human
{
  public class DispelMagicFactory : ActiveAbilityFactory<DispelMagic>
  {
    public string SpecialArt = @"Abilities\Spells\Human\DispelMagic\DispelMagicTarget.mdl";
    public string TargetArt = @"Abilities\Spells\Human\DispelMagic\DispelMagicTarget.mdl";
    public LeveledAbilityPropertyFloat ManaLoss = new("Mana loss", 0);
    public LeveledAbilityPropertyFloat SummonedUnitDamage = new("Summoned unit damage", 200);
    public LeveledAbilityPropertyFloat AreaOfEffect = new("Area of effect", 200);
    public LeveledAbilityPropertyFloat CastRange = new("Cast range", 700);
    public LeveledAbilityPropertyTargets TargetsAllowed = new("Targets allowed", new Target[] { Target.Air, Target.Ground, 
      Target.Ward, Target.Invulnerable, Target.Vulnerable, Target.Tree});

    protected override void ApplyStats(DispelMagic ability)
    {
      ability.ArtSpecial = new[] { SpecialArt };
      ability.ArtTarget = new[] { TargetArt };
      for (var i = 0; i < Levels; i++)
      {
        ability.DataManaLoss[i + 1] = ManaLoss[i];
        ability.DataSummonedUnitDamage[i + 1] = SummonedUnitDamage[i];
        ability.StatsAreaOfEffect[i + 1] = AreaOfEffect[i];
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsTargetsAllowed[i + 1] = TargetsAllowed[i];
      }
    }

    public override DispelMagic Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new DispelMagic(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public DispelMagicFactory() : base()
    {
      Properties.Add(ManaLoss);
      Properties.Add(SummonedUnitDamage);
      Properties.Add(AreaOfEffect);
      Properties.Add(CastRange);
      Properties.Add(TargetsAllowed);
    }
  }
}