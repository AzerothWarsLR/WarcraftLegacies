using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  public sealed class QuestShipArgus : QuestData
  {
    public QuestShipArgus() : base("Reconquering Tempest Keep",
      "Tempest Keep still has the power to open a portal Argus, but Velen needs to channel it",
      "ReplaceableTextures\\CommandButtons\\BTNArcaneCastle.blp")
    {
      AddObjective(new ObjectiveChannelRect(Regions.TempestKeepSpawn, "Tempest Keep", LegendDraenei.LegendVelen, 180, 0));
      Global = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "Velen has opened the portal to Argus";

    /// <inheritdoc />
    protected override string RewardDescription => "Open a Portal between Tempest Keep and Argus";
    
    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      //Todo: uncomment these
      // WaygateActivateBJ(true, gg_unit_h03V_3538);
      // ShowUnitShow(gg_unit_h03V_3538);
      // WaygateSetDestinationLocBJ(gg_unit_h03V_3538, GetRectCenter(gg_rct_OutlandToArgus));
      // WaygateActivateBJ(true, gg_unit_h03V_3539);
      // ShowUnitShow(gg_unit_h03V_3539);
      // WaygateSetDestinationLocBJ(gg_unit_h03V_3539, GetRectCenter(gg_rct_TempestKeepSpawn));
    }
  }
}