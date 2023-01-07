using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using MacroTools.ArtifactSystem;
using MacroTools.ObjectiveSystem.Objectives;
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
    /// <param name="scepterOfTheQueen">Reward for completing the quest.</param>
    public QuestScepterOfTheQueenSentinels(Rectangle area, Artifact scepterOfTheQueen) : base("Return to the Fold",
      "Remnants of the ancient Highborne survive within the ruins of the Athenaeum. If Stonemaul falls, it would be safe for them to come out.",
      "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2.blp")
    {
      _highBourneArea = area;
      _scepterOfTheQueen = scepterOfTheQueen;
      _highBourneAreaUnits = _highBourneArea.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      ResearchId = Constants.UPGRADE_R02O_QUEST_COMPLETED_RETURN_TO_THE_FOLD_SENTINELS;
      AddObjective(new ObjectiveCapitalDead(LegendWarsong.StonemaulKeep));
      AddObjective(new ObjectiveKillAllInArea(new[]{area}, "outside the Athenaeum"));
      _anyUnitInRect = new ObjectiveAnyUnitInRect(_highBourneArea, "the Athenaeum", true);
      AddObjective(_anyUnitInRect);
      AddObjective(new ObjectiveNoOtherPlayerGetsArtifact(scepterOfTheQueen));
      Required = true;
    }

    private readonly List<unit> _highBourneAreaUnits;
    private readonly Rectangle _highBourneArea;
    private readonly Artifact _scepterOfTheQueen;
    private readonly ObjectiveAnyUnitInRect _anyUnitInRect;

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "The Shen'dralar, the Highborne survivors of the Sundering, swear allegiance to their fellow Night Elves. As a sign of their loyalty, they offer up an artifact they have guarded for thousands of years: the Scepter of the Queen.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Gain the Scepter of the Queen, the Athenaeum, 4 {GetObjectName(Constants.UNIT_NNMG_REDEEMED_HIGHBORNE_SENTINELS)}, and the ability to train {GetObjectName(Constants.UNIT_NNMG_REDEEMED_HIGHBORNE_SENTINELS)} from the {GetObjectName(Constants.UNIT_E00V_TEMPLE_OF_ELUNE_SENTINEL_MAGIC)}";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      _anyUnitInRect.CompletingUnit?.AddItemSafe(_scepterOfTheQueen.Item);
      whichFaction.Player?.RescueGroup(_highBourneAreaUnits);
    }
    
    /// <inheritdoc/>
    protected override void OnFail(Faction whichFaction)
    {
      _scepterOfTheQueen.Item.SetPosition(_highBourneArea.Center);
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_highBourneAreaUnits);
    }
  }
}