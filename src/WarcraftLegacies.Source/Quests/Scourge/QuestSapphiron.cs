using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestSapphiron : QuestData
  {
    private const int SapphironId = Constants.UNIT_UBDD_SAPPHIRON_SCOURGE_DEMI;

    public QuestSapphiron(unit sapphiron, LegendaryHero kelthuzad) : base("Sapphiron",
      "Kill Sapphiron the Blue Dragon to have Kel'Tuzad reanimate her as a Frost Wyrm. Sapphiron can be found in Northrend.",
      "ReplaceableTextures\\CommandButtons\\BTNFrostWyrm.blp")
    {
      AddObjective(new ObjectiveKillUnit(sapphiron));
      AddObjective(new ObjectiveControlLegend(kelthuzad, false));
      ResearchId = Constants.UPGRADE_R025_QUEST_COMPLETED_SAPPHIRON_SCOURGE;
    }
    
    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "Sapphiron has been slain, and has been reanimated as a mighty Frost Wyrm under the command of the Scourge.";

    /// <inheritdoc/>
    protected override string RewardDescription => "The demihero Sapphiron";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      CreateUnit(completingFaction.Player, SapphironId, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()),
        GetUnitFacing(GetTriggerUnit()));
    }
  }
}