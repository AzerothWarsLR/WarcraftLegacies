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


namespace WarcraftLegacies.Source.Quests.Sentinels
{
  public sealed class QuestAstranaar : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestAstranaar(List<Rectangle> rescueRects) : base("Astranaar Stronghold",
      "Darkshore is under attack by some Murloc. We should deal with them swiftly and){ make for the Astranaar Outpost. Clearing the Murlocs will also reestablish communication with Darnassus.",
      "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp")
    {
      AddObjective(new ObjectiveLegendReachRect(LegendSentinels.legendTyrande, Regions.AstranaarUnlock,
        "Astranaar Outpost"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n02U"))));
      AddObjective(new ObjectiveExpire(1430));
      AddObjective(new ObjectiveSelfExists());

      foreach (var rectangle in rescueRects)
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rectangle.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Astranaar has been relieved and has joined the Sentinels in their war effort";

    protected override string RewardDescription => "Control of all units in Astranaar Outpost and Darnassus";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 200);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 100);
    }
  }
}