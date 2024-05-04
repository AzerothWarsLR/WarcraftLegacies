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
            upgrade.TextName[1] = "Iron Forged Swords";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Upgrade to Iron Forged Swords";
            upgrade.TextTooltipExtended[1] = "Increases the attack damage of Militia, Footmen, Spellbreakers, Dragonhawk Riders, Gryphon Riders and Knights.";
            upgrade.TextHotkeyRaw[1] = "S";
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
            upgrade.TextName[1] = "Black Gunpowder";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Upgrade to Black Gunpowder";
            upgrade.TextTooltipExtended[1] = "Increases the ranged attack damage of Riflemen, Mortar Teams, Siege Engines and Flying Machines.";
            upgrade.TextHotkeyRaw[1] = "G";
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
            upgrade.TextName[1] = "Storm Hammers";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Storm Hammers";
            upgrade.TextTooltipExtended[1] = "Causes a Gryphon Rider's attacks to damage multiple units.";
            upgrade.TextHotkeyRaw[1] = "H";
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
            upgrade.TextName[1] = "Iron Plating";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Upgrade to Iron Plating";
            upgrade.TextTooltipExtended[1] = "Increases the armor of Militia, Footmen, Spellbreakers, Knights, Flying Machines and Siege Engines.";
            upgrade.TextHotkeyRaw[1] = "P";
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
            upgrade.TextName[1] = "Flying Machine Bombs";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Flying Machine Bombs";
            upgrade.TextTooltipExtended[1] = "Allows Flying Machines to attack land units.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Improved Masonry";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Upgrade to Improved Masonry";
            upgrade.TextTooltipExtended[1] = "Increases the armor and hit points of Human buildings.";
            upgrade.TextHotkeyRaw[1] = "M";
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
            upgrade.TextName[1] = "Defend";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Defend";
            upgrade.TextHotkeyRaw[1] = "D";
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
            upgrade.TextName[1] = "Animal War Training";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Animal War Training";
            upgrade.TextTooltipExtended[1] = "Increases the maximum hit points of Knights, Dragonhawk Riders, and Gryphon Riders by <Rhan,base1>.";
            upgrade.TextHotkeyRaw[1] = "A";
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
            upgrade.TextName[1] = "Priest Adept Training";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Priest Adept Training";
            upgrade.TextTooltipExtended[1] = "Increases Priests' mana capacity, mana regeneration rate, hit points, and gives them the ability to cast Dispel Magic.";
            upgrade.TextHotkeyRaw[1] = "T";
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
            upgrade.TextName[1] = "Sorceress Adept Training";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Sorceress Adept Training";
            upgrade.TextTooltipExtended[1] = "Increases Sorceresses' mana capacity, mana regeneration rate, hit points, and gives them the ability to cast Invisibility.";
            upgrade.TextHotkeyRaw[1] = "O";
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
            upgrade.TextName[1] = "Studded Leather Armor";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Upgrade to Studded Leather Armor";
            upgrade.TextTooltipExtended[1] = "Increases the armor of Riflemen, Mortar Teams, Dragonhawk Riders and Gryphon Riders.";
            upgrade.TextHotkeyRaw[1] = "A";
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
            upgrade.TextName[1] = "Long Rifles";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Upgrade to Long Rifles";
            upgrade.TextTooltipExtended[1] = "Increases the range of Riflemen attacks.";
            upgrade.TextHotkeyRaw[1] = "L";
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
            upgrade.TextName[1] = "Improved Lumber Harvesting";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Improved Lumber Harvesting";
            upgrade.TextTooltipExtended[1] = "Increases the amount of lumber that Peasants can carry by <Rhlh,mod1>.";
            upgrade.TextHotkeyRaw[1] = "L";
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
            upgrade.TextName[1] = "Magic Sentry";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Magic Sentry";
            upgrade.TextTooltipExtended[1] = "Provides Human towers with the ability to detect invisible units.";
            upgrade.TextHotkeyRaw[1] = "M";
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
            upgrade.TextName[1] = "Flare";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Flare";
            upgrade.TextTooltipExtended[1] = "Provides Mortar Teams with the Flare ability. Flares can be used to reveal any area of the map. |nCan see invisible units.";
            upgrade.TextHotkeyRaw[1] = "R";
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
            upgrade.TextName[1] = "Control Magic";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Control Magic";
            upgrade.TextTooltipExtended[1] = "Gives Spellbreakers the ability to take control of enemy summoned units.";
            upgrade.TextHotkeyRaw[1] = "G";
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
            upgrade.TextName[1] = "Barrage";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Barrage";
            upgrade.TextTooltipExtended[1] = "Upgrades Siege Engines, giving them the Barrage ability, which allows them to damage nearby enemy air units.";
            upgrade.TextHotkeyRaw[1] = "G";
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
            upgrade.TextName[1] = "Backpack";
            upgrade.TextEditorSuffix[1] = " (Human)";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Backpack";
            upgrade.TextTooltipExtended[1] = "Gives specific Human ground units the ability to carry items.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Flak Cannons";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Flak Cannons";
            upgrade.TextTooltipExtended[1] = "Upgrades the weapons on Flying Machines to give them an area effect damage attack against air units.";
            upgrade.TextHotkeyRaw[1] = "C";
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
            upgrade.TextName[1] = "Fragmentation Shards";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Fragmentation Shards";
            upgrade.TextTooltipExtended[1] = "Upgrades the mortar shells on Mortar Teams and Cannon Towers to increase the damage they deal to Unarmored and Medium armor units.";
            upgrade.TextHotkeyRaw[1] = "S";
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
            upgrade.TextName[1] = "Cloud";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Cloud";
            upgrade.TextTooltipExtended[1] = "Provides Dragonhawk Riders with the Cloud ability, which stops ranged buildings from attacking.";
            upgrade.TextHotkeyRaw[1] = "C";
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
            upgrade.TextName[1] = "Sundering Blades";
            upgrade.StatsRaceRaw = "human";
            upgrade.TextTooltip[1] = "Research Sundering Blades";
            upgrade.TextTooltipExtended[1] = "Upgrades Knights to deal increased damage to targets with Medium armor.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Steel Melee Weapons";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Upgrade to Steel Melee Weapons";
            upgrade.TextTooltipExtended[1] = "Increases the melee attack damage of Grunts, Raiders and Tauren.";
            upgrade.TextHotkeyRaw[1] = "M";
            upgrade.StatsClassRaw = "melee";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 75;
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

        protected virtual Upgrade LoadOrcRangedAttack(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcRangedAttack, db);
            upgrade.TextName[1] = "Steel Ranged Weapons";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Upgrade to Steel Ranged Weapons";
            upgrade.TextTooltipExtended[1] = "Increases the ranged attack damage of Headhunters, Wind Riders, Batriders and Demolishers.";
            upgrade.TextHotkeyRaw[1] = "R";
            upgrade.StatsClassRaw = "ranged";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 50;
            upgrade.StatsLumberBase = 100;
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

        protected virtual Upgrade LoadOrcArmor(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcArmor, db);
            upgrade.TextName[1] = "Steel Armor";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Upgrade to Steel Unit Armor";
            upgrade.TextTooltipExtended[1] = "Increases the armor of Grunts, Raiders, Batriders, Tauren, Headhunters, Wind Riders and Demolishers.";
            upgrade.TextHotkeyRaw[1] = "A";
            upgrade.StatsClassRaw = "armor";
            upgrade.StatsLevels = 3;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 75;
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

        protected virtual Upgrade LoadOrcWarDrumsDamage(ObjectDatabaseBase db)
        {
            var upgrade = new Upgrade(UpgradeType.OrcWarDrumsDamage, db);
            upgrade.TextName[1] = "War Drums Damage Increase";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Upgrade War Drums";
            upgrade.TextTooltipExtended[1] = "Increases the damage bonus that the War Drums aura on the Kodo Beast gives. War Drums increases the damage of friendly units around Kodo Beasts.";
            upgrade.TextHotkeyRaw[1] = "D";
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
            upgrade.TextName[1] = "Pillage";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Pillage";
            upgrade.TextTooltipExtended[1] = "Causes Peons', Grunts', and Raiders' attacks to gain resources when hitting enemy buildings.";
            upgrade.TextHotkeyRaw[1] = "G";
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
            upgrade.TextName[1] = "Brute Strength";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Research Brute Strength";
            upgrade.TextTooltipExtended[1] = "Improves the fighting capabilities of Grunts with a <Robs,base1> hit point increase, and <Robs,base2> bonus attack damage.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Pulverize Damage Increase";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Upgrade Pulverize";
            upgrade.TextTooltipExtended[1] = "Upgrades the totem carried by Tauren, increasing the damage of their Pulverize ability.";
            upgrade.TextHotkeyRaw[1] = "P";
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
            upgrade.TextName[1] = "Ensnare";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Research Ensnare";
            upgrade.TextTooltipExtended[1] = "Enables Raiders to use the Ensnare ability. Ensnare causes a target enemy unit to be bound to the ground so that it cannot move. Air units that are ensnared can be attacked as though they were land units.";
            upgrade.TextHotkeyRaw[1] = "N";
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
            upgrade.TextName[1] = "Envenomed Spears";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Research Envenomed Spears";
            upgrade.TextTooltipExtended[1] = "Adds an additional poison effect to Wind Riders' attacks. A unit poisoned by Envenomed Spears takes damage over time.";
            upgrade.TextHotkeyRaw[1] = "E";
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
            upgrade.TextName[1] = "Witch Doctor Adept Training";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Witch Doctor Adept Training";
            upgrade.TextTooltipExtended[1] = "Increases Witch Doctors' mana capacity, mana regeneration rate, hit points, and gives them the ability to cast Stasis Trap.";
            upgrade.TextHotkeyRaw[1] = "D";
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
            upgrade.TextName[1] = "Shaman Adept Training";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Shaman Adept Training";
            upgrade.TextTooltipExtended[1] = "Increases Shaman mana capacity, mana regeneration rate, hit points, and gives them the ability to cast Lightning Shield.";
            upgrade.TextHotkeyRaw[1] = "M";
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
            upgrade.TextName[1] = "Spiked Barricades";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Upgrade to Spiked Barricades";
            upgrade.TextTooltipExtended[1] = "Surrounds Orc buildings with spikes that damage enemy melee attackers. Deals <Rosp,base1> damage per attack plus an additional <Rosp,base2,%>% of the attacker's damage.";
            upgrade.TextHotkeyRaw[1] = "S";
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
            upgrade.TextName[1] = "Troll Regeneration";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Research Troll Regeneration";
            upgrade.TextTooltipExtended[1] = "Increases the hit point regeneration rate of Headhunters, Witch Doctors and Batriders.";
            upgrade.TextHotkeyRaw[1] = "R";
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
            upgrade.TextName[1] = "Liquid Fire";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Research Liquid Fire";
            upgrade.TextTooltipExtended[1] = "Gives Batriders the Liquid Fire attack, which deals damage over time to enemy buildings, reduces the repaired rate and the attack rate of enemy buildings.";
            upgrade.TextHotkeyRaw[1] = "L";
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
            upgrade.TextName[1] = "Chaos";
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
            upgrade.TextName[1] = "Spirit Walker Adept Training";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Spirit Walker Adept Training";
            upgrade.TextTooltipExtended[1] = "Increases Spirit Walkers' mana capacity, mana regeneration rate, hit points, and gives them the ability to cast Disenchant.";
            upgrade.TextHotkeyRaw[1] = "R";
            upgrade.StatsClassRaw = "caster";
            upgrade.StatsLevels = 2;
            upgrade.StatsGoldBase = 100;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 50;
            upgrade.StatsLumberIncrement = 100;
            upgrade.StatsTimeBase = 50;
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
            upgrade.TextName[1] = "Reinforced Defenses";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Reinforced Defenses";
            upgrade.TextTooltipExtended[1] = "Upgrades Burrows and Watch Towers so that they have Fortified armor.";
            upgrade.TextHotkeyRaw[1] = "D";
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
            upgrade.TextName[1] = "Berserker Upgrade";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Berserker Upgrade";
            upgrade.TextTooltipExtended[1] = "Transforms Headhunters into Berserkers, giving them increased hit points and the Berserk ability.";
            upgrade.TextHotkeyRaw[1] = "E";
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
            upgrade.TextName[1] = "Backpack";
            upgrade.TextEditorSuffix[1] = " (Orc)";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Research Backpack";
            upgrade.TextTooltipExtended[1] = "Gives specific Orc ground units the ability to carry items.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Burning Oil";
            upgrade.StatsRaceRaw = "orc";
            upgrade.TextTooltip[1] = "Burning Oil";
            upgrade.TextTooltipExtended[1] = "Upgrades Demolishers to fire rocks smothered in burning oil, which causes the ground to burn.";
            upgrade.TextHotkeyRaw[1] = "N";
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
            upgrade.TextName[1] = "Unholy Strength";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Upgrade to Unholy Strength";
            upgrade.TextTooltipExtended[1] = "Increases the attack damage of Ghouls, Meat Wagons, Abominations, Skeleton Warriors, and Skeletal Mages.";
            upgrade.TextHotkeyRaw[1] = "S";
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
            upgrade.TextName[1] = "Creature Attack";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Upgrade to Creature Attack";
            upgrade.TextTooltipExtended[1] = "Increases the attack damage of Crypt Fiends, Gargoyles, Destroyers, and Frost Wyrms.";
            upgrade.TextHotkeyRaw[1] = "A";
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
            upgrade.TextName[1] = "Unholy Armor";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Upgrade to Unholy Armor";
            upgrade.TextTooltipExtended[1] = "Increases the armor of Ghouls, Abominations, Skeleton Warriors, and Skeletal Mages.";
            upgrade.TextHotkeyRaw[1] = "U";
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
            upgrade.TextName[1] = "Cannibalize";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Cannibalize";
            upgrade.TextTooltipExtended[1] = "Enables Ghouls and Abominations to use the Cannibalize ability. Cannibalize consumes a nearby corpse to restore health.";
            upgrade.TextHotkeyRaw[1] = "C";
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
            upgrade.TextName[1] = "Ghoul Frenzy";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Ghoul Frenzy";
            upgrade.TextTooltipExtended[1] = "Increases the attack rate of Ghouls by <Rugf,base1,%>%, and increases their movement speed.";
            upgrade.TextHotkeyRaw[1] = "Z";
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
            upgrade.TextName[1] = "Web";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Web";
            upgrade.TextTooltipExtended[1] = "Enables Crypt Fiends to use the Web ability. Web binds a target enemy air unit in webbing, forcing it to the ground. Webbed units can be hit as though they were land units.";
            upgrade.TextHotkeyRaw[1] = "W";
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
            upgrade.TextName[1] = "Stone Form";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Stone Form";
            upgrade.TextTooltipExtended[1] = "Enables the ability for Gargoyles to assume Stone Form. Stone Form transforms the Gargoyle into a statue with high armor, spell immunity, and regeneration. The Gargoyle cannot attack in this form.";
            upgrade.TextHotkeyRaw[1] = "S";
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
            upgrade.TextName[1] = "Necromancer Adept Training";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Necromancer Adept Training";
            upgrade.TextTooltipExtended[1] = "Increases Necromancers' mana capacity, mana regeneration rate, hit points, and gives them the ability to cast Unholy Frenzy.";
            upgrade.TextHotkeyRaw[1] = "E";
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
            upgrade.TextName[1] = "Banshee Adept Training";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Banshee Adept Training";
            upgrade.TextTooltipExtended[1] = "Increases Banshees' mana capacity, mana regeneration rate, hit points, and gives them the ability to cast Anti-magic Shell.";
            upgrade.TextHotkeyRaw[1] = "A";
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
            upgrade.TextName[1] = "Freezing Breath";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Freezing Breath";
            upgrade.TextTooltipExtended[1] = "Enables Frost Wyrms to use the Freezing Breath ability. When cast on a building, temporarily stops production.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Skeletal Longevity";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Skeletal Longevity";
            upgrade.TextTooltipExtended[1] = "Increases the duration of raised Skeleton Warriors and Skeletal Mages by <Rusl,base1> seconds.";
            upgrade.TextHotkeyRaw[1] = "S";
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
            upgrade.TextName[1] = "Creature Carapace";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Upgrade to Creature Carapace";
            upgrade.TextTooltipExtended[1] = "Increases the armor of Crypt Fiends, Gargoyles, Destroyers, and Frost Wyrms.";
            upgrade.TextHotkeyRaw[1] = "C";
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
            upgrade.TextName[1] = "Disease Cloud";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Disease Cloud";
            upgrade.TextTooltipExtended[1] = "Gives Abominations a Disease Cloud aura that deals <Aap1,DataB1> damage per second for <Aap1,DataA1> seconds to nearby enemy units. Meat Wagons will cause Disease Clouds wherever they attack that deal <Aap2,DataB1> damage per second for <Aap2,DataA1> seconds to nearby enemy units. |nUndead are immune to Disease Cloud.";
            upgrade.TextHotkeyRaw[1] = "D";
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
            upgrade.TextName[1] = "Skeletal Mastery";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Skeletal Mastery";
            upgrade.TextTooltipExtended[1] = "Causes one of the two skeletons created by Raise Dead to be a Skeletal Mage and increases the duration of raised Skeleton Warriors and Skeletal Mages by <Rusl,base1> seconds.";
            upgrade.TextHotkeyRaw[1] = "M";
            upgrade.StatsClassRaw = "_";
            upgrade.StatsLevels = 1;
            upgrade.StatsGoldBase = 150;
            upgrade.StatsGoldIncrement = 0;
            upgrade.StatsLumberBase = 100;
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
            upgrade.TextName[1] = "Burrow";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Burrow";
            upgrade.TextTooltipExtended[1] = "Crypt Fiends gain the ability to burrow. Burrowed Crypt Fiends are invisible and gain increased hit point regeneration, but cannot attack.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Destroyer Form";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Destroyer Form";
            upgrade.TextTooltipExtended[1] = "Allows the Obsidian Statue to transform into a Destroyer, a large flying unit that must devour magic to sustain its mana. The Destroyer has Spell Immunity, Devour Magic, Absorb Mana, and Orb of Annihilation. |n|n|cffffcc00Attacks land and air units.|r";
            upgrade.TextHotkeyRaw[1] = "T";
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
            upgrade.TextName[1] = "Exhume Corpses";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Exhume Corpses";
            upgrade.TextTooltipExtended[1] = "Gives Meat Wagons the ability to generate corpses.";
            upgrade.TextHotkeyRaw[1] = "E";
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
            upgrade.TextName[1] = "Backpack";
            upgrade.TextEditorSuffix[1] = " (Undead)";
            upgrade.StatsRaceRaw = "undead";
            upgrade.TextTooltip[1] = "Research Backpack";
            upgrade.TextTooltipExtended[1] = "Gives specific Undead ground units the ability to carry items.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Strength of the Moon";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Upgrade to Strength of the Moon";
            upgrade.TextTooltipExtended[1] = "Increases the damage of Archers, Huntresses, Glaive Throwers, and Hippogryph Riders.";
            upgrade.TextHotkeyRaw[1] = "M";
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
            upgrade.TextName[1] = "Strength of the Wild";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Upgrade to Strength of the Wild";
            upgrade.TextTooltipExtended[1] = "Increases the damage of Druids of the Claw in Bear Form, Druids of the Talon in Storm Crow Form, Dryads, Mountain Giants, Faerie Dragons, Hippogryphs, and Chimaeras.";
            upgrade.TextHotkeyRaw[1] = "W";
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
            upgrade.TextName[1] = "Moon Armor";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Upgrade to Moon Armor";
            upgrade.TextTooltipExtended[1] = "Increases the armor of Archers, Huntresses, and Hippogryph Riders.";
            upgrade.TextHotkeyRaw[1] = "A";
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
            upgrade.TextName[1] = "Reinforced Hides";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Upgrade to Reinforced Hides";
            upgrade.TextTooltipExtended[1] = "Increases the armor of Druids of the Claw in Bear Form, Druids of the Talon in Storm Crow Form, Dryads, Mountain Giants, Faerie Dragons, Hippogryphs, and Chimaeras.";
            upgrade.TextHotkeyRaw[1] = "R";
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
            upgrade.TextName[1] = "Ultravision";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Upgrade to Ultravision";
            upgrade.TextTooltipExtended[1] = "Gives Night Elves the ability to see as far at night as they do during the day.";
            upgrade.TextHotkeyRaw[1] = "U";
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
            upgrade.TextName[1] = "Nature's Blessing";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Nature's Blessing";
            upgrade.TextTooltipExtended[1] = "Upgrades all Ancients' and Treants' movement speed and armor.";
            upgrade.TextHotkeyRaw[1] = "N";
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
            upgrade.TextName[1] = "Sentinel";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Sentinel";
            upgrade.TextTooltipExtended[1] = "Gives the Huntress the ability to send her owl companion to a nearby tree and provide vision. |nCan see invisible units.";
            upgrade.TextHotkeyRaw[1] = "S";
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
            upgrade.TextName[1] = "Upgrade Moon Glaive";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Upgrade Moon Glaive";
            upgrade.TextTooltipExtended[1] = "Gives the Huntress the ability to strike additional units with her bouncing glaive attacks.";
            upgrade.TextHotkeyRaw[1] = "G";
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
            upgrade.TextName[1] = "Improved Bows";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Improved Bows";
            upgrade.TextTooltipExtended[1] = "Increases the Archer's and Hippogryph Rider's attack range.";
            upgrade.TextHotkeyRaw[1] = "I";
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
            upgrade.TextName[1] = "Marksmanship";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Marksmanship";
            upgrade.TextTooltipExtended[1] = "Increases damage of Archers and Hippogryph Riders by <Remk,base1>.";
            upgrade.TextHotkeyRaw[1] = "M";
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
            upgrade.TextName[1] = "Druid of the Talon Adept Training";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Druid of the Talon Adept Training";
            upgrade.TextTooltipExtended[1] = "Increases their Night Elf Form's mana capacity, mana regeneration rate, hit points, and gives them the ability Storm Crow Form.";
            upgrade.TextHotkeyRaw[1] = "A";
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
            upgrade.TextName[1] = "Druid of the Claw Adept Training";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Druid of the Claw Adept Training";
            upgrade.TextTooltipExtended[1] = "Increases their Night Elf Form's mana capacity, mana regeneration rate, hit points, attack damage and gives them the ability Rejuvenation.";
            upgrade.TextHotkeyRaw[1] = "L";
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
            upgrade.TextName[1] = "Abolish Magic";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Abolish Magic";
            upgrade.TextTooltipExtended[1] = "Gives the Dryad the ability to dispel positive buffs from enemy units, and negative buffs from friendly units. |nDamages summoned units.";
            upgrade.TextHotkeyRaw[1] = "S";
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
            upgrade.TextName[1] = "Corrosive Breath";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Corrosive Breath";
            upgrade.TextTooltipExtended[1] = "Gives Chimaeras the ability to hurl corrosive bile onto enemy buildings.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Hippogryph Taming";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Hippogryph Taming";
            upgrade.TextTooltipExtended[1] = "Trains Hippogryphs to allow Archers to mount them. This allows them to attack both air and ground units.";
            upgrade.TextHotkeyRaw[1] = "I";
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
            upgrade.TextName[1] = "Vorpal Blades";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Vorpal Blades";
            upgrade.TextTooltipExtended[1] = "Increases the speed of glaives launched by the Glaive Thrower. Also allows them to attack trees.";
            upgrade.TextHotkeyRaw[1] = "P";
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
            upgrade.TextName[1] = "Resistant Skin";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Resistant Skin";
            upgrade.TextTooltipExtended[1] = "Gives Mountain Giants increased resistance to spell damage.";
            upgrade.TextHotkeyRaw[1] = "T";
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
            upgrade.TextName[1] = "Hardened Skin";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Hardened Skin";
            upgrade.TextTooltipExtended[1] = "Gives Mountain Giants increased resistance to attack damage.";
            upgrade.TextHotkeyRaw[1] = "H";
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
            upgrade.TextName[1] = "Mark of the Claw";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Mark of the Claw";
            upgrade.TextTooltipExtended[1] = "Allows Druids of the Claw to cast Roar while in Bear Form.";
            upgrade.TextHotkeyRaw[1] = "M";
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
            upgrade.TextName[1] = "Mark of the Talon";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Mark of the Talon";
            upgrade.TextTooltipExtended[1] = "Allows Druids of the Talon to cast Faerie Fire while in Storm Crow Form.";
            upgrade.TextHotkeyRaw[1] = "M";
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
            upgrade.TextName[1] = "Well Spring";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Well Spring";
            upgrade.TextTooltipExtended[1] = "Increases the amount of mana that can be stored in Moon Wells by <Rews,base1>, and their rate of mana regeneration by <Rews,base2,%>%.";
            upgrade.TextHotkeyRaw[1] = "E";
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
            upgrade.TextName[1] = "Backpack";
            upgrade.TextEditorSuffix[1] = " (Night Elf)";
            upgrade.StatsRaceRaw = "nightelf";
            upgrade.TextTooltip[1] = "Research Backpack";
            upgrade.TextTooltipExtended[1] = "Gives specific Night Elf ground units the ability to carry items.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Glyph of Fortification";
            upgrade.TextEditorSuffix[1] = " (Upgrade 1)";
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
            upgrade.TextName[1] = "Glyph of Ultravision";
            upgrade.TextEditorSuffix[1] = " (Upgrade)";
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
            upgrade.TextName[1] = "Ensnare";
            upgrade.StatsRaceRaw = "naga";
            upgrade.TextTooltip[1] = "Research Ensnare";
            upgrade.TextTooltipExtended[1] = "Enables Naga Myrmidons to use the Ensnare ability. Ensnare causes a target enemy unit to be bound to the ground so that it cannot move. Air units that are ensnared can be attacked as though they were land units.";
            upgrade.TextHotkeyRaw[1] = "N";
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
            upgrade.TextName[1] = "Naga Siren Adept Training";
            upgrade.StatsRaceRaw = "naga";
            upgrade.TextTooltip[1] = "Research Naga Siren Adept Training";
            upgrade.TextTooltipExtended[1] = "Increases Naga Sirens' mana capacity, mana regeneration rate, hit points, and gives them the ability to cast Frost Armor.";
            upgrade.TextHotkeyRaw[1] = "N";
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
            upgrade.TextName[1] = "Abolish Magic";
            upgrade.StatsRaceRaw = "naga";
            upgrade.TextTooltip[1] = "Research Abolish Magic";
            upgrade.TextTooltipExtended[1] = "Gives the Couatl the ability to dispel positive buffs from enemy units, and negative buffs from friendly units. |nDamages summoned units.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Coral Blades";
            upgrade.StatsRaceRaw = "naga";
            upgrade.TextTooltip[1] = "Upgrade to Coral Blades";
            upgrade.TextTooltipExtended[1] = "Increases the attack damage of Naga attack units.";
            upgrade.TextHotkeyRaw[1] = "B";
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
            upgrade.TextName[1] = "Coral Scales";
            upgrade.StatsRaceRaw = "naga";
            upgrade.TextTooltip[1] = "Upgrade to Coral Scales";
            upgrade.TextTooltipExtended[1] = "Increases the armor of Naga attack units.";
            upgrade.TextHotkeyRaw[1] = "C";
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
            upgrade.TextName[1] = "Submerge";
            upgrade.StatsRaceRaw = "naga";
            upgrade.TextTooltip[1] = "Research Submerge";
            upgrade.TextTooltipExtended[1] = "Gives Naga Myrmidons and Snap Dragons the ability to submerge under water, hiding them from view.";
            upgrade.TextHotkeyRaw[1] = "U";
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