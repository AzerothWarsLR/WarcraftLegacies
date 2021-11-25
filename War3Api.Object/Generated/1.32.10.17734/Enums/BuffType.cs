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
    public enum BuffType
    {
        /// <summary>Pause ('BPSE').</summary>
        Pause = 1163087938,
        /// <summary>Stun ('BSTN').</summary>
        Stun = 1314149186,
        /// <summary>Cargo hold death ('Bchd').</summary>
        CargoHoldDeath = 1684562754,
        /// <summary>Defense ('Bdef').</summary>
        Defense = 1717920834,
        /// <summary>Detected ('Bdet').</summary>
        Detected = 1952801858,
        /// <summary>Freeze ('Bfre').</summary>
        Freeze = 1701996098,
        /// <summary>Frost ('Bfro').</summary>
        Frost = 1869768258,
        /// <summary>Invulnerable ('Bvul').</summary>
        Invulnerable = 1819637314,
        /// <summary>Poison attack ('Bpoi').</summary>
        PoisonAttack = 1768910914,
        /// <summary>Poison attack stack do t ('Bpsd').</summary>
        PoisonAttackStackDoT = 1685286978,
        /// <summary>Poison attack stack info ('Bpsi').</summary>
        PoisonAttackStackInfo = 1769173058,
        /// <summary>Shared vision ('Bsha').</summary>
        SharedVision = 1634235202,
        /// <summary>Speed bonus ('Bspe').</summary>
        SpeedBonus = 1701868354,
        /// <summary>Teleport reveal ('Btrv').</summary>
        TeleportReveal = 1987212354,
        /// <summary>Cloud of fog ('Bclf').</summary>
        CloudOfFog_Bclf = 1718379330,
        /// <summary>Control magic ('Bcmg').</summary>
        ControlMagic = 1735222082,
        /// <summary>Heal ('Bhea').</summary>
        Heal = 1634035778,
        /// <summary>Inner fire ('Binf').</summary>
        InnerFire = 1718511938,
        /// <summary>Invisibility ('Binv').</summary>
        Invisibility_Binv = 1986947394,
        /// <summary>Magic leash caster ('Bmlc').</summary>
        MagicLeashCaster = 1668050242,
        /// <summary>Magic leash target ('Bmlt').</summary>
        MagicLeashTarget = 1953262914,
        /// <summary>Militia ('Bmil').</summary>
        Militia = 1818848578,
        /// <summary>Phoenix fire ('Bpxf').</summary>
        PhoenixFire = 1719169090,
        /// <summary>Phoenix ('Bphx').</summary>
        Phoenix = 2020110402,
        /// <summary>Polymorph ('Bply').</summary>
        Polymorph = 2037149762,
        /// <summary>Slow ('Bslo').</summary>
        Slow = 1869378370,
        /// <summary>Aura brilliance ('BHab').</summary>
        AuraBrilliance = 1650542658,
        /// <summary>Aura devotion ('BHad').</summary>
        AuraDevotion = 1684097090,
        /// <summary>Avatar ('BHav').</summary>
        Avatar = 1986086978,
        /// <summary>Banish ('BHbn').</summary>
        Banish = 1851934786,
        /// <summary>Blizzard ('BHbd').</summary>
        Blizzard_BHbd = 1684162626,
        /// <summary>Blizzard aoe ('BHbz').</summary>
        BlizzardAoe = 2053261378,
        /// <summary>Divine shield ('BHds').</summary>
        DivineShield = 1935951938,
        /// <summary>Drain caster ('Bdcb').</summary>
        DrainCaster = 1650680898,
        /// <summary>Drain caster life ('Bdcl').</summary>
        DrainCasterLife = 1818453058,
        /// <summary>Drain caster mana ('Bdcm').</summary>
        DrainCasterMana = 1835230274,
        /// <summary>Drain target ('Bdtb').</summary>
        DrainTarget = 1651795010,
        /// <summary>Drain target life ('Bdtl').</summary>
        DrainTargetLife = 1819567170,
        /// <summary>Drain target mana ('Bdtm').</summary>
        DrainTargetMana = 1836344386,
        /// <summary>Flame strike ('BHfs').</summary>
        FlameStrike_BHfs = 1936083010,
        /// <summary>Thunder clap ('BHtc').</summary>
        ThunderClap = 1668565058,
        /// <summary>Water elemental ('BHwe').</summary>
        WaterElemental = 1702316098,
        /// <summary>Aura koto beast ('Bakb').</summary>
        AuraKotoBeast = 1651204418,
        /// <summary>Aura regen life ('Boar').</summary>
        AuraRegenLife = 1918988098,
        /// <summary>Aura regen mana ('Barm').</summary>
        AuraRegenMana = 1836212546,
        /// <summary>Balls of fire ('Bbof').</summary>
        BallsOfFire_Bbof = 1718575682,
        /// <summary>Berserker rage ('Bbsk').</summary>
        BerserkerRage = 1802723906,
        /// <summary>Bloodlust ('Bblo').</summary>
        Bloodlust = 1869374018,
        /// <summary>Devour vision ('Bdvv').</summary>
        DevourVision = 1987470402,
        /// <summary>Digesting ('Bdig').</summary>
        Digesting = 1734960194,
        /// <summary>Ensnare ('Bens').</summary>
        Ensnare = 1936614722,
        /// <summary>Ensnare air ('Bena').</summary>
        EnsnareAir = 1634624834,
        /// <summary>Ensnare ground ('Beng').</summary>
        EnsnareGround = 1735288130,
        /// <summary>Evil eye ('Beye').</summary>
        EvilEye = 1702454594,
        /// <summary>Healing ward ('Bhwd').</summary>
        HealingWard = 1685547074,
        /// <summary>Lightning shield ('Blsh').</summary>
        LightningShield = 1752394818,
        /// <summary>Lightning shield aoe ('Blsa').</summary>
        LightningShieldAoe = 1634954306,
        /// <summary>Liquid fire ('Bliq').</summary>
        LiquidFire = 1902734402,
        /// <summary>Purge ('Bprg').</summary>
        Purge = 1735553090,
        /// <summary>Spirit link ('Bspl').</summary>
        SpiritLink = 1819308866,
        /// <summary>Stasis trap trigger ('Bstt').</summary>
        StasisTrapTrigger = 1953788738,
        /// <summary>Aura command ('BOac').</summary>
        AuraCommand = 1667321666,
        /// <summary>Aura endurance ('BOae').</summary>
        AuraEndurance = 1700876098,
        /// <summary>Earthquake ('BOeq').</summary>
        Earthquake_BOeq = 1902464834,
        /// <summary>Earthquake aoe ('BOea').</summary>
        EarthquakeAoe = 1634029378,
        /// <summary>Hex ('BOhx').</summary>
        Hex = 2020101954,
        /// <summary>Mirror image ('BOmi').</summary>
        MirrorImage = 1768771394,
        /// <summary>Shockwave ('BOsh').</summary>
        Shockwave = 1752387394,
        /// <summary>Spirit wolf ('BOsf').</summary>
        SpiritWolf = 1718832962,
        /// <summary>Voodoo ('BOvd').</summary>
        Voodoo = 1685475138,
        /// <summary>Voodoo caster ('BOvc').</summary>
        VoodooCaster = 1668697922,
        /// <summary>Ward ('BOwd').</summary>
        Ward = 1685540674,
        /// <summary>Whirlwind aoe ('BOww').</summary>
        WhirlwindAoe = 2004307778,
        /// <summary>Wind walk ('BOwk').</summary>
        WindWalk = 1802981186,
        /// <summary>Barkskin ('Bbar').</summary>
        Barkskin = 1918984770,
        /// <summary>Corrosive breath ('Bcor').</summary>
        CorrosiveBreath = 1919902530,
        /// <summary>Cyclone ('Bcyc').</summary>
        Cyclone = 1668899650,
        /// <summary>Cyclone two ('Bcy2').</summary>
        CycloneTwo = 846816066,
        /// <summary>Eat tree ('Beat').</summary>
        EatTree = 1952539970,
        /// <summary>Faerie fire ('Bfae').</summary>
        FaerieFire = 1700881986,
        /// <summary>Grab tree ('Bgra').</summary>
        GrabTree = 1634887490,
        /// <summary>Mana flare ('Bmfl').</summary>
        ManaFlare = 1818651970,
        /// <summary>Mana flare aoe ('Bmfa').</summary>
        ManaFlareAoe = 1634102594,
        /// <summary>Phase shift ('Bpsh').</summary>
        PhaseShift = 1752395842,
        /// <summary>Wisp phase shift ('Bps1').</summary>
        WispPhaseShift = 829648962,
        /// <summary>Rejuvination ('Brej').</summary>
        Rejuvination = 1785033282,
        /// <summary>Roar ('Broa').</summary>
        Roar = 1634693698,
        /// <summary>Slow poison ('Bspo').</summary>
        SlowPoison = 1869640514,
        /// <summary>Slow poison stack do t ('Bssd').</summary>
        SlowPoisonStackDoT = 1685287746,
        /// <summary>Slow poison stack info ('Bssi').</summary>
        SlowPoisonStackInfo = 1769173826,
        /// <summary>Vengeance ('Bvng').</summary>
        Vengeance = 1735292482,
        /// <summary>Aura thorns ('BEah').</summary>
        AuraThorns = 1751205186,
        /// <summary>Aura trueshot ('BEar').</summary>
        AuraTrueshot = 1918977346,
        /// <summary>Entangling roots ('BEer').</summary>
        EntanglingRoots = 1919239490,
        /// <summary>Force of nature ('BEfn').</summary>
        ForceOfNature = 1852196162,
        /// <summary>Immolation ('BEim').</summary>
        Immolation = 1835615554,
        /// <summary>Immolation aoe ('BEia').</summary>
        ImmolationAoe = 1634288962,
        /// <summary>Metamorphosis ('BEme').</summary>
        Metamorphosis = 1701659970,
        /// <summary>Scout ('BEst').</summary>
        Scout = 1953711426,
        /// <summary>Shadow strike ('BEsh').</summary>
        ShadowStrike = 1752384834,
        /// <summary>Spirit of vengeance ('BEsv').</summary>
        SpiritOfVengeance = 1987265858,
        /// <summary>Anti magic shell ('Bams').</summary>
        AntiMagicShell = 1936548162,
        /// <summary>Anti magic shell matrix ('Bam2').</summary>
        AntiMagicShellMatrix = 846029122,
        /// <summary>Aura blight regen ('Babr').</summary>
        AuraBlightRegen = 1919050050,
        /// <summary>Aura plague ('Bapl').</summary>
        AuraPlague = 1819304258,
        /// <summary>Cripple ('Bcri').</summary>
        Cripple = 1769104194,
        /// <summary>Curse ('Bcrs').</summary>
        Curse = 1936876354,
        /// <summary>Freezing breath ('Bfrz').</summary>
        FreezingBreath = 2054317634,
        /// <summary>Plague ward ('Bplg').</summary>
        PlagueWard = 1735159874,
        /// <summary>Possession ('Bpoc').</summary>
        Possession_Bpoc = 1668247618,
        /// <summary>Possession ('Bpos').</summary>
        Possession_Bpos = 1936683074,
        /// <summary>Raise dead ('Brai').</summary>
        RaiseDead = 1767993922,
        /// <summary>Replenish ('Brpb').</summary>
        Replenish = 1651536450,
        /// <summary>Replenish life ('Brpl').</summary>
        ReplenishLife = 1819308610,
        /// <summary>Replenish mana ('Brpm').</summary>
        ReplenishMana = 1836085826,
        /// <summary>Spider attack ('Bspa').</summary>
        SpiderAttack = 1634759490,
        /// <summary>Unholy frenzy ('Buhf').</summary>
        UnholyFrenzy = 1718121794,
        /// <summary>Unsummon ('Buns').</summary>
        Unsummon = 1936618818,
        /// <summary>Web ('Bweb').</summary>
        Web = 1650816834,
        /// <summary>Web air ('Bwea').</summary>
        WebAir = 1634039618,
        /// <summary>Animate dead ('BUan').</summary>
        AnimateDead_BUan = 1851872578,
        /// <summary>Aura unholy ('BUau').</summary>
        AuraUnholy = 1969313090,
        /// <summary>Aura vampiric ('BUav').</summary>
        AuraVampiric = 1986090306,
        /// <summary>Carrion scarab ('BUcb').</summary>
        CarrionScarab = 1650677058,
        /// <summary>Carrion swarm ('BUcs').</summary>
        CarrionSwarm = 1935889730,
        /// <summary>Death and decay aoe ('BUdd').</summary>
        DeathAndDecayAoe = 1684297026,
        /// <summary>Frost armor ('BUfa').</summary>
        FrostArmor = 1634096450,
        /// <summary>Impale ('BUim').</summary>
        Impale = 1835619650,
        /// <summary>Sleep ('BUsl').</summary>
        Sleep = 1819497794,
        /// <summary>Sleep pause ('BUsp').</summary>
        SleepPause = 1886606658,
        /// <summary>Sleep stun ('BUst').</summary>
        SleepStun = 1953715522,
        /// <summary>Thorny shield ('BUts').</summary>
        ThornyShield_BUts = 1937003842,
        /// <summary>Thorny shield ('BUtt').</summary>
        ThornyShield_BUtt = 1953781058,
        /// <summary>Aura slow ('Basl').</summary>
        AuraSlow = 1819500866,
        /// <summary>Breath of frost ('BCbf').</summary>
        BreathOfFrost = 1717715778,
        /// <summary>Creep thunder clap ('BCtc').</summary>
        CreepThunderClap = 1668563778,
        /// <summary>Frenzy ('Bfzy').</summary>
        Frenzy = 2038064706,
        /// <summary>Mechanical critter ('Bmec').</summary>
        MechanicalCritter = 1667591490,
        /// <summary>Mind rot ('BNmr').</summary>
        MindRot = 1919766082,
        /// <summary>Panda immolation ('Bpig').</summary>
        PandaImmolation = 1734963266,
        /// <summary>Perm immolation ('BNpi').</summary>
        PermImmolation = 1768967746,
        /// <summary>Sanctuary ('BNsa').</summary>
        Sanctuary = 1634946626,
        /// <summary>Shadow sight ('Bshs').</summary>
        ShadowSight = 1936225090,
        /// <summary>Spell shield ('BNss').</summary>
        SpellShield = 1936936514,
        /// <summary>Tornado damage aoe ('Btdg').</summary>
        TornadoDamageAoe = 1734636610,
        /// <summary>Tornado spin ('Btsp').</summary>
        TornadoSpin = 1886614594,
        /// <summary>Tornado spin aoe ('Btsa').</summary>
        TornadoSpinAoe = 1634956354,
        /// <summary>Black arrow ('BNba').</summary>
        BlackArrow = 1633832514,
        /// <summary>Breath of fire ('BNbf').</summary>
        BreathOfFire = 1717718594,
        /// <summary>Cold arrow ('BHca').</summary>
        ColdArrow = 1633896514,
        /// <summary>Cold arrow stack do t ('Bcsd').</summary>
        ColdArrowStackDoT = 1685283650,
        /// <summary>Cold arrow stack info ('Bcsi').</summary>
        ColdArrowStackInfo = 1769169730,
        /// <summary>Dark minion ('BNdm').</summary>
        DarkMinion = 1835290178,
        /// <summary>Doom ('BNdo').</summary>
        Doom = 1868844610,
        /// <summary>Doom minion ('BNdi').</summary>
        DoomMinion = 1768181314,
        /// <summary>Drunken haze ('BNdh').</summary>
        DrunkenHaze = 1751404098,
        /// <summary>Elemental fury ('BNef').</summary>
        ElementalFury = 1717915202,
        /// <summary>Howl of terror ('BNht').</summary>
        HowlOfTerror = 1952992834,
        /// <summary>Mana shield ('BNms').</summary>
        ManaShield = 1936543298,
        /// <summary>Silence ('BNsi').</summary>
        Silence = 1769164354,
        /// <summary>Stampede ('BNst').</summary>
        Stampede = 1953713730,
        /// <summary>Summon grizzly ('BNsg').</summary>
        SummonGrizzly = 1735609922,
        /// <summary>Summon quillbeast ('BNsq').</summary>
        SummonQuillbeast = 1903382082,
        /// <summary>Summon war eagle ('BNsw').</summary>
        SummonWarEagle = 2004045378,
        /// <summary>Tornado ('BNto').</summary>
        Tornado = 1869893186,
        /// <summary>Watery minion ('BNwm').</summary>
        WateryMinion = 1836535362,
        /// <summary>Battle roar ('BNbr').</summary>
        BattleRoar = 1919045186,
        /// <summary>Dark conversion ('BNdc').</summary>
        DarkConversion = 1667518018,
        /// <summary>Infernal ('BNin').</summary>
        Infernal = 1852395074,
        /// <summary>Parasite ('BNpa').</summary>
        Parasite = 1634750018,
        /// <summary>Parasite minion ('BNpm').</summary>
        ParasiteMinion = 1836076610,
        /// <summary>Rain of fire ('BNrd').</summary>
        RainOfFire_BNrd = 1685212738,
        /// <summary>Rain of fire aoe ('BNrf').</summary>
        RainOfFireAoe = 1718767170,
        /// <summary>Soul preservation ('BNsl').</summary>
        SoulPreservation = 1819496002,
        /// <summary>Corruption ('BIcb').</summary>
        Corruption = 1650673986,
        /// <summary>Figurine ('BFig').</summary>
        Figurine = 1734952514,
        /// <summary>Item cloak of flames ('BIcf').</summary>
        ItemCloakOfFlames = 1717782850,
        /// <summary>Item illusion ('BIil').</summary>
        ItemIllusion = 1818839362,
        /// <summary>Rebirth ('BIrb').</summary>
        Rebirth = 1651657026,
        /// <summary>Regeneration ('BIrg').</summary>
        Regeneration = 1735543106,
        /// <summary>Regen life ('BIrl').</summary>
        RegenLife = 1819429186,
        /// <summary>Regen mana ('BIrm').</summary>
        RegenMana = 1836206402,
        /// <summary>Soul trap vision ('BIsv').</summary>
        SoulTrapVision = 1987266882,
        /// <summary>Spirit troll ('BIsh').</summary>
        SpiritTroll = 1752385858,
        /// <summary>Item web ('BIwb').</summary>
        ItemWeb = 1651984706,
        /// <summary>Item monster lure ('BImo').</summary>
        ItemMonsterLure = 1869433154,
        /// <summary>Item vampire potion ('BIpv').</summary>
        ItemVampirePotion = 1987070274,
        /// <summary>Cloud of fog ('Xclf').</summary>
        CloudOfFog_Xclf = 1718379352,
        /// <summary>Flare ('Xfla').</summary>
        Flare = 1634494040,
        /// <summary>Blizzard ('XHbz').</summary>
        Blizzard_XHbz = 2053261400,
        /// <summary>Flame strike ('XHfs').</summary>
        FlameStrike_XHfs = 1936083032,
        /// <summary>Balls of fire ('Xbof').</summary>
        BallsOfFire_Xbof = 1718575704,
        /// <summary>Earthquake ('XOeq').</summary>
        Earthquake_XOeq = 1902464856,
        /// <summary>Reincarnation ('XOre').</summary>
        Reincarnation = 1701990232,
        /// <summary>Sentinel ('Xesn').</summary>
        Sentinel = 1853056344,
        /// <summary>Starfall ('XEsf').</summary>
        Starfall = 1718830424,
        /// <summary>Tranquility ('XEtq').</summary>
        Tranquility = 1903445336,
        /// <summary>Death and decay ('XUdd').</summary>
        DeathAndDecay = 1684297048,
        /// <summary>Monsoon ('XNmo').</summary>
        Monsoon_XNmo = 1869434456,
        /// <summary>Rain of chaos ('XErc').</summary>
        RainOfChaos = 1668433240,
        /// <summary>Rain of fire ('XErf').</summary>
        RainOfFire_XErf = 1718764888,
        /// <summary>Item change TOD ('XIct').</summary>
        ItemChangeTOD = 1952663896,
        /// <summary>Starfall target ('AEsd').</summary>
        StarfallTarget = 1685275969,
        /// <summary>Tranquility target ('AEtr').</summary>
        TranquilityTarget = 1920222529,
        /// <summary>Monsoon ('ANmd').</summary>
        Monsoon_ANmd = 1684885057,
        /// <summary>Invisibility ('Bivs').</summary>
        Invisibility_Bivs = 1937140034,
        /// <summary>Animate dead ('BUad').</summary>
        AnimateDead_BUad = 1684100418,
        /// <summary>Ultravision ('Bult').</summary>
        Ultravision = 1953264962,
        /// <summary>Acid bomb ('BNab').</summary>
        AcidBomb = 1650544194,
        /// <summary>Chemical rage ('BNcr').</summary>
        ChemicalRage = 1919110722,
        /// <summary>Healing spray ('BNhs').</summary>
        HealingSpray_BNhs = 1936215618,
        /// <summary>Healing spray ('XNhs').</summary>
        HealingSpray_XNhs = 1936215640,
        /// <summary>Transmute ('BNtm').</summary>
        Transmute = 1836338754,
        /// <summary>Engineering upgrade ('BNeg').</summary>
        EngineeringUpgrade = 1734692418,
        /// <summary>Cluster rockets ('BNcs').</summary>
        ClusterRockets_BNcs = 1935887938,
        /// <summary>Cluster rockets ('XNcs').</summary>
        ClusterRockets_XNcs = 1935887960,
        /// <summary>Summon factory ('BNfy').</summary>
        SummonFactory = 2036747842,
        /// <summary>Clockwerk goblin ('BNcg').</summary>
        ClockwerkGoblin = 1734561346,
        /// <summary>Incinerate ('BNic').</summary>
        Incinerate = 1667845698,
        /// <summary>Soul burn ('BNso').</summary>
        SoulBurn = 1869827650,
        /// <summary>Lava monster ('BNlm').</summary>
        LavaMonster = 1835814466,
        /// <summary>Volcano ('BNvc').</summary>
        Volcano_BNvc = 1668697666,
        /// <summary>Volcano AOE ('BNva').</summary>
        VolcanoAOE = 1635143234,
        /// <summary>Volcano ('XNvc').</summary>
        Volcano_XNvc = 1668697688,
        /// <summary>EFFECT BASEDETECTOR ('Xbdt').</summary>
        EFFECTBASEDETECTOR = 1952735832,
        /// <summary>EFFECT BLIGHT ('Xbli').</summary>
        EFFECTBLIGHT = 1768710744,
        /// <summary>EFFECT HERODISSIPATE ('Xdis').</summary>
        EFFECTHERODISSIPATE = 1936286808,
        /// <summary>EFFECT OnFireHumanSml ('Xfhs').</summary>
        EFFECTOnFireHumanSml = 1936221784,
        /// <summary>EFFECT OnFireHumanMed ('Xfhm').</summary>
        EFFECTOnFireHumanMed = 1835558488,
        /// <summary>EFFECT OnFireHumanLrg ('Xfhl').</summary>
        EFFECTOnFireHumanLrg = 1818781272,
        /// <summary>EFFECT OnFireOrcSml ('Xfos').</summary>
        EFFECTOnFireOrcSml = 1936680536,
        /// <summary>EFFECT OnFireOrcMed ('Xfom').</summary>
        EFFECTOnFireOrcMed = 1836017240,
        /// <summary>EFFECT OnFireOrcLrg ('Xfol').</summary>
        EFFECTOnFireOrcLrg = 1819240024,
        /// <summary>EFFECT OnFireNightElfSml ('Xfns').</summary>
        EFFECTOnFireNightElfSml = 1936615000,
        /// <summary>EFFECT OnFireNightElfMed ('Xfnm').</summary>
        EFFECTOnFireNightElfMed = 1835951704,
        /// <summary>EFFECT OnFireNightElfLrg ('Xfnl').</summary>
        EFFECTOnFireNightElfLrg = 1819174488,
        /// <summary>EFFECT OnFireUndeadSml ('Xfus').</summary>
        EFFECTOnFireUndeadSml = 1937073752,
        /// <summary>EFFECT OnFireUndeadMed ('Xfum').</summary>
        EFFECTOnFireUndeadMed = 1836410456,
        /// <summary>EFFECT OnFireUndeadLrg ('Xful').</summary>
        EFFECTOnFireUndeadLrg = 1819633240,
        /// <summary>Heal multiplier ('BIhm').</summary>
        HealMultiplier = 1835551042
    }
}