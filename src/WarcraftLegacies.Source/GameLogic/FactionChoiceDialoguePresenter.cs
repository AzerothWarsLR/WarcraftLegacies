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
    public FactionChoiceDialoguePresenter(params string[] factionChoices) : base(factionChoices, "Pick your Faction")
    {
    }

    protected override void OnChoiceExpired(player pickingPlayer, string choice)
    {
      if (GetLocalPlayer() == pickingPlayer)
        DialogDisplay(GetLocalPlayer(), PickDialogue, false);

      if (pickingPlayer.GetFaction() == null && !HasChoiceBeenPicked)
        OnChoicePicked(pickingPlayer, choice);

      Dispose();
    }

    protected override void OnChoicePicked(player pickingPlayer, string choice)
    {
      HasChoiceBeenPicked = true;
      if (GetLocalPlayer() == pickingPlayer && FactionManager.GetFromName(choice)?.StartingCameraPosition != null)
      {
        var startingCameraPosition = FactionManager.GetFromName(choice)?.StartingCameraPosition;
        if (startingCameraPosition != null)
          SetCameraPosition(startingCameraPosition.X,
            startingCameraPosition.Y);
      }

      pickingPlayer.SetFaction(FactionManager.GetFromName(choice));
      var startingUnits = FactionManager.GetFromName(choice)?.StartingUnits;
      if (startingUnits != null)
        pickingPlayer.RescueGroup(startingUnits);

      foreach (var unpickedFaction in Choices.Where(x => x != choice))
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