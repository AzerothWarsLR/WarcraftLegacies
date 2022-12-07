using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  public sealed class QuestTriumvirate : QuestData
  {
    public QuestTriumvirate() : base("Crown of the Triumvirate",
      "Eons ago, the council that led the Eredar was the Triumvirate. If Velen could reconquer Argus, he could reform the Crown of the Triumvirate",
      "ReplaceableTextures\\CommandButtons\\BTNNeverMeltingCrown.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BH"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BL"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n09X"))));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendDraenei.LegendVelen));
      Global = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "Velen has liberated Argus and re-assembled the Crown of Triumvirate";

    /// <inheritdoc />
    protected override string RewardDescription => "You gain the powerful item, the Crown of the Triumvirate";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      LegendDraenei.LegendVelen.Unit?.AddItemSafe(ArtifactSetup.ArtifactCrowntriumvirate.Item);
    }
  }
}