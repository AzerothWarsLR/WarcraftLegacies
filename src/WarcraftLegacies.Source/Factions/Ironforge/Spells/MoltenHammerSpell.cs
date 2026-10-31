using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Leaves a patch of fire where the hammer lands, burning enemies standing in it.</summary>
public sealed class MoltenHammerSpell : Spell
{
  public required float Radius { get; init; }
  public required float Duration { get; init; }
  public required float DamagePerSecond { get; init; }
  public required string FireEffectPath { get; init; }

  public MoltenHammerSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var speed = caster.GetAbility(Id).MissileSpeed;
    var distance = MathEx.GetDistanceBetweenPoints(new Point(caster.X, caster.Y), new Point(target.X, target.Y));
    var flightTime = speed > 0 ? distance / speed : 0;
    var landing = timer.Create();
    landing.Start(flightTime, false, () =>
    {
      landing.Dispose();
      Burn(caster, target.X, target.Y);
    });
  }

  private void Burn(unit caster, float x, float y)
  {
    var fire = effect.Create(FireEffectPath, x, y);
    var elapsed = 0f;
    var ticker = timer.Create();
    ticker.Start(1, true, () =>
    {
      elapsed += 1;
      if (elapsed > Duration)
      {
        ticker.Dispose();
        fire.Dispose();
        return;
      }

      foreach (var victim in GlobalGroup.EnumUnitsInRange(x, y, Radius))
      {
        if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, victim) || victim.UnitType == DummyCasterManager.UnitTypeId ||
            victim.IsUnitType(unittype.Structure))
        {
          continue;
        }

        caster.DealDamage(victim, DamagePerSecond, false, false, attacktype.Magic, damagetype.Fire, weapontype.WhoKnows);
      }
    });
  }
}
