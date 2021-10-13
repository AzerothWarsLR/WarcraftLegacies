using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public sealed class ImmolationFactory : ActiveAbilityFactory<ImmolationCreep>
  {
    public LeveledAbilityProperty<float> BufferManaRequired { get; set; } = new("Buffer mana required");
    public LeveledAbilityProperty<float> DamagePerSecond { get; set; } = new("Damage per second");
    public LeveledAbilityProperty<float> ManaDrainedPerSecond { get; set; } = new("Mana drained per second");
    public LeveledAbilityProperty<float> AreaOfEffect { get; set; } = new("Area of effect");

    protected override string GenerateTooltipExtended(int level)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Activate to engulf this unit in flames, dealing damage each second to nearby enemy land units.");
      stringBuilder.Append($"|nDrains mana until deactivated.");
      stringBuilder.Append("|n");
      stringBuilder.Append(DamagePerSecond.ToConcatenatedString(level));
      stringBuilder.Append(BufferManaRequired.ToConcatenatedString(level));
      stringBuilder.Append(ManaDrainedPerSecond.ToConcatenatedString(level));
      stringBuilder.Append(AreaOfEffect.ToConcatenatedString(level));
      return stringBuilder.ToString();
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

    public override ImmolationCreep Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new ImmolationCreep(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

  }
}