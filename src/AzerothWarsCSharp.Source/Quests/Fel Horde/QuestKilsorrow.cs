using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestKilsorrow : QuestData
  {
    public QuestKilsorrow()
    {
      thistype this =
        thistype.allocate("KilFourCC("sorrow Fortress", "This sinister fortress will serve the Fel Horde well,
          clear the surrounding lands to establish it", "ReplaceableTextures\\CommandButtons\\BTNFelOrcWatchTower.blp");
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n09X"))));
      AddQuestItem(new QuestItemExpire(1452));
      AddQuestItem(QuestItemSelfExists);
    }


    protected override string CompletionPopup =>
      "KilFourCC(sorrow is now established, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in KilFourCC(sorrow && 3 new Demon Gates";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.KilsorrowUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.KilsorrowUnlock.Rect, Holder.Player);
      UnitRescue(gg_unit_n081_4142, FelHordeSetup.FactionFelHorde.Player);
    }

    protected override void OnAdd()
    {
    }
  }
}