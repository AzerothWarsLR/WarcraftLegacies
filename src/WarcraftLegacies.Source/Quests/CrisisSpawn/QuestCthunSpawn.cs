using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.Libraries;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common; 

namespace WarcraftLegacies.Source.Quests.CrisisSpawn
{
  /// <summary>
  /// Research 'Northrend Expidition' to gain a base at the shores of Dragonblight.
  /// </summary>
  public sealed class QuestCthunSpawn : QuestData
  {
    private readonly Rectangle _spawnLocation;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestCthunSpawn"/> class.
    /// </summary>
    public QuestCthunSpawn(Rectangle spawnLocation) : base("Pick Cthun", "Blabla", "ReplaceableTextures\\CommandButtons\\BTNHumanTransport.blp")
    {
      _spawnLocation = spawnLocation;
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R06F_NORTHREND_EXPEDITION_LORDAERON, Constants.UNIT_HSHY_SHIPYARD_LORDAERON_SHIPYARD));
      Shared = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "Crown Prince Arthas, and what remains of his forces, have landed on the shores of Northrend and established a base camp.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "A new base near Dragonblight in Northrend, and Arthas revives there";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      KillNeutralHostileUnitsInRadius(-17512, -16776, 2000);
      if(completingFaction.Player != null)
      {
        CreateStructureForced(completingFaction.Player, Constants.UNIT_H01C_HUNTSMAN_LORDAERON, -18477, -18214, 0, 256);
        var spawn = _spawnLocation.Center;
        GeneralHelpers.CreateUnits(completingFaction.Player, Constants.UNIT_U00J_ARCANE_WAGON_QUEL_THALAS, spawn.X, spawn.Y, 270, 2);
      }
    
      completingFaction.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    }

    /// <inheritdoc/>
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}