using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public static class Kultiras
  {
    public static void Setup()
    {
      //Abilities
      var summonSeaElemental = AbilityFactory.CreateSummonWaterElemental(
        newRawcode: "ksum",
        iconName: "WaterElemental",
        summonedUnit: null,
        summonCount: new int[] { 1 },
        levels: 1);

      //Units
      var tidepriest = UnitFactory.CreateUnit(
        baseType: UnitType.Chaplain,
        newRawCode: "Ktid",
        name: "Tidesage",
        model: @"MageKulTirasV1.01.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNEmissary.blp",
        abilities: new Ability[] { summonSeaElemental });

      var thornspeaker = UnitFactory.CreateUnit(
        baseType: UnitType.Druidoftheclaw,
        newRawCode: "Ktho",
        name: "Thornspeaker",
        model: @"DruidoftheClawKulTirasV1.02.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNDruidOfTheClaw.blp");

      var revenant = UnitFactory.CreateUnit(
        baseType: UnitType.Revenantofthetides,
        newRawCode: "Krev",
        name: "Tide Revenant",
        model: @"units\creeps\RevenantOfTheWaves\RevenantOfTheWaves",
        icon: @"ReplaceableTextures\CommandButtons\BTNRevenant.blp");

      var marine = UnitFactory.CreateUnit(
        baseType: UnitType.Highelvenswordsman,
        newRawCode: "Kdec",
        name: "Marine",
        model: @"MageKulTirasV1.01.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNEmissary.blp");

      var stormSorcerer = UnitFactory.CreateUnit(
        baseType: UnitType.Bloodmage,
        newRawCode: "Kdec",
        name: "Storm Sorcerer",
        model: @"MageKulTirasV1.01.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNEmissary.blp");

      var warship = UnitFactory.CreateUnit(
        baseType: UnitType.Humanbattleship,
        newRawCode: "Kdec",
        name: "Warship",
        model: @"MageKulTirasV1.01.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNEmissary.blp");

      var seaGiant = UnitFactory.CreateUnit(
        baseType: UnitType.Seagiant,
        newRawCode: "Kdec",
        name: "Sea Giant",
        model: @"MageKulTirasV1.01.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNEmissary.blp");

      var musketeer = UnitFactory.CreateUnit(
        baseType: UnitType.Rifleman,
        newRawCode: "Kdec",
        name: "Musketeer",
        model: @"MageKulTirasV1.01.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNEmissary.blp");

      var bomber = UnitFactory.CreateUnit(
        baseType: UnitType.Flyingmachine,
        newRawCode: "Kdec",
        name: "Bomber",
        model: @"MageKulTirasV1.01.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNEmissary.blp");

      var siegeTank = UnitFactory.CreateUnit(
        baseType: UnitType.Siegeengine,
        newRawCode: "Kdec",
        name: "Siege Tank",
        model: @"MageKulTirasV1.01.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNEmissary.blp");

      var cannonteam = UnitFactory.CreateUnit(
        baseType: UnitType.Mortarteam,
        newRawCode: "Kdec",
        name: "Cannon Team",
        model: @"MageKulTirasV1.01.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNEmissary.blp");

      //Upgrades
      var tidepriestUpgrade = UpgradeFactory.CreateCasterUpgrade(
        newRawCode: "Koft",
        casterUnit: tidepriest,
        casterAbilities: new Ability[]{ summonSeaElemental });

      var thornspeakerUpgrade = UpgradeFactory.CreateCasterUpgrade(
        newRawCode: "Ktho",
        casterUnit: thornspeaker,
        casterAbilities: null);

      //Structures
      var townHall = BuildingFactory.CreateBuilding(
        baseType: UnitType.Arcanesanctum,
        newRawCode: "Karc",
        name: "Arcane Sanctum",
        units: new Unit[] { tidepriest, thornspeaker, revenant },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var keep = BuildingFactory.CreateBuilding(
        baseType: UnitType.Keep,
        newRawCode: "Karc",
        name: "Arcane Sanctum",
        units: new Unit[] { tidepriest, thornspeaker, revenant },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var castle = BuildingFactory.CreateBuilding(
        baseType: UnitType.Castle,
        newRawCode: "Karc",
        name: "Arcane Sanctum",
        units: new Unit[] { tidepriest, thornspeaker, revenant },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var arcaneSanctum = BuildingFactory.CreateBuilding(
        baseType: UnitType.Arcanesanctum,
        newRawCode: "Karc",
        name: "Arcane Sanctum",
        units: new Unit[] { tidepriest, thornspeaker, revenant },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var farm = BuildingFactory.CreateBuilding(
        baseType: UnitType.Farm,
        newRawCode: "Karc",
        name: "Farm");

      var altarOfAdmirals = BuildingFactory.CreateBuilding(
        baseType: UnitType.Altarofkings,
        newRawCode: "Karc",
        name: "Altar of Admirals");

      var garrison = BuildingFactory.CreateBuilding(
        baseType: UnitType.Humanbarracks,
        newRawCode: "Karc",
        name: "Garrison",
        units: new Unit[] { marine, musketeer, seaGiant },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var blacksmith = BuildingFactory.CreateBuilding(
        baseType: UnitType.Arcanesanctum,
        newRawCode: "Karc",
        name: "Blacksmith",
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var workshop = BuildingFactory.CreateBuilding(
        baseType: UnitType.Arcanesanctum,
        newRawCode: "Karc",
        name: "Workshop",
        units: new Unit[] { cannonteam, siegeTank, bomber },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var scoutTower = BuildingFactory.CreateBuilding(
        baseType: UnitType.Arcanesanctum,
        newRawCode: "Karc",
        name: "Scout Tower",
        units: new Unit[] { tidepriest, thornspeaker, revenant },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var guardTower = BuildingFactory.CreateBuilding(
        baseType: UnitType.Arcanesanctum,
        newRawCode: "Karc",
        name: "Scout Tower",
        units: new Unit[] { tidepriest, thornspeaker, revenant },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var cannonTower = BuildingFactory.CreateBuilding(
        baseType: UnitType.Arcanesanctum,
        newRawCode: "Karc",
        name: "Scout Tower",
        units: new Unit[] { tidepriest, thornspeaker, revenant },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var marketplace = BuildingFactory.CreateBuilding(
        baseType: UnitType.Arcanesanctum,
        newRawCode: "Karc",
        name: "Scout Tower",
        units: new Unit[] { tidepriest, thornspeaker, revenant },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      var shipyard = BuildingFactory.CreateBuilding(
        baseType: UnitType.Arcanesanctum,
        newRawCode: "Karc",
        name: "Scout Tower",
        units: new Unit[] { tidepriest, thornspeaker, revenant },
        upgrades: new Upgrade[] { tidepriestUpgrade, thornspeakerUpgrade });

      //Units
      var deckhand = UnitFactory.CreateWorker(
        baseType: UnitType.Peasant,
        newRawCode: "Kdec",
        name: "Deckhand",
        model: @"MageKulTirasV1.01.mdl",
        icon: @"ReplaceableTextures\CommandButtons\BTNEmissary.blp",
        structuresBuilt: new Unit[] { townHall, arcaneSanctum, farm, altarOfAdmirals,
          garrison, blacksmith, workshop, scoutTower, marketplace, shipyard });
    }
  }
}