using System.Collections.Generic;
using MacroTools.ArtifactSystem;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  public sealed class QuestRoyalPlunder : QuestData
  {
    private readonly Artifact _scepterOfTheQueen;
    private readonly List<unit> _unitsToRescue = new();

    public QuestRoyalPlunder(Rectangle rescueRect, Artifact scepterOfTheQueen) : base("Royal Plunder",
      "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Feathermoon Stronghold falls, it would become a simple matter to slaughter the Highborne and plunder their artifacts.",
      "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2.blp")
    {
      _scepterOfTheQueen = scepterOfTheQueen;
      AddObjective(new ObjectiveUnitAlive(LegendWarsong.StonemaulKeep.Unit));
      AddObjective(new ObjectiveCapitalDead(LegendSentinels.Feathermoon));
      AddObjective(new ObjectiveAnyUnitInRect(rescueRect, "Dire Maul", true));
      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (!ControlPointManager.UnitIsControlPoint(unit))
        {
          SetUnitInvulnerable(unit, true);
          _unitsToRescue.Add(unit);
        }
    }

    protected override string RewardDescription =>
      "Gain the Scepter of the Queen and turn all units in Dire Maul hostile";

    protected override string CompletionPopup =>
      "The Highborne are no longer implicitly defended by the Night Elven presence at Feathermoon Stronghold. The Horde unleashes their full might against these Night Elven arcanists.";

    protected override void OnComplete(Faction completingFaction)
    {
      //SetItemPosition(_scepterOfTheQueen.Item, Regions.HighBourne.Center.X, Regions.HighBourne.Center.Y);
      foreach (var unit in _unitsToRescue) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }
  }
}