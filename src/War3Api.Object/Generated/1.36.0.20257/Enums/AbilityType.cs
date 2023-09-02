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
    public enum AbilityType
    {
        /// <summary>Arch mage blizzard ('AHbz').</summary>
        ArchMageBlizzard = 2053261377,
        /// <summary>Arch mage brilliance aura ('AHab').</summary>
        ArchMageBrillianceAura = 1650542657,
        /// <summary>Arch mage mass teleport ('AHmt').</summary>
        ArchMageMassTeleport = 1953318977,
        /// <summary>Arch mage water elemental ('AHwe').</summary>
        ArchMageWaterElemental = 1702316097,
        /// <summary>Beast master stampede ('ANst').</summary>
        BeastMasterStampede = 1953713729,
        /// <summary>Beast master summon bear ('ANsg').</summary>
        BeastMasterSummonBear = 1735609921,
        /// <summary>Beast master summon quilbeast ('ANsq').</summary>
        BeastMasterSummonQuilbeast = 1903382081,
        /// <summary>Beast master summon hawk ('ANsw').</summary>
        BeastMasterSummonHawk = 2004045377,
        /// <summary>Blade master bladestorm ('AOww').</summary>
        BladeMasterBladestorm = 2004307777,
        /// <summary>Blade master critical strike ('AOcr').</summary>
        BladeMasterCriticalStrike = 1919110977,
        /// <summary>Blade master mirror image ('AOmi').</summary>
        BladeMasterMirrorImage = 1768771393,
        /// <summary>Blade master wind walk ('AOwk').</summary>
        BladeMasterWindWalk = 1802981185,
        /// <summary>Blood mage banish ('AHbn').</summary>
        BloodMageBanish = 1851934785,
        /// <summary>Blood mage flame strike ('AHfs').</summary>
        BloodMageFlameStrike = 1936083009,
        /// <summary>Blood mage siphon mana ('AHdr').</summary>
        BloodMageSiphonMana = 1919174721,
        /// <summary>Blood mage phoenix ('AHpx').</summary>
        BloodMagePhoenix = 2020624449,
        /// <summary>Crypt lord carrion scarabs ('AUcb').</summary>
        CryptLordCarrionScarabs = 1650677057,
        /// <summary>Crypt lord impale ('AUim').</summary>
        CryptLordImpale = 1835619649,
        /// <summary>Crypt lord locust swarm ('AUls').</summary>
        CryptLordLocustSwarm = 1936479553,
        /// <summary>Crypt lord spiked carapace ('AUts').</summary>
        CryptLordSpikedCarapace = 1937003841,
        /// <summary>Dark ranger black arrow ('ANba').</summary>
        DarkRangerBlackArrow = 1633832513,
        /// <summary>Dark ranger charm ('ANch').</summary>
        DarkRangerCharm = 1751338561,
        /// <summary>Dark ranger drain ('ANdr').</summary>
        DarkRangerDrain = 1919176257,
        /// <summary>Dark ranger silence ('ANsi').</summary>
        DarkRangerSilence = 1769164353,
        /// <summary>Death knight animate dead ('AUan').</summary>
        DeathKnightAnimateDead = 1851872577,
        /// <summary>Death knight death coil ('AUdc').</summary>
        DeathKnightDeathCoil = 1667519809,
        /// <summary>Death knight death pact ('AUdp').</summary>
        DeathKnightDeathPact = 1885623617,
        /// <summary>Death knight unholy aura ('AUau').</summary>
        DeathKnightUnholyAura = 1969313089,
        /// <summary>Demon hunter evasion ('AEev').</summary>
        DemonHunterEvasion = 1986348353,
        /// <summary>Demon hunter immolation ('AEim').</summary>
        DemonHunterImmolation = 1835615553,
        /// <summary>Demon hunter mana burn ('AEmb').</summary>
        DemonHunterManaBurn = 1651328321,
        /// <summary>Demon hunter metamorphosis ('AEme').</summary>
        DemonHunterMetamorphosis = 1701659969,
        /// <summary>Dreadlord sleep ('AUsl').</summary>
        DreadlordSleep = 1819497793,
        /// <summary>Dreadlord vampiric aura ('AUav').</summary>
        DreadlordVampiricAura = 1986090305,
        /// <summary>Dreadlord carrion swarm ('AUcs').</summary>
        DreadlordCarrionSwarm = 1935889729,
        /// <summary>Dreadlord inferno ('AUin').</summary>
        DreadlordInferno = 1852396865,
        /// <summary>Farseer chain lightning ('AOcl').</summary>
        FarseerChainLightning = 1818447681,
        /// <summary>Farseer earthquake ('AOeq').</summary>
        FarseerEarthquake = 1902464833,
        /// <summary>Farseer far sight ('AOfs').</summary>
        FarseerFarSight = 1936084801,
        /// <summary>Farseer spirit wolf ('AOsf').</summary>
        FarseerSpiritWolf = 1718832961,
        /// <summary>Keeper entangling roots ('AEer').</summary>
        KeeperEntanglingRoots = 1919239489,
        /// <summary>Keeper force of nature ('AEfn').</summary>
        KeeperForceOfNature = 1852196161,
        /// <summary>Keeper thorns aura ('AEah').</summary>
        KeeperThornsAura = 1751205185,
        /// <summary>Keeper tranquility ('AEtq').</summary>
        KeeperTranquility = 1903445313,
        /// <summary>Lich dark ritual ('AUdr').</summary>
        LichDarkRitual = 1919178049,
        /// <summary>Lich death and decay ('AUdd').</summary>
        LichDeathAndDecay = 1684297025,
        /// <summary>Lich frost armor ('AUfa').</summary>
        LichFrostArmor = 1634096449,
        /// <summary>Lich frost armor autocast ('AUfu').</summary>
        LichFrostArmorAutocast = 1969640769,
        /// <summary>Lich frost nova ('AUfn').</summary>
        LichFrostNova = 1852200257,
        /// <summary>Mountain king avatar ('AHav').</summary>
        MountainKingAvatar = 1986086977,
        /// <summary>Mountain king bash ('AHbh').</summary>
        MountainKingBash = 1751271489,
        /// <summary>Mountain king thunder bolt ('AHtb').</summary>
        MountainKingThunderBolt = 1651787841,
        /// <summary>Mountain king thunder clap ('AHtc').</summary>
        MountainKingThunderClap = 1668565057,
        /// <summary>Sea witch forked lightning ('ANfl').</summary>
        SeaWitchForkedLightning = 1818644033,
        /// <summary>Sea witch frost arrows ('ANfa').</summary>
        SeaWitchFrostArrows = 1634094657,
        /// <summary>Sea witch tornado ('ANto').</summary>
        SeaWitchTornado = 1869893185,
        /// <summary>Sea witch mana shield ('ANms').</summary>
        SeaWitchManaShield = 1936543297,
        /// <summary>Paladin devotion aura ('AHad').</summary>
        PaladinDevotionAura = 1684097089,
        /// <summary>Paladin divine shield ('AHds').</summary>
        PaladinDivineShield = 1935951937,
        /// <summary>Paladin holy light ('AHhb').</summary>
        PaladinHolyLight = 1651001409,
        /// <summary>Paladin resurrection ('AHre').</summary>
        PaladinResurrection = 1701988417,
        /// <summary>Brewmaster breath of fire ('ANbf').</summary>
        BrewmasterBreathOfFire = 1717718593,
        /// <summary>Brewmaster drunken brawler ('ANdb').</summary>
        BrewmasterDrunkenBrawler = 1650740801,
        /// <summary>Brewmaster drunken haze ('ANdh').</summary>
        BrewmasterDrunkenHaze = 1751404097,
        /// <summary>Brewmaster storm earth and fire ('ANef').</summary>
        BrewmasterStormEarthAndFire = 1717915201,
        /// <summary>Pit lord doom ('ANdo').</summary>
        PitLordDoom = 1868844609,
        /// <summary>Pit lord howl of terror ('ANht').</summary>
        PitLordHowlOfTerror = 1952992833,
        /// <summary>Pit lord cleaving attack ('ANca').</summary>
        PitLordCleavingAttack = 1633898049,
        /// <summary>Pit lord rain of fire ('ANrf').</summary>
        PitLordRainOfFire = 1718767169,
        /// <summary>Priestess searing arrows ('AHfa').</summary>
        PriestessSearingArrows = 1634093121,
        /// <summary>Priestess scout ('AEst').</summary>
        PriestessScout = 1953711425,
        /// <summary>Priestess starfall ('AEsf').</summary>
        PriestessStarfall = 1718830401,
        /// <summary>Priestess trueshot aura ('AEar').</summary>
        PriestessTrueshotAura = 1918977345,
        /// <summary>Chieftain endurance aura ('AOae').</summary>
        ChieftainEnduranceAura = 1700876097,
        /// <summary>Chieftain reincarnation ('AOre').</summary>
        ChieftainReincarnation = 1701990209,
        /// <summary>Chieftain shock wave ('AOsh').</summary>
        ChieftainShockWave = 1752387393,
        /// <summary>Chieftain war stomp ('AOws').</summary>
        ChieftainWarStomp = 1937198913,
        /// <summary>Shadow hunter healing wave ('AOhw').</summary>
        ShadowHunterHealingWave = 2003324737,
        /// <summary>Shadow hunter hex ('AOhx').</summary>
        ShadowHunterHex = 2020101953,
        /// <summary>Shadow hunter serpent ward ('AOsw').</summary>
        ShadowHunterSerpentWard = 2004045633,
        /// <summary>Shadow hunter voodooo ('AOvd').</summary>
        ShadowHunterVoodooo = 1685475137,
        /// <summary>Warden blink ('AEbl').</summary>
        WardenBlink = 1818379585,
        /// <summary>Warden fan of knives ('AEfk').</summary>
        WardenFanOfKnives = 1801864513,
        /// <summary>Warden shadow strike ('AEsh').</summary>
        WardenShadowStrike = 1752384833,
        /// <summary>Warden spirit of vengeance ('AEsv').</summary>
        WardenSpiritOfVengeance = 1987265857,
        /// <summary>Alchemist acid bomb ('ANab').</summary>
        AlchemistAcidBomb = 1650544193,
        /// <summary>Alchemist chemical rage ('ANcr').</summary>
        AlchemistChemicalRage = 1919110721,
        /// <summary>Alchemist healing spray ('ANhs').</summary>
        AlchemistHealingSpray = 1936215617,
        /// <summary>Alchemist transmute ('ANtm').</summary>
        AlchemistTransmute = 1836338753,
        /// <summary>Tinkerer engineering upgrade ('ANeg').</summary>
        TinkererEngineeringUpgrade = 1734692417,
        /// <summary>Tinkerer cluster rockets level 0 ('ANcs').</summary>
        TinkererClusterRocketsLevel0 = 1935887937,
        /// <summary>Tinkerer cluster rockets level 1 ('ANc1').</summary>
        TinkererClusterRocketsLevel1 = 828591681,
        /// <summary>Tinkerer cluster rockets level 2 ('ANc2').</summary>
        TinkererClusterRocketsLevel2 = 845368897,
        /// <summary>Tinkerer cluster rockets level 3 ('ANc3').</summary>
        TinkererClusterRocketsLevel3 = 862146113,
        /// <summary>Tinkerer robo goblin level 0 ('ANrg').</summary>
        TinkererRoboGoblinLevel0 = 1735544385,
        /// <summary>Tinkerer robo goblin level 1 ('ANg1').</summary>
        TinkererRoboGoblinLevel1 = 828853825,
        /// <summary>Tinkerer robo goblin level 2 ('ANg2').</summary>
        TinkererRoboGoblinLevel2 = 845631041,
        /// <summary>Tinkerer robo goblin level 3 ('ANg3').</summary>
        TinkererRoboGoblinLevel3 = 862408257,
        /// <summary>Tinkerer summon factory level 0 ('ANsy').</summary>
        TinkererSummonFactoryLevel0 = 2037599809,
        /// <summary>Tinkerer summon factory level 1 ('ANs1').</summary>
        TinkererSummonFactoryLevel1 = 829640257,
        /// <summary>Tinkerer summon factory level 2 ('ANs2').</summary>
        TinkererSummonFactoryLevel2 = 846417473,
        /// <summary>Tinkerer summon factory level 3 ('ANs3').</summary>
        TinkererSummonFactoryLevel3 = 863194689,
        /// <summary>Tinkerer demolish level 0 ('ANde').</summary>
        TinkererDemolishLevel0 = 1701072449,
        /// <summary>Tinkerer demolish level 1 ('ANd1').</summary>
        TinkererDemolishLevel1 = 828657217,
        /// <summary>Tinkerer demolish level 2 ('ANd2').</summary>
        TinkererDemolishLevel2 = 845434433,
        /// <summary>Tinkerer demolish level 3 ('ANd3').</summary>
        TinkererDemolishLevel3 = 862211649,
        /// <summary>Firelord incinerate ('ANic').</summary>
        FirelordIncinerate_ANic = 1667845697,
        /// <summary>Firelord incinerate ('ANia').</summary>
        FirelordIncinerate_ANia = 1634291265,
        /// <summary>Firelord soul burn ('ANso').</summary>
        FirelordSoulBurn = 1869827649,
        /// <summary>Firelord summon lava spawn ('ANlm').</summary>
        FirelordSummonLavaSpawn = 1835814465,
        /// <summary>Firelord volcano ('ANvc').</summary>
        FirelordVolcano = 1668697665,
        /// <summary>Inferno ('ANin').</summary>
        Inferno = 1852395073,
        /// <summary>Tichondrius inferno ('SNin').</summary>
        TichondriusInferno = 1852395091,
        /// <summary>Fire bolt ('ANfb').</summary>
        FireBolt = 1650871873,
        /// <summary>Finger of death ('ANfd').</summary>
        FingerOfDeath_ANfd = 1684426305,
        /// <summary>Finger of pain ('ACfd').</summary>
        FingerOfPain = 1684423489,
        /// <summary>Finger of pain 2 1 button ('ACf3').</summary>
        FingerOfPain21Button = 862339905,
        /// <summary>Dark portal ('ANdp').</summary>
        DarkPortal = 1885621825,
        /// <summary>Rain of chaos ('ANrc').</summary>
        RainOfChaos = 1668435521,
        /// <summary>Rain of chaos button 0 2 ('ANr3').</summary>
        RainOfChaosButton02 = 863129153,
        /// <summary>Cenarius beefy starfall ('AEsb').</summary>
        CenariusBeefyStarfall = 1651721537,
        /// <summary>Mannoroth reincarnation ('ANrn').</summary>
        MannorothReincarnation = 1852984897,
        /// <summary>Malganis dark conversion ('ANdc').</summary>
        MalganisDarkConversion = 1667518017,
        /// <summary>Dark conversion fast ('SNdc').</summary>
        DarkConversionFast = 1667518035,
        /// <summary>Malganis soul preservation ('ANsl').</summary>
        MalganisSoulPreservation = 1819496001,
        /// <summary>Illidan metamorphosis ('AEIl').</summary>
        IllidanMetamorphosis = 1816741185,
        /// <summary>Evil illidan metamorphosis ('AEvi').</summary>
        EvilIllidanMetamorphosis = 1769358657,
        /// <summary>Super earthquake ('SNeq').</summary>
        SuperEarthquake = 1902464595,
        /// <summary>Super death and decay ('SNdd').</summary>
        SuperDeathAndDecay = 1684295251,
        /// <summary>Monsoon ('ANmo').</summary>
        Monsoon = 1869434433,
        /// <summary>Poison arrows ('AEpa').</summary>
        PoisonArrows = 1634747713,
        /// <summary>Watery minion ('ANwm').</summary>
        WateryMinion = 1836535361,
        /// <summary>Cold arrows ('AHca').</summary>
        ColdArrows = 1633896513,
        /// <summary>Battle roar ('ANbr').</summary>
        BattleRoar = 1919045185,
        /// <summary>Rexxar summon bear ('Arsg').</summary>
        RexxarSummonBear = 1735619137,
        /// <summary>Attribute modifier skill ('Aamk').</summary>
        AttributeModifierSkill = 1802330433,
        /// <summary>Rexxar summon quilbeast ('Arsq').</summary>
        RexxarSummonQuilbeast = 1903391297,
        /// <summary>Rexxar stampede ('Arsp').</summary>
        RexxarStampede = 1886614081,
        /// <summary>Rexxar storm bolt ('ANsb').</summary>
        RexxarStormBolt = 1651723841,
        /// <summary>Rokhan healing wave ('ANhw').</summary>
        RokhanHealingWave = 2003324481,
        /// <summary>Rokhan serpent ward ('Arsw').</summary>
        RokhanSerpentWard = 2004054593,
        /// <summary>Rokhan hex ('ANhx').</summary>
        RokhanHex = 2020101697,
        /// <summary>Rokhan voodoo spirits ('AOls').</summary>
        RokhanVoodooSpirits = 1936478017,
        /// <summary>Chen breath of fire ('ANcf').</summary>
        ChenBreathOfFire = 1717784129,
        /// <summary>Chen drunken brawler ('Acdb').</summary>
        ChenDrunkenBrawler = 1650746177,
        /// <summary>Chen drunken haze ('Acdh').</summary>
        ChenDrunkenHaze = 1751409473,
        /// <summary>Chen storm earth and fire ('Acef').</summary>
        ChenStormEarthAndFire = 1717920577,
        /// <summary>Cairne endurance aura ('AOr2').</summary>
        CairneEnduranceAura = 846352193,
        /// <summary>Cairne reincarnation ('AOr3').</summary>
        CairneReincarnation = 863129409,
        /// <summary>Cairne shock wave ('AOs2').</summary>
        CairneShockWave = 846417729,
        /// <summary>Cairne war stomp ('AOw2').</summary>
        CairneWarStomp = 846679873,
        /// <summary>Illidan channel ('ANcl').</summary>
        IllidanChannel = 1818447425,
        /// <summary>Abolish magic ('Aadm').</summary>
        AbolishMagic = 1835295041,
        /// <summary>Abolish magic naga ('Andm').</summary>
        AbolishMagicNaga = 1835298369,
        /// <summary>Abolish magic creep ('ACdm').</summary>
        AbolishMagicCreep = 1835287361,
        /// <summary>Abolish magic creep 1 2 pos ('ACd2').</summary>
        AbolishMagicCreep12Pos = 845431617,
        /// <summary>Absorb mana ('Aabs').</summary>
        AbsorbMana = 1935827265,
        /// <summary>Acolyte harvest ('Aaha').</summary>
        AcolyteHarvest = 1634230593,
        /// <summary>Avatar garithos ('ANav').</summary>
        AvatarGarithos = 1986088513,
        /// <summary>Alarm ('Aalr').</summary>
        Alarm = 1919705409,
        /// <summary>Allied building ('Aall').</summary>
        AlliedBuilding = 1819042113,
        /// <summary>Ancestral spirit ('Aast').</summary>
        AncestralSpirit = 1953718593,
        /// <summary>Animate dead creep ('ACad').</summary>
        AnimateDeadCreep = 1684095809,
        /// <summary>Anti magic Shield ('Aams').</summary>
        AntiMagicShield_Aams = 1936548161,
        /// <summary>Anti magic Shield (Matrix) ('Aam2').</summary>
        AntiMagicShieldMatrix = 846029121,
        /// <summary>Anti magic Shield (creep) ('ACam').</summary>
        AntiMagicShieldCreep = 1835090753,
        /// <summary>Attack ('Aatk').</summary>
        Attack = 1802789185,
        /// <summary>Aura brilliance creep ('ACba').</summary>
        AuraBrillianceCreep = 1633829697,
        /// <summary>Aura command creep ('ACac').</summary>
        AuraCommandCreep = 1667318593,
        /// <summary>Aura devotion creep ('ACav').</summary>
        AuraDevotionCreep = 1986085697,
        /// <summary>Aura endurance creep ('SCae').</summary>
        AuraEnduranceCreep = 1700873043,
        /// <summary>Aura plague abomination ('Aap1').</summary>
        AuraPlagueAbomination = 829448513,
        /// <summary>Aura plague plague ward ('Aap2').</summary>
        AuraPlaguePlagueWard = 846225729,
        /// <summary>Aura plague creep ('Aap3').</summary>
        AuraPlagueCreep = 863002945,
        /// <summary>Aura plague creep gfx ('Aap4').</summary>
        AuraPlagueCreepGfx = 879780161,
        /// <summary>Aura plague animated dead ('Aap5').</summary>
        AuraPlagueAnimatedDead = 896557377,
        /// <summary>Aura regeneration ward ('Aoar').</summary>
        AuraRegenerationWard = 1918988097,
        /// <summary>Aura regeneration statue ('Aabr').</summary>
        AuraRegenerationStatue = 1919050049,
        /// <summary>Aura slow ('Aasl').</summary>
        AuraSlow = 1819500865,
        /// <summary>Aura trueshot creep ('ACat').</summary>
        AuraTrueshotCreep = 1952531265,
        /// <summary>Aura war drums ('Aakb').</summary>
        AuraWarDrums = 1651204417,
        /// <summary>Avenger form ('Aave').</summary>
        AvengerForm = 1702256961,
        /// <summary>Awaken ('Aawa').</summary>
        Awaken = 1635213633,
        /// <summary>Balls of fire ('Abof').</summary>
        BallsOfFire = 1718575681,
        /// <summary>Banish creep ('ACbn').</summary>
        BanishCreep = 1851933505,
        /// <summary>Bash creep ('ACbh').</summary>
        BashCreep = 1751270209,
        /// <summary>Bash beastmaster bear ('ANbh').</summary>
        BashBeastmasterBear = 1751273025,
        /// <summary>Bash maul SP bear level 3 ('ANb2').</summary>
        BashMaulSPBearLevel3 = 845303361,
        /// <summary>Battlestations ('Abtl').</summary>
        Battlestations = 1819566657,
        /// <summary>Battlestations chaos ('Sbtl').</summary>
        BattlestationsChaos = 1819566675,
        /// <summary>Bearform ('Abrf').</summary>
        Bearform = 1718772289,
        /// <summary>Beserk ('Absk').</summary>
        Beserk = 1802723905,
        /// <summary>Berserker upgrade ('Sbsk').</summary>
        BerserkerUpgrade = 1802723923,
        /// <summary>Black arrow melee creep ('ACbk').</summary>
        BlackArrowMeleeCreep = 1801601857,
        /// <summary>Blight dispel small ('Abds').</summary>
        BlightDispelSmall = 1935958593,
        /// <summary>Blight dispel large ('Abdl').</summary>
        BlightDispelLarge = 1818518081,
        /// <summary>Blight growth small ('Abgs').</summary>
        BlightGrowthSmall = 1936155201,
        /// <summary>Blight growth large ('Abgl').</summary>
        BlightGrowthLarge = 1818714689,
        /// <summary>Blighted gold mine ('Abgm').</summary>
        BlightedGoldMine = 1835491905,
        /// <summary>Blink beastmaster bear ('ANbl').</summary>
        BlinkBeastmasterBear = 1818381889,
        /// <summary>Blizzard creep ('ACbz').</summary>
        BlizzardCreep = 2053260097,
        /// <summary>Bloodlust ('Ablo').</summary>
        Bloodlust = 1869374017,
        /// <summary>Bloodlust creep ('ACbl').</summary>
        BloodlustCreep = 1818379073,
        /// <summary>Bloodlust creep hotkey B ('ACbb').</summary>
        BloodlustCreepHotkeyB = 1650606913,
        /// <summary>Breath of fire creep ('ACbc').</summary>
        BreathOfFireCreep = 1667384129,
        /// <summary>Breath of frost creep ('ACbf').</summary>
        BreathOfFrostCreep = 1717715777,
        /// <summary>Build neutral ('ANbu').</summary>
        BuildNeutral = 1969376833,
        /// <summary>Build human ('AHbu').</summary>
        BuildHuman = 1969375297,
        /// <summary>Build orc ('AObu').</summary>
        BuildOrc = 1969377089,
        /// <summary>Build night elf ('AEbu').</summary>
        BuildNightElf = 1969374529,
        /// <summary>Build undead ('AUbu').</summary>
        BuildUndead = 1969378625,
        /// <summary>Build naga ('AGbu').</summary>
        BuildNaga = 1969375041,
        /// <summary>Burrow ('Abur').</summary>
        Burrow = 1920295489,
        /// <summary>Burrow scarab lvl 2 ('Abu2').</summary>
        BurrowScarabLvl2 = 846553665,
        /// <summary>Burrow scarab lvl 3 ('Abu3').</summary>
        BurrowScarabLvl3 = 863330881,
        /// <summary>Burrow barbed arachnathid ('Abu5').</summary>
        BurrowBarbedArachnathid = 896885313,
        /// <summary>Burrow detection flyers ('Abdt').</summary>
        BurrowDetectionFlyers = 1952735809,
        /// <summary>Cannibalize ('Acan').</summary>
        Cannibalize = 1851876161,
        /// <summary>Cannibalize abomination ('Acn2').</summary>
        CannibalizeAbomination = 846095169,
        /// <summary>Cannibalize creep ('ACcn').</summary>
        CannibalizeCreep = 1851999041,
        /// <summary>Cargo hold burrow ('Abun').</summary>
        CargoHoldBurrow = 1853186625,
        /// <summary>Cargo hold devour ('Advc').</summary>
        CargoHoldDevour = 1668703297,
        /// <summary>Cargo hold meat wagon ('Sch2').</summary>
        CargoHoldMeatWagon = 845701971,
        /// <summary>Cargo hold ship ('Sch5').</summary>
        CargoHoldShip = 896033619,
        /// <summary>Cargo hold tank ('Sch4').</summary>
        CargoHoldTank = 879256403,
        /// <summary>Cargo hold transport ('Sch3').</summary>
        CargoHoldTransport = 862479187,
        /// <summary>Cargo hold gold mine ('Aenc').</summary>
        CargoHoldGoldMine = 1668179265,
        /// <summary>Cargo hold death ('Achd').</summary>
        CargoHoldDeath = 1684562753,
        /// <summary>Carrion swarm creep ('ACca').</summary>
        CarrionSwarmCreep = 1633895233,
        /// <summary>Crushing wave ('ACcv').</summary>
        CrushingWave = 1986216769,
        /// <summary>Crushing wave dragon turtle ('ACc2').</summary>
        CrushingWaveDragonTurtle = 845366081,
        /// <summary>Crushing wave lesser ('ACc3').</summary>
        CrushingWaveLesser = 862143297,
        /// <summary>Chain lightning creep ('ACcl').</summary>
        ChainLightningCreep = 1818444609,
        /// <summary>Chain dispel ('Ache').</summary>
        ChainDispel = 1701339969,
        /// <summary>Chaos grunt ('Sca1').</summary>
        ChaosGrunt = 828466003,
        /// <summary>Chaos raider ('Sca2').</summary>
        ChaosRaider = 845243219,
        /// <summary>Chaos shaman ('Sca3').</summary>
        ChaosShaman = 862020435,
        /// <summary>Chaos kodo ('Sca4').</summary>
        ChaosKodo = 878797651,
        /// <summary>Chaos peon ('Sca5').</summary>
        ChaosPeon = 895574867,
        /// <summary>Chaos grom ('Sca6').</summary>
        ChaosGrom = 912352083,
        /// <summary>Chaos cargo load ('Achl').</summary>
        ChaosCargoLoad = 1818780481,
        /// <summary>Charm ('ACch').</summary>
        Charm = 1751335745,
        /// <summary>Cleaving attack creep ('ACce').</summary>
        CleavingAttackCreep = 1701004097,
        /// <summary>Cloud of fog ('Aclf').</summary>
        CloudOfFog = 1718379329,
        /// <summary>Cold arrows creep ('ACcw').</summary>
        ColdArrowsCreep = 2002993985,
        /// <summary>Control magic ('Acmg').</summary>
        ControlMagic = 1735222081,
        /// <summary>Corporeal form ('Acpf').</summary>
        CorporealForm = 1718641473,
        /// <summary>Corrosive breath ('Acor').</summary>
        CorrosiveBreath = 1919902529,
        /// <summary>Couple archer ('Acoa').</summary>
        CoupleArcher = 1634689857,
        /// <summary>Couple hippogryph ('Acoh').</summary>
        CoupleHippogryph = 1752130369,
        /// <summary>Couple instant archer ('Aco2').</summary>
        CoupleInstantArcher = 846160705,
        /// <summary>Couple instant hippogryph ('Aco3').</summary>
        CoupleInstantHippogryph = 862937921,
        /// <summary>Creep sleep ('ACsp').</summary>
        CreepSleep = 1886602049,
        /// <summary>Cripple ('Acri').</summary>
        Cripple = 1769104193,
        /// <summary>Cripple warlock ('Scri').</summary>
        CrippleWarlock = 1769104211,
        /// <summary>Cripple creep ('ACcr').</summary>
        CrippleCreep = 1919107905,
        /// <summary>Critical strike creep ('ACct').</summary>
        CriticalStrikeCreep = 1952662337,
        /// <summary>Curse ('Acrs').</summary>
        Curse = 1936876353,
        /// <summary>Curse creep ('ACcs').</summary>
        CurseCreep = 1935885121,
        /// <summary>Cyclone ('Acyc').</summary>
        Cyclone_Acyc = 1668899649,
        /// <summary>Cyclone naga ('Acny').</summary>
        CycloneNaga = 2037277505,
        /// <summary>Cyclone creep ('ACcy').</summary>
        CycloneCreep = 2036548417,
        /// <summary>Cyclone cenarius ('SCc1').</summary>
        CycloneCenarius = 828588883,
        /// <summary>Death coil creep ('ACdc').</summary>
        DeathCoilCreep = 1667515201,
        /// <summary>Death damage sapper ('Adda').</summary>
        DeathDamageSapper = 1633969217,
        /// <summary>Death damage mine ('Amnx').</summary>
        DeathDamageMine = 2020502849,
        /// <summary>Death damage mine BIG ('Amnz').</summary>
        DeathDamageMineBIG = 2054057281,
        /// <summary>Decouple ('Adec').</summary>
        Decouple = 1667589185,
        /// <summary>Defend ('Adef').</summary>
        Defend = 1717920833,
        /// <summary>Detect sentry ward ('Adt1').</summary>
        DetectSentryWard = 829711425,
        /// <summary>Detect shade ('Atru').</summary>
        DetectShade = 1970435137,
        /// <summary>Detect general ('Adtg').</summary>
        DetectGeneral = 1735681089,
        /// <summary>Detect war eagle ('ANtr').</summary>
        DetectWarEagle = 1920224833,
        /// <summary>Detect gyrocopter ('Agyv').</summary>
        DetectGyrocopter = 1987667777,
        /// <summary>Detect magic sentinel ('Adts').</summary>
        DetectMagicSentinel = 1937007681,
        /// <summary>Detonate ('Adtn').</summary>
        Detonate = 1853121601,
        /// <summary>Devour ('Adev').</summary>
        Devour = 1986356289,
        /// <summary>Devour dragon creep ('ACdv').</summary>
        DevourDragonCreep = 1986282305,
        /// <summary>Devour magic ('Advm').</summary>
        DevourMagic = 1836475457,
        /// <summary>Devour magic creep ('ACde').</summary>
        DevourMagicCreep = 1701069633,
        /// <summary>Disenchant old ('Adch').</summary>
        DisenchantOld = 1751344193,
        /// <summary>Disenchant new ('Adcn').</summary>
        DisenchantNew = 1852007489,
        /// <summary>Dispel magic ('Adis').</summary>
        DispelMagic = 1936286785,
        /// <summary>Dispel magic creep ('Adsm').</summary>
        DispelMagicCreep = 1836278849,
        /// <summary>Divine shield creep ('ACds').</summary>
        DivineShieldCreep = 1935950657,
        /// <summary>Drain life creep ('ACdr').</summary>
        DrainLifeCreep = 1919173441,
        /// <summary>Drop instant ('Adri').</summary>
        DropInstant = 1769104449,
        /// <summary>Drop ('Adro').</summary>
        Drop_Adro = 1869767745,
        /// <summary>Drop ('Sdro').</summary>
        Drop_Sdro = 1869767763,
        /// <summary>Drop pilot ('Atdp').</summary>
        DropPilot = 1885631553,
        /// <summary>Eat tree ('Aeat').</summary>
        EatTree = 1952539969,
        /// <summary>Elune s grace ('Aegr').</summary>
        EluneSGrace = 1919378753,
        /// <summary>Ensnare naga ('ANen').</summary>
        EnsnareNaga = 1852132929,
        /// <summary>Ensnare ('Aens').</summary>
        Ensnare = 1936614721,
        /// <summary>Ensnare creep ('ACen').</summary>
        EnsnareCreep = 1852130113,
        /// <summary>Entangle ('Aent').</summary>
        Entangle = 1953391937,
        /// <summary>Entangled gold mine ('Aegm').</summary>
        EntangledGoldMine = 1835492673,
        /// <summary>Entangling roots creep ('Aenr').</summary>
        EntanglingRootsCreep = 1919837505,
        /// <summary>Entangling seaweed ('Aenw').</summary>
        EntanglingSeaweed = 2003723585,
        /// <summary>Ethereal ('Aetl').</summary>
        Ethereal = 1819567425,
        /// <summary>Ethereal form ('Aetf').</summary>
        EtherealForm = 1718904129,
        /// <summary>Evasion creep ('ACev').</summary>
        EvasionCreep = 1986347841,
        /// <summary>Evasion creep 100 ('ACes').</summary>
        EvasionCreep100 = 1936016193,
        /// <summary>Exhume ('Aexh').</summary>
        Exhume = 1752720705,
        /// <summary>Factory ('ANfy').</summary>
        Factory = 2036747841,
        /// <summary>Faerie fire ('Afae').</summary>
        FaerieFire_Afae = 1700881985,
        /// <summary>Faerie fire ('Afa2').</summary>
        FaerieFire_Afa2 = 845243969,
        /// <summary>Faerie fire creep ('ACff').</summary>
        FaerieFireCreep = 1717977921,
        /// <summary>Feedback ('Afbk').</summary>
        Feedback = 1801610817,
        /// <summary>Feedback arcane tower ('Afbt').</summary>
        FeedbackArcaneTower = 1952605761,
        /// <summary>Feedback spirit beast ('Afbb').</summary>
        FeedbackSpiritBeast = 1650615873,
        /// <summary>Feral spirit creep ('ACsf').</summary>
        FeralSpiritCreep = 1718829889,
        /// <summary>Feral spirit creep pig ('ACs9').</summary>
        FeralSpiritCreepPig = 963855169,
        /// <summary>Feral spirit spirit beast ('ACs8').</summary>
        FeralSpiritSpiritBeast = 947077953,
        /// <summary>Feral spirit akama ('ACs7').</summary>
        FeralSpiritAkama = 930300737,
        /// <summary>Finger of death ('Afod').</summary>
        FingerOfDeath_Afod = 1685022273,
        /// <summary>Fire bolt warlock ('Awfb').</summary>
        FireBoltWarlock = 1650882369,
        /// <summary>Fire bolt creep ('ACfb').</summary>
        FireBoltCreep = 1650869057,
        /// <summary>Flak cannon ('Aflk').</summary>
        FlakCannon = 1802266177,
        /// <summary>Flare ('Afla').</summary>
        Flare = 1634494017,
        /// <summary>Flame strike creep ('ACfs').</summary>
        FlameStrikeCreep = 1936081729,
        /// <summary>Flame strike improved creep ('ANfs').</summary>
        FlameStrikeImprovedCreep = 1936084545,
        /// <summary>Force of nature creep ('ACfr').</summary>
        ForceOfNatureCreep = 1919304513,
        /// <summary>Forked lightning creep ('ACfl').</summary>
        ForkedLightningCreep = 1818641217,
        /// <summary>Frag shards ('Afsh').</summary>
        FragShards = 1752393281,
        /// <summary>Freezing breath ('Afrz').</summary>
        FreezingBreath = 2054317633,
        /// <summary>Frenzy ('Afzy').</summary>
        Frenzy = 2038064705,
        /// <summary>Frost armor creep old ('ACfa').</summary>
        FrostArmorCreepOld = 1634091841,
        /// <summary>Frost armor creep autocast ('ACf2').</summary>
        FrostArmorCreepAutocast = 845562689,
        /// <summary>Frost armor autocast naga ('ACfu').</summary>
        FrostArmorAutocastNaga = 1969636161,
        /// <summary>Frost attack ('Afra').</summary>
        FrostAttack = 1634887233,
        /// <summary>Frost attack 1 2 ('Afr2').</summary>
        FrostAttack12 = 846358081,
        /// <summary>Frost breath ('Afrb').</summary>
        FrostBreath = 1651664449,
        /// <summary>Frost breath new has icon ('Afrc').</summary>
        FrostBreathNewHasIcon = 1668441665,
        /// <summary>Frost nova creep ('ACfn').</summary>
        FrostNovaCreep = 1852195649,
        /// <summary>Frost bolt ('ACcb').</summary>
        FrostBolt = 1650672449,
        /// <summary>Ghost ('Agho').</summary>
        Ghost = 1869113153,
        /// <summary>Ghost visible ('Aeth').</summary>
        GhostVisible = 1752458561,
        /// <summary>Gold mine ('Agld').</summary>
        GoldMine = 1684825921,
        /// <summary>Grab tree ('Agra').</summary>
        GrabTree = 1634887489,
        /// <summary>Graveyard ('Agyd').</summary>
        Graveyard = 1685677889,
        /// <summary>Gyrocopter bombs ('Agyb').</summary>
        GyrocopterBombs = 1652123457,
        /// <summary>Hardened skin ('Assk').</summary>
        HardenedSkin = 1802728257,
        /// <summary>Hardened skin naga turtle ('Ansk').</summary>
        HardenedSkinNagaTurtle = 1802726977,
        /// <summary>Harvest ('Ahar').</summary>
        Harvest = 1918986305,
        /// <summary>Harvest naga ('ANha').</summary>
        HarvestNaga = 1634225729,
        /// <summary>Harvest lumber ('Ahrl').</summary>
        HarvestLumber = 1819437121,
        /// <summary>Harvest lumber shredder ('Ahr3').</summary>
        HarvestLumberShredder = 863135809,
        /// <summary>Harvest lumber arch ghouls ('Ahr2').</summary>
        HarvestLumberArchGhouls = 846358593,
        /// <summary>Heal ('Ahea').</summary>
        Heal = 1634035777,
        /// <summary>Heal creep normal ('Anhe').</summary>
        HealCreepNormal_Anhe = 1701342785,
        /// <summary>Heal creep normal ('Anh1').</summary>
        HealCreepNormal_Anh1 = 828927553,
        /// <summary>Heal creep high ('Anh2').</summary>
        HealCreepHigh = 845704769,
        /// <summary>Healing ward ('Ahwd').</summary>
        HealingWard_Ahwd = 1685547073,
        /// <summary>Healing ward creep ('AChw').</summary>
        HealingWardCreep = 2003321665,
        /// <summary>Healing wave creep ('AChv').</summary>
        HealingWaveCreep = 1986544449,
        /// <summary>Null roar summoner ('Ahnl').</summary>
        NullRoarSummoner = 1819174977,
        /// <summary>Hero ('AHer').</summary>
        Hero = 1919240257,
        /// <summary>Hex creep ('AChx').</summary>
        HexCreep = 2020098881,
        /// <summary>Howl of terror ('Acht').</summary>
        HowlOfTerror = 1952998209,
        /// <summary>Immolation creep ('ACim').</summary>
        ImmolationCreep = 1835615041,
        /// <summary>Impale creep ('ACmp').</summary>
        ImpaleCreep = 1886208833,
        /// <summary>Impaling bolt ('Aimp').</summary>
        ImpalingBolt = 1886218561,
        /// <summary>Inner fire ('Ainf').</summary>
        InnerFire = 1718511937,
        /// <summary>Inner fire creep ('ACif').</summary>
        InnerFireCreep = 1718174529,
        /// <summary>Invisibility ('Aivs').</summary>
        Invisibility = 1937140033,
        /// <summary>Inventory ('AInv').</summary>
        Inventory = 1986939201,
        /// <summary>Inventory pack mule ('Apak').</summary>
        InventoryPackMule = 1801547841,
        /// <summary>Inventory 2 slot unit orc ('Aion').</summary>
        Inventory2SlotUnitOrc = 1852795201,
        /// <summary>Inventory 2 slot unit human ('Aihn').</summary>
        Inventory2SlotUnitHuman = 1852336449,
        /// <summary>Inventory 2 slot unit night elf ('Aien').</summary>
        Inventory2SlotUnitNightElf = 1852139841,
        /// <summary>Inventory 2 slot unit undead ('Aiun').</summary>
        Inventory2SlotUnitUndead = 1853188417,
        /// <summary>Invulnerable ('Avul').</summary>
        Invulnerable = 1819637313,
        /// <summary>Lightning attack ('Alit').</summary>
        LightningAttack = 1953066049,
        /// <summary>Lightning shield ('Alsh').</summary>
        LightningShield = 1752394817,
        /// <summary>Lightning shield creep ('ACls').</summary>
        LightningShieldCreep = 1936474945,
        /// <summary>Liquid fire ('Aliq').</summary>
        LiquidFire = 1902734401,
        /// <summary>Load ('Aloa').</summary>
        Load = 1634692161,
        /// <summary>Load burrow ('Sloa').</summary>
        LoadBurrow = 1634692179,
        /// <summary>Load entangled gold mine ('Slo2').</summary>
        LoadEntangledGoldMine = 846163027,
        /// <summary>Load navies ('Slo3').</summary>
        LoadNavies = 862940243,
        /// <summary>Load pilot ('Atlp').</summary>
        LoadPilot = 1886155841,
        /// <summary>Locust ('Aloc').</summary>
        Locust = 1668246593,
        /// <summary>Magic defense ('Amdf').</summary>
        MagicDefense = 1717857601,
        /// <summary>Magic immunity ('Amim').</summary>
        MagicImmunity_Amim = 1835625793,
        /// <summary>Magic immunity creep ('ACmi').</summary>
        MagicImmunityCreep = 1768768321,
        /// <summary>Magic immunity archimonde ('ACm2').</summary>
        MagicImmunityArchimonde = 846021441,
        /// <summary>Magic immunity dragons ('ACm3').</summary>
        MagicImmunityDragons = 862798657,
        /// <summary>Aerial shackles ('Amls').</summary>
        AerialShackles = 1936485697,
        /// <summary>Mana battery ('Ambt').</summary>
        ManaBattery = 1952607553,
        /// <summary>Mana battery obsidian statue ('Amb2').</summary>
        ManaBatteryObsidianStatue = 845311297,
        /// <summary>Mana burn demon ('Amnb').</summary>
        ManaBurnDemon_Amnb = 1651404097,
        /// <summary>Mana burn demon ('Ambd').</summary>
        ManaBurnDemon_Ambd = 1684172097,
        /// <summary>Mana burn hotkey B ('Ambb').</summary>
        ManaBurnHotkeyB = 1650617665,
        /// <summary>Mana flare ('Amfl').</summary>
        ManaFlare = 1818651969,
        /// <summary>Mana shield creep ('ACmf').</summary>
        ManaShieldCreep = 1718436673,
        /// <summary>Meat drop ('Amed').</summary>
        MeatDrop = 1684368705,
        /// <summary>Meat load ('Amel').</summary>
        MeatLoad = 1818586433,
        /// <summary>Militia ('Amil').</summary>
        Militia = 1818848577,
        /// <summary>Militia conversion ('Amic').</summary>
        MilitiaConversion = 1667853633,
        /// <summary>Mind rot ('ANmr').</summary>
        MindRot = 1919766081,
        /// <summary>Mine ('Amin').</summary>
        Mine = 1852403009,
        /// <summary>Monsoon creep ('ACmo').</summary>
        MonsoonCreep = 1869431617,
        /// <summary>Moon glaive ('Amgl').</summary>
        MoonGlaive = 1818717505,
        /// <summary>Moon glaive no research ('Amgr').</summary>
        MoonGlaiveNoResearch = 1919380801,
        /// <summary>Move ('Amov').</summary>
        Move = 1987013953,
        /// <summary>Neutral building ('Aneu').</summary>
        NeutralBuilding = 1969581633,
        /// <summary>Neutral building any unit ('Ane2').</summary>
        NeutralBuildingAnyUnit = 845508161,
        /// <summary>Neutral detection reveal ability ('Andt').</summary>
        NeutralDetectionRevealAbility = 1952738881,
        /// <summary>Neutral regen mana only ('ANre').</summary>
        NeutralRegenManaOnly = 1701989953,
        /// <summary>Neutral regen health only ('ACnr').</summary>
        NeutralRegenHealthOnly = 1919828801,
        /// <summary>Neutral spell ('AAns').</summary>
        NeutralSpell = 1936605505,
        /// <summary>Neutral spies ('Ansp').</summary>
        NeutralSpies = 1886613057,
        /// <summary>Orb of annihilation ('Afak').</summary>
        OrbOfAnnihilation = 1801545281,
        /// <summary>Orb of annihilation quill spray ('ANak').</summary>
        OrbOfAnnihilationQuillSpray = 1801539137,
        /// <summary>On fire ('Afir').</summary>
        OnFire = 1919510081,
        /// <summary>On fire human ('Afih').</summary>
        OnFireHuman = 1751737921,
        /// <summary>On fire orc ('Afio').</summary>
        OnFireOrc = 1869178433,
        /// <summary>On fire night elf ('Afin').</summary>
        OnFireNightElf = 1852401217,
        /// <summary>On fire undead ('Afiu').</summary>
        OnFireUndead = 1969841729,
        /// <summary>Parasite ('ANpa').</summary>
        Parasite = 1634750017,
        /// <summary>Parasite eredar ('ACpa').</summary>
        ParasiteEredar = 1634747201,
        /// <summary>Permanent immolation ('ANpi').</summary>
        PermanentImmolation = 1768967745,
        /// <summary>Permanent immolation flying ('Apmf').</summary>
        PermanentImmolationFlying = 1718448193,
        /// <summary>Permanent immolation graphic ('Apig').</summary>
        PermanentImmolationGraphic = 1734963265,
        /// <summary>Permanent invisibility ('Apiv').</summary>
        PermanentInvisibility = 1986621505,
        /// <summary>Phase shift ('Apsh').</summary>
        PhaseShift = 1752395841,
        /// <summary>Phoenix ('Aphx').</summary>
        Phoenix = 2020110401,
        /// <summary>Phoenix fire ('Apxf').</summary>
        PhoenixFire = 1719169089,
        /// <summary>Plague toss ('Apts').</summary>
        PlagueToss = 1937010753,
        /// <summary>Poison attack ('Apoi').</summary>
        PoisonAttack = 1768910913,
        /// <summary>Polymorph ('Aply').</summary>
        Polymorph = 2037149761,
        /// <summary>Polymorph creep ('ACpy').</summary>
        PolymorphCreep = 2037400385,
        /// <summary>Possession ('Apos').</summary>
        Possession = 1936683073,
        /// <summary>Possession creep ('ACps').</summary>
        PossessionCreep = 1936737089,
        /// <summary>Possession channeling ('Aps2').</summary>
        PossessionChanneling = 846426177,
        /// <summary>Pulverize ('Awar').</summary>
        Pulverize = 1918990145,
        /// <summary>Pulverize sea giant ('ACpv').</summary>
        PulverizeSeaGiant = 1987068737,
        /// <summary>Purchase item ('Apit').</summary>
        PurchaseItem = 1953067073,
        /// <summary>Purge ('Aprg').</summary>
        Purge_Aprg = 1735553089,
        /// <summary>Purge ('Apg2').</summary>
        Purge_Apg2 = 845639745,
        /// <summary>Purge creep ('ACpu').</summary>
        PurgeCreep = 1970291521,
        /// <summary>Rain of fire creep ('ACrf').</summary>
        RainOfFireCreep = 1718764353,
        /// <summary>Rain of fire creep greater ('ACrg').</summary>
        RainOfFireCreepGreater = 1735541569,
        /// <summary>Raise dead ('Arai').</summary>
        RaiseDead = 1767993921,
        /// <summary>Raise dead creep ('ACrd').</summary>
        RaiseDeadCreep = 1685209921,
        /// <summary>Rally ('ARal').</summary>
        Rally = 1818317377,
        /// <summary>Raven form druid ('Arav').</summary>
        RavenFormDruid = 1986097729,
        /// <summary>Raven form medivh ('Amrf').</summary>
        RavenFormMedivh = 1718775105,
        /// <summary>Reincarnation creep ('ACrn').</summary>
        ReincarnationCreep = 1852982081,
        /// <summary>Reincarnation generic ('ANr2').</summary>
        ReincarnationGeneric = 846351937,
        /// <summary>Reinforced burrows ('Arbr').</summary>
        ReinforcedBurrows = 1919054401,
        /// <summary>Rejuvination ('Arej').</summary>
        Rejuvination = 1785033281,
        /// <summary>Rejuvination creep ('ACrj').</summary>
        RejuvinationCreep = 1785873217,
        /// <summary>Rejuvination furbolg ('ACr2').</summary>
        RejuvinationFurbolg = 846349121,
        /// <summary>Renew ('Aren').</summary>
        Renew = 1852142145,
        /// <summary>Repair human ('Ahrp').</summary>
        RepairHuman = 1886545985,
        /// <summary>Repair orc ('Arep').</summary>
        RepairOrc = 1885696577,
        /// <summary>Replenish life mana ('Arpb').</summary>
        ReplenishLifeMana = 1651536449,
        /// <summary>Replenish life ('Arpl').</summary>
        ReplenishLife = 1819308609,
        /// <summary>Replenish mana ('Arpm').</summary>
        ReplenishMana = 1836085825,
        /// <summary>Resistant skin ('Arsk').</summary>
        ResistantSkin = 1802728001,
        /// <summary>Resistant skin creep ('ACrk').</summary>
        ResistantSkinCreep = 1802650433,
        /// <summary>Resistant skin 3 1 pos creep ('ACsk').</summary>
        ResistantSkin31PosCreep = 1802715969,
        /// <summary>Restoration ('Arst').</summary>
        Restoration = 1953722945,
        /// <summary>Return gold ('Argd').</summary>
        ReturnGold = 1684501057,
        /// <summary>Return gold lumber ('Argl').</summary>
        ReturnGoldLumber = 1818718785,
        /// <summary>Return lumber ('Arlm').</summary>
        ReturnLumber = 1835823681,
        /// <summary>Reveal arcane tower ('AHta').</summary>
        RevealArcaneTower = 1635010625,
        /// <summary>Revenge ('Arng').</summary>
        Revenge = 1735291457,
        /// <summary>Revive ('Arev').</summary>
        Revive = 1986359873,
        /// <summary>Roar ('Aroa').</summary>
        Roar_Aroa = 1634693697,
        /// <summary>Roar ('Ara2').</summary>
        Roar_Ara2 = 845247041,
        /// <summary>Roar creep skeletal orc ('ACr1').</summary>
        RoarCreepSkeletalOrc = 829571905,
        /// <summary>Roar creep ('ACro').</summary>
        RoarCreep = 1869759297,
        /// <summary>Rocket attack ('Aroc').</summary>
        RocketAttack = 1668248129,
        /// <summary>Root ancients ('Aro1').</summary>
        RootAncients = 829387329,
        /// <summary>Root ancient protector ('Aro2').</summary>
        RootAncientProtector = 846164545,
        /// <summary>Sacrifice sacrificial pit ('Asac').</summary>
        SacrificeSacrificialPit = 1667330881,
        /// <summary>Pillage ('Asal').</summary>
        Pillage = 1818325825,
        /// <summary>Sacrifice acolyte ('Alam').</summary>
        SacrificeAcolyte = 1835101249,
        /// <summary>Searing arrows creep ('ACsa').</summary>
        SearingArrowsCreep = 1634943809,
        /// <summary>Self destruct ('Asds').</summary>
        SelfDestruct = 1935962945,
        /// <summary>Self destruct clockwerk goblins ('Asdg').</summary>
        SelfDestructClockwerkGoblins = 1734636353,
        /// <summary>Self destruct 2 clockwerk goblins ('Asd2').</summary>
        SelfDestruct2ClockwerkGoblins = 845443905,
        /// <summary>Self destruct 3 clockwerk goblins ('Asd3').</summary>
        SelfDestruct3ClockwerkGoblins = 862221121,
        /// <summary>Sell item ('Asid').</summary>
        SellItem = 1684632385,
        /// <summary>Sell unit ('Asud').</summary>
        SellUnit = 1685418817,
        /// <summary>Sentinel ('Aesn').</summary>
        Sentinel = 1853056321,
        /// <summary>Sentinel no research ('Aesr').</summary>
        SentinelNoResearch = 1920165185,
        /// <summary>Sentry ward ('Aeye').</summary>
        SentryWard = 1702454593,
        /// <summary>Serpent ward tentacle forgotten one ('ACtn').</summary>
        SerpentWardTentacleForgottenOne = 1853113153,
        /// <summary>Shadow meld ('Ashm').</summary>
        ShadowMeld = 1835561793,
        /// <summary>Shadow meld item ('AIhm').</summary>
        ShadowMeldItem = 1835551041,
        /// <summary>Shadow meld instant ('Sshm').</summary>
        ShadowMeldInstant = 1835561811,
        /// <summary>Shadow meld akama ('Ahid').</summary>
        ShadowMeldAkama = 1684629569,
        /// <summary>Shadow strike creep ('ACss').</summary>
        ShadowStrikeCreep = 1936933697,
        /// <summary>Shockwave creep ('ACsh').</summary>
        ShockwaveCreep = 1752384321,
        /// <summary>Shockwave trap ('ACst').</summary>
        ShockwaveTrap = 1953710913,
        /// <summary>Garithos shock wave ('ANsh').</summary>
        GarithosShockWave = 1752387137,
        /// <summary>Silence creep ('ACsi').</summary>
        SilenceCreep = 1769161537,
        /// <summary>Siphon mana creep ('ACsm').</summary>
        SiphonManaCreep = 1836270401,
        /// <summary>Sleep creep ('ACsl').</summary>
        SleepCreep = 1819493185,
        /// <summary>Sleep always ('Asla').</summary>
        SleepAlways = 1634497345,
        /// <summary>Slow ('Aslo').</summary>
        Slow_Aslo = 1869378369,
        /// <summary>Slow creep ('ACsw').</summary>
        SlowCreep = 2004042561,
        /// <summary>Slow poison ('Aspo').</summary>
        SlowPoison = 1869640513,
        /// <summary>Spawn skeleton ('Asod').</summary>
        SpawnSkeleton = 1685025601,
        /// <summary>Spawn spiderling ('Assp').</summary>
        SpawnSpiderling = 1886614337,
        /// <summary>Spawn spider ('Aspd').</summary>
        SpawnSpider = 1685091137,
        /// <summary>Spawn hydra ('Aspy').</summary>
        SpawnHydra = 2037412673,
        /// <summary>Spawn hydra hatchling ('Aspt').</summary>
        SpawnHydraHatchling = 1953526593,
        /// <summary>Spell steal ('Asps').</summary>
        SpellSteal = 1936749377,
        /// <summary>Sphere ('Asph').</summary>
        Sphere = 1752200001,
        /// <summary>Sphere so v level 1 ('Asp1').</summary>
        SphereSoVLevel1 = 829453121,
        /// <summary>Sphere so v level 2 ('Asp2').</summary>
        SphereSoVLevel2 = 846230337,
        /// <summary>Sphere so v level 3 ('Asp3').</summary>
        SphereSoVLevel3 = 863007553,
        /// <summary>Sphere so v level 4 ('Asp4').</summary>
        SphereSoVLevel4 = 879784769,
        /// <summary>Sphere so v level 5 ('Asp5').</summary>
        SphereSoVLevel5 = 896561985,
        /// <summary>Sphere so v level 6 ('Asp6').</summary>
        SphereSoVLevel6 = 913339201,
        /// <summary>Spider attack ('Aspa').</summary>
        SpiderAttack = 1634759489,
        /// <summary>Spiked barricades ('Aspi').</summary>
        SpikedBarricades = 1768977217,
        /// <summary>Spirit link ('Aspl').</summary>
        SpiritLink = 1819308865,
        /// <summary>Stand down ('Astd').</summary>
        StandDown = 1685353281,
        /// <summary>Stasis trap ('Asta').</summary>
        StasisTrap = 1635021633,
        /// <summary>Stone form ('Astn').</summary>
        StoneForm = 1853125441,
        /// <summary>Storm hammers ('Asth').</summary>
        StormHammers = 1752462145,
        /// <summary>Submerge myrmidon ('Asb1').</summary>
        SubmergeMyrmidon = 828535617,
        /// <summary>Submerge royal guard ('Asb2').</summary>
        SubmergeRoyalGuard = 845312833,
        /// <summary>Submerge snap dragon ('Asb3').</summary>
        SubmergeSnapDragon = 862090049,
        /// <summary>Summon lobstrok prawns ('Aslp').</summary>
        SummonLobstrokPrawns = 1886155585,
        /// <summary>Summon sea elemental ('ACwe').</summary>
        SummonSeaElemental = 1702314817,
        /// <summary>Tank turret ('Attu').</summary>
        TankTurret = 1970566209,
        /// <summary>Tank upgrade ('Srtt').</summary>
        TankUpgrade = 1953788499,
        /// <summary>Taunt ('Atau').</summary>
        Taunt = 1969321025,
        /// <summary>Taunt creep ('ANta').</summary>
        TauntCreep = 1635012161,
        /// <summary>Thorny shield creep ('ANth').</summary>
        ThornyShieldCreep = 1752452673,
        /// <summary>Thorny shield dragon turtle ('ANt2').</summary>
        ThornyShieldDragonTurtle = 846483009,
        /// <summary>Thorns aura creep ('ACah').</summary>
        ThornsAuraCreep = 1751204673,
        /// <summary>Thunder bolt creep ('ACtb').</summary>
        ThunderBoltCreep = 1651786561,
        /// <summary>Thunder clap creep ('ACtc').</summary>
        ThunderClapCreep = 1668563777,
        /// <summary>Thunder clap thunder lizard ('ACt2').</summary>
        ThunderClapThunderLizard = 846480193,
        /// <summary>Tornado damage ('Atdg').</summary>
        TornadoDamage = 1734636609,
        /// <summary>Tornado spin ('Atsp').</summary>
        TornadoSpin = 1886614593,
        /// <summary>Tornado wander ('Atwa').</summary>
        TornadoWander = 1635218497,
        /// <summary>Tree of life for attaching art ('Atol').</summary>
        TreeOfLifeForAttachingArt = 1819243585,
        /// <summary>Ultravision ('Ault').</summary>
        Ultravision = 1953264961,
        /// <summary>Unholy aura creep ('ACua').</summary>
        UnholyAuraCreep = 1635074881,
        /// <summary>Unholy frenzy ('Auhf').</summary>
        UnholyFrenzy = 1718121793,
        /// <summary>Unholy frenzy warlock ('Suhf').</summary>
        UnholyFrenzyWarlock = 1718121811,
        /// <summary>Unholy frenzy creep ('ACuf').</summary>
        UnholyFrenzyCreep = 1718960961,
        /// <summary>Incite unholy frenzy ('Auuf').</summary>
        InciteUnholyFrenzy = 1718973761,
        /// <summary>Unstable concoction ('Auco').</summary>
        UnstableConcoction = 1868789057,
        /// <summary>Unsummon ('Auns').</summary>
        Unsummon = 1936618817,
        /// <summary>Vampiric attack ('SCva').</summary>
        VampiricAttack_SCva = 1635140435,
        /// <summary>Vampiric aura creep ('ACvp').</summary>
        VampiricAuraCreep = 1886798657,
        /// <summary>Vengeance ('Avng').</summary>
        Vengeance = 1735292481,
        /// <summary>Wander ('Awan').</summary>
        Wander = 1851881281,
        /// <summary>War stomp creep ('Awrs').</summary>
        WarStompCreep = 1936881473,
        /// <summary>War stomp sea giant ('Awrg').</summary>
        WarStompSeaGiant = 1735554881,
        /// <summary>War stomp hydra ('Awrh').</summary>
        WarStompHydra = 1752332097,
        /// <summary>Wind walk ('ANwk').</summary>
        WindWalk = 1802980929,
        /// <summary>Wisp harvest ('Awha').</summary>
        WispHarvest = 1634236225,
        /// <summary>Wisp harvest invulnerable ('Awh2').</summary>
        WispHarvestInvulnerable = 845707073,
        /// <summary>Venom spears ('Aven').</summary>
        VenomSpears = 1852143169,
        /// <summary>Venom spears creep ('ACvs').</summary>
        VenomSpearsCreep = 1937130305,
        /// <summary>Warp ('Awrp').</summary>
        Warp = 1886549825,
        /// <summary>Web ('Aweb').</summary>
        Web = 1650816833,
        /// <summary>Web creep ('ACwb').</summary>
        WebCreep = 1651983169,
        /// <summary>Agility bonus 1 ('AIa1').</summary>
        AgilityBonus1 = 828459329,
        /// <summary>Agility bonus 2 ('AIa2').</summary>
        AgilityBonus2 = 845236545,
        /// <summary>Agility bonus 3 ('AIa3').</summary>
        AgilityBonus3 = 862013761,
        /// <summary>Agility bonus 4 ('AIa4').</summary>
        AgilityBonus4 = 878790977,
        /// <summary>Agility bonus 5 ('AIa5').</summary>
        AgilityBonus5 = 895568193,
        /// <summary>Agility bonus 6 ('AIa6').</summary>
        AgilityBonus6 = 912345409,
        /// <summary>Crown of kings all 5 ('AIx5').</summary>
        CrownOfKingsAll5 = 897075521,
        /// <summary>All 1 ('AIx1').</summary>
        All1 = 829966657,
        /// <summary>All 2 ('AIx2').</summary>
        All2 = 846743873,
        /// <summary>Strength bonus 1 ('AIs1').</summary>
        StrengthBonus1 = 829638977,
        /// <summary>Strength bonus 2 ('AIs2').</summary>
        StrengthBonus2 = 846416193,
        /// <summary>Strength bonus 3 ('AIs3').</summary>
        StrengthBonus3 = 863193409,
        /// <summary>Strength bonus 4 ('AIs4').</summary>
        StrengthBonus4 = 879970625,
        /// <summary>Strength bonus 5 ('AIs5').</summary>
        StrengthBonus5 = 896747841,
        /// <summary>Strength bonus 6 ('AIs6').</summary>
        StrengthBonus6 = 913525057,
        /// <summary>Intelligence bonus 1 ('AIi1').</summary>
        IntelligenceBonus1 = 828983617,
        /// <summary>Intelligence bonus 2 ('AIi2').</summary>
        IntelligenceBonus2 = 845760833,
        /// <summary>Intelligence bonus 3 ('AIi3').</summary>
        IntelligenceBonus3 = 862538049,
        /// <summary>Intelligence bonus 4 ('AIi4').</summary>
        IntelligenceBonus4 = 879315265,
        /// <summary>Intelligence bonus 5 ('AIi5').</summary>
        IntelligenceBonus5 = 896092481,
        /// <summary>Intelligence bonus 6 ('AIi6').</summary>
        IntelligenceBonus6 = 912869697,
        /// <summary>Reassignable attribute bonus 1 ('AIvm').</summary>
        ReassignableAttributeBonus1 = 1836468545,
        /// <summary>Permanent all 1 ('AIxm').</summary>
        PermanentAll1 = 1836599617,
        /// <summary>Agility mod ('AIam').</summary>
        AgilityMod = 1835092289,
        /// <summary>Intelligence mod ('AIim').</summary>
        IntelligenceMod = 1835616577,
        /// <summary>Strength mod ('AIsm').</summary>
        StrengthMod = 1836271937,
        /// <summary>Agility mod 2 ('AIgm').</summary>
        AgilityMod2 = 1835485505,
        /// <summary>Intelligence mod 2 ('AItm').</summary>
        IntelligenceMod2 = 1836337473,
        /// <summary>Strength mod 2 ('AInm').</summary>
        StrengthMod2 = 1835944257,
        /// <summary>Attack mod ('AIaa').</summary>
        AttackMod = 1633765697,
        /// <summary>Attack bonus ('AIat').</summary>
        AttackBonus_AIat = 1952532801,
        /// <summary>Attack bonus ('AIt6').</summary>
        AttackBonus_AIt6 = 913590593,
        /// <summary>Attack bonus ('AIt9').</summary>
        AttackBonus_AIt9 = 963922241,
        /// <summary>Attack bonus ('AItc').</summary>
        AttackBonus_AItc = 1668565313,
        /// <summary>Attack bonus ('AItf').</summary>
        AttackBonus_AItf = 1718896961,
        /// <summary>Attack bonus 1 ('AItg').</summary>
        AttackBonus1 = 1735674177,
        /// <summary>Attack bonus 2 ('AIth').</summary>
        AttackBonus2 = 1752451393,
        /// <summary>Attack bonus 4 ('AIti').</summary>
        AttackBonus4 = 1769228609,
        /// <summary>Attack bonus 5 ('AItj').</summary>
        AttackBonus5 = 1786005825,
        /// <summary>Attack bonus 7 ('AItk').</summary>
        AttackBonus7 = 1802783041,
        /// <summary>Attack bonus 8 ('AItl').</summary>
        AttackBonus8 = 1819560257,
        /// <summary>Attack bonus 10 ('AItn').</summary>
        AttackBonus10 = 1853114689,
        /// <summary>Vampiric attack ('AIva').</summary>
        VampiricAttack_AIva = 1635141953,
        /// <summary>Blink item ('AIbk').</summary>
        BlinkItem = 1801603393,
        /// <summary>Build tiny castle ('AIbl').</summary>
        BuildTinyCastle = 1818380609,
        /// <summary>Build tiny great hall ('AIbg').</summary>
        BuildTinyGreatHall = 1734494529,
        /// <summary>Build tiny scout tower ('AIbt').</summary>
        BuildTinyScoutTower = 1952598337,
        /// <summary>Build tiny blacksmith ('AIbb').</summary>
        BuildTinyBlacksmith = 1650608449,
        /// <summary>Build tiny farm ('AIbf').</summary>
        BuildTinyFarm = 1717717313,
        /// <summary>Build tiny lumber mill ('AIbr').</summary>
        BuildTinyLumberMill = 1919043905,
        /// <summary>Build tiny barracks ('AIbs').</summary>
        BuildTinyBarracks = 1935821121,
        /// <summary>Build tiny altar ('AIbh').</summary>
        BuildTinyAltar = 1751271745,
        /// <summary>Cyclone ('AIcy').</summary>
        Cyclone_AIcy = 2036549953,
        /// <summary>Defense bonus 1 ('AId1').</summary>
        DefenseBonus1 = 828655937,
        /// <summary>Defense bonus 2 ('AId2').</summary>
        DefenseBonus2 = 845433153,
        /// <summary>Defense bonus 3 ('AId3').</summary>
        DefenseBonus3 = 862210369,
        /// <summary>Defense bonus 4 ('AId4').</summary>
        DefenseBonus4 = 878987585,
        /// <summary>Defense bonus 5 ('AId5').</summary>
        DefenseBonus5 = 895764801,
        /// <summary>Fortification glyph ('AIgf').</summary>
        FortificationGlyph = 1718044993,
        /// <summary>Ultra vision glyph ('AIgu').</summary>
        UltraVisionGlyph = 1969703233,
        /// <summary>Experience mod ('AIem').</summary>
        ExperienceMod = 1835354433,
        /// <summary>Experience mod greater ('AIe2').</summary>
        ExperienceModGreater = 845498689,
        /// <summary>Figurine red drake ('AIfd').</summary>
        FigurineRedDrake = 1684425025,
        /// <summary>Figurine furbolg ('AIff').</summary>
        FigurineFurbolg = 1717979457,
        /// <summary>Figurine rock golem ('AIfr').</summary>
        FigurineRockGolem = 1919306049,
        /// <summary>Figurine doom guard ('AIfu').</summary>
        FigurineDoomGuard = 1969637697,
        /// <summary>Figurine fel hound ('AIfh').</summary>
        FigurineFelHound = 1751533889,
        /// <summary>Figurine skeleton ('AIfs').</summary>
        FigurineSkeleton = 1936083265,
        /// <summary>Figurine ice revenant ('AIir').</summary>
        FigurineIceRevenant = 1919502657,
        /// <summary>Figurine ursa warrior ('AIuw').</summary>
        FigurineUrsaWarrior = 2004175169,
        /// <summary>Flag ('AIfl').</summary>
        Flag = 1818642753,
        /// <summary>Flag human ('AIfm').</summary>
        FlagHuman = 1835419969,
        /// <summary>Flag orc ('AIfo').</summary>
        FlagOrc = 1868974401,
        /// <summary>Flag night elf ('AIfn').</summary>
        FlagNightElf = 1852197185,
        /// <summary>Flag undead ('AIfe').</summary>
        FlagUndead = 1701202241,
        /// <summary>Flag orc battle standard ('AIfx').</summary>
        FlagOrcBattleStandard = 2019969345,
        /// <summary>Flare gun ('AIfa').</summary>
        FlareGun = 1634093377,
        /// <summary>Item inferno ('AIin').</summary>
        ItemInferno = 1852393793,
        /// <summary>Level mod ('AIlm').</summary>
        LevelMod = 1835813185,
        /// <summary>Lightning purge ('AIlp').</summary>
        LightningPurge = 1886144833,
        /// <summary>Max life bonus least ('AIlf').</summary>
        MaxLifeBonusLeast = 1718372673,
        /// <summary>Max life bonus lesser ('AIl1').</summary>
        MaxLifeBonusLesser = 829180225,
        /// <summary>Max life bonus greater ('AIl2').</summary>
        MaxLifeBonusGreater = 845957441,
        /// <summary>Move speed bonus ('AIms').</summary>
        MoveSpeedBonus = 1936542017,
        /// <summary>Orb of darkness black arrow ('ANbs').</summary>
        OrbOfDarknessBlackArrow = 1935822401,
        /// <summary>Orb of darkness ('AIdf').</summary>
        OrbOfDarkness = 1717848385,
        /// <summary>Orb of corruption ('AIcb').</summary>
        OrbOfCorruption = 1650673985,
        /// <summary>Shadow orb ability ('AIdn').</summary>
        ShadowOrbAbility = 1852066113,
        /// <summary>Orb of fire ('AIfb').</summary>
        OrbOfFire = 1650870593,
        /// <summary>Orb of guldan ('AIgd').</summary>
        OrbOfGuldan = 1684490561,
        /// <summary>Orb of freezing ('AIzb').</summary>
        OrbOfFreezing = 1652181313,
        /// <summary>Orb of frost ('AIob').</summary>
        OrbOfFrost = 1651460417,
        /// <summary>Orb of lightning ('AIll').</summary>
        OrbOfLightning = 1819035969,
        /// <summary>Orb of lightning old ('AIlb').</summary>
        OrbOfLightningOld = 1651263809,
        /// <summary>Orb of spells ('AIsb').</summary>
        OrbOfSpells = 1651722561,
        /// <summary>Orb of venom ('AIpb').</summary>
        OrbOfVenom = 1651525953,
        /// <summary>Orb of venom poison attack ('Apo2').</summary>
        OrbOfVenomPoisonAttack = 846164033,
        /// <summary>Animate dead item special ('AInd').</summary>
        AnimateDeadItemSpecial = 1684949313,
        /// <summary>Regen life ('Arel').</summary>
        RegenLife_Arel = 1818587713,
        /// <summary>Regen life ('Arll').</summary>
        RegenLife_Arll = 1819046465,
        /// <summary>Sight bonus ('AIsi').</summary>
        SightBonus = 1769163073,
        /// <summary>Slow ('AIos').</summary>
        Slow_AIos = 1936673089,
        /// <summary>Soul trap ('AIso').</summary>
        SoulTrap = 1869826369,
        /// <summary>Soul possession ('Asou').</summary>
        SoulPossession = 1970238273,
        /// <summary>Item cloak of flames ('AIcf').</summary>
        ItemCloakOfFlames = 1717782849,
        /// <summary>Item command ('AIco').</summary>
        ItemCommand = 1868777793,
        /// <summary>Item damage aoe ('AIdm').</summary>
        ItemDamageAoe = 1835288897,
        /// <summary>Item defense aoe ('AIda').</summary>
        ItemDefenseAoe = 1633962305,
        /// <summary>Item defense aoe healing ('AIdb').</summary>
        ItemDefenseAoeHealing = 1650739521,
        /// <summary>Item detect aoe ('AIta').</summary>
        ItemDetectAoe = 1635010881,
        /// <summary>Item dispel aoe ('AIdi').</summary>
        ItemDispelAoe = 1768180033,
        /// <summary>Item dispel aoe with cooldown ('AIds').</summary>
        ItemDispelAoeWithCooldown = 1935952193,
        /// <summary>Powerup dispel aoe ('APdi').</summary>
        PowerupDispelAoe = 1768181825,
        /// <summary>Item heal lesser ('AIh1').</summary>
        ItemHealLesser = 828918081,
        /// <summary>Item heal greater ('AIh2').</summary>
        ItemHealGreater = 845695297,
        /// <summary>Item heal least ('AIh3').</summary>
        ItemHealLeast = 862472513,
        /// <summary>Item heal aoe ('AIha').</summary>
        ItemHealAoe = 1634224449,
        /// <summary>Item heal aoe greater ('AIhb').</summary>
        ItemHealAoeGreater = 1651001665,
        /// <summary>Powerup heal aoe lesser ('APh1').</summary>
        PowerupHealAoeLesser = 828919873,
        /// <summary>Powerup heal aoe ('APh2').</summary>
        PowerupHealAoe = 845697089,
        /// <summary>Powerup heal aoe greater ('APh3').</summary>
        PowerupHealAoeGreater = 862474305,
        /// <summary>Healing ward ('AIhw').</summary>
        HealingWard_AIhw = 2003323201,
        /// <summary>Sentry ward item ('AIsw').</summary>
        SentryWardItem = 2004044097,
        /// <summary>Item illusion ('AIil').</summary>
        ItemIllusion = 1818839361,
        /// <summary>Item invis lesser ('AIv1').</summary>
        ItemInvisLesser = 829835585,
        /// <summary>Item invis greater ('AIv2').</summary>
        ItemInvisGreater = 846612801,
        /// <summary>Item invul normal ('AIvu').</summary>
        ItemInvulNormal = 1970686273,
        /// <summary>Item invul lesser ('AIvl').</summary>
        ItemInvulLesser = 1819691329,
        /// <summary>Item invul divinity ('AIvg').</summary>
        ItemInvulDivinity = 1735805249,
        /// <summary>Item mana restore lesser ('AIm1').</summary>
        ItemManaRestoreLesser = 829245761,
        /// <summary>Item mana restore greater ('AIm2').</summary>
        ItemManaRestoreGreater = 846022977,
        /// <summary>Item mana restore aoe ('AImr').</summary>
        ItemManaRestoreAoe = 1919764801,
        /// <summary>Rune mana restore aoe ('APmr').</summary>
        RuneManaRestoreAoe = 1919766593,
        /// <summary>Rune mana restore greater aoe ('APmg').</summary>
        RuneManaRestoreGreaterAoe = 1735217217,
        /// <summary>Item place mine ('AIpm').</summary>
        ItemPlaceMine = 1836075329,
        /// <summary>Item recall ('AIrt').</summary>
        ItemRecall = 1953646913,
        /// <summary>Item regen mana ('AIrm').</summary>
        ItemRegenMana = 1836206401,
        /// <summary>Item regen mana lesser ('AIrn').</summary>
        ItemRegenManaLesser = 1852983617,
        /// <summary>Item reincarnation ('AIrc').</summary>
        ItemReincarnation = 1668434241,
        /// <summary>Item restore ('AIre').</summary>
        ItemRestore = 1701988673,
        /// <summary>Item restore aoe ('AIra').</summary>
        ItemRestoreAoe = 1634879809,
        /// <summary>Rune restore aoe ('APra').</summary>
        RuneRestoreAoe = 1634881601,
        /// <summary>Item speed ('AIsp').</summary>
        ItemSpeed = 1886603585,
        /// <summary>Item speed aoe ('AIsa').</summary>
        ItemSpeedAoe = 1634945345,
        /// <summary>Rune speed aoe ('APsa').</summary>
        RuneSpeedAoe = 1634947137,
        /// <summary>Item town portal ('AItp').</summary>
        ItemTownPortal = 1886669121,
        /// <summary>Item aura devotion ('AIad').</summary>
        ItemAuraDevotion = 1684097345,
        /// <summary>Item aura command ('AIcd').</summary>
        ItemAuraCommand = 1684228417,
        /// <summary>Item aura war drums ('AIwd').</summary>
        ItemAuraWarDrums = 1685539137,
        /// <summary>Item aura brilliance ('AIba').</summary>
        ItemAuraBrilliance = 1633831233,
        /// <summary>Item aura vampiric ('AIav').</summary>
        ItemAuraVampiric = 1986087233,
        /// <summary>Item aura trueshot ('AIar').</summary>
        ItemAuraTrueshot = 1918978369,
        /// <summary>Item aura endurance ('AIae').</summary>
        ItemAuraEndurance = 1700874561,
        /// <summary>Item aura unholy ('AIau').</summary>
        ItemAuraUnholy = 1969310017,
        /// <summary>Item ultravision ('AIuv').</summary>
        ItemUltravision = 1987397953,
        /// <summary>Lightning shield item ('AIls').</summary>
        LightningShieldItem = 1936476481,
        /// <summary>Anti magic Shield ('AIxs').</summary>
        AntiMagicShield_AIxs = 1937262913,
        /// <summary>Animate dead ('AIan').</summary>
        AnimateDead = 1851869505,
        /// <summary>Resurrection ('AIrs').</summary>
        Resurrection = 1936869697,
        /// <summary>Roar ('AIrr').</summary>
        Roar_AIrr = 1920092481,
        /// <summary>Evasion ('AIev').</summary>
        Evasion = 1986349377,
        /// <summary>Magic immunity ('AImx').</summary>
        MagicImmunity_AImx = 2020428097,
        /// <summary>Permanent hit point bonus ('AImh').</summary>
        PermanentHitPointBonus = 1751992641,
        /// <summary>Max mana bonus least ('AImb').</summary>
        MaxManaBonusLeast = 1651329345,
        /// <summary>Max mana bonus most ('AIbm').</summary>
        MaxManaBonusMost = 1835157825,
        /// <summary>Attack speed increase ('AIsx').</summary>
        AttackSpeedIncrease = 2020821313,
        /// <summary>Potion of life regen ('AIrl').</summary>
        PotionOfLifeRegen = 1819429185,
        /// <summary>Potion of mana regen greater ('AIpr').</summary>
        PotionOfManaRegenGreater = 1919961409,
        /// <summary>Scroll of life regen ('AIsl').</summary>
        ScrollOfLifeRegen = 1819494721,
        /// <summary>Potion of mana regen lesser ('AIpl').</summary>
        PotionOfManaRegenLesser = 1819298113,
        /// <summary>Potion of rejuv I ('AIp1').</summary>
        PotionOfRejuvI = 829442369,
        /// <summary>Potion of rejuv II ('AIp2').</summary>
        PotionOfRejuvII = 846219585,
        /// <summary>Potion of rejuv III ('AIp3').</summary>
        PotionOfRejuvIII = 862996801,
        /// <summary>Potion of rejuv IV ('AIp4').</summary>
        PotionOfRejuvIV = 879774017,
        /// <summary>Scroll of rejuv I ('AIp5').</summary>
        ScrollOfRejuvI = 896551233,
        /// <summary>Scroll of rejuv II ('AIp6').</summary>
        ScrollOfRejuvII = 913328449,
        /// <summary>Give gold ('AIgo').</summary>
        GiveGold = 1869039937,
        /// <summary>Give lumber ('AIlu').</summary>
        GiveLumber = 1970030913,
        /// <summary>Item reveal map ('AIrv').</summary>
        ItemRevealMap = 1987201345,
        /// <summary>Item dispel chain ('AIdc').</summary>
        ItemDispelChain = 1667516737,
        /// <summary>Item web ('AIwb').</summary>
        ItemWeb = 1651984705,
        /// <summary>Item monster lure ('AImo').</summary>
        ItemMonsterLure = 1869433153,
        /// <summary>Item change TOD ('AIct').</summary>
        ItemChangeTOD = 1952663873,
        /// <summary>Item random item ('AIri').</summary>
        ItemRandomItem = 1769097537,
        /// <summary>Runed bracers ('AIsr').</summary>
        RunedBracers = 1920158017,
        /// <summary>Blight placement ('Ablp').</summary>
        BlightPlacement = 1886151233,
        /// <summary>Item potion vampirism ('AIpv').</summary>
        ItemPotionVampirism = 1987070273,
        /// <summary>Mana steal ('Aste').</summary>
        ManaSteal = 1702130497,
        /// <summary>Mechanical critter ('Amec').</summary>
        MechanicalCritter = 1667591489,
        /// <summary>Shadow sight ('Ashs').</summary>
        ShadowSight = 1936225089,
        /// <summary>Preservation ('ANpr').</summary>
        Preservation = 1919962689,
        /// <summary>Sanctuary ('ANsa').</summary>
        Sanctuary = 1634946625,
        /// <summary>Spell shield ('ANss').</summary>
        SpellShield = 1936936513,
        /// <summary>Spell shield AOE ('ANse').</summary>
        SpellShieldAOE = 1702055489,
        /// <summary>Retrain ('Aret').</summary>
        Retrain = 1952805441,
        /// <summary>Staff o teleportation ('AImt').</summary>
        StaffOTeleportation = 1953319233,
        /// <summary>Spell book ('Aspb').</summary>
        SpellBook = 1651536705,
        /// <summary>Raise dead item ('AIrd').</summary>
        RaiseDeadItem = 1685211457,
        /// <summary>Dust of appearance ('AItb').</summary>
        DustOfAppearance = 1651788097,
        /// <summary>Divine shield item ('AIdv').</summary>
        DivineShieldItem = 1986283841,
        /// <summary>Silence item ('AIse').</summary>
        SilenceItem = 1702054209,
        /// <summary>Purge orb ('AIpg').</summary>
        PurgeOrb = 1735412033,
        /// <summary>Purge totem SP ('AIps').</summary>
        PurgeTotemSP = 1936738625,
        /// <summary>Cloud of fog item ('AIfg').</summary>
        CloudOfFogItem = 1734756673,
        /// <summary>Rune of lesser resurrection ('APrl').</summary>
        RuneOfLesserResurrection = 1819430977,
        /// <summary>Rune of greater resurrection ('APrr').</summary>
        RuneOfGreaterResurrection = 1920094273,
        /// <summary>Rune of rebirth ('AIrb').</summary>
        RuneOfRebirth = 1651657025,
        /// <summary>Rune of spirit link ('Aspp').</summary>
        RuneOfSpiritLink = 1886417729,
        /// <summary>Dark summoning ('AUds').</summary>
        DarkSummoning = 1935955265,
        /// <summary>Rune of the watcher ('APwt').</summary>
        RuneOfTheWatcher = 1953976385,
        /// <summary>Unholy frenzy item ('AIuf').</summary>
        UnholyFrenzyItem = 1718962497,
        /// <summary>Defense bonus 10 ('AId0').</summary>
        DefenseBonus10 = 811878721,
        /// <summary>Control magic item ('AIcm').</summary>
        ControlMagicItem = 1835223361,
        /// <summary>Max mana bonus leastest ('AImz').</summary>
        MaxManaBonusLeastest = 2053982529,
        /// <summary>Finger of death item ('AIfz').</summary>
        FingerOfDeathItem = 2053523777,
        /// <summary>Death pact item ('AIdp').</summary>
        DeathPactItem = 1885620545,
        /// <summary>Max mana bonus leastest really ('AImv').</summary>
        MaxManaBonusLeastestReally = 1986873665,
        /// <summary>Permanent hit point bonus small ('AIpx').</summary>
        PermanentHitPointBonusSmall = 2020624705,
        /// <summary>Defend item ('AIdd').</summary>
        DefendItem = 1684293953,
        /// <summary>Defense bonus 8 ('AId8').</summary>
        DefenseBonus8 = 946096449,
        /// <summary>Defense bonus 7 ('AId7').</summary>
        DefenseBonus7 = 929319233,
        /// <summary>Max life bonus leastest ('AIlz').</summary>
        MaxLifeBonusLeastest = 2053916993,
        /// <summary>Item heal leastest ('AIhx').</summary>
        ItemHealLeastest = 2020100417,
        /// <summary>Agility bonus 10 ('AIaz').</summary>
        AgilityBonus10 = 2053196097,
        /// <summary>Resurrection item ('AIrx').</summary>
        ResurrectionItem = 2020755777,
        /// <summary>Bash item ('AIbx').</summary>
        BashItem = 2019707201,
        /// <summary>Attack bonus 20 ('AItx').</summary>
        AttackBonus20 = 2020886849,
        /// <summary>Watery minion item ('AIwm').</summary>
        WateryMinionItem = 1836534081,
        /// <summary>Summon headhunter item ('AIsh').</summary>
        SummonHeadhunterItem = 1752385857,
        /// <summary>200 mana bonus ('AI2m').</summary>
        _200ManaBonus = 1832012097,
        /// <summary>Aura regeneration item ('AIgx').</summary>
        AuraRegenerationItem = 2020034881,
        /// <summary>Holy light item ('AIhl').</summary>
        HolyLightItem = 1818773825,
        /// <summary>Slow poison item ('AIsz').</summary>
        SlowPoisonItem = 2054375745,
        /// <summary>Penguin squeek ('AIpz').</summary>
        PenguinSqueek = 2054179137,
        /// <summary>Searing blade fire melee ('AIfw').</summary>
        SearingBladeFireMelee = 2003192129,
        /// <summary>Frostguard frost melee ('AIft').</summary>
        FrostguardFrostMelee = 1952860481,
        /// <summary>Shaman claws lightning melee ('AIlx').</summary>
        ShamanClawsLightningMelee = 2020362561,
        /// <summary>Critical strike item ('AIcs').</summary>
        CriticalStrikeItem = 1935886657,
        /// <summary>Chain lightning item ('AIcl').</summary>
        ChainLightningItem = 1818446145,
        /// <summary>All 3 ('AIx3').</summary>
        All3 = 863521089,
        /// <summary>All 4 ('AIx4').</summary>
        All4 = 880298305,
        /// <summary>Beserk item ('AIxk').</summary>
        BeserkItem = 1803045185,
        /// <summary>Item ritual dagger instant ('AIdg').</summary>
        ItemRitualDaggerInstant = 1734625601,
        /// <summary>Item ritual dagger regen ('AIg2').</summary>
        ItemRitualDaggerRegen = 845629761,
        /// <summary>Orb of fire v 2 ('AIf2').</summary>
        OrbOfFireV2 = 845564225,
        /// <summary>Sundering blades ('Ahsb').</summary>
        SunderingBlades = 1651730497,
        /// <summary>Passive simple ('APai').</summary>
        PassiveSimple = 1767985217,
        /// <summary>Passive human rifleman plus range rhri ('Ahri').</summary>
        PassiveHumanRiflemanPlusRangeRhri = 1769105473,
        /// <summary>Passive human animal breeding rhan ('Ahan').</summary>
        PassiveHumanAnimalBreedingRhan = 1851877441,
        /// <summary>Passive phoenix fire and egg ('Ahpe').</summary>
        PassivePhoenixFireAndEgg = 1701865537,
        /// <summary>Passive human lumber harvesting rhlh ('Ahlh').</summary>
        PassiveHumanLumberHarvestingRhlh = 1751935041,
        /// <summary>Passive orc grunt berserk robs ('Aobs').</summary>
        PassiveOrcGruntBerserkRobs = 1935830849,
        /// <summary>Passive orc berserkers robk ('Aobk').</summary>
        PassiveOrcBerserkersRobk = 1801613121,
        /// <summary>Passive orc reinforced defense rorb ('Aorb').</summary>
        PassiveOrcReinforcedDefenseRorb = 1651666753,
        /// <summary>Passive orc spiked barricade rosp ('Aosp').</summary>
        PassiveOrcSpikedBarricadeRosp = 1886613313,
        /// <summary>Passive orc ghost icon only orc aeth unused ('Aoth').</summary>
        PassiveOrcGhostIconOnlyOrcAethUnused = 1752461121,
        /// <summary>Passive orc troll regeneration rotr ('Aotr').</summary>
        PassiveOrcTrollRegenerationRotr = 1920233281,
        /// <summary>Passive undead ghoul frenzy rugf ('Augf').</summary>
        PassiveUndeadGhoulFrenzyRugf = 1718056257,
        /// <summary>Passive ghost icon only undead agho ('Augh').</summary>
        PassiveGhostIconOnlyUndeadAgho = 1751610689,
        /// <summary>Passive undead skeletal mastery rusm ('Ausm').</summary>
        PassiveUndeadSkeletalMasteryRusm = 1836283201,
        /// <summary>Passive nightelf improved bows reib ('Aeib').</summary>
        PassiveNightelfImprovedBowsReib = 1651074369,
        /// <summary>Passive nightelf marksmanship remk ('Aemk').</summary>
        PassiveNightelfMarksmanshipRemk = 1802331457,
        /// <summary>Passive nightelf well spring rews ('Aews').</summary>
        PassiveNightelfWellSpringRews = 1937204545,
        /// <summary>Figurine blue drake ('AIbd').</summary>
        FigurineBlueDrake = 1684162881,
        /// <summary>Figurine furbolg tracker ('AIut').</summary>
        FigurineFurbolgTracker = 1953843521,
        /// <summary>Figurine dragonspawn overseer ('AIes').</summary>
        FigurineDragonspawnOverseer = 1936017729,
        /// <summary>Item transmute ('AIts').</summary>
        ItemTransmute = 1937000769,
        /// <summary>Attack target priority ('Aatp').</summary>
        AttackTargetPriority = 1886675265
    }
}