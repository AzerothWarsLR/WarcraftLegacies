using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestThunderBluff : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestThunderBluff(rect rescueRect) : base("The Long March",
      "The Tauren have been wandering for too long. The plains of Mulgore would offer respite from this endless journey.",
      "ReplaceableTextures\\CommandButtons\\BTNCentaurKhan.blp")
    {
      AddQuestItem(new ObjectiveLegendDead(LegendNeutral.LegendCentaurkhan));
      AddQuestItem(new ObjectiveAnyUnitInRect(Regions.ThunderBluff, "Thunder Bluff", true));
      AddQuestItem(new ObjectiveExpire(1455));
      AddQuestItem(new ObjectiveSelfExists());
      ResearchId = FourCC("R05I");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    //todo: bad flavour
    protected override string CompletionPopup => "The Crossroads have been constructed.";

    protected override string RewardDescription => "Control of Thunder Bluff";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\TaurenTheme.mp3");
    }
  }
}