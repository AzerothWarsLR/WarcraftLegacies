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
            return item;
        }

        protected virtual Item LoadCrystalBall(ObjectDatabaseBase db)
        {
            var item = new Item(ItemType.CrystalBall, db);
            item.AbilitiesAbilitiesRaw = "AIta";
            item.StatsClassificationRaw = "Permanent";
            item.StatsCooldownGroupRaw = "AIta";
            item.StatsDroppedWhenCarrierDiesRaw = 0;
            item.StatsCanBeDroppedRaw = 1;
            item.StatsGoldCost = 300;
            item.StatsHitPoints = 75;
            item.StatsIgnoreCooldownRaw = 0;
            item.StatsLevel = 3;
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
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
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
            item.StatsGoldCost = 325;
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
            item.StatsIncludeAsRandomChoiceRaw = 1;
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
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 440;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 1;
            item.StatsMaxStacks = 0;
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
            item.StatsStockMaximum = 1;
            item.StatsStockReplenishInterval = 120;
            item.StatsStockStartDelay = 220;
            item.StatsStockInitialAfterStartDelay = 1;
            item.StatsActivelyUsedRaw = 1;
            item.StatsNumberOfCharges = 0;
            item.StatsMaxStacks = 0;
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