using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public sealed class MetamorphosisFactory : ActiveAbilityFactory<DemonHunterMetamorphosis>
  {
    protected override void ApplyTooltipNormalExtended(DemonHunterMetamorphosis ability)
    {
      
    }

    protected override void ApplyTooltipLearnExtended(DemonHunterMetamorphosis ability)
    {
      ability.TextName = TextName;

      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Transforms the caster into another unit.");
      stringBuilder.Append("|n");
      stringBuilder.Append(BonusHitPoints.ToConcatenatedString());
      stringBuilder.Append(Duration.ToConcatenatedString());
      stringBuilder.Append(AlternateForm.ToConcatenatedString());
      ability.TextTooltipLearnExtended = stringBuilder.ToString();
    }

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

    public override DemonHunterMetamorphosis Generate(string newRawCode)
    {
      var newAbility = new DemonHunterMetamorphosis(newRawCode);
      Apply(newAbility);
      return newAbility;
    }

    public LeveledAbilityProperty<float> BonusHitPoints { get; set; } = new("Bonus hit points");
    public LeveledAbilityProperty<Unit> AlternateForm { get; set; } = new("Alternate form");
    public LeveledAbilityProperty<Unit> NormalForm { get; set; } = new("Normal form");
    public LeveledAbilityProperty<MorphFlags> MorphFlags { get; set; } = new("Morph flags");
    public LeveledAbilityProperty<float> Duration { get; set; } = new("Duration");
    public LeveledAbilityProperty<float> TransformTime { get; set; } = new("Transform time");
  }
}