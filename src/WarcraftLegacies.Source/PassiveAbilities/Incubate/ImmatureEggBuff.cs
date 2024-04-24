using MacroTools.Extensions;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.PassiveAbilities.Incubate
{
  /// <summary>
  /// Causes the egg to mature when the buff expires, allowing it to hatch.
  /// </summary>
  public sealed class ImmatureEggBuff : PassiveBuff
  {
    private bool _isMature;

    /// <summary>The unit type ID of the unit that gets hatched.</summary>
    public required int HatchedUnitTypeId { get; init; }
    
    /// <inheritdoc />
    public ImmatureEggBuff(unit caster) : base(caster, caster)
    {
    }

    /// <inheritdoc />
    public override void OnApply()
    {
      Target.SetTimedLife(Duration + 1);
    }

    /// <inheritdoc />
    public override void OnExpire() => Mature();

    /// <inheritdoc />
    public override void OnDeath(bool killingBlow)
    {
      if (_isMature) 
        CreateUnit(Target.OwningPlayer(), HatchedUnitTypeId, GetUnitX(Target), GetUnitY(Target), 270);
    }

    private void Mature()
    {
      Target
        .SetName("Mature Egg")
        .SetColor(255, 255, 255, 255)
        .AddAbility(ABILITY_ZBBS_HATCH_INCUBATE)
        .SetTimedLife(0);

      AddSpecialEffect(@"Abilities\Spells\Items\AIem\AIemTarget.mdl", GetUnitX(Target), GetUnitY(Target))
        .SetColor(0, 255, 0)
        .SetLifespan();

      _isMature = true;
    }
  }
}