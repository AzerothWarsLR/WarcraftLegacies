using System.Collections.Generic;
using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  /// <summary>
  /// Free Alterac Mountains of the Blackrock orcs and upgrgade the main building to a castle in order to gain control of Stratholme.
  /// </summary>
  public sealed class QuestStratholme : QuestData
  {
    private readonly LegendaryHero _arthas;
    private readonly Capital _stratholme;
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestStratholme"/> class.
    /// </summary>
    public QuestStratholme(Rectangle rescueRect, PreplacedUnitSystem preplacedUnitSystem, LegendaryHero arthas, Capital stratholme) : base("Blackrock and Roll",
      "The Blackrock clan has taken over Alterac, they must be eliminated for the safety of Lordaeron",
      "ReplaceableTextures\\CommandButtons\\BTNChaosBlademaster.blp")
    {
      _arthas = arthas;
      _stratholme = stratholme;
      AddObjective(new ObjectiveUnitIsDead(preplacedUnitSystem.GetUnit(Constants.UNIT_O00B_JUBEI_THOS_LEGION_DEMI)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N019_ALTERAC_MOUNTAINS_20GOLD_MIN)));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_HCAS_CASTLE_LORDAERON_T3, Constants.UNIT_HTOW_TOWN_HALL_LORDAERON_T1));
      AddObjective(new ObjectiveExpire(1470, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "Stratholme has been liberated, and its military is now free to assist the Kingdom of Lordaeron.";
    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all units in Stratholme";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
      _arthas.AddUnitDependency(_stratholme.Unit);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
      _arthas.AddUnitDependency(_stratholme.Unit);
    }
  }
}