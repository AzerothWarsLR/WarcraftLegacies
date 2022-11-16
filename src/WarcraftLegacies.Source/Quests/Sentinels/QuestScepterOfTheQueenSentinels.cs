using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using System.Collections.Generic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  /// <summary>
  /// Sentinels rescue some Highborne and get the Scepter of the Queen.
  /// </summary>
  public sealed class QuestScepterOfTheQueenSentinels : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestScepterOfTheQueenSentinels"/> class.
    /// </summary>
    /// <param name="area">Units in this area will be made invulnerable, then rescued when the quest is completed.</param>
    public QuestScepterOfTheQueenSentinels(Rectangle area) : base("Return to the Fold",
      "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Stonemaul falls, it would be safe for them to come out.",
      "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2.blp")
    {
      _highBourneArea = area;
      _highBourneAreaUnits = _highBourneArea.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      ResearchId = Constants.UPGRADE_R02O_QUEST_COMPLETED_RETURN_TO_THE_FOLD_SENTINELS;
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendSentinels.legendFeathermoon));
      AddObjective(new ObjectiveLegendDead(LegendWarsong.StonemaulKeep));
      AddObjective(new ObjectiveAnyUnitInRect(Regions.HighBourne, "Dire Maul", true));
    }

    private readonly List<unit> _highBourneAreaUnits;
    private readonly Rectangle _highBourneArea;

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "The Shen'dralar, the Highborne survivors of the Sundering, swear allegiance to their fellow Night Elves. As a sign of their loyalty, they offer up an artifact they have guarded for thousands of years: the Scepter of the Queen.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Gain the Scepter of the Queen and control of all units in Dire Maul";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      ArtifactSetup.ArtifactScepterofthequeen?.Item.SetPosition(_highBourneArea.Center);
      whichFaction.Player?.RescueGroup(_highBourneAreaUnits);
    }
  }
}