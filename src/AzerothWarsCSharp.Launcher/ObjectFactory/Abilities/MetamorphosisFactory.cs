using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class MetamorphosisFactory : ActiveAbilityFactory<DemonHunterMetamorphosis>
  {
    private void GenerateTooltip(DemonHunterMetamorphosis ability)
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

    private void GenerateMetamorphosis(DemonHunterMetamorphosis ability)
    {
      //ability.DataAlternateFormHitPointBonus = BonusHitPoints;
      //ability.DataAlternateFormUnit = AlternateForm;
      //ability.DataMorphingFlags = MorphFlags;
      //ability.DataNormalFormUnit = NormalForm;
      //ability.StatsDurationNormal = Duration;
      //ability.StatsDurationHero = TransformTime;
    }

    public override DemonHunterMetamorphosis Generate(string newRawCode)
    {
      var newAbility = new DemonHunterMetamorphosis(newRawCode);
      GenerateCore(newAbility);
      GenerateMetamorphosis(newAbility);
      GenerateTooltip(newAbility);
      GenerateButtonPositions(newAbility);
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