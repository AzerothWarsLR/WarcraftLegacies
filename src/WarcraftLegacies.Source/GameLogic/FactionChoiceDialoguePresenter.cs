using System.Linq;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.UserInterface;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
  public sealed class FactionChoiceDialoguePresenter : ChoiceDialoguePresenter
  {
    

  /// <summary>Initializes a new instance of the <see cref="FactionChoiceDialoguePresenter"/> class.</summary>
  public FactionChoiceDialoguePresenter(params string[] factionChoices) : base(factionChoices,"Pick your Faction")
  {
    ChoicePicked += PickFaction;

    ChoiceExpired += ExpireFactionPick;
  }

  private void ExpireFactionPick(object? sender, ChoiceDialoguePresenterEventArgs args)
  {
    if (GetLocalPlayer() == args.Player)
      DialogDisplay(GetLocalPlayer(), PickDialogue, false);

    if (args.Player.GetFaction() == null && !HasChoiceBeenPicked)
      PickFaction(sender,args);

    Dispose();
  }

  private void PickFaction(object? sender, ChoiceDialoguePresenterEventArgs args)
  {
    HasChoiceBeenPicked = true;
    if (GetLocalPlayer() == args.Player && FactionManager.GetFromName(args.Choice)?.StartingCameraPosition != null)
    {
      var startingCameraPosition = FactionManager.GetFromName(args.Choice)?.StartingCameraPosition;
      if (startingCameraPosition != null)
        SetCameraPosition(startingCameraPosition.X,
          startingCameraPosition.Y);
    }

    args.Player.SetFaction(FactionManager.GetFromName(args.Choice));
    var startingUnits = FactionManager.GetFromName(args.Choice)?.StartingUnits;
    if (startingUnits != null)
      args.Player.RescueGroup(startingUnits);

    foreach (var unpickedFaction in Choices.Where(x => x != args.Choice))
      RemoveFaction(unpickedFaction);
  }

  private static void RemoveFaction(string whichFaction)
  {
    var startingUnits = FactionManager.GetFromName(whichFaction)?.StartingUnits;
    if (startingUnits != null)
      foreach (var unit in startingUnits)
      {
        if (ControlPointManager.Instance.UnitIsControlPoint(unit))
          unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
        else
          unit.Remove();
      }

    FactionManager.GetFromName(whichFaction)?.RemoveGoldMines();
    FactionManager.GetFromName(whichFaction)?.Defeat();
  }
  }
}