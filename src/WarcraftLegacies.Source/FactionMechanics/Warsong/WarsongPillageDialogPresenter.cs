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

            if (choice.Location == null)
                return;

            if (choice.Type == PillageChoiceType.Subdue)
            {
                pickingPlayer.RescueGroup(choice.Location.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures));
            }
            else if (choice.Type == PillageChoiceType.Pillage)
            {
                // Clean up all neutral units in the area (removes units)
                choice.Location.CleanupNeutralPassiveUnits();

                // Reward the player with gold
                pickingPlayer.AddGold(choice.GoldReward);

                // Grant experience to Grom
                _grom?.AddExperience(choice.ExperienceReward);

                // Apply health adjustment to neutral structures in the region
                foreach (var unit in GlobalGroup.EnumUnitsInRect(choice.Location)
                             .Where(unit => IsUnitType(unit, UNIT_TYPE_STRUCTURE) &&
                              (unit.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE) ||
                               unit.OwningPlayer() == Player(PLAYER_NEUTRAL_PASSIVE))))
                {
                    unit.SetLifePercent(15);
                }
            }

            pickingPlayer.RepositionCamera(choice.Location.Center);
        }

        protected override WarsongPillageChoice GetDefaultChoice(player whichPlayer) => Choices.First();

        protected override bool IsChoiceActive(player whichPlayer, WarsongPillageChoice choice) => true;
    }
}