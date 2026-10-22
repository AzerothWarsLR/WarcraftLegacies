using MacroTools.DummyCasters;
using MacroTools.Extensions;
using MacroTools.Spells;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Forsaken.Spells;

/// <summary>
/// Doom whose damage grows the longer it lasts. When the target dies, a Doom Guard rises that grows with the damage
/// Doom dealt.
/// </summary>
public sealed class UnravellingDoomSpell : Spell
{
  public required int DoomBuffId { get; init; }
  public required LeveledAbilityField<float> BaseDamagePerSecond { get; init; }
  public required LeveledAbilityField<float> DamageGrowthPerSecond { get; init; }
  public required int DoomGuardTypeId { get; init; }
  public required float DoomGuardDuration { get; init; }
  public required float DamagePerStep { get; init; }
  public required float BonusPerStep { get; init; }
  public required float MaxBonus { get; init; }
  public required string RiseEffectPath { get; init; }

  public UnravellingDoomSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (target == null)
    {
      return;
    }

    var level = GetAbilityLevel(caster);
    var owner = caster.Owner;
    var baseDamage = BaseDamagePerSecond.GetValue(level);
    var growth = DamageGrowthPerSecond.GetValue(level);
    var damageSource = unit.Create(owner, DummyCasterManager.UnitTypeId, target.X, target.Y, 0);
    var seconds = 0;
    var damageDealt = 0f;
    var doomed = false;
    var x = target.X;
    var y = target.Y;
    var facing = target.Facing;
    var ticker = timer.Create();
    ticker.Start(1, true, () =>
    {
      if (target.Alive && target.GetAbilityLevel(DoomBuffId) > 0)
      {
        doomed = true;
        seconds++;
        x = target.X;
        y = target.Y;
        facing = target.Facing;
        var extra = System.Math.Min(growth * seconds, baseDamage);
        damageDealt += baseDamage + extra;
        damageSource.SetPosition(x, y);
        damageSource.DealDamage(target, extra, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
        return;
      }

      ticker.Dispose();
      damageSource.Dispose();
      if (!target.Alive && doomed)
      {
        RaiseDoomGuard(owner, x, y, facing, damageDealt);
      }
    });
  }

  private void RaiseDoomGuard(player owner, float x, float y, float facing, float damageDealt)
  {
    var bonus = System.Math.Min((int)(damageDealt / DamagePerStep) * BonusPerStep, MaxBonus);
    var doomGuard = unit.Create(owner, DoomGuardTypeId, x, y, facing);
    var scale = 1 + bonus / 2;
    doomGuard.SetScale(scale, scale, scale);
    doomGuard.MaxLife = (int)(doomGuard.MaxLife * (1 + bonus));
    doomGuard.Life = doomGuard.MaxLife;
    doomGuard.MultiplyBaseDamage(1 + bonus, 0);
    doomGuard.ApplyTimedLife(0, DoomGuardDuration);
    EffectSystem.Add(effect.Create(RiseEffectPath, x, y), 2);
  }
}
