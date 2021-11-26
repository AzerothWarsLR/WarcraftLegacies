using AzerothWarsCSharp.ObjectFactory.AbilityProperties;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.ObjectFactory.Abilities
{
  public sealed class ImmolationFactory : ActiveAbilityFactory<ImmolationCreep>
  {
    public LeveledAbilityPropertyFloat BufferManaRequired { get; set; } = new("Buffer mana required", 10);
    public LeveledAbilityPropertyFloat DamagePerSecond { get; set; } = new("Damage per second");
    public LeveledAbilityPropertyFloat ManaDrainedPerSecond { get; set; } = new("Mana drained per second", 7);
    public LeveledAbilityPropertyFloat AreaOfEffect { get; set; } = new("Area of effect", 50);

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

    public ImmolationFactory() : base()
    {
      Properties.Add(BufferManaRequired);
      Properties.Add(DamagePerSecond);
      Properties.Add(ManaDrainedPerSecond);
      Properties.Add(AreaOfEffect);
    }

  }
}