using AzerothWarsCSharp.ObjectFactory.AbilityProperties;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.ObjectFactory.Abilities
{
  public sealed class MetamorphosisFactory : ActiveAbilityFactory<DemonHunterMetamorphosis>
  {
    public LeveledAbilityPropertyFloat BonusHitPoints { get; set; } = new("Bonus hit points");
    public LeveledAbilityPropertyUnit AlternateForm { get; set; } = new("Alternate form");
    public LeveledAbilityPropertyUnit NormalForm { get; set; } = new("Normal form");
    public LeveledAbilityPropertyMorphFlags MorphFlags { get; set; } = new("Morph flags");
    public LeveledAbilityPropertyFloat Duration { get; set; } = new("Duration");
    public LeveledAbilityPropertyFloat TransformTime { get; set; } = new("Transform time");

    protected override void ApplyStats(DemonHunterMetamorphosis ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataAlternateFormHitPointBonus[i + 1] = BonusHitPoints[i];
        ability.DataAlternateFormUnit[i + 1] = AlternateForm[i];
        ability.DataMorphingFlags[i + 1] = MorphFlags[i];
        ability.DataNormalFormUnit[i + 1] = NormalForm[i];
        ability.StatsDurationNormal[i + 1] = Duration[i];
        ability.StatsDurationHero[i + 1] = TransformTime[i];
      }
    }

    public override DemonHunterMetamorphosis Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new DemonHunterMetamorphosis(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public MetamorphosisFactory() : base()
    {
      Properties.Add(BonusHitPoints);
      Properties.Add(AlternateForm);
      Properties.Add(NormalForm);
      Properties.Add(MorphFlags);
      Properties.Add(Duration);
      Properties.Add(TransformTime);
    }
  }
}