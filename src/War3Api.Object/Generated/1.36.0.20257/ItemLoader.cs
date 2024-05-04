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
    internal class ItemLoader
    {
        protected virtual Item LoadCrownOfKings5(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.CrownOfKings5, db);
            item.AbilitiesAbilitiesRaw = "AIx5";
            item.StatsClassificationRaw = "Artifact";
            item.StatsCooldownGroupRaw = "AIx5";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 8;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 10;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 126;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides a +5 bonus to Agility, Strength, and Intelligence.";
            item.TextHotkeyRaw = "K";
            item.TextName = "Crown of Kings +5";
            item.TextTooltipBasic = "Purchase Crown of Kings";
            item.TextTooltipExtended = "Increases the Strength, Intelligence, and Agility of the Hero by 5 when worn.";
            return item;
        }

        protected virtual Item LoadMaskOfDeath(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.MaskOfDeath, db);
            item.AbilitiesAbilitiesRaw = "AIva";
            item.StatsClassificationRaw = "Artifact";
            item.StatsCooldownGroupRaw = "AIva";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 8;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 10;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 138;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This mask causes the Hero's attacks to drain life.";
            item.TextName = "Mask of Death";
            item.TextTooltipBasic = "Purchase Mask of Death";
            item.TextTooltipExtended = "While wearing this mask, a Hero will recover hit points equal to <AIva,DataA1,%>% of the attack damage dealt to an enemy unit.";
            return item;
        }

        protected virtual Item LoadTomeOfPower(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfPower, db);
            item.AbilitiesAbilitiesRaw = "AIlm";
            item.StatsClassificationRaw = "Artifact";
            item.StatsCooldownGroupRaw = "AIlm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 8;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 9;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gives the Hero an experience level.";
            item.TextHotkeyRaw = "P";
            item.TextName = "Tome of Power";
            item.TextTooltipBasic = "Purchase Tome of Power";
            item.TextTooltipExtended = "Increases the level of the Hero by <AIlm,DataA1> when used.";
            return item;
        }

        protected virtual Item LoadClawsOfAttack15(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ClawsOfAttack15, db);
            item.AbilitiesAbilitiesRaw = "AItf";
            item.StatsClassificationRaw = "Artifact";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 800;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 7;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 9;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 53;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts attack damage by 15.";
            item.TextName = "Claws of Attack +15";
            item.TextTooltipBasic = "Purchase Claws of Attack +15";
            item.TextTooltipExtended = "Increases the attack damage of the Hero by 15 when worn.";
            return item;
        }

        protected virtual Item LoadOrbOfFrost(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrbOfFrost, db);
            item.AbilitiesAbilitiesRaw = "AIob";
            item.StatsClassificationRaw = "Artifact";
            item.StatsCooldownGroupRaw = "AIob";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 800;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 7;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 97;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Attacks cause Frost Shock.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Orb of Frost";
            item.TextTooltipBasic = "Purchase Orb of Frost";
            item.TextTooltipExtended = "Adds <AIob,DataA1> bonus cold damage to the attack of a Hero when carried. The Hero's attacks also become ranged when attacking air and slow the movement speed and attack rate of the enemy for <AIob,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadInfernoStone(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.InfernoStone, db);
            item.AbilitiesAbilitiesRaw = "AIin";
            item.StatsClassificationRaw = "Artifact";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 800;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 7;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 8;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 146;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Brings down an Infernal Demon.";
            item.TextName = "Inferno Stone";
            item.TextTooltipBasic = "Purchase Inferno Stone";
            item.TextTooltipExtended = "Calls an Infernal down from the sky, dealing <AIin,DataA1> damage and stunning enemy land units for <AIin,Dur1> seconds in an area. The Infernal lasts <AIin,DataB1> seconds.";
            return item;
        }

        protected virtual Item LoadDaggerOfEscape(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.DaggerOfEscape, db);
            item.AbilitiesAbilitiesRaw = "AIbk";
            item.StatsClassificationRaw = "Artifact";
            item.StatsCooldownGroupRaw = "AIbk";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 800;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 7;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 47;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Teleports the Hero a short distance.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Kelen's Dagger of Escape";
            item.TextTooltipBasic = "Purchase Dagger of Escape";
            item.TextTooltipExtended = "Allows the Hero to teleport a short distance.";
            return item;
        }

        protected virtual Item LoadDemonicFigurine(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.DemonicFigurine, db);
            item.AbilitiesAbilitiesRaw = "AIfu";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 700;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 8;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 139;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons a Doom Guard.";
            item.TextName = "Demonic Figurine";
            item.TextTooltipBasic = "Purchase Demonic Figurine";
            item.TextTooltipExtended = "Summons a Doom Guard to fight for you. |nLasts <AIfu,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadEngravedScale(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.EngravedScale, db);
            item.AbilitiesAbilitiesRaw = "AIes";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 700;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 8;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 141;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons a Blue Dragonspawn Overseer.";
            item.TextName = "Engraved Scale";
            item.TextTooltipBasic = "Purchase Engraved Scale";
            item.TextTooltipExtended = "Summons a Blue Dragonspawn Overseer to fight for you.|nLasts <AIes,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadIceShard(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.IceShard, db);
            item.AbilitiesAbilitiesRaw = "AIir";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 700;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 135;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons an Ice Revenant.";
            item.TextName = "Ice Shard";
            item.TextTooltipBasic = "Purchase Ice Shard";
            item.TextTooltipExtended = "Summons an Ice Revenant. The Ice Revenant lasts <AIir,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadScepterOfMastery(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScepterOfMastery, db);
            item.AbilitiesAbilitiesRaw = "AIco";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIco";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 700;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 143;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Allows mind control of non-Hero units.";
            item.TextHotkeyRaw = "C";
            item.TextName = "Scepter of Mastery";
            item.TextTooltipBasic = "Purchase Scepter of Mastery";
            item.TextTooltipExtended = "Transfers control of the targeted non-Hero unit to the player who uses the Scepter. The transfer of control is permanent. |nCannot be used on Heroes or on creeps higher than level  <AIco,DataA1>. |nContains <ccmd,uses> charges.";
            return item;
        }

        protected virtual Item LoadAmuletOfTheWild(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.AmuletOfTheWild, db);
            item.AbilitiesAbilitiesRaw = "AIuw";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 700;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 136;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons a Furbolg.";
            item.TextName = "Amulet of the Wild";
            item.TextTooltipBasic = "Purchase Amulet of the Wild";
            item.TextTooltipExtended = "Summons a Furbolg Warrior. The Furbolg lasts <AIuw,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadScepterOfAvarice(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScepterOfAvarice, db);
            item.AbilitiesAbilitiesRaw = "AIts";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIts";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 700;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 8;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 134;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Turns non-Hero units into gold.";
            item.TextName = "Scepter of Avarice";
            item.TextTooltipBasic = "Purchase Scepter of Avarice";
            item.TextTooltipExtended = "Kills a target unit instantly, transforming it into gold. <AIts,DataA1,%>% of the unit's cost is added to your available gold.|nCannot be used on Heroes, or creeps above level <AIts,DataC1>.";
            return item;
        }

        protected virtual Item LoadOrbOfDarkness(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrbOfDarkness, db);
            item.AbilitiesAbilitiesRaw = "AIdf";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIdf";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 600;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 96;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Attacks can create Dark Minions.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Orb of Darkness";
            item.TextTooltipBasic = "Purchase Orb of Darkness";
            item.TextTooltipExtended = "Adds <AIdf,DataA1> bonus damage to the attack of a Hero when carried. The Hero's attack also becomes ranged when attacking air and will create a Dark Minion when it is the killing blow on an enemy unit. The Dark Minion lasts <ANbs,DataC1> seconds.";
            return item;
        }

        protected virtual Item LoadRingOfProtection5(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RingOfProtection5, db);
            item.AbilitiesAbilitiesRaw = "AId5";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIde";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 9;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 117;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts armor by 5.";
            item.TextHotkeyRaw = "5";
            item.TextName = "Ring of Protection +5";
            item.TextTooltipBasic = "Purchase Ring of Protection +5";
            item.TextTooltipExtended = "Increases the armor of the Hero by 5 when worn.";
            return item;
        }

        protected virtual Item LoadPendantOfMana(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PendantOfMana, db);
            item.AbilitiesAbilitiesRaw = "AIbm";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AImm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 600;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 61;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides additional mana.";
            item.TextName = "Pendant of Mana";
            item.TextTooltipBasic = "Purchase Pendant of Mana";
            item.TextTooltipExtended = "Increases the mana capacity of the Hero by <AIbm,DataA1> when worn.";
            return item;
        }

        protected virtual Item LoadKhadgarSGemOfHealth(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.KhadgarSGemOfHealth, db);
            item.AbilitiesAbilitiesRaw = "AIl2";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIml";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 600;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 128;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases the hit points of the Hero.";
            item.TextHotkeyRaw = "H";
            item.TextName = "Khadgar's Gem of Health";
            item.TextTooltipBasic = "Purchase Khadgar's Gem of Health";
            item.TextTooltipExtended = "Increases the hit points of the Hero by <AIl2,DataA1> when worn.";
            return item;
        }

        protected virtual Item LoadStaffOfSilence(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.StaffOfSilence, db);
            item.AbilitiesAbilitiesRaw = "AIse";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "ANsi";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 600;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 6;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Stops enemy spellcasting.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Staff of Silence";
            item.TextTooltipBasic = "Purchase Staff of Silence";
            item.TextTooltipExtended = "Stops all enemies in a target area from casting spells for <AIse,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadAmuletOfSpellShield(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.AmuletOfSpellShield, db);
            item.AbilitiesAbilitiesRaw = "ANss";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "ANss";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 600;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 5;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 113;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Blocks enemy spells.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Amulet of Spell Shield";
            item.TextTooltipBasic = "Purchase Amulet of Spell Shield";
            item.TextTooltipExtended = "Blocks a negative spell that an enemy casts on the Hero once every <ANss,Cool1> seconds.";
            return item;
        }

        protected virtual Item LoadScrollOfRestoration(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfRestoration, db);
            item.AbilitiesAbilitiesRaw = "AIra";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIra";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 144;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores hit points and mana to nearby units.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Scroll of Restoration";
            item.TextTooltipBasic = "Purchase Scroll of Restoration";
            item.TextTooltipExtended = "Restores <AIra,DataA1> hit points and <AIra,DataB1> mana of friendly non-mechanical units in an area around your Hero.";
            return item;
        }

        protected virtual Item LoadPotionOfDivinityInvulnerability(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfDivinityInvulnerability, db);
            item.AbilitiesAbilitiesRaw = "AIvg";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIvu";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 125;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Turns Hero invulnerable.";
            item.TextHotkeyRaw = "D";
            item.TextName = "Potion of Divinity";
            item.TextTooltipBasic = "Purchase Potion of Divinity";
            item.TextTooltipExtended = "Makes the Hero invulnerable to damage for <AIvg,Dur1> seconds when used. An invulnerable Hero may not be the target of spells or effects.";
            return item;
        }

        protected virtual Item LoadPotionOfRestoration(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfRestoration, db);
            item.AbilitiesAbilitiesRaw = "AIre";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIre";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 6;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 132;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores lost hit points and mana.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Potion of Restoration";
            item.TextTooltipBasic = "Purchase Potion of Restoration";
            item.TextTooltipExtended = "Restores <AIre,DataA1> hit points and <AIre,DataB1> mana of the Hero when used.";
            return item;
        }

        protected virtual Item LoadIdolOfTheWild(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.IdolOfTheWild, db);
            item.AbilitiesAbilitiesRaw = "AIut";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 6;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 84;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons a Furbolg Tracker.";
            item.TextName = "Idol of the Wild";
            item.TextTooltipBasic = "Purchase Idol of the Wild";
            item.TextTooltipExtended = "Summons a Furbolg Tracker to fight for you. |nLasts <AIut,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadSpikedCollar(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SpikedCollar, db);
            item.AbilitiesAbilitiesRaw = "AIfh";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 6;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 83;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons a Fel Stalker.";
            item.TextName = "Spiked Collar";
            item.TextTooltipBasic = "Purchase Spiked Collar";
            item.TextTooltipExtended = "Summons a Fel Stalker to fight for you. |nLasts <AIfh,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadBlueDrakeEgg(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.BlueDrakeEgg, db);
            item.AbilitiesAbilitiesRaw = "AIbd";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 6;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 77;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons a Blue Drake.";
            item.TextName = "Blue Drake Egg";
            item.TextTooltipBasic = "Purchase Drake Egg";
            item.TextTooltipExtended = "Summons a Blue Drake to fight for you. |nLasts <AIbd,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadStoneToken(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.StoneToken, db);
            item.AbilitiesAbilitiesRaw = "AIfr";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 6;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 140;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons a Rock Golem.";
            item.TextName = "Stone Token";
            item.TextTooltipBasic = "Purchase Stone Token";
            item.TextTooltipExtended = "Summons a Rock Golem to fight for you. |nLasts <AIfr,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadHoodOfCunning(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HoodOfCunning, db);
            item.AbilitiesAbilitiesRaw = "AIa5,AIi5";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIa5";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 9;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 62;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides bonuses to Agility and Intelligence.";
            item.TextName = "Hood of Cunning";
            item.TextTooltipBasic = "Purchase Hood of Cunning";
            item.TextTooltipExtended = "Increases the Agility and Intelligence of the Hero by 5 when worn.";
            return item;
        }

        protected virtual Item LoadHelmOfValor(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HelmOfValor, db);
            item.AbilitiesAbilitiesRaw = "AIs5,AIa5";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIs5";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 9;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 108;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides bonuses to Strength and Agility.";
            item.TextName = "Helm of Valor";
            item.TextTooltipBasic = "Purchase Helm of Valor";
            item.TextTooltipExtended = "Increases the Strength and Agility of the Hero by 5 when worn.";
            return item;
        }

        protected virtual Item LoadMedallionOfCourage(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.MedallionOfCourage, db);
            item.AbilitiesAbilitiesRaw = "AIs5,AIi5";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIs5";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 9;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 87;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides bonuses to Strength and Intelligence.";
            item.TextName = "Medallion of Courage";
            item.TextTooltipBasic = "Purchase Medallion of Courage";
            item.TextTooltipExtended = "Increases the Strength and Intelligence of the Hero by 5 when worn.";
            return item;
        }

        protected virtual Item LoadAncientJanggoOfEndurance(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.AncientJanggoOfEndurance, db);
            item.AbilitiesAbilitiesRaw = "AIae";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AOae";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 118;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Nearby units move and attack more swiftly.";
            item.TextName = "Ancient Janggo of Endurance";
            item.TextTooltipBasic = "Purchase Ancient Janggo of Endurance";
            item.TextTooltipExtended = "Grants the Hero and friendly nearby units <AIae,DataB1,%>% increased attack speed and <AIae,DataA1,%>% movement speed. |nDoes not stack with Endurance Aura.";
            return item;
        }

        protected virtual Item LoadCloakOfFlames(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.CloakOfFlames, db);
            item.AbilitiesAbilitiesRaw = "AIcf";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIcf";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 120;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Surrounds the Hero with damaging flames.";
            item.TextName = "Cloak of Flames";
            item.TextTooltipBasic = "Purchase Cloak of Flames";
            item.TextTooltipExtended = "Engulfs the Hero in fire which deals <AIcf,DataA1> damage per second to nearby enemy land units. |nDoes not stack with Immolation.";
            return item;
        }

        protected virtual Item LoadClawsOfAttack12(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ClawsOfAttack12, db);
            item.AbilitiesAbilitiesRaw = "AItc";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 49;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts attack damage by 12.";
            item.TextName = "Claws of Attack +12";
            item.TextTooltipBasic = "Purchase Claws of Attack +12";
            item.TextTooltipExtended = "Increases the attack damage of the Hero by 12 when worn.";
            return item;
        }

        protected virtual Item LoadWarsongBattleDrumsKodo(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WarsongBattleDrumsKodo, db);
            item.AbilitiesAbilitiesRaw = "AIwd";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "Aakb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 38;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases combat effectiveness of nearby units.";
            item.TextHotkeyRaw = "W";
            item.TextName = "Warsong Battle Drums";
            item.TextTooltipBasic = "Purchase Warsong Battle Drums";
            item.TextTooltipExtended = "Increases the attack damage of nearby friendly units by <AIwd,DataA1,%>% when worn. |nDoes not stack with War Drums.";
            return item;
        }

        protected virtual Item LoadKhadgarSPipeOfInsight(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.KhadgarSPipeOfInsight, db);
            item.AbilitiesAbilitiesRaw = "AIba";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AHab";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 60;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Nearby units regain mana more swiftly.";
            item.TextName = "Khadgar's Pipe of Insight";
            item.TextTooltipBasic = "Purchase Khadgar's Pipe of Insight";
            item.TextTooltipExtended = "Grants the Hero and friendly nearby units <AIba,DataA1,.> bonus mana regeneration. |nDoes not stack with Brilliance Aura.";
            return item;
        }

        protected virtual Item LoadLegionDoomHorn(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.LegionDoomHorn, db);
            item.AbilitiesAbilitiesRaw = "AIau";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AUau";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 124;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Nearby units heal and move more swiftly.";
            item.TextName = "Legion Doom-Horn";
            item.TextTooltipBasic = "Purchase Legion Doom-Horn";
            item.TextTooltipExtended = "Grants the Hero and friendly nearby units <AIau,DataB1,.> life regeneration and <AIau,DataA1,%>% increased movement speed. |nDoes not stack with Unholy Aura.";
            return item;
        }

        protected virtual Item LoadAnkhOfReincarnation(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.AnkhOfReincarnation, db);
            item.AbilitiesAbilitiesRaw = "AIrc";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIrc";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 6;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 142;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Allows reincarnation upon death.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Ankh of Reincarnation";
            item.TextTooltipBasic = "Purchase Ankh of Reincarnation";
            item.TextTooltipExtended = "Automatically brings the Hero back to life with <AIrc,DataB1> hit points when the Hero wearing the Ankh dies.";
            return item;
        }

        protected virtual Item LoadHealingWards(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HealingWards, db);
            item.AbilitiesAbilitiesRaw = "AIhw";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "Ahwd";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 6;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 85;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 3;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Conjures a Healing Ward.";
            item.TextName = "Healing Wards";
            item.TextTooltipBasic = "Purchase Healing Wards";
            item.TextTooltipExtended = "Summons an immovable ward that heals <Aoar,DataA1,%>% of nearby friendly non-mechanical unit's hit points per second. |nContains <whwd,uses> charges. |nLasts <Ahwd,Dur1> seconds. ";
            return item;
        }

        protected virtual Item LoadBookOfTheDead(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.BookOfTheDead, db);
            item.AbilitiesAbilitiesRaw = "AIfs";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 6;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 55;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons skeletons.";
            item.TextName = "Book of the Dead";
            item.TextTooltipBasic = "Purchase Book of the Dead";
            item.TextTooltipExtended = "Summons <AIfs,DataA1> Skeleton Warriors and <AIfs,DataB1> Skeleton Archers to fight for you. |nLasts <AIfs,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadWandOfTheWind(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WandOfTheWind, db);
            item.AbilitiesAbilitiesRaw = "AIcy";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "Acyc";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 6;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 30;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 2;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Casts Cyclone.";
            item.TextName = "Wand of the Wind";
            item.TextTooltipBasic = "Purchase Wand of the Wind";
            item.TextTooltipExtended = "Allows the Hero to cast Cyclone. Cyclone tosses a target enemy unit into the air, rendering it unable to attack, move or cast spells. |nContains <wcyc,uses> charges. |nLasts <AIcy,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadHealthStone(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HealthStone, db);
            item.AbilitiesAbilitiesRaw = "AIh2,Arll";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIhe";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 4;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 122;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides faster regeneration, and can be consumed for hit points.";
            item.TextName = "Health Stone";
            item.TextTooltipBasic = "Purchase Health Stone";
            item.TextTooltipExtended = "Increases the life regeneration rate of the Hero by <Arll,DataA1> hit points per second when worn. Can be consumed for <AIh2,DataA1> health.";
            return item;
        }

        protected virtual Item LoadManaStone(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ManaStone, db);
            item.AbilitiesAbilitiesRaw = "AIm2,AIrn";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIma";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 4;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 90;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides faster mana regeneration, and can be consumed for mana.";
            item.TextName = "Mana Stone";
            item.TextTooltipBasic = "Purchase Mana Stone";
            item.TextTooltipExtended = "Increases the mana regeneration rate of the Hero by <AIrn,DataA1,%>% when worn. Can be consumed for <AIm2,DataA1> mana.";
            return item;
        }

        protected virtual Item LoadBootsOfQuelThalas6(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.BootsOfQuelThalas6, db);
            item.AbilitiesAbilitiesRaw = "AIa6";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIa6";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 8;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 78;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides a bonus to Agility.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Boots of Quel'Thalas +6";
            item.TextTooltipBasic = "Purchase Boots of Quel'Thalas";
            item.TextTooltipExtended = "Increases the Agility of the Hero by 6 when worn.";
            return item;
        }

        protected virtual Item LoadBeltOfGiantStrength6(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.BeltOfGiantStrength6, db);
            item.AbilitiesAbilitiesRaw = "AIs6";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIs6";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 8;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 106;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides a bonus to Strength.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Belt of Giant Strength +6";
            item.TextTooltipBasic = "Purchase Belt of Giant Strength";
            item.TextTooltipExtended = "Increases the Strength of the Hero by 6 when worn.";
            return item;
        }

        protected virtual Item LoadRobeOfTheMagi6(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RobeOfTheMagi6, db);
            item.AbilitiesAbilitiesRaw = "AIi6";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIi6";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 8;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 43;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides a bonus to Intelligence.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Robe of the Magi +6";
            item.TextTooltipBasic = "Purchase Robe of the Magi";
            item.TextTooltipExtended = "Increases the Intelligence of the Hero by 6 when worn.";
            return item;
        }

        protected virtual Item LoadLionHornOfStormwind(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.LionHornOfStormwind, db);
            item.AbilitiesAbilitiesRaw = "AIad";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AHad";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 76;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Generates a protective aura around the Hero.";
            item.TextName = "The Lion Horn of Stormwind";
            item.TextTooltipBasic = "Purchase the Lion Horn of Stormwind";
            item.TextTooltipExtended = "Grants the Hero and friendly nearby units <AIad,DataA1> bonus armor. |nDoes not stack with Devotion Aura.";
            return item;
        }

        protected virtual Item LoadAlleriaSFluteOfAccuracy(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.AlleriaSFluteOfAccuracy, db);
            item.AbilitiesAbilitiesRaw = "AIar";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AEar";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 46;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Nearby units' missile attacks do more damage.";
            item.TextName = "Alleria's Flute of Accuracy";
            item.TextTooltipBasic = "Purchase Alleria's Flute of Accuracy";
            item.TextTooltipExtended = "Increases nearby ranged units' damage by <AIar,DataA1,%>%. |nDoes not stack with Trueshot Aura.";
            return item;
        }

        protected virtual Item LoadScourgeBoneChimes(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScourgeBoneChimes, db);
            item.AbilitiesAbilitiesRaw = "AIav";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AUav";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 71;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Nearby units gain some life from damage they deal to enemy units.";
            item.TextName = "Scourge Bone Chimes";
            item.TextTooltipBasic = "Purchase Scourge Bone Chimes";
            item.TextTooltipExtended = "Grants a melee Hero and friendly nearby melee units life stealing attacks which take <AIav,DataA1,%>% of the damage they deal and convert it into life. |nDoes not stack with Vampiric Aura.";
            return item;
        }

        protected virtual Item LoadRunedBracers(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RunedBracers, db);
            item.AbilitiesAbilitiesRaw = "AIsr";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIsr";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 4;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 114;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Reduces Spell damage to Hero.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Runed Bracers";
            item.TextTooltipBasic = "Purchase Runed Bracers";
            item.TextTooltipExtended = "Reduces Spell damage dealt to the Hero by <AIsr,DataB1,%>%.";
            return item;
        }

        protected virtual Item LoadSobiMask(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SobiMask, db);
            item.AbilitiesAbilitiesRaw = "AIrm";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIrm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 4;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 64;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases mana regeneration rate.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Sobi Mask";
            item.TextTooltipBasic = "Purchase Sobi Mask";
            item.TextTooltipExtended = "Increases the Hero's rate of mana regeneration by <AIrm,DataA1,%>% when worn.";
            return item;
        }

        protected virtual Item LoadPotionOfGreaterHealing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfGreaterHealing, db);
            item.AbilitiesAbilitiesRaw = "AIh2";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIhe";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 121;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores lost hit points.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Potion of Greater Healing";
            item.TextTooltipBasic = "Purchase Potion of Greater Healing";
            item.TextTooltipExtended = "Heals <AIh2,DataA1> hit points when used.";
            return item;
        }

        protected virtual Item LoadPotionOfGreaterMana(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfGreaterMana, db);
            item.AbilitiesAbilitiesRaw = "AIm2";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIma";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 68;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores lost mana.";
            item.TextHotkeyRaw = "M";
            item.TextName = "Potion of Greater Mana";
            item.TextTooltipBasic = "Purchase Potion of Greater Mana";
            item.TextTooltipExtended = "Restores <AIm2,DataA1> mana when used.";
            return item;
        }

        protected virtual Item LoadPotionOfInvulnerability(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfInvulnerability, db);
            item.AbilitiesAbilitiesRaw = "AIvu";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIvu";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 102;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Renders Hero temporarily invulnerable.";
            item.TextHotkeyRaw = "I";
            item.TextName = "Potion of Invulnerability";
            item.TextTooltipBasic = "Purchase Potion of Invulnerability";
            item.TextTooltipExtended = "Makes the Hero invulnerable to damage for <AIvu,Dur1> seconds when used. An invulnerable Hero may not be the target of spells or effects.";
            return item;
        }

        protected virtual Item LoadScrollOfTheBeast(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfTheBeast, db);
            item.AbilitiesAbilitiesRaw = "AIrr";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "Aroa";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 63;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts friendly unit combat damage.";
            item.TextName = "Scroll of the Beast";
            item.TextTooltipBasic = "Purchase Scroll of the Beast";
            item.TextTooltipExtended = "Gives friendly nearby units a <AIrr,DataA1,%>% bonus to damage for <AIrr,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadWandOfManaStealing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WandOfManaStealing, db);
            item.AbilitiesAbilitiesRaw = "Aste";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "Aste";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 69;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 2;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Steals mana.";
            item.TextHotkeyRaw = "W";
            item.TextName = "Wand of Mana Stealing";
            item.TextTooltipBasic = "Purchase Wand of Mana Stealing";
            item.TextTooltipExtended = "Steals <Aste,DataA1> mana instantly from a target unit and gives it to the Hero. |nContains <woms,uses> charges.";
            return item;
        }

        protected virtual Item LoadCrystalBall(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.CrystalBall, db);
            item.AbilitiesAbilitiesRaw = "AIta";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIta";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 3;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Permits the viewing of distant areas.";
            item.TextHotkeyRaw = "C";
            item.TextName = "Crystal Ball";
            item.TextTooltipBasic = "Purchase Crystal Ball";
            item.TextTooltipExtended = "Reveals a targeted area. Invisible units are also revealed by the Crystal Ball's effect. |nLasts <AIta,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadTalismanOfEvasion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TalismanOfEvasion, db);
            item.AbilitiesAbilitiesRaw = "AIev";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AEev";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 99;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Makes the Hero harder to hit.";
            item.TextName = "Talisman of Evasion";
            item.TextTooltipBasic = "Purchase Talisman of Evasion";
            item.TextTooltipExtended = "Causes attacks against the wearer to miss <AIev,DataA1,%>% of the time. |nDoes not stack with Evasion or Drunken Brawler.";
            return item;
        }

        protected virtual Item LoadPendantOfEnergy(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PendantOfEnergy, db);
            item.AbilitiesAbilitiesRaw = "AImb";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AImm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 4;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 50;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides additional mana.";
            item.TextName = "Pendant of Energy";
            item.TextTooltipBasic = "Purchase Pendant of Energy";
            item.TextTooltipExtended = "Increases the mana capacity of the Hero by <AImb,DataA1> when worn.";
            return item;
        }

        protected virtual Item LoadPeriaptOfVitality(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PeriaptOfVitality, db);
            item.AbilitiesAbilitiesRaw = "AIlf";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIml";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 4;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 107;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases the hit points of the Hero.";
            item.TextHotkeyRaw = "V";
            item.TextName = "Periapt of Vitality";
            item.TextTooltipBasic = "Purchase Periapt of Vitality";
            item.TextTooltipExtended = "Increases the hit points of the Hero by <AIlf,DataA1> when worn.";
            return item;
        }

        protected virtual Item LoadClawsOfAttack9(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ClawsOfAttack9, db);
            item.AbilitiesAbilitiesRaw = "AIt9";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 4;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 48;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts attack damage by 8.";
            item.TextHotkeyRaw = "C";
            item.TextName = "Claws of Attack +8";
            item.TextTooltipBasic = "Purchase Claws of Attack +8";
            item.TextTooltipExtended = "Increases the attack damage of the Hero by 8 when worn.";
            return item;
        }

        protected virtual Item LoadRingOfProtection4(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RingOfProtection4, db);
            item.AbilitiesAbilitiesRaw = "AId4";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIde";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 125;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 8;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 116;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts armor by 4.";
            item.TextHotkeyRaw = "4";
            item.TextName = "Ring of Protection +4";
            item.TextTooltipBasic = "Purchase Ring of Protection +4";
            item.TextTooltipExtended = "Increases the armor of the Hero by 4 when worn.";
            return item;
        }

        protected virtual Item LoadRingOfRegeneration(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RingOfRegeneration, db);
            item.AbilitiesAbilitiesRaw = "Arel";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "Arel";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 4;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 42;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides regeneration.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Ring of Regeneration";
            item.TextTooltipBasic = "Purchase Ring of Regeneration";
            item.TextTooltipExtended = "Increases the Hero's hit point regeneration by <Arel,DataA1> hit points per second.";
            return item;
        }

        protected virtual Item LoadBootsOfSpeed(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.BootsOfSpeed, db);
            item.AbilitiesAbilitiesRaw = "AIms";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIms";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 41;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 220;
            item.StatsStockInitialAfterStartDelay = 2;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases movement rate.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Boots of Speed";
            item.TextTooltipBasic = "Purchase Boots of Speed";
            item.TextTooltipExtended = "Increases the movement speed of the Hero when worn.";
            return item;
        }

        protected virtual Item LoadReplenishmentPotion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ReplenishmentPotion, db);
            item.AbilitiesAbilitiesRaw = "AIp3";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIrg";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 1;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 75;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 0;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates health and mana.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Replenishment Potion";
            item.TextTooltipBasic = "Purchase Replenishment Potion";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRegenerates <AIp3,DataA1> hit points and <AIp3,DataB1> mana of the Hero over <AIp3,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadWandOfIllusion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WandOfIllusion, db);
            item.AbilitiesAbilitiesRaw = "AIil";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIil";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 14;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 2;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates a phantom double.";
            item.TextHotkeyRaw = "I";
            item.TextName = "Wand of Illusion";
            item.TextTooltipBasic = "Purchase Wand of Illusion";
            item.TextTooltipExtended = "Create an illusory double of the targeted unit when used. The illusory double deals no damage to enemy units, takes <AIil,DataB1> times the damage from enemy attacks, and will disappear after <AIil,Dur1> seconds or when its hit points reach zero. |nContains <will,uses> charges.";
            return item;
        }

        protected virtual Item LoadWandOfLightningShield(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WandOfLightningShield, db);
            item.AbilitiesAbilitiesRaw = "AIls";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIls";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 8;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 2;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Casts Lightning Shield.";
            item.TextName = "Wand of Lightning Shield";
            item.TextTooltipBasic = "Purchase Wand of Lightning Shield";
            item.TextTooltipExtended = "Allows the Hero to cast Lightning Shield on a target unit. Lightning Shield surrounds a unit with electricity, dealing <AIls,DataA1> damage per second to nearby units. |nContains <wlsd,uses> charges. |nLasts <AIls,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadSentryWards(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SentryWards, db);
            item.AbilitiesAbilitiesRaw = "AIsw";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "Aeye";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 2;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Conjures a Sentry Ward.";
            item.TextName = "Sentry Wards";
            item.TextTooltipBasic = "Purchase Sentry Wards";
            item.TextTooltipExtended = "Drops a Sentry Ward to spy upon an area for <AIsw,Dur1> seconds. |nContains <wswd,uses> charges.";
            return item;
        }

        protected virtual Item LoadCircletOfNobility(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.CircletOfNobility, db);
            item.AbilitiesAbilitiesRaw = "AIx2";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIx2";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 175;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 4;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 79;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides a +2 bonus to Strength, Agility and Intelligence.";
            item.TextHotkeyRaw = "C";
            item.TextName = "Circlet of Nobility";
            item.TextTooltipBasic = "Purchase Circlet of Nobility";
            item.TextTooltipExtended = "Increases the Strength, Agility and Intelligence of the Hero by 2 when worn.";
            return item;
        }

        protected virtual Item LoadGlovesOfHaste(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GlovesOfHaste, db);
            item.AbilitiesAbilitiesRaw = "AIsx";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIas";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 125;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 32;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases attack speed.";
            item.TextName = "Gloves of Haste";
            item.TextTooltipBasic = "Purchase Gloves of Haste";
            item.TextTooltipExtended = "Increases the attack speed of the Hero by <AIsx,DataA1,%>% when worn.";
            return item;
        }

        protected virtual Item LoadClawsOfAttack6(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ClawsOfAttack6, db);
            item.AbilitiesAbilitiesRaw = "AItj";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 125;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 44;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts attack damage by 5.";
            item.TextName = "Claws of Attack +5";
            item.TextTooltipBasic = "Purchase Claws of Attack +5";
            item.TextTooltipExtended = "Increases the attack damage of the Hero by 5 when worn.";
            return item;
        }

        protected virtual Item LoadRingOfProtection3(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RingOfProtection3, db);
            item.AbilitiesAbilitiesRaw = "AId3";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIde";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 105;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts armor by 3.";
            item.TextHotkeyRaw = "3";
            item.TextName = "Ring of Protection +3";
            item.TextTooltipBasic = "Purchase Ring of Protection +3";
            item.TextTooltipExtended = "Increases the armor of the Hero by 3 when worn.";
            return item;
        }

        protected virtual Item LoadTomeOfAgility2(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfAgility2, db);
            item.AbilitiesAbilitiesRaw = "AIgm";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIgm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 5;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Permanently increases Agility.";
            item.TextName = "Tome of Agility +2";
            item.TextTooltipBasic = "Purchase Tome of Agility +2";
            item.TextTooltipExtended = "Permanently increases the Agility of the Hero by 2 when used.";
            return item;
        }

        protected virtual Item LoadTomeOfIntelligence2(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfIntelligence2, db);
            item.AbilitiesAbilitiesRaw = "AItm";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AItm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 5;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Permanently increases Intelligence.";
            item.TextName = "Tome of Intelligence +2";
            item.TextTooltipBasic = "Purchase Tome of Intelligence +2";
            item.TextTooltipExtended = "Permanently increases the Intelligence of the Hero by 2 when used.";
            return item;
        }

        protected virtual Item LoadTomeOfKnowledge(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfKnowledge, db);
            item.AbilitiesAbilitiesRaw = "AIxm";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIxm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 5;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Permanently increases Strength, Agility and Intelligence.";
            item.TextName = "Tome of Knowledge";
            item.TextTooltipBasic = "Purchase Tome of Knowledge";
            item.TextTooltipExtended = "Permanently increases the Strength, Agility and Intelligence of the Hero by 1 when used.";
            return item;
        }

        protected virtual Item LoadTomeOfStrength2(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfStrength2, db);
            item.AbilitiesAbilitiesRaw = "AInm";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AInm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 5;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Permanently increases Strength.";
            item.TextName = "Tome of Strength +2";
            item.TextTooltipBasic = "Purchase Tome of Strength +2";
            item.TextTooltipExtended = "Permanently increases the Strength of the Hero by 2 when used.";
            return item;
        }

        protected virtual Item LoadPotionOfLesserInvulnerability(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfLesserInvulnerability, db);
            item.AbilitiesAbilitiesRaw = "AIvl";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIvu";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 40;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Renders Hero temporarily invulnerable.";
            item.TextHotkeyRaw = "N";
            item.TextName = "Potion of Lesser Invulnerability";
            item.TextTooltipBasic = "Purchase Potion of Lesser Invulnerability";
            item.TextTooltipExtended = "Makes the Hero invulnerable to damage for <AIvl,Dur1> seconds when used. An invulnerable Hero may not be the target of spells or effects.";
            return item;
        }

        protected virtual Item LoadCloakOfShadows(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.CloakOfShadows, db);
            item.AbilitiesAbilitiesRaw = "AIhm";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIhm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 2;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Allows the hero to turn invisible.";
            item.TextHotkeyRaw = "C";
            item.TextName = "Cloak of Shadows";
            item.TextTooltipBasic = "Purchase Cloak of Shadows";
            item.TextTooltipExtended = "Provides the Hero with invisibility when worn. An invisible Hero is untargetable by the enemy unless detected. If the Hero moves, attacks, uses an ability, or casts a spell, the invisibility effect is lost.";
            return item;
        }

        protected virtual Item LoadSlippersOfAgility3(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SlippersOfAgility3, db);
            item.AbilitiesAbilitiesRaw = "AIa3";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIa3";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 104;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Agility by 3.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Slippers of Agility +3";
            item.TextTooltipBasic = "Purchase Slippers of Agility +3";
            item.TextTooltipExtended = "Increases the Agility of the Hero by 3 when worn.";
            return item;
        }

        protected virtual Item LoadMantleOfIntelligence3(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.MantleOfIntelligence3, db);
            item.AbilitiesAbilitiesRaw = "AIi3";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIi3";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 23;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Intelligence by 3.";
            item.TextHotkeyRaw = "I";
            item.TextName = "Mantle of Intelligence +3";
            item.TextTooltipBasic = "Purchase Mantle of Intelligence +3";
            item.TextTooltipExtended = "Increases the Intelligence of the Hero by 3 when worn.";
            return item;
        }

        protected virtual Item LoadGauntletsOfOgreStrength3(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GauntletsOfOgreStrength3, db);
            item.AbilitiesAbilitiesRaw = "AIs3";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIs3";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 58;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Strength by 3.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Gauntlets of Ogre Strength +3";
            item.TextTooltipBasic = "Purchase Gauntlets of Ogre Strength +3";
            item.TextTooltipExtended = "Increases the Strength of the Hero by 3 when worn.";
            return item;
        }

        protected virtual Item LoadManualOfHealth(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ManualOfHealth, db);
            item.AbilitiesAbilitiesRaw = "AImh";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AImi";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 1;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Permanent +50 hit points.";
            item.TextName = "Manual of Health";
            item.TextTooltipBasic = "Purchase Manual of Health";
            item.TextTooltipExtended = "Permanently increases the hit points of the Hero by <AImh,DataA1> when used.";
            return item;
        }

        protected virtual Item LoadTomeOfAgility1(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfAgility1, db);
            item.AbilitiesAbilitiesRaw = "AIam";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIam";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 1;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Permanently increases Agility.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Tome of Agility";
            item.TextTooltipBasic = "Purchase Tome of Agility";
            item.TextTooltipExtended = "Permanently increases the Agility of the Hero by <AIam,DataA1> when used.";
            return item;
        }

        protected virtual Item LoadTomeOfIntelligence(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfIntelligence, db);
            item.AbilitiesAbilitiesRaw = "AIim";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIim";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 1;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Permanently increases Intelligence.";
            item.TextHotkeyRaw = "T";
            item.TextName = "Tome of Intelligence";
            item.TextTooltipBasic = "Purchase Tome of Intelligence";
            item.TextTooltipExtended = "Permanently increases the Intelligence of the Hero by <AIim,DataB1> when used.";
            return item;
        }

        protected virtual Item LoadTomeOfStrength1(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfStrength1, db);
            item.AbilitiesAbilitiesRaw = "AIsm";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIsm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 1;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Permanently increases Strength.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Tome of Strength";
            item.TextTooltipBasic = "Purchase Tome of Strength";
            item.TextTooltipExtended = "Permanently increases the Strength of the Hero by <AIsm,DataC1> when used.";
            return item;
        }

        protected virtual Item LoadPotionOfOmniscience(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfOmniscience, db);
            item.AbilitiesAbilitiesRaw = "AIrv";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "AIrv";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Reveals the entire map.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Potion of Omniscience";
            item.TextTooltipBasic = "Purchase Potion of Omniscience";
            item.TextTooltipExtended = "Reveals the entire map for <AIrv,Dur1> seconds when used.";
            return item;
        }

        protected virtual Item LoadWandOfShadowsight(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WandOfShadowsight, db);
            item.AbilitiesAbilitiesRaw = "Ashs";
            item.StatsClassificationRaw = "Charged";
            item.StatsCooldownGroupRaw = "Ashs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 2;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Grants vision of a target unit.";
            item.TextHotkeyRaw = "W";
            item.TextName = "Wand of Shadowsight";
            item.TextTooltipBasic = "Purchase Wand of Shadowsight";
            item.TextTooltipExtended = "Gives the player vision of a target unit until that unit is dispelled. |nContains <wshs,uses> charges.";
            return item;
        }

        protected virtual Item LoadGreaterScrollOfReplenishment(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GreaterScrollOfReplenishment, db);
            item.AbilitiesAbilitiesRaw = "AIp6";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIrg";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 6;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 1;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 130;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 0;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates the health and mana of nearby units.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Greater Scroll of Replenishment";
            item.TextTooltipBasic = "Purchase Greater Scroll of Replenishment";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRegenerates <AIp6,DataA1> hit points and <AIp6,DataB1> mana of the Hero and nearby friendly units over <AIp6,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadLesserScrollOfReplenishment(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.LesserScrollOfReplenishment, db);
            item.AbilitiesAbilitiesRaw = "AIp5";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIrg";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 5;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 1;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 129;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 0;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates the health and mana of nearby units.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Lesser Scroll of Replenishment";
            item.TextTooltipBasic = "Purchase Lesser Scroll of Replenishment";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRegenerates <AIp5,DataA1> hit points and <AIp5,DataB1> mana of the Hero and nearby friendly units over <AIp5,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadGreaterReplenishmentPotion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GreaterReplenishmentPotion, db);
            item.AbilitiesAbilitiesRaw = "AIp4";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIrg";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 1;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 119;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 0;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates health and mana.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Greater Replenishment Potion";
            item.TextTooltipBasic = "Purchase Greater Replenishment Potion";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRegenerates <AIp4,DataA1> hit points and <AIp4,DataB1> mana of the Hero over <AIp4,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadFourthRingOfTheArchmagi(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.FourthRingOfTheArchmagi, db);
            item.AbilitiesAbilitiesRaw = "AIx3,AIba";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AHab";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 750;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 145;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A powerful artifact with a wondrous gem.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Ring of the Archmagi";
            item.TextTooltipBasic = "Purchase Ring of the Archmagi";
            item.TextTooltipExtended = "A powerful artifact with a wondrous gem inset. Increases the Strength, Agility and Intelligence of the Hero by 3 and gives nearby friendly units a bonus to mana regeneration.";
            return item;
        }

        protected virtual Item LoadDiamondOfSummoning(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.DiamondOfSummoning, db);
            item.AbilitiesAbilitiesRaw = "AUds";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AUds";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons your units to your Hero.";
            item.TextHotkeyRaw = "D";
            item.TextName = "Diamond of Summoning";
            item.TextTooltipBasic = "Purchase Diamond of Summoning";
            item.TextTooltipExtended = "Teleports <AUds,DataA1> of the player's units within the targeted area to the location of the Hero when used.";
            return item;
        }

        protected virtual Item LoadOrbOfFire(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrbOfFire, db);
            item.AbilitiesAbilitiesRaw = "AIfb";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIfb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 95;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Attacks also do fire damage.";
            item.TextHotkeyRaw = "F";
            item.TextName = "Orb of Fire";
            item.TextTooltipBasic = "Purchase Orb of Fire";
            item.TextTooltipExtended = "Adds <AIfb,DataA1> bonus fire damage to the attack of a Hero when carried. The Hero's attacks also become ranged when attacking air and do splash damage to nearby enemy units.";
            return item;
        }

        protected virtual Item LoadOrbOfCorruption(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrbOfCorruption, db);
            item.AbilitiesAbilitiesRaw = "AIcb";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIcb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 375;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 93;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Attacks reduce armor.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Orb of Corruption";
            item.TextTooltipBasic = "Purchase Orb of Corruption";
            item.TextTooltipExtended = "Adds <AIcb,DataA1> bonus damage to the attack of a Hero when carried. The Hero's attacks also become ranged when attacking air and reduce the armor of enemy units for <AIcb,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadOrbOfLightning(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrbOfLightning, db);
            item.AbilitiesAbilitiesRaw = "AIll";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIll";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 375;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 91;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Attacks cause lightning damage.";
            item.TextHotkeyRaw = "L";
            item.TextName = "Orb of Lightning";
            item.TextTooltipBasic = "Purchase Orb of Lightning";
            item.TextTooltipExtended = "Adds <AIll,DataA1> bonus damage to the attack of a Hero when carried. The Hero's attacks also become ranged when attacking air, and have a chance to dispel magic and immobilize the enemy for <AIpg,DataD1> seconds; they will slowly regain their movement speed over <AIpg,Dur1> seconds. |n|cffffcc00Deals <AIpg,DataC1> bonus damage to summoned units.";
            return item;
        }

        protected virtual Item LoadOrbOfVenom(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrbOfVenom, db);
            item.AbilitiesAbilitiesRaw = "AIpb,Apo2";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIpb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 325;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 94;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Attacks cause poison damage.";
            item.TextHotkeyRaw = "V";
            item.TextName = "Orb of Venom";
            item.TextTooltipBasic = "Purchase Orb of Venom";
            item.TextTooltipExtended = "Adds <AIpb,DataA1> bonus damage to the attack of a Hero when carried. The Hero's attacks also become ranged when attacking air and poison enemy units for <Apo2,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadThirdRingOfTheArchmagi(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ThirdRingOfTheArchmagi, db);
            item.AbilitiesAbilitiesRaw = "AIx3";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIab";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 4;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 109;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A powerful artifact with a nearly intact gem.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Ring of the Archmagi";
            item.TextTooltipBasic = "Purchase Ring of the Archmagi";
            item.TextTooltipExtended = "A powerful artifact with most of a fragmented gem inset. Increases the Strength, Agility and Intelligence of the Hero by 3.";
            return item;
        }

        protected virtual Item LoadTomeOfRetraining(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfRetraining, db);
            item.AbilitiesAbilitiesRaw = "Aret";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "Aret";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 2;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Unlearns a Hero's skills.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Tome of Retraining";
            item.TextTooltipBasic = "Purchase Tome of Retraining";
            item.TextTooltipExtended = "Unlearns all of the Hero's spells, allowing the Hero to learn different skills.";
            return item;
        }

        protected virtual Item LoadTinyGreatHall(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TinyGreatHall, db);
            item.AbilitiesAbilitiesRaw = "AIbg";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIbl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 600;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 185;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates a Great Hall.";
            item.TextHotkeyRaw = "G";
            item.TextName = "Tiny Great Hall";
            item.TextTooltipBasic = "Purchase Tiny Great Hall";
            item.TextTooltipExtended = "Creates a Great Hall at a target location. Human, Night Elf, and Undead players will get their racial equivalent town hall.";
            return item;
        }

        protected virtual Item LoadLesserReplenishmentPotion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.LesserReplenishmentPotion, db);
            item.AbilitiesAbilitiesRaw = "AIp2";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIrg";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 1;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 72;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 0;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates health and mana.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Lesser Replenishment Potion";
            item.TextTooltipBasic = "Purchase Lesser Replenishment Potion";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRegenerates <AIp2,DataA1> hit points and <AIp2,DataB1> mana of the Hero over <AIp2,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadGemOfTrueSeeing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GemOfTrueSeeing, db);
            item.AbilitiesAbilitiesRaw = "Adt1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Adet";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 35;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Permits invisible units to be seen.";
            item.TextHotkeyRaw = "G";
            item.TextName = "Gem of True Seeing";
            item.TextTooltipBasic = "Purchase Gem of True Seeing";
            item.TextTooltipExtended = "Allows the Hero to detect hidden or invisible units in the Hero's line of sight when carried.";
            return item;
        }

        protected virtual Item LoadSecondRingOfTheArchmagi(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SecondRingOfTheArchmagi, db);
            item.AbilitiesAbilitiesRaw = "AIx2";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIab";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 52;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A powerful artifact with a fragmented gem.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Ring of the Archmagi";
            item.TextTooltipBasic = "Purchase Ring of the Archmagi";
            item.TextTooltipExtended = "A powerful artifact with a part of a fragmented gem inset. Increases the Strength, Agility and Intelligence of the Hero by 2.";
            return item;
        }

        protected virtual Item LoadStaffOfTeleportation(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.StaffOfTeleportation, db);
            item.AbilitiesAbilitiesRaw = "AImt";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AHmt";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 220;
            item.StatsStockInitialAfterStartDelay = 2;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Teleports the Hero.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Staff of Teleportation";
            item.TextTooltipBasic = "Purchase Staff of Teleportation";
            item.TextTooltipExtended = "Teleports the Hero to the targeted allied land unit or structure.";
            return item;
        }

        protected virtual Item LoadScrollOfTownPortal(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfTownPortal, db);
            item.AbilitiesAbilitiesRaw = "AItp";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AItp";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 325;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 123;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Transports troops to friendly town hall.";
            item.TextHotkeyRaw = "T";
            item.TextName = "Scroll of Town Portal";
            item.TextTooltipBasic = "Purchase Scroll of Town Portal";
            item.TextTooltipExtended = "Teleports the Hero and any of its nearby troops to a target friendly town hall.";
            return item;
        }

        protected virtual Item LoadWandOfNegation(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WandOfNegation, db);
            item.AbilitiesAbilitiesRaw = "AIdi";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIdi";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 1;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 110;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 3;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Dispels magic in an area.";
            item.TextHotkeyRaw = "N";
            item.TextName = "Wand of Negation";
            item.TextTooltipBasic = "Purchase Wand of Negation";
            item.TextTooltipExtended = "Dispels all magical effects in a target area. |nContains <wneg,uses> charges. |n|cffffcc00Deals <AIdi,DataB1> damage to summoned units.|r";
            return item;
        }

        protected virtual Item LoadStaffOfNegation(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.StaffOfNegation, db);
            item.AbilitiesAbilitiesRaw = "AIds";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIds";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 112;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Dispels magic in an area.";
            item.TextHotkeyRaw = "N";
            item.TextName = "Staff of Negation";
            item.TextTooltipBasic = "Purchase Staff of Negation";
            item.TextTooltipExtended = "Dispels all magical effects in a target area. |n|cffffcc00Deals <AIdi,DataB1> damage to summoned units.|r";
            return item;
        }

        protected virtual Item LoadWandOfNeutralization(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WandOfNeutralization, db);
            item.AbilitiesAbilitiesRaw = "AIdc";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIdc";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 111;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 4;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Dispels magical effects in a chain.";
            item.TextHotkeyRaw = "N";
            item.TextName = "Wand of Neutralization";
            item.TextTooltipBasic = "Purchase Wand of Neutralization";
            item.TextTooltipExtended = "Hurls forth a stream of neutralizing magic that bounces up to <AIdc,DataC1> times, dispelling units in its wake. |nContains <wneu,uses> charges.";
            return item;
        }

        protected virtual Item LoadScrollOfHealing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfHealing, db);
            item.AbilitiesAbilitiesRaw = "AIha";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIha";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 73;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores hit points to nearby units.";
            item.TextHotkeyRaw = "H";
            item.TextName = "Scroll of Healing";
            item.TextTooltipBasic = "Purchase Scroll of Healing";
            item.TextTooltipExtended = "Heals <AIha,DataA1> hit points to all friendly non-mechanical units around the Hero when used.";
            return item;
        }

        protected virtual Item LoadScrollOfMana(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfMana, db);
            item.AbilitiesAbilitiesRaw = "AImr";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AImr";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 65;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 5;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores mana to nearby units.";
            item.TextHotkeyRaw = "M";
            item.TextName = "Scroll of Mana";
            item.TextTooltipBasic = "Purchase Scroll of Mana";
            item.TextTooltipExtended = "Restores <AImr,DataA1> mana to all friendly units in an area around your Hero.";
            return item;
        }

        protected virtual Item LoadMinorReplenishmentPotion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.MinorReplenishmentPotion, db);
            item.AbilitiesAbilitiesRaw = "AIp1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIrg";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 1;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 31;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 0;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates health and mana.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Minor Replenishment Potion";
            item.TextTooltipBasic = "Purchase Minor Replenishment Potion";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRegenerates <AIp1,DataA1> hit points and <AIp1,DataB1> mana of the Hero over <AIp1,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadPotionOfSpeed(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfSpeed, db);
            item.AbilitiesAbilitiesRaw = "AIsp";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIsp";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 75;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 7;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 45;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides Hero with a temporary speed increase.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Potion of Speed";
            item.TextTooltipBasic = "Purchase Potion of Speed";
            item.TextTooltipExtended = "Increases the movement speed of the Hero by <AIsp,DataA1,%>% for <AIsp,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadDustOfAppearance(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.DustOfAppearance, db);
            item.AbilitiesAbilitiesRaw = "AItb";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AItb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 75;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 2;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Reveals invisible units.";
            item.TextHotkeyRaw = "D";
            item.TextName = "Dust of Appearance";
            item.TextTooltipBasic = "Purchase Dust of Appearance";
            item.TextTooltipExtended = "Reveals enemy invisible units in an area around the Hero. |nContains <dust,uses> charges. |nLasts <AItb,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadFirstRingOfTheArchmagi(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.FirstRingOfTheArchmagi, db);
            item.AbilitiesAbilitiesRaw = "AIx1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIab";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 125;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 24;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A powerful artifact with a shattered gem.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Ring of the Archmagi";
            item.TextTooltipBasic = "Purchase Ring of the Archmagi";
            item.TextTooltipExtended = "A powerful artifact with a sliver of a fragmented gem inset. Increases the Strength, Agility and Intelligence of the Hero by 1.";
            return item;
        }

        protected virtual Item LoadPotionOfInvisibility(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfInvisibility, db);
            item.AbilitiesAbilitiesRaw = "AIv1";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIvi";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 33;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Renders Hero temporarily invisible.";
            item.TextHotkeyRaw = "I";
            item.TextName = "Potion of Invisibility";
            item.TextTooltipBasic = "Purchase Potion of Invisibility";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRenders the Hero invisible for <AIv1,Dur1> seconds when used. An invisible Hero is untargetable by the enemy unless detected. If the Hero attacks, uses an ability, or casts a spell, the invisibility effect is lost.";
            return item;
        }

        protected virtual Item LoadPotionOfHealing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfHealing, db);
            item.AbilitiesAbilitiesRaw = "AIh1";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIhe";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 74;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores lost hit points.";
            item.TextHotkeyRaw = "P";
            item.TextName = "Potion of Healing";
            item.TextTooltipBasic = "Purchase Potion of Healing";
            item.TextTooltipExtended = "Heals <AIh1,DataA1> hit points when used.";
            return item;
        }

        protected virtual Item LoadPotionOfMana(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfMana, db);
            item.AbilitiesAbilitiesRaw = "AIm1";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIma";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 66;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores lost mana.";
            item.TextHotkeyRaw = "M";
            item.TextName = "Potion of Mana";
            item.TextTooltipBasic = "Purchase Potion of Mana";
            item.TextTooltipExtended = "Restores <AIm1,DataA1> mana when used.";
            return item;
        }

        protected virtual Item LoadScrollOfProtection(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfProtection, db);
            item.AbilitiesAbilitiesRaw = "AIda";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIda";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 103;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Temporarily increases the armor of nearby units.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Scroll of Protection";
            item.TextTooltipBasic = "Purchase Scroll of Protection";
            item.TextTooltipExtended = "Increases the armor of all friendly units in an area around your Hero by <AIda,DataA1> for <AIda,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadHealingSalve(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HealingSalve, db);
            item.AbilitiesAbilitiesRaw = "AIrl";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIrg";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 82;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 3;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates lost hit points over time.";
            item.TextHotkeyRaw = "H";
            item.TextName = "Healing Salve";
            item.TextTooltipBasic = "Purchase Healing Salve";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRegenerates a target unit's hit points by <AIrl,DataA1> over <AIrl,Dur1> seconds when used. |nContains <hslv,uses> charges.";
            return item;
        }

        protected virtual Item LoadMoonstone(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.Moonstone, db);
            item.AbilitiesAbilitiesRaw = "AIct";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIct";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 1;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Makes it night time.";
            item.TextHotkeyRaw = "N";
            item.TextName = "Moonstone";
            item.TextTooltipBasic = "Purchase Moonstone";
            item.TextTooltipExtended = "Causes an eclipse that blocks out the sun and creates an artificial night. |nLasts <AIct,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadScrollOfSpeed(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfSpeed, db);
            item.AbilitiesAbilitiesRaw = "AIsa";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIsp";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 70;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 34;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases movement speed of units.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Scroll of Speed";
            item.TextTooltipBasic = "Purchase Scroll of Speed";
            item.TextTooltipExtended = "Increases the movement speed of the Hero and nearby allied units to the maximum movement speed. |nLasts <AIsa,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadSacrificialSkull(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SacrificialSkull, db);
            item.AbilitiesAbilitiesRaw = "Ablp";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "Ablp";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 45;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates Blight at a target location.";
            item.TextHotkeyRaw = "K";
            item.TextName = "Sacrificial Skull";
            item.TextTooltipBasic = "Purchase Sacrificial Skull";
            item.TextTooltipExtended = "Creates an area of Blight at a target location.";
            return item;
        }

        protected virtual Item LoadMechanicalCritter(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.MechanicalCritter, db);
            item.AbilitiesAbilitiesRaw = "Amec";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "Amec";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates a mechanical critter.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Mechanical Critter";
            item.TextTooltipBasic = "Purchase Mechanical Critter";
            item.TextTooltipExtended = "Creates a player-controlled critter that can be used to scout enemies.";
            return item;
        }

        protected virtual Item LoadRodOfNecromancy(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RodOfNecromancy, db);
            item.AbilitiesAbilitiesRaw = "AIrd";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIrd";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 86;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 4;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates two Skeleton Warriors from a corpse.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Rod of Necromancy";
            item.TextTooltipBasic = "Purchase Rod of Necromancy";
            item.TextTooltipExtended = "Creates two Skeleton Warriors from a corpse. |nContains <rnec,uses> charges.";
            return item;
        }

        protected virtual Item LoadRitualDagger(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RitualDagger, db);
            item.AbilitiesAbilitiesRaw = "AIg2";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIg2";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 86;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 2;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Sacrifices a unit to regenerate the health of nearby units.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Ritual Dagger";
            item.TextTooltipBasic = "Purchase Ritual Dagger";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nSacrifices a friendly Undead unit to regenerate <AIg2,DataA1> hit points to all friendly non-mechanical units around it over <AIg2,Dur1> seconds. |nContains <ritd,uses> charges.";
            return item;
        }

        protected virtual Item LoadIvoryTower(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.IvoryTower, db);
            item.AbilitiesAbilitiesRaw = "AIbt";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIbl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 40;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 25;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 30;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates a Scout Tower.";
            item.TextHotkeyRaw = "V";
            item.TextName = "Ivory Tower";
            item.TextTooltipBasic = "Purchase Ivory Tower";
            item.TextTooltipExtended = "Creates a Scout Tower at a target location.";
            return item;
        }

        protected virtual Item LoadHeartOfAszune(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HeartOfAszune, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "The magical amulet Heart of Aszune.";
            item.TextName = "Heart of Aszune";
            item.TextTooltipBasic = "Purchase Heart of Aszune";
            item.TextTooltipExtended = "Legends say that the imprisoned spirit of Aszune seeks out her heart to this very day.";
            return item;
        }

        protected virtual Item LoadEmptyVial(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.EmptyVial, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This is an empty vial.";
            item.TextName = "Empty Vial";
            item.TextTooltipBasic = "Purchase Empty Vial";
            item.TextTooltipExtended = "A special vial adept at containing the magical healing waters of a Fountain of Life.";
            return item;
        }

        protected virtual Item LoadFullVial(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.FullVial, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This vial is full of healing waters.";
            item.TextName = "Full Vial";
            item.TextTooltipBasic = "Purchase Full Vial";
            item.TextTooltipExtended = "A special vial adept at containing the magical healing waters of a Fountain of Life.";
            return item;
        }

        protected virtual Item LoadCheese(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.Cheese, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "It's the Cheese!";
            item.TextName = "Cheese";
            item.TextTooltipBasic = "Purchase the Cheese";
            item.TextTooltipExtended = "Cheese cheese cheese cheese!";
            return item;
        }

        protected virtual Item LoadHornOfCenarius(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HornOfCenarius, db);
            item.AbilitiesAbilitiesRaw = "Arel,AIl1";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This is the Horn of Cenarius.";
            item.TextName = "Horn of Cenarius";
            item.TextTooltipBasic = "Purchase Horn of Cenarius";
            item.TextTooltipExtended = "This ancient relic of the Night Elves is said to hold the power to call the spirits of all Night Elves. It imbues its owner with <AIl1,DataA1> hit points, and a <Arel,DataA1> hit point per second regeneration bonus.";
            return item;
        }

        protected virtual Item LoadGuldanSSkull(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GuldanSSkull, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This is the Skull of Gul'dan.";
            item.TextName = "Skull of Gul'dan";
            item.TextTooltipBasic = "Purchase Skull of Gul'dan";
            item.TextTooltipExtended = "Once a powerful user of Demonic magics, the Demons answered his calls, and found a greater use for his head.";
            return item;
        }

        protected virtual Item LoadGlyphOfPurification(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GlyphOfPurification, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A glyph.";
            item.TextName = "Glyph of Purification";
            item.TextTooltipBasic = "Purchase Glyph of Purification";
            item.TextTooltipExtended = "Created by ancient druids, this glyph has the power to heal the land.";
            return item;
        }

        protected virtual Item LoadKeyOf3Moons1(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.KeyOf3Moons1, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This is one part of the Key of Three Moons.";
            item.TextName = "Mooncrystal";
            item.TextTooltipBasic = "Purchase Mooncrystal";
            item.TextTooltipExtended = "Cut from the emerald Eye of Jennala, it opens the mind of the Gate Keeper.";
            return item;
        }

        protected virtual Item LoadKeyOf3Moons2(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.KeyOf3Moons2, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This is two parts of the Key of Three Moons.";
            item.TextName = "Partial Key of the Three Moons";
            item.TextTooltipBasic = "Purchase Partial Key of Three Moons";
            item.TextTooltipExtended = "Cut from the amethyst Stone of Hannalee, it opens the heart of the Gate Keeper.";
            return item;
        }

        protected virtual Item LoadKeyOf3Moons3(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.KeyOf3Moons3, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This is the complete Key of Three Moons.";
            item.TextName = "Key of Three Moons";
            item.TextTooltipBasic = "Purchase Key of Three Moons";
            item.TextTooltipExtended = "Cut from the sapphire Body of Enulaia, it opens the soul of the Gate Keeper.";
            return item;
        }

        protected virtual Item LoadUrnOfKelThuzad(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.UrnOfKelThuzad, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This urn contains the remains of King Terenas.";
            item.TextName = "Urn of King Terenas";
            item.TextTooltipBasic = "Purchase Urn of King Terenas";
            item.TextTooltipExtended = "Formerly the container of King Terenas' ashes, this magically enchanted Urn was chosen by Tichondrius to preserve Kel'Thuzad's remains.";
            return item;
        }

        protected virtual Item LoadBloodyKey(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.BloodyKey, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A bloody key.";
            item.TextName = "Blood Key";
            item.TextTooltipBasic = "Purchase Blood Key";
            item.TextTooltipExtended = "This key is covered in blood.";
            return item;
        }

        protected virtual Item LoadGhostKey(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GhostKey, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A ghostly key.";
            item.TextName = "Ghost Key";
            item.TextTooltipBasic = "Purchase Ghost Key";
            item.TextTooltipExtended = "This key is rather insubstantial.";
            return item;
        }

        protected virtual Item LoadMoonKey(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.MoonKey, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A faintly glowing key.";
            item.TextName = "Moon Key";
            item.TextTooltipBasic = "Purchase Moon Key";
            item.TextTooltipExtended = "This key glows faintly.";
            return item;
        }

        protected virtual Item LoadSunKey(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SunKey, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A glowing key.";
            item.TextName = "Sun Key";
            item.TextTooltipBasic = "Purchase Sun Key";
            item.TextTooltipExtended = "This key glows brightly.";
            return item;
        }

        protected virtual Item LoadGerardSLostLedger(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GerardSLostLedger, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A ledger.";
            item.TextName = "Gerard's Lost Ledger";
            item.TextTooltipBasic = "Purchase Gerard's Lost Ledger";
            item.TextTooltipExtended = "This Ledger looks to be full of boring facts and figures.";
            return item;
        }

        protected virtual Item LoadPhatLewt(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PhatLewt, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 999;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "The phattest lewt, definitely.";
            item.TextName = "Phat Lewt";
            item.TextTooltipBasic = "Purchase Phat Lewt";
            item.TextTooltipExtended = "There is no phatter lewt than this.";
            return item;
        }

        protected virtual Item LoadSearinoxSHeart(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SearinoxSHeart, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "The heart of the Dragon Searinox.";
            item.TextName = "The Heart of Searinox";
            item.TextTooltipBasic = "Purchase the Heart of Searinox";
            item.TextTooltipExtended = "The still beating heart of Searinox can be used to imbue an Orb with the fiery powers of a Dragon.";
            return item;
        }

        protected virtual Item LoadEnchantedGemstone(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.EnchantedGemstone, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This is an enchanted gemstone.";
            item.TextName = "Enchanted Gemstone";
            item.TextTooltipBasic = "Purchase Enchanted Gemstone";
            item.TextTooltipExtended = "This artifact of the Kelani Magi is said to hold the power to make constructs out of pure energy. When the Kelani fell to ruin, the Razormane Quillboars were quick to scavenge and covet these beautiful and powerful objects.";
            return item;
        }

        protected virtual Item LoadShadowOrbFragment(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrbFragment, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A fragment of the Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb Fragment";
            item.TextTooltipBasic = "Purchase Shadow Orb Fragment";
            item.TextTooltipExtended = "A fragment of a powerful artifact.";
            return item;
        }

        protected virtual Item LoadGemFragment(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GemFragment, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A Gem Fragment from a powerful ring.";
            item.TextHotkeyRaw = "G";
            item.TextName = "Gem Fragment";
            item.TextTooltipBasic = "Purchase Gem Fragment";
            item.TextTooltipExtended = "A fragment of a gem from a powerful ring.";
            return item;
        }

        protected virtual Item LoadNoteToJainaProudmoore(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.NoteToJainaProudmoore, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A note to Jaina Proudmoore.";
            item.TextHotkeyRaw = "J";
            item.TextName = "Note to Jaina Proudmoore";
            item.TextTooltipBasic = "Purchase Note to Jaina Proudmoore";
            item.TextTooltipExtended = "A note from Thrall, for Jaina Proudmoore.";
            return item;
        }

        protected virtual Item LoadShimmerweed(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.Shimmerweed, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A shimmering plant.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Shimmerweed";
            item.TextTooltipBasic = "Purchase Shimmerweed";
            item.TextTooltipExtended = "Wondrous plant said to have miraculous mind-expanding properties.";
            return item;
        }

        protected virtual Item LoadSkeletalArtifact(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SkeletalArtifact, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Soulfeast the Devourer.";
            item.TextName = "Skeletal Artifact";
            item.TextTooltipBasic = "Purchase Skeletal Artifact";
            item.TextTooltipExtended = "This ancient artifact entraps the souls of those who die violently, forcing them to relive the last moments of their lives for eternity.";
            return item;
        }

        protected virtual Item LoadThunderLizardEgg(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ThunderLizardEgg, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Massive Lizard Egg.";
            item.TextName = "Thunder Lizard Egg";
            item.TextTooltipBasic = "Purchase Thunder Lizard Egg";
            item.TextTooltipExtended = "This massive egg will not hatch without a parent to warm it.";
            return item;
        }

        protected virtual Item LoadSecretLevelPowerup(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SecretLevelPowerup, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 75;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Unlocks a secret level!";
            item.TextName = "Secret Level Powerup";
            item.TextTooltipBasic = "Purchase Secret Level Powerup";
            item.TextTooltipExtended = "Unlocks a secret level!";
            return item;
        }

        protected virtual Item LoadWirtSLeg(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WirtSLeg, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "The One Leg.";
            item.TextHotkeyRaw = "L";
            item.TextName = "Wirt's Leg";
            item.TextTooltipBasic = "Purchase Wirt's Leg";
            item.TextTooltipExtended = "Could it be that a portal opened up and expelled the remains of our dearest pal from the world of Diablo to here? If so, was it a player, or a Demon? Just how many worlds have the Burning Legion conquered? Could the Demons of the Burning Legion and those of Sanctuary be one and the same? The mind wobbles.";
            return item;
        }

        protected virtual Item LoadWirtSOtherLeg(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WirtSOtherLeg, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "The One Other Leg.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Wirt's Other Leg";
            item.TextTooltipBasic = "Purchase Wirt's Other Leg";
            item.TextTooltipExtended = "Perhaps the overzealous adventurer pried this off before his journey here thinking it might give him one last opportunity at bovine slaughter. Little did he know where it would lead him.";
            return item;
        }

        protected virtual Item LoadMagtheridonSKeys(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.MagtheridonSKeys, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A key chain.";
            item.TextHotkeyRaw = "K";
            item.TextName = "Magic Key Chain";
            item.TextTooltipBasic = "Purchase Magic Key Chain";
            item.TextTooltipExtended = "This magical chain of keys can open many doors.";
            return item;
        }

        protected virtual Item LoadMogrinSReport(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.MogrinSReport, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A letter for Thrall.";
            item.TextHotkeyRaw = "M";
            item.TextName = "Mogrin's Report";
            item.TextTooltipBasic = "Purchase Mogrin's Report";
            item.TextTooltipExtended = "The letter is magically sealed. On the front, written in large scrawling letters is the word Thrall.";
            return item;
        }

        protected virtual Item LoadThunderHawkEgg(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ThunderHawkEgg, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A rare egg of a Thunder Phoenix.";
            item.TextHotkeyRaw = "H";
            item.TextName = "Thunder Phoenix Egg";
            item.TextTooltipBasic = "Purchase Thunder Phoenix Egg";
            item.TextTooltipExtended = "A rare egg of a Thunder Phoenix.";
            return item;
        }

        protected virtual Item LoadKegOfThunderwater(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.KegOfThunderwater, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A keg filled to the brim with the strongest drink available this side of Khaz Modan!";
            item.TextHotkeyRaw = "K";
            item.TextName = "Keg of Thunderwater";
            item.TextTooltipBasic = "Purchase Keg of Thunderwater";
            item.TextTooltipExtended = "A keg filled to the brim with the strongest drink available this side of Khaz Modan!";
            return item;
        }

        protected virtual Item LoadThunderbloomBulb(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ThunderbloomBulb, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "An exotic plant well known for its unstable and dangerous properties.";
            item.TextHotkeyRaw = "T";
            item.TextName = "Thunderbloom Bulb";
            item.TextTooltipBasic = "Purchase Thunderbloom Bulb";
            item.TextTooltipExtended = "An exotic plant well known for its unstable and dangerous properties.";
            return item;
        }

        protected virtual Item LoadFlareGun(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.FlareGun, db);
            item.AbilitiesAbilitiesRaw = "AIfa";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIfa";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 125;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 45;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 3;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Reveals an area on the map.";
            item.TextHotkeyRaw = "F";
            item.TextName = "Flare Gun";
            item.TextTooltipBasic = "Purchase Flare Gun";
            item.TextTooltipExtended = "Reveals a target area on the map. |nContains <fgun,uses> charges.";
            return item;
        }

        protected virtual Item LoadMonsterLure(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.MonsterLure, db);
            item.AbilitiesAbilitiesRaw = "AImo";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AImo";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 3;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Draws nearby creeps to ward.";
            item.TextHotkeyRaw = "L";
            item.TextName = "Monster Lure";
            item.TextTooltipBasic = "Purchase Monster Lure";
            item.TextTooltipExtended = "Creates a ward that draws nearby creeps to it.";
            return item;
        }

        protected virtual Item LoadOrbOfLightningOld(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrbOfLightningOld, db);
            item.AbilitiesAbilitiesRaw = "AIlb,AIlp";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIlb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 10;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 92;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Attacks cause lightning damage.";
            item.TextHotkeyRaw = "L";
            item.TextName = "Orb of Lightning";
            item.TextTooltipBasic = "Purchase Orb of Lightning";
            item.TextTooltipExtended = "Adds <AIlb,DataA1> bonus damage to the attack of a Hero when carried. The Hero's attacks also become ranged when attacking air, and have a chance to dispel magic and slows its movement speed by a factor of <AIlp,DataA1>; they will slowly regain their movement speed over <AIlp,Dur1> seconds. |n|cffffcc00Deals <AIlp,DataC1> bonus damage to summoned units.";
            return item;
        }

        protected virtual Item LoadAmuletOfRecall(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.AmuletOfRecall, db);
            item.AbilitiesAbilitiesRaw = "AIrt";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIrt";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Can be used to teleport units to the user.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Amulet of Recall";
            item.TextTooltipBasic = "Purchase Amulet of Recall";
            item.TextTooltipExtended = "Teleports <AIrt,DataA1> of the player's units within the targeted area to the location of the Hero when used.";
            return item;
        }

        protected virtual Item LoadHumanFlag(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HumanFlag, db);
            item.AbilitiesAbilitiesRaw = "AIfm";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 1;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Can be captured in special scenarios.";
            item.TextName = "Human Flag";
            item.TextTooltipBasic = "Purchase Human Flag";
            item.TextTooltipExtended = "An object that is often captured in special scenarios as a win condition.";
            return item;
        }

        protected virtual Item LoadGoblinLandMine(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GoblinLandMine, db);
            item.AbilitiesAbilitiesRaw = "AIpm";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIpm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 225;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 3;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Explosive mines.";
            item.TextHotkeyRaw = "L";
            item.TextName = "Goblin Land Mines";
            item.TextTooltipBasic = "Purchase Goblin Land Mines";
            item.TextTooltipExtended = "Places a hidden land mine at a target point. Enemy units that move near the land mine will activate the mine, destroying the mine and causing area of effect damage to nearby units. |nContains <gobm,uses> charges.";
            return item;
        }

        protected virtual Item LoadSoulGem(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SoulGem, db);
            item.AbilitiesAbilitiesRaw = "AIso";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIso";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 137;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Allows the theft of a Hero's soul.";
            item.TextHotkeyRaw = "G";
            item.TextName = "Soul Gem";
            item.TextTooltipBasic = "Purchase Soul Gem";
            item.TextTooltipExtended = "Traps the targeted enemy Hero inside the Soul Gem when used. The enemy Hero is returned to play when the bearer of the Soul Gem is killed. While an enemy Hero is trapped, the bearer of the Soul Gem is revealed to the enemy through the Fog of War.";
            return item;
        }

        protected virtual Item LoadNightElfFlag(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.NightElfFlag, db);
            item.AbilitiesAbilitiesRaw = "AIfn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 1;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Can be captured in special scenarios.";
            item.TextName = "Night Elf Flag";
            item.TextTooltipBasic = "Purchase Night Elf Flag";
            item.TextTooltipExtended = "An object that is often captured in special scenarios as a win condition.";
            return item;
        }

        protected virtual Item LoadNecklaceOfSpellImmunity(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.NecklaceOfSpellImmunity, db);
            item.AbilitiesAbilitiesRaw = "AImx";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AImx";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 131;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Grants immunity to magic.";
            item.TextName = "Necklace of Spell Immunity";
            item.TextTooltipBasic = "Purchase Necklace of Spell Immunity";
            item.TextTooltipExtended = "Renders the Hero invulnerable to magic.";
            return item;
        }

        protected virtual Item LoadOrcFlag(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrcFlag, db);
            item.AbilitiesAbilitiesRaw = "AIfo";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 1;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Can be captured in special scenarios.";
            item.TextName = "Orc Flag";
            item.TextTooltipBasic = "Purchase Orc Flag";
            item.TextTooltipExtended = "An object that is often captured in special scenarios as a win condition.";
            return item;
        }

        protected virtual Item LoadAntiMagicPotion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.AntiMagicPotion, db);
            item.AbilitiesAbilitiesRaw = "AIxs";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Aami";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 56;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Renders Hero immune to magic.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Anti-magic Potion";
            item.TextTooltipBasic = "Purchase Anti-magic Potion";
            item.TextTooltipExtended = "Gives the Hero immunity to magical spells for <AIxs,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadPotionOfGreaterInvisibility(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfGreaterInvisibility, db);
            item.AbilitiesAbilitiesRaw = "AIv2";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIvi";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 36;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Renders Hero temporarily invisible.";
            item.TextHotkeyRaw = "I";
            item.TextName = "Potion of Greater Invisibility";
            item.TextTooltipBasic = "Purchase Potion of Greater Invisibility";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRenders the Hero invisible for <AIv2,Dur1> seconds when used. An invisible Hero is untargetable by the enemy unless detected. If the Hero attacks, uses an ability, or casts a spell, the invisibility effect is lost.";
            return item;
        }

        protected virtual Item LoadClawsOfAttack3(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ClawsOfAttack3, db);
            item.AbilitiesAbilitiesRaw = "AIat";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 18;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts attack damage by 3.";
            item.TextHotkeyRaw = "K";
            item.TextName = "Claws of Attack +3";
            item.TextTooltipBasic = "Purchase Claws of Attack +3";
            item.TextTooltipExtended = "Increases the attack damage of the Hero by 3 when worn.";
            return item;
        }

        protected virtual Item LoadRingOfProtection1(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RingOfProtection1, db);
            item.AbilitiesAbilitiesRaw = "AId1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIde";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 45;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts armor by 1.";
            item.TextHotkeyRaw = "1";
            item.TextName = "Ring of Protection +1";
            item.TextTooltipBasic = "Purchase Ring of Protection +1";
            item.TextTooltipExtended = "Increases the armor of the Hero by 1 when worn.";
            return item;
        }

        protected virtual Item LoadRingOfProtection2(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RingOfProtection2, db);
            item.AbilitiesAbilitiesRaw = "AId2";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIde";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 125;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 2;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 80;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts armor by 2.";
            item.TextHotkeyRaw = "2";
            item.TextName = "Ring of Protection +2";
            item.TextTooltipBasic = "Purchase Ring of Protection +2";
            item.TextTooltipExtended = "Increases the armor of the Hero by 2 when worn.";
            return item;
        }

        protected virtual Item LoadRingOfSuperiority(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RingOfSuperiority, db);
            item.AbilitiesAbilitiesRaw = "AIx1";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIx1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 1;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 1;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 1;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 35;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Provides a +1 bonus to Strength, Agility and Intelligence.";
            item.TextName = "Ring of Superiority";
            item.TextTooltipBasic = "Purchase Ring of Superiority";
            item.TextTooltipExtended = "Increases the Strength, Agility and Intelligence of the Hero by 1 when worn.";
            return item;
        }

        protected virtual Item LoadSoul(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.Soul, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 0;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "This is a trapped soul.";
            item.TextName = "Soul";
            item.TextTooltipBasic = "Purchase Soul";
            item.TextTooltipExtended = "A soul, trapped by the enchantments of a Soul Gem.";
            return item;
        }

        protected virtual Item LoadGoblinNightScope(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GoblinNightScope, db);
            item.AbilitiesAbilitiesRaw = "AIuv";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Ault";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 5;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases sight range at night.";
            item.TextHotkeyRaw = "T";
            item.TextName = "Goblin Night Scope";
            item.TextTooltipBasic = "Purchase Goblin Night Scope";
            item.TextTooltipExtended = "Provides an increase to the Hero's line of sight radius at night when carried.";
            return item;
        }

        protected virtual Item LoadTomeOfGreaterExperience(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfGreaterExperience, db);
            item.AbilitiesAbilitiesRaw = "AIe2";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIe2";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gives bonus experience points.";
            item.TextName = "Tome of Greater Experience";
            item.TextTooltipBasic = "Purchase Tome of Greater Experience";
            item.TextTooltipExtended = "Gives the Hero <AIe2,DataA1> bonus experience points when used.";
            return item;
        }

        protected virtual Item LoadUndeadFlag(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.UndeadFlag, db);
            item.AbilitiesAbilitiesRaw = "AIfe";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 1;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Can be captured in special scenarios.";
            item.TextName = "Undead Flag";
            item.TextTooltipBasic = "Purchase Undead Flag";
            item.TextTooltipExtended = "An object that is often captured in special scenarios as a win condition.";
            return item;
        }

        protected virtual Item LoadAncientFigurine(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.AncientFigurine, db);
            item.AbilitiesAbilitiesRaw = "AIi1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIi1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 11;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Intelligence by 1.";
            item.TextName = "Ancient Figurine";
            item.TextTooltipBasic = "Purchase Ancient Figurine";
            item.TextTooltipExtended = "Increases the Intelligence of the Hero by 1 when carried.";
            return item;
        }

        protected virtual Item LoadBracerOfAgility(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.BracerOfAgility, db);
            item.AbilitiesAbilitiesRaw = "AIa1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIa1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 20;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Agility by 1.";
            item.TextName = "Bracer of Agility";
            item.TextTooltipBasic = "Purchase Bracer of Agility";
            item.TextTooltipExtended = "Increases the Agility of the Hero by 1 when worn.";
            return item;
        }

        protected virtual Item LoadDruidPouch(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.DruidPouch, db);
            item.AbilitiesAbilitiesRaw = "AIi1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIi1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 10;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Intelligence by 1.";
            item.TextName = "Druid Pouch";
            item.TextTooltipBasic = "Purchase Druid Pouch";
            item.TextTooltipExtended = "Increases the Intelligence of the Hero by 1 when carried.";
            return item;
        }

        protected virtual Item LoadIronwoodBranch(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.IronwoodBranch, db);
            item.AbilitiesAbilitiesRaw = "AIs1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIs1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 27;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Strength by 1.";
            item.TextName = "Ironwood Branch";
            item.TextTooltipBasic = "Purchase Ironwood Branch";
            item.TextTooltipExtended = "Increases the Strength of the Hero by 1 when carried.";
            return item;
        }

        protected virtual Item LoadJadeRing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.JadeRing, db);
            item.AbilitiesAbilitiesRaw = "AIa1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIa1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 21;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Agility by 1.";
            item.TextName = "Jade Ring";
            item.TextTooltipBasic = "Purchase Jade Ring";
            item.TextTooltipExtended = "Increases the Agility of the Hero by 1 when worn.";
            return item;
        }

        protected virtual Item LoadLionSRing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.LionSRing, db);
            item.AbilitiesAbilitiesRaw = "AIa1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIa1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 22;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Agility by 1.";
            item.TextName = "Lion's Ring";
            item.TextTooltipBasic = "Purchase Lion's Ring";
            item.TextTooltipExtended = "Increases the Agility of the Hero by 1 when worn.";
            return item;
        }

        protected virtual Item LoadMaulOfStrength(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.MaulOfStrength, db);
            item.AbilitiesAbilitiesRaw = "AIs1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIs1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 29;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Strength by 1.";
            item.TextName = "Maul of Strength";
            item.TextTooltipBasic = "Purchase Maul of Strength";
            item.TextTooltipExtended = "Increases the Strength of the Hero by 1 when carried.";
            return item;
        }

        protected virtual Item LoadOrbOfSlow(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrbOfSlow, db);
            item.AbilitiesAbilitiesRaw = "AIsb";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIsb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 98;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Attacks can slow enemies.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Orb of Slow";
            item.TextTooltipBasic = "Purchase Orb of Slow";
            item.TextTooltipExtended = "Adds <AIsb,DataA1> bonus damage to the attack of a Hero when carried. The Hero's attacks also become ranged when attacking air, and have a chance to slow a target enemy unit's movement speed by <AIos,DataA1,%>% and attack rate by <AIos,DataB1,%>% for <AIos,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadSpellBook(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SpellBook, db);
            item.AbilitiesAbilitiesRaw = "Aspb";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Aspb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 325;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A book full of random spells.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Spell Book";
            item.TextTooltipBasic = "Purchase Spell Book";
            item.TextTooltipExtended = "A book full of random spells.";
            return item;
        }

        protected virtual Item LoadSkullShield(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SkullShield, db);
            item.AbilitiesAbilitiesRaw = "AIs1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIs1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 26;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Strength by 1.";
            item.TextName = "Skull Shield";
            item.TextTooltipBasic = "Purchase Skull Shield";
            item.TextTooltipExtended = "Increases the Strength of the Hero by 1 when carried.";
            return item;
        }

        protected virtual Item LoadSpiderRing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SpiderRing, db);
            item.AbilitiesAbilitiesRaw = "AIa1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIa1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 19;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Agility by 1.";
            item.TextName = "Spider Ring";
            item.TextTooltipBasic = "Purchase Spider Ring";
            item.TextTooltipExtended = "Increases the Agility of the Hero by 1 when worn.";
            return item;
        }

        protected virtual Item LoadTotemOfMight(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TotemOfMight, db);
            item.AbilitiesAbilitiesRaw = "AIs1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIs1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 28;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Strength by 1.";
            item.TextName = "Totem of Might";
            item.TextTooltipBasic = "Purchase Totem of Might";
            item.TextTooltipExtended = "Increases the Strength of the Hero by 1 when carried.";
            return item;
        }

        protected virtual Item LoadVoodooDoll(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.VoodooDoll, db);
            item.AbilitiesAbilitiesRaw = "AIi1";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIi1";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 16;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Boosts Intelligence by 1.";
            item.TextName = "Voodoo Doll";
            item.TextTooltipBasic = "Purchase Voodoo Doll";
            item.TextTooltipExtended = "Increases the Intelligence of the Hero by 1 when carried.";
            return item;
        }

        protected virtual Item LoadStaffOfPreservation(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.StaffOfPreservation, db);
            item.AbilitiesAbilitiesRaw = "ANpr";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "ANpr";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 4;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Teleports a target unit home.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Staff of Preservation";
            item.TextTooltipBasic = "Purchase Staff of Preservation";
            item.TextTooltipExtended = "Teleports a target friendly unit to its highest level town hall.";
            return item;
        }

        protected virtual Item LoadHornOfTheClouds(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HornOfTheClouds, db);
            item.AbilitiesAbilitiesRaw = "AIfg";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Aclf";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 13;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Stops enemy towers from attacking.";
            item.TextHotkeyRaw = "C";
            item.TextName = "Horn of the Clouds";
            item.TextTooltipBasic = "Purchase Horn of the Clouds";
            item.TextTooltipExtended = "Allows the Hero to channel the Cloud ability, which stops an area of enemy towers from attacking for <AIfg,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadShadowOrb1(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrb1, db);
            item.AbilitiesAbilitiesRaw = "AItg,AIdn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 9;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gul'dan's Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb +1";
            item.TextTooltipBasic = "Purchase Shadow Orb";
            item.TextTooltipExtended = "This artifact was imbued with special powers by the Orc Shadow Council. It increases your attack damage by 1.";
            return item;
        }

        protected virtual Item LoadShadowOrb2(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrb2, db);
            item.AbilitiesAbilitiesRaw = "AIth,AIdn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 15;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gul'dan's Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb +2";
            item.TextTooltipBasic = "Purchase Shadow Orb";
            item.TextTooltipExtended = "This artifact was imbued with special powers by the Orc Shadow Council. It increases your attack damage by 2.";
            return item;
        }

        protected virtual Item LoadShadowOrb3(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrb3, db);
            item.AbilitiesAbilitiesRaw = "AIat,AIdn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 17;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gul'dan's Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb +3";
            item.TextTooltipBasic = "Purchase Shadow Orb";
            item.TextTooltipExtended = "This artifact was imbued with special powers by the Orc Shadow Council. It increases your attack damage by 3.";
            return item;
        }

        protected virtual Item LoadShadowOrb4(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrb4, db);
            item.AbilitiesAbilitiesRaw = "AIti,AId1,AIdn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 51;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gul'dan's Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb +4";
            item.TextTooltipBasic = "Purchase Shadow Orb";
            item.TextTooltipExtended = "This artifact was imbued with special powers by the Orc Shadow Council. It increases your attack damage by 4 and armor by 1.";
            return item;
        }

        protected virtual Item LoadShadowOrb5(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrb5, db);
            item.AbilitiesAbilitiesRaw = "AItj,AId1,AIdn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 350;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 54;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gul'dan's Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb +5";
            item.TextTooltipBasic = "Purchase Shadow Orb";
            item.TextTooltipExtended = "This artifact was imbued with special powers by the Orc Shadow Council. It increases your attack damage by 5 and armor by 1.";
            return item;
        }

        protected virtual Item LoadShadowOrb6(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrb6, db);
            item.AbilitiesAbilitiesRaw = "AIt6,AId1,AIdn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 59;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gul'dan's Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb +6";
            item.TextTooltipBasic = "Purchase Shadow Orb";
            item.TextTooltipExtended = "This artifact was imbued with special powers by the Orc Shadow Council. It increases your attack damage by 6 and armor by 1.";
            return item;
        }

        protected virtual Item LoadShadowOrb7(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrb7, db);
            item.AbilitiesAbilitiesRaw = "AItk,AId2,AIdn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 88;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gul'dan's Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb +7";
            item.TextTooltipBasic = "Purchase Shadow Orb";
            item.TextTooltipExtended = "This artifact was imbued with special powers by the Orc Shadow Council. It increases your attack damage by 7 and armor by 2.";
            return item;
        }

        protected virtual Item LoadShadowOrb8(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrb8, db);
            item.AbilitiesAbilitiesRaw = "AItl,AId2,AIdn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 700;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 100;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gul'dan's Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb +8";
            item.TextTooltipBasic = "Purchase Shadow Orb";
            item.TextTooltipExtended = "This artifact was imbued with special powers by the Orc Shadow Council. It increases your attack damage by 8 and armor by 2.";
            return item;
        }

        protected virtual Item LoadShadowOrb9(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrb9, db);
            item.AbilitiesAbilitiesRaw = "AIt9,AId2,Arel,AIdn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 900;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 101;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gul'dan's Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb +9";
            item.TextTooltipBasic = "Purchase Shadow Orb";
            item.TextTooltipExtended = "This artifact was imbued with special powers by the Orc Shadow Council. It increases your attack damage by 9, armor by 2 and grants enhanced hit point regeneration.";
            return item;
        }

        protected virtual Item LoadShadowOrb10(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShadowOrb10, db);
            item.AbilitiesAbilitiesRaw = "AItn,AId3,Arel,AIdn";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 115;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gul'dan's Shadow Orb.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Shadow Orb +10";
            item.TextTooltipBasic = "Purchase Shadow Orb";
            item.TextTooltipExtended = "This artifact was imbued with special powers by the Orc Shadow Council. It increases your attack damage by 10, armor by 3 and grants enhanced hit point regeneration.";
            return item;
        }

        protected virtual Item LoadFrostwyrmSkullShield(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.FrostwyrmSkullShield, db);
            item.AbilitiesAbilitiesRaw = "AId2,AIsr";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIsr";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 750;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 127;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A powerful Undead artifact.";
            item.TextHotkeyRaw = "F";
            item.TextName = "Frost Wyrm Skull Shield";
            item.TextTooltipBasic = "Purchase Frost Wyrm Skull Shield";
            item.TextTooltipExtended = "This ancient Frost Wyrm skull has been equipped with handles, turning it into a powerful shield. Increases armor by 2 when worn and reduces Magic damage dealt to the Hero by <AIsr,DataB1,%>%.";
            return item;
        }

        protected virtual Item LoadShamanicTotem(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShamanicTotem, db);
            item.AbilitiesAbilitiesRaw = "AIps";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Aprg";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 600;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 37;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A powerful Orcish artifact.";
            item.TextHotkeyRaw = "H";
            item.TextName = "Shamanic Totem";
            item.TextTooltipBasic = "Purchase Shamanic Totem";
            item.TextTooltipExtended = "This powerful Orc artifact channels Shamanic powers through its user, allowing them to cast Purge.";
            return item;
        }

        protected virtual Item LoadEssenceOfAszune(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.EssenceOfAszune, db);
            item.AbilitiesAbilitiesRaw = "AIh3";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIhe";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 600;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 89;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A powerful Night Elf artifact.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Essence of Aszune";
            item.TextTooltipBasic = "Purchase Essence of Aszune";
            item.TextTooltipExtended = "Legends speak of an intelligent Orc who found the Heart of Aszune. This is the essence of her heart, precious to the Night Elves. It has the power to heal the Hero that wields it. This item is permanent.";
            return item;
        }

        protected virtual Item LoadOrcishBattleStandard(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrcishBattleStandard, db);
            item.AbilitiesAbilitiesRaw = "AIfx";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 1;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Thrall's Battle Standard.";
            item.TextName = "Battle Standard";
            item.TextTooltipBasic = "Purchase Battle Standard";
            item.TextTooltipExtended = "The Battle Standard of Thrall's Orcs, carry it with pride.";
            return item;
        }

        protected virtual Item LoadTinyBlacksmith(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TinyBlacksmith, db);
            item.AbilitiesAbilitiesRaw = "AIbb";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIbl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 50;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates a Blacksmith.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Tiny Blacksmith";
            item.TextTooltipBasic = "Purchase Tiny Blacksmith";
            item.TextTooltipExtended = "Creates a Blacksmith at a target location.";
            return item;
        }

        protected virtual Item LoadTinyFarm(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TinyFarm, db);
            item.AbilitiesAbilitiesRaw = "AIbf";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIbl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 75;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 20;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates a Farm.";
            item.TextHotkeyRaw = "F";
            item.TextName = "Tiny Farm";
            item.TextTooltipBasic = "Purchase Tiny Farm";
            item.TextTooltipExtended = "Creates a Farm at a target location.";
            return item;
        }

        protected virtual Item LoadTinyLumberMill(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TinyLumberMill, db);
            item.AbilitiesAbilitiesRaw = "AIbr";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIbl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates a Lumber Mill.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Tiny Lumber Mill";
            item.TextTooltipBasic = "Purchase Tiny Lumber Mill";
            item.TextTooltipExtended = "Creates a Lumber Mill at a target location.";
            return item;
        }

        protected virtual Item LoadTinyBarracks(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TinyBarracks, db);
            item.AbilitiesAbilitiesRaw = "AIbs";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIbl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 160;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 50;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates a Barracks.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Tiny Barracks";
            item.TextTooltipBasic = "Purchase Tiny Barracks";
            item.TextTooltipExtended = "Creates a Barracks at a target location.";
            return item;
        }

        protected virtual Item LoadTinyAltarOfKings(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TinyAltarOfKings, db);
            item.AbilitiesAbilitiesRaw = "AIbh";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIbh";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 180;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 50;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates a Altar of Kings.";
            item.TextHotkeyRaw = "K";
            item.TextName = "Tiny Altar of Kings";
            item.TextTooltipBasic = "Purchase Tiny Altar of Kings";
            item.TextTooltipExtended = "Creates a Altar of Kings at a target location.";
            return item;
        }

        protected virtual Item LoadOrbOfKilJaeden(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrbOfKilJaeden, db);
            item.AbilitiesAbilitiesRaw = "AIgd";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIfb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 95;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Attacks also do fire damage.";
            item.TextHotkeyRaw = "K";
            item.TextName = "Orb of Kil'jaeden";
            item.TextTooltipBasic = "Purchase Orb of Kil'jaeden";
            item.TextTooltipExtended = "Adds <AIgd,DataA1> bonus fire damage to the attack of a Hero when carried. The Hero's attacks also become ranged when attacking air and do splash damage to nearby enemy units.";
            return item;
        }

        protected virtual Item LoadStaffOfReanimation(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.StaffOfReanimation, db);
            item.AbilitiesAbilitiesRaw = "AInd";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AUan";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Animates a corpse.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Staff of Reanimation";
            item.TextTooltipBasic = "Purchase Staff of Reanimation";
            item.TextTooltipExtended = "Animates a nearby corpse to fight your enemies. Lasts <AInd,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadHolyRelic(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HolyRelic, db);
            item.AbilitiesAbilitiesRaw = "AIae";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AOae";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 950;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A sacred shaman artifact.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Sacred Relic";
            item.TextTooltipBasic = "Purchase Sacred Relic";
            item.TextTooltipExtended = "A powerful artifact, sacred to the orc shaman. |nGrants the Hero and friendly nearby units increased attack rate and movement speed. |nDoes not stack with Endurance Aura.";
            return item;
        }

        protected virtual Item LoadHelmOfBattlethirst(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.HelmOfBattlethirst, db);
            item.AbilitiesAbilitiesRaw = "AIxk,AIa4,AIs4";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Absk";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 4200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cff8b00ffUnique|r|nThis helm makes you crave combat.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Helm of Battlethirst";
            item.TextTooltipBasic = "Purchase Helm of Battlethirst";
            item.TextTooltipExtended = "|cff8b00ffUnique|r|nGrants the ability to go Berserk, causing the Hero to attack <AIxk,DataB1,%>% faster but take <AIxk,DataC1,%>% more damage. Also increases strength and agility by 4 when worn.";
            return item;
        }

        protected virtual Item LoadBladebaneArmor(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.BladebaneArmor, db);
            item.AbilitiesAbilitiesRaw = "AId7,AIad";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AHad";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 3500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases armor.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Bladebane Armor";
            item.TextTooltipBasic = "Purchase Bladebane Armor";
            item.TextTooltipExtended = "Grants nearby units <AIad,DataA1> bonus defense. Enhances the Hero's armor by <AId7,DataA1>.";
            return item;
        }

        protected virtual Item LoadRunedGauntlets(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RunedGauntlets, db);
            item.AbilitiesAbilitiesRaw = "AId3,AIs3";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIab";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 725;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases strength and armor.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Runed Gauntlets";
            item.TextTooltipBasic = "Purchase Runed Gauntlets";
            item.TextTooltipExtended = "Increases the strength and armor of the Hero by 3 when worn.";
            return item;
        }

        protected virtual Item LoadFirehandGauntlets(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.FirehandGauntlets, db);
            item.AbilitiesAbilitiesRaw = "AId5,AIs2";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIas";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 3500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Fiery gauntlets that increase armor and attack rate.";
            item.TextHotkeyRaw = "F";
            item.TextName = "Firehand Gauntlets";
            item.TextTooltipBasic = "Purchase Firehand Gauntlets";
            item.TextTooltipExtended = "Increases armor by <AId5,DataA1> and attack rate by <AIs2,DataA1,%>% when worn.";
            return item;
        }

        protected virtual Item LoadGlovesOfSpellMastery(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GlovesOfSpellMastery, db);
            item.AbilitiesAbilitiesRaw = "AIcm,AIi6";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Acmg";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cff8b00ffUnique|r|nThese gloves have a highly magical nature.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Gloves of Spell Mastery";
            item.TextTooltipBasic = "Purchase Gloves of Spell Mastery";
            item.TextTooltipExtended = "|cff8b00ffUnique|r|nGrants the ability to control summoned units. Also increases the intelligence of the Hero by <AIa6,DataA1> when worn.";
            return item;
        }

        protected virtual Item LoadCrownOfTheDeathlord(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.CrownOfTheDeathlord, db);
            item.AbilitiesAbilitiesRaw = "AIfz,AIlf,AImz";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "ANfd";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 6400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cffff8c00Artifact|r|nA simple crown with the emblem of an unfamiliar Paladin order on it.";
            item.TextHotkeyRaw = "D";
            item.TextName = "Crown of the Deathlord";
            item.TextTooltipBasic = "Purchase Crown of the Deathlord";
            item.TextTooltipExtended = "|cffff8c00Artifact|r|nGrants the ability to fire bolts of pain that deal <AIfz,DataC1> damage. Also increases the Hero's hit points by <AIlf,DataA1> and mana by <AImz,DataA1> when worn.|n|cffffcc00History|r|n|cffffdeadThe Deathlords are rumored to have been mighty Paladins once. One of their order turned from the light when he slaughtered his own family, believing they were impure.|r";
            return item;
        }

        protected virtual Item LoadArcaneScroll(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ArcaneScroll, db);
            item.AbilitiesAbilitiesRaw = "AIdb";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIdb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores hit points, mana and increases armor to nearby units.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Arcane Scroll";
            item.TextTooltipBasic = "Purchase Arcane Scroll";
            item.TextTooltipExtended = "A powerful scroll that restores <AIha,DataA1> hit points, <AImr,DataA1> mana, and grants <AIda,DataA1> bonus armor to nearby friendly units.";
            return item;
        }

        protected virtual Item LoadScrollOfTheUnholyLegion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfTheUnholyLegion, db);
            item.AbilitiesAbilitiesRaw = "AIan";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIan";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 950;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Animates nearby corpses.";
            item.TextHotkeyRaw = "I";
            item.TextName = "Scroll of the Unholy Legion";
            item.TextTooltipBasic = "Purchase Scroll of the Unholy Legion";
            item.TextTooltipExtended = "Animates <AIan,DataA1> nearby corpses to fight for you. Lasts <AIan,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadTomeOfSacrifices(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfSacrifices, db);
            item.AbilitiesAbilitiesRaw = "AIdp,AImz";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AUdp";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cff8b00ffUnique|r|nAn evil looking tome with runes of necromancy etched into the binding.";
            item.TextHotkeyRaw = "T";
            item.TextName = "Tome of Sacrifices";
            item.TextTooltipBasic = "Purchase Tome of Sacrifices";
            item.TextTooltipExtended = "|cff8b00ffUnique|r|nGrants the ability to sacrifice a friendly non-Hero unit to restore hit points. Also increases the Hero's mana by <AImz,DataA1> while equipped.";
            return item;
        }

        protected virtual Item LoadDrekTharSSpellbook(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.DrekTharSSpellbook, db);
            item.AbilitiesAbilitiesRaw = "AItp,AImv,AIsr";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AItp";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 3350;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cffff8c00Artifact|r|nA seemingly simple spellbook, handed down from a master Farseer, Drek'thar.";
            item.TextHotkeyRaw = "D";
            item.TextName = "Drek'thar's Spellbook";
            item.TextTooltipBasic = "Purchase Drek'thar's Spellbook";
            item.TextTooltipExtended = "|cffff8c00Artifact|r|nGrants the ability to portal to your home town. Also reduces spell damage by <AIsr,DataB1,%>% and increases the Hero's mana by <AImv,DataA1> while equipped.|n|cffffcc00History|r|n|cffffdeadDrek'Thar's old spellbook is filled with pages stolen from Kirin Tor mages that were slain in battle.|r";
            return item;
        }

        protected virtual Item LoadGrimoireOfSouls(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GrimoireOfSouls, db);
            item.AbilitiesAbilitiesRaw = "AIpx";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AImi";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1350;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 10;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cff87ceebUnique Consumable|r|nPermanently increases hit points.";
            item.TextHotkeyRaw = "G";
            item.TextName = "Grimoire of Souls";
            item.TextTooltipBasic = "Purchase Grimoire of Souls";
            item.TextTooltipExtended = "|cff87ceebUnique Consumable|r|nThis powerful book permanently increases the hit points of the Hero by <AIpx,DataA1> each time it is used. |nContains <grsl,uses> charges.";
            return item;
        }

        protected virtual Item LoadArcaniteShield(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ArcaniteShield, db);
            item.AbilitiesAbilitiesRaw = "AId5,AIdd";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Adef";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 3500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases armor and reduces damage from ranged attacks.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Arcanite Shield";
            item.TextTooltipBasic = "Purchase Arcanite Shield";
            item.TextTooltipExtended = "Reduces damage from ranged attacks to <AIdd,DataA1,%>%. Also increases the Hero's armor by <AId5,DataA1> when worn.";
            return item;
        }

        protected virtual Item LoadShieldOfTheDeathlord(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShieldOfTheDeathlord, db);
            item.AbilitiesAbilitiesRaw = "AIlf,AImz,AId0,AIcf";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIcf";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 9000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cffff8c00Artifact|r|nA magical shield with the emblem of an unfamiliar Paladin order on it.";
            item.TextHotkeyRaw = "D";
            item.TextName = "Shield of the Deathlord";
            item.TextTooltipBasic = "Purchase Shield of the Deathlord";
            item.TextTooltipExtended = "|cffff8c00Artifact|r|nEngulfs the Hero in fire which deals <AIcf,DataA1> damage per second to nearby enemy land units. Also increases the Hero's armor by <AId0,DataA1>, hit points by <AIlf,DataA1>, and mana by <AImz,DataA1> when worn. |n|cffffcc00History|r|n|cffffdeadWhen Arthas took up the sword against his own people in Stratholme, the Deathlords committed the same heinous act in many other cities across Lordaeron.|r";
            return item;
        }

        protected virtual Item LoadShieldOfHonor(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShieldOfHonor, db);
            item.AbilitiesAbilitiesRaw = "AId8,AIcd";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AOac";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 3350;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cff8b00ffUnique|r|nA Kul Tiras navy commander's shield.";
            item.TextHotkeyRaw = "H";
            item.TextName = "Shield of Honor";
            item.TextTooltipBasic = "Purchase Shield of Honor";
            item.TextTooltipExtended = "|cff8b00ffUnique|r|nGrants nearby friendly units a <AIcd,DataA1,%>% bonus to attack damage. Also increases the armor of the Hero by <AId8,DataA1> when worn.";
            return item;
        }

        protected virtual Item LoadEnchantedShield(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.EnchantedShield, db);
            item.AbilitiesAbilitiesRaw = "AId2,AIlz";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIml";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 650;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases armor and hit points.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Enchanted Shield";
            item.TextTooltipBasic = "Purchase Enchanted Shield";
            item.TextTooltipExtended = "Increases the Hero's armor by <AId2,DataA1> and hit points by <AIlz,DataA1> when worn.";
            return item;
        }

        protected virtual Item LoadThunderlizardDiamond(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ThunderlizardDiamond, db);
            item.AbilitiesAbilitiesRaw = "AIcl";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AOcl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1190;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cff8b00ffUnique|r|nA massive diamond that crackles with electricity.";
            item.TextHotkeyRaw = "T";
            item.TextName = "Thunderlizard Diamond";
            item.TextTooltipBasic = "Purchase Thunderlizard Diamond";
            item.TextTooltipExtended = "|cff8b00ffUnique|r|nCasts bolts of lightning that deal damage to multiple targets.";
            return item;
        }

        protected virtual Item LoadStuffedPenguin(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.StuffedPenguin, db);
            item.AbilitiesAbilitiesRaw = "AIpz";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIha";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A small clockwork penguin that squeaks.";
            item.TextHotkeyRaw = "P";
            item.TextName = "Clockwork Penguin";
            item.TextTooltipBasic = "Purchase Clockwork Penguin";
            item.TextTooltipExtended = "This penguin squeak-toy was first created by the goblin tinkerer Salzhigh for the centaur. Regarding it with some awe (having never seen a penguin before) the centaur purchased them as idols and worshipped them at altars.";
            return item;
        }

        protected virtual Item LoadShimmerglazeRoast(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShimmerglazeRoast, db);
            item.AbilitiesAbilitiesRaw = "AIhx";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIhe";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 6;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores lost hit points.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Shimmerglaze Roast";
            item.TextTooltipBasic = "Purchase Shimmerglaze Roast";
            item.TextTooltipExtended = "A tasty roast with a shimmerweed base. Heals <AIhx,DataA1> hit points when eaten. |nContains <shrs,uses> charges.";
            return item;
        }

        protected virtual Item LoadBloodfeatherSHeart(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.BloodfeatherSHeart, db);
            item.AbilitiesAbilitiesRaw = "AIaz";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIab";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 2500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cff8b00ffUnique|r|nThe heart of Bloodfeather.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Bloodfeather's Heart";
            item.TextTooltipBasic = "Purchase Bloodfeather's Heart";
            item.TextTooltipExtended = "|cff8b00ffUnique|r|nIncreases the Hero's agility by <AIaz,DataA1> when worn.";
            return item;
        }

        protected virtual Item LoadCelestialOrbOfSouls(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.CelestialOrbOfSouls, db);
            item.AbilitiesAbilitiesRaw = "AIrx";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AHre";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 10000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cffff8c00Artifact|r|nA bright glowing orb that instills peace.";
            item.TextHotkeyRaw = "C";
            item.TextName = "Celestial Orb of Souls";
            item.TextTooltipBasic = "Purchase Celestial Orb of Souls";
            item.TextTooltipExtended = "|cffff8c00Artifact|r|nBrings <AIrx,DataA1> of your nearby dead units back to life. |n|cffffcc00History|r|n|cffffdeadCrafted by the Titans as gifts to their favored creations, the Celestial Orb of Souls channels the powers of the light to bring back to life those who have recently fallen.|r";
            return item;
        }

        protected virtual Item LoadShamanClaws(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ShamanClaws, db);
            item.AbilitiesAbilitiesRaw = "AIlx";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIll";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 950;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cff8b00ffUnique|r|nIncreases attack damage and dispels magic.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Shaman Claws";
            item.TextTooltipBasic = "Purchase Shaman Claws";
            item.TextTooltipExtended = "|cff8b00ffUnique|r|nThese are given to shaman upon the completion of their training. Increases attack damage by <AIlx,DataA1>. The Hero's attacks also have a chance to dispel magic and slow the movement speed of the enemy for <AIpg,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadSearingBlade(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SearingBlade, db);
            item.AbilitiesAbilitiesRaw = "AIfw,AIcs";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AOcr";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1650;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases attack damage.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Searing Blade";
            item.TextTooltipBasic = "Purchase Searing Blade";
            item.TextTooltipExtended = "Adds <AIfw,DataA1> bonus fire damage to the attack of a Hero when carried. The Hero's attacks also do splash damage to nearby enemy units, and have a <AIcs,DataA1>% chance to deal <AIcs,DataB1> times their total damage.";
            return item;
        }

        protected virtual Item LoadFrostguard(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.Frostguard, db);
            item.AbilitiesAbilitiesRaw = "AIft,AId5";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIob";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1400;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases attack damage.";
            item.TextHotkeyRaw = "F";
            item.TextName = "Frostguard";
            item.TextTooltipBasic = "Purchase Frostguard";
            item.TextTooltipExtended = "Adds <AIft,DataA1> bonus cold damage to the attack of a Hero and <AId5,DataA1> bonus armor when carried. The Hero's attacks also slow the movement speed and attack rate of the enemy.";
            return item;
        }

        protected virtual Item LoadEnchantedVial(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.EnchantedVial, db);
            item.AbilitiesAbilitiesRaw = "AIp3";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIrg";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 450;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 5;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates health and mana.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Enchanted Vial";
            item.TextTooltipBasic = "Purchase Enchanted Vial";
            item.TextTooltipExtended = "Regenerates <AIp3,DataA1> hit points and <AIp3,DataB1> mana of the Hero over <AIp3,Dur1> seconds. |nContains <envl,uses> charges.";
            return item;
        }

        protected virtual Item LoadRustyMiningPick(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RustyMiningPick, db);
            item.AbilitiesAbilitiesRaw = "AItg,AIbx";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AHbh";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 100;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases attack damage and gives a chance to stun.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Rusty Mining Pick";
            item.TextTooltipBasic = "Purchase Rusty Mining Pick";
            item.TextTooltipExtended = "This heavy pick can be swung with force. Increases the Hero's attack damage by <AItg,DataA1> and gives a <AIbx,DataA1>% chance to stun the enemy.";
            return item;
        }

        protected virtual Item LoadSerathil(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.Serathil, db);
            item.AbilitiesAbilitiesRaw = "AIsx,AItf";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIas";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 5500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cffff8c00Artifact|r|nThis massive axe is covered with notches and orcish runes.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Serathil";
            item.TextTooltipBasic = "Purchase Serathil";
            item.TextTooltipExtended = "|cffff8c00Artifact|r|nIncreases the attack rate of the Hero by <AIsx,DataA1,%>% and attack damage by <AItf,DataA1>.|n|cffffcc00History|r|n|cffffdeadThis weapon was crafted on Draenor for Kash'drakor and used in the Blood River war that ended with the annihilation of the Dark Scar clan. Nazgrel is the last living relative of Kash'drakor.|r";
            return item;
        }

        protected virtual Item LoadSturdyWarAxe(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SturdyWarAxe, db);
            item.AbilitiesAbilitiesRaw = "AItj";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIat";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 600;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases attack damage.";
            item.TextHotkeyRaw = "W";
            item.TextName = "Sturdy War Axe";
            item.TextTooltipBasic = "Purchase Sturdy War Axe";
            item.TextTooltipExtended = "Increases the attack damage of the Hero by <AItj,DataA1> when carried.";
            return item;
        }

        protected virtual Item LoadKillmaim(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.Killmaim, db);
            item.AbilitiesAbilitiesRaw = "AItx,AIva";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIva";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 7500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cffff8c00Artifact|r|nA slender crescent axe that smells of blood and salt.";
            item.TextHotkeyRaw = "K";
            item.TextName = "Killmaim";
            item.TextTooltipBasic = "Purchase Killmaim";
            item.TextTooltipExtended = "|cffff8c00Artifact|r|nIncreases the attack damage of the Hero by <AItx,DataA1> when carried. Also causes the Hero's attacks to steal life.|n|cffffcc00History|r|n|cffffdeadWhen Dethorin found his lady, Allurana, in the arms of another, he went to the Barrens and cried out. An axe burst forth from the sands as if in answer. Dethorin slew Allurana and her lover, then hurled the axe with all his might into the deep dark sea.|r";
            return item;
        }

        protected virtual Item LoadRodOfTheSea(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RodOfTheSea, db);
            item.AbilitiesAbilitiesRaw = "AIwm,AIx2";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "ANwm";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 5;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cff87ceebUnique Consumable|r|nSummons murlocs.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Scepter of the Sea";
            item.TextTooltipBasic = "Purchase Scepter of the Sea";
            item.TextTooltipExtended = "|cff87ceebUnique Consumable|r|nSummons <AIwm,DataA1> Murlocs to fight for you. Also increases the Hero's strength, agility, and intelligence by 2. |nContains <rots,uses> charges.";
            return item;
        }

        protected virtual Item LoadAncestralStaff(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.AncestralStaff, db);
            item.AbilitiesAbilitiesRaw = "AIsh,AIae";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AOsf";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 3000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "|cffff8c00Artifact|r|nThis intricate staff has many names carved into it.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Ancestral Staff";
            item.TextTooltipBasic = "Purchase Ancestral Staff";
            item.TextTooltipExtended = "|cffff8c00Artifact|r|nSummons <AIsh,DataB1> Berserkers to fight for you. Also grants the Hero and friendly nearby units increased attack rate and movement speed. |nDoes not stack with Endurance Aura.|n|cffffcc00History|r|n|cffffdeadNames of generations of Witch Doctors are carved into this staff. The wielder can call upon them for wisdom and guidance in times of peril.|r";
            return item;
        }

        protected virtual Item LoadMindstaff(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.Mindstaff, db);
            item.AbilitiesAbilitiesRaw = "AI2m,AIba";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AHab";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 1800;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases mana.";
            item.TextHotkeyRaw = "M";
            item.TextName = "Mindstaff";
            item.TextTooltipBasic = "Purchase Mindstaff";
            item.TextTooltipExtended = "Increases the mana of the Hero by <AI2m,DataA1>. Also grants the Hero and friendly nearby units a bonus to mana regeneration.";
            return item;
        }

        protected virtual Item LoadScepterOfHealing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScepterOfHealing, db);
            item.AbilitiesAbilitiesRaw = "AIhl,AIgx";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AHhb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 4200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A staff that heals others.";
            item.TextHotkeyRaw = "H";
            item.TextName = "Scepter of Healing";
            item.TextTooltipBasic = "Purchase Scepter of Healing";
            item.TextTooltipExtended = "Grants the ability to heal a friendly unit. Also grants the Hero and friendly nearby units <AIgx,DataA1,%>% increased hit point regeneration.";
            return item;
        }

        protected virtual Item LoadAssassinSBlade(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.AssassinSBlade, db);
            item.AbilitiesAbilitiesRaw = "AIsz,AItj";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Aspo";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 2000;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases attack damage.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Assassin's Blade";
            item.TextTooltipBasic = "Purchase Assassin's Blade";
            item.TextTooltipExtended = "Adds <AItj,DataA1> bonus damage to the attack of the Hero when carried. The Hero's attacks also deal <AIsz,DataA1> damage per second, and slow the movement speed and attack rate of the enemy.";
            return item;
        }

        protected virtual Item LoadKegOfAle(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.KegOfAle, db);
            item.AbilitiesAbilitiesRaw = "AIrm,Arel";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "Arel";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 850;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases hit point and mana regeneration.";
            item.TextHotkeyRaw = "K";
            item.TextName = "Keg of Ale";
            item.TextTooltipBasic = "Purchase Keg of Ale";
            item.TextTooltipExtended = "Increases hit point and mana regeneration.";
            return item;
        }

        protected virtual Item LoadWarsongBattleDrums(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.WarsongBattleDrums, db);
            item.AbilitiesAbilitiesRaw = "AIcd";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AOac";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 38;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases combat effectiveness of nearby units.";
            item.TextHotkeyRaw = "W";
            item.TextName = "Warsong Battle Drums";
            item.TextTooltipBasic = "Purchase Warsong Battle Drums";
            item.TextTooltipExtended = "Increases the attack damage of nearby friendly units by <AIcd,DataA1,%>% when worn. |nDoes not stack with Command Aura.";
            return item;
        }

        protected virtual Item LoadChestOfGold(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ChestOfGold, db);
            item.AbilitiesAbilitiesRaw = "AIgo";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIgo";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gives gold to player.";
            item.TextName = "Gold Coins";
            item.TextTooltipBasic = "Purchase Gold Coins";
            item.TextTooltipExtended = "Gives <AIgo,DataA1> gold to the player when used.";
            return item;
        }

        protected virtual Item LoadBundleOfLumber(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.BundleOfLumber, db);
            item.AbilitiesAbilitiesRaw = "AIlu";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIlu";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 3;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gives lumber to player.";
            item.TextName = "Bundle of Lumber";
            item.TextTooltipBasic = "Purchase Bundle of Lumber";
            item.TextTooltipExtended = "Gives <AIlu,DataA1> lumber to the player when used.";
            return item;
        }

        protected virtual Item LoadGlyphOfFortification(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GlyphOfFortification, db);
            item.AbilitiesAbilitiesRaw = "AIgf";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIgl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Improves building armor and hit points.";
            item.TextHotkeyRaw = "F";
            item.TextName = "Glyph of Fortification";
            item.TextTooltipBasic = "Purchase Glyph of Fortification";
            item.TextTooltipExtended = "Increases the armor and hit points of your buildings.";
            return item;
        }

        protected virtual Item LoadGlyphOfUltraVision(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GlyphOfUltraVision, db);
            item.AbilitiesAbilitiesRaw = "AIgu";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIgl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 125;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Improves night vision.";
            item.TextHotkeyRaw = "U";
            item.TextName = "Glyph of Ultravision";
            item.TextTooltipBasic = "Purchase Glyph of Ultravision";
            item.TextTooltipExtended = "Gives all of your units the ability to see as far at night as they do during the day.";
            return item;
        }

        protected virtual Item LoadRuneOfSpiritLink(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfSpiritLink, db);
            item.AbilitiesAbilitiesRaw = "Aspp";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "Aspp";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 150;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Links units together to distribute damage.";
            item.TextName = "Rune of Spirit Link";
            item.TextTooltipBasic = "Purchase Rune of Spirit Link";
            item.TextTooltipExtended = "Links nearby units' spirits together, causing <Aspp,DataA1,%>% of the damage taken by one to be distributed across all spirit linked units.";
            return item;
        }

        protected virtual Item LoadRuneOfLesserResurrection(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfLesserResurrection, db);
            item.AbilitiesAbilitiesRaw = "APrl";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIrs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Resurrects your dead to fight again.";
            item.TextName = "Rune of Lesser Resurrection";
            item.TextTooltipBasic = "Purchase Rune of Lesser Resurrection";
            item.TextTooltipExtended = "Brings <APrl,DataA1> of your nearby dead units back to life.";
            return item;
        }

        protected virtual Item LoadRuneOfGreaterResurrection(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfGreaterResurrection, db);
            item.AbilitiesAbilitiesRaw = "APrr";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIrs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Resurrects your dead to fight again.";
            item.TextName = "Rune of Greater Resurrection";
            item.TextTooltipBasic = "Purchase Rune of Greater Resurrection";
            item.TextTooltipExtended = "Brings <APrr,DataA1> of your nearby dead units back to life.";
            return item;
        }

        protected virtual Item LoadGlyphOfOmniscience(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.GlyphOfOmniscience, db);
            item.AbilitiesAbilitiesRaw = "AIrv";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIrv";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 240;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Reveals the entire map.";
            item.TextHotkeyRaw = "O";
            item.TextName = "Glyph of Omniscience";
            item.TextTooltipBasic = "Purchase Glyph of Omniscience";
            item.TextTooltipExtended = "Reveals the entire map for <AIrv,Dur1> seconds when used.";
            return item;
        }

        protected virtual Item LoadRuneOfShielding(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfShielding, db);
            item.AbilitiesAbilitiesRaw = "ANse";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "ANse";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 180;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gives nearby units a shield that blocks an enemy spell.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Rune of Shielding";
            item.TextTooltipBasic = "Purchase Rune of Shielding";
            item.TextTooltipExtended = "Creates a shield on nearby friendly units that blocks the next negative spell that an enemy casts upon them.";
            return item;
        }

        protected virtual Item LoadRuneOfSpeed(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfSpeed, db);
            item.AbilitiesAbilitiesRaw = "APsa";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIsp";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Increases movement speed of units.";
            item.TextHotkeyRaw = "D";
            item.TextName = "Rune of Speed";
            item.TextTooltipBasic = "Purchase Rune of Speed";
            item.TextTooltipExtended = "Increases the movement speed of all nearby allied units to the maximum movement speed. |nLasts <APsa,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadRuneOfManaLesser(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfManaLesser, db);
            item.AbilitiesAbilitiesRaw = "APmr";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AImr";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores mana to nearby units.";
            item.TextHotkeyRaw = "M";
            item.TextName = "Rune of Mana";
            item.TextTooltipBasic = "Purchase Rune of Mana";
            item.TextTooltipExtended = "Restores <APmr,DataA1> mana to all nearby friendly units.";
            return item;
        }

        protected virtual Item LoadRuneOfManaGreater(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfManaGreater, db);
            item.AbilitiesAbilitiesRaw = "APmg";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AImr";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores mana to nearby units.";
            item.TextHotkeyRaw = "M";
            item.TextName = "Rune of Greater Mana";
            item.TextTooltipBasic = "Purchase Rune of Greater Mana";
            item.TextTooltipExtended = "Restores <APmg,DataA1> mana to all nearby friendly units.";
            return item;
        }

        protected virtual Item LoadRuneOfRestoration(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfRestoration, db);
            item.AbilitiesAbilitiesRaw = "APra";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIra";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores hit points and mana to nearby units.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Rune of Restoration";
            item.TextTooltipBasic = "Purchase Rune of Restoration";
            item.TextTooltipExtended = "Restores <APra,DataA1> hit points and <APra,DataB1> mana of friendly non-mechanical units in an area around your Hero.";
            return item;
        }

        protected virtual Item LoadRuneOfRebirth(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfRebirth, db);
            item.AbilitiesAbilitiesRaw = "AIrb";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIrb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Makes a monster yours.";
            item.TextHotkeyRaw = "B";
            item.TextName = "Rune of Rebirth";
            item.TextTooltipBasic = "Purchase Rune of Rebirth";
            item.TextTooltipExtended = "Places the monster that held this rune under your control.";
            return item;
        }

        protected virtual Item LoadRuneOfLesserHealing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfLesserHealing, db);
            item.AbilitiesAbilitiesRaw = "APh1";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIha";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores hit points to nearby units.";
            item.TextHotkeyRaw = "H";
            item.TextName = "Rune of Lesser Healing";
            item.TextTooltipBasic = "Purchase Rune of Lesser Healing";
            item.TextTooltipExtended = "Heals <APh1,DataA1> hit points to all nearby friendly non-mechanical units.";
            return item;
        }

        protected virtual Item LoadRuneOfHealing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfHealing, db);
            item.AbilitiesAbilitiesRaw = "APh2";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIha";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores hit points to nearby units.";
            item.TextHotkeyRaw = "H";
            item.TextName = "Rune of Healing";
            item.TextTooltipBasic = "Purchase Rune of Healing";
            item.TextTooltipExtended = "Heals <APh2,DataA1> hit points to all nearby friendly non-mechanical units.";
            return item;
        }

        protected virtual Item LoadRuneOfGreaterHealing(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfGreaterHealing, db);
            item.AbilitiesAbilitiesRaw = "APh3";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIha";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Restores hit points to nearby units.";
            item.TextHotkeyRaw = "H";
            item.TextName = "Rune of Greater Healing";
            item.TextTooltipBasic = "Purchase Rune of Greater Healing";
            item.TextTooltipExtended = "Heals <APh3,DataA1> hit points to all nearby friendly non-mechanical units.";
            return item;
        }

        protected virtual Item LoadRuneOfDispelMagic(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfDispelMagic, db);
            item.AbilitiesAbilitiesRaw = "APdi";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "APdi";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 75;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Dispels magic in the surrounding area.";
            item.TextHotkeyRaw = "D";
            item.TextName = "Rune of Dispel Magic";
            item.TextTooltipBasic = "Purchase Rune of Dispel Magic";
            item.TextTooltipExtended = "Dispels all nearby magic effects. |n|cffffcc00Deals <APdi,DataB1> damage to summoned units.|r";
            return item;
        }

        protected virtual Item LoadTomeOfExperience(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TomeOfExperience, db);
            item.AbilitiesAbilitiesRaw = "AIem";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "AIem";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 500;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 2;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 5;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Gives bonus experience points.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Tome of Experience";
            item.TextTooltipBasic = "Purchase Tome of Experience";
            item.TextTooltipExtended = "Gives <AIem,DataA1> experience to the Hero when used.";
            return item;
        }

        protected virtual Item LoadRuneOfTheWatcher(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RuneOfTheWatcher, db);
            item.AbilitiesAbilitiesRaw = "APwt";
            item.StatsClassificationRaw = "PowerUp";
            item.StatsCooldownGroupRaw = "APwt";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 75;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 1;
            item.StatsPriority = 200;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates an invulnerable Sentry Ward here.";
            item.TextHotkeyRaw = "W";
            item.TextName = "Rune of the Watcher";
            item.TextTooltipBasic = "Purchase Rune of the Watcher";
            item.TextTooltipExtended = "Creates an invulnerable Sentry Ward when activated.";
            return item;
        }

        protected virtual Item LoadClarityPotion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ClarityPotion, db);
            item.AbilitiesAbilitiesRaw = "AIpr";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIpr";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 160;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 67;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 45;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates mana over time.";
            item.TextHotkeyRaw = "Y";
            item.TextName = "Clarity Potion";
            item.TextTooltipBasic = "Purchase Clarity Potion";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRegenerates the Hero's mana by <AIpr,DataB1> over <AIpr,Dur1> seconds when used.";
            return item;
        }

        protected virtual Item LoadLesserClarityPotion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.LesserClarityPotion, db);
            item.AbilitiesAbilitiesRaw = "AIpl";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIpr";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 70;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 57;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 30;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates mana over time.";
            item.TextHotkeyRaw = "C";
            item.TextName = "Lesser Clarity Potion";
            item.TextTooltipBasic = "Purchase Lesser Clarity Potion";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRegenerates the Hero's mana by <AIpl,DataB1> over <AIpl,Dur1> seconds when used.";
            return item;
        }

        protected virtual Item LoadSpiderSilk(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SpiderSilk, db);
            item.AbilitiesAbilitiesRaw = "AIwb";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIwb";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 50;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 81;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 60;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 4;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Webs a target air unit.";
            item.TextHotkeyRaw = "S";
            item.TextName = "Spider Silk Broach";
            item.TextTooltipBasic = "Purchase Spider Silk Broach";
            item.TextTooltipExtended = "Binds a target enemy air unit in webbing, forcing the target to the ground. Webbed units can be hit as though they were land units. |nContains <silk,uses> charges.";
            return item;
        }

        protected virtual Item LoadPotionOfVampirism(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfVampirism, db);
            item.AbilitiesAbilitiesRaw = "AIpv";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIpv";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 75;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 39;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 45;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Damage bonus and life-stealing attack.";
            item.TextHotkeyRaw = "V";
            item.TextName = "Vampiric Potion";
            item.TextTooltipBasic = "Purchase Vampiric Potion";
            item.TextTooltipExtended = "Adds <AIpv,DataA1> bonus damage and a life-stealing attack to the Hero. |nLasts <AIpv,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadScrollOfRegeneration(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfRegeneration, db);
            item.AbilitiesAbilitiesRaw = "AIsl";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIsl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 100;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 70;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 2;
            item.StatsStockReplenishInterval = 90;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Regenerates the health of nearby units.";
            item.TextHotkeyRaw = "R";
            item.TextName = "Scroll of Regeneration";
            item.TextTooltipBasic = "Purchase Scroll of Regeneration";
            item.TextTooltipExtended = "|cff87ceebNon-Combat Consumable|r|nRegenerates the hit points of all friendly non-mechanical units in an area around your Hero by <AIsl,DataA1> over <AIsl,Dur1> seconds when used.";
            return item;
        }

        protected virtual Item LoadTinyCastle(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TinyCastle, db);
            item.AbilitiesAbilitiesRaw = "AIbl";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "AIbl";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 800;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 300;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Creates a Castle.";
            item.TextHotkeyRaw = "A";
            item.TextName = "Tiny Castle";
            item.TextTooltipBasic = "Purchase Tiny Castle";
            item.TextTooltipExtended = "Creates a Castle at a target location.";
            return item;
        }

        protected virtual Item LoadStaffOfSanctuary(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.StaffOfSanctuary, db);
            item.AbilitiesAbilitiesRaw = "ANsa";
            item.StatsClassificationRaw = "Purchasable";
            item.StatsCooldownGroupRaw = "ANsa";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 3;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Heals and teleports a unit.";
            item.TextHotkeyRaw = "N";
            item.TextName = "Staff of Sanctuary";
            item.TextTooltipBasic = "Purchase Staff of Sanctuary";
            item.TextTooltipExtended = "Teleports a target unit to your highest level town hall, stunning the unit and regenerating <ANsa,DataE1> hit points per second. Lasts until the unit is fully healed.";
            return item;
        }

        protected virtual Item LoadOrbOfFireV2(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.OrbOfFireV2, db);
            item.AbilitiesAbilitiesRaw = "AIf2";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIf2";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 250;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 95;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Attacks reduce healing.";
            item.TextHotkeyRaw = "F";
            item.TextName = "Orb of Fire";
            item.TextTooltipBasic = "Purchase Orb of Fire";
            item.TextTooltipExtended = "Adds <AIf2,DataA1> bonus damage to the attack of a Hero when carried. The Hero's attacks also become ranged when attacking air, and reduce the effectiveness of healing and regeneration on enemy units by 35% for <AIf2,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadSeedOfExpulsion(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.SeedOfExpulsion, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A magical seed.";
            item.TextName = "Seed of Expulsion";
            item.TextTooltipBasic = "Purchase Seed of Expulsion";
            item.TextTooltipExtended = "This seed hums with energy.";
            return item;
        }

        protected virtual Item LoadVineOfPurification(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.VineOfPurification, db);
            item.AbilitiesAbilitiesRaw = "_";
            item.StatsClassificationRaw = "Campaign";
            item.StatsCooldownGroupRaw = null;
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 200;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 0;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 0;
            item.StatsCanBeSoldToMerchantsRaw = 0;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 0;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
            item.TextDescription = "A magical vine.";
            item.TextName = "Vine of Purification";
            item.TextTooltipBasic = "Purchase Vine of Purification";
            item.TextTooltipExtended = "This vine hums with energy.";
            return item;
        }

        protected virtual Item LoadPotionOfDivinityDivineShield(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.PotionOfDivinityDivineShield, db);
            item.AbilitiesAbilitiesRaw = "AIdv";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AHds";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 0;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Turns Hero invulnerable.";
            item.TextHotkeyRaw = "D";
            item.TextName = "Potion of Divinity";
            item.TextTooltipBasic = "Purchase Potion of Divinity";
            item.TextTooltipExtended = "Grants the hero a Divine Shield, protecting it from all damage and spells for for <AIdv,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadRedDrakeEgg(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.RedDrakeEgg, db);
            item.AbilitiesAbilitiesRaw = "AIfd";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 6;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons a Red Drake.";
            item.TextHotkeyRaw = "E";
            item.TextName = "Red Drake Egg";
            item.TextTooltipBasic = "Purchase Drake Egg";
            item.TextTooltipExtended = "Summons a Red Drake to fight for you. |nLasts <AIfd,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadTalismanOfTheWild(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.TalismanOfTheWild, db);
            item.AbilitiesAbilitiesRaw = "AIff";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIfs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 550;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 7;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 0;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 3;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Summons Furbolgs.";
            item.TextName = "Talisman of the Wild";
            item.TextTooltipBasic = "Purchase Talisman of the Wild";
            item.TextTooltipExtended = "This mystic stone summons a Furbolg to fight for you. |nContains <totw,uses> charges. |nLasts <AIff,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadScrollOfAnimateDead(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfAnimateDead, db);
            item.AbilitiesAbilitiesRaw = "AIan";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIan";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 700;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 8;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Animates the dead to fight for you.";
            item.TextName = "Scroll of Animate Dead";
            item.TextTooltipBasic = "Purchase Scroll of Animate Dead";
            item.TextTooltipExtended = "Raises <AIan,DataA1> nearby dead units to fight for <AIan,Dur1> seconds.";
            return item;
        }

        protected virtual Item LoadScrollOfResurrection(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.ScrollOfResurrection, db);
            item.AbilitiesAbilitiesRaw = "AIrs";
            item.StatsClassificationRaw = "Miscellaneous";
            item.StatsCooldownGroupRaw = "AIrs";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 700;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 0;
            item.StatsLumberCost = 0;
            item.StatsValidTargetForTransformationRaw = 0;
            item.StatsLevelUnclassified = 8;
            item.StatsPerishableRaw = 1;
            item.StatsIncludeAsRandomChoiceRaw = 0;
            item.StatsUseAutomaticallyWhenAcquiredRaw = 0;
            item.StatsPriority = 0;
            item.StatsCanBeSoldByMerchantsRaw = 1;
            item.StatsCanBeSoldToMerchantsRaw = 1;
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
            item.TextDescription = "Resurrects your dead to fight again.";
            item.TextName = "Scroll of Resurrection";
            item.TextTooltipBasic = "Purchase Scroll of Resurrection";
            item.TextTooltipExtended = "Brings <AIrs,DataA1> of your nearby dead units back to life.";
            return item;
        }

        public Item Load(ItemType itemType, ObjectDatabaseBase db)
        {
            return itemType switch
            {
            ItemType.CrownOfKings5 => LoadCrownOfKings5(db), ItemType.MaskOfDeath => LoadMaskOfDeath(db), ItemType.TomeOfPower => LoadTomeOfPower(db), ItemType.ClawsOfAttack15 => LoadClawsOfAttack15(db), ItemType.OrbOfFrost => LoadOrbOfFrost(db), ItemType.InfernoStone => LoadInfernoStone(db), ItemType.DaggerOfEscape => LoadDaggerOfEscape(db), ItemType.DemonicFigurine => LoadDemonicFigurine(db), ItemType.EngravedScale => LoadEngravedScale(db), ItemType.IceShard => LoadIceShard(db), ItemType.ScepterOfMastery => LoadScepterOfMastery(db), ItemType.AmuletOfTheWild => LoadAmuletOfTheWild(db), ItemType.ScepterOfAvarice => LoadScepterOfAvarice(db), ItemType.OrbOfDarkness => LoadOrbOfDarkness(db), ItemType.RingOfProtection5 => LoadRingOfProtection5(db), ItemType.PendantOfMana => LoadPendantOfMana(db), ItemType.KhadgarSGemOfHealth => LoadKhadgarSGemOfHealth(db), ItemType.StaffOfSilence => LoadStaffOfSilence(db), ItemType.AmuletOfSpellShield => LoadAmuletOfSpellShield(db), ItemType.ScrollOfRestoration => LoadScrollOfRestoration(db), ItemType.PotionOfDivinityInvulnerability => LoadPotionOfDivinityInvulnerability(db), ItemType.PotionOfRestoration => LoadPotionOfRestoration(db), ItemType.IdolOfTheWild => LoadIdolOfTheWild(db), ItemType.SpikedCollar => LoadSpikedCollar(db), ItemType.BlueDrakeEgg => LoadBlueDrakeEgg(db), ItemType.StoneToken => LoadStoneToken(db), ItemType.HoodOfCunning => LoadHoodOfCunning(db), ItemType.HelmOfValor => LoadHelmOfValor(db), ItemType.MedallionOfCourage => LoadMedallionOfCourage(db), ItemType.AncientJanggoOfEndurance => LoadAncientJanggoOfEndurance(db), ItemType.CloakOfFlames => LoadCloakOfFlames(db), ItemType.ClawsOfAttack12 => LoadClawsOfAttack12(db), ItemType.WarsongBattleDrumsKodo => LoadWarsongBattleDrumsKodo(db), ItemType.KhadgarSPipeOfInsight => LoadKhadgarSPipeOfInsight(db), ItemType.LegionDoomHorn => LoadLegionDoomHorn(db), ItemType.AnkhOfReincarnation => LoadAnkhOfReincarnation(db), ItemType.HealingWards => LoadHealingWards(db), ItemType.BookOfTheDead => LoadBookOfTheDead(db), ItemType.WandOfTheWind => LoadWandOfTheWind(db), ItemType.HealthStone => LoadHealthStone(db), ItemType.ManaStone => LoadManaStone(db), ItemType.BootsOfQuelThalas6 => LoadBootsOfQuelThalas6(db), ItemType.BeltOfGiantStrength6 => LoadBeltOfGiantStrength6(db), ItemType.RobeOfTheMagi6 => LoadRobeOfTheMagi6(db), ItemType.LionHornOfStormwind => LoadLionHornOfStormwind(db), ItemType.AlleriaSFluteOfAccuracy => LoadAlleriaSFluteOfAccuracy(db), ItemType.ScourgeBoneChimes => LoadScourgeBoneChimes(db), ItemType.RunedBracers => LoadRunedBracers(db), ItemType.SobiMask => LoadSobiMask(db), ItemType.PotionOfGreaterHealing => LoadPotionOfGreaterHealing(db), ItemType.PotionOfGreaterMana => LoadPotionOfGreaterMana(db), ItemType.PotionOfInvulnerability => LoadPotionOfInvulnerability(db), ItemType.ScrollOfTheBeast => LoadScrollOfTheBeast(db), ItemType.WandOfManaStealing => LoadWandOfManaStealing(db), ItemType.CrystalBall => LoadCrystalBall(db), ItemType.TalismanOfEvasion => LoadTalismanOfEvasion(db), ItemType.PendantOfEnergy => LoadPendantOfEnergy(db), ItemType.PeriaptOfVitality => LoadPeriaptOfVitality(db), ItemType.ClawsOfAttack9 => LoadClawsOfAttack9(db), ItemType.RingOfProtection4 => LoadRingOfProtection4(db), ItemType.RingOfRegeneration => LoadRingOfRegeneration(db), ItemType.BootsOfSpeed => LoadBootsOfSpeed(db), ItemType.ReplenishmentPotion => LoadReplenishmentPotion(db), ItemType.WandOfIllusion => LoadWandOfIllusion(db), ItemType.WandOfLightningShield => LoadWandOfLightningShield(db), ItemType.SentryWards => LoadSentryWards(db), ItemType.CircletOfNobility => LoadCircletOfNobility(db), ItemType.GlovesOfHaste => LoadGlovesOfHaste(db), ItemType.ClawsOfAttack6 => LoadClawsOfAttack6(db), ItemType.RingOfProtection3 => LoadRingOfProtection3(db), ItemType.TomeOfAgility2 => LoadTomeOfAgility2(db), ItemType.TomeOfIntelligence2 => LoadTomeOfIntelligence2(db), ItemType.TomeOfKnowledge => LoadTomeOfKnowledge(db), ItemType.TomeOfStrength2 => LoadTomeOfStrength2(db), ItemType.PotionOfLesserInvulnerability => LoadPotionOfLesserInvulnerability(db), ItemType.CloakOfShadows => LoadCloakOfShadows(db), ItemType.SlippersOfAgility3 => LoadSlippersOfAgility3(db), ItemType.MantleOfIntelligence3 => LoadMantleOfIntelligence3(db), ItemType.GauntletsOfOgreStrength3 => LoadGauntletsOfOgreStrength3(db), ItemType.ManualOfHealth => LoadManualOfHealth(db), ItemType.TomeOfAgility1 => LoadTomeOfAgility1(db), ItemType.TomeOfIntelligence => LoadTomeOfIntelligence(db), ItemType.TomeOfStrength1 => LoadTomeOfStrength1(db), ItemType.PotionOfOmniscience => LoadPotionOfOmniscience(db), ItemType.WandOfShadowsight => LoadWandOfShadowsight(db), ItemType.GreaterScrollOfReplenishment => LoadGreaterScrollOfReplenishment(db), ItemType.LesserScrollOfReplenishment => LoadLesserScrollOfReplenishment(db), ItemType.GreaterReplenishmentPotion => LoadGreaterReplenishmentPotion(db), ItemType.FourthRingOfTheArchmagi => LoadFourthRingOfTheArchmagi(db), ItemType.DiamondOfSummoning => LoadDiamondOfSummoning(db), ItemType.OrbOfFire => LoadOrbOfFire(db), ItemType.OrbOfCorruption => LoadOrbOfCorruption(db), ItemType.OrbOfLightning => LoadOrbOfLightning(db), ItemType.OrbOfVenom => LoadOrbOfVenom(db), ItemType.ThirdRingOfTheArchmagi => LoadThirdRingOfTheArchmagi(db), ItemType.TomeOfRetraining => LoadTomeOfRetraining(db), ItemType.TinyGreatHall => LoadTinyGreatHall(db), ItemType.LesserReplenishmentPotion => LoadLesserReplenishmentPotion(db), ItemType.GemOfTrueSeeing => LoadGemOfTrueSeeing(db), ItemType.SecondRingOfTheArchmagi => LoadSecondRingOfTheArchmagi(db), ItemType.StaffOfTeleportation => LoadStaffOfTeleportation(db), ItemType.ScrollOfTownPortal => LoadScrollOfTownPortal(db), ItemType.WandOfNegation => LoadWandOfNegation(db), ItemType.StaffOfNegation => LoadStaffOfNegation(db), ItemType.WandOfNeutralization => LoadWandOfNeutralization(db), ItemType.ScrollOfHealing => LoadScrollOfHealing(db), ItemType.ScrollOfMana => LoadScrollOfMana(db), ItemType.MinorReplenishmentPotion => LoadMinorReplenishmentPotion(db), ItemType.PotionOfSpeed => LoadPotionOfSpeed(db), ItemType.DustOfAppearance => LoadDustOfAppearance(db), ItemType.FirstRingOfTheArchmagi => LoadFirstRingOfTheArchmagi(db), ItemType.PotionOfInvisibility => LoadPotionOfInvisibility(db), ItemType.PotionOfHealing => LoadPotionOfHealing(db), ItemType.PotionOfMana => LoadPotionOfMana(db), ItemType.ScrollOfProtection => LoadScrollOfProtection(db), ItemType.HealingSalve => LoadHealingSalve(db), ItemType.Moonstone => LoadMoonstone(db), ItemType.ScrollOfSpeed => LoadScrollOfSpeed(db), ItemType.SacrificialSkull => LoadSacrificialSkull(db), ItemType.MechanicalCritter => LoadMechanicalCritter(db), ItemType.RodOfNecromancy => LoadRodOfNecromancy(db), ItemType.RitualDagger => LoadRitualDagger(db), ItemType.IvoryTower => LoadIvoryTower(db), ItemType.HeartOfAszune => LoadHeartOfAszune(db), ItemType.EmptyVial => LoadEmptyVial(db), ItemType.FullVial => LoadFullVial(db), ItemType.Cheese => LoadCheese(db), ItemType.HornOfCenarius => LoadHornOfCenarius(db), ItemType.GuldanSSkull => LoadGuldanSSkull(db), ItemType.GlyphOfPurification => LoadGlyphOfPurification(db), ItemType.KeyOf3Moons1 => LoadKeyOf3Moons1(db), ItemType.KeyOf3Moons2 => LoadKeyOf3Moons2(db), ItemType.KeyOf3Moons3 => LoadKeyOf3Moons3(db), ItemType.UrnOfKelThuzad => LoadUrnOfKelThuzad(db), ItemType.BloodyKey => LoadBloodyKey(db), ItemType.GhostKey => LoadGhostKey(db), ItemType.MoonKey => LoadMoonKey(db), ItemType.SunKey => LoadSunKey(db), ItemType.GerardSLostLedger => LoadGerardSLostLedger(db), ItemType.PhatLewt => LoadPhatLewt(db), ItemType.SearinoxSHeart => LoadSearinoxSHeart(db), ItemType.EnchantedGemstone => LoadEnchantedGemstone(db), ItemType.ShadowOrbFragment => LoadShadowOrbFragment(db), ItemType.GemFragment => LoadGemFragment(db), ItemType.NoteToJainaProudmoore => LoadNoteToJainaProudmoore(db), ItemType.Shimmerweed => LoadShimmerweed(db), ItemType.SkeletalArtifact => LoadSkeletalArtifact(db), ItemType.ThunderLizardEgg => LoadThunderLizardEgg(db), ItemType.SecretLevelPowerup => LoadSecretLevelPowerup(db), ItemType.WirtSLeg => LoadWirtSLeg(db), ItemType.WirtSOtherLeg => LoadWirtSOtherLeg(db), ItemType.MagtheridonSKeys => LoadMagtheridonSKeys(db), ItemType.MogrinSReport => LoadMogrinSReport(db), ItemType.ThunderHawkEgg => LoadThunderHawkEgg(db), ItemType.KegOfThunderwater => LoadKegOfThunderwater(db), ItemType.ThunderbloomBulb => LoadThunderbloomBulb(db), ItemType.FlareGun => LoadFlareGun(db), ItemType.MonsterLure => LoadMonsterLure(db), ItemType.OrbOfLightningOld => LoadOrbOfLightningOld(db), ItemType.AmuletOfRecall => LoadAmuletOfRecall(db), ItemType.HumanFlag => LoadHumanFlag(db), ItemType.GoblinLandMine => LoadGoblinLandMine(db), ItemType.SoulGem => LoadSoulGem(db), ItemType.NightElfFlag => LoadNightElfFlag(db), ItemType.NecklaceOfSpellImmunity => LoadNecklaceOfSpellImmunity(db), ItemType.OrcFlag => LoadOrcFlag(db), ItemType.AntiMagicPotion => LoadAntiMagicPotion(db), ItemType.PotionOfGreaterInvisibility => LoadPotionOfGreaterInvisibility(db), ItemType.ClawsOfAttack3 => LoadClawsOfAttack3(db), ItemType.RingOfProtection1 => LoadRingOfProtection1(db), ItemType.RingOfProtection2 => LoadRingOfProtection2(db), ItemType.RingOfSuperiority => LoadRingOfSuperiority(db), ItemType.Soul => LoadSoul(db), ItemType.GoblinNightScope => LoadGoblinNightScope(db), ItemType.TomeOfGreaterExperience => LoadTomeOfGreaterExperience(db), ItemType.UndeadFlag => LoadUndeadFlag(db), ItemType.AncientFigurine => LoadAncientFigurine(db), ItemType.BracerOfAgility => LoadBracerOfAgility(db), ItemType.DruidPouch => LoadDruidPouch(db), ItemType.IronwoodBranch => LoadIronwoodBranch(db), ItemType.JadeRing => LoadJadeRing(db), ItemType.LionSRing => LoadLionSRing(db), ItemType.MaulOfStrength => LoadMaulOfStrength(db), ItemType.OrbOfSlow => LoadOrbOfSlow(db), ItemType.SpellBook => LoadSpellBook(db), ItemType.SkullShield => LoadSkullShield(db), ItemType.SpiderRing => LoadSpiderRing(db), ItemType.TotemOfMight => LoadTotemOfMight(db), ItemType.VoodooDoll => LoadVoodooDoll(db), ItemType.StaffOfPreservation => LoadStaffOfPreservation(db), ItemType.HornOfTheClouds => LoadHornOfTheClouds(db), ItemType.ShadowOrb1 => LoadShadowOrb1(db), ItemType.ShadowOrb2 => LoadShadowOrb2(db), ItemType.ShadowOrb3 => LoadShadowOrb3(db), ItemType.ShadowOrb4 => LoadShadowOrb4(db), ItemType.ShadowOrb5 => LoadShadowOrb5(db), ItemType.ShadowOrb6 => LoadShadowOrb6(db), ItemType.ShadowOrb7 => LoadShadowOrb7(db), ItemType.ShadowOrb8 => LoadShadowOrb8(db), ItemType.ShadowOrb9 => LoadShadowOrb9(db), ItemType.ShadowOrb10 => LoadShadowOrb10(db), ItemType.FrostwyrmSkullShield => LoadFrostwyrmSkullShield(db), ItemType.ShamanicTotem => LoadShamanicTotem(db), ItemType.EssenceOfAszune => LoadEssenceOfAszune(db), ItemType.OrcishBattleStandard => LoadOrcishBattleStandard(db), ItemType.TinyBlacksmith => LoadTinyBlacksmith(db), ItemType.TinyFarm => LoadTinyFarm(db), ItemType.TinyLumberMill => LoadTinyLumberMill(db), ItemType.TinyBarracks => LoadTinyBarracks(db), ItemType.TinyAltarOfKings => LoadTinyAltarOfKings(db), ItemType.OrbOfKilJaeden => LoadOrbOfKilJaeden(db), ItemType.StaffOfReanimation => LoadStaffOfReanimation(db), ItemType.HolyRelic => LoadHolyRelic(db), ItemType.HelmOfBattlethirst => LoadHelmOfBattlethirst(db), ItemType.BladebaneArmor => LoadBladebaneArmor(db), ItemType.RunedGauntlets => LoadRunedGauntlets(db), ItemType.FirehandGauntlets => LoadFirehandGauntlets(db), ItemType.GlovesOfSpellMastery => LoadGlovesOfSpellMastery(db), ItemType.CrownOfTheDeathlord => LoadCrownOfTheDeathlord(db), ItemType.ArcaneScroll => LoadArcaneScroll(db), ItemType.ScrollOfTheUnholyLegion => LoadScrollOfTheUnholyLegion(db), ItemType.TomeOfSacrifices => LoadTomeOfSacrifices(db), ItemType.DrekTharSSpellbook => LoadDrekTharSSpellbook(db), ItemType.GrimoireOfSouls => LoadGrimoireOfSouls(db), ItemType.ArcaniteShield => LoadArcaniteShield(db), ItemType.ShieldOfTheDeathlord => LoadShieldOfTheDeathlord(db), ItemType.ShieldOfHonor => LoadShieldOfHonor(db), ItemType.EnchantedShield => LoadEnchantedShield(db), ItemType.ThunderlizardDiamond => LoadThunderlizardDiamond(db), ItemType.StuffedPenguin => LoadStuffedPenguin(db), ItemType.ShimmerglazeRoast => LoadShimmerglazeRoast(db), ItemType.BloodfeatherSHeart => LoadBloodfeatherSHeart(db), ItemType.CelestialOrbOfSouls => LoadCelestialOrbOfSouls(db), ItemType.ShamanClaws => LoadShamanClaws(db), ItemType.SearingBlade => LoadSearingBlade(db), ItemType.Frostguard => LoadFrostguard(db), ItemType.EnchantedVial => LoadEnchantedVial(db), ItemType.RustyMiningPick => LoadRustyMiningPick(db), ItemType.Serathil => LoadSerathil(db), ItemType.SturdyWarAxe => LoadSturdyWarAxe(db), ItemType.Killmaim => LoadKillmaim(db), ItemType.RodOfTheSea => LoadRodOfTheSea(db), ItemType.AncestralStaff => LoadAncestralStaff(db), ItemType.Mindstaff => LoadMindstaff(db), ItemType.ScepterOfHealing => LoadScepterOfHealing(db), ItemType.AssassinSBlade => LoadAssassinSBlade(db), ItemType.KegOfAle => LoadKegOfAle(db), ItemType.WarsongBattleDrums => LoadWarsongBattleDrums(db), ItemType.ChestOfGold => LoadChestOfGold(db), ItemType.BundleOfLumber => LoadBundleOfLumber(db), ItemType.GlyphOfFortification => LoadGlyphOfFortification(db), ItemType.GlyphOfUltraVision => LoadGlyphOfUltraVision(db), ItemType.RuneOfSpiritLink => LoadRuneOfSpiritLink(db), ItemType.RuneOfLesserResurrection => LoadRuneOfLesserResurrection(db), ItemType.RuneOfGreaterResurrection => LoadRuneOfGreaterResurrection(db), ItemType.GlyphOfOmniscience => LoadGlyphOfOmniscience(db), ItemType.RuneOfShielding => LoadRuneOfShielding(db), ItemType.RuneOfSpeed => LoadRuneOfSpeed(db), ItemType.RuneOfManaLesser => LoadRuneOfManaLesser(db), ItemType.RuneOfManaGreater => LoadRuneOfManaGreater(db), ItemType.RuneOfRestoration => LoadRuneOfRestoration(db), ItemType.RuneOfRebirth => LoadRuneOfRebirth(db), ItemType.RuneOfLesserHealing => LoadRuneOfLesserHealing(db), ItemType.RuneOfHealing => LoadRuneOfHealing(db), ItemType.RuneOfGreaterHealing => LoadRuneOfGreaterHealing(db), ItemType.RuneOfDispelMagic => LoadRuneOfDispelMagic(db), ItemType.TomeOfExperience => LoadTomeOfExperience(db), ItemType.RuneOfTheWatcher => LoadRuneOfTheWatcher(db), ItemType.ClarityPotion => LoadClarityPotion(db), ItemType.LesserClarityPotion => LoadLesserClarityPotion(db), ItemType.SpiderSilk => LoadSpiderSilk(db), ItemType.PotionOfVampirism => LoadPotionOfVampirism(db), ItemType.ScrollOfRegeneration => LoadScrollOfRegeneration(db), ItemType.TinyCastle => LoadTinyCastle(db), ItemType.StaffOfSanctuary => LoadStaffOfSanctuary(db), ItemType.OrbOfFireV2 => LoadOrbOfFireV2(db), ItemType.SeedOfExpulsion => LoadSeedOfExpulsion(db), ItemType.VineOfPurification => LoadVineOfPurification(db), ItemType.PotionOfDivinityDivineShield => LoadPotionOfDivinityDivineShield(db), ItemType.RedDrakeEgg => LoadRedDrakeEgg(db), ItemType.TalismanOfTheWild => LoadTalismanOfTheWild(db), ItemType.ScrollOfAnimateDead => LoadScrollOfAnimateDead(db), ItemType.ScrollOfResurrection => LoadScrollOfResurrection(db), _ => throw new System.ComponentModel.InvalidEnumArgumentException(nameof(itemType), (int)itemType, typeof(ItemType))}

            ;
        }
    }
}