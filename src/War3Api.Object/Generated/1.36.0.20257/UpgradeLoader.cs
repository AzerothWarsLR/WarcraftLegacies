using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    internal class UpgradeLoader
    {
        protected virtual Upgrade LoadHumanMeleeAttack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanMeleeAttack, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "melee";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 75;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 125;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "ratd";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanRangedAttack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanRangedAttack, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "ranged";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 75;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 125;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "ratd";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanHammerBounce(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanHammerBounce, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 125;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 225;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 45;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rasd";
            upgrade.DataEffect1_gba1 = 200f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanArmor(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanArmor, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "armor";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 125;
            upgrade.StatsGoldIncrement = 25;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rarm";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanGyroBombs(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanGyroBombs, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 35;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "renw";
            upgrade.DataEffect1_gba1 = 3f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanArchitecture(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanArchitecture, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "armor";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 125;
            upgrade.StatsGoldIncrement = 25;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 25;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rarm";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rhpo";
            upgrade.DataEffect2_gba2 = 0.1f;
            upgrade.DataEffect2_gmo2 = 0.1f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanFootmanDefend(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanFootmanDefend, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 45;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanAnimalBreeding(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanAnimalBreeding, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 125;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 125;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rhpx";
            upgrade.DataEffect1_gba1 = 100f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanPriestTraining(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanPriestTraining, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 100f;
            upgrade.DataEffect1_gmo1 = 100f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.325f;
            upgrade.DataEffect2_gmo2 = 0.325f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rhpx";
            upgrade.DataEffect3_gba3 = 40f;
            upgrade.DataEffect3_gmo3 = 40f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "ratd";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanSorceressTraining(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanSorceressTraining, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 100f;
            upgrade.DataEffect1_gmo1 = 100f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.325f;
            upgrade.DataEffect2_gmo2 = 0.325f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rhpx";
            upgrade.DataEffect3_gba3 = 40f;
            upgrade.DataEffect3_gmo3 = 40f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "ratd";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanLeatherArmor(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanLeatherArmor, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "armor";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 75;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rarm";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanRiflemanPlusRange(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanRiflemanPlusRange, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 125;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 30;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "ratr";
            upgrade.DataEffect1_gba1 = 200f;
            upgrade.DataEffect1_gmo1 = 200f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanLumberHarvesting(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanLumberHarvesting, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 100;
            upgrade.StatsLumberBase = 0;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rlum";
            upgrade.DataEffect1_gba1 = 10f;
            upgrade.DataEffect1_gmo1 = 10f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rlev";
            upgrade.DataEffect2_gba2 = 1f;
            upgrade.DataEffect2_gmo2 = 1f;
            upgrade.DataEffect2_gco2 = "Ahlh";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanMagicalSentinal(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanMagicalSentinal, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 30;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanFlare(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanFlare, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 30;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanControlMagic(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanControlMagic, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 45;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanRocketTank(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanRocketTank, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rtma";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "hmtt";
            upgrade.DataEffect2_gef2Raw = "rtma";
            upgrade.DataEffect2_gba2 = -1f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "hrtt";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 1;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanBackpack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanBackpack, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 25;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 20;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanFlakCannon(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanFlakCannon, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanFragShards(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanFragShards, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanCloudResearch(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanCloudResearch, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 35;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadHumanSunderingBlades(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.HumanSunderingBlades, db);
            upgrade.StatsRaceRaw = "human";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcMeleeAttack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcMeleeAttack, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "melee";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "ratd";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcRangedAttack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcRangedAttack, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "ranged";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "ratd";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcArmor(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcArmor, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "armor";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 75;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 150;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rarm";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcWarDrumsDamage(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcWarDrumsDamage, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "raud";
            upgrade.DataEffect1_gba1 = 0.1f;
            upgrade.DataEffect1_gmo1 = 0.1f;
            upgrade.DataEffect1_gco1 = "Aakb";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcPillage(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcPillage, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 25;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 45;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcGruntBerserk(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcGruntBerserk, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rhpx";
            upgrade.DataEffect1_gba1 = 125f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "ratx";
            upgrade.DataEffect2_gba2 = 3f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcTaurenSmash(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcTaurenSmash, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 175;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rlev";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "Awar";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcRaiderEnsare(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcRaiderEnsare, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcWyvernVenomSpear(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcWyvernVenomSpear, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcWitchDoctorTraining(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcWitchDoctorTraining, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 100f;
            upgrade.DataEffect1_gmo1 = 100f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.325f;
            upgrade.DataEffect2_gmo2 = 0.325f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rhpx";
            upgrade.DataEffect3_gba3 = 40f;
            upgrade.DataEffect3_gmo3 = 40f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "ratd";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcShamanTraining(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcShamanTraining, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 100f;
            upgrade.DataEffect1_gmo1 = 100f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.325f;
            upgrade.DataEffect2_gmo2 = 0.325f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rhpx";
            upgrade.DataEffect3_gba3 = 40f;
            upgrade.DataEffect3_gmo3 = 40f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "ratd";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcSpikedBarricade(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcSpikedBarricade, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 25;
            upgrade.StatsGoldIncrement = 25;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 25;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rspi";
            upgrade.DataEffect1_gba1 = 5f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rspp";
            upgrade.DataEffect2_gba2 = 0.2f;
            upgrade.DataEffect2_gmo2 = 0.3f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rlev";
            upgrade.DataEffect3_gba3 = 1f;
            upgrade.DataEffect3_gmo3 = 1f;
            upgrade.DataEffect3_gco3 = "Aosp";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcTrollRegeneration(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcTrollRegeneration, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 35;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rhpr";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcLiquidFire(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcLiquidFire, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 125;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 75;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcChaosConversion(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcChaosConversion, db);
            upgrade.StatsRaceRaw = "demon";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 0;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 0;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 0;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 1;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcSpiritwalkerTraining(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcSpiritwalkerTraining, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 150f;
            upgrade.DataEffect1_gmo1 = 150f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.42f;
            upgrade.DataEffect2_gmo2 = 0.42f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rhpx";
            upgrade.DataEffect3_gba3 = 60f;
            upgrade.DataEffect3_gmo3 = 60f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "ratd";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcReinforcedDefense(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcReinforcedDefense, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 175;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rart";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcBerserkers(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcBerserkers, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 175;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rtma";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "ohun";
            upgrade.DataEffect2_gef2Raw = "rtma";
            upgrade.DataEffect2_gba2 = -1f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "otbk";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 1;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcBackpack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcBackpack, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 25;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 20;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadOrcNaptha(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcNaptha, db);
            upgrade.StatsRaceRaw = "orc";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 30;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadUnholyStrength(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadUnholyStrength, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "melee";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 125;
            upgrade.StatsGoldIncrement = 75;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "ratd";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadCreatureAttack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadCreatureAttack, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "ranged";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 75;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "ratd";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadUnholyArmor(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadUnholyArmor, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "armor";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 125;
            upgrade.StatsGoldIncrement = 75;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rarm";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadGhoulCannibalize(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadGhoulCannibalize, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 0;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 15;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadGhoulFrenzy(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadGhoulFrenzy, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 45;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rats";
            upgrade.DataEffect1_gba1 = 0.35f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmvx";
            upgrade.DataEffect2_gba2 = 80f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadFiendWeb(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadFiendWeb, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 30;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadGargoyleStone(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadGargoyleStone, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadNecromancerTraining(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadNecromancerTraining, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 30;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 100f;
            upgrade.DataEffect1_gmo1 = 100f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.325f;
            upgrade.DataEffect2_gmo2 = 0.325f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rhpx";
            upgrade.DataEffect3_gba3 = 40f;
            upgrade.DataEffect3_gmo3 = 40f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "ratd";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadBansheeTraining(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadBansheeTraining, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 100f;
            upgrade.DataEffect1_gmo1 = 100f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.325f;
            upgrade.DataEffect2_gmo2 = 0.325f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rhpx";
            upgrade.DataEffect3_gba3 = 40f;
            upgrade.DataEffect3_gmo3 = 40f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "ratd";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadFrostWyrmBreath(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadFrostWyrmBreath, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 275;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadSkeletonLifeSpan(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadSkeletonLifeSpan, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 15;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rrai";
            upgrade.DataEffect1_gba1 = 20f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadCreatureArmor(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadCreatureArmor, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "armor";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 125;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rarm";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadPlagueCloud(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadPlagueCloud, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 200;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 45;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadSkeletalMastery(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadSkeletalMastery, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 200;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 175;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 30;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rlev";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "Arai";
            upgrade.DataEffect2_gef2Raw = "rrai";
            upgrade.DataEffect2_gba2 = 20f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadBurrowing(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadBurrowing, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 45;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadAvengerTransform(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadAvengerTransform, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadExhumeCorpses(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadExhumeCorpses, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 20;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadUndeadBackpack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.UndeadBackpack, db);
            upgrade.StatsRaceRaw = "undead";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 25;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 20;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfStrengthOfMoon(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfStrengthOfMoon, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "melee";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 125;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "ratd";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfStrengthOfWild(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfStrengthOfWild, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "ranged";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 75;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "ratd";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfMoonArmor(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfMoonArmor, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "armor";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 75;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rarm";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfReinforcedHides(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfReinforcedHides, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "armor";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rarm";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfUltravision(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfUltravision, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 45;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfNatureSBlessing(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfNatureSBlessing, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 200;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rmvx";
            upgrade.DataEffect1_gba1 = 40f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rarm";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfScout(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfScout, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 20;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfMoonGlaiveUpgrade(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfMoonGlaiveUpgrade, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 35;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "ratc";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfImprovedBows(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfImprovedBows, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 35;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "ratr";
            upgrade.DataEffect1_gba1 = 200f;
            upgrade.DataEffect1_gmo1 = 200f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfMarksmanship(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfMarksmanship, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 175;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "ratx";
            upgrade.DataEffect1_gba1 = 4f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfDoTTraining(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfDoTTraining, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 100f;
            upgrade.DataEffect1_gmo1 = 100f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.325f;
            upgrade.DataEffect2_gmo2 = 0.325f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rhpx";
            upgrade.DataEffect3_gba3 = 40f;
            upgrade.DataEffect3_gmo3 = 40f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "ratd";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfDoCTraining(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfDoCTraining, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 25;
            upgrade.StatsTimeIncrement = 10;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 100f;
            upgrade.DataEffect1_gmo1 = 100f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.325f;
            upgrade.DataEffect2_gmo2 = 0.325f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rhpx";
            upgrade.DataEffect3_gba3 = 75f;
            upgrade.DataEffect3_gmo3 = 75f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "ratd";
            upgrade.DataEffect4_gba4 = 1f;
            upgrade.DataEffect4_gmo4 = 1f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfAbolishMagic(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfAbolishMagic, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 45;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfCorrosiveBreath(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfCorrosiveBreath, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 125;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 225;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "renw";
            upgrade.DataEffect1_gba1 = 3f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfHippogryphTaming(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfHippogryphTaming, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 30;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfImpalingBolt(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfImpalingBolt, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 125;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rasd";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "renw";
            upgrade.DataEffect2_gba2 = 2f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfResistantSkin(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfResistantSkin, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 75;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfHardenedSkin(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfHardenedSkin, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 175;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfEnchantedBears(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfEnchantedBears, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 25;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 20;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfEnchantedCrows(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfEnchantedCrows, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 25;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 20;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfWellSpring(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfWellSpring, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 75;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 150;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 30;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 125f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.52f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNightelfBackpack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NightelfBackpack, db);
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 25;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 20;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadGlyphOfFortification(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.GlyphOfFortification, db);
            upgrade.StatsRaceRaw = "unknown";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 50;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rarm";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rhpo";
            upgrade.DataEffect2_gba2 = 0.2f;
            upgrade.DataEffect2_gmo2 = 0.2f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadGlyphOfUltravision(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.GlyphOfUltravision, db);
            upgrade.StatsRaceRaw = "unknown";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 100;
            upgrade.StatsLumberIncrement = 50;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rauv";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNagaMyrmidonEnsnare(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NagaMyrmidonEnsnare, db);
            upgrade.StatsRaceRaw = "naga";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 40;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNagaSeaWitchTraining(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NagaSeaWitchTraining, db);
            upgrade.StatsRaceRaw = "naga";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rmnx";
            upgrade.DataEffect1_gba1 = 100f;
            upgrade.DataEffect1_gmo1 = 100f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "rmnr";
            upgrade.DataEffect2_gba2 = 0.325f;
            upgrade.DataEffect2_gmo2 = 0.325f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "rhpx";
            upgrade.DataEffect3_gba3 = 40f;
            upgrade.DataEffect3_gmo3 = 40f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "ratd";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNagaAbolishMagic(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NagaAbolishMagic, db);
            upgrade.StatsRaceRaw = "naga";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 50;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 45;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNagaAttack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NagaAttack, db);
            upgrade.StatsRaceRaw = "naga";
            upgrade.StatsClassRaw = "melee";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 75;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 150;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "ratd";
            upgrade.DataEffect1_gba1 = 1f;
            upgrade.DataEffect1_gmo1 = 1f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNagaArmor(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NagaArmor, db);
            upgrade.StatsRaceRaw = "naga";
            upgrade.StatsClassRaw = "armor";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 125;
            upgrade.StatsGoldIncrement = 100;
            upgrade.StatsLumberBase = 75;
            upgrade.StatsLumberIncrement = 150;
            upgrade.StatsTimeBase = 60;
            upgrade.StatsTimeIncrement = 15;
            upgrade.DataEffect1_gef1Raw = "rarm";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 0;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        protected virtual Upgrade LoadNagaSubmerge(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.NagaSubmerge, db);
            upgrade.StatsRaceRaw = "naga";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 25;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 25;
            upgrade.StatsLumberIncrement = 0;
            upgrade.StatsTimeBase = 20;
            upgrade.StatsTimeIncrement = 0;
            upgrade.DataEffect1_gef1Raw = "_";
            upgrade.DataEffect1_gba1 = 0f;
            upgrade.DataEffect1_gmo1 = 0f;
            upgrade.DataEffect1_gco1 = "-";
            upgrade.DataEffect2_gef2Raw = "_";
            upgrade.DataEffect2_gba2 = 0f;
            upgrade.DataEffect2_gmo2 = 0f;
            upgrade.DataEffect2_gco2 = "-";
            upgrade.DataEffect3_gef3Raw = "_";
            upgrade.DataEffect3_gba3 = 0f;
            upgrade.DataEffect3_gmo3 = 0f;
            upgrade.DataEffect3_gco3 = "-";
            upgrade.DataEffect4_gef4Raw = "_";
            upgrade.DataEffect4_gba4 = 0f;
            upgrade.DataEffect4_gmo4 = 0f;
            upgrade.DataEffect4_gco4 = "-";
            upgrade.StatsTransferWithUnitOwnershipRaw = 1;
            upgrade.StatsAppliesToAllUnitsRaw = 0;
            return upgrade;
        }

        public Upgrade Load(UpgradeType upgradeType, ObjectDatabaseBase db)
        {
            return upgradeType switch
            {
            UpgradeType.HumanMeleeAttack => LoadHumanMeleeAttack(db), UpgradeType.HumanRangedAttack => LoadHumanRangedAttack(db), UpgradeType.HumanHammerBounce => LoadHumanHammerBounce(db), UpgradeType.HumanArmor => LoadHumanArmor(db), UpgradeType.HumanGyroBombs => LoadHumanGyroBombs(db), UpgradeType.HumanArchitecture => LoadHumanArchitecture(db), UpgradeType.HumanFootmanDefend => LoadHumanFootmanDefend(db), UpgradeType.HumanAnimalBreeding => LoadHumanAnimalBreeding(db), UpgradeType.HumanPriestTraining => LoadHumanPriestTraining(db), UpgradeType.HumanSorceressTraining => LoadHumanSorceressTraining(db), UpgradeType.HumanLeatherArmor => LoadHumanLeatherArmor(db), UpgradeType.HumanRiflemanPlusRange => LoadHumanRiflemanPlusRange(db), UpgradeType.HumanLumberHarvesting => LoadHumanLumberHarvesting(db), UpgradeType.HumanMagicalSentinal => LoadHumanMagicalSentinal(db), UpgradeType.HumanFlare => LoadHumanFlare(db), UpgradeType.HumanControlMagic => LoadHumanControlMagic(db), UpgradeType.HumanRocketTank => LoadHumanRocketTank(db), UpgradeType.HumanBackpack => LoadHumanBackpack(db), UpgradeType.HumanFlakCannon => LoadHumanFlakCannon(db), UpgradeType.HumanFragShards => LoadHumanFragShards(db), UpgradeType.HumanCloudResearch => LoadHumanCloudResearch(db), UpgradeType.HumanSunderingBlades => LoadHumanSunderingBlades(db), UpgradeType.OrcMeleeAttack => LoadOrcMeleeAttack(db), UpgradeType.OrcRangedAttack => LoadOrcRangedAttack(db), UpgradeType.OrcArmor => LoadOrcArmor(db), UpgradeType.OrcWarDrumsDamage => LoadOrcWarDrumsDamage(db), UpgradeType.OrcPillage => LoadOrcPillage(db), UpgradeType.OrcGruntBerserk => LoadOrcGruntBerserk(db), UpgradeType.OrcTaurenSmash => LoadOrcTaurenSmash(db), UpgradeType.OrcRaiderEnsare => LoadOrcRaiderEnsare(db), UpgradeType.OrcWyvernVenomSpear => LoadOrcWyvernVenomSpear(db), UpgradeType.OrcWitchDoctorTraining => LoadOrcWitchDoctorTraining(db), UpgradeType.OrcShamanTraining => LoadOrcShamanTraining(db), UpgradeType.OrcSpikedBarricade => LoadOrcSpikedBarricade(db), UpgradeType.OrcTrollRegeneration => LoadOrcTrollRegeneration(db), UpgradeType.OrcLiquidFire => LoadOrcLiquidFire(db), UpgradeType.OrcChaosConversion => LoadOrcChaosConversion(db), UpgradeType.OrcSpiritwalkerTraining => LoadOrcSpiritwalkerTraining(db), UpgradeType.OrcReinforcedDefense => LoadOrcReinforcedDefense(db), UpgradeType.OrcBerserkers => LoadOrcBerserkers(db), UpgradeType.OrcBackpack => LoadOrcBackpack(db), UpgradeType.OrcNaptha => LoadOrcNaptha(db), UpgradeType.UndeadUnholyStrength => LoadUndeadUnholyStrength(db), UpgradeType.UndeadCreatureAttack => LoadUndeadCreatureAttack(db), UpgradeType.UndeadUnholyArmor => LoadUndeadUnholyArmor(db), UpgradeType.UndeadGhoulCannibalize => LoadUndeadGhoulCannibalize(db), UpgradeType.UndeadGhoulFrenzy => LoadUndeadGhoulFrenzy(db), UpgradeType.UndeadFiendWeb => LoadUndeadFiendWeb(db), UpgradeType.UndeadGargoyleStone => LoadUndeadGargoyleStone(db), UpgradeType.UndeadNecromancerTraining => LoadUndeadNecromancerTraining(db), UpgradeType.UndeadBansheeTraining => LoadUndeadBansheeTraining(db), UpgradeType.UndeadFrostWyrmBreath => LoadUndeadFrostWyrmBreath(db), UpgradeType.UndeadSkeletonLifeSpan => LoadUndeadSkeletonLifeSpan(db), UpgradeType.UndeadCreatureArmor => LoadUndeadCreatureArmor(db), UpgradeType.UndeadPlagueCloud => LoadUndeadPlagueCloud(db), UpgradeType.UndeadSkeletalMastery => LoadUndeadSkeletalMastery(db), UpgradeType.UndeadBurrowing => LoadUndeadBurrowing(db), UpgradeType.UndeadAvengerTransform => LoadUndeadAvengerTransform(db), UpgradeType.UndeadExhumeCorpses => LoadUndeadExhumeCorpses(db), UpgradeType.UndeadBackpack => LoadUndeadBackpack(db), UpgradeType.NightelfStrengthOfMoon => LoadNightelfStrengthOfMoon(db), UpgradeType.NightelfStrengthOfWild => LoadNightelfStrengthOfWild(db), UpgradeType.NightelfMoonArmor => LoadNightelfMoonArmor(db), UpgradeType.NightelfReinforcedHides => LoadNightelfReinforcedHides(db), UpgradeType.NightelfUltravision => LoadNightelfUltravision(db), UpgradeType.NightelfNatureSBlessing => LoadNightelfNatureSBlessing(db), UpgradeType.NightelfScout => LoadNightelfScout(db), UpgradeType.NightelfMoonGlaiveUpgrade => LoadNightelfMoonGlaiveUpgrade(db), UpgradeType.NightelfImprovedBows => LoadNightelfImprovedBows(db), UpgradeType.NightelfMarksmanship => LoadNightelfMarksmanship(db), UpgradeType.NightelfDoTTraining => LoadNightelfDoTTraining(db), UpgradeType.NightelfDoCTraining => LoadNightelfDoCTraining(db), UpgradeType.NightelfAbolishMagic => LoadNightelfAbolishMagic(db), UpgradeType.NightelfCorrosiveBreath => LoadNightelfCorrosiveBreath(db), UpgradeType.NightelfHippogryphTaming => LoadNightelfHippogryphTaming(db), UpgradeType.NightelfImpalingBolt => LoadNightelfImpalingBolt(db), UpgradeType.NightelfResistantSkin => LoadNightelfResistantSkin(db), UpgradeType.NightelfHardenedSkin => LoadNightelfHardenedSkin(db), UpgradeType.NightelfEnchantedBears => LoadNightelfEnchantedBears(db), UpgradeType.NightelfEnchantedCrows => LoadNightelfEnchantedCrows(db), UpgradeType.NightelfWellSpring => LoadNightelfWellSpring(db), UpgradeType.NightelfBackpack => LoadNightelfBackpack(db), UpgradeType.GlyphOfFortification => LoadGlyphOfFortification(db), UpgradeType.GlyphOfUltravision => LoadGlyphOfUltravision(db), UpgradeType.NagaMyrmidonEnsnare => LoadNagaMyrmidonEnsnare(db), UpgradeType.NagaSeaWitchTraining => LoadNagaSeaWitchTraining(db), UpgradeType.NagaAbolishMagic => LoadNagaAbolishMagic(db), UpgradeType.NagaAttack => LoadNagaAttack(db), UpgradeType.NagaArmor => LoadNagaArmor(db), UpgradeType.NagaSubmerge => LoadNagaSubmerge(db), _ => throw new System.ComponentModel.InvalidEnumArgumentException(nameof(upgradeType), (int)upgradeType, typeof(UpgradeType))}

            ;
        }
    }
}