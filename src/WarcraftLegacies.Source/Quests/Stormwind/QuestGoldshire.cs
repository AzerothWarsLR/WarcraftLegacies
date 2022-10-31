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

namespace WarcraftLegacies.Source.Quests.Stormwind
{
  public sealed class QuestGoldshire : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestGoldshire(Rectangle rescueRect, unit hogger) : base("The Scourge of Elwynn",
      "Hogger and his pack have taken over Goldshire, clear them out!",
      "ReplaceableTextures\\CommandButtons\\BTNGnoll.blp")
    {
      AddObjective(new ObjectiveKillUnit(hogger)); //Hogger
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00Z"))));
      AddObjective(new ObjectiveExpire(1335));
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup => "The Gnolls have been defeated, Goldshire is safe.";

    protected override string RewardDescription => "Control of all units in Goldshire";

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