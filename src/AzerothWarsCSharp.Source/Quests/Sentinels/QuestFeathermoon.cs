using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestFeathermoon : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestFeathermoon(Rectangle rescueRect) : base("Feathermoon Stronghold",
      "Feathermoon Stronghold stood guard for ten thousand years, it is time to relieve the guards from their duty.",
      "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp")
    {
      AddQuestItem(new QuestItemLegendReachRect(LegendSentinels.legendTyrande, Regions.FeathermoonUnlock,
        "Feathermoon Stronghold"));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01R"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("n06P"), FourCC("n06J")));
      AddQuestItem(new QuestItemExpire(1485));
      AddQuestItem(new QuestItemSelfExists());
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

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
      Holder.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 300);
      Holder.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 300);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\SentinelTheme.mp3");
    }
  }
}