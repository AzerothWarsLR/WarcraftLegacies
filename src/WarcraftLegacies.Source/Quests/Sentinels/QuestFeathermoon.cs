using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  public sealed class QuestFeathermoon : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestFeathermoon(Rectangle rescueRect) : base("Feathermoon Stronghold",
      "Feathermoon Stronghold stood guard for ten thousand years, it is time to relieve the guards from their duty.",
      "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp")
    {
      AddObjective(new ObjectiveLegendReachRect(LegendSentinels.Tyrande, Regions.FeathermoonUnlock,
        "Feathermoon Stronghold"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01R_ASTRANAAR_15GOLD_MIN)));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_N06P_SENTINEL_ENCLAVE_SENTINEL_T3, Constants.UNIT_N06J_SENTINEL_OUTPOST_SENTINEL_T1));
      AddObjective(new ObjectiveExpire(1485));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R06M_QUEST_COMPLETED_FEATHERMOON_RELIEF;
      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Feathermoon Stronghold has been relieved and has joined the Sentinels in their war effort";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units in Feathermoon Stronghold and make Shandris and Maiev trainable at the Altar";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 300);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 300);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\SentinelTheme.mp3");
    }
  }
}