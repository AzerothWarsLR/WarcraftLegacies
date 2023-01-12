using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
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
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N019_ALTERAC_MOUNTAINS_20GOLD_MIN), 10));
      ResearchId = Constants.UPGRADE_R042_QUEST_COMPLETED_INFERNAL_FOOTHOLD_LEGION;
    }

    protected override string RewardFlavour => "The Legion has developped more infernal weaponry";

    protected override string RewardDescription =>
      "You can build the Infernal Machine Factory and summon Anetheron from the " + GetObjectName(AltarId);
  }
}