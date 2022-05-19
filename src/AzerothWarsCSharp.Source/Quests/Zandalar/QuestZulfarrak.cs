using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestZulfarrak : QuestData
  {
    private const int GAHZRILLA_ID = Constants.UNIT_H06Q_DEMIGOD_WARSONG;
    private readonly List<unit> _rescueUnits = new();

    public QuestZulfarrak(Rectangle rescueRect) : base("Fury of the Sands",
      "The Sandfury Trolls of Zul'farrak are openly hostile to visitors, but they share a common heritage with the Zandalari Trolls. An adequate display of force could bring them around.",
      "ReplaceableTextures\\CommandButtons\\BTNDarkTroll.blp")
    {
      ResearchId = Constants.UPGRADE_R02F_QUEST_COMPLETED_FURY_OF_THE_SANDS_WARSONG;
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendZulfarrak, false));
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      $"Zul'farrak has fallen. The Sandfury trolls lend their might to the {Holder.Team?.Name}.";

    protected override string RewardDescription =>
      "Control of Zul'farrak, 300 gold tribute, enable to train Storm Wyrm and you can summon the hero Gahz'rilla from the Altar of Conquerors";

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
      Holder.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 300);
      SetUnitOwner(LegendNeutral.LegendZulfarrak.Unit, Holder.Player, true);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(GAHZRILLA_ID, 1);
    }
  }
}