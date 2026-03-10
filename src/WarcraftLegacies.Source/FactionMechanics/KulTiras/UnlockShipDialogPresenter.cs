
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
  private bool _choiceExecuted;

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
    _choiceExecuted = false;
  }

  protected override void OnChoicePicked(player pickingPlayer, UnlockShipChoice choice)
  {
    if (_choiceExecuted)
    {
      return;
    }

    _choiceExecuted = true;
    if (choice.Type == UnlockShipChoiceType.TeleportTroops)
    {
      TeleportTroops(_player);
    }
  }

  private static void TeleportTroops(player whichPlayer)
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRect(Rectangle.WorldBounds)
               .Where(x => x.Owner == whichPlayer))
    {
      if (!unit.IsUnitType(unittype.Structure) &&
          !unit.IsUnitType(unittype.Ancient) &&
          !unit.IsUnitType(unittype.Peon))
      {
        unit.SetPosition(6864, -17176);
      }
    }

    whichPlayer.RepositionCamera(6864, -17176);

    const int workerId = UNIT_H01E_DECKHAND_KULTIRAS_WORKER;

    unit.Create(whichPlayer, workerId, 6864 + 80, -17176, 0);
    unit.Create(whichPlayer, workerId, 6864 - 80, -17176, 0);
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
