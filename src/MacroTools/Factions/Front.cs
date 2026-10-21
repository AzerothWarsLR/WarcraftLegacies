using System;

namespace MacroTools.Factions;

/// <summary>Two sides that fight each other, used to work out <see cref="TeamHandicaps"/>.</summary>
public sealed class Front
{
  public Front(Func<Faction, bool> attacks, Func<Faction, bool> defends)
  {
    Attacks = attacks;
    Defends = defends;
  }

  /// <summary>Whether a faction is on the attacking side.</summary>
  public Func<Faction, bool> Attacks { get; }

  /// <summary>Whether a faction is on the defending side.</summary>
  public Func<Faction, bool> Defends { get; }

  internal int StartingAttackers { get; set; }

  internal int StartingDefenders { get; set; }
}
