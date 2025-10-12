using System.Linq;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class MassAnySpell : Spell
{
  public int DummyAbilityId { get; init; }

  public int DummyAbilityOrderId { get; init; }

  public float Radius { get; init; }

  public required DummyCasterManager.CastFilter CastFilter { get; init; }

  public SpellTargetType TargetType { get; init; } = SpellTargetType.None;

  public DummyCasterType DummyCasterType { get; init; } = DummyCasterType.Global;

  public float Chance { get; init; } = 1.0f;

  public DummyCastOriginType DummyCastOriginType { get; init; } = DummyCastOriginType.Target;

  public float DamageBase { get; init; } = 0f;
  public float DamageLevel { get; init; } = 0f;
  public bool EnableDamage { get; init; } = false;

  public MassAnySpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var center = TargetType == SpellTargetType.None ? new Point(caster.X, caster.Y) : targetPoint;
    var units = GlobalGroup.EnumUnitsInRange(center.X, center.Y, Radius).Where(u => CastFilter(caster, u));

    var filteredUnits = units.Where(u => GetRandomReal(0, 1) <= Chance).ToList();

    foreach (var unit in filteredUnits)
    {
      if (EnableDamage && unit.IsEnemyTo(caster.Owner))
      {
        var damage = DamageBase + DamageLevel * GetAbilityLevel(caster);
        caster.DealDamage(unit, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      }
    }

    if (DummyCasterType == DummyCasterType.Global)
    {
      DummyCasterManager.GetGlobalDummyCaster()
        .CastOnUnitsInCircle(
          caster,
          DummyAbilityId,
          DummyAbilityOrderId,
          GetAbilityLevel(caster),
          center,
          Radius,
          (c, t) => filteredUnits.Contains(t),
          DummyCastOriginType
        );
    }
    else if (DummyCasterType == DummyCasterType.AbilitySpecific)
    {
      DummyCasterManager.GetAbilitySpecificDummyCaster(DummyAbilityId, DummyAbilityOrderId)
        .CastOnUnitsInCircle(
          caster,
          GetAbilityLevel(caster),
          center,
          Radius,
          (c, t) => filteredUnits.Contains(t),
          DummyCastOriginType
        );
    }
  }
}
