using System.Linq;
using MacroTools.Extensions;
using MacroTools.UserInterface;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.FactionMechanics.Warsong
{
    // Defines a dialog presenter for Warsong's pillage and subdue mechanics
    public sealed class WarsongPillageDialogPresenter : ChoiceDialogPresenter<WarsongPillageChoice>
    {
        private readonly unit _grom;

        public WarsongPillageDialogPresenter(unit grom, params WarsongPillageChoice[] choices)
            : base(choices, "Choose their fate.")
        {
            _grom = grom;
        }

        protected override void OnChoicePicked(player pickingPlayer, WarsongPillageChoice choice)
        {
            HasChoiceBeenPicked = true;

            // Handle cases where Location is null
            if (choice.Location == null)
                return;

            // Handle "Subdue" choice type
            if (choice.Type == PillageChoiceType.Subdue)
            {
                pickingPlayer.RescueGroup(choice.Location.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures));

                if (choice.ResearchReward != 0)
                {
                    SetPlayerTechResearched(pickingPlayer, choice.ResearchReward, 1); // Apply Subdue research reward
                }
            }
            // Handle "Pillage" choice type
            else if (choice.Type == PillageChoiceType.Pillage)
            {
                choice.Location.CleanupNeutralPassiveUnits();

                pickingPlayer.AddGold(choice.GoldReward);

                _grom?.AddExperience(choice.ExperienceReward);

                // Apply health adjustment to neutral structures
                foreach (var unit in GlobalGroup.EnumUnitsInRect(choice.Location)
                           .Where(unit => IsUnitType(unit, UNIT_TYPE_STRUCTURE) &&
                                          (unit.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE) ||
                                           unit.OwningPlayer() == Player(PLAYER_NEUTRAL_PASSIVE))))
                {
                    unit.SetLifePercent(15);
                }
            }

            // Focus the camera on the location
            pickingPlayer.RepositionCamera(choice.Location.Center);
        }

        protected override WarsongPillageChoice GetDefaultChoice(player whichPlayer)
        {
            return Choices.First(); // Default to the first choice
        }

        protected override bool IsChoiceActive(player whichPlayer, WarsongPillageChoice choice)
        {
            return true; // All choices are active by default
        }
    }
}