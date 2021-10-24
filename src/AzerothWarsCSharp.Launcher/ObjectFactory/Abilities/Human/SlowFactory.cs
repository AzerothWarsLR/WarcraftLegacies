using War3Api.Object;
using War3Api.Object.Abilities;
using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human
{
  public class SlowFactory : AutocastAbilityFactory<SlowCreep>
  {
    public LeveledAbilityPropertyFloat AttackSpeedDecrease = new("Attack speed reduction", 0.25f, true);
    public LeveledAbilityPropertyFloat MovementSpeedDecrease = new("Movement speed reduction", 0.6f, true);
    public LeveledAbilityPropertyFloat CastRange = new("Cast range", 600);
    public LeveledAbilityPropertyFloat DurationNormal = new("Duration (normal)", 10);
    public LeveledAbilityPropertyFloat DurationHero = new("Duration (hero)", 20);
    public LeveledAbilityPropertyTargets TargetsAllowed = new("Targets allowed", new Target[] { Target.Air, Target.Ground, Target.Enemies});
    public LeveledAbilityPropertyBuffs Buffs = new("Buffs applied");
    public int SpellStealPriority = 3;
    public string TargetArt = @"Abilities\Spells\Human\SlowCreep\SlowCreepTarget.mdl";
    public string AttachmentPoint = "origin";

    protected override void ApplyStats(SlowCreep ability)
    {
      ability.StatsPriorityForSpellSteal = SpellStealPriority;
      for (var i = 0; i < Levels; i++)
      {
        ability.DataAttackSpeedFactor[i + 1] = AttackSpeedDecrease[i];
        ability.DataMovementSpeedFactor[i + 1] = MovementSpeedDecrease[i];
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsDurationHero[i + 1] = DurationHero[i];
        ability.StatsDurationNormal[i + 1] = DurationNormal[i];
        ability.StatsTargetsAllowed[i + 1] = TargetsAllowed[i];
        ability.StatsBuffs[i + 1] = Buffs[i];
      }
    }

    public Buff GenerateBuff(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newBuff = new Buff(BuffType.Slow, newRawCode, objectDatabase)
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

    public override SlowCreep Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new SlowCreep(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public SlowFactory() : base()
    {
      Properties.Add(AttackSpeedDecrease);
      Properties.Add(MovementSpeedDecrease);
      Properties.Add(CastRange);
      Properties.Add(DurationNormal);
      Properties.Add(DurationHero);
      Properties.Add(TargetsAllowed);
    }
  }
}