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
  public sealed class QuestTwilightHammerSpawn : QuestData
  {
    private readonly Rectangle _spawnLocation;
    private readonly unit _picker;
    private readonly unit _secondpick;
    private readonly LegendaryHero _cho;
    private readonly LegendaryHero _azil;
    private readonly LegendaryHero _emberscar;
    private readonly LegendaryHero _ignacious;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestCthunSpawn"/> class.
    /// </summary>
    public QuestTwilightHammerSpawn(PreplacedUnitSystem preplacedUnitSystem, Rectangle spawnLocation, LegendaryHero cho, LegendaryHero azil, LegendaryHero emberscar, LegendaryHero ignacious) : base("Pick the Twilight Hammer Clan", "Cho'gall and his Twilight Hammer clan will spawn in the Twilight Highlands", "ReplaceableTextures\\CommandButtons\\BTNChogall.blp")
    {
      _spawnLocation = spawnLocation;
      _cho = cho;
      _azil = azil;
      _emberscar = emberscar;
      _ignacious = ignacious;
      _picker = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS, new Point(13068, -29532));
      _secondpick = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS, new Point(12700, -29532));
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R08K_FORTIFIED_HULLS, Constants.UNIT_N0DR_CRISIS_FACTION_PICKER_OLD_GODS));
      Shared = true;
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Twilight Hammer clan will reveal themselves in the Twilight Highlands";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "You will spawn with Cho'gall and an army in the Twilight Highlands.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      var spawn = _spawnLocation.Center;
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        SetPlayerTechMaxAllowed(player, Constants.UPGRADE_R08K_FORTIFIED_HULLS, 0);
      }

      KillNeutralHostileUnitsInRadius(spawn.X, spawn.Y, 2000);

      RemoveUnit(_picker);

      SetUnitOwner(_secondpick, Player(16), true);

      if (completingFaction.Player == Player(16))
        RemoveUnit(_secondpick);

      if (completingFaction.Player != null)
      {

        CreateStructureForced(completingFaction.Player, Constants.UNIT_H05U_TWILIGHT_CITADEL_TWILIGHT_T3, 19087, -7370, 180, 256);

        CreateUnits(completingFaction.Player, Constants.UNIT_O04B_CULTIST_TWILIGHT_HAMMER_WORKER, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_O04I_BATTLEMASTER_TWILIGHT, spawn.X, spawn.Y, 270, 6);

        CreateUnits(completingFaction.Player, Constants.UNIT_O01H_TWILIGHT_HAMMER_ENFORCER_TWILIGHT, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N087_PHASE_GRENADIER_TWILIGHT, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_O04K_SKULL_CATAPULT_TWILIGHT, spawn.X, spawn.Y, 270, 6);

        CreateUnits(completingFaction.Player, Constants.UNIT_U01T_HERALD_TWILIGHT, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N07X_OGRE_MAGI_TWILIGHT, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N09O_ORCISH_DEATH_KNIGHT_TWILIGHT, spawn.X, spawn.Y, 270, 6);

        CreateUnits(completingFaction.Player, Constants.UNIT_U01Y_DEATHWING_TWILIGHT, spawn.X, spawn.Y, 270, 1);

        CreateUnits(completingFaction.Player, Constants.UNIT_N083_TWILIGHT_DRAGONSPAWN_TWILIGHT, spawn.X, spawn.Y, 270, 12);
        CreateUnits(completingFaction.Player, Constants.UNIT_N051_NETHER_DRAGON_TWILIGHT, spawn.X, spawn.Y, 270, 4);
        CreateUnits(completingFaction.Player, Constants.UNIT_O04J_VOID_RIDER_TWILIGHT, spawn.X, spawn.Y, 270, 8);

        _azil.StartingXp = (int)(GameTime.GetGameTime() * 6);
        _emberscar.StartingXp = (int)(GameTime.GetGameTime() * 6);
        _ignacious.StartingXp = (int)(GameTime.GetGameTime() * 6);
        _cho.StartingXp = (int)(GameTime.GetGameTime() * 7);
        _cho.ForceCreate(completingFaction.Player, spawn, 270);

        completingFaction.Player.SetTeam(TeamSetup.Oldgods);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, (int)((GameTime.GetGameTime() / 60) * 100));
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 8000);

        if (GetLocalPlayer() == completingFaction.Player)
          SetCameraPosition(spawn.X, spawn.Y);

        completingFaction.Player.SetFaction(TwilightHammerSetup.TwilightHammer);
      }
    }
  }
}