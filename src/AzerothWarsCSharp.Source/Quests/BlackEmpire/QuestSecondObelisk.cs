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
  public sealed class QuestSecondObelisk : QuestData
  {
    private readonly List<destructable> _gates;
    private readonly List<unit> _rescueUnits = new();

    public QuestSecondObelisk(List<rect> rescueRects, IEnumerable<destructable> gates) : base("Second Obelisk",
      "The convergence of floatities grows ever closer. An Obelisk must be established in Uldum.",
      "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp")
    {
      AddObjective(new ObjectiveObelisk(ControlPointManager.GetFromUnitType(FourCC("n0BD"))));
      foreach (var rescueRect in rescueRects)
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
      {
        SetUnitInvulnerable(unit, true);
        _rescueUnits.Add(unit);
      }

      _gates = gates.ToList();
      foreach (var gate in _gates)
      {
        SetDestructableInvulnerable(gate, true);
      }

      Required = true;
    }

    protected override string CompletionPopup =>
      "The second Obelisk has been set. Ny'alotha's connection to Azeroth grows stronger.";

    protected override string RewardDescription =>
      "Unlock the southern zone of NyaFourCC(lotha, and the next Herald you train will open a temporary portal to the Twilight Highlands.";

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
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