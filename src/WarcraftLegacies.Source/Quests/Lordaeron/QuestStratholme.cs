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

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  public sealed class QuestStratholme : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestStratholme(Rectangle rescueRect) : base("Blackrock and Roll",
      "The Blackrock clan has taken over Alterac, they must be eliminated for the safety of Lordaeron",
      "ReplaceableTextures\\CommandButtons\\BTNChaosBlademaster.blp")
    {
      AddObjective(new ObjectiveKillUnit(PreplacedUnitSystem.GetUnit(Constants.UNIT_O00B_JUBEI_THOS_LEGION_DEMI)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N019_ALTERAC_MOUNTAINS_20GOLD_MIN)));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_HCAS_CASTLE, Constants.UNIT_HTOW_TOWN_HALL));
      AddObjective(new ObjectiveExpire(1470));
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
      Required = true;
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Stratholme has been liberated, and its military is now free to assist the Kingdom of Lordaeron.";

    protected override string RewardDescription => "Control of all units in Stratholme";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      LegendLordaeron.LegendArthas.AddUnitDependency(LegendLordaeron.LegendStratholme.Unit);
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      LegendLordaeron.LegendArthas.AddUnitDependency(LegendLordaeron.LegendStratholme.Unit);
    }
  }
}