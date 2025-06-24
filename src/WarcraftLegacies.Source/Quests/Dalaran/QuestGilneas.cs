using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
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
    public sealed class QuestGilneas : QuestData
    {
        private readonly List<unit> _rescueUnits;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestGilneas"/> class.
        /// </summary>
        /// <param name="prerequisite">This quests must be completed before this one can be completed.</param>
        /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
        public QuestGilneas(Rectangle rescueRect) : base("The Greymane Wall",
          "The Gilneans, fearful of a potential invasion from the frozen north, sealed themselves behind the Greymane Wall. If we are to survive the coming storm, we must force our neighbor back out into the open.",
          @"ReplaceableTextures\CommandButtons\BTNGate.blp")
        {
            _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
             AddObjective(new ObjectiveControlPoint(UNIT_N01A_HINTERLANDS));
             AddObjective(new ObjectiveControlPoint(UNIT_N0EB_JINTHA_ALOR));
             AddObjective(new ObjectiveControlPoint(UNIT_N01Z_ARATHI_HIGHLANDS));
            AddObjective(new ObjectiveSelfExists());
            ResearchId = UPGRADE_RD03_QUEST_COMPLETED_THE_GREYMANE_WALL;
        }

        /// <inheritdoc/>
        public override string RewardFlavour =>
          $"smashes down the gate to Gilneas. What lies behind the Greymane Wall reveals a tragic history: the Gilneans have already fallen to the Worgen curse. There is nothing more to be done, other than to put them out of their misery.";

        /// <inheritdoc/>
        protected override string RewardDescription => "Gain control of Gilneas";

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
            foreach (var unit in _rescueUnits)
               unit.Rescue(completingFaction.Player);
               completingFaction.Player?.PlayMusicThematic("war3mapImported\\DalaranTheme.mp3");

            AddSpecialEffect(@"Abilities\Spells\Human\DispelMagic\DispelMagicTarget.mdl", GetUnitX(_rescueUnits[0]), GetUnitY(_rescueUnits[0]))
              .SetScale(3)
              .SetLifespan();

            AddSpecialEffect(@"Units\NightElf\Wisp\WispExplode.mdl", GetUnitX(_rescueUnits[0]), GetUnitY(_rescueUnits[0]))
              .SetScale(3)
              .SetLifespan();
        }
    }
}
