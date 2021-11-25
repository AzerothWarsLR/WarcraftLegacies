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
    public enum DoodadType
    {
        /// <summary>Mushrooms ('APms').</summary>
        Mushrooms_APms = 1936543809,
        /// <summary>Hollow stump ('AOhs').</summary>
        HollowStump_AOhs = 1936215873,
        /// <summary>Thorny vines ('APtv').</summary>
        ThornyVines_APtv = 1987334209,
        /// <summary>Cattail ('APct').</summary>
        Cattail_APct = 1952665665,
        /// <summary>Birds ('AObd').</summary>
        Birds = 1684164417,
        /// <summary>Skull brazier ('AObr').</summary>
        SkullBrazier = 1919045441,
        /// <summary>Fish ('AWfs').</summary>
        Fish = 1936086849,
        /// <summary>Guardian statue of aszune ('AOgs').</summary>
        GuardianStatueOfAszune = 1936150337,
        /// <summary>Keeper statue ('AOks').</summary>
        KeeperStatue = 1936412481,
        /// <summary>Straight log ('AOlg').</summary>
        StraightLog_AOlg = 1735151425,
        /// <summary>Angled log ('AOla').</summary>
        AngledLog_AOla = 1634488129,
        /// <summary>Glowing obelisk ('AOob').</summary>
        GlowingObelisk = 1651461953,
        /// <summary>Obelisk ('AOsk').</summary>
        Obelisk_AOsk = 1802719041,
        /// <summary>Broken obelisk ('AObo').</summary>
        BrokenObelisk_AObo = 1868713793,
        /// <summary>Scorched remains ('AOsr').</summary>
        ScorchedRemains = 1920159553,
        /// <summary>Bush ('APbs').</summary>
        Bush_APbs = 1935822913,
        /// <summary>Lily pads ('AWlp').</summary>
        LilyPads = 1886148417,
        /// <summary>Floating lily pads ('AWfl').</summary>
        FloatingLilyPads_AWfl = 1818646337,
        /// <summary>Rocks ('ARrk').</summary>
        Rocks_ARrk = 1802654273,
        /// <summary>Broken column ('ASbc').</summary>
        BrokenColumn_ASbc = 1667388225,
        /// <summary>Black ruined rubble ('ASbr').</summary>
        BlackRuinedRubble_ASbr = 1919046465,
        /// <summary>Ruined blocks ('ASHB').</summary>
        RuinedBlocks_ASHB = 1112036161,
        /// <summary>Archway ('ASra').</summary>
        Archway_ASra = 1634882369,
        /// <summary>Archway ('ASr1').</summary>
        Archway_ASr1 = 829576001,
        /// <summary>World tree ('ASwt').</summary>
        WorldTree = 1953977153,
        /// <summary>Cactus ('BPca').</summary>
        Cactus = 1633898562,
        /// <summary>Bones ('BObo').</summary>
        Bones_BObo = 1868713794,
        /// <summary>Totem ('BOct').</summary>
        Totem_BOct = 1952665410,
        /// <summary>Throne ('BOth').</summary>
        Throne_BOth = 1752452930,
        /// <summary>Totem ('BOtt').</summary>
        Totem_BOtt = 1953779522,
        /// <summary>Crater ('BRcr').</summary>
        Crater = 1919111746,
        /// <summary>Fissure ('BRfs').</summary>
        Fissure_BRfs = 1936085570,
        /// <summary>Rocks ('BRrk').</summary>
        Rocks_BRrk = 1802654274,
        /// <summary>Pillar of rock ('BRrp').</summary>
        PillarOfRock = 1886540354,
        /// <summary>Rock spires ('BRrs').</summary>
        RockSpires_BRrs = 1936872002,
        /// <summary>Rock spires cinematic ('BRrc').</summary>
        RockSpiresCinematic = 1668436546,
        /// <summary>Small rock spires ('BRsp').</summary>
        SmallRockSpires_BRsp = 1886605890,
        /// <summary>Geyser ('BRgs').</summary>
        Geyser = 1936151106,
        /// <summary>Ruined arch ('BSar').</summary>
        RuinedArch = 1918980930,
        /// <summary>Archway ('BSra').</summary>
        Archway_BSra = 1634882370,
        /// <summary>Archway ('BSr1').</summary>
        Archway_BSr1 = 829576002,
        /// <summary>Ruined chunk ('BSrc').</summary>
        RuinedChunk = 1668436802,
        /// <summary>Ruined curved wall ('BSrv').</summary>
        RuinedCurvedWall = 1987203906,
        /// <summary>Ruined wall ('BSrw').</summary>
        RuinedWall = 2003981122,
        /// <summary>Blighted mist ('CObl').</summary>
        BlightedMist = 1818382147,
        /// <summary>Hollow stump ('COhs').</summary>
        HollowStump_COhs = 1936215875,
        /// <summary>Straight log ('COlg').</summary>
        StraightLog_COlg = 1735151427,
        /// <summary>Angled log ('COla').</summary>
        AngledLog_COla = 1634488131,
        /// <summary>Obelisk ('COob').</summary>
        Obelisk_COob = 1651461955,
        /// <summary>Broken obelisk ('CObo').</summary>
        BrokenObelisk_CObo = 1868713795,
        /// <summary>Bush ('CPbs').</summary>
        Bush_CPbs = 1935822915,
        /// <summary>Cattail ('CPct').</summary>
        Cattail_CPct = 1952665667,
        /// <summary>Mushrooms ('CPms').</summary>
        Mushrooms_CPms = 1936543811,
        /// <summary>Lily pad ('CPlp').</summary>
        LilyPad = 1886146627,
        /// <summary>Fissure ('CRfs').</summary>
        Fissure_CRfs = 1936085571,
        /// <summary>Rock spires ('CRrs').</summary>
        RockSpires_CRrs = 1936872003,
        /// <summary>Broken column ('CSbc').</summary>
        BrokenColumn_CSbc = 1667388227,
        /// <summary>Black ruined rubble ('CSbr').</summary>
        BlackRuinedRubble_CSbr = 1919046467,
        /// <summary>Ruined blocks ('CSbl').</summary>
        RuinedBlocks_CSbl = 1818383171,
        /// <summary>Archway ('CSra').</summary>
        Archway_CSra = 1634882371,
        /// <summary>Angled archway ('CSr1').</summary>
        AngledArchway_CSr1 = 829576003,
        /// <summary>Corn ('LPcr').</summary>
        Corn = 1919111244,
        /// <summary>Floating lily pads ('LPfp').</summary>
        FloatingLilyPads_LPfp = 1885753420,
        /// <summary>Lilly pad ('LPlp').</summary>
        LillyPad = 1886146636,
        /// <summary>River rushes ('LPrs').</summary>
        RiverRushes = 1936871500,
        /// <summary>Wheat bunch ('LPwb').</summary>
        WheatBunch = 1651986508,
        /// <summary>Wheat ('LPwh').</summary>
        Wheat = 1752649804,
        /// <summary>Scorched grain ('LPcw').</summary>
        ScorchedGrain = 2002997324,
        /// <summary>Archery target ('LOar').</summary>
        ArcheryTarget = 1918979916,
        /// <summary>Armor rack ('LOam').</summary>
        ArmorRack = 1835093836,
        /// <summary>Human banner ('LOh1').</summary>
        HumanBanner = 828919628,
        /// <summary>Orc banner ('LOo1').</summary>
        OrcBanner = 829378380,
        /// <summary>Tutorial orc banner ('LOo2').</summary>
        TutorialOrcBanner = 846155596,
        /// <summary>Brazier ('LObr').</summary>
        Brazier = 1919045452,
        /// <summary>Glowing brazier ('LObz').</summary>
        GlowingBrazier = 2053263180,
        /// <summary>Empty cage ('LOce').</summary>
        EmptyCage_LOce = 1701007180,
        /// <summary>Cauldron with heads ('LOca').</summary>
        CauldronWithHeads = 1633898316,
        /// <summary>Empty cage ('LOct').</summary>
        EmptyCage_LOct = 1952665420,
        /// <summary>Flies ('LOfl').</summary>
        Flies = 1818644300,
        /// <summary>Grave ('LOgr').</summary>
        Grave_LOgr = 1919373132,
        /// <summary>Hay ('LOhb').</summary>
        Hay = 1651003212,
        /// <summary>Hay cart ('LOch').</summary>
        HayCart = 1751338828,
        /// <summary>Broken hay cart ('LOcb').</summary>
        BrokenHayCart = 1650675532,
        /// <summary>Hay cart infected ('LOrc').</summary>
        HayCartInfected = 1668435788,
        /// <summary>Broken hay cart infected ('LOxx').</summary>
        BrokenHayCartInfected = 2021150540,
        /// <summary>Hay clump ('LOhc').</summary>
        HayClump = 1667780428,
        /// <summary>Head on spear ('LOsh').</summary>
        HeadOnSpear = 1752387404,
        /// <summary>Hitching post ('LOhp').</summary>
        HitchingPost = 1885884236,
        /// <summary>Impaled corpse ('LOic').</summary>
        ImpaledCorpse = 1667845964,
        /// <summary>Lantern post ('LOlp').</summary>
        LanternPost_LOlp = 1886146380,
        /// <summary>Peasant grave ('LOpg').</summary>
        PeasantGrave = 1735413580,
        /// <summary>Rib bones ('LOrb').</summary>
        RibBones = 1651658572,
        /// <summary>Hay infected ('LOrh').</summary>
        HayInfected = 1752321868,
        /// <summary>Sign post ('LOsp').</summary>
        SignPost = 1886605132,
        /// <summary>Sitting corpse ('LOsc').</summary>
        SittingCorpse = 1668501324,
        /// <summary>Skulls on stick ('LOss').</summary>
        SkullsOnStick = 1936936780,
        /// <summary>Skull pile ('LOsk').</summary>
        SkullPile = 1802719052,
        /// <summary>Smoke smudge ('LOsm').</summary>
        SmokeSmudge = 1836273484,
        /// <summary>Stone wall ('LOsw').</summary>
        StoneWall = 2004045644,
        /// <summary>Torch ('LOth').</summary>
        Torch = 1752452940,
        /// <summary>Glowing torch ('LOtz').</summary>
        GlowingTorch = 2054442828,
        /// <summary>Trash ('LOt1').</summary>
        Trash_LOt1 = 829706060,
        /// <summary>Trough ('LOtr').</summary>
        Trough = 1920225100,
        /// <summary>Wheelbarrel ('LOwb').</summary>
        Wheelbarrel = 1651986252,
        /// <summary>Broken wheelbarrel ('LOwr').</summary>
        BrokenWheelbarrel = 1920421708,
        /// <summary>Weapon rack ('LOwp').</summary>
        WeaponRack = 1886867276,
        /// <summary>Rocks ('LRrk').</summary>
        Rocks_LRrk = 1802654284,
        /// <summary>Barn ('LSba').</summary>
        Barn = 1633833804,
        /// <summary>Elven building ('LSeb').</summary>
        ElvenBuilding = 1650807628,
        /// <summary>Scorched barn ('LSsb').</summary>
        ScorchedBarn = 1651725132,
        /// <summary>Scorched farm ('LSsf').</summary>
        ScorchedFarm = 1718833996,
        /// <summary>Granary ('LSgr').</summary>
        Granary = 1919374156,
        /// <summary>Scorched granary ('LSgs').</summary>
        ScorchedGranary = 1936151372,
        /// <summary>Inn ('LSin').</summary>
        Inn = 1852396364,
        /// <summary>Rock archway ('LSra').</summary>
        RockArchway_LSra = 1634882380,
        /// <summary>Angled rock archway ('LSr1').</summary>
        AngledRockArchway_LSr1 = 829576012,
        /// <summary>Scorched inn ('LSsi').</summary>
        ScorchedInn = 1769165644,
        /// <summary>Scorched tower ('LSst').</summary>
        ScorchedTower = 1953715020,
        /// <summary>Well ('LSwl').</summary>
        Well = 1819759436,
        /// <summary>Burned wind mill ('LSwb').</summary>
        BurnedWindMill = 1651987276,
        /// <summary>Wind mill ('LSwm').</summary>
        WindMill = 1836536652,
        /// <summary>Broken column ('NObc').</summary>
        BrokenColumn_NObc = 1667387214,
        /// <summary>Broken obelisk ('NObk').</summary>
        BrokenObelisk_NObk = 1801604942,
        /// <summary>Bones ('NObo').</summary>
        Bones_NObo = 1868713806,
        /// <summary>Fence ('NOfl').</summary>
        Fence = 1818644302,
        /// <summary>Angled fence ('NOal').</summary>
        AngledFence = 1818316622,
        /// <summary>Stone grave ('NOgv').</summary>
        StoneGrave = 1986481998,
        /// <summary>Obelisk ('NOok').</summary>
        Obelisk_NOok = 1802456910,
        /// <summary>Tombstone ('NOtb').</summary>
        Tombstone = 1651789646,
        /// <summary>Floating box ('NWfb').</summary>
        FloatingBox = 1650874190,
        /// <summary>Floating plank ('NWfp').</summary>
        FloatingPlank = 1885755214,
        /// <summary>Ice floe ('NWf1').</summary>
        IceFloe_NWf1 = 828790606,
        /// <summary>Ice floe ('NWf2').</summary>
        IceFloe_NWf2 = 845567822,
        /// <summary>Ice floe ('NWf3').</summary>
        IceFloe_NWf3 = 862345038,
        /// <summary>Ice floe ('NWf4').</summary>
        IceFloe_NWf4 = 879122254,
        /// <summary>Iceberg ('NWi1').</summary>
        Iceberg_NWi1 = 828987214,
        /// <summary>Iceberg ('NWi2').</summary>
        Iceberg_NWi2 = 845764430,
        /// <summary>Iceberg ('NWi3').</summary>
        Iceberg_NWi3 = 862541646,
        /// <summary>Iceberg ('NWi4').</summary>
        Iceberg_NWi4 = 879318862,
        /// <summary>Floating panel ('NWpa').</summary>
        FloatingPanel = 1634752334,
        /// <summary>Fire pit ('NOfp').</summary>
        FirePit = 1885753166,
        /// <summary>Fire pit w pig ('NOfg').</summary>
        FirePitWPig = 1734758222,
        /// <summary>Trashed fire pit ('NOft').</summary>
        TrashedFirePit = 1952862030,
        /// <summary>Bats ('NObt').</summary>
        Bats = 1952599886,
        /// <summary>Rowboat ('NWrw').</summary>
        Rowboat = 2003982158,
        /// <summary>Destroyed rowboat ('NWrd').</summary>
        DestroyedRowboat = 1685215054,
        /// <summary>Ship ('NWsp').</summary>
        Ship = 1886607182,
        /// <summary>Destroyed ship ('NWsd').</summary>
        DestroyedShip = 1685280590,
        /// <summary>Whale ('NWwh').</summary>
        Whale = 1752651598,
        /// <summary>Thorny vines ('NPth').</summary>
        ThornyVines_NPth = 1752453198,
        /// <summary>Fissure ('NRfs').</summary>
        Fissure_NRfs = 1936085582,
        /// <summary>Ice claws ('NRic').</summary>
        IceClaws = 1667846734,
        /// <summary>Rocks ('NRrk').</summary>
        Rocks_NRrk = 1802654286,
        /// <summary>Webbed rocks ('NRwr').</summary>
        WebbedRocks = 1920422478,
        /// <summary>Crypt ('NSct').</summary>
        Crypt = 1952666446,
        /// <summary>Archway ('NSra').</summary>
        Archway_NSra = 1634882382,
        /// <summary>Angled archway ('NSr1').</summary>
        AngledArchway_NSr1 = 829576014,
        /// <summary>Rubble ('NSrb').</summary>
        Rubble_NSrb = 1651659598,
        /// <summary>Long fence ('VOfl').</summary>
        LongFence = 1818644310,
        /// <summary>Angled long fence ('VOal').</summary>
        AngledLongFence = 1818316630,
        /// <summary>Short fence ('VOfs').</summary>
        ShortFence = 1936084822,
        /// <summary>Angled short fence ('VOas').</summary>
        AngledShortFence = 1935757142,
        /// <summary>Building ('VSvb').</summary>
        Building = 1651921750,
        /// <summary>Long blue banner ('YObb').</summary>
        LongBlueBanner = 1650610009,
        /// <summary>Long white banner ('YOwb').</summary>
        LongWhiteBanner = 1651986265,
        /// <summary>Stone bench ('YObs').</summary>
        StoneBench = 1935822681,
        /// <summary>Angled stone bench ('YOsa').</summary>
        AngledStoneBench = 1634946905,
        /// <summary>Alonsus chapel ('YOsb').</summary>
        AlonsusChapel_YOsb = 1651724121,
        /// <summary>Alonsus chapel ('YOmb').</summary>
        AlonsusChapel_YOmb = 1651330905,
        /// <summary>Clock tower ('YOms').</summary>
        ClockTower = 1936543577,
        /// <summary>Market stall small ('YOm1').</summary>
        MarketStallSmall = 829247321,
        /// <summary>Market item baubles ('YOm2').</summary>
        MarketItemBaubles = 846024537,
        /// <summary>Market item baubles alt ('YOm3').</summary>
        MarketItemBaublesAlt = 862801753,
        /// <summary>Market item produce ('YOm4').</summary>
        MarketItemProduce = 879578969,
        /// <summary>Market item produce alt ('YOm5').</summary>
        MarketItemProduceAlt = 896356185,
        /// <summary>Market item textiles ('YOm6').</summary>
        MarketItemTextiles = 913133401,
        /// <summary>Market item textiles alt ('YOm7').</summary>
        MarketItemTextilesAlt = 929910617,
        /// <summary>Wood bench ('YObw').</summary>
        WoodBench = 2002931545,
        /// <summary>Angled wood bench ('YOwa').</summary>
        AngledWoodBench = 1635209049,
        /// <summary>Fountain ('YOfn').</summary>
        Fountain = 1852198745,
        /// <summary>Grave ('YOgr').</summary>
        Grave_YOgr = 1919373145,
        /// <summary>Obelisk ('YOob').</summary>
        Obelisk_YOob = 1651461977,
        /// <summary>Lantern post ('YOlp').</summary>
        LanternPost_YOlp = 1886146393,
        /// <summary>Statue ('YOst').</summary>
        Statue = 1953714009,
        /// <summary>Shieldless statue ('YOks').</summary>
        ShieldlessStatue = 1936412505,
        /// <summary>Power generator ('XOcs').</summary>
        PowerGenerator = 1935888216,
        /// <summary>Magical lantern ('XOcl').</summary>
        MagicalLantern = 1818447704,
        /// <summary>Magical runes ('XOmr').</summary>
        MagicalRunes = 1919766360,
        /// <summary>Tavern sign ('YOts').</summary>
        TavernSign = 1937002329,
        /// <summary>Bob s guns sign ('YObg').</summary>
        BobSGunsSign = 1734496089,
        /// <summary>Tracey s armory sign ('YOta').</summary>
        TraceySArmorySign = 1635012441,
        /// <summary>Empty crates ('YOec').</summary>
        EmptyCrates = 1667583833,
        /// <summary>Throne ('YOth').</summary>
        Throne_YOth = 1752452953,
        /// <summary>Whale statue ('YOws').</summary>
        WhaleStatue = 1937198937,
        /// <summary>King terenas statue ('YOss').</summary>
        KingTerenasStatue = 1936936793,
        /// <summary>Iron gate a ('YOig').</summary>
        IronGateA = 1734954841,
        /// <summary>Iron gate b ('YOi1').</summary>
        IronGateB = 828985177,
        /// <summary>Bush ('YPbs').</summary>
        Bush_YPbs = 1935822937,
        /// <summary>Tree planter ('YPtp').</summary>
        TreePlanter = 1886670937,
        /// <summary>Straight flower bed ('YPfs').</summary>
        StraightFlowerBed = 1936085081,
        /// <summary>Angled flower bed ('YPfa').</summary>
        AngledFlowerBed = 1634095193,
        /// <summary>Potted plant ('YPpp').</summary>
        PottedPlant = 1886408793,
        /// <summary>Archway ('YSaw').</summary>
        Archway_YSaw = 2002867033,
        /// <summary>Angled archway ('YSa1').</summary>
        AngledArchway_YSa1 = 828461913,
        /// <summary>Archway entrance ('YSa2').</summary>
        ArchwayEntrance = 845239129,
        /// <summary>Angled archway entrance ('YSa3').</summary>
        AngledArchwayEntrance = 862016345,
        /// <summary>Cathedral ('YSca').</summary>
        Cathedral = 1633899353,
        /// <summary>Single column ('YSco').</summary>
        SingleColumn = 1868780377,
        /// <summary>Double column ('YScd').</summary>
        DoubleColumn = 1684231001,
        /// <summary>Double column 45 ('YSc5').</summary>
        DoubleColumn45 = 895701849,
        /// <summary>Column semi circle ('YScs').</summary>
        ColumnSemiCircle = 1935889241,
        /// <summary>Column semi circle 2 ('YSc2').</summary>
        ColumnSemiCircle2 = 845370201,
        /// <summary>Column semi circle 3 ('YSc3').</summary>
        ColumnSemiCircle3 = 862147417,
        /// <summary>Column semi circle 4 ('YSc4').</summary>
        ColumnSemiCircle4 = 878924633,
        /// <summary>Short wall end ('YSls').</summary>
        ShortWallEnd = 1936479065,
        /// <summary>Low wall ('YSw0').</summary>
        LowWall_YSw0 = 813126489,
        /// <summary>Low wall ('YSw1').</summary>
        LowWall_YSw1 = 829903705,
        /// <summary>Low wall ('YSw2').</summary>
        LowWall_YSw2 = 846680921,
        /// <summary>Low wall ('YSw3').</summary>
        LowWall_YSw3 = 863458137,
        /// <summary>Wall corner ('YSw4').</summary>
        WallCorner_YSw4 = 880235353,
        /// <summary>Wall endcap ('YSw5').</summary>
        WallEndcap_YSw5 = 897012569,
        /// <summary>Wall staright ('YSw6').</summary>
        WallStaright = 913789785,
        /// <summary>Wall corner ('YSw7').</summary>
        WallCorner_YSw7 = 930567001,
        /// <summary>Wall straight long ('YSw8').</summary>
        WallStraightLong_YSw8 = 947344217,
        /// <summary>Wall straight short ('YSw9').</summary>
        WallStraightShort_YSw9 = 964121433,
        /// <summary>Wall straight tee ('YSwA').</summary>
        WallStraightTee = 1098339161,
        /// <summary>Wall straight tee alt ('YSwB').</summary>
        WallStraightTeeAlt = 1115116377,
        /// <summary>Wall entrance ('YSwC').</summary>
        WallEntrance = 1131893593,
        /// <summary>Wall door ('YSwD').</summary>
        WallDoor = 1148670809,
        /// <summary>Wall door short ('YSwE').</summary>
        WallDoorShort = 1165448025,
        /// <summary>Tall wall end ('YSlt').</summary>
        TallWallEnd = 1953256281,
        /// <summary>Lantern wall end ('YSll').</summary>
        LanternWallEnd = 1819038553,
        /// <summary>Tavern ('YSta').</summary>
        Tavern = 1635013465,
        /// <summary>Dead fish ('COdf').</summary>
        DeadFish = 1717849923,
        /// <summary>Rocks ('CRrk').</summary>
        Rocks_CRrk = 1802654275,
        /// <summary>Rocks ('DRrk').</summary>
        Rocks_DRrk = 1802654276,
        /// <summary>Lightning bolt ('YOlb').</summary>
        LightningBolt = 1651265369,
        /// <summary>Fire ('YOtf').</summary>
        Fire = 1718898521,
        /// <summary>Blue fire ('YOfb').</summary>
        BlueFire = 1650872153,
        /// <summary>Small fire ('YOfs').</summary>
        SmallFire = 1936084825,
        /// <summary>Side fire trap ('YOf1').</summary>
        SideFireTrap = 828788569,
        /// <summary>Fire trap ('YOf2').</summary>
        FireTrap = 845565785,
        /// <summary>Fire gust ('YOf3').</summary>
        FireGust = 862343001,
        /// <summary>Side frost trap ('YOr1').</summary>
        SideFrostTrap = 829575001,
        /// <summary>Frost trap ('YOr2').</summary>
        FrostTrap = 846352217,
        /// <summary>Archway ('DSar').</summary>
        Archway_DSar = 1918980932,
        /// <summary>Angled archway ('DSa1').</summary>
        AngledArchway_DSa1 = 828461892,
        /// <summary>Stone archway ('DSah').</summary>
        StoneArchway_DSah = 1751208772,
        /// <summary>Stone archway ('DSa2').</summary>
        StoneArchway_DSa2 = 845239108,
        /// <summary>Pile of treasure ('DOtp').</summary>
        PileOfTreasure = 1886670660,
        /// <summary>Pile of junk ('DOjp').</summary>
        PileOfJunk = 1886015300,
        /// <summary>Chains ('DOch').</summary>
        Chains = 1751338820,
        /// <summary>Chain post ('DOcp').</summary>
        ChainPost = 1885556548,
        /// <summary>Fiery crater ('DRfc').</summary>
        FieryCrater_DRfc = 1667650116,
        /// <summary>Stalagmite ('DRst').</summary>
        Stalagmite_DRst = 1953714756,
        /// <summary>Lava cracks ('DOlc').</summary>
        LavaCracks_DOlc = 1668042564,
        /// <summary>Chair ('DOcr').</summary>
        Chair_DOcr = 1919110980,
        /// <summary>Bench ('DObh').</summary>
        Bench = 1751273284,
        /// <summary>Bookshelf ('DObk').</summary>
        Bookshelf = 1801604932,
        /// <summary>Large bookshelf ('DOkb').</summary>
        LargeBookshelf = 1651199812,
        /// <summary>Long bookshelf ('DObw').</summary>
        LongBookshelf = 2002931524,
        /// <summary>Angled bookshelf ('DOab').</summary>
        AngledBookshelf = 1650544452,
        /// <summary>Obelisk ('DOob').</summary>
        Obelisk_DOob = 1651461956,
        /// <summary>Table ('DOtb').</summary>
        Table = 1651789636,
        /// <summary>Table and chair ('DOtc').</summary>
        TableAndChair = 1668566852,
        /// <summary>Iron maiden ('DOim').</summary>
        IronMaiden = 1835618116,
        /// <summary>Torture table ('DOtt').</summary>
        TortureTable = 1953779524,
        /// <summary>Mine cart ('DOmc').</summary>
        MineCart = 1668108100,
        /// <summary>Empty mine cart ('DOme').</summary>
        EmptyMineCart = 1701662532,
        /// <summary>Barred wall ('DSp0').</summary>
        BarredWall_DSp0 = 812667716,
        /// <summary>Barred wall ('DSp9').</summary>
        BarredWall_DSp9 = 963662660,
        /// <summary>Blue mushroom ('GPsh').</summary>
        BlueMushroom = 1752387655,
        /// <summary>Rocks ('GRrk').</summary>
        Rocks_GRrk = 1802654279,
        /// <summary>Fiery crater ('GRfc').</summary>
        FieryCrater_GRfc = 1667650119,
        /// <summary>Stalagmite ('GRst').</summary>
        Stalagmite_GRst = 1953714759,
        /// <summary>Obelisk ('GOob').</summary>
        Obelisk_GOob = 1651461959,
        /// <summary>Stone archway ('GSah').</summary>
        StoneArchway_GSah = 1751208775,
        /// <summary>Stone archway ('GSa2').</summary>
        StoneArchway_GSa2 = 845239111,
        /// <summary>Archway ('GSar').</summary>
        Archway_GSar = 1918980935,
        /// <summary>Archway ('GSa1').</summary>
        Archway_GSa1 = 828461895,
        /// <summary>Barred wall ('GSp0').</summary>
        BarredWall_GSp0 = 812667719,
        /// <summary>Barred wall ('GSp9').</summary>
        BarredWall_GSp9 = 963662663,
        /// <summary>Lava cracks ('GOlc').</summary>
        LavaCracks_GOlc = 1668042567,
        /// <summary>Waterfall effect ('LWw0').</summary>
        WaterfallEffect = 813127500,
        /// <summary>Cave 0 ('LCc0').</summary>
        Cave0 = 811811660,
        /// <summary>Cave 2 ('LCc2').</summary>
        Cave2 = 845366092,
        /// <summary>Sun well ('YOsw').</summary>
        SunWell = 2004045657,
        /// <summary>Camera prop ('YOcp').</summary>
        CameraProp = 1885556569,
        /// <summary>City building ('YS00').</summary>
        CityBuilding_YS00 = 808473433,
        /// <summary>City building ('YS01').</summary>
        CityBuilding_YS01 = 825250649,
        /// <summary>City building ('YS02').</summary>
        CityBuilding_YS02 = 842027865,
        /// <summary>City building ('YS03').</summary>
        CityBuilding_YS03 = 858805081,
        /// <summary>City building ('YS04').</summary>
        CityBuilding_YS04 = 875582297,
        /// <summary>City building ('YS05').</summary>
        CityBuilding_YS05 = 892359513,
        /// <summary>City building ('YS06').</summary>
        CityBuilding_YS06 = 909136729,
        /// <summary>City building ('YS07').</summary>
        CityBuilding_YS07 = 925913945,
        /// <summary>City building ('YS08').</summary>
        CityBuilding_YS08 = 942691161,
        /// <summary>City building ('YS09').</summary>
        CityBuilding_YS09 = 959468377,
        /// <summary>City building ('YS10').</summary>
        CityBuilding_YS10 = 808538969,
        /// <summary>City building ('YS11').</summary>
        CityBuilding_YS11 = 825316185,
        /// <summary>Large city building ('YS12').</summary>
        LargeCityBuilding_YS12 = 842093401,
        /// <summary>Large city building ('YS13').</summary>
        LargeCityBuilding_YS13 = 858870617,
        /// <summary>Large city building ('YS14').</summary>
        LargeCityBuilding_YS14 = 875647833,
        /// <summary>Large city building ('YS15').</summary>
        LargeCityBuilding_YS15 = 892425049,
        /// <summary>Energy field ('YZef').</summary>
        EnergyField = 1717918297,
        /// <summary>Thrall s hut ('LZth').</summary>
        ThrallSHut = 1752455756,
        /// <summary>Ruins brazier ('ZObz').</summary>
        RuinsBrazier = 2053263194,
        /// <summary>Ruins statue ('ZOst').</summary>
        RuinsStatue = 1953714010,
        /// <summary>Ruins broken statue ('ZOsb').</summary>
        RuinsBrokenStatue = 1651724122,
        /// <summary>Ruins stones ('ZOss').</summary>
        RuinsStones = 1936936794,
        /// <summary>Archway ('ZSar').</summary>
        Archway_ZSar = 1918980954,
        /// <summary>Archway ('ZSa1').</summary>
        Archway_ZSa1 = 828461914,
        /// <summary>Archway ('ZSas').</summary>
        Archway_ZSas = 1935758170,
        /// <summary>Archway ('ZSs1').</summary>
        Archway_ZSs1 = 829641562,
        /// <summary>Ruined archway ('ZSab').</summary>
        RuinedArchway_ZSab = 1650545498,
        /// <summary>Ruined archway ('ZSb1').</summary>
        RuinedArchway_ZSb1 = 828527450,
        /// <summary>Green fish ('ZWfs').</summary>
        GreenFish = 1936086874,
        /// <summary>School of fish ('ZWsf').</summary>
        SchoolOfFish = 1718835034,
        /// <summary>Ruins ('ZSrb').</summary>
        Ruins = 1651659610,
        /// <summary>Ruins fountain ('ZOfo').</summary>
        RuinsFountain = 1868975962,
        /// <summary>Ruins obelisk ('ZOob').</summary>
        RuinsObelisk = 1651461978,
        /// <summary>Ruins throne ('ZOrt').</summary>
        RuinsThrone = 1953648474,
        /// <summary>Rocks ('IRrk').</summary>
        Rocks_IRrk = 1802654281,
        /// <summary>Ruins pillar ('ZOrp').</summary>
        RuinsPillar = 1886539610,
        /// <summary>Shells ('ZOsh').</summary>
        Shells = 1752387418,
        /// <summary>City cliff cave 1 ('YCc1').</summary>
        CityCliffCave1 = 828588889,
        /// <summary>City cliff cave 2 ('YCc2').</summary>
        CityCliffCave2 = 845366105,
        /// <summary>City cliff cave 3 ('YCc3').</summary>
        CityCliffCave3 = 862143321,
        /// <summary>City cliff cave 4 ('YCc4').</summary>
        CityCliffCave4 = 878920537,
        /// <summary>City cliff collapse 1 ('YCd1').</summary>
        CityCliffCollapse1 = 828654425,
        /// <summary>City cliff collapse 2 ('YCd2').</summary>
        CityCliffCollapse2 = 845431641,
        /// <summary>City cliff collapse 3 ('YCd3').</summary>
        CityCliffCollapse3 = 862208857,
        /// <summary>City cliff collapse 4 ('YCd4').</summary>
        CityCliffCollapse4 = 878986073,
        /// <summary>Ruined crystal tower ('ZOrc').</summary>
        RuinedCrystalTower = 1668435802,
        /// <summary>Ruined tower ('ZOdt').</summary>
        RuinedTower_ZOdt = 1952730970,
        /// <summary>Ruined tower ('ZOd2').</summary>
        RuinedTower_ZOd2 = 845434714,
        /// <summary>Ruined tower base ('ZOrb').</summary>
        RuinedTowerBase = 1651658586,
        /// <summary>Ruined double base ('ZOtb').</summary>
        RuinedDoubleBase_ZOtb = 1651789658,
        /// <summary>Ruined double base ('ZOt2').</summary>
        RuinedDoubleBase_ZOt2 = 846483290,
        /// <summary>Ruined violet citadel ('ZOvr').</summary>
        RuinedVioletCitadel = 1920356186,
        /// <summary>Ruins firepot ('ZOfp').</summary>
        RuinsFirepot = 1885753178,
        /// <summary>Rocks ('ZRrk').</summary>
        Rocks_ZRrk = 1802654298,
        /// <summary>Cliffside vines ('ZCv1').</summary>
        CliffsideVines_ZCv1 = 829834074,
        /// <summary>Cliffside vines ('ZCv2').</summary>
        CliffsideVines_ZCv2 = 846611290,
        /// <summary>Seaweed ('ZWsw').</summary>
        Seaweed = 2004047706,
        /// <summary>Bubbles ('ZWbg').</summary>
        Bubbles = 1734498138,
        /// <summary>Steam bubbles ('IWbg').</summary>
        SteamBubbles = 1734498121,
        /// <summary>Floating ice ('IWie').</summary>
        FloatingIce = 1701402441,
        /// <summary>Icy waterfall effect ('IWw0').</summary>
        IcyWaterfallEffect = 813127497,
        /// <summary>Flowers ('ZPfw').</summary>
        Flowers_ZPfw = 2003193946,
        /// <summary>Shrub ('ZPsh').</summary>
        Shrub = 1752387674,
        /// <summary>Lilypad ('ZPlp').</summary>
        Lilypad = 1886146650,
        /// <summary>Cat tail ('ZPru').</summary>
        CatTail = 1970425946,
        /// <summary>Coral ('ZWcl').</summary>
        Coral = 1818449754,
        /// <summary>Coral arch ('ZWca').</summary>
        CoralArch = 1633900378,
        /// <summary>Demonic footprints ('ZZdt').</summary>
        DemonicFootprints = 1952733786,
        /// <summary>Skull torch ('IOst').</summary>
        SkullTorch = 1953713993,
        /// <summary>Ice archway ('ISar').</summary>
        IceArchway_ISar = 1918980937,
        /// <summary>Ice archway ('ISa1').</summary>
        IceArchway_ISa1 = 828461897,
        /// <summary>Obelisk ('IOob').</summary>
        Obelisk_IOob = 1651461961,
        /// <summary>Pillar ('IOpr').</summary>
        Pillar = 1919962953,
        /// <summary>Ice block ('IRic').</summary>
        IceBlock = 1667846729,
        /// <summary>Statue of azshara ('DOas').</summary>
        StatueOfAzshara_DOas = 1935757124,
        /// <summary>Snowman ('IOsm').</summary>
        Snowman = 1836273481,
        /// <summary>Rock spires ('ZRrs').</summary>
        RockSpires_ZRrs = 1936872026,
        /// <summary>Small rock spires ('ZRsp').</summary>
        SmallRockSpires_ZRsp = 1886605914,
        /// <summary>Rocks ('ORrk').</summary>
        Rocks_ORrk = 1802654287,
        /// <summary>Rock spires ('ORrs').</summary>
        RockSpires_ORrs = 1936872015,
        /// <summary>Ice spider on pedestal ('IOss').</summary>
        IceSpiderOnPedestal = 1936936777,
        /// <summary>Ice spider statue ('IOsl').</summary>
        IceSpiderStatue = 1819496265,
        /// <summary>Ruined ship ('AZrf').</summary>
        RuinedShip = 1718770241,
        /// <summary>Plants ('OPop').</summary>
        Plants = 1886343247,
        /// <summary>Glacier ('IRgc').</summary>
        Glacier = 1667715657,
        /// <summary>Magma rock ('ORmk').</summary>
        MagmaRock = 1802326607,
        /// <summary>RuinedFloor2x2  ('YCx1').</summary>
        RuinedFloor2x2_YCx1 = 829965145,
        /// <summary>RuinedFloor2x2  ('YCx2').</summary>
        RuinedFloor2x2_YCx2 = 846742361,
        /// <summary>RuinedFloor2x2  ('YCx3').</summary>
        RuinedFloor2x2_YCx3 = 863519577,
        /// <summary>RuinedFloor2x2  ('YCx4').</summary>
        RuinedFloor2x2_YCx4 = 880296793,
        /// <summary>RuinedFloor4x4  ('YCx5').</summary>
        RuinedFloor4x4_YCx5 = 897074009,
        /// <summary>RuinedFloor4x4  ('YCx6').</summary>
        RuinedFloor4x4_YCx6 = 913851225,
        /// <summary>RuinedFloor4x2  ('YCx7').</summary>
        RuinedFloor4x2_YCx7 = 930628441,
        /// <summary>RuinedFloor4x2  ('YCx8').</summary>
        RuinedFloor4x2_YCx8 = 947405657,
        /// <summary>Rough cliff cave 1 ('YCr1').</summary>
        RoughCliffCave1 = 829571929,
        /// <summary>Rough cliff cave 2 ('YCr2').</summary>
        RoughCliffCave2 = 846349145,
        /// <summary>Rough cliff cave 3 ('YCr3').</summary>
        RoughCliffCave3 = 863126361,
        /// <summary>Rough cliff cave 4 ('YCr4').</summary>
        RoughCliffCave4 = 879903577,
        /// <summary>Rough cliff collapse 1 ('YCp1').</summary>
        RoughCliffCollapse1 = 829440857,
        /// <summary>Rough cliff collapse 2 ('YCp2').</summary>
        RoughCliffCollapse2 = 846218073,
        /// <summary>Rough cliff collapse 3 ('YCp3').</summary>
        RoughCliffCollapse3 = 862995289,
        /// <summary>Rough cliff collapse 4 ('YCp4').</summary>
        RoughCliffCollapse4 = 879772505,
        /// <summary>City cliff slide 1 ('YCs1').</summary>
        CityCliffSlide1 = 829637465,
        /// <summary>City cliff slide 2 ('YCs2').</summary>
        CityCliffSlide2 = 846414681,
        /// <summary>City cliff slide 3 ('YCs3').</summary>
        CityCliffSlide3 = 863191897,
        /// <summary>City cliff slide 4 ('YCs4').</summary>
        CityCliffSlide4 = 879969113,
        /// <summary>City cliff collapse short 1 ('YCt1').</summary>
        CityCliffCollapseShort1 = 829703001,
        /// <summary>City cliff collapse short 2 ('YCt2').</summary>
        CityCliffCollapseShort2 = 846480217,
        /// <summary>City cliff collapse short 3 ('YCt3').</summary>
        CityCliffCollapseShort3 = 863257433,
        /// <summary>City cliff collapse short 4 ('YCt4').</summary>
        CityCliffCollapseShort4 = 880034649,
        /// <summary>City cliff slide short 1 ('YCo1').</summary>
        CityCliffSlideShort1 = 829375321,
        /// <summary>City cliff slide short 2 ('YCo2').</summary>
        CityCliffSlideShort2 = 846152537,
        /// <summary>City cliff slide short 3 ('YCo3').</summary>
        CityCliffSlideShort3 = 862929753,
        /// <summary>City cliff slide short 4 ('YCo4').</summary>
        CityCliffSlideShort4 = 879706969,
        /// <summary>Rough cliff slide 1 ('YCg1').</summary>
        RoughCliffSlide1 = 828851033,
        /// <summary>Rough cliff slide 2 ('YCg2').</summary>
        RoughCliffSlide2 = 845628249,
        /// <summary>Rough cliff slide 3 ('YCg3').</summary>
        RoughCliffSlide3 = 862405465,
        /// <summary>Rough cliff slide 4 ('YCg4').</summary>
        RoughCliffSlide4 = 879182681,
        /// <summary>Rough cliff slide short 1 ('YCu1').</summary>
        RoughCliffSlideShort1 = 829768537,
        /// <summary>Rough cliff slide short 2 ('YCu2').</summary>
        RoughCliffSlideShort2 = 846545753,
        /// <summary>Rough cliff slide short 3 ('YCu3').</summary>
        RoughCliffSlideShort3 = 863322969,
        /// <summary>Rough cliff slide short 4 ('YCu4').</summary>
        RoughCliffSlideShort4 = 880100185,
        /// <summary>Rough cliff collapse short 1 ('YCl1').</summary>
        RoughCliffCollapseShort1 = 829178713,
        /// <summary>Rough cliff collapse short 2 ('YCl2').</summary>
        RoughCliffCollapseShort2 = 845955929,
        /// <summary>Rough cliff collapse short 3 ('YCl3').</summary>
        RoughCliffCollapseShort3 = 862733145,
        /// <summary>Rough cliff collapse short 4 ('YCl4').</summary>
        RoughCliffCollapseShort4 = 879510361,
        /// <summary>Small rubble ('ZRbs').</summary>
        SmallRubble = 1935823450,
        /// <summary>Large rubble ('ZRbd').</summary>
        LargeRubble = 1684165210,
        /// <summary>Floating rock ('ORfk').</summary>
        FloatingRock = 1801867855,
        /// <summary>Floating rock cluster ('OZfc').</summary>
        FloatingRockCluster = 1667652175,
        /// <summary>Pier ('ASpr').</summary>
        Pier = 1919963969,
        /// <summary>Ruined pier ('ASpt').</summary>
        RuinedPier = 1953518401,
        /// <summary>Mushrooms ('ZPms').</summary>
        Mushrooms_ZPms = 1936543834,
        /// <summary>Viny plant ('ZPvp').</summary>
        VinyPlant = 1886802010,
        /// <summary>Library shelf ('ZOls').</summary>
        LibraryShelf = 1936478042,
        /// <summary>Ruined cathedral ('YScr').</summary>
        RuinedCathedral = 1919112025,
        /// <summary>Ruined fountain ('YOfr').</summary>
        RuinedFountain = 1919307609,
        /// <summary>Gul dan s runes ('ZZgr').</summary>
        GulDanSRunes = 1919375962,
        /// <summary>Invulnerability field ('JZif').</summary>
        InvulnerabilityField = 1718180426,
        /// <summary>City building ('YSr0').</summary>
        CityBuilding_YSr0 = 812798809,
        /// <summary>City building ('YSr1').</summary>
        CityBuilding_YSr1 = 829576025,
        /// <summary>City building ('YSr2').</summary>
        CityBuilding_YSr2 = 846353241,
        /// <summary>City building ('YSr3').</summary>
        CityBuilding_YSr3 = 863130457,
        /// <summary>City building ('YSr4').</summary>
        CityBuilding_YSr4 = 879907673,
        /// <summary>City building ('YSr5').</summary>
        CityBuilding_YSr5 = 896684889,
        /// <summary>City building ('YSr6').</summary>
        CityBuilding_YSr6 = 913462105,
        /// <summary>City building ('YSr7').</summary>
        CityBuilding_YSr7 = 930239321,
        /// <summary>City building ('YSr8').</summary>
        CityBuilding_YSr8 = 947016537,
        /// <summary>City building ('YSr9').</summary>
        CityBuilding_YSr9 = 963793753,
        /// <summary>City building ('YSra').</summary>
        CityBuilding_YSra = 1634882393,
        /// <summary>City building ('YSrb').</summary>
        CityBuilding_YSrb = 1651659609,
        /// <summary>Large city building ('YSrc').</summary>
        LargeCityBuilding_YSrc = 1668436825,
        /// <summary>Large city building ('YSrd').</summary>
        LargeCityBuilding_YSrd = 1685214041,
        /// <summary>Large city building ('YSre').</summary>
        LargeCityBuilding_YSre = 1701991257,
        /// <summary>Large city building ('YSrf').</summary>
        LargeCityBuilding_YSrf = 1718768473,
        /// <summary>City building row ('YSbr').</summary>
        CityBuildingRow_YSbr = 1919046489,
        /// <summary>City building row ('YSb1').</summary>
        CityBuildingRow_YSb1 = 828527449,
        /// <summary>City building row ('YSb2').</summary>
        CityBuildingRow_YSb2 = 845304665,
        /// <summary>Eye of sargeras ('ZZys').</summary>
        EyeOfSargeras = 1937332826,
        /// <summary>Column semi circle ruined ('JScs').</summary>
        ColumnSemiCircleRuined = 1935889226,
        /// <summary>Column semi circle 2 ruined ('JSc2').</summary>
        ColumnSemiCircle2Ruined = 845370186,
        /// <summary>Column semi circle 3 ruined ('JSc3').</summary>
        ColumnSemiCircle3Ruined = 862147402,
        /// <summary>Column semi circle 4 ruined ('JSc4').</summary>
        ColumnSemiCircle4Ruined = 878924618,
        /// <summary>Single column ruined ('JSco').</summary>
        SingleColumnRuined_JSco = 1868780362,
        /// <summary>Single column ruined ('JScx').</summary>
        SingleColumnRuined_JScx = 2019775306,
        /// <summary>Large city building ruined base ('JSrc').</summary>
        LargeCityBuildingRuinedBase = 1668436810,
        /// <summary>City building ruined base ('JSr6').</summary>
        CityBuildingRuinedBase = 913462090,
        /// <summary>Archway ruined ('JSar').</summary>
        ArchwayRuined_JSar = 1918980938,
        /// <summary>Archway ruined ('JSax').</summary>
        ArchwayRuined_JSax = 2019644234,
        /// <summary>Dust ('ZZcd').</summary>
        Dust = 1684232794,
        /// <summary>Ruined goblin shipyard ('LSrg').</summary>
        RuinedGoblinShipyard = 1735545676,
        /// <summary>Totem lantern ('AOnt').</summary>
        TotemLantern = 1953386305,
        /// <summary>Sewer vent ('DOsv').</summary>
        SewerVent = 1987268420,
        /// <summary>Sewer wallpipes ('DOsw').</summary>
        SewerWallpipes = 2004045636,
        /// <summary>Wall fountain ('LOwf').</summary>
        WallFountain = 1719095116,
        /// <summary>Runes ('KOdr').</summary>
        Runes = 1919176523,
        /// <summary>Shimmering portal ('OZsp').</summary>
        ShimmeringPortal = 1886607951,
        /// <summary>Elven fishing village ('ASv0').</summary>
        ElvenFishingVillage_ASv0 = 813060929,
        /// <summary>Elven fishing village ('ASv1').</summary>
        ElvenFishingVillage_ASv1 = 829838145,
        /// <summary>Elven fishing village ('ASv2').</summary>
        ElvenFishingVillage_ASv2 = 846615361,
        /// <summary>Elven fishing village ('ASv3').</summary>
        ElvenFishingVillage_ASv3 = 863392577,
        /// <summary>Elven fishing village ('ASv4').</summary>
        ElvenFishingVillage_ASv4 = 880169793,
        /// <summary>Ruined elven fishing village ('ASx0').</summary>
        RuinedElvenFishingVillage_ASx0 = 813192001,
        /// <summary>Ruined elven fishing village ('ASx1').</summary>
        RuinedElvenFishingVillage_ASx1 = 829969217,
        /// <summary>Ruined elven fishing village ('ASx2').</summary>
        RuinedElvenFishingVillage_ASx2 = 846746433,
        /// <summary>Trash ('ZOtr').</summary>
        Trash_ZOtr = 1920225114,
        /// <summary>Bloody altar ('ZOba').</summary>
        BloodyAltar = 1633832794,
        /// <summary>Rising water ('IZrw').</summary>
        RisingWater = 2003982921,
        /// <summary>Black citadel statue ('KOst').</summary>
        BlackCitadelStatue = 1953713995,
        /// <summary>The frozen throne ('IZft').</summary>
        TheFrozenThrone = 1952864841,
        /// <summary>Icey chair ('IOic').</summary>
        IceyChair = 1667845961,
        /// <summary>Crystal ('IRcy').</summary>
        Crystal = 2036552265,
        /// <summary>Stone archway ('ISsr').</summary>
        StoneArchway_ISsr = 1920160585,
        /// <summary>Angled stone archway ('ISs1').</summary>
        AngledStoneArchway = 829641545,
        /// <summary>Chair ('IOch').</summary>
        Chair_IOch = 1751338825,
        /// <summary>Altar ('OOal').</summary>
        Altar = 1818316623,
        /// <summary>Flame grate ('OOgr').</summary>
        FlameGrate = 1919373135,
        /// <summary>Obstacle ('OOob').</summary>
        Obstacle = 1651461967,
        /// <summary>Skull ('OOsk').</summary>
        Skull = 1802719055,
        /// <summary>Stake ('OOst').</summary>
        Stake = 1953713999,
        /// <summary>Rubble ('ORrr').</summary>
        Rubble_ORrr = 1920094799,
        /// <summary>Underground dome ('JZud').</summary>
        UndergroundDome = 1685412426,
        /// <summary>Standard ('OOsd').</summary>
        Standard = 1685278543,
        /// <summary>Snowy rocks ('IRrs').</summary>
        SnowyRocks = 1936872009,
        /// <summary>Rubble ('ISrb').</summary>
        Rubble_ISrb = 1651659593,
        /// <summary>Glowing runes ('JOgr').</summary>
        GlowingRunes = 1919373130,
        /// <summary>Barrens tree ('BPtw').</summary>
        BarrensTree = 2004111426,
        /// <summary>Sunken ruins tree ('ZPtw').</summary>
        SunkenRuinsTree = 2004111450,
        /// <summary>Rising water wide ('IZww').</summary>
        RisingWaterWide = 2004310601,
        /// <summary>No lantern wall end ('YSlx').</summary>
        NoLanternWallEnd = 2020365145,
        /// <summary>Rock archway ('OSar').</summary>
        RockArchway_OSar = 1918980943,
        /// <summary>Angled rock archway ('OSa1').</summary>
        AngledRockArchway_OSa1 = 828461903,
        /// <summary>Strahnbrad clock tower ('SCt0').</summary>
        StrahnbradClockTower = 812925779,
        /// <summary>Strahnbrad large tree ('SLt0').</summary>
        StrahnbradLargeTree = 812928083,
        /// <summary>Brill clock tower ('BCt0').</summary>
        BrillClockTower = 812925762,
        /// <summary>Androhal clock tower ('ACt0').</summary>
        AndrohalClockTower = 812925761,
        /// <summary>Androhal clock tower destroyed ('ACtd').</summary>
        AndrohalClockTowerDestroyed = 1685340993,
        /// <summary>Hearthglen abbey ('HA00').</summary>
        HearthglenAbbey = 808468808,
        /// <summary>Pyrewood village clock tower destroyed ('PVct').</summary>
        PyrewoodVillageClockTowerDestroyed = 1952667216,
        /// <summary>High elf crest standing banners ('HEcs').</summary>
        HighElfCrestStandingBanners = 1935885640,
        /// <summary>High elf crest hanging banners ('HEch').</summary>
        HighElfCrestHangingBanners = 1751336264,
        /// <summary>Silvermoon residential buildings diagonal 1 ('SRbc').</summary>
        SilvermoonResidentialBuildingsDiagonal1 = 1667387987,
        /// <summary>Silvermoon residential buildings diagonal 2 ('SRbe').</summary>
        SilvermoonResidentialBuildingsDiagonal2 = 1700942419,
        /// <summary>Silvermoon residential buildings vertical ('SRbv').</summary>
        SilvermoonResidentialBuildingsVertical = 1986155091,
        /// <summary>Silvermoon residential buildings horizontal ('SRbh').</summary>
        SilvermoonResidentialBuildingsHorizontal = 1751274067,
        /// <summary>Sunfury spire main tower ('SSmt').</summary>
        SunfurySpireMainTower = 1953321811,
        /// <summary>Sunfury spire side tower ('SSst').</summary>
        SunfurySpireSideTower = 1953715027,
        /// <summary>Silvermoon tower doodads large ('STdl').</summary>
        SilvermoonTowerDoodadsLarge = 1818514515,
        /// <summary>Silvermoon tower doodads medium ('STdm').</summary>
        SilvermoonTowerDoodadsMedium = 1835291731,
        /// <summary>Silvermoon tower doodads small ('STds').</summary>
        SilvermoonTowerDoodadsSmall = 1935955027,
        /// <summary>Silvermoon wall straight short ('SWss').</summary>
        SilvermoonWallStraightShort = 1936938835,
        /// <summary>Silvermoon wall straight ('SWs0').</summary>
        SilvermoonWallStraight = 812865363,
        /// <summary>Silvermoon wall straight long ('SWsl').</summary>
        SilvermoonWallStraightLong = 1819498323,
        /// <summary>SilvermoonWall T ('SWt0').</summary>
        SilvermoonWallT = 812930899,
        /// <summary>Silvermoon wall straight door ('SWsd').</summary>
        SilvermoonWallStraightDoor = 1685280595,
        /// <summary>Silvermoon wall straight door short ('SWse').</summary>
        SilvermoonWallStraightDoorShort = 1702057811,
        /// <summary>Silvermoon wall corner ('SWc0').</summary>
        SilvermoonWallCorner = 811816787,
        /// <summary>Silvermoon wall endcap ('SWe0').</summary>
        SilvermoonWallEndcap = 811947859,
        /// <summary>Silvermoon archway entrance ('SAe0').</summary>
        SilvermoonArchwayEntrance = 811942227,
        /// <summary>Silvermoon archway entrance 45 ('SAe1').</summary>
        SilvermoonArchwayEntrance45 = 828719443,
        /// <summary>Silvermoon archway ('SA00').</summary>
        SilvermoonArchway = 808468819,
        /// <summary>Silvermoon archway 45 ('SA01').</summary>
        SilvermoonArchway45 = 825246035,
        /// <summary>Large silvermoon tower ('LSt0').</summary>
        LargeSilvermoonTower = 812929868,
        /// <summary>Exterior main tower ('EMt0').</summary>
        ExteriorMainTower = 812928325,
        /// <summary>Exterior tower ('ET00').</summary>
        ExteriorTower = 808473669,
        /// <summary>Exterior wall ('EW00').</summary>
        ExteriorWall = 808474437,
        /// <summary>Exterior gate ('EG00').</summary>
        ExteriorGate = 808470341,
        /// <summary>Archway standard dimension ('ASd0').</summary>
        ArchwayStandardDimension = 811881281,
        /// <summary>Statue of azshara ('SA02').</summary>
        StatueOfAzshara_SA02 = 842023251,
        /// <summary>Corpse of gul 2 dan ('CGd0').</summary>
        CorpseOfGul2Dan = 811878211,
        /// <summary>Violet hold main structure ('VHms').</summary>
        VioletHoldMainStructure = 1936541782,
        /// <summary>Violet hold spire ('VHs0').</summary>
        VioletHoldSpire = 812861526,
        /// <summary>Violet hold spire small ('VHss').</summary>
        VioletHoldSpireSmall = 1936934998,
        /// <summary>Violet hold archway endpiece ('VHae').</summary>
        VioletHoldArchwayEndpiece = 1700874326,
        /// <summary>Magus turret ('MT00').</summary>
        MagusTurret = 808473677,
        /// <summary>Magus highrise ('MH00').</summary>
        MagusHighrise = 808470605,
        /// <summary>Magus conservatory ('MC00').</summary>
        MagusConservatory = 808469325,
        /// <summary>Sunreaver archway ('SA03').</summary>
        SunreaverArchway = 858800467,
        /// <summary>Sunreaver dome ('SD00').</summary>
        SunreaverDome = 808469587,
        /// <summary>Sunreaver dome small ('SDs0').</summary>
        SunreaverDomeSmall = 812860499,
        /// <summary>Sunreaver spire ('SS00').</summary>
        SunreaverSpire = 808473427,
        /// <summary>Enclave main structure ('EMs0').</summary>
        EnclaveMainStructure = 812862789,
        /// <summary>Enclave spire ('ES00').</summary>
        EnclaveSpire = 808473413,
        /// <summary>Enclave house ('EH00').</summary>
        EnclaveHouse = 808470597,
        /// <summary>Enclave house B ('EHb0').</summary>
        EnclaveHouseB = 811747397,
        /// <summary>Enclave turret ('ET01').</summary>
        EnclaveTurret = 825250885,
        /// <summary>Runeweaver square fountain ('RSf0').</summary>
        RuneweaverSquareFountain = 812012370,
        /// <summary>Building A ('BA00').</summary>
        BuildingA = 808468802,
        /// <summary>Building B ('BB00').</summary>
        BuildingB = 808469058,
        /// <summary>Building C ('BC00').</summary>
        BuildingC = 808469314,
        /// <summary>Wall straight short ('WSs0').</summary>
        WallStraightShort_WSs0 = 812864343,
        /// <summary>Wall straight ('WS00').</summary>
        WallStraight = 808473431,
        /// <summary>Wall straight long ('WSl0').</summary>
        WallStraightLong_WSl0 = 812405591,
        /// <summary>Wall T ('WT00').</summary>
        WallT = 808473687,
        /// <summary>Wall T alt ('WTa0').</summary>
        WallTAlt = 811684951,
        /// <summary>Wall spire ('WS01').</summary>
        WallSpire = 825250647,
        /// <summary>Wall spire alt ('WSa0').</summary>
        WallSpireAlt = 811684695,
        /// <summary>Wall 90 degree ('WD00').</summary>
        Wall90Degree = 808469591,
        /// <summary>Wall endcap ('WE00').</summary>
        WallEndcap_WE00 = 808469847,
        /// <summary>Flowers ('ZPf0').</summary>
        Flowers_ZPf0 = 812011610
    }
}