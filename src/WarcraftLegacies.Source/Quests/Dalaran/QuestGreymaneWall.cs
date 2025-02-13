using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Dalaran
{
    /// <summary>
    /// Dalaran unlocks and takes control of Gilneas Gate.
    /// </summary>
    public sealed class QuestGreymaneWall : QuestData
    {
        private readonly List<unit> _rescueUnits;
        private readonly ObjectiveAnyUnitInRect _enterGilneasGateRegion;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestGreymaneWall"/> class.
        /// </summary>
        /// <param name="prerequisite">This quests must be completed before this one can be completed.</param>
        /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
        public QuestGreymaneWall(QuestData prerequisite, Rectangle rescueRect) : base("The Greymane Wall",
          "The Gilneans, fearful of a potential invasion from the frozen north, sealed themselves behind the Greymane Wall. If we are to survive the coming storm, we must force our neighbor back out into the open.",
          @"ReplaceableTextures\CommandButtons\BTNGate.blp")
        {
            _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

            AddObjective(new ObjectiveQuestComplete(prerequisite));
            AddObjective(_enterGilneasGateRegion = new ObjectiveAnyUnitInRect(Regions.GilneasUnlock5, "Gilneas Gate", true));
            AddObjective(new ObjectiveSelfExists());
            ResearchId = UPGRADE_RD03_QUEST_COMPLETED_THE_GREYMANE_WALL;
        }

        /// <inheritdoc/>
        public override string RewardFlavour =>
          $"{_enterGilneasGateRegion.CompletingUnitName} smashes down the gate to Gilneas. What lies behind the Greymane Wall reveals a tragic history: the Gilneans have already fallen to the Worgen curse. There is nothing more to be done, other than to put them out of their misery.";

        /// <inheritdoc/>
        protected override string RewardDescription => "Gain control of Gilneas gate";

        /// <inheritdoc/>
        protected override void OnFail(Faction completingFaction)
        {
            var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
              ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
              : completingFaction.Player;

            rescuer.RescueGroup(_rescueUnits);
        }

        /// <inheritdoc/>
        protected override void OnComplete(Faction completingFaction)
        {
            completingFaction.Player.RescueGroup(_rescueUnits);

            completingFaction.Player
              .PlayMusicThematic("war3mapImported\\DalaranTheme.mp3");

            AddSpecialEffect(@"Abilities\Spells\Human\DispelMagic\DispelMagicTarget.mdl", GetUnitX(_rescueUnits[0]), GetUnitY(_rescueUnits[0]))
              .SetScale(3)
              .SetLifespan();

            AddSpecialEffect(@"Units\NightElf\Wisp\WispExplode.mdl", GetUnitX(_rescueUnits[0]), GetUnitY(_rescueUnits[0]))
              .SetScale(3)
              .SetLifespan();
        }
    }
}
