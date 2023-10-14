using System.Linq;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.UserInterface;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
  public sealed class FactionChoiceDialoguePresenter : ChoiceDialoguePresenter<Faction>
  {
    /// <summary>Initializes a new instance of the <see cref="FactionChoiceDialoguePresenter"/> class.</summary>
    public FactionChoiceDialoguePresenter(params Choice<Faction>[] factionChoices) : base(factionChoices, "Pick your Faction")
    {
    }

    protected override void OnChoiceExpired(player pickingPlayer, Choice<Faction> choice)
    {
      if (GetLocalPlayer() == pickingPlayer)
        DialogDisplay(GetLocalPlayer(), PickDialogue, false);

      if (pickingPlayer.GetFaction() == null && !HasChoiceBeenPicked)
        OnChoicePicked(pickingPlayer, choice);

      Dispose();
    }

    protected override void OnChoicePicked(player pickingPlayer, Choice<Faction> choice)
    {
      var pickedFaction = choice.Data;
      HasChoiceBeenPicked = true;
      if (GetLocalPlayer() == pickingPlayer && pickedFaction.StartingCameraPosition != null)
      {
        var startingCameraPosition = pickedFaction.StartingCameraPosition;
        if (startingCameraPosition != null)
          SetCameraPosition(startingCameraPosition.X,
            startingCameraPosition.Y);
      }

      pickingPlayer.SetFaction(pickedFaction);
      var startingUnits = pickedFaction.StartingUnits;
      pickingPlayer.RescueGroup(startingUnits);

      foreach (var unpickedFaction in Choices.Where(x => x.Data != choice.Data))
        RemoveFaction(unpickedFaction.Data);
    }

    private static void RemoveFaction(Faction faction)
    {
      var startingUnits = faction.StartingUnits;
      foreach (var unit in startingUnits)
        if (ControlPointManager.Instance.UnitIsControlPoint(unit))
          unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
        else
          unit.Remove();

      faction.RemoveGoldMines();
      faction.Defeat();
    }
  }
}