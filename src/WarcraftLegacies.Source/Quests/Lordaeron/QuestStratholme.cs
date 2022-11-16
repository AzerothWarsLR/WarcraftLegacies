using System.Collections.Generic;
using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  /// <summary>
  /// Free Alterac Mountains of the Blackrock orcs and upgrgade the main building to a castle in order to gain control of Stratholme.
  /// </summary>
  public sealed class QuestStratholme : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestStratholme"/> class.
    /// </summary>
    /// <param name="rescueRect"></param>
    public QuestStratholme(Rectangle rescueRect) : base("Blackrock and Roll",
      "The Blackrock clan has taken over Alterac, they must be eliminated for the safety of Lordaeron",
      "ReplaceableTextures\\CommandButtons\\BTNChaosBlademaster.blp")
    {
      AddObjective(new ObjectiveKillUnit(PreplacedUnitSystem.GetUnit(Constants.UNIT_O00B_JUBEI_THOS_LEGION_DEMI)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N019_ALTERAC_MOUNTAINS_20GOLD_MIN)));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_HCAS_CASTLE, Constants.UNIT_HTOW_TOWN_HALL));
      AddObjective(new ObjectiveExpire(1470));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      Required = true;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "Stratholme has been liberated, and its military is now free to assist the Kingdom of Lordaeron.";
    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all units in Stratholme";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
      LegendLordaeron.Arthas.AddUnitDependency(LegendLordaeron.Stratholme.Unit);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
        completingFaction.Player.RescueGroup(_rescueUnits);
      LegendLordaeron.Arthas.AddUnitDependency(LegendLordaeron.Stratholme.Unit);
    }
  }
}