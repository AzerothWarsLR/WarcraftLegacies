using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Legends;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestThunderBluff : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    //todo: bad flavour
    protected override string CompletionPopup => "The Crossroads have been constructed.";

    protected override string RewardDescription => "Control of Thunder Bluff";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Holder.Player);
      if (GetLocalPlayer() == Holder.Player)
      {
        PlayThematicMusicBJ("war3mapImported\\TaurenTheme.mp3");
      }
    }

    public QuestThunderBluff(rect rescueRect) : base("The Long March",
      "The Tauren have been wandering for too long. The plains of Mulgore would offer respite from this endless journey.",
      "ReplaceableTextures\\CommandButtons\\BTNCentaurKhan.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LegendNeutral.LegendCentaurkhan));
      AddQuestItem(new QuestItemAnyUnitInRect(Regions.ThunderBluff, "Thunder Bluff", true));
      AddQuestItem(new QuestItemExpire(1455));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R05I");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
      {
        SetUnitInvulnerable(unit, true);
        _rescueUnits.Add(unit);
      }
    }
  }
}