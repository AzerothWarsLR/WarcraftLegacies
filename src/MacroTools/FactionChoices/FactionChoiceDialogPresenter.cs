using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.UserInterface;

using static War3Api.Common;

namespace MacroTools.FactionChoices
{
  /// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
  public sealed class FactionChoiceDialogPresenter : ChoiceDialogPresenter<Faction>
  {
    /// <summary>Initializes a new instance of the <see cref="FactionChoiceDialogPresenter"/> class.</summary>
    public FactionChoiceDialogPresenter(params Faction[] factions) : base(ConvertToFactionChoices(factions),
      "Pick your Faction")
    {
    }

        protected override void OnChoicePicked(player pickingPlayer, Choice<Faction> choice)
        {
            var pickedFaction = choice.Data;
            HasChoiceBeenPicked = true;
            var startingUnits = pickedFaction.StartingUnits;

            // Log the initial starting units
            Console.WriteLine("Initial starting units:");
            LogUnits(startingUnits);

            if (pickedFaction.FactionWorker != 0)
            {
                startingUnits = startingUnits.ReplaceWorkers(pickingPlayer, pickedFaction.FactionWorker);
            }
            if (pickedFaction.FactionTownHall != 0)
            {
                startingUnits = startingUnits.ReplaceTownHall(pickingPlayer, pickedFaction.FactionTownHall);
            }

            // Log the starting units after replacement
            Console.WriteLine("Starting units after replacement:");
            LogUnits(startingUnits);

            // Rescue control points explicitly after replacements
            foreach (var unit in startingUnits)
            {
                if (ControlPointManager.Instance.UnitIsControlPoint(unit))
                {
                    Console.WriteLine($"Rescuing control point unit ID: {GetUnitTypeId(unit)} to player ID: {GetPlayerId(pickingPlayer)}");
                    SetUnitOwner(unit, pickingPlayer, true);
                }
            }

            if (pickedFaction.StartingCameraPosition != null)
                pickingPlayer.RepositionCamera(pickedFaction.StartingCameraPosition);

            pickingPlayer.SetFaction(pickedFaction);
            FactionManager.Register(pickedFaction);
            pickingPlayer.RescueGroup(startingUnits);

            foreach (var unpickedFaction in Choices.Where(x => x.Data != choice.Data))
                RemoveFaction(unpickedFaction.Data, startingUnits);
        }


        // Helper method to log units
        private void LogUnits(List<unit> units)
        {
            foreach (var unit in units)
            {
                Console.WriteLine($"Unit ID: {GetUnitTypeId(unit)}, Position: ({GetUnitX(unit)}, {GetUnitY(unit)})");
            }
        }


    /// <inheritdoc />
    protected override Choice<Faction> GetDefaultChoice(player whichPlayer) => Choices.First();

        private static void RemoveFaction(Faction faction, List<unit> pickedFactionStartingUnits)
        {
            var startingUnits = faction.StartingUnits;
            foreach (var unit in startingUnits)
            {
                if (ControlPointManager.Instance.UnitIsControlPoint(unit))
                {
                    // Check if the control point is part of the picked faction's starting units
                    if (!pickedFactionStartingUnits.Contains(unit))
                    {
                        Console.WriteLine($"Rescuing control point unit ID: {GetUnitTypeId(unit)} to Neutral Aggressive");
                        unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
                    }
                    else
                    {
                        Console.WriteLine($"Skipping control point unit ID: {GetUnitTypeId(unit)} as it is part of the picked faction's starting units");
                    }
                }
                else
                {
                    unit.Remove();
                }
            }

            faction.OnNotPicked();
        }

    private static Choice<Faction>[] ConvertToFactionChoices(IEnumerable<Faction> factions)
    {
      return factions
        .Select(x => new Choice<Faction>(x, $"{x.Name} {x.LearningDifficulty.ToColoredText()}"))
        .ToArray();
    }
  }
}