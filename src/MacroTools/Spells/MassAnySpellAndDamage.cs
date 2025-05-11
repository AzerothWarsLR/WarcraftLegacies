using System;
using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
using War3Api;

namespace MacroTools.Spells
{
  public sealed class MassAnySpellAndDamage : Spell
  {
    public float DamageBase { get; init; }
    public float DamageLevel { get; init; }
    public int DurationBase { get; init; }
    public int DurationLevel { get; init; }
    public int DummyAbilityId { get; init; }
    public int DummyAbilityOrderId { get; init; }
    public float Radius { get; init; }
    public float Chance { get; init; } = 1.0f;
    public DummyCasterManager.CastFilter CastFilter { get; init; }
    public SpellTargetType TargetType { get; init; } = SpellTargetType.None;
    public DummyCastOriginType DummyCastOriginType { get; init; } = DummyCastOriginType.Target;

    public MassAnySpellAndDamage(int id) : base(id)
    {
      DummyAbilityId = 0;
      DummyAbilityOrderId = 0;
      CastFilter = (c, u) => false;
    }

    public override void OnCast(Common.unit caster, Common.unit target, Point targetPoint)
    {
      var center = TargetType == SpellTargetType.None
        ? new Point(GetUnitX(caster), GetUnitY(caster))
        : targetPoint;

      foreach (var unit in GetUnitsInRadius(center, Radius, CastFilter))
      {
        if (!IsUnitEnemy(unit, GetOwningPlayer(caster)) || !UnitAlive(unit) || GetRandomReal(0, 1) > Chance)
          continue;

        // Deal damage
        var damage = DamageBase + DamageLevel * GetAbilityLevel(caster);
        UnitDamageTarget(caster, unit, damage, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC,
          WEAPON_TYPE_WHOKNOWS);

        // Cast dummy ability on the unit for additional effects
        if (DummyAbilityId != 0 && DurationBase > 0)
        {
          var duration = DurationBase + DurationLevel * GetAbilityLevel(caster);

          // Debug: Log the dummy cast
          Console.WriteLine(
            $"Casting DummyAbilityId ({DummyAbilityId}) with OrderId ({DummyAbilityOrderId}) on unit: {GetUnitName(unit)}");

          DummyCasterManager.GetGlobalDummyCaster()
            .CastUnit(caster, DummyAbilityId, DummyAbilityOrderId, duration, unit, DummyCastOriginType);
        }
        else
        {
          // Debug: Log missing configuration
          Console.WriteLine("Skipping dummy cast due to missing DummyAbilityId or invalid DurationBase.");
        }
      }
    }

    private IEnumerable<Common.unit> GetUnitsInRadius(Point center, float radius,
      DummyCasterManager.CastFilter castFilter)
    {
      var group = CreateGroup();
      GroupEnumUnitsInRange(group, center.X, center.Y, radius, null);
      var units = new List<Common.unit>();
      Common.unit u;

      while ((u = FirstOfGroup(group)) != null)
      {
        GroupRemoveUnit(group, u);
        if (castFilter(null, u))
        {
          units.Add(u);
        }
      }

      DestroyGroup(group);
      return units;
    }
  }
}
