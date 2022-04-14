using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestStratholme : QuestData
  {
    public QuestStratholme() : base("Blackrock and Roll",
      "The Blackrock clan has taken over Alterac, they must be eliminated for the safety of Lordaeron",
      "ReplaceableTextures\\CommandButtons\\BTNChaosBlademaster.blp")
    {
      AddQuestItem(new QuestItemKillUnit(PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00B")))); //Jubei
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n019"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("hcas"), FourCC("htow")));
      AddQuestItem(new QuestItemExpire(1470));
      AddQuestItem(new QuestItemSelfExists());
    }


    protected override string CompletionPopup =>
      "Stratholme has been liberated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Stratholme";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.StratholmeUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.StratholmeUnlock.Rect, Holder.Player);
    }

    protected override void OnAdd()
    {
    }
  }
}