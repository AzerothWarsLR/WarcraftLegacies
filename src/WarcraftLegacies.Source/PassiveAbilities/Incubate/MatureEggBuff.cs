using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Effects;

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

      var effect = AddSpecialEffect(@"Abilities\Spells\Items\AIem\AIemTarget.mdl", GetUnitX(Target), GetUnitY(Target));
      BlzSetSpecialEffectColor(effect, 0, 255, 0);
      BlzSetSpecialEffectScale(effect, 0.5f);
      EffectSystem.Add(effect);
    }

    /// <inheritdoc />
    public override void OnDeath(bool killingBlow)
    {
      var rallyPoint = Target.GetRallyPoint();
      if (rallyPoint.X == 0 && rallyPoint.Y == 0)
        rallyPoint = Target.GetPosition();
      
      CreateUnit(GetOwningPlayer(Target), HatchedUnitTypeId, GetUnitX(Target), GetUnitY(Target), 270)
        .IssueOrder("attack", rallyPoint);
    }
  }
}