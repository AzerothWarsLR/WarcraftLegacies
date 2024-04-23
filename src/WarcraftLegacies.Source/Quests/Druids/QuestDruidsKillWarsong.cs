using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Druids
{
  public sealed class QuestDruidsKillWarsong : QuestData
  {
    private const int UnittypeId = UNIT_E012_SIEGE_ANCIENT_DRUIDS_ELITE;

    public QuestDruidsKillWarsong() : base("Enemies at the Gate",
      "Arriving from another planet and across the seas of Azeroth, the Orcs of the Warsong Clan have arrived to ravage the wilderness and consume its bounty. They must be stopped.",
      @"ReplaceableTextures\CommandButtons\BTNHellScream.blp")
    {
      AddObjective(new ObjectiveControlLevel(UNIT_N01Q_NORTHERN_ASHENVALE, 10));
      AddObjective(new ObjectiveControlLevel(UNIT_N08U_SOUTHERN_ASHENVALE, 10));
      AddObjective(new ObjectiveControlLevel(UNIT_N05K_WARSONG_LUMBER_CAMP, 10));
      AddObjective(new ObjectiveControlLevel(UNIT_N09R_ELDARATH, 10));
      AddObjective(new ObjectiveControlPoint(UNIT_N05K_WARSONG_LUMBER_CAMP, 0));
      ResearchId = UPGRADE_R05A_QUEST_COMPLETED_ENEMIES_AT_THE_GATE;
    }
    
    /// <inheritdoc/>
    public override string RewardFlavour =>
      "The Warsong presence on Kalimdor has been eliminated. The sacred lands are safe from their hatchets.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Learn to train " + GetObjectName(UnittypeId) + "s";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.DisplayUnitTypeAcquired(UnittypeId, "You can now train Siege Ancients at the Ancient of War.");
    }
  }
}