using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Forsaken
{
  public sealed class QuestTheNine : QuestData
  {
    public QuestTheNine() : base("The Nine",
      "Most of the Val'kyr are still in Northrend, under the influence of the Lich King, they need to join the Forsaken cause",
      "ReplaceableTextures\\CommandButtons\\BTNPaleValkyr.blp")
    {
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendForsaken.SylvanasUndead));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n02J"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n03U"))));
      AddObjective(new ObjectiveCapitalDead(LegendScourge.LegendLichking));
      AddObjective(new ObjectiveSelfExists());
    }

    //Todo: bad flavour
    protected override string CompletionPopup => "Enable up to 9 Val'kyr join their ranks.";

    protected override string RewardDescription => "Enable 9 Val'kyr to be raised";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(Constants.UNIT_U01V_VAL_KYR_FORSAKEN, 5);
    }
  }
}