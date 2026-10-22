using System;
using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Spells;

/// <summary>Damages every nearby enemy, splitting a capped total between them when there are many.</summary>
public sealed class KeeningWailSpell : Spell
{
  public required float Damage { get; init; }
  public required float MaxDamage { get; init; }
  public required float Radius { get; init; }

  public KeeningWailSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var victims = new List<unit>();
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (CastFilters.IsTargetEnemyAndAliveUnits(caster, nearby))
      {
        victims.Add(nearby);
      }
    }

    if (victims.Count == 0)
    {
      return;
    }

    var damage = Math.Min(Damage, MaxDamage / victims.Count);
    foreach (var victim in victims)
    {
      caster.DealDamage(victim, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    }
  }
}
