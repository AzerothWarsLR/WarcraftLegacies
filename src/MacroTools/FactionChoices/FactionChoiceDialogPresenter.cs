using System;
using System.Linq;
using MacroTools.Cheats;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Systems;
using MacroTools.UserInterface;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.FactionChoices;

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
    HasChoiceBeenPicked = true;

    var pickedFaction = choice.Faction;
    ReplaceStartingUnitsWithFactionEquivalents(pickingPlayer, choice, pickedFaction);

    pickingPlayer
      .RepositionCamera(choice.StartingArea.Center)
      .SetFaction(pickedFaction);

    FactionManager.Register(pickedFaction);
    CleanupUnpickedFactions(choice);
  }

  private static void ReplaceStartingUnitsWithFactionEquivalents(player pickingPlayer, FactionChoice choice,
    Faction pickedFaction)
  {
    var startingUnits = GlobalGroup
      .EnumUnitsInRect(choice.StartingArea)
      .Where(x => x.UnitType != FourCC("ngol"));

    foreach (var unit in startingUnits)
    {
      var replacedUnit = unit.ReplaceWithFactionEquivalent(pickedFaction);
      replacedUnit.SetOwner(pickingPlayer, true);

      if (replacedUnit != unit && CinematicMode.State == CinematicState.Active)
      {
        CinematicMode.AddPausedUnit(replacedUnit);
      }
    }
  }

  public static void ReplaceRegionUnitsWithFactionEquivalents(Rectangle region, Faction pickedFaction)
  {
    if (pickedFaction == null)
    {
      throw new ArgumentNullException(nameof(pickedFaction), "pickedFaction cannot be null.");
    }

    var unitsInRegion = GlobalGroup
      .EnumUnitsInRect(region)
      .Where(x => x.UnitType != FourCC("ngol"))
      .Where(x => x.Owner != player.NeutralAggressive);

    foreach (var unit in unitsInRegion)
    {
      var replacedUnit = unit.ReplaceWithFactionEquivalent(pickedFaction);

      if (replacedUnit != unit && CinematicMode.State == CinematicState.Active)
      {
        CinematicMode.AddPausedUnit(replacedUnit);
      }
    }
  }

  private void CleanupUnpickedFactions(FactionChoice choice)
  {
    var unpickedFactions = Choices.Where(x => x != choice).Select(x => x.Faction).ToList();
    foreach (var unpickedFaction in unpickedFactions)
    {
      var goldMinesToRemove = unpickedFaction.GoldMines.Except(choice.Faction.GoldMines);
      unpickedFaction.OnNotPicked();
      unpickedFaction.RemoveGoldMines(goldMinesToRemove);
    }
  }

  /// <inheritdoc />
  protected override FactionChoice GetDefaultChoice(player whichPlayer) => Choices.First();

  /// <inheritdoc />
  protected override bool IsChoiceActive(player whichPlayer, FactionChoice choice) =>
    !choice.RequiresCheats || TestMode.CheatCondition(whichPlayer);
}
