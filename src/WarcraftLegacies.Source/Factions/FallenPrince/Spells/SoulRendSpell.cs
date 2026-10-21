using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Spells;

/// <summary>Damages enemies in an area; every enemy it kills releases a soul that strikes another enemy.</summary>
public sealed class SoulRendSpell : Spell
{
  public required LeveledAbilityField<float> Damage { get; init; }
  public required float Radius { get; init; }
  public required float SoulRange { get; init; }
  public required int MaximumSouls { get; init; }
  public required string AreaEffectPath { get; init; }
  public required string StrikeEffectPath { get; init; }
  public required string SoulMissilePath { get; init; }

  public SoulRendSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var rend = new SoulRend(caster, Damage.GetValue(GetAbilityLevel(caster)))
    {
      SoulRange = SoulRange,
      SoulsLeft = MaximumSouls,
      StrikeEffectPath = StrikeEffectPath,
      SoulMissilePath = SoulMissilePath
    };
    effect.Create(AreaEffectPath, targetPoint.X, targetPoint.Y).Dispose();
    foreach (var unit in GlobalGroup.EnumUnitsInRange(targetPoint.X, targetPoint.Y, Radius))
    {
      if (rend.IsValidTarget(unit))
      {
        rend.Strike(unit);
      }
    }
  }
}

/// <summary>One cast of Soul Rend, tracking which enemies its souls have already struck.</summary>
public sealed class SoulRend
{
  private readonly unit _caster;
  private readonly float _damage;
  private readonly HashSet<unit> _struckBySoul = new();

  public required float SoulRange { get; init; }
  public required int SoulsLeft { get; set; }
  public required string StrikeEffectPath { get; init; }
  public required string SoulMissilePath { get; init; }

  public SoulRend(unit caster, float damage)
  {
    _caster = caster;
    _damage = damage;
  }

  public bool IsValidTarget(unit target) =>
    CastFilters.IsTargetEnemyAndAliveUnits(_caster, target) && target.UnitType != DummyCasterManager.UnitTypeId;

  public void Strike(unit target)
  {
    var x = target.X;
    var y = target.Y;
    effect.Create(StrikeEffectPath, target, "chest").Dispose();
    _caster.DealDamage(target, _damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    if (!target.Alive)
    {
      ReleaseSoul(x, y);
    }
  }

  private void ReleaseSoul(float x, float y)
  {
    if (SoulsLeft <= 0)
    {
      return;
    }

    unit? nearest = null;
    var nearestDistance = SoulRange * SoulRange;
    foreach (var unit in GlobalGroup.EnumUnitsInRange(x, y, SoulRange))
    {
      if (_struckBySoul.Contains(unit) || !IsValidTarget(unit))
      {
        continue;
      }

      var dx = unit.X - x;
      var dy = unit.Y - y;
      var distance = dx * dx + dy * dy;
      if (distance <= nearestDistance)
      {
        nearest = unit;
        nearestDistance = distance;
      }
    }

    if (nearest == null)
    {
      return;
    }

    SoulsLeft--;
    _struckBySoul.Add(nearest);
    MissileSystem.Add(new SoulRendMissile(_caster.Owner, x, y, nearest, this)
    {
      EffectString = SoulMissilePath
    });
  }
}

/// <summary>A released soul homing in on its next victim.</summary>
public sealed class SoulRendMissile : HomingMissile
{
  private readonly SoulRend _rend;
  private readonly unit _victim;

  public SoulRendMissile(player owner, float x, float y, unit target, SoulRend rend) : base(owner, x, y, target)
  {
    _rend = rend;
    _victim = target;
    Speed = 700;
    CasterLaunchZ = 50;
    TargetImpactZ = 50;
    Active = true;
  }

  public override void OnImpact()
  {
    if (_rend.IsValidTarget(_victim))
    {
      _rend.Strike(_victim);
    }
  }
}
