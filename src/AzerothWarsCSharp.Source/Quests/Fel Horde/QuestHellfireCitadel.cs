using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
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
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N01J_ZANGARMARSH_15GOLD_MIN)));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N02N_BLADE_S_EDGE_MOUNTAINS_15GOLD_MIN)));
      AddQuestItem(new QuestItemUpgrade(FourCC("o030"), FourCC("o02Y")));
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
      foreach (var unit in _demonGates) unit.Rescue(Holder.Player);
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\FelTheme.mp3");
    }

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }
  }
}