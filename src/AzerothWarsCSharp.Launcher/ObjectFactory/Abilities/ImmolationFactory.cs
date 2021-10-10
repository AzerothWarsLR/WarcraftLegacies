using System.Text;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public sealed class ImmolationFactory : ActiveAbilityFactory<ImmolationCreep>
  {
    public LeveledAbilityProperty<float> BufferManaRequired { get; set; } = new("Buffer mana required");
    public LeveledAbilityProperty<float> DamagePerSecond { get; set; } = new("Damage per second");
    public LeveledAbilityProperty<float> ManaDrainedPerSecond { get; set; } = new("Mana drained per second");
    public LeveledAbilityProperty<float> AreaOfEffect { get; set; } = new("Area of effect");

    protected override void ApplyTooltipLearnExtended(ImmolationCreep ability)
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

    protected override void ApplyTooltipNormalExtended(ImmolationCreep ability)
    {

    }

    protected override void ApplyStats(ImmolationCreep ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataBufferManaRequired[i+1] = BufferManaRequired[i];
        ability.DataDamagePerInterval[i+1] = DamagePerSecond[i];
        ability.DataManaDrainedPerSecond[i+1] = ManaDrainedPerSecond[i];
        ability.StatsDurationNormal[i + 1] = 1;
      }
    }

    public override ImmolationCreep Generate(string newRawCode)
    {
      var newAbility = new ImmolationCreep(newRawCode);
      Apply(newAbility);
      return newAbility;
    }

  }
}