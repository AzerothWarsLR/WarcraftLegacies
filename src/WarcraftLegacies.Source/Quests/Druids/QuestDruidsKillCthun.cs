using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Druids
{
  public sealed class QuestDruidsKillCthun : QuestData
  {
    private const int UnittypeId = UNIT_E012_SIEGE_ANCIENT_DRUIDS_ELITE;

    public QuestDruidsKillCthun(Legend cthun) : base("The Gates of Ahn'Qiraj",
      "The ravaging hordes of the Qiraji have been consumming Kalimdor. We must put an end to their rampage.",
      @"ReplaceableTextures\CommandButtons\BTNCthunT3.blp")
    {
      AddObjective(new ObjectiveKillUnit(cthun.Unit));

      ResearchId = UPGRADE_R05A_QUEST_COMPLETED_THE_GATES_OF_AHN_QIRAJ;
    }
    
    /// <inheritdoc/>
    public override string RewardFlavour =>
      "The Qiraji presence on Kalimdor has been eliminated. The sacred lands are safe from them.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Learn to train " + GetObjectName(UnittypeId) + "s";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.DisplayUnitTypeAcquired(UnittypeId, "You can now train Siege Ancients at the Ancient of War.");
    }
  }
}