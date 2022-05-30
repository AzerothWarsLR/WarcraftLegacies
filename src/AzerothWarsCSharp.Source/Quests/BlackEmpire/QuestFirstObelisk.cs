using System.Collections.Generic;
using System.Linq;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Mechanics.BlackEmpire;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public sealed class QuestFirstObelisk : QuestData
  {
    private readonly List<destructable> _gates;
    private readonly List<unit> _rescueUnits = new();

    public QuestFirstObelisk(rect rescueArea, IEnumerable<destructable> gates) : base("The First Obelisk",
      "The twisted floatity of Ny'alotha is a mere shadow of Azeroth, but that will soon change. The first step in merging the two realities is to establish an Obelisk in Northrend.",
      "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp")
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueArea).EmptyToList())
      {
        SetUnitInvulnerable(unit, true);
        _rescueUnits.Add(unit);
      }

      _gates = gates.ToList();
      foreach (var gate in _gates)
      {
        SetDestructableInvulnerable(gate, true);
      }

      AddObjective(new ObjectiveObelisk(ControlPointManager.GetFromUnitType(FourCC("n02S"))));
      Required = true;
    }

    protected override string CompletionPopup =>
      "The first Obelisk has been summoned, but Ny'alotha's connection to Azeroth is not yet stable. More Obelisks must be erected.";

    protected override string RewardDescription =>
      "Unlock the northern zone of Ny'alotha, and the next Herald you train will open a temporary portal to Uldum.";

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits)
      {
        unit.Rescue(completingFaction.Player ?? Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }

      KillUnit(HeraldBuff.Instance?.Caster);
      BlackEmpirePortalManager.GoToNext();
      foreach (var gate in _gates)
      {
        RemoveDestructable(gate);
      }

      _gates.Clear();
    }
  }
}