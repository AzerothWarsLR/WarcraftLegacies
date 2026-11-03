using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>Makes nearby allies attack and move faster for a while.</summary>
public sealed class KingsCommandSpell : Spell
{
  public required float Radius { get; init; }
  public required int BuffAbilityId { get; init; }
  public required string CastEffectPath { get; init; }

  public KingsCommandSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    effect.Create(CastEffectPath, caster.X, caster.Y).Dispose();
    foreach (var ally in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!ally.Alive || !ally.IsAllyTo(caster.Owner) || ally.IsUnitType(unittype.Structure) ||
          ally.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      DummyCasterManager.GetGlobalDummyCaster()
        .CastUnit(caster, BuffAbilityId, ORDER_BLOODLUST, level, ally, DummyCastOriginType.Target);
    }
  }
}
