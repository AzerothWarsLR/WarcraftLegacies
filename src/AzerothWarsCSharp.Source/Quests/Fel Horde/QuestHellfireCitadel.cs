using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestHellfireCitadel : QuestData
  {
    private readonly List<unit> _demonGates;
    private readonly List<unit> _rescueUnits = new();

    //Todo: mediocre flavour
    public QuestHellfireCitadel(Rectangle rescueRect, List<unit> demonGates) : base("The Citadel",
      "The clans holding Hellfire Citadel do not respect Kargath authority yet, destroy Murmur to finally establish Magtheridon as the undisputable king of Outland",
      "ReplaceableTextures\\CommandButtons\\BTNFelOrcFortress.blp")
    {
      _demonGates = demonGates;
      AddQuestItem(new QuestItemLegendDead(LegendDraenei.LegendExodarship));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01J"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n02N"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("o02Y"), FourCC("o02Y")));
      AddQuestItem(new QuestItemExpire(1450));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R00P");
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE))
          _rescueUnits.Add(unit);
    }

    //Todo: bad flavor
    protected override string CompletionPopup =>
      "Hellfire Citadel has been subjugated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "Control of all units in Hellfire Citadel and enable Kargath to be trained at the altar";

    protected override void OnComplete()
    {
      foreach (var unit in _demonGates) UnitRescue(unit, Holder.Player);
      foreach (var unit in _rescueUnits) UnitRescue(unit, Holder.Player);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\FelTheme.mp3");
    }

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }
  }
}