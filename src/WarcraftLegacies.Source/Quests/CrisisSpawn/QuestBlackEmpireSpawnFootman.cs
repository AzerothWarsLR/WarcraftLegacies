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
  /// <summary>
  /// Research 'Northrend Expidition' to gain a base at the shores of Dragonblight.
  /// </summary>
  public sealed class QuestBlackEmpireSpawnFootman : QuestData
  {
    private readonly Rectangle _spawnLocation;
    private readonly unit _picker;
    private readonly unit _secondpick;
    private readonly LegendaryHero _nzoth;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBlackEmpireSpawnFootman"/> class.
    /// </summary>
    public QuestBlackEmpireSpawnFootman(PreplacedUnitSystem preplacedUnitSystem, Rectangle spawnLocation, LegendaryHero nzoth) : base("Pick the Black Empire", "The Black Empire will awaken.", "ReplaceableTextures\\CommandButtons\\BTNNzothIcon.blp")
    {
      _spawnLocation = spawnLocation;
      _nzoth = nzoth;
      _picker = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS, new Point(13068, -29532));
      _secondpick = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS, new Point(12700, -29532));
      AddObjective(new ObjectiveEitherOf(
       new ObjectiveResearch(Constants.UPGRADE_R07W_FORTIFIED_HULLS, Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS),
       new ObjectiveTime(1590)));
      Shared = true;
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Black Empire and it's forces awaken from the Abyss.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "You will spawn with N'zoth and an army in the Maelstrom.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      var spawn = _spawnLocation.Center;
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        SetPlayerTechMaxAllowed(player, Constants.UPGRADE_R07W_FORTIFIED_HULLS, 0);
      }

      KillNeutralHostileUnitsInRadius(spawn.X, spawn.Y, 2000);

      RemoveUnit(_picker);

      SetUnitOwner(_secondpick, Player(16), true);

      if (completingFaction.Player != null)
      {

        CreateStructureForced(completingFaction.Player, Constants.UNIT_N0DU_PYRAMID_OF_MADNESS_NZOTH_OTHER, -1000, -1050, 0, 256);

        CreateUnits(completingFaction.Player, Constants.UNIT_N0B5_SCAVENGER_YOGG_WORKER, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N0B4_REAPER_YOGG, spawn.X, spawn.Y, 270, 6);

        CreateUnits(completingFaction.Player, Constants.UNIT_O01G_FACELESS_MARAUDER_YOGG, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_O04V_SOUL_HUNTER_YOGG, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_U029_STYGIAN_HULK_YOGG, spawn.X, spawn.Y, 270, 12);

        CreateUnits(completingFaction.Player, Constants.UNIT_N077_SORCERER_YOGG, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_O04Y_FATEWEAVER_YOGG, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_U02F_FORGOTTEN_ONE_YOGG, spawn.X, spawn.Y, 270, 2);

        CreateUnits(completingFaction.Player, Constants.UNIT_O04Z_FLYING_HORROR_YOGG, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N0AH_DEFORMED_CHIMERA_YOGG, spawn.X, spawn.Y, 270, 4);
        CreateUnits(completingFaction.Player, Constants.UNIT_H09F_GLADIATOR_YOGG, spawn.X, spawn.Y, 270, 12);

        _nzoth.ForceCreate(completingFaction.Player, spawn, 270);

        completingFaction.Player.SetTeam(TeamSetup.Oldgods);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 2000);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 8000);

        if (GetLocalPlayer() == completingFaction.Player)
          SetCameraPosition(spawn.X, spawn.Y);

        completingFaction.Player.SetFaction(BlackEmpireSetup.BlackEmpire);
      }
    }
  }
}