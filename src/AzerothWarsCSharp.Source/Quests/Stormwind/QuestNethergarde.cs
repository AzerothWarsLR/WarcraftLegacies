using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestNethergarde : QuestData
  {
    public QuestNethergarde() : base("Nethergarde relief",
      "The nethergarde fort is holding down the Dark Portal, they will need to be reinforced soon!",
      "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionBarracks.blp")
    {
      AddQuestItem(new QuestItemLegendInRect(LegendStormwind.LegendVarian, Regions.NethergardeUnlock.Rect, "Nethergarde"));
      AddQuestItem(new QuestItemExpire(1440));
      AddQuestItem(new QuestItemSelfExists());
    }
    
    protected override string CompletionPopup => "Varian has come to relieve the Nethergarde garrison.";

    protected override string RewardDescription => "You gain control of the Nethergarde base";

    private static void GrantNethergarde(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Nethergarde
      GroupEnumUnitsInRect(tempGroup, Regions.NethergardeUnlock.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) UnitRescue(u, whichPlayer);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
      
    }

    protected override void OnFail()
    {
      GrantNethergarde(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      GrantNethergarde(Holder.Player);
      StormwindSetup.Stormwind.ModObjectLimit(FourCC("h03F"), 1); //Reginald windsor
    }
  }
}