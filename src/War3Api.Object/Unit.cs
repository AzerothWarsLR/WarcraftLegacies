using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public sealed class Unit : BaseObject
    {
        private readonly SimpleObjectDataModifications _modifications = new SimpleObjectDataModifications();
        public Unit(UnitType baseUnitType): this((int)baseUnitType)
        {
        }

        public Unit(UnitType baseUnitType, int newId): this((int)baseUnitType, newId)
        {
        }

        public Unit(UnitType baseUnitType, string newRawcode): this((int)baseUnitType, newRawcode)
        {
        }

        public Unit(UnitType baseUnitType, ObjectDatabase db): this((int)baseUnitType, db)
        {
        }

        public Unit(UnitType baseUnitType, int newId, ObjectDatabase db): this((int)baseUnitType, newId, db)
        {
        }

        public Unit(UnitType baseUnitType, string newRawcode, ObjectDatabase db): this((int)baseUnitType, newRawcode, db)
        {
        }

        private Unit(int oldId): base(oldId)
        {
        }

        private Unit(int oldId, int newId): base(oldId, newId)
        {
        }

        private Unit(int oldId, string newRawcode): base(oldId, newRawcode)
        {
        }

        private Unit(int oldId, ObjectDatabase db): base(oldId, db)
        {
        }

        private Unit(int oldId, int newId, ObjectDatabase db): base(oldId, newId, db)
        {
        }

        private Unit(int oldId, string newRawcode, ObjectDatabase db): base(oldId, newRawcode, db)
        {
        }

        public SimpleObjectDataModifications Modifications => _modifications;
        public string ArtRequiredAnimationNamesRaw
        {
            get => _modifications[1768841589].ValueAsString;
            set => _modifications[1768841589] = new SimpleObjectDataModification{Id = 1768841589, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<string> ArtRequiredAnimationNames
        {
            get => ArtRequiredAnimationNamesRaw.ToIEnumerableString(this);
            set => ArtRequiredAnimationNamesRaw = value.ToRaw(null, 20);
        }

        public string ArtIconGameInterfaceRaw
        {
            get => _modifications[1868786037].ValueAsString;
            set => _modifications[1868786037] = new SimpleObjectDataModification{Id = 1868786037, Type = ObjectDataType.String, Value = value};
        }

        public string ArtIconGameInterface
        {
            get => ArtIconGameInterfaceRaw.ToString(this);
            set => ArtIconGameInterfaceRaw = value.ToRaw(null, null);
        }

        public string ArtRequiredAnimationNamesAttachmentsRaw
        {
            get => _modifications[1885430133].ValueAsString;
            set => _modifications[1885430133] = new SimpleObjectDataModification{Id = 1885430133, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<string> ArtRequiredAnimationNamesAttachments
        {
            get => ArtRequiredAnimationNamesAttachmentsRaw.ToIEnumerableString(this);
            set => ArtRequiredAnimationNamesAttachmentsRaw = value.ToRaw(null, 20);
        }

        public string ArtRequiredAttachmentLinkNamesRaw
        {
            get => _modifications[1886151029].ValueAsString;
            set => _modifications[1886151029] = new SimpleObjectDataModification{Id = 1886151029, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<string> ArtRequiredAttachmentLinkNames
        {
            get => ArtRequiredAttachmentLinkNamesRaw.ToIEnumerableString(this);
            set => ArtRequiredAttachmentLinkNamesRaw = value.ToRaw(null, 20);
        }

        public string TextTooltipAwaken
        {
            get => _modifications[1953980789].ValueAsString;
            set => _modifications[1953980789] = new SimpleObjectDataModification{Id = 1953980789, Type = ObjectDataType.String, Value = value};
        }

        public string ArtRequiredBoneNamesRaw
        {
            get => _modifications[1919967861].ValueAsString;
            set => _modifications[1919967861] = new SimpleObjectDataModification{Id = 1919967861, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<string> ArtRequiredBoneNames
        {
            get => ArtRequiredBoneNamesRaw.ToIEnumerableString(this);
            set => ArtRequiredBoneNamesRaw = value.ToRaw(null, 20);
        }

        public string SoundConstructionRaw
        {
            get => _modifications[1819501173].ValueAsString;
            set => _modifications[1819501173] = new SimpleObjectDataModification{Id = 1819501173, Type = ObjectDataType.String, Value = value};
        }

        public string SoundConstruction
        {
            get => SoundConstructionRaw.ToString(this);
            set => SoundConstructionRaw = value.ToRaw(null, null);
        }

        public string TechtreeStructuresBuiltRaw
        {
            get => _modifications[1769300597].ValueAsString;
            set => _modifications[1769300597] = new SimpleObjectDataModification{Id = 1769300597, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Unit> TechtreeStructuresBuilt
        {
            get => TechtreeStructuresBuiltRaw.ToIEnumerableUnit(this);
            set => TechtreeStructuresBuiltRaw = value.ToRaw(null, null);
        }

        public int ArtButtonPositionX
        {
            get => _modifications[2020631157].ValueAsInt;
            set => _modifications[2020631157] = new SimpleObjectDataModification{Id = 2020631157, Type = ObjectDataType.Int, Value = value};
        }

        public int ArtButtonPositionY
        {
            get => _modifications[2037408373].ValueAsInt;
            set => _modifications[2037408373] = new SimpleObjectDataModification{Id = 2037408373, Type = ObjectDataType.Int, Value = value};
        }

        public string ArtCasterUpgradeArtRaw
        {
            get => _modifications[1635083125].ValueAsString;
            set => _modifications[1635083125] = new SimpleObjectDataModification{Id = 1635083125, Type = ObjectDataType.String, Value = value};
        }

        public string ArtCasterUpgradeArt
        {
            get => ArtCasterUpgradeArtRaw.ToString(this);
            set => ArtCasterUpgradeArtRaw = value.ToRaw(null, null);
        }

        public string TextCasterUpgradeNamesRaw
        {
            get => _modifications[1853186933].ValueAsString;
            set => _modifications[1853186933] = new SimpleObjectDataModification{Id = 1853186933, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<string> TextCasterUpgradeNames
        {
            get => TextCasterUpgradeNamesRaw.ToIEnumerableString(this);
            set => TextCasterUpgradeNamesRaw = value.ToRaw(null, 32);
        }

        public string TextCasterUpgradeTipsRaw
        {
            get => _modifications[1953850229].ValueAsString;
            set => _modifications[1953850229] = new SimpleObjectDataModification{Id = 1953850229, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<string> TextCasterUpgradeTips
        {
            get => TextCasterUpgradeTipsRaw.ToIEnumerableString(this);
            set => TextCasterUpgradeTipsRaw = value.ToRaw(null, null);
        }

        public string TechtreeDependencyEquivalentsRaw
        {
            get => _modifications[1885693045].ValueAsString;
            set => _modifications[1885693045] = new SimpleObjectDataModification{Id = 1885693045, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Unit> TechtreeDependencyEquivalents
        {
            get => TechtreeDependencyEquivalentsRaw.ToIEnumerableUnit(this);
            set => TechtreeDependencyEquivalentsRaw = value.ToRaw(null, null);
        }

        public string TextDescription
        {
            get => _modifications[1936024681].ValueAsString;
            set => _modifications[1936024681] = new SimpleObjectDataModification{Id = 1936024681, Type = ObjectDataType.String, Value = value};
        }

        public string TextNameEditorSuffix
        {
            get => _modifications[1718840949].ValueAsString;
            set => _modifications[1718840949] = new SimpleObjectDataModification{Id = 1718840949, Type = ObjectDataType.String, Value = value};
        }

        public char TextHotkey
        {
            get => _modifications[1953458293].ValueAsChar;
            set => _modifications[1953458293] = new SimpleObjectDataModification{Id = 1953458293, Type = ObjectDataType.Char, Value = value};
        }

        public int SoundLoopingFadeInRate
        {
            get => _modifications[1768320117].ValueAsInt;
            set => _modifications[1768320117] = new SimpleObjectDataModification{Id = 1768320117, Type = ObjectDataType.Int, Value = value};
        }

        public int SoundLoopingFadeOutRate
        {
            get => _modifications[1868983413].ValueAsInt;
            set => _modifications[1868983413] = new SimpleObjectDataModification{Id = 1868983413, Type = ObjectDataType.Int, Value = value};
        }

        public string TechtreeItemsMadeRaw
        {
            get => _modifications[1768648053].ValueAsString;
            set => _modifications[1768648053] = new SimpleObjectDataModification{Id = 1768648053, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Item> TechtreeItemsMade
        {
            get => TechtreeItemsMadeRaw.ToIEnumerableItem(this);
            set => TechtreeItemsMadeRaw = value.ToRaw(null, 12);
        }

        public float CombatAttack1ProjectileArc
        {
            get => _modifications[828468597].ValueAsFloat;
            set => _modifications[828468597] = new SimpleObjectDataModification{Id = 828468597, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack2ProjectileArc
        {
            get => _modifications[845245813].ValueAsFloat;
            set => _modifications[845245813] = new SimpleObjectDataModification{Id = 845245813, Type = ObjectDataType.Unreal, Value = value};
        }

        public string CombatAttack1ProjectileArtRaw
        {
            get => _modifications[1831952757].ValueAsString;
            set => _modifications[1831952757] = new SimpleObjectDataModification{Id = 1831952757, Type = ObjectDataType.String, Value = value};
        }

        public string CombatAttack1ProjectileArt
        {
            get => CombatAttack1ProjectileArtRaw.ToString(this);
            set => CombatAttack1ProjectileArtRaw = value.ToRaw(null, null);
        }

        public string CombatAttack2ProjectileArtRaw
        {
            get => _modifications[1832018293].ValueAsString;
            set => _modifications[1832018293] = new SimpleObjectDataModification{Id = 1832018293, Type = ObjectDataType.String, Value = value};
        }

        public string CombatAttack2ProjectileArt
        {
            get => CombatAttack2ProjectileArtRaw.ToString(this);
            set => CombatAttack2ProjectileArtRaw = value.ToRaw(null, null);
        }

        public bool CombatAttack1ProjectileHomingEnabled
        {
            get => _modifications[828927349].ValueAsBool;
            set => _modifications[828927349] = new SimpleObjectDataModification{Id = 828927349, Type = ObjectDataType.Bool, Value = value};
        }

        public bool CombatAttack2ProjectileHomingEnabled
        {
            get => _modifications[845704565].ValueAsBool;
            set => _modifications[845704565] = new SimpleObjectDataModification{Id = 845704565, Type = ObjectDataType.Bool, Value = value};
        }

        public int CombatAttack1ProjectileSpeed
        {
            get => _modifications[2050056565].ValueAsInt;
            set => _modifications[2050056565] = new SimpleObjectDataModification{Id = 2050056565, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack2ProjectileSpeed
        {
            get => _modifications[2050122101].ValueAsInt;
            set => _modifications[2050122101] = new SimpleObjectDataModification{Id = 2050122101, Type = ObjectDataType.Int, Value = value};
        }

        public string SoundMovementRaw
        {
            get => _modifications[1819503989].ValueAsString;
            set => _modifications[1819503989] = new SimpleObjectDataModification{Id = 1819503989, Type = ObjectDataType.String, Value = value};
        }

        public string SoundMovement
        {
            get => SoundMovementRaw.ToString(this);
            set => SoundMovementRaw = value.ToRaw(null, null);
        }

        public string TextName
        {
            get => _modifications[1835101813].ValueAsString;
            set => _modifications[1835101813] = new SimpleObjectDataModification{Id = 1835101813, Type = ObjectDataType.String, Value = value};
        }

        public string TextProperNamesRaw
        {
            get => _modifications[1869770869].ValueAsString;
            set => _modifications[1869770869] = new SimpleObjectDataModification{Id = 1869770869, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<string> TextProperNames
        {
            get => TextProperNamesRaw.ToIEnumerableString(this);
            set => TextProperNamesRaw = value.ToRaw(null, 32);
        }

        public string SoundRandomRaw
        {
            get => _modifications[1819505269].ValueAsString;
            set => _modifications[1819505269] = new SimpleObjectDataModification{Id = 1819505269, Type = ObjectDataType.String, Value = value};
        }

        public string SoundRandom
        {
            get => SoundRandomRaw.ToString(this);
            set => SoundRandomRaw = value.ToRaw(null, null);
        }

        public int TechtreeRequirementsTiersUsed
        {
            get => _modifications[1668379253].ValueAsInt;
            set => _modifications[1668379253] = new SimpleObjectDataModification{Id = 1668379253, Type = ObjectDataType.Int, Value = value};
        }

        public string TechtreeRequirementsRaw
        {
            get => _modifications[1902473845].ValueAsString;
            set => _modifications[1902473845] = new SimpleObjectDataModification{Id = 1902473845, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tech> TechtreeRequirements
        {
            get => TechtreeRequirementsRaw.ToIEnumerableTech(this);
            set => TechtreeRequirementsRaw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsTier2Raw
        {
            get => _modifications[829518453].ValueAsString;
            set => _modifications[829518453] = new SimpleObjectDataModification{Id = 829518453, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tech> TechtreeRequirementsTier2
        {
            get => TechtreeRequirementsTier2Raw.ToIEnumerableTech(this);
            set => TechtreeRequirementsTier2Raw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsTier3Raw
        {
            get => _modifications[846295669].ValueAsString;
            set => _modifications[846295669] = new SimpleObjectDataModification{Id = 846295669, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tech> TechtreeRequirementsTier3
        {
            get => TechtreeRequirementsTier3Raw.ToIEnumerableTech(this);
            set => TechtreeRequirementsTier3Raw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsTier4Raw
        {
            get => _modifications[863072885].ValueAsString;
            set => _modifications[863072885] = new SimpleObjectDataModification{Id = 863072885, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tech> TechtreeRequirementsTier4
        {
            get => TechtreeRequirementsTier4Raw.ToIEnumerableTech(this);
            set => TechtreeRequirementsTier4Raw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsTier5Raw
        {
            get => _modifications[879850101].ValueAsString;
            set => _modifications[879850101] = new SimpleObjectDataModification{Id = 879850101, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tech> TechtreeRequirementsTier5
        {
            get => TechtreeRequirementsTier5Raw.ToIEnumerableTech(this);
            set => TechtreeRequirementsTier5Raw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsTier6Raw
        {
            get => _modifications[896627317].ValueAsString;
            set => _modifications[896627317] = new SimpleObjectDataModification{Id = 896627317, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tech> TechtreeRequirementsTier6
        {
            get => TechtreeRequirementsTier6Raw.ToIEnumerableTech(this);
            set => TechtreeRequirementsTier6Raw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsTier7Raw
        {
            get => _modifications[913404533].ValueAsString;
            set => _modifications[913404533] = new SimpleObjectDataModification{Id = 913404533, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tech> TechtreeRequirementsTier7
        {
            get => TechtreeRequirementsTier7Raw.ToIEnumerableTech(this);
            set => TechtreeRequirementsTier7Raw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsTier8Raw
        {
            get => _modifications[930181749].ValueAsString;
            set => _modifications[930181749] = new SimpleObjectDataModification{Id = 930181749, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tech> TechtreeRequirementsTier8
        {
            get => TechtreeRequirementsTier8Raw.ToIEnumerableTech(this);
            set => TechtreeRequirementsTier8Raw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsTier9Raw
        {
            get => _modifications[946958965].ValueAsString;
            set => _modifications[946958965] = new SimpleObjectDataModification{Id = 946958965, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tech> TechtreeRequirementsTier9
        {
            get => TechtreeRequirementsTier9Raw.ToIEnumerableTech(this);
            set => TechtreeRequirementsTier9Raw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsLevelsRaw
        {
            get => _modifications[1634824821].ValueAsString;
            set => _modifications[1634824821] = new SimpleObjectDataModification{Id = 1634824821, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<int> TechtreeRequirementsLevels
        {
            get => TechtreeRequirementsLevelsRaw.ToIEnumerableInt(this);
            set => TechtreeRequirementsLevelsRaw = value.ToRaw(null, null);
        }

        public string TechtreeResearchesAvailableRaw
        {
            get => _modifications[1936028277].ValueAsString;
            set => _modifications[1936028277] = new SimpleObjectDataModification{Id = 1936028277, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Upgrade> TechtreeResearchesAvailable
        {
            get => TechtreeResearchesAvailableRaw.ToIEnumerableUpgrade(this);
            set => TechtreeResearchesAvailableRaw = value.ToRaw(null, null);
        }

        public bool TechtreeRevivesDeadHeroes
        {
            get => _modifications[1986359925].ValueAsBool;
            set => _modifications[1986359925] = new SimpleObjectDataModification{Id = 1986359925, Type = ObjectDataType.Bool, Value = value};
        }

        public string TextTooltipRevive
        {
            get => _modifications[1919972469].ValueAsString;
            set => _modifications[1919972469] = new SimpleObjectDataModification{Id = 1919972469, Type = ObjectDataType.String, Value = value};
        }

        public string ArtIconScoreScreenRaw
        {
            get => _modifications[1769173877].ValueAsString;
            set => _modifications[1769173877] = new SimpleObjectDataModification{Id = 1769173877, Type = ObjectDataType.String, Value = value};
        }

        public string ArtIconScoreScreen
        {
            get => ArtIconScoreScreenRaw.ToString(this);
            set => ArtIconScoreScreenRaw = value.ToRaw(null, null);
        }

        public string TechtreeItemsSoldRaw
        {
            get => _modifications[1768256373].ValueAsString;
            set => _modifications[1768256373] = new SimpleObjectDataModification{Id = 1768256373, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Item> TechtreeItemsSold
        {
            get => TechtreeItemsSoldRaw.ToIEnumerableItem(this);
            set => TechtreeItemsSoldRaw = value.ToRaw(null, 12);
        }

        public string TechtreeUnitsSoldRaw
        {
            get => _modifications[1969582965].ValueAsString;
            set => _modifications[1969582965] = new SimpleObjectDataModification{Id = 1969582965, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Unit> TechtreeUnitsSold
        {
            get => TechtreeUnitsSoldRaw.ToIEnumerableUnit(this);
            set => TechtreeUnitsSoldRaw = value.ToRaw(null, 12);
        }

        public string ArtSpecialRaw
        {
            get => _modifications[1634759541].ValueAsString;
            set => _modifications[1634759541] = new SimpleObjectDataModification{Id = 1634759541, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<string> ArtSpecial
        {
            get => ArtSpecialRaw.ToIEnumerableString(this);
            set => ArtSpecialRaw = value.ToRaw(null, null);
        }

        public string ArtTargetRaw
        {
            get => _modifications[1633776757].ValueAsString;
            set => _modifications[1633776757] = new SimpleObjectDataModification{Id = 1633776757, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<string> ArtTarget
        {
            get => ArtTargetRaw.ToIEnumerableString(this);
            set => ArtTargetRaw = value.ToRaw(null, null);
        }

        public string TextTooltipBasic
        {
            get => _modifications[1885959285].ValueAsString;
            set => _modifications[1885959285] = new SimpleObjectDataModification{Id = 1885959285, Type = ObjectDataType.String, Value = value};
        }

        public string TechtreeUnitsTrainedRaw
        {
            get => _modifications[1634890869].ValueAsString;
            set => _modifications[1634890869] = new SimpleObjectDataModification{Id = 1634890869, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Unit> TechtreeUnitsTrained
        {
            get => TechtreeUnitsTrainedRaw.ToIEnumerableUnit(this);
            set => TechtreeUnitsTrainedRaw = value.ToRaw(null, null);
        }

        public string TechtreeHeroRevivalLocationsRaw
        {
            get => _modifications[1635152501].ValueAsString;
            set => _modifications[1635152501] = new SimpleObjectDataModification{Id = 1635152501, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Unit> TechtreeHeroRevivalLocations
        {
            get => TechtreeHeroRevivalLocationsRaw.ToIEnumerableUnit(this);
            set => TechtreeHeroRevivalLocationsRaw = value.ToRaw(null, null);
        }

        public string TextTooltipExtended
        {
            get => _modifications[1651864693].ValueAsString;
            set => _modifications[1651864693] = new SimpleObjectDataModification{Id = 1651864693, Type = ObjectDataType.String, Value = value};
        }

        public string TechtreeUpgradesToRaw
        {
            get => _modifications[1953527157].ValueAsString;
            set => _modifications[1953527157] = new SimpleObjectDataModification{Id = 1953527157, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Unit> TechtreeUpgradesTo
        {
            get => TechtreeUpgradesToRaw.ToIEnumerableUnit(this);
            set => TechtreeUpgradesToRaw = value.ToRaw(null, 12);
        }

        public string AbilitiesNormalRaw
        {
            get => _modifications[1768055157].ValueAsString;
            set => _modifications[1768055157] = new SimpleObjectDataModification{Id = 1768055157, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Ability> AbilitiesNormal
        {
            get => AbilitiesNormalRaw.ToIEnumerableAbility(this);
            set => AbilitiesNormalRaw = value.ToRaw(null, null);
        }

        public string AbilitiesDefaultActiveAbilityRaw
        {
            get => _modifications[1633772661].ValueAsString;
            set => _modifications[1633772661] = new SimpleObjectDataModification{Id = 1633772661, Type = ObjectDataType.String, Value = value};
        }

        public Ability AbilitiesDefaultActiveAbility
        {
            get => AbilitiesDefaultActiveAbilityRaw.ToAbility(this);
            set => AbilitiesDefaultActiveAbilityRaw = value.ToRaw(null, null);
        }

        public string AbilitiesHeroRaw
        {
            get => _modifications[1650550901].ValueAsString;
            set => _modifications[1650550901] = new SimpleObjectDataModification{Id = 1650550901, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Ability> AbilitiesHero
        {
            get => AbilitiesHeroRaw.ToIEnumerableAbility(this);
            set => AbilitiesHeroRaw = value.ToRaw(null, 5);
        }

        public int StatsStartingAgility
        {
            get => _modifications[1768382837].ValueAsInt;
            set => _modifications[1768382837] = new SimpleObjectDataModification{Id = 1768382837, Type = ObjectDataType.Int, Value = value};
        }

        public float StatsAgilityPerLevel
        {
            get => _modifications[1885823349].ValueAsFloat;
            set => _modifications[1885823349] = new SimpleObjectDataModification{Id = 1885823349, Type = ObjectDataType.Unreal, Value = value};
        }

        public int StatsBuildTime
        {
            get => _modifications[1684824693].ValueAsInt;
            set => _modifications[1684824693] = new SimpleObjectDataModification{Id = 1684824693, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsGoldBountyAwardedNumberOfDice
        {
            get => _modifications[1768186485].ValueAsInt;
            set => _modifications[1768186485] = new SimpleObjectDataModification{Id = 1768186485, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsGoldBountyAwardedBase
        {
            get => _modifications[1633837685].ValueAsInt;
            set => _modifications[1633837685] = new SimpleObjectDataModification{Id = 1633837685, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsGoldBountyAwardedSidesPerDie
        {
            get => _modifications[1769169525].ValueAsInt;
            set => _modifications[1769169525] = new SimpleObjectDataModification{Id = 1769169525, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsLumberBountyAwardedNumberOfDice
        {
            get => _modifications[1684171893].ValueAsInt;
            set => _modifications[1684171893] = new SimpleObjectDataModification{Id = 1684171893, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsLumberBountyAwardedBase
        {
            get => _modifications[1633840245].ValueAsInt;
            set => _modifications[1633840245] = new SimpleObjectDataModification{Id = 1633840245, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsLumberBountyAwardedSidesPerDie
        {
            get => _modifications[1935830133].ValueAsInt;
            set => _modifications[1935830133] = new SimpleObjectDataModification{Id = 1935830133, Type = ObjectDataType.Int, Value = value};
        }

        public float PathingCollisionSize
        {
            get => _modifications[1819239285].ValueAsFloat;
            set => _modifications[1819239285] = new SimpleObjectDataModification{Id = 1819239285, Type = ObjectDataType.Unreal, Value = value};
        }

        public int CombatDefenseBase
        {
            get => _modifications[1717920885].ValueAsInt;
            set => _modifications[1717920885] = new SimpleObjectDataModification{Id = 1717920885, Type = ObjectDataType.Int, Value = value};
        }

        public string CombatDefenseTypeRaw
        {
            get => _modifications[2037671029].ValueAsString;
            set => _modifications[2037671029] = new SimpleObjectDataModification{Id = 2037671029, Type = ObjectDataType.String, Value = value};
        }

        public DefenseType CombatDefenseType
        {
            get => CombatDefenseTypeRaw.ToDefenseType(this);
            set => CombatDefenseTypeRaw = value.ToRaw(null, null);
        }

        public int CombatDefenseUpgradeBonus
        {
            get => _modifications[1886741621].ValueAsInt;
            set => _modifications[1886741621] = new SimpleObjectDataModification{Id = 1886741621, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsFoodProduced
        {
            get => _modifications[1634559605].ValueAsInt;
            set => _modifications[1634559605] = new SimpleObjectDataModification{Id = 1634559605, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsFoodCost
        {
            get => _modifications[1869571701].ValueAsInt;
            set => _modifications[1869571701] = new SimpleObjectDataModification{Id = 1869571701, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsGoldCost
        {
            get => _modifications[1819240309].ValueAsInt;
            set => _modifications[1819240309] = new SimpleObjectDataModification{Id = 1819240309, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsRepairGoldCost
        {
            get => _modifications[1919903605].ValueAsInt;
            set => _modifications[1919903605] = new SimpleObjectDataModification{Id = 1919903605, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsHitPointsMaximumBase
        {
            get => _modifications[1836083317].ValueAsInt;
            set => _modifications[1836083317] = new SimpleObjectDataModification{Id = 1836083317, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsStartingIntelligence
        {
            get => _modifications[1953393013].ValueAsInt;
            set => _modifications[1953393013] = new SimpleObjectDataModification{Id = 1953393013, Type = ObjectDataType.Int, Value = value};
        }

        public float StatsIntelligencePerLevel
        {
            get => _modifications[1886284149].ValueAsFloat;
            set => _modifications[1886284149] = new SimpleObjectDataModification{Id = 1886284149, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool StatsIsABuilding
        {
            get => _modifications[1734632053].ValueAsBool;
            set => _modifications[1734632053] = new SimpleObjectDataModification{Id = 1734632053, Type = ObjectDataType.Bool, Value = value};
        }

        public int StatsLevel
        {
            get => _modifications[1986358389].ValueAsInt;
            set => _modifications[1986358389] = new SimpleObjectDataModification{Id = 1986358389, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsLumberCost
        {
            get => _modifications[1836412021].ValueAsInt;
            set => _modifications[1836412021] = new SimpleObjectDataModification{Id = 1836412021, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsRepairLumberCost
        {
            get => _modifications[1920298101].ValueAsInt;
            set => _modifications[1920298101] = new SimpleObjectDataModification{Id = 1920298101, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsManaInitialAmount
        {
            get => _modifications[1768975733].ValueAsInt;
            set => _modifications[1768975733] = new SimpleObjectDataModification{Id = 1768975733, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsManaMaximum
        {
            get => _modifications[1836084597].ValueAsInt;
            set => _modifications[1836084597] = new SimpleObjectDataModification{Id = 1836084597, Type = ObjectDataType.Int, Value = value};
        }

        public int MovementSpeedMaximum
        {
            get => _modifications[1935764853].ValueAsInt;
            set => _modifications[1935764853] = new SimpleObjectDataModification{Id = 1935764853, Type = ObjectDataType.Int, Value = value};
        }

        public int MovementSpeedMinimum
        {
            get => _modifications[1936289141].ValueAsInt;
            set => _modifications[1936289141] = new SimpleObjectDataModification{Id = 1936289141, Type = ObjectDataType.Int, Value = value};
        }

        public bool StatsNeutralBuildingValidAsRandomBuilding
        {
            get => _modifications[1919053429].ValueAsBool;
            set => _modifications[1919053429] = new SimpleObjectDataModification{Id = 1919053429, Type = ObjectDataType.Bool, Value = value};
        }

        public int StatsSightRadiusNight
        {
            get => _modifications[1852404597].ValueAsInt;
            set => _modifications[1852404597] = new SimpleObjectDataModification{Id = 1852404597, Type = ObjectDataType.Int, Value = value};
        }

        public string PathingPlacementRequiresRaw
        {
            get => _modifications[1885433973].ValueAsString;
            set => _modifications[1885433973] = new SimpleObjectDataModification{Id = 1885433973, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<PathingPrevent> PathingPlacementRequires
        {
            get => PathingPlacementRequiresRaw.ToIEnumerablePathingPrevent(this);
            set => PathingPlacementRequiresRaw = value.ToRaw(null, null);
        }

        public string StatsPrimaryAttributeRaw
        {
            get => _modifications[1634889845].ValueAsString;
            set => _modifications[1634889845] = new SimpleObjectDataModification{Id = 1634889845, Type = ObjectDataType.String, Value = value};
        }

        public AttributeType StatsPrimaryAttribute
        {
            get => StatsPrimaryAttributeRaw.ToAttributeType(this);
            set => StatsPrimaryAttributeRaw = value.ToRaw(null, null);
        }

        public float StatsHitPointsRegenerationRate
        {
            get => _modifications[1919969397].ValueAsFloat;
            set => _modifications[1919969397] = new SimpleObjectDataModification{Id = 1919969397, Type = ObjectDataType.Unreal, Value = value};
        }

        public float StatsManaRegeneration
        {
            get => _modifications[1919970677].ValueAsFloat;
            set => _modifications[1919970677] = new SimpleObjectDataModification{Id = 1919970677, Type = ObjectDataType.Unreal, Value = value};
        }

        public string StatsHitPointsRegenerationTypeRaw
        {
            get => _modifications[1953654901].ValueAsString;
            set => _modifications[1953654901] = new SimpleObjectDataModification{Id = 1953654901, Type = ObjectDataType.String, Value = value};
        }

        public RegenType StatsHitPointsRegenerationType
        {
            get => StatsHitPointsRegenerationTypeRaw.ToRegenType(this);
            set => StatsHitPointsRegenerationTypeRaw = value.ToRaw(null, null);
        }

        public int StatsRepairTime
        {
            get => _modifications[1836348021].ValueAsInt;
            set => _modifications[1836348021] = new SimpleObjectDataModification{Id = 1836348021, Type = ObjectDataType.Int, Value = value};
        }

        public bool MovementGroupSeparationEnabled
        {
            get => _modifications[1869640309].ValueAsBool;
            set => _modifications[1869640309] = new SimpleObjectDataModification{Id = 1869640309, Type = ObjectDataType.Bool, Value = value};
        }

        public int MovementGroupSeparationGroupNumber
        {
            get => _modifications[1735422581].ValueAsInt;
            set => _modifications[1735422581] = new SimpleObjectDataModification{Id = 1735422581, Type = ObjectDataType.Int, Value = value};
        }

        public int MovementGroupSeparationParameter
        {
            get => _modifications[1886417525].ValueAsInt;
            set => _modifications[1886417525] = new SimpleObjectDataModification{Id = 1886417525, Type = ObjectDataType.Int, Value = value};
        }

        public int MovementGroupSeparationPriority
        {
            get => _modifications[1919971957].ValueAsInt;
            set => _modifications[1919971957] = new SimpleObjectDataModification{Id = 1919971957, Type = ObjectDataType.Int, Value = value};
        }

        public string PathingPlacementPreventedByRaw
        {
            get => _modifications[1918988405].ValueAsString;
            set => _modifications[1918988405] = new SimpleObjectDataModification{Id = 1918988405, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<PathingRequire> PathingPlacementPreventedBy
        {
            get => PathingPlacementPreventedByRaw.ToIEnumerablePathingRequire(this);
            set => PathingPlacementPreventedByRaw = value.ToRaw(null, null);
        }

        public int StatsSightRadiusDay
        {
            get => _modifications[1684632437].ValueAsInt;
            set => _modifications[1684632437] = new SimpleObjectDataModification{Id = 1684632437, Type = ObjectDataType.Int, Value = value};
        }

        public int MovementSpeedBase
        {
            get => _modifications[1937141109].ValueAsInt;
            set => _modifications[1937141109] = new SimpleObjectDataModification{Id = 1937141109, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsStockMaximum
        {
            get => _modifications[1634562933].ValueAsInt;
            set => _modifications[1634562933] = new SimpleObjectDataModification{Id = 1634562933, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsStockReplenishInterval
        {
            get => _modifications[1735553909].ValueAsInt;
            set => _modifications[1735553909] = new SimpleObjectDataModification{Id = 1735553909, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsStockStartDelay
        {
            get => _modifications[1953723253].ValueAsInt;
            set => _modifications[1953723253] = new SimpleObjectDataModification{Id = 1953723253, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsStockInitialAfterStartDelay
        {
            get => _modifications[1953067893].ValueAsInt;
            set => _modifications[1953067893] = new SimpleObjectDataModification{Id = 1953067893, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsStartingStrength
        {
            get => _modifications[1920234357].ValueAsInt;
            set => _modifications[1920234357] = new SimpleObjectDataModification{Id = 1920234357, Type = ObjectDataType.Int, Value = value};
        }

        public float StatsStrengthPerLevel
        {
            get => _modifications[1886679925].ValueAsFloat;
            set => _modifications[1886679925] = new SimpleObjectDataModification{Id = 1886679925, Type = ObjectDataType.Unreal, Value = value};
        }

        public string EditorTilesetsRaw
        {
            get => _modifications[1818850421].ValueAsString;
            set => _modifications[1818850421] = new SimpleObjectDataModification{Id = 1818850421, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tileset> EditorTilesets
        {
            get => EditorTilesetsRaw.ToIEnumerableTileset(this);
            set => EditorTilesetsRaw = value.ToRaw(null, null);
        }

        public string StatsUnitClassificationRaw
        {
            get => _modifications[1887007861].ValueAsString;
            set => _modifications[1887007861] = new SimpleObjectDataModification{Id = 1887007861, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<UnitClassification> StatsUnitClassification
        {
            get => StatsUnitClassificationRaw.ToIEnumerableUnitClassification(this);
            set => StatsUnitClassificationRaw = value.ToRaw(null, null);
        }

        public string TechtreeUpgradesUsedRaw
        {
            get => _modifications[1919381621].ValueAsString;
            set => _modifications[1919381621] = new SimpleObjectDataModification{Id = 1919381621, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Upgrade> TechtreeUpgradesUsed
        {
            get => TechtreeUpgradesUsedRaw.ToIEnumerableUpgrade(this);
            set => TechtreeUpgradesUsedRaw = value.ToRaw(null, null);
        }

        public float PathingAIPlacementRadius
        {
            get => _modifications[1919050101].ValueAsFloat;
            set => _modifications[1919050101] = new SimpleObjectDataModification{Id = 1919050101, Type = ObjectDataType.Unreal, Value = value};
        }

        public string PathingAIPlacementTypeRaw
        {
            get => _modifications[1952604533].ValueAsString;
            set => _modifications[1952604533] = new SimpleObjectDataModification{Id = 1952604533, Type = ObjectDataType.String, Value = value};
        }

        public AiBuffer PathingAIPlacementType
        {
            get => PathingAIPlacementTypeRaw.ToAiBuffer(this);
            set => PathingAIPlacementTypeRaw = value.ToRaw(null, null);
        }

        public bool StatsCanBuildOn
        {
            get => _modifications[1868718965].ValueAsBool;
            set => _modifications[1868718965] = new SimpleObjectDataModification{Id = 1868718965, Type = ObjectDataType.Bool, Value = value};
        }

        public bool StatsCanFlee
        {
            get => _modifications[1701602933].ValueAsBool;
            set => _modifications[1701602933] = new SimpleObjectDataModification{Id = 1701602933, Type = ObjectDataType.Bool, Value = value};
        }

        public bool StatsSleeps
        {
            get => _modifications[1701606261].ValueAsBool;
            set => _modifications[1701606261] = new SimpleObjectDataModification{Id = 1701606261, Type = ObjectDataType.Bool, Value = value};
        }

        public int StatsTransportedSize
        {
            get => _modifications[1918985077].ValueAsInt;
            set => _modifications[1918985077] = new SimpleObjectDataModification{Id = 1918985077, Type = ObjectDataType.Int, Value = value};
        }

        public float ArtDeathTimeSeconds
        {
            get => _modifications[1836344437].ValueAsFloat;
            set => _modifications[1836344437] = new SimpleObjectDataModification{Id = 1836344437, Type = ObjectDataType.Unreal, Value = value};
        }

        public int CombatDeathTypeRaw
        {
            get => _modifications[1634034805].ValueAsInt;
            set => _modifications[1634034805] = new SimpleObjectDataModification{Id = 1634034805, Type = ObjectDataType.Int, Value = value};
        }

        public DeathType CombatDeathType
        {
            get => CombatDeathTypeRaw.ToDeathType(this);
            set => CombatDeathTypeRaw = value.ToRaw(null, null);
        }

        public bool ArtUseExtendedLineOfSight
        {
            get => _modifications[1936682101].ValueAsBool;
            set => _modifications[1936682101] = new SimpleObjectDataModification{Id = 1936682101, Type = ObjectDataType.Bool, Value = value};
        }

        public int StatsFormationRank
        {
            get => _modifications[1919903349].ValueAsInt;
            set => _modifications[1919903349] = new SimpleObjectDataModification{Id = 1919903349, Type = ObjectDataType.Int, Value = value};
        }

        public bool StatsCanBeBuiltOn
        {
            get => _modifications[1868720501].ValueAsBool;
            set => _modifications[1868720501] = new SimpleObjectDataModification{Id = 1868720501, Type = ObjectDataType.Bool, Value = value};
        }

        public float MovementHeightMinimum
        {
            get => _modifications[1719037301].ValueAsFloat;
            set => _modifications[1719037301] = new SimpleObjectDataModification{Id = 1719037301, Type = ObjectDataType.Unreal, Value = value};
        }

        public float MovementHeight
        {
            get => _modifications[1752591733].ValueAsFloat;
            set => _modifications[1752591733] = new SimpleObjectDataModification{Id = 1752591733, Type = ObjectDataType.Unreal, Value = value};
        }

        public string MovementTypeRaw
        {
            get => _modifications[1953918325].ValueAsString;
            set => _modifications[1953918325] = new SimpleObjectDataModification{Id = 1953918325, Type = ObjectDataType.String, Value = value};
        }

        public MoveType MovementType
        {
            get => MovementTypeRaw.ToMoveType(this);
            set => MovementTypeRaw = value.ToRaw(null, null);
        }

        public int TextProperNamesUsed
        {
            get => _modifications[1970434165].ValueAsInt;
            set => _modifications[1970434165] = new SimpleObjectDataModification{Id = 1970434165, Type = ObjectDataType.Int, Value = value};
        }

        public int ArtOrientationInterpolation
        {
            get => _modifications[1769107317].ValueAsInt;
            set => _modifications[1769107317] = new SimpleObjectDataModification{Id = 1769107317, Type = ObjectDataType.Int, Value = value};
        }

        public string PathingPathingMapRaw
        {
            get => _modifications[1952542837].ValueAsString;
            set => _modifications[1952542837] = new SimpleObjectDataModification{Id = 1952542837, Type = ObjectDataType.String, Value = value};
        }

        public string PathingPathingMap
        {
            get => PathingPathingMapRaw.ToString(this);
            set => PathingPathingMapRaw = value.ToRaw(null, null);
        }

        public int StatsPointValue
        {
            get => _modifications[1768910965].ValueAsInt;
            set => _modifications[1768910965] = new SimpleObjectDataModification{Id = 1768910965, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsPriority
        {
            get => _modifications[1769107573].ValueAsInt;
            set => _modifications[1769107573] = new SimpleObjectDataModification{Id = 1769107573, Type = ObjectDataType.Int, Value = value};
        }

        public float ArtPropulsionWindowDegrees
        {
            get => _modifications[2003988597].ValueAsFloat;
            set => _modifications[2003988597] = new SimpleObjectDataModification{Id = 2003988597, Type = ObjectDataType.Unreal, Value = value};
        }

        public string StatsRaceRaw
        {
            get => _modifications[1667330677].ValueAsString;
            set => _modifications[1667330677] = new SimpleObjectDataModification{Id = 1667330677, Type = ObjectDataType.String, Value = value};
        }

        public UnitRace StatsRace
        {
            get => StatsRaceRaw.ToUnitRace(this);
            set => StatsRaceRaw = value.ToRaw(null, null);
        }

        public float PathingPlacementRequiresWaterRadius
        {
            get => _modifications[2002874485].ValueAsFloat;
            set => _modifications[2002874485] = new SimpleObjectDataModification{Id = 2002874485, Type = ObjectDataType.Unreal, Value = value};
        }

        public string CombatTargetedAsRaw
        {
            get => _modifications[1918989429].ValueAsString;
            set => _modifications[1918989429] = new SimpleObjectDataModification{Id = 1918989429, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Target> CombatTargetedAs
        {
            get => CombatTargetedAsRaw.ToIEnumerableTarget(this);
            set => CombatTargetedAsRaw = value.ToRaw(null, null);
        }

        public float MovementTurnRate
        {
            get => _modifications[1920363893].ValueAsFloat;
            set => _modifications[1920363893] = new SimpleObjectDataModification{Id = 1920363893, Type = ObjectDataType.Unreal, Value = value};
        }

        public string CombatArmorTypeRaw
        {
            get => _modifications[1836212597].ValueAsString;
            set => _modifications[1836212597] = new SimpleObjectDataModification{Id = 1836212597, Type = ObjectDataType.String, Value = value};
        }

        public ArmorType CombatArmorType
        {
            get => CombatArmorTypeRaw.ToArmorType(this);
            set => CombatArmorTypeRaw = value.ToRaw(null, null);
        }

        public float ArtAnimationBlendTimeSeconds
        {
            get => _modifications[1701601909].ValueAsFloat;
            set => _modifications[1701601909] = new SimpleObjectDataModification{Id = 1701601909, Type = ObjectDataType.Real, Value = value};
        }

        public int ArtTintingColor3Blue
        {
            get => _modifications[1651270517].ValueAsInt;
            set => _modifications[1651270517] = new SimpleObjectDataModification{Id = 1651270517, Type = ObjectDataType.Int, Value = value};
        }

        public string ArtShadowTextureBuildingRaw
        {
            get => _modifications[1651012469].ValueAsString;
            set => _modifications[1651012469] = new SimpleObjectDataModification{Id = 1651012469, Type = ObjectDataType.String, Value = value};
        }

        public string ArtShadowTextureBuilding
        {
            get => ArtShadowTextureBuildingRaw.ToString(this);
            set => ArtShadowTextureBuildingRaw = value.ToRaw(null, null);
        }

        public bool EditorCategorizationCampaign
        {
            get => _modifications[1835098997].ValueAsBool;
            set => _modifications[1835098997] = new SimpleObjectDataModification{Id = 1835098997, Type = ObjectDataType.Bool, Value = value};
        }

        public bool ArtAllowCustomTeamColor
        {
            get => _modifications[1667462261].ValueAsBool;
            set => _modifications[1667462261] = new SimpleObjectDataModification{Id = 1667462261, Type = ObjectDataType.Bool, Value = value};
        }

        public bool EditorCanDropItemsOnDeath
        {
            get => _modifications[1869767797].ValueAsBool;
            set => _modifications[1869767797] = new SimpleObjectDataModification{Id = 1869767797, Type = ObjectDataType.Bool, Value = value};
        }

        public int ArtElevationSamplePoints
        {
            get => _modifications[1953523061].ValueAsInt;
            set => _modifications[1953523061] = new SimpleObjectDataModification{Id = 1953523061, Type = ObjectDataType.Int, Value = value};
        }

        public float ArtElevationSampleRadius
        {
            get => _modifications[1685218677].ValueAsFloat;
            set => _modifications[1685218677] = new SimpleObjectDataModification{Id = 1685218677, Type = ObjectDataType.Real, Value = value};
        }

        public string ArtModelFileRaw
        {
            get => _modifications[1818520949].ValueAsString;
            set => _modifications[1818520949] = new SimpleObjectDataModification{Id = 1818520949, Type = ObjectDataType.String, Value = value};
        }

        public string ArtModelFile
        {
            get => ArtModelFileRaw.ToString(this);
            set => ArtModelFileRaw = value.ToRaw(null, null);
        }

        public int ArtModelFileExtraVersionsRaw
        {
            get => _modifications[1919252085].ValueAsInt;
            set => _modifications[1919252085] = new SimpleObjectDataModification{Id = 1919252085, Type = ObjectDataType.Int, Value = value};
        }

        public VersionFlags ArtModelFileExtraVersions
        {
            get => ArtModelFileExtraVersionsRaw.ToVersionFlags(this);
            set => ArtModelFileExtraVersionsRaw = value.ToRaw(0, 3);
        }

        public float ArtFogOfWarSampleRadius
        {
            get => _modifications[1685218933].ValueAsFloat;
            set => _modifications[1685218933] = new SimpleObjectDataModification{Id = 1685218933, Type = ObjectDataType.Real, Value = value};
        }

        public int ArtTintingColor2Green
        {
            get => _modifications[1735156597].ValueAsInt;
            set => _modifications[1735156597] = new SimpleObjectDataModification{Id = 1735156597, Type = ObjectDataType.Int, Value = value};
        }

        public bool EditorDisplayAsNeutralHostile
        {
            get => _modifications[1936681077].ValueAsBool;
            set => _modifications[1936681077] = new SimpleObjectDataModification{Id = 1936681077, Type = ObjectDataType.Bool, Value = value};
        }

        public bool EditorPlaceableInEditor
        {
            get => _modifications[1701734773].ValueAsBool;
            set => _modifications[1701734773] = new SimpleObjectDataModification{Id = 1701734773, Type = ObjectDataType.Bool, Value = value};
        }

        public float ArtMaximumPitchAngleDegrees
        {
            get => _modifications[1886940533].ValueAsFloat;
            set => _modifications[1886940533] = new SimpleObjectDataModification{Id = 1886940533, Type = ObjectDataType.Real, Value = value};
        }

        public float ArtMaximumRollAngleDegrees
        {
            get => _modifications[1920494965].ValueAsFloat;
            set => _modifications[1920494965] = new SimpleObjectDataModification{Id = 1920494965, Type = ObjectDataType.Real, Value = value};
        }

        public float ArtScalingValue
        {
            get => _modifications[1633907573].ValueAsFloat;
            set => _modifications[1633907573] = new SimpleObjectDataModification{Id = 1633907573, Type = ObjectDataType.Real, Value = value};
        }

        public bool StatsNeutralBuildingShowsMinimapIcon
        {
            get => _modifications[1835167349].ValueAsBool;
            set => _modifications[1835167349] = new SimpleObjectDataModification{Id = 1835167349, Type = ObjectDataType.Bool, Value = value};
        }

        public bool StatsHeroHideHeroInterfaceIcon
        {
            get => _modifications[1651009653].ValueAsBool;
            set => _modifications[1651009653] = new SimpleObjectDataModification{Id = 1651009653, Type = ObjectDataType.Bool, Value = value};
        }

        public bool StatsHeroHideHeroMinimapDisplay
        {
            get => _modifications[1835559029].ValueAsBool;
            set => _modifications[1835559029] = new SimpleObjectDataModification{Id = 1835559029, Type = ObjectDataType.Bool, Value = value};
        }

        public bool StatsHeroHideHeroDeathMessage
        {
            get => _modifications[1684564085].ValueAsBool;
            set => _modifications[1684564085] = new SimpleObjectDataModification{Id = 1684564085, Type = ObjectDataType.Bool, Value = value};
        }

        public bool StatsHideMinimapDisplay
        {
            get => _modifications[1836017781].ValueAsBool;
            set => _modifications[1836017781] = new SimpleObjectDataModification{Id = 1836017781, Type = ObjectDataType.Bool, Value = value};
        }

        public float ArtOccluderHeight
        {
            get => _modifications[1667460981].ValueAsFloat;
            set => _modifications[1667460981] = new SimpleObjectDataModification{Id = 1667460981, Type = ObjectDataType.Unreal, Value = value};
        }

        public int ArtTintingColor1Red
        {
            get => _modifications[1919705973].ValueAsInt;
            set => _modifications[1919705973] = new SimpleObjectDataModification{Id = 1919705973, Type = ObjectDataType.Int, Value = value};
        }

        public float ArtAnimationRunSpeed
        {
            get => _modifications[1853190773].ValueAsFloat;
            set => _modifications[1853190773] = new SimpleObjectDataModification{Id = 1853190773, Type = ObjectDataType.Real, Value = value};
        }

        public float ArtSelectionScale
        {
            get => _modifications[1668510581].ValueAsFloat;
            set => _modifications[1668510581] = new SimpleObjectDataModification{Id = 1668510581, Type = ObjectDataType.Real, Value = value};
        }

        public bool ArtScaleProjectiles
        {
            get => _modifications[1650684789].ValueAsBool;
            set => _modifications[1650684789] = new SimpleObjectDataModification{Id = 1650684789, Type = ObjectDataType.Bool, Value = value};
        }

        public bool ArtSelectionCircleOnWater
        {
            get => _modifications[2003137397].ValueAsBool;
            set => _modifications[2003137397] = new SimpleObjectDataModification{Id = 2003137397, Type = ObjectDataType.Bool, Value = value};
        }

        public float ArtSelectionCircleHeight
        {
            get => _modifications[2053927797].ValueAsFloat;
            set => _modifications[2053927797] = new SimpleObjectDataModification{Id = 2053927797, Type = ObjectDataType.Real, Value = value};
        }

        public float ArtShadowImageHeight
        {
            get => _modifications[1751675765].ValueAsFloat;
            set => _modifications[1751675765] = new SimpleObjectDataModification{Id = 1751675765, Type = ObjectDataType.Real, Value = value};
        }

        public bool ArtHasWaterShadow
        {
            get => _modifications[1919447925].ValueAsBool;
            set => _modifications[1919447925] = new SimpleObjectDataModification{Id = 1919447925, Type = ObjectDataType.Bool, Value = value};
        }

        public float ArtShadowImageWidth
        {
            get => _modifications[2003334005].ValueAsFloat;
            set => _modifications[2003334005] = new SimpleObjectDataModification{Id = 2003334005, Type = ObjectDataType.Real, Value = value};
        }

        public float ArtShadowImageCenterX
        {
            get => _modifications[2020111221].ValueAsFloat;
            set => _modifications[2020111221] = new SimpleObjectDataModification{Id = 2020111221, Type = ObjectDataType.Real, Value = value};
        }

        public float ArtShadowImageCenterY
        {
            get => _modifications[2036888437].ValueAsFloat;
            set => _modifications[2036888437] = new SimpleObjectDataModification{Id = 2036888437, Type = ObjectDataType.Real, Value = value};
        }

        public bool EditorCategorizationSpecial
        {
            get => _modifications[1701868405].ValueAsBool;
            set => _modifications[1701868405] = new SimpleObjectDataModification{Id = 1701868405, Type = ObjectDataType.Bool, Value = value};
        }

        public int ArtTeamColorRaw
        {
            get => _modifications[1868788853].ValueAsInt;
            set => _modifications[1868788853] = new SimpleObjectDataModification{Id = 1868788853, Type = ObjectDataType.Int, Value = value};
        }

        public TeamColor ArtTeamColor
        {
            get => ArtTeamColorRaw.ToTeamColor(this);
            set => ArtTeamColorRaw = value.ToRaw(null, null);
        }

        public bool EditorHasTilesetSpecificData
        {
            get => _modifications[1936946293].ValueAsBool;
            set => _modifications[1936946293] = new SimpleObjectDataModification{Id = 1936946293, Type = ObjectDataType.Bool, Value = value};
        }

        public string ArtGroundTextureRaw
        {
            get => _modifications[1935832437].ValueAsString;
            set => _modifications[1935832437] = new SimpleObjectDataModification{Id = 1935832437, Type = ObjectDataType.String, Value = value};
        }

        public string ArtGroundTexture
        {
            get => ArtGroundTextureRaw.ToString(this);
            set => ArtGroundTextureRaw = value.ToRaw(null, null);
        }

        public string ArtShadowImageUnitRaw
        {
            get => _modifications[1969779573].ValueAsString;
            set => _modifications[1969779573] = new SimpleObjectDataModification{Id = 1969779573, Type = ObjectDataType.String, Value = value};
        }

        public ShadowImage ArtShadowImageUnit
        {
            get => ArtShadowImageUnitRaw.ToShadowImage(this);
            set => ArtShadowImageUnitRaw = value.ToRaw(null, null);
        }

        public string SoundUnitSoundSetRaw
        {
            get => _modifications[1684960117].ValueAsString;
            set => _modifications[1684960117] = new SimpleObjectDataModification{Id = 1684960117, Type = ObjectDataType.String, Value = value};
        }

        public string SoundUnitSoundSet
        {
            get => SoundUnitSoundSetRaw.ToString(this);
            set => SoundUnitSoundSetRaw = value.ToRaw(null, null);
        }

        public bool EditorUseClickHelper
        {
            get => _modifications[1751348597].ValueAsBool;
            set => _modifications[1751348597] = new SimpleObjectDataModification{Id = 1751348597, Type = ObjectDataType.Bool, Value = value};
        }

        public float ArtAnimationWalkSpeed
        {
            get => _modifications[1818326901].ValueAsFloat;
            set => _modifications[1818326901] = new SimpleObjectDataModification{Id = 1818326901, Type = ObjectDataType.Real, Value = value};
        }

        public float CombatAcquisitionRange
        {
            get => _modifications[1902338421].ValueAsFloat;
            set => _modifications[1902338421] = new SimpleObjectDataModification{Id = 1902338421, Type = ObjectDataType.Unreal, Value = value};
        }

        public string CombatAttack1AttackTypeRaw
        {
            get => _modifications[1949393269].ValueAsString;
            set => _modifications[1949393269] = new SimpleObjectDataModification{Id = 1949393269, Type = ObjectDataType.String, Value = value};
        }

        public AttackType CombatAttack1AttackType
        {
            get => CombatAttack1AttackTypeRaw.ToAttackType(this);
            set => CombatAttack1AttackTypeRaw = value.ToRaw(null, null);
        }

        public string CombatAttack2AttackTypeRaw
        {
            get => _modifications[1949458805].ValueAsString;
            set => _modifications[1949458805] = new SimpleObjectDataModification{Id = 1949458805, Type = ObjectDataType.String, Value = value};
        }

        public AttackType CombatAttack2AttackType
        {
            get => CombatAttack2AttackTypeRaw.ToAttackType(this);
            set => CombatAttack2AttackTypeRaw = value.ToRaw(null, null);
        }

        public float CombatAttack1AnimationBackswingPoint
        {
            get => _modifications[829645429].ValueAsFloat;
            set => _modifications[829645429] = new SimpleObjectDataModification{Id = 829645429, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack2AnimationBackswingPoint
        {
            get => _modifications[846422645].ValueAsFloat;
            set => _modifications[846422645] = new SimpleObjectDataModification{Id = 846422645, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtAnimationCastBackswing
        {
            get => _modifications[1935827829].ValueAsFloat;
            set => _modifications[1935827829] = new SimpleObjectDataModification{Id = 1935827829, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtAnimationCastPoint
        {
            get => _modifications[1953522549].ValueAsFloat;
            set => _modifications[1953522549] = new SimpleObjectDataModification{Id = 1953522549, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack1CooldownTime
        {
            get => _modifications[1664180597].ValueAsFloat;
            set => _modifications[1664180597] = new SimpleObjectDataModification{Id = 1664180597, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack2CooldownTime
        {
            get => _modifications[1664246133].ValueAsFloat;
            set => _modifications[1664246133] = new SimpleObjectDataModification{Id = 1664246133, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack1DamageLossFactor
        {
            get => _modifications[829187189].ValueAsFloat;
            set => _modifications[829187189] = new SimpleObjectDataModification{Id = 829187189, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack2DamageLossFactor
        {
            get => _modifications[845964405].ValueAsFloat;
            set => _modifications[845964405] = new SimpleObjectDataModification{Id = 845964405, Type = ObjectDataType.Unreal, Value = value};
        }

        public int CombatAttack1DamageNumberOfDice
        {
            get => _modifications[1680957813].ValueAsInt;
            set => _modifications[1680957813] = new SimpleObjectDataModification{Id = 1680957813, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack2DamageNumberOfDice
        {
            get => _modifications[1681023349].ValueAsInt;
            set => _modifications[1681023349] = new SimpleObjectDataModification{Id = 1681023349, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack1DamageBase
        {
            get => _modifications[1647403381].ValueAsInt;
            set => _modifications[1647403381] = new SimpleObjectDataModification{Id = 1647403381, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack2DamageBase
        {
            get => _modifications[1647468917].ValueAsInt;
            set => _modifications[1647468917] = new SimpleObjectDataModification{Id = 1647468917, Type = ObjectDataType.Int, Value = value};
        }

        public float CombatAttack1AnimationDamagePoint
        {
            get => _modifications[829449333].ValueAsFloat;
            set => _modifications[829449333] = new SimpleObjectDataModification{Id = 829449333, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack2AnimationDamagePoint
        {
            get => _modifications[846226549].ValueAsFloat;
            set => _modifications[846226549] = new SimpleObjectDataModification{Id = 846226549, Type = ObjectDataType.Unreal, Value = value};
        }

        public int CombatAttack1DamageUpgradeAmount
        {
            get => _modifications[829777013].ValueAsInt;
            set => _modifications[829777013] = new SimpleObjectDataModification{Id = 829777013, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack2DamageUpgradeAmount
        {
            get => _modifications[846554229].ValueAsInt;
            set => _modifications[846554229] = new SimpleObjectDataModification{Id = 846554229, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack1AreaOfEffectFullDamage
        {
            get => _modifications[1714512245].ValueAsInt;
            set => _modifications[1714512245] = new SimpleObjectDataModification{Id = 1714512245, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack2AreaOfEffectFullDamage
        {
            get => _modifications[1714577781].ValueAsInt;
            set => _modifications[1714577781] = new SimpleObjectDataModification{Id = 1714577781, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack1AreaOfEffectMediumDamage
        {
            get => _modifications[1748066677].ValueAsInt;
            set => _modifications[1748066677] = new SimpleObjectDataModification{Id = 1748066677, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack2AreaOfEffectMediumDamage
        {
            get => _modifications[1748132213].ValueAsInt;
            set => _modifications[1748132213] = new SimpleObjectDataModification{Id = 1748132213, Type = ObjectDataType.Int, Value = value};
        }

        public float CombatAttack1DamageFactorMedium
        {
            get => _modifications[828663925].ValueAsFloat;
            set => _modifications[828663925] = new SimpleObjectDataModification{Id = 828663925, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack2DamageFactorMedium
        {
            get => _modifications[845441141].ValueAsFloat;
            set => _modifications[845441141] = new SimpleObjectDataModification{Id = 845441141, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtProjectileImpactZSwimming
        {
            get => _modifications[2054383989].ValueAsFloat;
            set => _modifications[2054383989] = new SimpleObjectDataModification{Id = 2054383989, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtProjectileImpactZ
        {
            get => _modifications[2053990773].ValueAsFloat;
            set => _modifications[2053990773] = new SimpleObjectDataModification{Id = 2053990773, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtProjectileLaunchZSwimming
        {
            get => _modifications[2054384757].ValueAsFloat;
            set => _modifications[2054384757] = new SimpleObjectDataModification{Id = 2054384757, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtProjectileLaunchX
        {
            get => _modifications[2020633717].ValueAsFloat;
            set => _modifications[2020633717] = new SimpleObjectDataModification{Id = 2020633717, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtProjectileLaunchY
        {
            get => _modifications[2037410933].ValueAsFloat;
            set => _modifications[2037410933] = new SimpleObjectDataModification{Id = 2037410933, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtProjectileLaunchZ
        {
            get => _modifications[2054188149].ValueAsFloat;
            set => _modifications[2054188149] = new SimpleObjectDataModification{Id = 2054188149, Type = ObjectDataType.Unreal, Value = value};
        }

        public int CombatMinimumAttackRange
        {
            get => _modifications[1852662133].ValueAsInt;
            set => _modifications[1852662133] = new SimpleObjectDataModification{Id = 1852662133, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack1AreaOfEffectSmallDamage
        {
            get => _modifications[1899061621].ValueAsInt;
            set => _modifications[1899061621] = new SimpleObjectDataModification{Id = 1899061621, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack2AreaOfEffectSmallDamage
        {
            get => _modifications[1899127157].ValueAsInt;
            set => _modifications[1899127157] = new SimpleObjectDataModification{Id = 1899127157, Type = ObjectDataType.Int, Value = value};
        }

        public float CombatAttack1DamageFactorSmall
        {
            get => _modifications[828666229].ValueAsFloat;
            set => _modifications[828666229] = new SimpleObjectDataModification{Id = 828666229, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack2DamageFactorSmall
        {
            get => _modifications[845443445].ValueAsFloat;
            set => _modifications[845443445] = new SimpleObjectDataModification{Id = 845443445, Type = ObjectDataType.Unreal, Value = value};
        }

        public int CombatAttack1Range
        {
            get => _modifications[1915838837].ValueAsInt;
            set => _modifications[1915838837] = new SimpleObjectDataModification{Id = 1915838837, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack2Range
        {
            get => _modifications[1915904373].ValueAsInt;
            set => _modifications[1915904373] = new SimpleObjectDataModification{Id = 1915904373, Type = ObjectDataType.Int, Value = value};
        }

        public float CombatAttack1RangeMotionBuffer
        {
            get => _modifications[828535413].ValueAsFloat;
            set => _modifications[828535413] = new SimpleObjectDataModification{Id = 828535413, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack2RangeMotionBuffer
        {
            get => _modifications[845312629].ValueAsFloat;
            set => _modifications[845312629] = new SimpleObjectDataModification{Id = 845312629, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool CombatAttack1ShowUI
        {
            get => _modifications[829781877].ValueAsBool;
            set => _modifications[829781877] = new SimpleObjectDataModification{Id = 829781877, Type = ObjectDataType.Bool, Value = value};
        }

        public bool CombatAttack2ShowUI
        {
            get => _modifications[846559093].ValueAsBool;
            set => _modifications[846559093] = new SimpleObjectDataModification{Id = 846559093, Type = ObjectDataType.Bool, Value = value};
        }

        public int CombatAttack1DamageSidesPerDie
        {
            get => _modifications[1932616053].ValueAsInt;
            set => _modifications[1932616053] = new SimpleObjectDataModification{Id = 1932616053, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack2DamageSidesPerDie
        {
            get => _modifications[1932681589].ValueAsInt;
            set => _modifications[1932681589] = new SimpleObjectDataModification{Id = 1932681589, Type = ObjectDataType.Int, Value = value};
        }

        public float CombatAttack1DamageSpillDistance
        {
            get => _modifications[828666741].ValueAsFloat;
            set => _modifications[828666741] = new SimpleObjectDataModification{Id = 828666741, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack2DamageSpillDistance
        {
            get => _modifications[845443957].ValueAsFloat;
            set => _modifications[845443957] = new SimpleObjectDataModification{Id = 845443957, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack1DamageSpillRadius
        {
            get => _modifications[829584245].ValueAsFloat;
            set => _modifications[829584245] = new SimpleObjectDataModification{Id = 829584245, Type = ObjectDataType.Unreal, Value = value};
        }

        public float CombatAttack2DamageSpillRadius
        {
            get => _modifications[846361461].ValueAsFloat;
            set => _modifications[846361461] = new SimpleObjectDataModification{Id = 846361461, Type = ObjectDataType.Unreal, Value = value};
        }

        public string CombatAttack1AreaOfEffectTargetsRaw
        {
            get => _modifications[1882284405].ValueAsString;
            set => _modifications[1882284405] = new SimpleObjectDataModification{Id = 1882284405, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Target> CombatAttack1AreaOfEffectTargets
        {
            get => CombatAttack1AreaOfEffectTargetsRaw.ToIEnumerableTarget(this);
            set => CombatAttack1AreaOfEffectTargetsRaw = value.ToRaw(null, null);
        }

        public string CombatAttack2AreaOfEffectTargetsRaw
        {
            get => _modifications[1882349941].ValueAsString;
            set => _modifications[1882349941] = new SimpleObjectDataModification{Id = 1882349941, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Target> CombatAttack2AreaOfEffectTargets
        {
            get => CombatAttack2AreaOfEffectTargetsRaw.ToIEnumerableTarget(this);
            set => CombatAttack2AreaOfEffectTargetsRaw = value.ToRaw(null, null);
        }

        public int CombatAttack1MaximumNumberOfTargets
        {
            get => _modifications[828601461].ValueAsInt;
            set => _modifications[828601461] = new SimpleObjectDataModification{Id = 828601461, Type = ObjectDataType.Int, Value = value};
        }

        public int CombatAttack2MaximumNumberOfTargets
        {
            get => _modifications[845378677].ValueAsInt;
            set => _modifications[845378677] = new SimpleObjectDataModification{Id = 845378677, Type = ObjectDataType.Int, Value = value};
        }

        public string CombatAttack1TargetsAllowedRaw
        {
            get => _modifications[1731289461].ValueAsString;
            set => _modifications[1731289461] = new SimpleObjectDataModification{Id = 1731289461, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Target> CombatAttack1TargetsAllowed
        {
            get => CombatAttack1TargetsAllowedRaw.ToIEnumerableTarget(this);
            set => CombatAttack1TargetsAllowedRaw = value.ToRaw(null, null);
        }

        public string CombatAttack2TargetsAllowedRaw
        {
            get => _modifications[1731354997].ValueAsString;
            set => _modifications[1731354997] = new SimpleObjectDataModification{Id = 1731354997, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Target> CombatAttack2TargetsAllowed
        {
            get => CombatAttack2TargetsAllowedRaw.ToIEnumerableTarget(this);
            set => CombatAttack2TargetsAllowedRaw = value.ToRaw(null, null);
        }

        public int CombatAttacksEnabledRaw
        {
            get => _modifications[1852137845].ValueAsInt;
            set => _modifications[1852137845] = new SimpleObjectDataModification{Id = 1852137845, Type = ObjectDataType.Int, Value = value};
        }

        public AttackBits CombatAttacksEnabled
        {
            get => CombatAttacksEnabledRaw.ToAttackBits(this);
            set => CombatAttacksEnabledRaw = value.ToRaw(null, null);
        }

        public string CombatAttack1WeaponTypeRaw
        {
            get => _modifications[1999724917].ValueAsString;
            set => _modifications[1999724917] = new SimpleObjectDataModification{Id = 1999724917, Type = ObjectDataType.String, Value = value};
        }

        public WeaponType CombatAttack1WeaponType
        {
            get => CombatAttack1WeaponTypeRaw.ToWeaponType(this);
            set => CombatAttack1WeaponTypeRaw = value.ToRaw(null, null);
        }

        public string CombatAttack2WeaponTypeRaw
        {
            get => _modifications[1999790453].ValueAsString;
            set => _modifications[1999790453] = new SimpleObjectDataModification{Id = 1999790453, Type = ObjectDataType.String, Value = value};
        }

        public WeaponType CombatAttack2WeaponType
        {
            get => CombatAttack2WeaponTypeRaw.ToWeaponType(this);
            set => CombatAttack2WeaponTypeRaw = value.ToRaw(null, null);
        }

        public string CombatAttack1WeaponSoundRaw
        {
            get => _modifications[829645685].ValueAsString;
            set => _modifications[829645685] = new SimpleObjectDataModification{Id = 829645685, Type = ObjectDataType.String, Value = value};
        }

        public CombatSound CombatAttack1WeaponSound
        {
            get => CombatAttack1WeaponSoundRaw.ToCombatSound(this);
            set => CombatAttack1WeaponSoundRaw = value.ToRaw(null, null);
        }

        public string CombatAttack2WeaponSoundRaw
        {
            get => _modifications[846422901].ValueAsString;
            set => _modifications[846422901] = new SimpleObjectDataModification{Id = 846422901, Type = ObjectDataType.String, Value = value};
        }

        public CombatSound CombatAttack2WeaponSound
        {
            get => CombatAttack2WeaponSoundRaw.ToCombatSound(this);
            set => CombatAttack2WeaponSoundRaw = value.ToRaw(null, null);
        }

        public string AbilitiesNormalSkinRaw
        {
            get => _modifications[1935827317].ValueAsString;
            set => _modifications[1935827317] = new SimpleObjectDataModification{Id = 1935827317, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Ability> AbilitiesNormalSkin
        {
            get => AbilitiesNormalSkinRaw.ToIEnumerableAbility(this);
            set => AbilitiesNormalSkinRaw = value.ToRaw(null, null);
        }

        public string AbilitiesHeroSkinRaw
        {
            get => _modifications[1935763573].ValueAsString;
            set => _modifications[1935763573] = new SimpleObjectDataModification{Id = 1935763573, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Ability> AbilitiesHeroSkin
        {
            get => AbilitiesHeroSkinRaw.ToIEnumerableAbility(this);
            set => AbilitiesHeroSkinRaw = value.ToRaw(null, null);
        }

        public static explicit operator SimpleObjectModification(Unit unit) => new SimpleObjectModification{OldId = unit.OldId, NewId = unit.NewId, Modifications = unit.Modifications.ToList()};
    }
}