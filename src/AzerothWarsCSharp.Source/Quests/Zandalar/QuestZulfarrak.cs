using AzerothWarsCSharp.MacroTools.FactionSystem;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestZulfarrak : QuestData
  {
    private static readonly int GahzrillaResearch = FourCC("R02F");
    private static readonly int GahzrillaId = FourCC("H06Q");


    protected override string CompletionPopup => "Zul'farrak has fallen. The Sandfury trolls lend their might to the " +
                                                 this.Holder.Team.Name +
                                                 ", you can train Storm Wyrms and Gahz'rilla awakens from its slumber.";

    protected override string RewardDescription =>
      "Control of Zul'farrak, 300 gold tribute, enable to train Storm Wyrm and you can summon the hero Gahz'rilla from the Altar of Conquerors";

    protected override void OnComplete()
    {
      unit u;
      group tempGroup;
      tempGroup = CreateGroup();
      GroupEnumUnitsInRect(tempGroup, Regions.Zulfarrak.Rect, null);
      u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null)
        {
          break;
        }

        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) ||
            GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE))
        {
          if (IsUnitType(u, UNIT_TYPE_HERO))
          {
            KillUnit(u);
          }
          else
          {
            UnitRescue(u, Holder.Player);
          }
        }

        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
      SetPlayerTechResearched(Holder.Player, GahzrillaResearch, 1);
      AdjustPlayerStateBJ(300, Holder.Player, PLAYER_STATE_RESOURCE_GOLD);
      SetUnitOwner(LegendNeutral.LegendZulfarrak.Unit, Holder.Player, true);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(GahzrillaResearch, Faction.UNLIMITED);
      Holder.ModObjectLimit(GahzrillaId, 1);
    }

    public QuestZulfarrak() : base("Fury of the Sands",
      "The Sandfury Trolls of Zul'farrak are openly hostile to visitors, but they share a common heritage with the Zandalari Trolls. An adequate display of force could bring them around.",
      "ReplaceableTextures\\CommandButtons\\BTNDarkTroll.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendZulfarrak, false));
    }
  }
}