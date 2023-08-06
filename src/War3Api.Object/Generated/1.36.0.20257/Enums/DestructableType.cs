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
    public enum DestructableType
    {
        /// <summary>Ashenvale tree wall ('ATtr').</summary>
        AshenvaleTreeWall = 1920226369,
        /// <summary>Barrens tree wall ('BTtw').</summary>
        BarrensTreeWall = 2004112450,
        /// <summary>Felwood tree wall ('CTtr').</summary>
        FelwoodTreeWall = 1920226371,
        /// <summary>Fall tree wall ('FTtw').</summary>
        FallTreeWall = 2004112454,
        /// <summary>Cage ('LOcg').</summary>
        Cage = 1734561612,
        /// <summary>Barricade ('LTba').</summary>
        Barricade = 1633834060,
        /// <summary>Crates ('LTcr').</summary>
        Crates = 1919112268,
        /// <summary>Barrel ('LTbr').</summary>
        Barrel_LTbr = 1919046732,
        /// <summary>Barrel ('LTbx').</summary>
        Barrel_LTbx = 2019710028,
        /// <summary>Barrel ('LTbs').</summary>
        Barrel_LTbs = 1935823948,
        /// <summary>Barrel of explosives ('LTex').</summary>
        BarrelOfExplosives = 2019906636,
        /// <summary>Gate ('LTg1').</summary>
        Gate_LTg1 = 828855372,
        /// <summary>Gate ('LTg2').</summary>
        Gate_LTg2 = 845632588,
        /// <summary>Gate ('LTg3').</summary>
        Gate_LTg3 = 862409804,
        /// <summary>Gate ('LTg4').</summary>
        Gate_LTg4 = 879187020,
        /// <summary>Elven gate ('LTe1').</summary>
        ElvenGate_LTe1 = 828724300,
        /// <summary>Elven gate ('LTe2').</summary>
        ElvenGate_LTe2 = 845501516,
        /// <summary>Elven gate ('LTe3').</summary>
        ElvenGate_LTe3 = 862278732,
        /// <summary>Elven gate ('LTe4').</summary>
        ElvenGate_LTe4 = 879055948,
        /// <summary>Demonic gate ('ATg1').</summary>
        DemonicGate_ATg1 = 828855361,
        /// <summary>Demonic gate ('ATg2').</summary>
        DemonicGate_ATg2 = 845632577,
        /// <summary>Demonic gate ('ATg3').</summary>
        DemonicGate_ATg3 = 862409793,
        /// <summary>Demonic gate ('ATg4').</summary>
        DemonicGate_ATg4 = 879187009,
        /// <summary>Iron gate ('DTg5').</summary>
        IronGate_DTg5 = 895964228,
        /// <summary>Iron gate ('DTg6').</summary>
        IronGate_DTg6 = 912741444,
        /// <summary>Iron gate ('DTg7').</summary>
        IronGate_DTg7 = 929518660,
        /// <summary>Iron gate ('DTg8').</summary>
        IronGate_DTg8 = 946295876,
        /// <summary>Dungeon gate ('DTg1').</summary>
        DungeonGate_DTg1 = 828855364,
        /// <summary>Dungeon gate ('DTg2').</summary>
        DungeonGate_DTg2 = 845632580,
        /// <summary>Dungeon gate ('DTg3').</summary>
        DungeonGate_DTg3 = 862409796,
        /// <summary>Dungeon gate ('DTg4').</summary>
        DungeonGate_DTg4 = 879187012,
        /// <summary>Summer tree wall ('LTlt').</summary>
        SummerTreeWall = 1953256524,
        /// <summary>Northrend tree wall ('NTtw').</summary>
        NorthrendTreeWall = 2004112462,
        /// <summary>Winter tree wall ('WTtw').</summary>
        WinterTreeWall = 2004112471,
        /// <summary>Snowy tree wall ('WTst').</summary>
        SnowyTreeWall = 1953715287,
        /// <summary>Cityscape summer tree wall ('YTct').</summary>
        CityscapeSummerTreeWall = 1952666713,
        /// <summary>Cityscape winter tree wall ('YTwt').</summary>
        CityscapeWinterTreeWall = 1953977433,
        /// <summary>Cityscape snowy tree wall ('YTst').</summary>
        CityscapeSnowyTreeWall = 1953715289,
        /// <summary>Cityscape fall tree wall ('YTft').</summary>
        CityscapeFallTreeWall = 1952863321,
        /// <summary>Village tree wall ('VTlt').</summary>
        VillageTreeWall = 1953256534,
        /// <summary>Stone wall ('LTw0').</summary>
        StoneWall_LTw0 = 813126732,
        /// <summary>Stone wall ('LTw1').</summary>
        StoneWall_LTw1 = 829903948,
        /// <summary>Stone wall ('LTw2').</summary>
        StoneWall_LTw2 = 846681164,
        /// <summary>Stone wall ('LTw3').</summary>
        StoneWall_LTw3 = 863458380,
        /// <summary>Short natural bridge ('YT00').</summary>
        ShortNaturalBridge_YT00 = 808473689,
        /// <summary>Short natural bridge ('YT01').</summary>
        ShortNaturalBridge_YT01 = 825250905,
        /// <summary>Short natural bridge ('YT02').</summary>
        ShortNaturalBridge_YT02 = 842028121,
        /// <summary>Short natural bridge ('YT03').</summary>
        ShortNaturalBridge_YT03 = 858805337,
        /// <summary>Long natural bridge ('YT04').</summary>
        LongNaturalBridge_YT04 = 875582553,
        /// <summary>Long natural bridge ('YT05').</summary>
        LongNaturalBridge_YT05 = 892359769,
        /// <summary>Long natural bridge ('YT06').</summary>
        LongNaturalBridge_YT06 = 909136985,
        /// <summary>Long natural bridge ('YT07').</summary>
        LongNaturalBridge_YT07 = 925914201,
        /// <summary>Wide natural bridge ('YT08').</summary>
        WideNaturalBridge_YT08 = 942691417,
        /// <summary>Wide natural bridge ('YT09').</summary>
        WideNaturalBridge_YT09 = 959468633,
        /// <summary>Wide natural bridge ('YT10').</summary>
        WideNaturalBridge_YT10 = 808539225,
        /// <summary>Wide natural bridge ('YT11').</summary>
        WideNaturalBridge_YT11 = 825316441,
        /// <summary>Short stone bridge ('YT12').</summary>
        ShortStoneBridge_YT12 = 842093657,
        /// <summary>Short stone bridge ('YT13').</summary>
        ShortStoneBridge_YT13 = 858870873,
        /// <summary>Short stone bridge ('YT14').</summary>
        ShortStoneBridge_YT14 = 875648089,
        /// <summary>Short stone bridge ('YT15').</summary>
        ShortStoneBridge_YT15 = 892425305,
        /// <summary>Long stone bridge ('YT16').</summary>
        LongStoneBridge_YT16 = 909202521,
        /// <summary>Long stone bridge ('YT17').</summary>
        LongStoneBridge_YT17 = 925979737,
        /// <summary>Long stone bridge ('YT18').</summary>
        LongStoneBridge_YT18 = 942756953,
        /// <summary>Long stone bridge ('YT19').</summary>
        LongStoneBridge_YT19 = 959534169,
        /// <summary>Wide stone bridge ('YT20').</summary>
        WideStoneBridge_YT20 = 808604761,
        /// <summary>Wide stone bridge ('YT21').</summary>
        WideStoneBridge_YT21 = 825381977,
        /// <summary>Wide stone bridge ('YT22').</summary>
        WideStoneBridge_YT22 = 842159193,
        /// <summary>Wide stone bridge ('YT23').</summary>
        WideStoneBridge_YT23 = 858936409,
        /// <summary>Short wooden bridge ('LT00').</summary>
        ShortWoodenBridge_LT00 = 808473676,
        /// <summary>Short wooden bridge ('LT01').</summary>
        ShortWoodenBridge_LT01 = 825250892,
        /// <summary>Short wooden bridge ('LT02').</summary>
        ShortWoodenBridge_LT02 = 842028108,
        /// <summary>Short wooden bridge ('LT03').</summary>
        ShortWoodenBridge_LT03 = 858805324,
        /// <summary>Long wooden bridge ('LT04').</summary>
        LongWoodenBridge_LT04 = 875582540,
        /// <summary>Long wooden bridge ('LT05').</summary>
        LongWoodenBridge_LT05 = 892359756,
        /// <summary>Long wooden bridge ('LT06').</summary>
        LongWoodenBridge_LT06 = 909136972,
        /// <summary>Long wooden bridge ('LT07').</summary>
        LongWoodenBridge_LT07 = 925914188,
        /// <summary>Wide wooden bridge ('LT08').</summary>
        WideWoodenBridge_LT08 = 942691404,
        /// <summary>Wide wooden bridge ('LT09').</summary>
        WideWoodenBridge_LT09 = 959468620,
        /// <summary>Wide wooden bridge ('LT10').</summary>
        WideWoodenBridge_LT10 = 808539212,
        /// <summary>Wide wooden bridge ('LT11').</summary>
        WideWoodenBridge_LT11 = 825316428,
        /// <summary>Dalaran building ('XTbd').</summary>
        DalaranBuilding = 1684165720,
        /// <summary>Dalaran violet citadel ('XTvt').</summary>
        DalaranVioletCitadel = 1953911896,
        /// <summary>Stone ramp ('LTr1').</summary>
        StoneRamp_LTr1 = 829576268,
        /// <summary>Stone ramp ('LTr2').</summary>
        StoneRamp_LTr2 = 846353484,
        /// <summary>Stone ramp ('LTr3').</summary>
        StoneRamp_LTr3 = 863130700,
        /// <summary>Stone ramp ('LTr4').</summary>
        StoneRamp_LTr4 = 879907916,
        /// <summary>Stone ramp ('LTr5').</summary>
        StoneRamp_LTr5 = 896685132,
        /// <summary>Stone ramp ('LTr6').</summary>
        StoneRamp_LTr6 = 913462348,
        /// <summary>Stone ramp ('LTr7').</summary>
        StoneRamp_LTr7 = 930239564,
        /// <summary>Stone ramp ('LTr8').</summary>
        StoneRamp_LTr8 = 947016780,
        /// <summary>Ship ('NTbd').</summary>
        Ship = 1684165710,
        /// <summary>Egg sack ('DTes').</summary>
        EggSack = 1936020548,
        /// <summary>Dungeon tree wall ('DTsh').</summary>
        DungeonTreeWall = 1752388676,
        /// <summary>Bridge destroyed ('YSdb').</summary>
        BridgeDestroyed_YSdb = 1650742105,
        /// <summary>Bridge destroyed ('YSdc').</summary>
        BridgeDestroyed_YSdc = 1667519321,
        /// <summary>King s throne ('XOkt').</summary>
        KingSThrone = 1953189720,
        /// <summary>King s throne diagonal 1 ('XOk1').</summary>
        KingSThroneDiagonal1_XOk1 = 829116248,
        /// <summary>King s throne diagonal 1 ('XOk2').</summary>
        KingSThroneDiagonal1_XOk2 = 845893464,
        /// <summary>Cliff cave gate ('DTc1').</summary>
        CliffCaveGate_DTc1 = 828593220,
        /// <summary>Cliff cave gate ('DTc2').</summary>
        CliffCaveGate_DTc2 = 845370436,
        /// <summary>Dungeon spikes ('DTsp').</summary>
        DungeonSpikes = 1886606404,
        /// <summary>Rock chunks ('DTrc').</summary>
        RockChunks_DTrc = 1668437060,
        /// <summary>Force bridge ('DTs0').</summary>
        ForceBridge_DTs0 = 812864580,
        /// <summary>Force bridge ('DTs1').</summary>
        ForceBridge_DTs1 = 829641796,
        /// <summary>Force bridge ('DTs2').</summary>
        ForceBridge_DTs2 = 846419012,
        /// <summary>Force bridge ('DTs3').</summary>
        ForceBridge_DTs3 = 863196228,
        /// <summary>Force wall ('Dofw').</summary>
        ForceWall_Dofw = 2003201860,
        /// <summary>Force wall ('Dofv').</summary>
        ForceWall_Dofv = 1986424644,
        /// <summary>Short natural bridge ('YT24').</summary>
        ShortNaturalBridge_YT24 = 875713625,
        /// <summary>Short natural bridge ('YT25').</summary>
        ShortNaturalBridge_YT25 = 892490841,
        /// <summary>Short natural bridge ('YT26').</summary>
        ShortNaturalBridge_YT26 = 909268057,
        /// <summary>Short natural bridge ('YT27').</summary>
        ShortNaturalBridge_YT27 = 926045273,
        /// <summary>Long natural bridge ('YT28').</summary>
        LongNaturalBridge_YT28 = 942822489,
        /// <summary>Long natural bridge ('YT29').</summary>
        LongNaturalBridge_YT29 = 959599705,
        /// <summary>Long natural bridge ('YT30').</summary>
        LongNaturalBridge_YT30 = 808670297,
        /// <summary>Long natural bridge ('YT31').</summary>
        LongNaturalBridge_YT31 = 825447513,
        /// <summary>Wide natural bridge ('YT32').</summary>
        WideNaturalBridge_YT32 = 842224729,
        /// <summary>Wide natural bridge ('YT33').</summary>
        WideNaturalBridge_YT33 = 859001945,
        /// <summary>Wide natural bridge ('YT34').</summary>
        WideNaturalBridge_YT34 = 875779161,
        /// <summary>Wide natural bridge ('YT35').</summary>
        WideNaturalBridge_YT35 = 892556377,
        /// <summary>Short stone bridge ('YT36').</summary>
        ShortStoneBridge_YT36 = 909333593,
        /// <summary>Short stone bridge ('YT37').</summary>
        ShortStoneBridge_YT37 = 926110809,
        /// <summary>Short stone bridge ('YT38').</summary>
        ShortStoneBridge_YT38 = 942888025,
        /// <summary>Short stone bridge ('YT39').</summary>
        ShortStoneBridge_YT39 = 959665241,
        /// <summary>Long stone bridge ('YT40').</summary>
        LongStoneBridge_YT40 = 808735833,
        /// <summary>Long stone bridge ('YT41').</summary>
        LongStoneBridge_YT41 = 825513049,
        /// <summary>Long stone bridge ('YT42').</summary>
        LongStoneBridge_YT42 = 842290265,
        /// <summary>Long stone bridge ('YT43').</summary>
        LongStoneBridge_YT43 = 859067481,
        /// <summary>Wide stone bridge ('YT44').</summary>
        WideStoneBridge_YT44 = 875844697,
        /// <summary>Wide stone bridge ('YT45').</summary>
        WideStoneBridge_YT45 = 892621913,
        /// <summary>Wide stone bridge ('YT46').</summary>
        WideStoneBridge_YT46 = 909399129,
        /// <summary>Wide stone bridge ('YT47').</summary>
        WideStoneBridge_YT47 = 926176345,
        /// <summary>Ramp naga small left ('ZTr0').</summary>
        RampNagaSmallLeft = 812799066,
        /// <summary>Ramp naga small top ('ZTr1').</summary>
        RampNagaSmallTop = 829576282,
        /// <summary>Ramp naga small right ('ZTr2').</summary>
        RampNagaSmallRight = 846353498,
        /// <summary>Ramp naga small bottom ('ZTr3').</summary>
        RampNagaSmallBottom = 863130714,
        /// <summary>Ruins tree wall ('ZTtw').</summary>
        RuinsTreeWall = 2004112474,
        /// <summary>Stone wall ('ZTw0').</summary>
        StoneWall_ZTw0 = 813126746,
        /// <summary>Stone wall ('ZTw1').</summary>
        StoneWall_ZTw1 = 829903962,
        /// <summary>Stone wall ('ZTw2').</summary>
        StoneWall_ZTw2 = 846681178,
        /// <summary>Stone wall ('ZTw3').</summary>
        StoneWall_ZTw3 = 863458394,
        /// <summary>Ruined gate ('ZTg1').</summary>
        RuinedGate_ZTg1 = 828855386,
        /// <summary>Ruined gate ('ZTg2').</summary>
        RuinedGate_ZTg2 = 845632602,
        /// <summary>Ruined gate ('ZTg3').</summary>
        RuinedGate_ZTg3 = 862409818,
        /// <summary>Ruined gate ('ZTg4').</summary>
        RuinedGate_ZTg4 = 879187034,
        /// <summary>Icecrown tree wall ('ITtw').</summary>
        IcecrownTreeWall = 2004112457,
        /// <summary>Rolling stone door ('ZTd1').</summary>
        RollingStoneDoor_ZTd1 = 828658778,
        /// <summary>Rolling stone door ('ZTd2').</summary>
        RollingStoneDoor_ZTd2 = 845435994,
        /// <summary>Rolling stone door ('ZTd3').</summary>
        RollingStoneDoor_ZTd3 = 862213210,
        /// <summary>Rolling stone door ('ZTd4').</summary>
        RollingStoneDoor_ZTd4 = 878990426,
        /// <summary>Rolling stone door ('ZTd5').</summary>
        RollingStoneDoor_ZTd5 = 895767642,
        /// <summary>Rolling stone door ('ZTd6').</summary>
        RollingStoneDoor_ZTd6 = 912544858,
        /// <summary>Rolling stone door ('ZTd7').</summary>
        RollingStoneDoor_ZTd7 = 929322074,
        /// <summary>Rolling stone door ('ZTd8').</summary>
        RollingStoneDoor_ZTd8 = 946099290,
        /// <summary>Ice bridge ('ITib').</summary>
        IceBridge_ITib = 1651070025,
        /// <summary>Ice bridge ('ITi2').</summary>
        IceBridge_ITi2 = 845763657,
        /// <summary>Ice bridge ('ITi3').</summary>
        IceBridge_ITi3 = 862540873,
        /// <summary>Ice bridge ('ITi4').</summary>
        IceBridge_ITi4 = 879318089,
        /// <summary>Icy gate ('ITg1').</summary>
        IcyGate_ITg1 = 828855369,
        /// <summary>Icy gate ('ITg2').</summary>
        IcyGate_ITg2 = 845632585,
        /// <summary>Icy gate ('ITg3').</summary>
        IcyGate_ITg3 = 862409801,
        /// <summary>Icy gate ('ITg4').</summary>
        IcyGate_ITg4 = 879187017,
        /// <summary>Stone wall ('ITw0').</summary>
        StoneWall_ITw0 = 813126729,
        /// <summary>Stone wall ('ITw1').</summary>
        StoneWall_ITw1 = 829903945,
        /// <summary>Stone wall ('ITw2').</summary>
        StoneWall_ITw2 = 846681161,
        /// <summary>Stone wall ('ITw3').</summary>
        StoneWall_ITw3 = 863458377,
        /// <summary>Tree bridge ('LTt0').</summary>
        TreeBridge_LTt0 = 812930124,
        /// <summary>Tree bridge ('LTt1').</summary>
        TreeBridge_LTt1 = 829707340,
        /// <summary>Tree bridge ('LTt2').</summary>
        TreeBridge_LTt2 = 846484556,
        /// <summary>Tree bridge ('LTt3').</summary>
        TreeBridge_LTt3 = 863261772,
        /// <summary>Tree bridge ('LTt4').</summary>
        TreeBridge_LTt4 = 880038988,
        /// <summary>Tree bridge ('ATt0').</summary>
        TreeBridge_ATt0 = 812930113,
        /// <summary>Tree bridge ('ATt1').</summary>
        TreeBridge_ATt1 = 829707329,
        /// <summary>Tree bridge ('LTt5').</summary>
        TreeBridge_LTt5 = 896816204,
        /// <summary>Ruins naga circle ('ZTnc').</summary>
        RuinsNagaCircle = 1668174938,
        /// <summary>Ice floe ('ITf1').</summary>
        IceFloe_ITf1 = 828789833,
        /// <summary>Ice floe ('ITf2').</summary>
        IceFloe_ITf2 = 845567049,
        /// <summary>Ice floe ('ITf3').</summary>
        IceFloe_ITf3 = 862344265,
        /// <summary>Ice floe ('ITf4').</summary>
        IceFloe_ITf4 = 879121481,
        /// <summary>Ice rock gate ('ITx1').</summary>
        IceRockGate_ITx1 = 829969481,
        /// <summary>Ice rock gate ('ITx2').</summary>
        IceRockGate_ITx2 = 846746697,
        /// <summary>Ice rock gate ('ITx3').</summary>
        IceRockGate_ITx3 = 863523913,
        /// <summary>Ice rock gate ('ITx4').</summary>
        IceRockGate_ITx4 = 880301129,
        /// <summary>Ashenvale canopy tree ('ATtc').</summary>
        AshenvaleCanopyTree = 1668568129,
        /// <summary>Outland tree wall ('OTtw').</summary>
        OutlandTreeWall = 2004112463,
        /// <summary>Black citadel tree wall ('KTtw').</summary>
        BlackCitadelTreeWall = 2004112459,
        /// <summary>Igloo ('ITig').</summary>
        Igloo = 1734956105,
        /// <summary>Elevator ('DTrf').</summary>
        Elevator_DTrf = 1718768708,
        /// <summary>Elevator ('DTrx').</summary>
        Elevator_DTrx = 2020758596,
        /// <summary>Magical pen ('XTmp').</summary>
        MagicalPen_XTmp = 1886213208,
        /// <summary>Magical pen ('XTm5').</summary>
        MagicalPen_XTm5 = 896357464,
        /// <summary>Magical pen wall ('XTmx').</summary>
        MagicalPenWall_XTmx = 2020430936,
        /// <summary>Magical pen wall ('XTx5').</summary>
        MagicalPenWall_XTx5 = 897078360,
        /// <summary>Icey rock ('ITcr').</summary>
        IceyRock = 1919112265,
        /// <summary>Elevator wall ('DTep').</summary>
        ElevatorWall = 1885688900,
        /// <summary>Wharf ('ATwf').</summary>
        Wharf = 1719096385,
        /// <summary>Pathing blocker both ('YTfb').</summary>
        PathingBlockerBoth = 1650873433,
        /// <summary>Pathing blocker both large ('YTfc').</summary>
        PathingBlockerBothLarge = 1667650649,
        /// <summary>Line of sight blocker ('YTlb').</summary>
        LineOfSightBlocker = 1651266649,
        /// <summary>Line of sight blocker large ('Ytlc').</summary>
        LineOfSightBlockerLarge = 1668052057,
        /// <summary>Pathing blocker ground ('YTpb').</summary>
        PathingBlockerGround = 1651528793,
        /// <summary>Pathing blocker ground large ('YTpc').</summary>
        PathingBlockerGroundLarge = 1668306009,
        /// <summary>Pathing blocker air ('YTab').</summary>
        PathingBlockerAir = 1650545753,
        /// <summary>Pathing blocker air large ('YTac').</summary>
        PathingBlockerAirLarge = 1667322969,
        /// <summary>Massive ruined gate ('ZTsg').</summary>
        MassiveRuinedGate_ZTsg = 1735611482,
        /// <summary>Massive ruined gate ('ZTsx').</summary>
        MassiveRuinedGate_ZTsx = 2020824154,
        /// <summary>Foot switch ('DTfp').</summary>
        FootSwitch_DTfp = 1885754436,
        /// <summary>Foot switch ('DTfx').</summary>
        FootSwitch_DTfx = 2019972164,
        /// <summary>Lever ('DTlv').</summary>
        Lever = 1986810948,
        /// <summary>City entrance ('YTce').</summary>
        CityEntrance_YTce = 1701008473,
        /// <summary>City entrance ('YTcx').</summary>
        CityEntrance_YTcx = 2019775577,
        /// <summary>Last hope bridge ('LTtc').</summary>
        LastHopeBridge_LTtc = 1668568140,
        /// <summary>Last hope bridge ('LTtx').</summary>
        LastHopeBridge_LTtx = 2020889676,
        /// <summary>Cityscape ruined tree wall ('JTct').</summary>
        CityscapeRuinedTreeWall = 1952666698,
        /// <summary>Dalaran ruins tree wall ('JTtw').</summary>
        DalaranRuinsTreeWall = 2004112458,
        /// <summary>Frozen throne gate ('ITtg').</summary>
        FrozenThroneGate = 1735677001,
        /// <summary>Underground tree wall ('GTsh').</summary>
        UndergroundTreeWall = 1752388679,
        /// <summary>Resurrection stone ('BTrs').</summary>
        ResurrectionStone_BTrs = 1936872514,
        /// <summary>Resurrection stone ('BTrx').</summary>
        ResurrectionStone_BTrx = 2020758594,
        /// <summary>Shimmering portal ('OTsp').</summary>
        ShimmeringPortal = 1886606415,
        /// <summary>Invisible platform ('OTip').</summary>
        InvisiblePlatform = 1885951055,
        /// <summary>Invisible platform small ('OTis').</summary>
        InvisiblePlatformSmall = 1936282703,
        /// <summary>Barrens canopy tree ('BTtc').</summary>
        BarrensCanopyTree = 1668568130,
        /// <summary>Felwood canopy tree ('CTtc').</summary>
        FelwoodCanopyTree = 1668568131,
        /// <summary>Northrend canopy tree ('NTtc').</summary>
        NorthrendCanopyTree = 1668568142,
        /// <summary>Ruins canopy tree ('ZTtc').</summary>
        RuinsCanopyTree = 1668568154,
        /// <summary>Icecrown canopy tree ('ITtc').</summary>
        IcecrownCanopyTree = 1668568137,
        /// <summary>Icecrown throne ('IOt0').</summary>
        IcecrownThrone = 812928841,
        /// <summary>Icecrown throne diagonal 1 ('IOt1').</summary>
        IcecrownThroneDiagonal1_IOt1 = 829706057,
        /// <summary>Icecrown throne diagonal 1 ('IOt2').</summary>
        IcecrownThroneDiagonal1_IOt2 = 846483273,
        /// <summary>Rock chunks ('LTrc').</summary>
        RockChunks_LTrc = 1668437068,
        /// <summary>Rock chunks ('LTrt').</summary>
        RockChunks_LTrt = 1953649740,
        /// <summary>Extra wide natural bridge ('YT48').</summary>
        ExtraWideNaturalBridge_YT48 = 942953561,
        /// <summary>Extra wide natural bridge ('YT49').</summary>
        ExtraWideNaturalBridge_YT49 = 959730777,
        /// <summary>Extra wide natural bridge ('YT50').</summary>
        ExtraWideNaturalBridge_YT50 = 808801369,
        /// <summary>Extra wide natural bridge ('YT51').</summary>
        ExtraWideNaturalBridge_YT51 = 825578585,
        /// <summary>Demon storm ('OTds').</summary>
        DemonStorm = 1935955023,
        /// <summary>Rockin arthas ('ITag').</summary>
        RockinArthas = 1734431817,
        /// <summary>Support column ('BTsc').</summary>
        SupportColumn = 1668502594,
        /// <summary>Stone ramp ('LTs1').</summary>
        StoneRamp_LTs1 = 829641804,
        /// <summary>Stone ramp ('LTs2').</summary>
        StoneRamp_LTs2 = 846419020,
        /// <summary>Stone ramp ('LTs3').</summary>
        StoneRamp_LTs3 = 863196236,
        /// <summary>Stone ramp ('LTs4').</summary>
        StoneRamp_LTs4 = 879973452,
        /// <summary>Stone ramp ('LTs5').</summary>
        StoneRamp_LTs5 = 896750668,
        /// <summary>Stone ramp ('LTs6').</summary>
        StoneRamp_LTs6 = 913527884,
        /// <summary>Stone ramp ('LTs7').</summary>
        StoneRamp_LTs7 = 930305100,
        /// <summary>Stone ramp ('LTs8').</summary>
        StoneRamp_LTs8 = 947082316,
        /// <summary>Volcano ('Volc').</summary>
        Volcano = 1668050774,
        /// <summary>Silvermoon tree ('Yts1').</summary>
        SilvermoonTree = 829650009,
        /// <summary>Icecrown citadel entrance ('YTc1').</summary>
        IcecrownCitadelEntrance = 828593241,
        /// <summary>Lordaeron city main gate ('YTc2').</summary>
        LordaeronCityMainGate = 845370457,
        /// <summary>Lordaeron city main gate column ('BTsk').</summary>
        LordaeronCityMainGateColumn = 1802720322,
        /// <summary>Lordaeron city main gate destroyed ('YTc4').</summary>
        LordaeronCityMainGateDestroyed = 878924889,
        /// <summary>Lordaeron city main gate column destroyed ('BTs1').</summary>
        LordaeronCityMainGateColumnDestroyed = 829641794,
        /// <summary>Lion statue ('BTs2').</summary>
        LionStatue = 846419010,
        /// <summary>Lion statue destroyed ('BTs3').</summary>
        LionStatueDestroyed = 863196226,
        /// <summary>Lordaeron city spire ('BTs4').</summary>
        LordaeronCitySpire = 879973442,
        /// <summary>Lordaeron city spire destroyed ('BTs5').</summary>
        LordaeronCitySpireDestroyed = 896750658,
        /// <summary>Lordaeron city dome ('XTv1').</summary>
        LordaeronCityDome = 829838424,
        /// <summary>Lordaeron city dome destroyed ('XTv2').</summary>
        LordaeronCityDomeDestroyed = 846615640,
        /// <summary>Lordaeron city main building ('XTv3').</summary>
        LordaeronCityMainBuilding = 863392856,
        /// <summary>Lordaeron city main building destroyed ('XTv4').</summary>
        LordaeronCityMainBuildingDestroyed = 880170072,
        /// <summary>Orgrimmar wall segment under construction ('XTv5').</summary>
        OrgrimmarWallSegmentUnderConstruction = 896947288,
        /// <summary>Orgrimmar wall segment completed ('XTv6').</summary>
        OrgrimmarWallSegmentCompleted = 913724504,
        /// <summary>Orgrimmar tower under construction ('XTv7').</summary>
        OrgrimmarTowerUnderConstruction = 930501720,
        /// <summary>Orgrimmar tower completed ('XTv8').</summary>
        OrgrimmarTowerCompleted = 947278936,
        /// <summary>Orgrimmar gate ('YTcn').</summary>
        OrgrimmarGate = 1852003417,
        /// <summary>Special ice bridge ('YT66').</summary>
        SpecialIceBridge = 909530201,
        /// <summary>Elven bridge ('YT67').</summary>
        ElvenBridge = 926307417,
        /// <summary>Short stratholme bridge ('YY12').</summary>
        ShortStratholmeBridge_YY12 = 842094937,
        /// <summary>Short stratholme bridge ('YY13').</summary>
        ShortStratholmeBridge_YY13 = 858872153,
        /// <summary>Short stratholme bridge ('YY14').</summary>
        ShortStratholmeBridge_YY14 = 875649369,
        /// <summary>Short stratholme bridge ('YY15').</summary>
        ShortStratholmeBridge_YY15 = 892426585,
        /// <summary>Long stratholme bridge ('YY16').</summary>
        LongStratholmeBridge_YY16 = 909203801,
        /// <summary>Long stratholme bridge ('YY17').</summary>
        LongStratholmeBridge_YY17 = 925981017,
        /// <summary>Long stratholme bridge ('YY18').</summary>
        LongStratholmeBridge_YY18 = 942758233,
        /// <summary>Long stratholme bridge ('YY19').</summary>
        LongStratholmeBridge_YY19 = 959535449,
        /// <summary>Wide stratholme bridge ('YY20').</summary>
        WideStratholmeBridge_YY20 = 808606041,
        /// <summary>Wide stratholme bridge ('YY21').</summary>
        WideStratholmeBridge_YY21 = 825383257,
        /// <summary>Wide stratholme bridge ('YY22').</summary>
        WideStratholmeBridge_YY22 = 842160473,
        /// <summary>Wide stratholme bridge ('YY23').</summary>
        WideStratholmeBridge_YY23 = 858937689,
        /// <summary>Short overgrown bridge ('OG00').</summary>
        ShortOvergrownBridge_OG00 = 808470351,
        /// <summary>Short overgrown bridge ('OG01').</summary>
        ShortOvergrownBridge_OG01 = 825247567,
        /// <summary>Short overgrown bridge ('OG02').</summary>
        ShortOvergrownBridge_OG02 = 842024783,
        /// <summary>Short overgrown bridge ('OG03').</summary>
        ShortOvergrownBridge_OG03 = 858801999,
        /// <summary>Long overgrown bridge ('OG04').</summary>
        LongOvergrownBridge_OG04 = 875579215,
        /// <summary>Long overgrown bridge ('OG05').</summary>
        LongOvergrownBridge_OG05 = 892356431,
        /// <summary>Long overgrown bridge ('OG06').</summary>
        LongOvergrownBridge_OG06 = 909133647,
        /// <summary>Long overgrown bridge ('OG07').</summary>
        LongOvergrownBridge_OG07 = 925910863,
        /// <summary>Wide overgrown bridge ('OG08').</summary>
        WideOvergrownBridge_OG08 = 942688079,
        /// <summary>Wide overgrown bridge ('OG09').</summary>
        WideOvergrownBridge_OG09 = 959465295,
        /// <summary>Wide overgrown bridge ('OG10').</summary>
        WideOvergrownBridge_OG10 = 808535887,
        /// <summary>Wide overgrown bridge ('OG11').</summary>
        WideOvergrownBridge_OG11 = 825313103,
        /// <summary>Short rickety wooden bridge ('RW00').</summary>
        ShortRicketyWoodenBridge_RW00 = 808474450,
        /// <summary>Short rickety wooden bridge ('RW01').</summary>
        ShortRicketyWoodenBridge_RW01 = 825251666,
        /// <summary>Short rickety wooden bridge ('RW02').</summary>
        ShortRicketyWoodenBridge_RW02 = 842028882,
        /// <summary>Short rickety wooden bridge ('RW03').</summary>
        ShortRicketyWoodenBridge_RW03 = 858806098,
        /// <summary>Long rickety wooden bridge ('RW04').</summary>
        LongRicketyWoodenBridge_RW04 = 875583314,
        /// <summary>Long rickety wooden bridge ('RW05').</summary>
        LongRicketyWoodenBridge_RW05 = 892360530,
        /// <summary>Long rickety wooden bridge ('RW06').</summary>
        LongRicketyWoodenBridge_RW06 = 909137746,
        /// <summary>Long rickety wooden bridge ('RW07').</summary>
        LongRicketyWoodenBridge_RW07 = 925914962,
        /// <summary>Wide rickety wooden bridge ('RW08').</summary>
        WideRicketyWoodenBridge_RW08 = 942692178,
        /// <summary>Wide rickety wooden bridge ('RW09').</summary>
        WideRicketyWoodenBridge_RW09 = 959469394,
        /// <summary>Wide rickety wooden bridge ('RW10').</summary>
        WideRicketyWoodenBridge_RW10 = 808539986,
        /// <summary>Wide rickety wooden bridge ('RW11').</summary>
        WideRicketyWoodenBridge_RW11 = 825317202,
        /// <summary>Short elven bridge ('EB00').</summary>
        ShortElvenBridge_EB00 = 808469061,
        /// <summary>Short elven bridge ('EB01').</summary>
        ShortElvenBridge_EB01 = 825246277,
        /// <summary>Short elven bridge ('EB02').</summary>
        ShortElvenBridge_EB02 = 842023493,
        /// <summary>Short elven bridge ('EB03').</summary>
        ShortElvenBridge_EB03 = 858800709,
        /// <summary>Long elven bridge ('EB04').</summary>
        LongElvenBridge_EB04 = 875577925,
        /// <summary>Long elven bridge ('EB05').</summary>
        LongElvenBridge_EB05 = 892355141,
        /// <summary>Long elven bridge ('EB06').</summary>
        LongElvenBridge_EB06 = 909132357,
        /// <summary>Long elven bridge ('EB07').</summary>
        LongElvenBridge_EB07 = 925909573,
        /// <summary>Wide elven bridge ('EB08').</summary>
        WideElvenBridge_EB08 = 942686789,
        /// <summary>Wide elven bridge ('EB09').</summary>
        WideElvenBridge_EB09 = 959464005,
        /// <summary>Wide elven bridge ('EB10').</summary>
        WideElvenBridge_EB10 = 808534597,
        /// <summary>Wide elven bridge ('EB11').</summary>
        WideElvenBridge_EB11 = 825311813,
        /// <summary>Short night elven wooden bridge ('NB00').</summary>
        ShortNightElvenWoodenBridge_NB00 = 808469070,
        /// <summary>Short night elven wooden bridge ('NB01').</summary>
        ShortNightElvenWoodenBridge_NB01 = 825246286,
        /// <summary>Short night elven wooden bridge ('NB02').</summary>
        ShortNightElvenWoodenBridge_NB02 = 842023502,
        /// <summary>Short night elven wooden bridge ('NB03').</summary>
        ShortNightElvenWoodenBridge_NB03 = 858800718,
        /// <summary>Long night elven wooden bridge ('NB04').</summary>
        LongNightElvenWoodenBridge_NB04 = 875577934,
        /// <summary>Long night elven wooden bridge ('NB05').</summary>
        LongNightElvenWoodenBridge_NB05 = 892355150,
        /// <summary>Long night elven wooden bridge ('NB06').</summary>
        LongNightElvenWoodenBridge_NB06 = 909132366,
        /// <summary>Long night elven wooden bridge ('NB07').</summary>
        LongNightElvenWoodenBridge_NB07 = 925909582,
        /// <summary>Wide night elven wooden bridge ('NB08').</summary>
        WideNightElvenWoodenBridge_NB08 = 942686798,
        /// <summary>Wide night elven wooden bridge ('NB09').</summary>
        WideNightElvenWoodenBridge_NB09 = 959464014,
        /// <summary>Wide night elven wooden bridge ('NB10').</summary>
        WideNightElvenWoodenBridge_NB10 = 808534606,
        /// <summary>Wide night elven wooden bridge ('NB11').</summary>
        WideNightElvenWoodenBridge_NB11 = 825311822,
        /// <summary>Scorched tree wall ('Ytsc').</summary>
        ScorchedTreeWall = 1668510809,
        /// <summary>Rolling stone door ('ITd1').</summary>
        RollingStoneDoor_ITd1 = 828658761,
        /// <summary>Rolling stone door ('ITd2').</summary>
        RollingStoneDoor_ITd2 = 845435977,
        /// <summary>Rolling stone door ('ITd3').</summary>
        RollingStoneDoor_ITd3 = 862213193,
        /// <summary>Rolling stone door ('ITd4').</summary>
        RollingStoneDoor_ITd4 = 878990409,
        /// <summary>Waygate ramp ('WGTR').</summary>
        WaygateRamp = 1381254999,
        /// <summary>Northrend icy tree wall ('NTiw').</summary>
        NorthrendIcyTreeWall = 2003391566
    }
}