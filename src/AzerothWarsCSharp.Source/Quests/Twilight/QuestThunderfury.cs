using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.Extensions;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Quests.Twilight
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