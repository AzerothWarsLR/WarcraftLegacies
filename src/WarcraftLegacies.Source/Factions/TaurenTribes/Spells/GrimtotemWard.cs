using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

public sealed class GrimtotemWard : Spell
{
  public required int WardTypeId { get; init; }

  public required float Duration { get; init; }

  public required List<int> AuraAbilityIds { get; init; }

  public string SummonEffect { get; init; } = @"Abilities\Spells\Orc\FeralSpirit\feralspiritdone.mdl";

  public GrimtotemWard(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var ward = unit.Create(caster.Owner, WardTypeId, targetPoint.X, targetPoint.Y, 270);
    foreach (var auraAbilityId in AuraAbilityIds)
    {
      ward.SetAbilityLevel(auraAbilityId, level);
    }

    ward.SetTimedLife(Duration);
    effect.Create(SummonEffect, targetPoint.X, targetPoint.Y).Dispose();
  }
}
