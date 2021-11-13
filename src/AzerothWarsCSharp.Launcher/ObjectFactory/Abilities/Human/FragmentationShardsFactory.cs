using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human
{
  public sealed class FragShardsFactory : PassiveAbilityFactory<FragShards>
  {
    public string ArtTarget { get; set; } = @"Abilities\Weapons\FlyingMachine\FlyingMachineImpact.mdl";
    public string TargetAttachmentPoint { get; set; } = "chest";
    public LeveledAbilityPropertyFloat FullDamageAmount { get; set; } = new("Full damage amount", 25);
    public LeveledAbilityPropertyFloat FullDamageRadius { get; set; } = new("Full damage radius", 100);
    public LeveledAbilityPropertyFloat MediumDamageAmount { get; set; } = new("Medium damage amount", 15);
    public LeveledAbilityPropertyFloat MediumDamageRadius { get; set; } = new("Medium damage radius", 225);
    public LeveledAbilityPropertyFloat SmallDamageAmount { get; set; } = new("Small damage amount", 10);
    public LeveledAbilityPropertyFloat SmallDamageRadius { get; set; } = new("Small damage radius", 275);
    public LeveledAbilityPropertyTargets TargetsAllowed { get; set; } = new("Targets allowed", new Target[] { Target.Ground, Target.Enemies, Target.Air } );

    protected override void ApplyStats(FragShards ability)
    {
      ability.ArtTarget = new[] { ArtTarget};
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

    public override FragShards Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new FragShards(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public FragShardsFactory() : base()
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