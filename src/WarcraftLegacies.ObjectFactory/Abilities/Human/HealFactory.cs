using War3Api.Object;
using War3Api.Object.Abilities;
using WarcraftLegacies.ObjectFactory.AbilityProperties;
using War3Api.Object.Enums;

namespace WarcraftLegacies.ObjectFactory.Abilities.Human
{
  public class HealFactory : AutocastAbilityFactory<Heal>
  {
    public string[] ArtTarget = new[] { @"Abilities\Spells\Human\Heal\HealTarget.mdl" };
    public LeveledAbilityPropertyFloat HitPointsGained = new("Hit points gained", 25);
    public LeveledAbilityPropertyFloat CastRange = new("Cast range", 250);
    public LeveledAbilityPropertyTargets TargetsAllowed = new("Targets allowed", new Target[] { Target.Air, Target.Ground, Target.Friend,
    Target.Vulnerable, Target.Invulnerable, Target.Self, Target.Organic, Target.Nonancient, Target.Neutral});
    public LeveledAbilityPropertyBuffs Buffs = new("Buffs applied");

    protected override void ApplyStats(Heal ability)
    {
      ability.ArtTarget = ArtTarget;
      for (var i = 0; i < Levels; i++)
      {
        ability.DataHitPointsGained[i + 1] = HitPointsGained[i];
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsTargetsAllowed[i + 1] = TargetsAllowed[i];
        ability.StatsBuffs[i + 1] = Buffs[i];
      }
    }

    public Buff GenerateBuff(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newBuff = new Buff(BuffType.Heal, newRawCode, objectDatabase)
      {
        TextNameEditorOnly = TextName,
        TextTooltip = TextName,
        ArtIcon = $@"ReplaceableTextures\CommandButtons\BTN{Icon}.blp",
        //StatsRace = Race;
      };
      return newBuff;
    }

    public override Heal Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new Heal(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public HealFactory() : base()
    {
      Properties.Add(HitPointsGained);
      Properties.Add(CastRange);
      Properties.Add(TargetsAllowed);
    }
  }
}