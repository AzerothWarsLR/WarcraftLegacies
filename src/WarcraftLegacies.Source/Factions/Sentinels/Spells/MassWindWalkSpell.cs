using System.Linq;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sentinels.Spells;

public sealed class MassWindWalkSpell : Spell
{
  public required int InvisibilityAbilityId { get; init; }

  public required float Radius { get; init; }

  public required float Duration { get; init; }

  public required float SpeedBonus { get; init; }

  public MassWindWalkSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var dummyCaster = DummyCasterManager.GetGlobalDummyCaster();
    var units = GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius)
      .Where(x => CastFilters.IsTargetAllyAndAlive(caster, x) && !x.IsUnitType(unittype.Structure))
      .ToList();

    foreach (var unit in units)
    {
      dummyCaster.CastUnit(caster, InvisibilityAbilityId, ORDER_INVISIBILITY, 1, unit, DummyCastOriginType.Target);
      SetUnitMoveSpeed(unit, GetUnitDefaultMoveSpeed(unit) * (1 + SpeedBonus));
    }

    var restoreTimer = timer.Create();
    restoreTimer.Start(Duration, false, () =>
    {
      foreach (var unit in units)
      {
        SetUnitMoveSpeed(unit, GetUnitDefaultMoveSpeed(unit));
      }

      restoreTimer.Dispose();
    });
  }
}
