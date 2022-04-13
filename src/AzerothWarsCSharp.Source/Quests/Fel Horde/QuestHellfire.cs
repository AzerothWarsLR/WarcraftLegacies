using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestHellfire : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R00P");

    private readonly List<unit> _demonGates;

    //Todo: mediocre flavour
    public QuestHellfire(List<unit> demonGates) : base("The Citadel",
      "The clans holding Hellfire Citadel do not respect Kargath authority yet, destroy Murmur to finally establish Magtheridon as the undisputable king of Outland",
      "ReplaceableTextures\\CommandButtons\\BTNFelOrcFortress.blp")
    {
      _demonGates = demonGates;
      AddQuestItem(new QuestItemLegendDead(LegendDraenei.LegendExodarship));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01J"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02N"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("o02Y"), FourCC("o02Y")));
      AddQuestItem(new QuestItemExpire(1450));
      AddQuestItem(new QuestItemSelfExists());
    }

    //Todo: bad flavor
    protected override string CompletionPopup =>
      "Hellfire Citadel has been subjugated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "Control of all units in Hellfire Citadel and enable Kargath to be trained at the altar";

    private static void GrantHellfire(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Hellfire Citadel
      GroupEnumUnitsInRect(tempGroup, Regions.HellfireUnlock.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE)) UnitRescue(u, whichPlayer);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnComplete()
    {
      foreach (var unit in _demonGates)
      {
        UnitRescue(unit, Holder.Player);
      }

      SetPlayerTechResearched(Holder.Player, FourCC("R00P"), 1);
      GrantHellfire(Holder.Player);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\FelTheme.mp3");
    }

    protected override void OnFail()
    {
      GrantHellfire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(QuestResearchId, 1);
    }
  }
}