using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.PassiveAbilitySystem;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;
using WarcraftLegacies.Source.Rocks;

namespace WarcraftLegacies.Source.Quests.Cthun
{
    public sealed class QuestTitanJailors : QuestData
    {
        private readonly AllLegendSetup _allLegendSetup;
        private readonly List<unit> _rescueUnits;
        private readonly List<RockGroup> _rockGroups; // Track the rocks

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestTitanJailors"/> class.
        /// </summary>
        public QuestTitanJailors(AllLegendSetup allLegendSetup, Rectangle rescueRect)
            : base("Titan Jailors",
                  "C'thun is currently watched by a Titan Construct. We must rid the temple of hostiles and destroy the Titan to free our god.",
                  @"ReplaceableTextures\CommandButtons\BTNArmorGolem.blp")
        {
            AddObjective(new ObjectiveControlPoint(UNIT_NLSE_TEMPLE_OF_AHN_QIRAJ, 1500));
            AddObjective(new ObjectiveExpire(660, Title));
            AddObjective(new ObjectiveSelfExists());

            _rockGroups = new List<RockGroup>(); // Contains rock groups associated with the quest
            _allLegendSetup = allLegendSetup;
            _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
            RegisterRockGroups();
        }

        /// <summary>
        /// Registers the RockGroups associated with this quest.
        /// </summary>
        private void RegisterRockGroups()
        {
            _rockGroups.Add(new RockGroup(Regions.AQ_Blockers, FourCC("LTrc"), 0));
            foreach (var rockGroup in _rockGroups)
            {
                RockSystem.Register(rockGroup);
            }
        }

        /// <inheritdoc />
        protected override void OnFail(Faction completingFaction)
        {
            CleanupRocks();

            var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
                ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
                : completingFaction.Player;

            rescuer.RescueGroup(_rescueUnits);
        }

        /// <inheritdoc />
        protected override void OnComplete(Faction completingFaction)
        {
            CleanupRocks();
            completingFaction.Player.RescueGroup(_rescueUnits);
            var cthun = _allLegendSetup.Ahnqiraj.Cthun.Unit;
            if (cthun != null)
            {
                PassiveAbilityManager.ForceOnCreated(cthun);
            }
        }

        /// <summary>
        /// Removes all rocks associated with this quest.
        /// </summary>
        private void CleanupRocks()
        {
            foreach (var rockGroup in _rockGroups)
            {
                RockSystem.Remove(rockGroup);
            }
        }
    }
}