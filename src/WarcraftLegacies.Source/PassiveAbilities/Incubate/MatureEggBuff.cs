using MacroTools.Extensions;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.PassiveAbilities.Incubate
{
  /// <summary>
  /// Causes the egg to hatch into a unit when it dies.
  /// </summary>
  public sealed class MatureEggBuff : PassiveBuff
  {
    /// <summary>The unit type ID of the unit that gets hatched.</summary>
    public required int HatchedUnitTypeId { get; init; }

    /// <inheritdoc />
    public MatureEggBuff(unit caster) : base(caster, caster)
    {
      Duration = float.MaxValue;
    }

    /// <inheritdoc />
    public override void OnApply()
    {
      BlzSetUnitName(Target, "Mature Egg");
      SetUnitVertexColor(Target, 255, 255, 255, 255);
      Target
        .AddAbility(ABILITY_ZBBS_HATCH_INCUBATE);

      AddSpecialEffect(@"Abilities\Spells\Items\AIem\AIemTarget.mdl", GetUnitX(Target), GetUnitY(Target))
        .SetColor(0, 255, 0)
        .SetScale(0.5f)
        .SetLifespan();
    }

    /// <inheritdoc />
    public override void OnDeath(bool killingBlow)
    {
      var rallyPoint = Target.GetRallyPoint();
      if (rallyPoint.X == 0 && rallyPoint.Y == 0)
        rallyPoint = Target.GetPosition();
      
      CreateUnit(Target.OwningPlayer(), HatchedUnitTypeId, GetUnitX(Target), GetUnitY(Target), 270)
        .IssueOrder("attack", rallyPoint);
    }
  }
}