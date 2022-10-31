using System.Collections.Generic;
using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.ControlPointSystem;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.MacroTools.Wrappers;
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
      AddObjective(new ObjectiveLegendReachRect(LegendSentinels.legendTyrande, Regions.FeathermoonUnlock,
        "Feathermoon Stronghold"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01R"))));
      AddObjective(new ObjectiveUpgrade(FourCC("n06P"), FourCC("n06J")));
      AddObjective(new ObjectiveExpire(1485));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R06M");
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Feathermoon Stronghold has been relieved and has joined the Sentinels in their war effort";

    protected override string RewardDescription =>
      "Control of all units in Feathermoon Stronghold and make Shandris and Maiev trainable at the Altar";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 300);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 300);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\SentinelTheme.mp3");
    }
  }
}