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
  public sealed class QuestNazjatarSpawnCaptain : QuestData
  {
    private readonly Rectangle _spawnLocation;
    private readonly unit _picker;
    private readonly unit _secondpick;
    private readonly LegendaryHero _azshara;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestNazjatarSpawnFootman"/> class.
    /// </summary>
    public QuestNazjatarSpawnCaptain(PreplacedUnitSystem preplacedUnitSystem, Rectangle spawnLocation, LegendaryHero azshara) : base("Pick Nazjatar", "The empire of Nazjatar will awaken.", "ReplaceableTextures\\CommandButtons\\BTNNagaSummoner.blp")
    {
      _spawnLocation = spawnLocation;
      _azshara = azshara;
      _picker = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS, new Point(13068, -29532));
      _secondpick = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS, new Point(12700, -29532));
      AddObjective(new ObjectiveEitherOf(
       new ObjectiveResearch(Constants.UPGRADE_R07E_FORTIFIED_HULLS, Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS),
       new ObjectiveTime(1590)));
      Shared = true;
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The empire of Nazjatar and it's forces awaken from the Abyss.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "You will spawn with Azshara and an army in the Abyss.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        SetPlayerTechMaxAllowed(player, Constants.UPGRADE_R07E_FORTIFIED_HULLS, 0);
      }

      KillNeutralHostileUnitsInRadius(-4200, 2450, 2000);

      RemoveUnit(_picker);

      SetUnitOwner(_secondpick, Player(16), true);

      if (completingFaction.Player != null)
      {
        var spawn = _spawnLocation.Center;

        CreateStructureForced(completingFaction.Player, Constants.UNIT_N045_TEMPLE_OF_AZSHARA_NZOTH_OTHER, -4200, 2450, 0, 256);

        CreateUnits(completingFaction.Player, Constants.UNIT_N0D7_DEEP_FORAGER_N_ZOTH_WORKER, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N0DT_TIDEMISTRESS_NZOTH, spawn.X, spawn.Y, 270, 6);

        CreateUnits(completingFaction.Player, Constants.UNIT_N0CA_NAGA_INCURSOR_NZOTH, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N0CE_HATCHLING_NZOTH, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N0CL_GARGANTUAN_SEA_TURTLE_NZOTH, spawn.X, spawn.Y, 270, 8);

        CreateUnits(completingFaction.Player, Constants.UNIT_N0CB_DEEPSEER_NZOTH, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N0CD_BLOODKIN_NZOTH, spawn.X, spawn.Y, 270, 12);

        CreateUnits(completingFaction.Player, Constants.UNIT_O060_RIPTIDE_DRAKE_NZOTH, spawn.X, spawn.Y, 270, 6);
        CreateUnits(completingFaction.Player, Constants.UNIT_U02J_TIDAL_TERROR_NZOTH, spawn.X, spawn.Y, 270, 4);

        CreateUnits(completingFaction.Player, Constants.UNIT_H01Q_IMMORTAL_GUARDIAN_NZOTH, spawn.X, spawn.Y, 270, 4);
        CreateUnits(completingFaction.Player, Constants.UNIT_N0CO_TRENCH_HYDRA_NZOTH, spawn.X, spawn.Y, 270, 2);

        _azshara.ForceCreate(completingFaction.Player, spawn, 270);

        completingFaction.Player.SetTeam(TeamSetup.Oldgods);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 2000);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 8000);

        if (GetLocalPlayer() == completingFaction.Player)
          SetCameraPosition(spawn.X, spawn.Y);

        completingFaction.Player.SetFaction(NazjatarSetup.Nazjatar);
      }
    }
  }
}