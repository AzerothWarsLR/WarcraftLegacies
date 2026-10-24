using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Forsaken.Spells;

/// <summary>Gives the unit the same colour whichever player owns it, like a campaign hero's.</summary>
public sealed class FixedUnitColor : UnitTrait, IEffectOnCreated
{
  public required playercolor Color { get; init; }

  /// <inheritdoc />
  public void OnCreated(unit createdUnit) => SetUnitColor(createdUnit, Color);
}
