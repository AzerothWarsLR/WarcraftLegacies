using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using System;
using WarcraftLegacies.Source.FactionMechanics.Warsong;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Quests.Warsong
{
    public sealed class QuestSubdueTauren : QuestData
    {
        private readonly List<unit> _rescueUnits;
        private readonly LegendaryHero _grom;
        private int PillageGoldReward { get; set; }
        private int PillageExperienceReward { get; set; }

        public QuestSubdueTauren(Rectangle rescueRect, LegendaryHero grom)
          : base(
            "Unyielding Bonds",
            "The Tauren of Thunder Bluff are noble warriors, but their allegiances are uncertain. Bring them into the fold or pillage their lands.",
            @"ReplaceableTextures\CommandButtons\BTNTauren.blp")
        {
            _grom = grom;
            AddObjective(new ObjectiveControlPoint(Constants.UNIT_N03M_THUNDERBLUFF));
            AddObjective(new ObjectiveSelfExists());

            _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
            // Set default values for the rewards as a fallback
            PillageGoldReward = 250;
            PillageExperienceReward = 800;
        }

        /// <inheritdoc/>
        public override string RewardFlavour =>
          "The strength of the warband grows.";

        /// <inheritdoc/>
        protected override string RewardDescription =>
          $"Control of Thunder Bluff and the ability to train {GetObjectName(UNIT_OKOD_KODO_BEAST_WARSONG)}s' from {GetObjectName(UNIT_O02Q_BEASTIARY_WARSONG_SPECIALIST)} or gain {PillageGoldReward} gold and {PillageExperienceReward} XP for Grom.";

        /// <inheritdoc/>
        protected override void OnComplete(Faction completingFaction)
        {
            if (completingFaction == null || completingFaction.Player == null)
            {
                Console.WriteLine("Invalid faction or player; cannot complete the quest.");
                return;
            }

            PresentPillageDialogs(completingFaction);
        }

        /// <summary>
        /// Handles the logic related to presenting Subdue or Pillage dialogs.
        /// </summary>
        private void PresentPillageDialogs(Faction completingFaction)
        {
          var gromUnit = _grom.Unit;
          if (gromUnit == null)
          {
            Console.WriteLine("Without Grom's leadership to guide the Horde, the Tauren remain scattered and their lands pillaged.");
            return;
          }

          new WarsongPillageDialogPresenter(
            gromUnit,
            new WarsongPillageChoice(
              PillageChoiceType.Pillage,
              "Pillage Thunder Bluff",
              Regions.ThunderBluff,
              250,       
              750      
            ),
            new WarsongPillageChoice(
              PillageChoiceType.Subdue,
              "Subdue the Tauren",
              Regions.ThunderBluff,
              0,
              0,
              Constants.UPGRADE_R00O_SUBDUE_THE_THUNDERBLUFF_TAUREN 
            )
          ).Run(completingFaction.Player);
        }


        /// <inheritdoc />
        protected override void OnFail(Faction completingFaction)
        {
            completingFaction.Player?.RescueGroup(_rescueUnits);
        }
    }
}