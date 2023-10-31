using MacroTools;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class ScarletSetup
  {
    public static Faction? ScarletCrusade { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      ScarletCrusade = new Faction("Scarlet Crusade", PLAYER_COLOR_MAROON, "|cff800000",
        @"ReplaceableTextures/CommandButtons/BTNScarletKnight.blp")
      {
        StartingGold = 200,
        StartingLumber = 500,
        ControlPointDefenderUnitTypeId = Constants.UNIT_H09O_CONTROL_POINT_DEFENDER_CRUSADE,
        IntroText = @"You are playing as the zealous |cff940000Scarlet Crusade|r.

The Cult of the Damned has mobilized and is quietly spreading corruption throughout Lordaeron.

Build towers to detect the hidden cultists moving through the Kingdom and burn any buildings they have corrupted.

Your soldiers are weaker when alone, but gain substantial bonuses when paired with a variety of unit-types. 

Fortify your strongholds against the storm to come and make ready to unleash the Crusade on those who would defile your lands."
      };

      //Structures
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0BM_TOWN_HALL_CRUSADE_T1, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0BN_KEEP_CRUSADE_T2, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0BO_CASTLE_CRUSADE_T3, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0BP_FARMSTEAD_CRUSADE_FARM, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0A3_BLACKSMITH_CRUSADE_RESEARCH, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H09X_SHIPYARD_CRUSADE_SHIPYARD, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0AG_HALL_OF_SWORDS_CRUSADE_BARRACKS, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0BE_STUDIUM_CRUSADE_MAGIC, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0BL_ROOKERY_CRUSADE_BEAST, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_N035_DIVINE_BASTION_CRUSADE_SPECIAL, 1);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0BI_BOMBARD_TOWER_CRUSADE_TOWER, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0BJ_IMPROVED_BOMBARD_TOWER_CRUSADE_TOWER, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0BQ_ALTAR_OF_CRUSADERS_CRUSADE_ALTAR, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_N0D8_VENDOR_HALL_CRUSADE_SHOP, Faction.UNLIMITED);


      //Units
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H022_FARMER_DALARAN_WORKER, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H06B_TEMPLAR_LORDAERON, 6);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H08I_CRUSADER_SCARLET, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H09P_LONGBOWMAN_SCARLET, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H08L_CAVALIER_SCARLET, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_N068_INQUISITOR_SCARLET, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H08K_MONK_SCARLET, Faction.UNLIMITED);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_N09N_BISHOP_OF_THE_LIGHT_SCARLET, 6);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H09Q_CRIMSON_COMMANDER_SCARLET, 8);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_O06V_EAGLE_RIDER_SCARLET, 6);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_E01L_GRYPHON_MARKSMAN_SCARLET, 6);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_O04C_SERAPHIM_SCARLET, 6);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_O00X_ARCHANGEL_SCARLET, 3);


      //Heroes
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H08G_GRAND_CRUSADER_SCARLET, 1);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H0A2_SCARLET_COMMANDER_SCARLET, 1);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H08H_HIGH_INQUISITOR_SCARLET, 1);
      ScarletCrusade.ModObjectLimit(Constants.UNIT_H00Y_HIGH_GENERAL_SCARLET, 1);

      //Ships
      ScarletCrusade.ModObjectLimit(FourCC("hbot"), Faction.UNLIMITED); //Alliance Transport Ship
      ScarletCrusade.ModObjectLimit(FourCC("h0AR"), Faction.UNLIMITED); //Alliance Scout
      ScarletCrusade.ModObjectLimit(FourCC("h0AX"), Faction.UNLIMITED); //Alliance Frigate
      ScarletCrusade.ModObjectLimit(FourCC("h0B3"), Faction.UNLIMITED); //Alliance Fireship
      ScarletCrusade.ModObjectLimit(FourCC("h0B0"), Faction.UNLIMITED); //Alliance Galley
      ScarletCrusade.ModObjectLimit(FourCC("h0B6"), Faction.UNLIMITED); //Alliance Boarding
      ScarletCrusade.ModObjectLimit(FourCC("h0AN"), Faction.UNLIMITED); //Alliance Juggernaut
      ScarletCrusade.ModObjectLimit(FourCC("h0B7"), 6); //Alliance Bombard

      //Upgrades
      ScarletCrusade.ModObjectLimit(FourCC("R05D"), Faction.UNLIMITED); //Chaplain Adept Training
      ScarletCrusade.ModObjectLimit(FourCC("R04F"), Faction.UNLIMITED); //Inquisitor traiing
      ScarletCrusade.ModObjectLimit(FourCC("Rhse"), Faction.UNLIMITED); //Magic Sentry
      ScarletCrusade.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      ScarletCrusade.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry

      FactionManager.Register(ScarletCrusade);
    }
  }
}