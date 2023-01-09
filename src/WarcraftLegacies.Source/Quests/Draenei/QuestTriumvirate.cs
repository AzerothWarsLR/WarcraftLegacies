using MacroTools.ArtifactSystem;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
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
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n0BH"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n0BL"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n09X"))));
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
      var crownOfTheTriumvirate = new Artifact(CreateItem(Constants.ITEM_I011_CROWN_OF_THE_TRIUMVIRATE, 0, 0));
      ArtifactManager.Register(crownOfTheTriumvirate);
      LegendDraenei.LegendVelen.Unit?.AddItemSafe(crownOfTheTriumvirate.Item);
    }
  }
}