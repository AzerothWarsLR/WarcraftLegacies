using MacroTools.UnitTraits;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Gilneas;

/// <summary>Once Gilneas forms in Roleplay mode, Greymane's Gate gains extra armour, kept as it opens, closes and is rebuilt.</summary>
public sealed class GreymaneFortification : UnitTrait, IEffectOnCreated, IEffectOnUpgrade
{
  private const int FortificationId = ABILITY_A18D_GREYMANE_FORTIFICATION_GILNEAS_GREYMANE_S_GATE;
  private const float GateX = 6912;
  private const float GateY = 2688;
  private const float GateSearchRadius = 400;

  private static readonly int[] _gateTypes =
  {
    UNIT_H02M_GREYMANE_S_GATE_GATE_OPEN,
    UNIT_H02K_GREYMANE_S_GATE_GATE_CLOSED,
    UNIT_H02L_GREYMANE_S_GATE_GATE_DEAD
  };

  private static bool _active;

  /// <summary>The unit types that make up Greymane's Gate.</summary>
  public static int[] GateTypes => _gateTypes;

  /// <summary>Fortifies Greymane's Gate from now on.</summary>
  public static void Activate()
  {
    _active = true;
    foreach (var whichUnit in GlobalGroup.EnumUnitsInRange(GateX, GateY, GateSearchRadius))
    {
      if (IsGate(whichUnit))
      {
        Fortify(whichUnit);
      }
    }
  }

  /// <inheritdoc />
  public void OnCreated(unit createdUnit)
  {
    if (_active)
    {
      Fortify(createdUnit);
    }
  }

  /// <inheritdoc />
  public void OnUpgrade()
  {
    if (_active)
    {
      Fortify(@event.Unit);
    }
  }

  private static bool IsGate(unit whichUnit)
  {
    foreach (var gateType in _gateTypes)
    {
      if (whichUnit.UnitType == gateType)
      {
        return true;
      }
    }

    return false;
  }

  private static void Fortify(unit whichUnit)
  {
    if (whichUnit.GetAbilityLevel(FortificationId) > 0)
    {
      return;
    }

    whichUnit.AddAbility(FortificationId);
    UnitMakeAbilityPermanent(whichUnit, true, FortificationId);
  }
}
