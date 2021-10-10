using System.Text;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class ImmolationFactory : ActiveAbilityFactory<ImmolationCreep>
  {
    public LeveledAbilityProperty<float> BufferManaRequired { get; set; } = new("Buffer mana required");
    public LeveledAbilityProperty<float> DamagePerSecond { get; set; } = new("Damage per second");
    public LeveledAbilityProperty<float> ManaDrainedPerSecond { get; set; } = new("Mana drained per second");
    public LeveledAbilityProperty<float> AreaOfEffect { get; set; } = new("Area of effect");

    private void GenerateTooltip(ImmolationCreep ability)
    {
      ability.TextName = TextName;

      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Activate to engulf this unit in flames, dealing damage each second to nearby enemy land units.");
      stringBuilder.Append($"|nDrains mana until deactivated.");
      stringBuilder.Append("|n");
      stringBuilder.Append(DamagePerSecond.ToConcatenatedString());
      stringBuilder.Append(BufferManaRequired.ToConcatenatedString());
      stringBuilder.Append(ManaDrainedPerSecond.ToConcatenatedString());
      stringBuilder.Append(AreaOfEffect.ToConcatenatedString());
      ability.TextTooltipLearnExtended = stringBuilder.ToString();
    }

    private void GenerateCoreImmolation(ImmolationCreep ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        //ability.DataBufferManaRequired[i+1] = i < BufferManaRequired.Length ? BufferManaRequired[i] : 0;
        //ability.DataDamagePerInterval[i+1] = i < DamagePerSecond.Length ? DamagePerSecond[i] : 0;
        //ability.DataManaDrainedPerSecond[i+1] = i < ManaDrainedPerSecond.Length ? ManaDrainedPerSecond[i] : 0;
        ability.StatsDurationNormal[i + 1] = 1;
      }
      ability.ArtButtonPositionNormalX = ButtonPosition.X;
      ability.ArtButtonPositionNormalY = ButtonPosition.Y;
      ability.ArtIconNormal = ArtIcon;
      ability.ArtIconResearch = ArtIcon;
    }

    public override ImmolationCreep Generate(string newRawCode)
    {
      var newAbility = new ImmolationCreep(newRawCode);
      GenerateCore(newAbility);
      GenerateCoreImmolation(newAbility);
      GenerateTooltip(newAbility);
      GenerateButtonPositions(newAbility);
      return newAbility;
    }

  }
}