using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestEmbassy : QuestData
  {
    private static readonly int AltarId = FourCC("u01N");

    public QuestEmbassy(Rectangle questRect1, Rectangle questRect2) : base("Infernal Foothold",
      "A stronger foothold in this world will be required to field the Burning Legion's war machines and to in more of its lieutenants."
      , "ReplaceableTextures\\CommandButtons\\BTNDemonBlackCitadel.blp")
    {
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_U00N_BURNING_CITADEL_LEGION_T3, Constants.UNIT_U00C_LEGION_BASTION_LEGION_T2));
      AddObjective(new ObjectiveBuildInRect(questRect1, "in Northrend", Constants.UNIT_U006_SUMMONING_CIRCLE_LEGION_SPECIALIST));
      AddObjective(new ObjectiveBuildInRect(questRect2, "in Alterac", Constants.UNIT_U006_SUMMONING_CIRCLE_LEGION_SPECIALIST));
      ResearchId = Constants.UPGRADE_R042_QUEST_COMPLETED_INFERNAL_FOOTHOLD_LEGION;
    }

    protected override string CompletionPopup => "The Legion has secured a foothold on Azeroth.";

    protected override string RewardDescription =>
      "You can build the Infernal Machine Factory and summon Anetheron from the " + GetObjectName(AltarId);
  }
}