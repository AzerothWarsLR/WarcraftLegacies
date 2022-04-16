using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestKilsorrow : QuestData
  {
    private readonly unit _kilsorrowFortress;
    private readonly List<unit> _rescueUnits = new();

    public QuestKilsorrow(Rectangle rescueRect, unit kilsorrowFortress) : base("Kil'sorrow Fortress",
      "This sinister fortress will serve the Fel Horde well, clear the surrounding lands to establish it",
      "ReplaceableTextures\\CommandButtons\\BTNFelOrcWatchTower.blp")
    {
      _kilsorrowFortress = kilsorrowFortress;
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n09X"))));
      AddQuestItem(new QuestItemExpire(1452));
      AddQuestItem(new QuestItemSelfExists());

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Kil'sorrow is now established, and its military is now free to assist the " + Holder.Team.Name + ".";

    //Todo: indicate where those Demon Gates are
    protected override string RewardDescription => "Control of all units in Kil'sorrow and 3 new Demon Gates";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Holder.Player);
      UnitRescue(_kilsorrowFortress, FelHordeSetup.FactionFelHorde.Player);
    }
  }
}