using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FelHorde.Spells;

/// <summary>Brings the caster owner's nearest dead units back to life, skipping heroes and units with a training limit.</summary>
public sealed class CallOfTheAncestorsSpell : Spell
{
  public required float Radius { get; init; }
  public required int MaximumUnits { get; init; }
  public required float LifeFraction { get; init; }
  public required string ReviveEffectPath { get; init; }

  public CallOfTheAncestorsSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var owner = caster.Owner;
    var faction = owner.GetPlayerData().Faction;
    var revived = 0;
    foreach (var corpse in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (revived >= MaximumUnits)
      {
        return;
      }

      if (!CanRevive(corpse, owner, faction))
      {
        continue;
      }

      var unitType = corpse.UnitType;
      var x = corpse.X;
      var y = corpse.Y;
      var facing = corpse.Facing;
      corpse.Dispose();
      var risen = unit.Create(owner, unitType, x, y, facing);
      risen.Life = risen.MaxLife * LifeFraction;
      effect.Create(ReviveEffectPath, x, y).Dispose();
      revived++;
    }
  }

  private static bool CanRevive(unit corpse, player owner, Faction? faction)
  {
    if (corpse.Alive || corpse.Owner != owner || corpse.IsUnitType(unittype.Hero) || corpse.IsUnitType(unittype.Structure) ||
        corpse.IsUnitType(unittype.Summoned) || corpse.IsUnitType(unittype.Mechanical))
    {
      return false;
    }

    if (faction == null)
    {
      return true;
    }

    var limit = faction.GetObjectLimit(corpse.UnitType);
    return limit == 0 || limit >= Faction.Unlimited;
  }
}
