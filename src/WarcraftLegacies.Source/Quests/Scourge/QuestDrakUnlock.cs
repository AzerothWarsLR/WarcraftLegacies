using System.Collections.Generic;
using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.ControlPointSystem;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestDrakUnlock : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestDrakUnlock(Rectangle rescueRect) : base(
      "Draktharon's Keep", "Drak'tharon's Keep will be the place for an outpost by the sea.",
      "ReplaceableTextures\\CommandButtons\\BTNUndeadShipyard.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n030"))));
      AddObjective(new ObjectiveControlLegend(LegendNeutral.LegendDraktharonkeep, false));
      AddObjective(new ObjectiveExpire(1140));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R08J");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup => "DrakFourCC(taron Keep is now under the control of the Scourge.";

    protected override string RewardDescription => "Control of all buildings in Drak'tharon Keep";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}