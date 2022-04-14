using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestKilsorrow : QuestData
  {
    private readonly unit _kilsorrowFortress;

    public QuestKilsorrow(unit kilsorrowFortress) : base("Kil'sorrow Fortress",
      "This sinister fortress will serve the Fel Horde well, clear the surrounding lands to establish it",
      "ReplaceableTextures\\CommandButtons\\BTNFelOrcWatchTower.blp")
    {
      _kilsorrowFortress = kilsorrowFortress;
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n09X"))));
      AddQuestItem(new QuestItemExpire(1452));
      AddQuestItem(new QuestItemSelfExists());
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Kil'sorrow is now established, and its military is now free to assist the " + Holder.Team.Name + ".";

    //Todo: indicate where those Demon Gates are
    protected override string RewardDescription => "Control of all units in Kil'sorrow and 3 new Demon Gates";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.KilsorrowUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.KilsorrowUnlock.Rect, Holder.Player);
      UnitRescue(_kilsorrowFortress, FelHordeSetup.FactionFelHorde.Player);
    }
  }
}