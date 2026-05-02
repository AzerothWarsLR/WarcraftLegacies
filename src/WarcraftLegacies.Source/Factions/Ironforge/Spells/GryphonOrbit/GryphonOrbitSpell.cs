using System.Collections.Generic;
using MacroTools.Spells;
using WCSharp.Events;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells.GryphonOrbit;

public sealed class GryphonOrbitSpell : Spell
{
  public int GryphonTypeId { get; init; }
  public LeveledAbilityField<float> Damage { get; init; } = new();
  public LeveledAbilityField<float> Duration { get; init; } = new();
  public float CollisionRadius { get; init; }
  public float OrbitRadius { get; init; }
  public float OrbitalPeriod { get; init; }
  public int BaseProjectileCount { get; init; }

  private readonly Dictionary<unit, List<GryphonOrbitMissile>> _activeMissiles = new();
  private readonly Dictionary<unit, List<BorrowedGryphon>> _borrowed = new();
  private readonly Dictionary<unit, float> _durationRemaining = new();

  public GryphonOrbitSpell(int id) : base(id)
  {
    PeriodicEvents.AddPeriodicEvent(OnPeriodic);
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = caster.GetAbilityLevel(Id);
    var duration = Duration.Base + Duration.PerLevel * level;
    var damage = Damage.Base + Damage.PerLevel * level;

    var missiles = new List<GryphonOrbitMissile>();
    var borrowed = new List<BorrowedGryphon>();

    for (var i = 0; i < BaseProjectileCount; i++)
    {
      var m = CreateMissile(caster, damage, duration);
      m.OrbitalAngle = (360f / BaseProjectileCount) * i;
      missiles.Add(m);
      MissileSystem.Add(m);
    }

    var group = Common.CreateGroup();
    Common.GroupEnumUnitsInRange(group, caster.X, caster.Y, 600, null);

    var u = Common.FirstOfGroup(group);
    while (u != null)
    {
      if (u.UnitType == GryphonTypeId && u.Owner == caster.Owner && u.Alive)
      {
        borrowed.Add(new BorrowedGryphon(u));

        Common.ShowUnit(u, false);
        u.SetPausedEx(true);
        u.IsInvulnerable = true;
        Common.SetUnitPathing(u, false);
        Common.SetUnitVertexColor(u, 255, 255, 255, 0);
        Common.SetUnitScale(u, 0.01f, 0.01f, 0.01f);

        var m = CreateMissile(caster, damage, duration);
        m.OrbitalAngle = Common.GetRandomReal(0, 360);
        missiles.Add(m);
        MissileSystem.Add(m);
      }

      Common.GroupRemoveUnit(group, u);
      u = Common.FirstOfGroup(group);
    }

    Common.DestroyGroup(group);

    _activeMissiles[caster] = missiles;
    _borrowed[caster] = borrowed;
    _durationRemaining[caster] = duration;
  }

  public override void OnStop(unit caster)
  {
  }

  private GryphonOrbitMissile CreateMissile(unit caster, float damage, float duration)
  {
    return new GryphonOrbitMissile(caster, caster)
    {
      CollisionRadius = CollisionRadius,
      Range = OrbitRadius,
      OrbitalPeriod = OrbitalPeriod,
      Damage = damage,
      Duration = duration
    };
  }

  private bool OnPeriodic()
  {
    var toEnd = new List<unit>();
    var casters = new List<unit>(_durationRemaining.Keys);

    foreach (var caster in casters)
    {
      _durationRemaining[caster] -= PeriodicEvents.SYSTEM_INTERVAL;

      if (_durationRemaining[caster] <= 0)
      {
        toEnd.Add(caster);
      }
    }

    foreach (var caster in toEnd)
    {
      EndSpell(caster);
      _durationRemaining.Remove(caster);
    }

    return true;
  }

  private void EndSpell(unit caster)
  {
    if (_activeMissiles.TryGetValue(caster, out var missiles))
    {
      foreach (var m in missiles)
      {
        m.Active = false;
      }

      _activeMissiles.Remove(caster);
    }

    if (_borrowed.TryGetValue(caster, out var borrowed))
    {
      if (borrowed.Count > 0)
      {
        var angleStep = 360f / borrowed.Count;
        float angle = 0;

        foreach (var b in borrowed)
        {
          var x = caster.X + Common.Cos(angle * 0.0174533f) * 150f;
          var y = caster.Y + Common.Sin(angle * 0.0174533f) * 150f;

          b.Unit.X = x;
          b.Unit.Y = y;
          b.Unit.Facing = angle;

          Common.ShowUnit(b.Unit, true);
          b.Unit.SetPausedEx(false);
          b.Unit.IsInvulnerable = false;
          Common.SetUnitPathing(b.Unit, true);
          Common.SetUnitVertexColor(b.Unit, 255, 255, 255, 255);
          Common.SetUnitScale(b.Unit, 1f, 1f, 1f);
          Common.IssueImmediateOrder(b.Unit, "stop");

          angle += angleStep;
        }
      }

      _borrowed.Remove(caster);
    }
  }
}
