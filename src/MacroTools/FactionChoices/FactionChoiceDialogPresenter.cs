using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Systems;
using MacroTools.UserInterface;
using MacroTools.Utils;
using static War3Api.Common;

namespace MacroTools.FactionChoices
{
  /// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
  public sealed class FactionChoiceDialogPresenter : ChoiceDialogPresenter<FactionChoice>
  {
    /// <summary>Initializes a new instance of the <see cref="FactionChoiceDialogPresenter"/> class.</summary>
    public FactionChoiceDialogPresenter(params FactionChoice[] factions) : base(factions,
      "Pick your Faction")
    {
    }

    protected override void OnChoicePicked(player pickingPlayer, FactionChoice choice)
    {
      var pickedFaction = choice.Faction;
      HasChoiceBeenPicked = true;

      var startingUnits = GlobalGroup
        .EnumUnitsInRect(choice.StartingArea)
        .Where(x => x.GetTypeId() != FourCC("ngol"));

      foreach (var unit in startingUnits)
      {
        var replacedUnit = unit
          .ReplaceWithFactionEquivalent(pickedFaction)
          .SetOwner(pickingPlayer);

        //If the unit was replaced, put back its paused state during game intro.
        if (replacedUnit != unit && GameTime.GetTurn() == 0) 
          replacedUnit.PauseEx(true);
      }

      pickingPlayer
        .RepositionCamera(choice.StartingArea.Center)
        .SetFaction(pickedFaction);

      FactionManager.Register(pickedFaction);

      var unpickedFactions = Choices.Where(x => x != choice).ToList();
      foreach (var unpickedFaction in unpickedFactions)
        unpickedFaction.Faction.OnNotPicked();
    }

    /// <inheritdoc />
    protected override FactionChoice GetDefaultChoice(player whichPlayer) => Choices.First();
  }
}