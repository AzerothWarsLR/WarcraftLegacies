using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  //todo: flavour doesn't make any sense
  public sealed class QuestNajentus : QuestData
  {
    public QuestNajentus() : base("Lord of the Depths",
      "The sea floor is wild and unconquered, if Illidan captures it, the Naga Lord Naj'entus will join us",
      "ReplaceableTextures\\CommandButtons\\BTNLordNaj.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N04B_GISHAN_CAVERNS_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N02P_MAK_ARA_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00P_THE_ABYSS_25GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N028_DROWNED_REACHES_10GOLD_MIN)));
      ResearchId = Constants.UPGRADE_R08W_QUEST_COMPLETED_LORD_OF_THE_DEPTHS;
    }

    protected override string CompletionPopup =>
      "The sea belong to Lord Illidan!";

    protected override string RewardDescription => "The hero Naj'entus will join you!";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}