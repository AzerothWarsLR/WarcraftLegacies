using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestStrahnbrad : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestStrahnbrad(Rectangle rescueRect) : base("The Defense of Strahnbrad",
      "The Strahnbrad is under attack by some brigands, clear them out",
      "ReplaceableTextures\\CommandButtons\\BTNFarm.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N01C_STRAHNBRAD_10GOLD_MIN)));
      AddObjective(new ObjectiveExpire(1170));
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
      Required = true;
    }

    protected override string CompletionPopup => "Strahnbrad has been liberated.";

    protected override string RewardDescription => "Control of all buildings in Strahnbrad";

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