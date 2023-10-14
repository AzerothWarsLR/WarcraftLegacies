using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.UserInterface;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  public sealed class ScourgeInvasionDialoguePresenter : ChoiceDialoguePresenter
  {
    private readonly Dictionary<string, Rectangle?> _locationsByChoice;

    public ScourgeInvasionDialoguePresenter(Dictionary<string, Rectangle?> locationsByChoice) : base(
      locationsByChoice.Keys.ToArray(), "Pick Invasion Location")
    {
      _locationsByChoice = locationsByChoice;
    }

    protected override void OnChoicePicked(player pickingPlayer, string choice)
    {
      HasChoiceBeenPicked = true;
      if (choice == "No Invasion" || _locationsByChoice[choice] == null)
        return;
      var invasionLocation = _locationsByChoice[choice];
      foreach (var unit in CreateGroup().EnumUnitsInRect(Regions.Northrend_Ambiance).EmptyToList()
                 .Where(x => x.OwningPlayer() == pickingPlayer))
      {
        if (IsUnitType(unit, UNIT_TYPE_STRUCTURE) || IsUnitType(unit, UNIT_TYPE_ANCIENT) ||
            IsUnitType(unit, UNIT_TYPE_PEON)) 
          continue;
        
        if (invasionLocation != null)
          SetUnitPosition(unit, invasionLocation.Center.X, invasionLocation.Center.Y);
      }

      if (GetLocalPlayer() != pickingPlayer) 
        return;
      
      if (invasionLocation != null)
        SetCameraPosition(invasionLocation.Center.X, invasionLocation.Center.Y);
    }

    protected override void OnChoiceExpired(player pickingPlayer, string choice)
    {
      if (GetLocalPlayer() == pickingPlayer)
        DialogDisplay(GetLocalPlayer(), PickDialogue, false);

      if (!HasChoiceBeenPicked)
        OnChoicePicked(pickingPlayer, choice);

      Dispose();
    }
  }
}