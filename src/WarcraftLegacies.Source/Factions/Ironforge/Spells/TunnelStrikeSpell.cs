using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Burrows to a target enemy and bursts up beneath it, then leaves the caster's drill lodged in the ground.</summary>
public sealed class TunnelStrikeSpell : Spell
{
  private const float TickInterval = 0.05f;
  private const float DigDelay = 0.5f;
  private const float BurrowTimeScale = 3;
  private const int BurrowAnimationIndex = 2;
  private const float ArrivalDistance = 60;
  private const float MaxTunnelTime = 3;
  private const int TicksPerDustCloud = 4;

  public required float TunnelSpeed { get; init; }
  public required float Damage { get; init; }
  public required float Radius { get; init; }
  public required int UpgradeResearchId { get; init; }
  public required float UpgradedDamageBonus { get; init; }
  public required float UpgradedLodgedReduction { get; init; }
  public required float LodgedDuration { get; init; }
  public required int StunAbilityId { get; init; }
  public required int LodgedAbilityId { get; init; }
  public required string DustEffectPath { get; init; }
  public required string EruptEffectPath { get; init; }

  public TunnelStrikeSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    SetUnitInvulnerable(caster, true);
    BlzPauseUnitEx(caster, true);
    SetUnitTimeScale(caster, BurrowTimeScale);
    SetUnitAnimationByIndex(caster, BurrowAnimationIndex);
    effect.Create(DustEffectPath, caster.X, caster.Y).Dispose();

    var dig = timer.Create();
    dig.Start(DigDelay, false, () =>
    {
      dig.Dispose();
      Tunnel(caster, target);
    });
  }

  private void Tunnel(unit caster, unit target)
  {
    SetUnitTimeScale(caster, 1);
    SetUnitVertexColor(caster, 255, 255, 255, 0);
    SetUnitPathing(caster, false);

    var destinationX = target.X;
    var destinationY = target.Y;
    var elapsed = 0f;
    var ticks = 0;
    var mover = timer.Create();
    mover.Start(TickInterval, true, () =>
    {
      elapsed += TickInterval;
      ticks++;
      if (target.Alive)
      {
        destinationX = target.X;
        destinationY = target.Y;
      }

      var dx = destinationX - caster.X;
      var dy = destinationY - caster.Y;
      var distance = SquareRoot(dx * dx + dy * dy);
      var step = TunnelSpeed * TickInterval;
      if (distance <= ArrivalDistance || distance <= step || elapsed >= MaxTunnelTime || !caster.Alive)
      {
        mover.Dispose();
        Surface(caster, target, destinationX, destinationY);
        return;
      }

      SetUnitX(caster, caster.X + dx / distance * step);
      SetUnitY(caster, caster.Y + dy / distance * step);
      if (ticks % TicksPerDustCloud == 0)
      {
        effect.Create(DustEffectPath, caster.X, caster.Y).Dispose();
      }
    });
  }

  private void Surface(unit caster, unit target, float x, float y)
  {
    if (caster.Alive)
    {
      SetUnitPosition(caster, x, y);
    }

    SetUnitPathing(caster, true);
    SetUnitVertexColor(caster, 255, 255, 255, 255);
    BlzPauseUnitEx(caster, false);
    SetUnitInvulnerable(caster, false);
    if (!caster.Alive)
    {
      return;
    }

    SetUnitAnimation(caster, "morph alternate");
    QueueUnitAnimation(caster, "stand");
    effect.Create(EruptEffectPath, caster.X, caster.Y).Dispose();

    var upgraded = caster.Owner.GetTechResearched(UpgradeResearchId, false) > 0;
    var damage = Damage;
    var lodgedDuration = LodgedDuration;
    if (upgraded)
    {
      damage += UpgradedDamageBonus;
      lodgedDuration -= UpgradedLodgedReduction;
    }

    foreach (var victim in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, victim) || victim.UnitType == DummyCasterManager.UnitTypeId ||
          victim.IsUnitType(unittype.Structure))
      {
        continue;
      }

      caster.DealDamage(victim, damage, false, false, attacktype.Magic, damagetype.Normal, weapontype.WhoKnows);
    }

    if (CastFilters.IsTargetEnemyAndAliveUnits(caster, target))
    {
      DummyCasterManager.GetGlobalDummyCaster()
        .CastUnit(caster, StunAbilityId, ORDER_THUNDERBOLT, 1, target, DummyCastOriginType.Target);
    }

    Lodge(caster, lodgedDuration);
  }

  private void Lodge(unit caster, float lodgedDuration)
  {
    caster.AddAbility(LodgedAbilityId);
    BlzUnitDisableAbility(caster, FourCC("Amov"), true, false);
    caster.IssueOrder(ORDER_STOP);

    var release = timer.Create();
    release.Start(lodgedDuration, false, () =>
    {
      release.Dispose();
      if (GetUnitTypeId(caster) == 0)
      {
        return;
      }

      BlzUnitDisableAbility(caster, FourCC("Amov"), false, false);
      caster.RemoveAbility(LodgedAbilityId);
    });
  }
}
