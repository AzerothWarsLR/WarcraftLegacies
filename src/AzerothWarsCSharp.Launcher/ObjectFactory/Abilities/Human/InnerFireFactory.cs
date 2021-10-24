using War3Api.Object;
using War3Api.Object.Abilities;
using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human
{
  public class InnerFireFactory : AutocastAbilityFactory<InnerFire>
  {
    public LeveledAbilityPropertyFloat DamageIncrease = new("Damage increase", 0.1f, true);
    public LeveledAbilityPropertyInt DefenseIncrease = new("Armor increase", 5);
    public LeveledAbilityPropertyFloat HitpointRegenRate = new("Hit points regained per second", 0);
    public LeveledAbilityPropertyFloat CastRange = new("Cast range", 500);
    public LeveledAbilityPropertyFloat Duration = new("Duration", 60);
    public LeveledAbilityPropertyTargets TargetsAllowed = new("Targets allowed", new Target[] { Target.Air, Target.Ground,
    Target.Friend, Target.Neutral, Target.Self});
    public LeveledAbilityPropertyBuffs Buffs = new("Buffs applied");
    public int SpellStealPriority = 10;
    public string TargetArt = @"Abilities\Spells\Human\InnerFire\InnerFireTarget.mdl";
    public string AttachmentPoint = "overhead";

    protected override void ApplyStats(InnerFire ability)
    {
      ability.StatsPriorityForSpellSteal = SpellStealPriority;
      for (var i = 0; i < Levels; i++)
      {
        ability.DataDamageIncrease[i + 1] = DamageIncrease[i];
        ability.StatsCastRange[i + 1] = DefenseIncrease[i];
        ability.DataLifeRegenRate[i + 1] = HitpointRegenRate[i];
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.DataAutocastRange[i + 1] = CastRange[i];
        ability.StatsDurationHero[i + 1] = Duration[i];
        ability.StatsDurationNormal[i + 1] = Duration[i];
        ability.StatsTargetsAllowed[i + 1] = TargetsAllowed[i];
      }
    }

    public Buff GenerateBuff(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newBuff = new Buff(BuffType.InnerFire, newRawCode, objectDatabase)
      {
        TextNameEditorOnly = TextName,
        TextTooltip = TextName,
        ArtIcon = $@"ReplaceableTextures\CommandButtons\BTN{Icon}.blp",
        ArtEffectAttachmentPoint = new[] { AttachmentPoint },
        ArtTarget = new[] { TargetArt }
        //StatsRace = Race;
      };
      return newBuff;
    }

    public override InnerFire Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new InnerFire(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public InnerFireFactory() : base()
    {
      Properties.Add(DamageIncrease);
      Properties.Add(DefenseIncrease);
      Properties.Add(HitpointRegenRate);
      Properties.Add(CastRange);
      Properties.Add(Duration);
      Properties.Add(TargetsAllowed);
    }
  }
}