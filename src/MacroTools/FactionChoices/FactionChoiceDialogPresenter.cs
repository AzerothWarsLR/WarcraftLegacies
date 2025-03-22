using System.Linq;
using MacroTools.Cheats;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Systems;
using MacroTools.UserInterface;
using MacroTools.Utils;
using static War3Api.Common;

namespace MacroTools.FactionChoices
{
    public sealed class FactionChoiceDialogPresenter : ChoiceDialogPresenter<FactionChoice>
    {
        private readonly bool _shouldReplaceUnits;

        /// <summary>
        /// Initializes a new instance of the <see cref="FactionChoiceDialogPresenter"/> class.
        /// </summary>
        /// <param name="factions">The faction choices available to the player.</param>
        /// <param name="shouldReplaceUnits">If false, skips replacing starting units.</param>
        public FactionChoiceDialogPresenter(bool shouldReplaceUnits, params FactionChoice[] factions) 
            : base(factions, "Pick your Faction")
        {
            _shouldReplaceUnits = shouldReplaceUnits;
        }

        protected override void OnChoicePicked(player pickingPlayer, FactionChoice choice)
        {
            HasChoiceBeenPicked = true;

            var pickedFaction = choice.Faction;

            // Always transfer unit ownership
            TransferUnitsToPlayer(pickingPlayer, choice);

            // Only perform replacement if the flag is enabled
            if (_shouldReplaceUnits)
            {
                ReplaceStartingUnitsWithFactionEquivalents(pickingPlayer, choice, pickedFaction);
            }

            pickingPlayer
                .RepositionCamera(choice.StartingArea.Center)
                .SetFaction(pickedFaction);

            FactionManager.Register(pickedFaction);
            CleanupUnpickedFactions(choice);
        }

        /// <summary>
        /// Transfers all starting units in the faction's area to the specified player.
        /// This happens regardless of the replacement flag.
        /// </summary>
        private static void TransferUnitsToPlayer(player pickingPlayer, FactionChoice choice)
        {
            var startingUnits = GlobalGroup
                .EnumUnitsInRect(choice.StartingArea)
                .Where(x => x.GetTypeId() != FourCC("ngol")); // Exclude gold mines

            foreach (var unit in startingUnits)
            {
                // Directly transfer ownership without replacing the unit if required
                unit.SetOwner(pickingPlayer);
            }
        }

        /// <summary>
        /// Replaces starting units with their faction equivalents and transfers ownership to the player.
        /// </summary>
        private static void ReplaceStartingUnitsWithFactionEquivalents(player pickingPlayer, FactionChoice choice, Faction pickedFaction)
        {
            var startingUnits = GlobalGroup
                .EnumUnitsInRect(choice.StartingArea)
                .Where(x => x.GetTypeId() != FourCC("ngol")); // Exclude gold mines

            foreach (var unit in startingUnits)
            {
                var replacedUnit = unit
                    .ReplaceWithFactionEquivalent(pickedFaction) // Replace unit if necessary
                    .SetOwner(pickingPlayer); // Transfer ownership after replacement

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
}