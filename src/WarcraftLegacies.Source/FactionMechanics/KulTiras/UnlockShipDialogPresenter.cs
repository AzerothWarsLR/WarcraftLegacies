using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.UserInterface;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.FactionMechanics.KulTiras;

public sealed class UnlockShipDialogPresenter : ChoiceDialogPresenter<UnlockShipChoice>
{
  private readonly player _player;
  private readonly List<unit> _rescueUnits;
  private readonly unit _proudmooreCapitalShip;

  public UnlockShipDialogPresenter(player player, List<unit> rescueUnits, unit proudmooreCapitalShip)
    : base(
      new[]
      {
        new UnlockShipChoice("Sail to Westfall (Recommended)", UnlockShipChoiceType.TeleportTroops),
        new UnlockShipChoice("Do Nothing", UnlockShipChoiceType.DoNothing)
      },
      "Choose What To Do With Your Troops")
  {
    _player = player;
    _rescueUnits = rescueUnits;
    _proudmooreCapitalShip = proudmooreCapitalShip;
  }

  protected override void OnChoicePicked(player pickingPlayer, UnlockShipChoice choice)
  {
    if (choice.Type == UnlockShipChoiceType.TeleportTroops)
    {
      TeleportTroops(_player, _rescueUnits, _proudmooreCapitalShip);
    }
  }

  private static void TeleportTroops(player whichPlayer, List<unit> rescueUnits, unit proudmooreCapitalShip)
  {
    // Teleport all troops
    foreach (var unit in GlobalGroup.EnumUnitsInRect(Rectangle.WorldBounds).Where(x => x.OwningPlayer() == whichPlayer))
    {
      if (!IsUnitType(unit, UNIT_TYPE_STRUCTURE) && !IsUnitType(unit, UNIT_TYPE_ANCIENT) && !IsUnitType(unit, UNIT_TYPE_PEON))
        SetUnitPosition(unit, 6864, -17176);
    }
    
    whichPlayer.RescueGroup(rescueUnits);
    proudmooreCapitalShip.Rescue(whichPlayer);
    proudmooreCapitalShip.PauseEx(false);
    
    whichPlayer.RepositionCamera(6864, -17176);
  }

  protected override UnlockShipChoice GetDefaultChoice(player whichPlayer)
  {
    return Choices.FirstOrDefault();
  }

  protected override bool IsChoiceActive(player whichPlayer, UnlockShipChoice choice)
  {
    return true;
  }
}