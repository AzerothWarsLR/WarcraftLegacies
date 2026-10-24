using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.BansheesHost.Spells;

namespace WarcraftLegacies.Source.Factions.Forsaken.Spells;

/// <summary>When the unit dies, it bursts, damaging nearby enemies and leaving a cloud that keeps damaging them.</summary>
public sealed class DeathThroes : UnitTrait, IEffectOnDeath
{
  public required float BurstDamage { get; init; }
  public required float BurstRadius { get; init; }
  public required string BurstEffectPath { get; init; }
  public required float CloudDuration { get; init; }
  public required float CloudRadius { get; init; }
  public required float CloudDamagePerSecond { get; init; }
  public required string CloudEffectPath { get; init; }
  public required string CloudTickEffectPath { get; init; }

  /// <inheritdoc />
  public void OnDeath()
  {
    var construct = @event.Unit;
    var owner = construct.Owner;
    var x = construct.X;
    var y = construct.Y;
    effect.Create(BurstEffectPath, x, y).Dispose();

    var damageSource = unit.Create(owner, DummyCasterManager.UnitTypeId, x, y, 0);
    foreach (var target in GlobalGroup.EnumUnitsInRange(x, y, BurstRadius))
    {
      if (!target.Alive || target.IsAllyTo(owner) || target.UnitType == DummyCasterManager.UnitTypeId ||
          target.IsUnitType(unittype.Structure))
      {
        continue;
      }

      damageSource.DealDamage(target, BurstDamage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    }

    damageSource.Dispose();

    HazardSystem.Add(new LingeringGriefHazard(construct)
    {
      Radius = CloudRadius,
      DamagePerTick = CloudDamagePerSecond,
      SpiritEffectPath = CloudEffectPath,
      TickEffectPath = CloudTickEffectPath,
      Interval = 1,
      Duration = CloudDuration
    });
  }
}
