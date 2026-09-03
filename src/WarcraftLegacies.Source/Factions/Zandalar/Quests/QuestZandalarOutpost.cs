using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.GameLogic.Rocks;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Zandalar.Quests;
  /// <summary>
  /// The Trolls can establish an outpost in the Echo Isles.
  /// </summary>
  public sealed class QuestZandalarOutpost : QuestData
  {
    private readonly List<unit> _rescueUnits;
    private readonly ObjectiveAnyUnitInRect _enterZandalarRegion;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestZandalar"/>.
    /// </summary>
    public QuestZandalarOutpost() : base("Zandalar Outpost",
      "It has been an age since the height of Zandalar's glory. Since then, our Darkspear cousins have grown strong nestled in the Horde's breast. We should establish an outpost in the Echo Isles, so that Zandalari and Darkspear may meet on shared ground.",
      @"ReplaceableTextures\CommandButtons\BTNtrollmedium.blp")
    {
      AddObjective(_enterZandalarRegion = new ObjectiveAnyUnitInRect(Regions.Zandalari_Echo_Unlock, "Zandalar Outpost", true));
      AddObjective(new ObjectiveSelfExists());
      AddObjective(new ObjectiveExpire(600, Title));

    ResearchId = UPGRADE_MD35_QUEST_COMPLETED_ZANDALAR_OUTPOST;
    _rescueUnits = Regions.Zandalari_Echo_Unlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      $"{_enterZandalarRegion.CompletingUnitName} has spoken with the elders of the Echo Isles and they have agreed to let the Zandalar trolls set up an outpost on one of their islands.";

    /// <inheritdoc />
    protected override string RewardDescription => "Gain control of a small outpost in the Echo Isles";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction) => completingFaction.Player.RescueGroup(_rescueUnits);
  }
