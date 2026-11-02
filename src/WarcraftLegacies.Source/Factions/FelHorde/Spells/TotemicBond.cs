using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FelHorde.Spells;

/// <summary>Keeps one totem per caster and makes each totem stronger for every other friendly totem near it.</summary>
public sealed class TotemicBond
{
  public required float Radius { get; init; }
  public required int MaximumBonds { get; init; }
  public required float BonusPerBond { get; init; }
  public required Dictionary<int, int> AuraAbilityByTotemType { get; init; }
  public required HashSet<int> DamageTotemTypes { get; init; }
  public required int ExtraBondsResearchId { get; init; }
  public required int ExtraBonds { get; init; }

  private readonly Dictionary<unit, unit> _totemByCaster = new();
  private readonly List<unit> _totems = new();
  private readonly Dictionary<unit, int> _baseDamage = new();
  private timer? _refresh;

  /// <summary>Places <paramref name="totem"/> for <paramref name="caster"/>, destroying the caster's previous totem.</summary>
  public void Place(unit caster, unit totem, float duration)
  {
    if (_totemByCaster.TryGetValue(caster, out var previous) && previous.Alive)
    {
      previous.IsInvulnerable = false;
      previous.Kill();
    }

    _totemByCaster[caster] = totem;
    _totems.Add(totem);
    if (DamageTotemTypes.Contains(totem.UnitType))
    {
      _baseDamage[totem] = BlzGetUnitBaseDamage(totem, 0);
    }

    totem.ApplyTimedLife(0, duration);
    if (_refresh == null)
    {
      _refresh = timer.Create();
      _refresh.Start(1, true, Refresh);
    }

    Refresh();
  }

  private void Refresh()
  {
    for (var i = _totems.Count - 1; i >= 0; i--)
    {
      if (!_totems[i].Alive)
      {
        _baseDamage.Remove(_totems[i]);
        _totems.RemoveAt(i);
      }
    }

    foreach (var totem in _totems)
    {
      var bonds = CountBonds(totem);
      if (AuraAbilityByTotemType.TryGetValue(totem.UnitType, out var auraId))
      {
        totem.SetAbilityLevel(auraId, bonds + 1);
      }

      if (_baseDamage.TryGetValue(totem, out var baseDamage))
      {
        BlzSetUnitBaseDamage(totem, R2I(baseDamage * (1 + BonusPerBond * bonds)), 0);
      }
    }
  }

  private int CountBonds(unit totem)
  {
    var bonds = 0;
    var maximum = MaximumBonds;
    if (totem.Owner.GetTechResearched(ExtraBondsResearchId, false) > 0)
    {
      maximum += ExtraBonds;
    }

    foreach (var other in _totems)
    {
      if (other == totem || other.Owner != totem.Owner ||
          MathEx.GetDistanceBetweenPoints(new Point(totem.X, totem.Y), new Point(other.X, other.Y)) > Radius)
      {
        continue;
      }

      bonds++;
      if (bonds >= maximum)
      {
        return bonds;
      }
    }

    return bonds;
  }
}
