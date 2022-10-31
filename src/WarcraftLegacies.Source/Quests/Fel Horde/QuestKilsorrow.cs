using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
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
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n09X"))));
      AddObjective(new ObjectiveExpire(1452));
      AddObjective(new ObjectiveSelfExists());

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Kil'sorrow is now established, and its military is now free to assist the Fel Horde.";

    //Todo: indicate where those Demon Gates are
    protected override string RewardDescription => "Control of all units in Kil'sorrow and 3 new Demon Gates";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      _kilsorrowFortress.Rescue(FelHordeSetup.FelHorde.Player);
    }
  }
}