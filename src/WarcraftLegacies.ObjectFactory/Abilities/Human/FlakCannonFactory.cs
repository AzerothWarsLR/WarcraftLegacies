using WarcraftLegacies.ObjectFactory.AbilityProperties;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;

namespace WarcraftLegacies.ObjectFactory.Abilities.Human
{
  public sealed class FlakCannonFactory : PassiveAbilityFactory<FlakCannon>
  {
    public string ArtTarget { get; set; } = @"Abilities\Weapons\FlyingMachine\FlyingMachineImpact.mdl";
    public string TargetAttachmentPoint { get; set; } = "chest";
    public LeveledAbilityPropertyFloat FullDamageAmount { get; set; } = new("Full damage amount", 7);
    public LeveledAbilityPropertyFloat FullDamageRadius { get; set; } = new("Full damage radius", 75);
    public LeveledAbilityPropertyFloat MediumDamageAmount { get; set; } = new("Medium damage amount", 6);
    public LeveledAbilityPropertyFloat MediumDamageRadius { get; set; } = new("Medium damage radius", 150);
    public LeveledAbilityPropertyFloat SmallDamageAmount { get; set; } = new("Small damage amount", 5);
    public LeveledAbilityPropertyFloat SmallDamageRadius { get; set; } = new("Small damage radius", 325);
    public LeveledAbilityPropertyTargets TargetsAllowed { get; set; } = new("Targets allowed", new Target[] { Target.Enemies, Target.Neutral, Target.Air });

    protected override void ApplyStats(FlakCannon ability)
    {
      ability.ArtTarget = new[] { ArtTarget };
      ability.ArtTargetAttachmentPoint1 = new[] { TargetAttachmentPoint };
      for (var i = 0; i < Levels; i++)
      {
        ability.DataFullDamageAmount[i + 1] = FullDamageAmount[i];
        ability.StatsAreaOfEffect[i + 1] = FullDamageRadius[i];
        ability.DataMediumDamageAmount[i + 1] = MediumDamageAmount[i];
        ability.DataMediumDamageRadius[i + 1] = MediumDamageRadius[i];
        ability.DataSmallDamageAmount[i + 1] = SmallDamageAmount[i];
        ability.DataSmallDamageRadius[i + 1] = SmallDamageRadius[i];
      }
    }

    public override FlakCannon Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new FlakCannon(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public FlakCannonFactory() : base()
    {
      Properties.Add(FullDamageAmount);
      Properties.Add(FullDamageRadius);
      Properties.Add(MediumDamageAmount);
      Properties.Add(MediumDamageRadius);
      Properties.Add(SmallDamageAmount);
      Properties.Add(SmallDamageRadius);
      Properties.Add(TargetsAllowed);
    }
  }
}