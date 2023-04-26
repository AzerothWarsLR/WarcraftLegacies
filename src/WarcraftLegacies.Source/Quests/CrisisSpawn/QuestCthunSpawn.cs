using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
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
  public sealed class QuestCthunSpawn : QuestData
  {
    private readonly Rectangle _spawnLocation;
    private readonly unit _picker;
    private readonly unit _secondpick;
    private readonly LegendaryHero _cthun;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestCthunSpawn"/> class.
    /// </summary>
    public QuestCthunSpawn(PreplacedUnitSystem preplacedUnitSystem, Rectangle spawnLocation, LegendaryHero cthun) : base("Pick the Ahn'Qiraj Kingdom", "The old god C'thun will awaken in Ahn'qiraj", "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
    {
      _spawnLocation = spawnLocation;
      _cthun = cthun;
      _picker = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS, new Point(13068, -29532));
      _secondpick = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS, new Point(12700, -29532));
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R086_FORTIFIED_HULLS, Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS));
      Shared = true;
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Ahn'qiraj Kingdom and it's forces awaken.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "You will spawn with C'thun and an army in Ahn'qiraj.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      var spawn = _spawnLocation.Center;
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        SetPlayerTechMaxAllowed(player, Constants.UPGRADE_R086_FORTIFIED_HULLS, 0);
      }

      KillNeutralHostileUnitsInRadius(spawn.X, spawn.Y, 2000);

      RemoveUnit(_picker);

      SetUnitOwner(_secondpick, Player(16), true);

      if (completingFaction.Player == Player(16))
        RemoveUnit(_secondpick);

      if (completingFaction.Player != null)
      {

        CreateStructureForced(completingFaction.Player, Constants.UNIT_N05A_TEMPLE_OF_AHN_QIRAJ_CTHUN_OTHER, -18458, -18200, 0, 256);

        CreateUnits(completingFaction.Player, Constants.UNIT_U019_DRONE_C_THUN_WORKER, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_O000_SILITHID_COLOSSUS_C_THUN_ELITES, spawn.X, spawn.Y, 270, 6);

        CreateUnits(completingFaction.Player, Constants.UNIT_N06I_SILITHID_WARRIOR_C_THUN_SILITHID_WARRIOR, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_O00L_SILITHID_REAVER_C_THUN_SILITHID_REAVER, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_U013_GIANT_SCARAB_C_THUN_GIANT_SCARAB, spawn.X, spawn.Y, 270, 12);

        CreateUnits(completingFaction.Player, Constants.UNIT_N060_SILITHID_TUNNELER_C_THUN_SILITHID_TUNNELER, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N05V_SHADOW_WEAVER_C_THUN_FACELESS_SHADOW_WEAVER, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_O001_TOL_VIR_STATUE_C_THUN_TOL_VIR_STATUE, spawn.X, spawn.Y, 270, 6);

        CreateUnits(completingFaction.Player, Constants.UNIT_H01K_SILITHID_OVERLORD_C_THUN_OVERLORD, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_O02N_SILITHID_WASP_CTHUN, spawn.X, spawn.Y, 270, 24);
        CreateUnits(completingFaction.Player, Constants.UNIT_H01N_VILE_CORRUPTER_C_THUN_FACELESS_CORRUPTOR, spawn.X, spawn.Y, 270, 4);

        _cthun.ForceCreate(completingFaction.Player, spawn, 270);

        completingFaction.Player.SetTeam(TeamSetup.Oldgods);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, (int)((GameTime.GetGameTime() / 60) * 100));
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 8000);

        if (GetLocalPlayer() == completingFaction.Player)
          SetCameraPosition(spawn.X, spawn.Y);

        completingFaction.Player.SetFaction(CthunSetup.Cthun);
      }
    }
  }
}