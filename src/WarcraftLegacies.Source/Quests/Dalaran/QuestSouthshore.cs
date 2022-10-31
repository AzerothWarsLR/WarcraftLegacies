using System.Collections.Generic;
using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.ControlPointSystem;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Dalaran
{
  public sealed class QuestSouthshore : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestSouthshore(Rectangle rescueRect, unit murlocToKill) : base("Murloc Troubles",
      "A small murloc skirmish is attacking Southshore, push them back",
      "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp")
    {
      AddObjective(new ObjectiveKillUnit(murlocToKill));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n08M"))));
      AddObjective(new ObjectiveExpire(1135));
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup => "The Murlocs have been defeated, Southshore is safe.";

    protected override string RewardDescription => "Control of all units in Southshore";

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