using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Goblin
{
  public sealed class QuestGadgetzan : QuestData
  {
    protected override string CompletionPopup =>
      "Control of all buildings in Gadgetzan and enables Noggenfogger to be built at the altar";

    protected override string CompletionDescription =>
      "We can train Noggenfogger && Gadgetzan is now under our influence and its military is now free to assist the " +
      Holder.Team.Name + ".";

    private static void GrantGadetzan(player whichPlayer)
    {
      group tempGroup = CreateGroup();
      //Transfer all Neutral Passive units in Gadetzan
      GroupEnumUnitsInRect(tempGroup, Regions.GadgetUnlock.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null)
        {
          break;
        }

        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          GeneralHelpers.UnitRescue(u, whichPlayer);
        }

        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnFail()
    {
      GrantGadetzan(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      GrantGadetzan(Holder.Player);
    }

    public QuestGadgetzan() : base("Gadgetzan", "The city of Gadgetzan is a perfect foothold into Kalimdor.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroAlchemist.blp")
    {
      AddQuestItem(new QuestItemExpire(1522));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R07E");
    }
  }
}