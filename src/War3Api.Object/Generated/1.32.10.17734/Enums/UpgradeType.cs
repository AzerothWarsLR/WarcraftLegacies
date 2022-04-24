using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Enums
{
    public enum UpgradeType
    {
        /// <summary>Human melee attack ('Rhme').</summary>
        HumanMeleeAttack = 1701668946,
        /// <summary>Human ranged attack ('Rhra').</summary>
        HumanRangedAttack = 1634887762,
        /// <summary>Human hammer bounce ('Rhhb').</summary>
        HumanHammerBounce = 1651009618,
        /// <summary>Human armor ('Rhar').</summary>
        HumanArmor = 1918986322,
        /// <summary>Human gyro bombs ('Rhgb').</summary>
        HumanGyroBombs = 1650944082,
        /// <summary>Human architecture ('Rhac').</summary>
        HumanArchitecture = 1667328082,
        /// <summary>Human footman defend ('Rhde').</summary>
        HumanFootmanDefend = 1701079122,
        /// <summary>Human animal breeding ('Rhan').</summary>
        HumanAnimalBreeding = 1851877458,
        /// <summary>Human priest training ('Rhpt').</summary>
        HumanPriestTraining = 1953523794,
        /// <summary>Human sorceress training ('Rhst').</summary>
        HumanSorceressTraining = 1953720402,
        /// <summary>Human leather armor ('Rhla').</summary>
        HumanLeatherArmor = 1634494546,
        /// <summary>Human rifleman plus range ('Rhri').</summary>
        HumanRiflemanPlusRange = 1769105490,
        /// <summary>Human lumber harvesting ('Rhlh').</summary>
        HumanLumberHarvesting = 1751935058,
        /// <summary>Human magical sentinal ('Rhse').</summary>
        HumanMagicalSentinal = 1702062162,
        /// <summary>Human flare ('Rhfl').</summary>
        HumanFlare = 1818650706,
        /// <summary>Human control magic ('Rhss').</summary>
        HumanControlMagic = 1936943186,
        /// <summary>Human rocket tank ('Rhrt').</summary>
        HumanRocketTank = 1953654866,
        /// <summary>Human backpack ('Rhpm').</summary>
        HumanBackpack = 1836083282,
        /// <summary>Human flak cannon ('Rhfc').</summary>
        HumanFlakCannon = 1667655762,
        /// <summary>Human frag shards ('Rhfs').</summary>
        HumanFragShards = 1936091218,
        /// <summary>Human cloud research ('Rhcd').</summary>
        HumanCloudResearch = 1684236370,
        /// <summary>Human sundering blades ('Rhsb').</summary>
        HumanSunderingBlades = 1651730514,
        /// <summary>Orc melee attack ('Rome').</summary>
        OrcMeleeAttack = 1701670738,
        /// <summary>Orc ranged attack ('Rora').</summary>
        OrcRangedAttack = 1634889554,
        /// <summary>Orc armor ('Roar').</summary>
        OrcArmor = 1918988114,
        /// <summary>Orc war drums damage ('Rwdm').</summary>
        OrcWarDrumsDamage = 1835300690,
        /// <summary>Orc pillage ('Ropg').</summary>
        OrcPillage = 1735421778,
        /// <summary>Orc grunt berserk ('Robs').</summary>
        OrcGruntBerserk = 1935830866,
        /// <summary>Orc tauren smash ('Rows').</summary>
        OrcTaurenSmash = 1937207122,
        /// <summary>Orc raider ensare ('Roen').</summary>
        OrcRaiderEnsare = 1852141394,
        /// <summary>Orc wyvern venom spear ('Rovs').</summary>
        OrcWyvernVenomSpear = 1937141586,
        /// <summary>Orc witch doctor training ('Rowd').</summary>
        OrcWitchDoctorTraining = 1685548882,
        /// <summary>Orc shaman training ('Rost').</summary>
        OrcShamanTraining = 1953722194,
        /// <summary>Orc spiked barricade ('Rosp').</summary>
        OrcSpikedBarricade = 1886613330,
        /// <summary>Orc troll regeneration ('Rotr').</summary>
        OrcTrollRegeneration = 1920233298,
        /// <summary>Orc liquid fire ('Rolf').</summary>
        OrcLiquidFire = 1718382418,
        /// <summary>Orc chaos conversion ('Roch').</summary>
        OrcChaosConversion = 1751347026,
        /// <summary>Orc spiritwalker training ('Rowt').</summary>
        OrcSpiritwalkerTraining = 1953984338,
        /// <summary>Orc reinforced defense ('Rorb').</summary>
        OrcReinforcedDefense = 1651666770,
        /// <summary>Orc berserkers ('Robk').</summary>
        OrcBerserkers = 1801613138,
        /// <summary>Orc backpack ('Ropm').</summary>
        OrcBackpack = 1836085074,
        /// <summary>Orc naptha ('Robf').</summary>
        OrcNaptha = 1717727058,
        /// <summary>Undead unholy strength ('Rume').</summary>
        UndeadUnholyStrength = 1701672274,
        /// <summary>Undead creature attack ('Rura').</summary>
        UndeadCreatureAttack = 1634891090,
        /// <summary>Undead unholy armor ('Ruar').</summary>
        UndeadUnholyArmor = 1918989650,
        /// <summary>Undead ghoul cannibalize ('Ruac').</summary>
        UndeadGhoulCannibalize = 1667331410,
        /// <summary>Undead ghoul frenzy ('Rugf').</summary>
        UndeadGhoulFrenzy = 1718056274,
        /// <summary>Undead fiend web ('Ruwb').</summary>
        UndeadFiendWeb = 1651995986,
        /// <summary>Undead gargoyle stone ('Rusf').</summary>
        UndeadGargoyleStone = 1718842706,
        /// <summary>Undead necromancer training ('Rune').</summary>
        UndeadNecromancerTraining = 1701737810,
        /// <summary>Undead banshee training ('Ruba').</summary>
        UndeadBansheeTraining = 1633842514,
        /// <summary>Undead frost wyrm breath ('Rufb').</summary>
        UndeadFrostWyrmBreath = 1650881874,
        /// <summary>Undead skeleton life span ('Rusl').</summary>
        UndeadSkeletonLifeSpan = 1819506002,
        /// <summary>Undead creature armor ('Rucr').</summary>
        UndeadCreatureArmor = 1919120722,
        /// <summary>Undead plague cloud ('Rupc').</summary>
        UndeadPlagueCloud = 1668314450,
        /// <summary>Undead skeletal mastery ('Rusm').</summary>
        UndeadSkeletalMastery = 1836283218,
        /// <summary>Undead burrowing ('Rubu').</summary>
        UndeadBurrowing = 1969386834,
        /// <summary>Undead avenger transform ('Rusp').</summary>
        UndeadAvengerTransform = 1886614866,
        /// <summary>Undead exhume corpses ('Ruex').</summary>
        UndeadExhumeCorpses = 2019915090,
        /// <summary>Undead backpack ('Rupm').</summary>
        UndeadBackpack = 1836086610,
        /// <summary>Nightelf strength of moon ('Resm').</summary>
        NightelfStrengthOfMoon = 1836279122,
        /// <summary>Nightelf strength of wild ('Resw').</summary>
        NightelfStrengthOfWild = 2004051282,
        /// <summary>Nightelf moon armor ('Rema').</summary>
        NightelfMoonArmor = 1634559314,
        /// <summary>Nightelf reinforced hides ('Rerh').</summary>
        NightelfReinforcedHides = 1752327506,
        /// <summary>Nightelf ultravision ('Reuv').</summary>
        NightelfUltravision = 1987405138,
        /// <summary>Nightelf nature s blessing ('Renb').</summary>
        NightelfNatureSBlessing = 1651402066,
        /// <summary>Nightelf scout ('Resc').</summary>
        NightelfScout = 1668506962,
        /// <summary>Nightelf moon glaive upgrade ('Remg').</summary>
        NightelfMoonGlaiveUpgrade = 1735222610,
        /// <summary>Nightelf improved bows ('Reib').</summary>
        NightelfImprovedBows = 1651074386,
        /// <summary>Nightelf marksmanship ('Remk').</summary>
        NightelfMarksmanship = 1802331474,
        /// <summary>Nightelf do t training ('Redt').</summary>
        NightelfDoTTraining = 1952736594,
        /// <summary>Nightelf do c training ('Redc').</summary>
        NightelfDoCTraining = 1667523922,
        /// <summary>Nightelf abolish magic ('Resi').</summary>
        NightelfAbolishMagic = 1769170258,
        /// <summary>Nightelf corrosive breath ('Recb').</summary>
        NightelfCorrosiveBreath = 1650681170,
        /// <summary>Nightelf hippogryph taming ('Reht').</summary>
        NightelfHippogryphTaming = 1952998738,
        /// <summary>Nightelf impaling bolt ('Repb').</summary>
        NightelfImpalingBolt = 1651533138,
        /// <summary>Nightelf resistant skin ('Rers').</summary>
        NightelfResistantSkin = 1936876882,
        /// <summary>Nightelf hardened skin ('Rehs').</summary>
        NightelfHardenedSkin = 1936221522,
        /// <summary>Nightelf enchanted bears ('Reeb').</summary>
        NightelfEnchantedBears = 1650812242,
        /// <summary>Nightelf enchanted crows ('Reec').</summary>
        NightelfEnchantedCrows = 1667589458,
        /// <summary>Nightelf well spring ('Rews').</summary>
        NightelfWellSpring = 1937204562,
        /// <summary>Nightelf backpack ('Repm').</summary>
        NightelfBackpack = 1836082514,
        /// <summary>Glyph of fortification ('Rgfo').</summary>
        GlyphOfFortification = 1868982098,
        /// <summary>Glyph of ultravision ('Rguv').</summary>
        GlyphOfUltravision = 1987405650,
        /// <summary>Naga myrmidon ensnare ('Rnen').</summary>
        NagaMyrmidonEnsnare = 1852141138,
        /// <summary>Naga sea witch training ('Rnsw').</summary>
        NagaSeaWitchTraining = 2004053586,
        /// <summary>Naga abolish magic ('Rnsi').</summary>
        NagaAbolishMagic = 1769172562,
        /// <summary>Naga attack ('Rnat').</summary>
        NagaAttack = 1952542290,
        /// <summary>Naga armor ('Rnam').</summary>
        NagaArmor = 1835101778,
        /// <summary>Naga submerge ('Rnsb').</summary>
        NagaSubmerge = 1651732050
    }
}