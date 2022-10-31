using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.ControlPointSystem;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Twilight
{
  public sealed class QuestThunderfury : QuestData
  {
    public QuestThunderfury() : base("Blessed Blade of the Windseeker",
      "The legendary sword, Thunderfury, has been lost somewhere in the Broken Isles, Cho'gall has seen it in a vision. It will be a great asset to the Old Gods",
      "ReplaceableTextures\\CommandButtons\\BTNThunderfury2.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendFelHorde.LegendChogall, Regions.Broken_Isles, "The Broken Isles"));
      AddObjective(
        new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N05Y_BROKEN_ISLES_20GOLD_MIN)));
    }

    protected override string CompletionPopup => "Cho'gall has found the legendary sword, Thunderfury";

    protected override string RewardDescription => "The legendary sword Thunderfury";

    protected override void OnComplete(Faction completingFaction)
    {
      LegendFelHorde.LegendChogall.Unit.AddItemSafe(ArtifactSetup.ArtifactThunderfury.Item);
    }
  }
}