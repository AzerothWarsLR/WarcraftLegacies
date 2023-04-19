using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common; 

namespace WarcraftLegacies.Source.Quests.CrisisSpawn
{
  /// <summary>
  /// Research 'Northrend Expidition' to gain a base at the shores of Dragonblight.
  /// </summary>
  public sealed class QuestCthunSpawnCaptain : QuestData
  {
    private readonly Rectangle _spawnLocation;
    private readonly unit _picker;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestCthunSpawCaptain"/> class.
    /// </summary>
    public QuestCthunSpawnCaptain(PreplacedUnitSystem preplacedUnitSystem, Rectangle spawnLocation) : base("Pick Cthun", "Blabla", "ReplaceableTextures\\CommandButtons\\BTNHumanTransport.blp")
    {
      _spawnLocation = spawnLocation;
      _picker = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS, new Point(12700, -29532));
      AddObjective(new ObjectiveEitherOf(
        new ObjectiveResearch(Constants.UPGRADE_R07E_FORTIFIED_HULLS, Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS),
        new ObjectiveTime(1590)));
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

      RemoveUnit(_picker);

      if (completingFaction.Player != null)
      {
        var spawn = _spawnLocation.Center;

        CreateStructureForced(completingFaction.Player, Constants.UNIT_N05A_VAULT_OF_THE_ETERNAL_PALACE_ILLIDARI_OTHER, -18477, -18214, 0, 256);
        CreateUnits(completingFaction.Player, Constants.UNIT_U019_DRONE_C_THUN_WORKER, spawn.X, spawn.Y, 270, 12);

        CreateUnits(completingFaction.Player, Constants.UNIT_N06I_SILITHID_WARRIOR_C_THUN_SILITHID_WARRIOR, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_O00L_SILITHID_REAVER_C_THUN_SILITHID_REAVER, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N05V_SHADOW_WEAVER_C_THUN_FACELESS_SHADOW_WEAVER, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N060_SILITHID_TUNNELER_C_THUN_SILITHID_TUNNELER, spawn.X, spawn.Y, 270, 12);

        CreateUnits(completingFaction.Player, Constants.UNIT_U00R_OLD_GOD, spawn.X, spawn.Y, 270, 1);

        completingFaction.Player.SetTeam(TeamSetup.Oldgods);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 2000);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 8000);

        if (GetLocalPlayer() == completingFaction.Player)
          SetCameraPosition(spawn.X, spawn.Y);

        completingFaction.Player.SetFaction(CthunSetup.Cthun);
      }
    }
  }
}