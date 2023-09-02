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
    public enum ItemType
    {
        /// <summary>Crown of kings 5 ('ckng').</summary>
        CrownOfKings5 = 1735289699,
        /// <summary>Mask of death ('modt').</summary>
        MaskOfDeath = 1952739181,
        /// <summary>Tome of power ('tkno').</summary>
        TomeOfPower = 1869507444,
        /// <summary>Claws of attack 15 ('ratf').</summary>
        ClawsOfAttack15 = 1718903154,
        /// <summary>Orb of frost ('ofro').</summary>
        OrbOfFrost = 1869768303,
        /// <summary>Inferno stone ('infs').</summary>
        InfernoStone = 1936092777,
        /// <summary>Dagger of escape ('desc').</summary>
        DaggerOfEscape = 1668506980,
        /// <summary>Demonic figurine ('fgdg').</summary>
        DemonicFigurine = 1734633318,
        /// <summary>Engraved scale ('engr').</summary>
        EngravedScale = 1919381093,
        /// <summary>Ice shard ('shar').</summary>
        IceShard = 1918986355,
        /// <summary>Scepter of mastery ('ccmd').</summary>
        ScepterOfMastery = 1684890467,
        /// <summary>Amulet of the wild ('wild').</summary>
        AmuletOfTheWild = 1684826487,
        /// <summary>Scepter of avarice ('scav').</summary>
        ScepterOfAvarice = 1986093939,
        /// <summary>Orb of darkness ('odef').</summary>
        OrbOfDarkness = 1717920879,
        /// <summary>Ring of protection 5 ('rde4').</summary>
        RingOfProtection5 = 879060082,
        /// <summary>Pendant of mana ('pmna').</summary>
        PendantOfMana = 1634626928,
        /// <summary>Khadgar s gem of health ('rhth').</summary>
        KhadgarSGemOfHealth = 1752459378,
        /// <summary>Staff of silence ('ssil').</summary>
        StaffOfSilence = 1818850163,
        /// <summary>Amulet of spell shield ('spsh').</summary>
        AmuletOfSpellShield = 1752395891,
        /// <summary>Scroll of restoration ('sres').</summary>
        ScrollOfRestoration = 1936028275,
        /// <summary>Potion of divinity invulnerability ('pdi2').</summary>
        PotionOfDivinityInvulnerability = 845767792,
        /// <summary>Potion of restoration ('pres').</summary>
        PotionOfRestoration = 1936028272,
        /// <summary>Idol of the wild ('iotw').</summary>
        IdolOfTheWild = 2004119401,
        /// <summary>Spiked collar ('fgfh').</summary>
        SpikedCollar = 1751541606,
        /// <summary>Blue drake egg ('fgbd').</summary>
        BlueDrakeEgg = 1684170598,
        /// <summary>Stone token ('fgrg').</summary>
        StoneToken = 1735550822,
        /// <summary>Hood of cunning ('hcun').</summary>
        HoodOfCunning = 1853186920,
        /// <summary>Helm of valor ('hval').</summary>
        HelmOfValor = 1818326632,
        /// <summary>Medallion of courage ('mcou').</summary>
        MedallionOfCourage = 1970234221,
        /// <summary>Ancient janggo of endurance ('ajen').</summary>
        AncientJanggoOfEndurance = 1852140129,
        /// <summary>Cloak of flames ('clfm').</summary>
        CloakOfFlames = 1835428963,
        /// <summary>Claws of attack 12 ('ratc').</summary>
        ClawsOfAttack12 = 1668571506,
        /// <summary>Warsong battle drums kodo ('war2').</summary>
        WarsongBattleDrumsKodo = 846356855,
        /// <summary>Khadgar s pipe of insight ('kpin').</summary>
        KhadgarSPipeOfInsight = 1852403819,
        /// <summary>Legion Doom Horn ('lgdh').</summary>
        LegionDoomHorn = 1751410540,
        /// <summary>Ankh of reincarnation ('ankh').</summary>
        AnkhOfReincarnation = 1751871073,
        /// <summary>Healing wards ('whwd').</summary>
        HealingWards = 1685547127,
        /// <summary>Book of the dead ('fgsk').</summary>
        BookOfTheDead = 1802725222,
        /// <summary>Wand of the wind ('wcyc').</summary>
        WandOfTheWind = 1668899703,
        /// <summary>Health stone ('hlst').</summary>
        HealthStone = 1953721448,
        /// <summary>Mana stone ('mnst').</summary>
        ManaStone = 1953721965,
        /// <summary>Boots of quel thalas 6 ('belv').</summary>
        BootsOfQuelThalas6 = 1986815330,
        /// <summary>Belt of giant strength 6 ('bgst').</summary>
        BeltOfGiantStrength6 = 1953720162,
        /// <summary>Robe of the magi 6 ('ciri').</summary>
        RobeOfTheMagi6 = 1769105763,
        /// <summary>Lion horn of stormwind ('lhst').</summary>
        LionHornOfStormwind = 1953720428,
        /// <summary>Alleria s flute of accuracy ('afac').</summary>
        AlleriaSFluteOfAccuracy = 1667327585,
        /// <summary>Scourge bone chimes ('sbch').</summary>
        ScourgeBoneChimes = 1751343731,
        /// <summary>Runed bracers ('brac').</summary>
        RunedBracers = 1667330658,
        /// <summary>Sobi mask ('rwiz').</summary>
        SobiMask = 2053732210,
        /// <summary>Potion of greater healing ('pghe').</summary>
        PotionOfGreaterHealing = 1701341040,
        /// <summary>Potion of greater mana ('pgma').</summary>
        PotionOfGreaterMana = 1634559856,
        /// <summary>Potion of invulnerability ('pnvu').</summary>
        PotionOfInvulnerability = 1970695792,
        /// <summary>Scroll of the beast ('sror').</summary>
        ScrollOfTheBeast = 1919906419,
        /// <summary>Wand of mana stealing ('woms').</summary>
        WandOfManaStealing = 1936551799,
        /// <summary>Crystal ball ('crys').</summary>
        CrystalBall = 1937338979,
        /// <summary>Talisman of evasion ('evtl').</summary>
        TalismanOfEvasion = 1819571813,
        /// <summary>Pendant of energy ('penr').</summary>
        PendantOfEnergy = 1919837552,
        /// <summary>Periapt of vitality ('prvt').</summary>
        PeriaptOfVitality = 1953919600,
        /// <summary>Claws of attack 9 ('rat9').</summary>
        ClawsOfAttack9 = 963928434,
        /// <summary>Ring of protection 4 ('rde3').</summary>
        RingOfProtection4 = 862282866,
        /// <summary>Ring of regeneration ('rlif').</summary>
        RingOfRegeneration = 1718185074,
        /// <summary>Boots of speed ('bspd').</summary>
        BootsOfSpeed = 1685091170,
        /// <summary>Replenishment potion ('rej3').</summary>
        ReplenishmentPotion = 862610802,
        /// <summary>Wand of illusion ('will').</summary>
        WandOfIllusion = 1819044215,
        /// <summary>Wand of lightning shield ('wlsd').</summary>
        WandOfLightningShield = 1685286007,
        /// <summary>Sentry wards ('wswd').</summary>
        SentryWards = 1685549943,
        /// <summary>Circlet of nobility ('cnob').</summary>
        CircletOfNobility = 1651469923,
        /// <summary>Gloves of haste ('gcel').</summary>
        GlovesOfHaste = 1818583911,
        /// <summary>Claws of attack 6 ('rat6').</summary>
        ClawsOfAttack6 = 913596786,
        /// <summary>Ring of protection 3 ('rde2').</summary>
        RingOfProtection3 = 845505650,
        /// <summary>Tome of agility 2 ('tdx2').</summary>
        TomeOfAgility2 = 846750836,
        /// <summary>Tome of intelligence 2 ('tin2').</summary>
        TomeOfIntelligence2 = 846096756,
        /// <summary>Tome of knowledge ('tpow').</summary>
        TomeOfKnowledge = 2003791988,
        /// <summary>Tome of strength 2 ('tst2').</summary>
        TomeOfStrength2 = 846492532,
        /// <summary>Potion of lesser invulnerability ('pnvl').</summary>
        PotionOfLesserInvulnerability = 1819700848,
        /// <summary>Cloak of shadows ('clsd').</summary>
        CloakOfShadows = 1685285987,
        /// <summary>Slippers of agility 3 ('rag1').</summary>
        SlippersOfAgility3 = 828858738,
        /// <summary>Mantle of intelligence 3 ('rin1').</summary>
        MantleOfIntelligence3 = 829319538,
        /// <summary>Gauntlets of ogre strength 3 ('rst1').</summary>
        GauntletsOfOgreStrength3 = 829715314,
        /// <summary>Manual of health ('manh').</summary>
        ManualOfHealth = 1752064365,
        /// <summary>Tome of agility 1 ('tdex').</summary>
        TomeOfAgility1 = 2019910772,
        /// <summary>Tome of intelligence ('tint').</summary>
        TomeOfIntelligence = 1953393012,
        /// <summary>Tome of strength 1 ('tstr').</summary>
        TomeOfStrength1 = 1920234356,
        /// <summary>Potion of omniscience ('pomn').</summary>
        PotionOfOmniscience = 1852665712,
        /// <summary>Wand of shadowsight ('wshs').</summary>
        WandOfShadowsight = 1936225143,
        /// <summary>Greater scroll of replenishment ('rej6').</summary>
        GreaterScrollOfReplenishment = 912942450,
        /// <summary>Lesser scroll of replenishment ('rej5').</summary>
        LesserScrollOfReplenishment = 896165234,
        /// <summary>Greater replenishment potion ('rej4').</summary>
        GreaterReplenishmentPotion = 879388018,
        /// <summary>Fourth ring of the archmagi ('ram4').</summary>
        FourthRingOfTheArchmagi = 879583602,
        /// <summary>Diamond of summoning ('dsum').</summary>
        DiamondOfSummoning = 1836413796,
        /// <summary>Orb of fire ('ofir').</summary>
        OrbOfFire = 1919510127,
        /// <summary>Orb of corruption ('ocor').</summary>
        OrbOfCorruption = 1919902575,
        /// <summary>Orb of lightning ('oli2').</summary>
        OrbOfLightning = 845769839,
        /// <summary>Orb of venom ('oven').</summary>
        OrbOfVenom = 1852143215,
        /// <summary>Third ring of the archmagi ('ram3').</summary>
        ThirdRingOfTheArchmagi = 862806386,
        /// <summary>Tome of retraining ('tret').</summary>
        TomeOfRetraining = 1952805492,
        /// <summary>Tiny great hall ('tgrh').</summary>
        TinyGreatHall = 1752328052,
        /// <summary>Lesser replenishment potion ('rej2').</summary>
        LesserReplenishmentPotion = 845833586,
        /// <summary>Gem of true seeing ('gemt').</summary>
        GemOfTrueSeeing = 1953326439,
        /// <summary>Second ring of the archmagi ('ram2').</summary>
        SecondRingOfTheArchmagi = 846029170,
        /// <summary>Staff of teleportation ('stel').</summary>
        StaffOfTeleportation = 1818588275,
        /// <summary>Scroll of town portal ('stwp').</summary>
        ScrollOfTownPortal = 1886876787,
        /// <summary>Wand of negation ('wneg').</summary>
        WandOfNegation = 1734700663,
        /// <summary>Staff of negation ('sneg').</summary>
        StaffOfNegation = 1734700659,
        /// <summary>Wand of neutralization ('wneu').</summary>
        WandOfNeutralization = 1969581687,
        /// <summary>Scroll of healing ('shea').</summary>
        ScrollOfHealing = 1634035827,
        /// <summary>Scroll of mana ('sman').</summary>
        ScrollOfMana = 1851878771,
        /// <summary>Minor replenishment potion ('rej1').</summary>
        MinorReplenishmentPotion = 829056370,
        /// <summary>Potion of speed ('pspd').</summary>
        PotionOfSpeed = 1685091184,
        /// <summary>Dust of appearance ('dust').</summary>
        DustOfAppearance = 1953723748,
        /// <summary>First ring of the archmagi ('ram1').</summary>
        FirstRingOfTheArchmagi = 829251954,
        /// <summary>Potion of invisibility ('pinv').</summary>
        PotionOfInvisibility = 1986947440,
        /// <summary>Potion of healing ('phea').</summary>
        PotionOfHealing = 1634035824,
        /// <summary>Potion of mana ('pman').</summary>
        PotionOfMana = 1851878768,
        /// <summary>Scroll of protection ('spro').</summary>
        ScrollOfProtection = 1869770867,
        /// <summary>Healing salve ('hslv').</summary>
        HealingSalve = 1986818920,
        /// <summary>Moonstone ('moon').</summary>
        Moonstone = 1852796781,
        /// <summary>Scroll of speed ('shas').</summary>
        ScrollOfSpeed = 1935763571,
        /// <summary>Sacrificial skull ('skul').</summary>
        SacrificialSkull = 1819634547,
        /// <summary>Mechanical critter ('mcri').</summary>
        MechanicalCritter = 1769104237,
        /// <summary>Rod of necromancy ('rnec').</summary>
        RodOfNecromancy = 1667591794,
        /// <summary>Ritual dagger ('ritd').</summary>
        RitualDagger = 1685350770,
        /// <summary>Ivory tower ('tsct').</summary>
        IvoryTower = 1952674676,
        /// <summary>Heart of aszune ('azhr').</summary>
        HeartOfAszune = 1919449697,
        /// <summary>Empty vial ('bzbe').</summary>
        EmptyVial = 1700952674,
        /// <summary>Full vial ('bzbf').</summary>
        FullVial = 1717729890,
        /// <summary>Cheese ('ches').</summary>
        Cheese = 1936025699,
        /// <summary>Horn of cenarius ('cnhn').</summary>
        HornOfCenarius = 1852337763,
        /// <summary>Guldan s skull ('glsk').</summary>
        GuldanSSkull = 1802726503,
        /// <summary>Glyph of purification ('gopr').</summary>
        GlyphOfPurification = 1919971175,
        /// <summary>Key of 3 moons 1 ('k3m1').</summary>
        KeyOf3Moons1 = 829240171,
        /// <summary>Key of 3 moons 2 ('k3m2').</summary>
        KeyOf3Moons2 = 846017387,
        /// <summary>Key of 3 moons 3 ('k3m3').</summary>
        KeyOf3Moons3 = 862794603,
        /// <summary>Urn of kel thuzad ('ktrm').</summary>
        UrnOfKelThuzad = 1836217451,
        /// <summary>Bloody key ('kybl').</summary>
        BloodyKey = 1818392939,
        /// <summary>Ghost key ('kygh').</summary>
        GhostKey = 1751611755,
        /// <summary>Moon key ('kymn').</summary>
        MoonKey = 1852668267,
        /// <summary>Sun key ('kysn').</summary>
        SunKey = 1853061483,
        /// <summary>Gerard s lost ledger ('ledg').</summary>
        GerardSLostLedger = 1734632812,
        /// <summary>Phat lewt ('phlt').</summary>
        PhatLewt = 1953261680,
        /// <summary>Searinox s heart ('sehr').</summary>
        SearinoxSHeart = 1919444339,
        /// <summary>Enchanted gemstone ('engs').</summary>
        EnchantedGemstone = 1936158309,
        /// <summary>Shadow orb fragment ('sorf').</summary>
        ShadowOrbFragment = 1718775667,
        /// <summary>Gem fragment ('gmfr').</summary>
        GemFragment = 1919315303,
        /// <summary>Note to jaina proudmoore ('jpnt').</summary>
        NoteToJainaProudmoore = 1953394794,
        /// <summary>Shimmerweed ('shwd').</summary>
        Shimmerweed = 1685547123,
        /// <summary>Skeletal artifact ('skrt').</summary>
        SkeletalArtifact = 1953655667,
        /// <summary>Thunder lizard egg ('thle').</summary>
        ThunderLizardEgg = 1701603444,
        /// <summary>Secret level powerup ('sclp').</summary>
        SecretLevelPowerup = 1886151539,
        /// <summary>Wirt s leg ('wtlg').</summary>
        WirtSLeg = 1735160951,
        /// <summary>Wirt s other leg ('wolg').</summary>
        WirtSOtherLeg = 1735159671,
        /// <summary>Magtheridon s keys ('mgtk').</summary>
        MagtheridonSKeys = 1802790765,
        /// <summary>Mogrin s report ('mort').</summary>
        MogrinSReport = 1953656685,
        /// <summary>Thunder hawk egg ('dphe').</summary>
        ThunderHawkEgg = 1701343332,
        /// <summary>Keg of thunderwater ('dkfw').</summary>
        KegOfThunderwater = 2003200868,
        /// <summary>Thunderbloom bulb ('dthb').</summary>
        ThunderbloomBulb = 1651012708,
        /// <summary>Flare gun ('fgun').</summary>
        FlareGun = 1853187942,
        /// <summary>Monster lure ('lure').</summary>
        MonsterLure = 1701999980,
        /// <summary>Orb of lightning old ('olig').</summary>
        OrbOfLightningOld = 1734962287,
        /// <summary>Amulet of recall ('amrc').</summary>
        AmuletOfRecall = 1668443489,
        /// <summary>Human flag ('flag').</summary>
        HumanFlag = 1734437990,
        /// <summary>Goblin land mine ('gobm').</summary>
        GoblinLandMine = 1835167591,
        /// <summary>Soul gem ('gsou').</summary>
        SoulGem = 1970238311,
        /// <summary>Night elf flag ('nflg').</summary>
        NightElfFlag = 1735157358,
        /// <summary>Necklace of spell immunity ('nspi').</summary>
        NecklaceOfSpellImmunity = 1768977262,
        /// <summary>Orc flag ('oflg').</summary>
        OrcFlag = 1735157359,
        /// <summary>Anti Magic Potion ('pams').</summary>
        AntiMagicPotion = 1936548208,
        /// <summary>Potion of greater invisibility ('pgin').</summary>
        PotionOfGreaterInvisibility = 1852401520,
        /// <summary>Claws of attack 3 ('rat3').</summary>
        ClawsOfAttack3 = 863265138,
        /// <summary>Ring of protection 1 ('rde0').</summary>
        RingOfProtection1 = 811951218,
        /// <summary>Ring of protection 2 ('rde1').</summary>
        RingOfProtection2 = 828728434,
        /// <summary>Ring of superiority ('rnsp').</summary>
        RingOfSuperiority = 1886613106,
        /// <summary>Soul ('soul').</summary>
        Soul = 1819635571,
        /// <summary>Goblin night scope ('tels').</summary>
        GoblinNightScope = 1936483700,
        /// <summary>Tome of greater experience ('tgxp').</summary>
        TomeOfGreaterExperience = 1886938996,
        /// <summary>Undead flag ('uflg').</summary>
        UndeadFlag = 1735157365,
        /// <summary>Ancient figurine ('anfg').</summary>
        AncientFigurine = 1734766177,
        /// <summary>Bracer of agility ('brag').</summary>
        BracerOfAgility = 1734439522,
        /// <summary>Druid pouch ('drph').</summary>
        DruidPouch = 1752199780,
        /// <summary>Ironwood branch ('iwbr').</summary>
        IronwoodBranch = 1919055721,
        /// <summary>Jade ring ('jdrn').</summary>
        JadeRing = 1852990570,
        /// <summary>Lion s ring ('lnrn').</summary>
        LionSRing = 1852993132,
        /// <summary>Maul of strength ('mlst').</summary>
        MaulOfStrength = 1953721453,
        /// <summary>Orb of slow ('oslo').</summary>
        OrbOfSlow = 1869378415,
        /// <summary>Spell book ('sbok').</summary>
        SpellBook = 1802461811,
        /// <summary>Skull shield ('sksh').</summary>
        SkullShield = 1752394611,
        /// <summary>Spider ring ('sprn').</summary>
        SpiderRing = 1852993651,
        /// <summary>Totem of might ('tmmt').</summary>
        TotemOfMight = 1953328500,
        /// <summary>Voodoo doll ('vddl').</summary>
        VoodooDoll = 1818518646,
        /// <summary>Staff of preservation ('spre').</summary>
        StaffOfPreservation = 1701998707,
        /// <summary>Horn of the clouds ('sfog').</summary>
        HornOfTheClouds = 1735353971,
        /// <summary>Shadow orb 1 ('sor1').</summary>
        ShadowOrb1 = 829583219,
        /// <summary>Shadow orb 2 ('sor2').</summary>
        ShadowOrb2 = 846360435,
        /// <summary>Shadow orb 3 ('sor3').</summary>
        ShadowOrb3 = 863137651,
        /// <summary>Shadow orb 4 ('sor4').</summary>
        ShadowOrb4 = 879914867,
        /// <summary>Shadow orb 5 ('sor5').</summary>
        ShadowOrb5 = 896692083,
        /// <summary>Shadow orb 6 ('sor6').</summary>
        ShadowOrb6 = 913469299,
        /// <summary>Shadow orb 7 ('sor7').</summary>
        ShadowOrb7 = 930246515,
        /// <summary>Shadow orb 8 ('sor8').</summary>
        ShadowOrb8 = 947023731,
        /// <summary>Shadow orb 9 ('sor9').</summary>
        ShadowOrb9 = 963800947,
        /// <summary>Shadow orb 10 ('sora').</summary>
        ShadowOrb10 = 1634889587,
        /// <summary>Frostwyrm skull shield ('fwss').</summary>
        FrostwyrmSkullShield = 1936947046,
        /// <summary>Shamanic totem ('shtm').</summary>
        ShamanicTotem = 1836345459,
        /// <summary>Essence of aszune ('esaz').</summary>
        EssenceOfAszune = 2053206885,
        /// <summary>Orcish battle standard ('btst').</summary>
        OrcishBattleStandard = 1953723490,
        /// <summary>Tiny blacksmith ('tbsm').</summary>
        TinyBlacksmith = 1836278388,
        /// <summary>Tiny farm ('tfar').</summary>
        TinyFarm = 1918985844,
        /// <summary>Tiny lumber mill ('tlum').</summary>
        TinyLumberMill = 1836412020,
        /// <summary>Tiny barracks ('tbar').</summary>
        TinyBarracks = 1918984820,
        /// <summary>Tiny altar of kings ('tbak').</summary>
        TinyAltarOfKings = 1801544308,
        /// <summary>Orb of kil jaeden ('gldo').</summary>
        OrbOfKilJaeden = 1868852327,
        /// <summary>Staff of reanimation ('stre').</summary>
        StaffOfReanimation = 1701999731,
        /// <summary>Holy relic ('horl').</summary>
        HolyRelic = 1819438952,
        /// <summary>Helm of battlethirst ('hbth').</summary>
        HelmOfBattlethirst = 1752457832,
        /// <summary>Bladebane armor ('blba').</summary>
        BladebaneArmor = 1633840226,
        /// <summary>Runed gauntlets ('rugt').</summary>
        RunedGauntlets = 1952937330,
        /// <summary>Firehand gauntlets ('frhg').</summary>
        FirehandGauntlets = 1734898278,
        /// <summary>Gloves of spell mastery ('gvsm').</summary>
        GlovesOfSpellMastery = 1836283495,
        /// <summary>Crown of the deathlord ('crdt').</summary>
        CrownOfTheDeathlord = 1952739939,
        /// <summary>Arcane scroll ('arsc').</summary>
        ArcaneScroll = 1668510305,
        /// <summary>Scroll of the unholy legion ('scul').</summary>
        ScrollOfTheUnholyLegion = 1819632499,
        /// <summary>Tome of sacrifices ('tmsc').</summary>
        TomeOfSacrifices = 1668509044,
        /// <summary>Drek thar s spellbook ('dtsb').</summary>
        DrekTharSSpellbook = 1651733604,
        /// <summary>Grimoire of souls ('grsl').</summary>
        GrimoireOfSouls = 1819505255,
        /// <summary>Arcanite shield ('arsh').</summary>
        ArcaniteShield = 1752396385,
        /// <summary>Shield of the deathlord ('shdt').</summary>
        ShieldOfTheDeathlord = 1952737395,
        /// <summary>Shield of honor ('shhn').</summary>
        ShieldOfHonor = 1852336243,
        /// <summary>Enchanted shield ('shen').</summary>
        EnchantedShield = 1852139635,
        /// <summary>Thunderlizard diamond ('thdm').</summary>
        ThunderlizardDiamond = 1835296884,
        /// <summary>Stuffed penguin ('stpg').</summary>
        StuffedPenguin = 1735423091,
        /// <summary>Shimmerglaze roast ('shrs').</summary>
        ShimmerglazeRoast = 1936877683,
        /// <summary>Bloodfeather s heart ('bfhr').</summary>
        BloodfeatherSHeart = 1919444578,
        /// <summary>Celestial orb of souls ('cosl').</summary>
        CelestialOrbOfSouls = 1819504483,
        /// <summary>Shaman claws ('shcw').</summary>
        ShamanClaws = 2003003507,
        /// <summary>Searing blade ('srbd').</summary>
        SearingBlade = 1684173427,
        /// <summary>Frostguard ('frgd').</summary>
        Frostguard = 1684501094,
        /// <summary>Enchanted vial ('envl').</summary>
        EnchantedVial = 1819700837,
        /// <summary>Rusty mining pick ('rump').</summary>
        RustyMiningPick = 1886221682,
        /// <summary>Serathil ('srtl').</summary>
        Serathil = 1819570803,
        /// <summary>Sturdy war axe ('stwa').</summary>
        SturdyWarAxe = 1635218547,
        /// <summary>Killmaim ('klmm').</summary>
        Killmaim = 1835887723,
        /// <summary>Rod of the sea ('rots').</summary>
        RodOfTheSea = 1937010546,
        /// <summary>Ancestral staff ('axas').</summary>
        AncestralStaff = 1935767649,
        /// <summary>Mindstaff ('mnsf').</summary>
        Mindstaff = 1718840941,
        /// <summary>Scepter of healing ('schl').</summary>
        ScepterOfHealing = 1818780531,
        /// <summary>Assassin s blade ('asbl').</summary>
        AssassinSBlade = 1818391393,
        /// <summary>Keg of ale ('kgal').</summary>
        KegOfAle = 1818322795,
        /// <summary>Warsong battle drums ('ward').</summary>
        WarsongBattleDrums = 1685217655,
        /// <summary>Chest of gold ('gold').</summary>
        ChestOfGold = 1684828007,
        /// <summary>Bundle of lumber ('lmbr').</summary>
        BundleOfLumber = 1919053164,
        /// <summary>Glyph of fortification ('gfor').</summary>
        GlyphOfFortification = 1919903335,
        /// <summary>Glyph of ultra vision ('guvi').</summary>
        GlyphOfUltraVision = 1769370983,
        /// <summary>Rune of spirit link ('rspl').</summary>
        RuneOfSpiritLink = 1819308914,
        /// <summary>Rune of lesser resurrection ('rre1').</summary>
        RuneOfLesserResurrection = 828732018,
        /// <summary>Rune of greater resurrection ('rre2').</summary>
        RuneOfGreaterResurrection = 845509234,
        /// <summary>Glyph of omniscience ('gomn').</summary>
        GlyphOfOmniscience = 1852665703,
        /// <summary>Rune of shielding ('rsps').</summary>
        RuneOfShielding = 1936749426,
        /// <summary>Rune of speed ('rspd').</summary>
        RuneOfSpeed = 1685091186,
        /// <summary>Rune of mana lesser ('rman').</summary>
        RuneOfManaLesser = 1851878770,
        /// <summary>Rune of mana greater ('rma2').</summary>
        RuneOfManaGreater = 845245810,
        /// <summary>Rune of restoration ('rres').</summary>
        RuneOfRestoration = 1936028274,
        /// <summary>Rune of rebirth ('rreb').</summary>
        RuneOfRebirth = 1650815602,
        /// <summary>Rune of lesser healing ('rhe1').</summary>
        RuneOfLesserHealing = 828729458,
        /// <summary>Rune of healing ('rhe2').</summary>
        RuneOfHealing = 845506674,
        /// <summary>Rune of greater healing ('rhe3').</summary>
        RuneOfGreaterHealing = 862283890,
        /// <summary>Rune of dispel magic ('rdis').</summary>
        RuneOfDispelMagic = 1936286834,
        /// <summary>Tome of experience ('texp').</summary>
        TomeOfExperience = 1886938484,
        /// <summary>Rune of the watcher ('rwat').</summary>
        RuneOfTheWatcher = 1952544626,
        /// <summary>Clarity potion ('pclr').</summary>
        ClarityPotion = 1919705968,
        /// <summary>Lesser clarity potion ('plcl').</summary>
        LesserClarityPotion = 1818455152,
        /// <summary>Spider silk ('silk').</summary>
        SpiderSilk = 1802266995,
        /// <summary>Potion of vampirism ('vamp').</summary>
        PotionOfVampirism = 1886216566,
        /// <summary>Scroll of regeneration ('sreg').</summary>
        ScrollOfRegeneration = 1734701683,
        /// <summary>Tiny castle ('tcas').</summary>
        TinyCastle = 1935762292,
        /// <summary>Staff of sanctuary ('ssan').</summary>
        StaffOfSanctuary = 1851880307,
        /// <summary>Orb of fire v 2 ('ofr2').</summary>
        OrbOfFireV2 = 846358127,
        /// <summary>Seed of expulsion ('sxpl').</summary>
        SeedOfExpulsion = 1819310195,
        /// <summary>Vine of purification ('vpur').</summary>
        VineOfPurification = 1920299126,
        /// <summary>Potion of divinity divine shield ('pdiv').</summary>
        PotionOfDivinityDivineShield = 1986618480,
        /// <summary>Red drake egg ('fgrd').</summary>
        RedDrakeEgg = 1685219174,
        /// <summary>Talisman of the wild ('totw').</summary>
        TalismanOfTheWild = 2004119412,
        /// <summary>Scroll of animate dead ('sand').</summary>
        ScrollOfAnimateDead = 1684955507,
        /// <summary>Scroll of resurrection ('srrc').</summary>
        ScrollOfResurrection = 1668444787
    }
}