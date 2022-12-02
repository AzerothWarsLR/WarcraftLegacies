using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using System.Collections.Generic;
using MacroTools;
using MacroTools.ArtifactSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  /// <summary>
  /// Warsong acquires the Scepter of the Queen and kills some Highborne.
  /// </summary>
  public sealed class QuestScepterOfTheQueenWarsong : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestScepterOfTheQueenWarsong"/> class.
    /// </summary>
    /// <param name="area">Units in this area will be made invulnerable, then made hostile when the quest is completed.</param>
    /// <param name="scepterOfTheQueen">Reward for completing the quest.</param>
    public QuestScepterOfTheQueenWarsong(Rectangle area, Artifact scepterOfTheQueen) : base("Royal Plunder",
      "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Feathermoon Stronghold falls, it would become a simple matter to slaughter the Highborne and plunder their artifacts.",
      "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2.blp")
    {
      _highBourneArea = area;
      _scepterOfTheQueen = scepterOfTheQueen;
      _highBourneAreaUnits = _highBourneArea.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendWarsong.StonemaulKeep ?? throw new SystemNotInitializedException(nameof(LegendWarsong))));
      AddObjective(new ObjectiveLegendDead(LegendSentinels.Feathermoon));
      AddObjective(new ObjectiveAnyUnitInRect(_highBourneArea, "Dire Maul", true));
    }

    private readonly List<unit> _highBourneAreaUnits;
    private readonly Rectangle _highBourneArea;
    private readonly Artifact _scepterOfTheQueen;

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "The Highborne are no longer implicitly defended by the Night Elven presence at Feathermoon Stronghold. The Horde unleashes their full might against these Night Elven arcanists.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Gain the Scepter of the Queen and turn all units in Dire Maul hostile";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      _scepterOfTheQueen.Item.SetPosition(_highBourneArea.Center);
      Player(GetPlayerNeutralAggressive()).RescueGroup(_highBourneAreaUnits);
    }
  }
}