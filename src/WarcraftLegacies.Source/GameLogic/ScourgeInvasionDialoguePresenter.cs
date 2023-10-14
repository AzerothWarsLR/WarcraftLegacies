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
    
    public ScourgeInvasionDialoguePresenter(Dictionary<string, Rectangle?> locationsByChoice) : base(locationsByChoice.Keys.ToArray(),"Pick Invasion Location")
    {
      _locationsByChoice = locationsByChoice;
      ChoicePicked += PickLocation;

      ChoiceExpired += ExpireLocationPick;
    }

    private void PickLocation(object? sender, ChoiceDialoguePresenterEventArgs args)
    {
      HasChoiceBeenPicked = true;
      if (args.Choice == "No Invasion" || _locationsByChoice[args.Choice] == null)
        return;
      var invasionLocation = _locationsByChoice[args.Choice];
      foreach (var unit in CreateGroup().EnumUnitsInRect(Regions.Northrend_Ambiance).EmptyToList().Where(x => x.OwningPlayer() == args.Player))
      {
        if (IsUnitType(unit, UNIT_TYPE_STRUCTURE) || IsUnitType(unit, UNIT_TYPE_ANCIENT) || IsUnitType(unit, UNIT_TYPE_PEON)) continue;
        if (invasionLocation != null)
          SetUnitPosition(unit, invasionLocation.Center.X, invasionLocation.Center.Y);
      }

      if (GetLocalPlayer() != args.Player) return;
      if (invasionLocation != null)
        SetCameraPosition(invasionLocation.Center.X, invasionLocation.Center.Y);
    }
    
    private void ExpireLocationPick(object? sender, ChoiceDialoguePresenterEventArgs args)
    {
      if (GetLocalPlayer() == args.Player)
        DialogDisplay(GetLocalPlayer(), PickDialogue, false);
      
      if (!HasChoiceBeenPicked)
        PickLocation(sender,new ChoiceDialoguePresenterEventArgs(args.Player,"No Invasion"));
      
      Dispose();
    }
  }
}