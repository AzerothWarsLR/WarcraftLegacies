using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestGnomeregan : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R05Q");

    public QuestGnomeregan() : base("The City of Invention",
      "The people of Gnomeregan have long been unable to assist the Alliance in its wars due an infestation of troggs && Ice Trolls. Resolve their conflicts for them to gain their services.",
      "ReplaceableTextures\\CommandButtons\\BTNFlyingMachine.blp")
    {
      AddQuestItem(new QuestItemKillUnit(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nitw")))); //Ice Troll Warlord
      AddQuestItem(new QuestItemSelfExists());
    }


    protected override string CompletionPopup =>
      "Gnomeregan has been literated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Gnomeregan";

    private static void GrantGnomeregan(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Gnomeregan
      GroupEnumUnitsInRect(tempGroup, Regions.Gnomergan.Rect, null);
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
      GrantGnomeregan(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, FourCC("R05Q"), 1);
      GrantGnomeregan(Holder.Player);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(QuestResearchId, 1);
    }
  }
}