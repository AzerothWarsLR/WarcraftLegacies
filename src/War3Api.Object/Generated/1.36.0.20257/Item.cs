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
    public sealed class Item : BaseObject
    {
        private readonly SimpleObjectDataModifications _modifications;
        public Item(ItemType itemType): this((int)itemType)
        {
        }

        public Item(ItemType itemType, int newId): this((int)itemType, newId)
        {
        }

        public Item(ItemType itemType, string newRawcode): this((int)itemType, newRawcode)
        {
        }

        public Item(ItemType itemType, ObjectDatabaseBase db): this((int)itemType, db)
        {
        }

        public Item(ItemType itemType, int newId, ObjectDatabaseBase db): this((int)itemType, newId, db)
        {
        }

        public Item(ItemType itemType, string newRawcode, ObjectDatabaseBase db): this((int)itemType, newRawcode, db)
        {
        }

        private Item(int oldId): base(oldId)
        {
            _modifications = new(this);
        }

        private Item(int oldId, int newId): base(oldId, newId)
        {
            _modifications = new(this);
        }

        private Item(int oldId, string newRawcode): base(oldId, newRawcode)
        {
            _modifications = new(this);
        }

        private Item(int oldId, ObjectDatabaseBase db): base(oldId, db)
        {
            _modifications = new(this);
        }

        private Item(int oldId, int newId, ObjectDatabaseBase db): base(oldId, newId, db)
        {
            _modifications = new(this);
        }

        private Item(int oldId, string newRawcode, ObjectDatabaseBase db): base(oldId, newRawcode, db)
        {
            _modifications = new(this);
        }

        public SimpleObjectDataModifications Modifications => _modifications;
        public string AbilitiesAbilitiesRaw
        {
            get => _modifications.GetModification(1768055145).ValueAsString;
            set => _modifications[1768055145] = new SimpleObjectDataModification{Id = 1768055145, Type = ObjectDataType.String, Value = value};
        }

        public bool IsAbilitiesAbilitiesModified => _modifications.ContainsKey(1768055145);
        public IEnumerable<Ability> AbilitiesAbilities
        {
            get => AbilitiesAbilitiesRaw.ToIEnumerableAbility(this);
            set => AbilitiesAbilitiesRaw = value.ToRaw(null, 4);
        }

        public string CombatArmorTypeRaw
        {
            get => _modifications.GetModification(1836212585).ValueAsString;
            set => _modifications[1836212585] = new SimpleObjectDataModification{Id = 1836212585, Type = ObjectDataType.String, Value = value};
        }

        public bool IsCombatArmorTypeModified => _modifications.ContainsKey(1836212585);
        public ArmorType CombatArmorType
        {
            get => CombatArmorTypeRaw.ToArmorType(this);
            set => CombatArmorTypeRaw = value.ToRaw(null, null);
        }

        public string StatsClassificationRaw
        {
            get => _modifications.GetModification(1634493289).ValueAsString;
            set => _modifications[1634493289] = new SimpleObjectDataModification{Id = 1634493289, Type = ObjectDataType.String, Value = value};
        }

        public bool IsStatsClassificationModified => _modifications.ContainsKey(1634493289);
        public ItemClass StatsClassification
        {
            get => StatsClassificationRaw.ToItemClass(this);
            set => StatsClassificationRaw = value.ToRaw(null, null);
        }

        public int ArtTintingColor3Blue
        {
            get => _modifications.GetModification(1651270505).ValueAsInt;
            set => _modifications[1651270505] = new SimpleObjectDataModification{Id = 1651270505, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtTintingColor3BlueModified => _modifications.ContainsKey(1651270505);
        public int ArtTintingColor2Green
        {
            get => _modifications.GetModification(1735156585).ValueAsInt;
            set => _modifications[1735156585] = new SimpleObjectDataModification{Id = 1735156585, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtTintingColor2GreenModified => _modifications.ContainsKey(1735156585);
        public int ArtTintingColor1Red
        {
            get => _modifications.GetModification(1919705961).ValueAsInt;
            set => _modifications[1919705961] = new SimpleObjectDataModification{Id = 1919705961, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtTintingColor1RedModified => _modifications.ContainsKey(1919705961);
        public string StatsCooldownGroupRaw
        {
            get => _modifications.GetModification(1684628329).ValueAsString;
            set => _modifications[1684628329] = new SimpleObjectDataModification{Id = 1684628329, Type = ObjectDataType.String, Value = value};
        }

        public bool IsStatsCooldownGroupModified => _modifications.ContainsKey(1684628329);
        public Ability StatsCooldownGroup
        {
            get => StatsCooldownGroupRaw.ToAbility(this);
            set => StatsCooldownGroupRaw = value.ToRaw(null, null);
        }

        public int StatsDroppedWhenCarrierDiesRaw
        {
            get => _modifications.GetModification(1886545001).ValueAsInt;
            set => _modifications[1886545001] = new SimpleObjectDataModification{Id = 1886545001, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsDroppedWhenCarrierDiesModified => _modifications.ContainsKey(1886545001);
        public bool StatsDroppedWhenCarrierDies
        {
            get => StatsDroppedWhenCarrierDiesRaw.ToBool(this);
            set => StatsDroppedWhenCarrierDiesRaw = value.ToRaw(null, null);
        }

        public int StatsCanBeDroppedRaw
        {
            get => _modifications.GetModification(1869767785).ValueAsInt;
            set => _modifications[1869767785] = new SimpleObjectDataModification{Id = 1869767785, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsCanBeDroppedModified => _modifications.ContainsKey(1869767785);
        public bool StatsCanBeDropped
        {
            get => StatsCanBeDroppedRaw.ToBool(this);
            set => StatsCanBeDroppedRaw = value.ToRaw(null, null);
        }

        public string ArtModelUsedRaw
        {
            get => _modifications.GetModification(1818846825).ValueAsString;
            set => _modifications[1818846825] = new SimpleObjectDataModification{Id = 1818846825, Type = ObjectDataType.String, Value = value};
        }

        public bool IsArtModelUsedModified => _modifications.ContainsKey(1818846825);
        public string ArtModelUsed
        {
            get => ArtModelUsedRaw.ToString(this);
            set => ArtModelUsedRaw = value.ToRaw(null, null);
        }

        public int StatsGoldCost
        {
            get => _modifications.GetModification(1819240297).ValueAsInt;
            set => _modifications[1819240297] = new SimpleObjectDataModification{Id = 1819240297, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsGoldCostModified => _modifications.ContainsKey(1819240297);
        public int StatsHitPoints
        {
            get => _modifications.GetModification(1886677097).ValueAsInt;
            set => _modifications[1886677097] = new SimpleObjectDataModification{Id = 1886677097, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsHitPointsModified => _modifications.ContainsKey(1886677097);
        public int StatsIgnoreCooldownRaw
        {
            get => _modifications.GetModification(1684236649).ValueAsInt;
            set => _modifications[1684236649] = new SimpleObjectDataModification{Id = 1684236649, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsIgnoreCooldownModified => _modifications.ContainsKey(1684236649);
        public bool StatsIgnoreCooldown
        {
            get => StatsIgnoreCooldownRaw.ToBool(this);
            set => StatsIgnoreCooldownRaw = value.ToRaw(null, null);
        }

        public int StatsLevel
        {
            get => _modifications.GetModification(1986358377).ValueAsInt;
            set => _modifications[1986358377] = new SimpleObjectDataModification{Id = 1986358377, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsLevelModified => _modifications.ContainsKey(1986358377);
        public int StatsLumberCost
        {
            get => _modifications.GetModification(1836412009).ValueAsInt;
            set => _modifications[1836412009] = new SimpleObjectDataModification{Id = 1836412009, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsLumberCostModified => _modifications.ContainsKey(1836412009);
        public int StatsValidTargetForTransformationRaw
        {
            get => _modifications.GetModification(1919905129).ValueAsInt;
            set => _modifications[1919905129] = new SimpleObjectDataModification{Id = 1919905129, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsValidTargetForTransformationModified => _modifications.ContainsKey(1919905129);
        public bool StatsValidTargetForTransformation
        {
            get => StatsValidTargetForTransformationRaw.ToBool(this);
            set => StatsValidTargetForTransformationRaw = value.ToRaw(null, null);
        }

        public int StatsLevelUnclassified
        {
            get => _modifications.GetModification(1870031977).ValueAsInt;
            set => _modifications[1870031977] = new SimpleObjectDataModification{Id = 1870031977, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsLevelUnclassifiedModified => _modifications.ContainsKey(1870031977);
        public int StatsPerishableRaw
        {
            get => _modifications.GetModification(1919250537).ValueAsInt;
            set => _modifications[1919250537] = new SimpleObjectDataModification{Id = 1919250537, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsPerishableModified => _modifications.ContainsKey(1919250537);
        public bool StatsPerishable
        {
            get => StatsPerishableRaw.ToBool(this);
            set => StatsPerishableRaw = value.ToRaw(null, null);
        }

        public int StatsIncludeAsRandomChoiceRaw
        {
            get => _modifications.GetModification(1852993641).ValueAsInt;
            set => _modifications[1852993641] = new SimpleObjectDataModification{Id = 1852993641, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsIncludeAsRandomChoiceModified => _modifications.ContainsKey(1852993641);
        public bool StatsIncludeAsRandomChoice
        {
            get => StatsIncludeAsRandomChoiceRaw.ToBool(this);
            set => StatsIncludeAsRandomChoiceRaw = value.ToRaw(null, null);
        }

        public int StatsUseAutomaticallyWhenAcquiredRaw
        {
            get => _modifications.GetModification(2003791977).ValueAsInt;
            set => _modifications[2003791977] = new SimpleObjectDataModification{Id = 2003791977, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsUseAutomaticallyWhenAcquiredModified => _modifications.ContainsKey(2003791977);
        public bool StatsUseAutomaticallyWhenAcquired
        {
            get => StatsUseAutomaticallyWhenAcquiredRaw.ToBool(this);
            set => StatsUseAutomaticallyWhenAcquiredRaw = value.ToRaw(null, null);
        }

        public int StatsPriority
        {
            get => _modifications.GetModification(1769107561).ValueAsInt;
            set => _modifications[1769107561] = new SimpleObjectDataModification{Id = 1769107561, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsPriorityModified => _modifications.ContainsKey(1769107561);
        public float ArtScalingValue
        {
            get => _modifications.GetModification(1633907561).ValueAsFloat;
            set => _modifications[1633907561] = new SimpleObjectDataModification{Id = 1633907561, Type = ObjectDataType.Real, Value = value};
        }

        public bool IsArtScalingValueModified => _modifications.ContainsKey(1633907561);
        public float ArtSelectionSizeEditor
        {
            get => _modifications.GetModification(1668510569).ValueAsFloat;
            set => _modifications[1668510569] = new SimpleObjectDataModification{Id = 1668510569, Type = ObjectDataType.Real, Value = value};
        }

        public bool IsArtSelectionSizeEditorModified => _modifications.ContainsKey(1668510569);
        public int StatsCanBeSoldByMerchantsRaw
        {
            get => _modifications.GetModification(1818588009).ValueAsInt;
            set => _modifications[1818588009] = new SimpleObjectDataModification{Id = 1818588009, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsCanBeSoldByMerchantsModified => _modifications.ContainsKey(1818588009);
        public bool StatsCanBeSoldByMerchants
        {
            get => StatsCanBeSoldByMerchantsRaw.ToBool(this);
            set => StatsCanBeSoldByMerchantsRaw = value.ToRaw(null, null);
        }

        public int StatsCanBeSoldToMerchantsRaw
        {
            get => _modifications.GetModification(2002874473).ValueAsInt;
            set => _modifications[2002874473] = new SimpleObjectDataModification{Id = 2002874473, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsCanBeSoldToMerchantsModified => _modifications.ContainsKey(2002874473);
        public bool StatsCanBeSoldToMerchants
        {
            get => StatsCanBeSoldToMerchantsRaw.ToBool(this);
            set => StatsCanBeSoldToMerchantsRaw = value.ToRaw(null, null);
        }

        public int StatsStockMaximum
        {
            get => _modifications.GetModification(1869902697).ValueAsInt;
            set => _modifications[1869902697] = new SimpleObjectDataModification{Id = 1869902697, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsStockMaximumModified => _modifications.ContainsKey(1869902697);
        public int StatsStockReplenishInterval
        {
            get => _modifications.GetModification(1920234345).ValueAsInt;
            set => _modifications[1920234345] = new SimpleObjectDataModification{Id = 1920234345, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsStockReplenishIntervalModified => _modifications.ContainsKey(1920234345);
        public int StatsStockStartDelay
        {
            get => _modifications.GetModification(1953723241).ValueAsInt;
            set => _modifications[1953723241] = new SimpleObjectDataModification{Id = 1953723241, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsStockStartDelayModified => _modifications.ContainsKey(1953723241);
        public int StatsStockInitialAfterStartDelay
        {
            get => _modifications.GetModification(1953067881).ValueAsInt;
            set => _modifications[1953067881] = new SimpleObjectDataModification{Id = 1953067881, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsStockInitialAfterStartDelayModified => _modifications.ContainsKey(1953067881);
        public int StatsActivelyUsedRaw
        {
            get => _modifications.GetModification(1634956649).ValueAsInt;
            set => _modifications[1634956649] = new SimpleObjectDataModification{Id = 1634956649, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsActivelyUsedModified => _modifications.ContainsKey(1634956649);
        public bool StatsActivelyUsed
        {
            get => StatsActivelyUsedRaw.ToBool(this);
            set => StatsActivelyUsedRaw = value.ToRaw(null, null);
        }

        public int StatsNumberOfCharges
        {
            get => _modifications.GetModification(1702065513).ValueAsInt;
            set => _modifications[1702065513] = new SimpleObjectDataModification{Id = 1702065513, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsNumberOfChargesModified => _modifications.ContainsKey(1702065513);
        public int StatsMaxStacks
        {
            get => _modifications.GetModification(1635021673).ValueAsInt;
            set => _modifications[1635021673] = new SimpleObjectDataModification{Id = 1635021673, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsMaxStacksModified => _modifications.ContainsKey(1635021673);
        public string ArtInterfaceIconRaw
        {
            get => _modifications.GetModification(1868786025).ValueAsString;
            set => _modifications[1868786025] = new SimpleObjectDataModification{Id = 1868786025, Type = ObjectDataType.String, Value = value};
        }

        public bool IsArtInterfaceIconModified => _modifications.ContainsKey(1868786025);
        public string ArtInterfaceIcon
        {
            get => ArtInterfaceIconRaw.ToString(this);
            set => ArtInterfaceIconRaw = value.ToRaw(null, null);
        }

        public int ArtButtonPositionX
        {
            get => _modifications.GetModification(2020631157).ValueAsInt;
            set => _modifications[2020631157] = new SimpleObjectDataModification{Id = 2020631157, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtButtonPositionXModified => _modifications.ContainsKey(2020631157);
        public int ArtButtonPositionY
        {
            get => _modifications.GetModification(2037408373).ValueAsInt;
            set => _modifications[2037408373] = new SimpleObjectDataModification{Id = 2037408373, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtButtonPositionYModified => _modifications.ContainsKey(2037408373);
        public string TextDescription
        {
            get => _modifications.GetModification(1936024681).ValueAsString;
            set => _modifications[1936024681] = new SimpleObjectDataModification{Id = 1936024681, Type = ObjectDataType.String, Value = value};
        }

        public bool IsTextDescriptionModified => _modifications.ContainsKey(1936024681);
        public string TextHotkeyRaw
        {
            get => _modifications.GetModification(1953458293).ValueAsString;
            set => _modifications[1953458293] = new SimpleObjectDataModification{Id = 1953458293, Type = ObjectDataType.String, Value = value};
        }

        public bool IsTextHotkeyModified => _modifications.ContainsKey(1953458293);
        public char TextHotkey
        {
            get => TextHotkeyRaw.ToChar(this);
            set => TextHotkeyRaw = value.ToRaw(null, null);
        }

        public string TextName
        {
            get => _modifications.GetModification(1835101813).ValueAsString;
            set => _modifications[1835101813] = new SimpleObjectDataModification{Id = 1835101813, Type = ObjectDataType.String, Value = value};
        }

        public bool IsTextNameModified => _modifications.ContainsKey(1835101813);
        public string TechtreeRequirementsRaw
        {
            get => _modifications.GetModification(1902473845).ValueAsString;
            set => _modifications[1902473845] = new SimpleObjectDataModification{Id = 1902473845, Type = ObjectDataType.String, Value = value};
        }

        public bool IsTechtreeRequirementsModified => _modifications.ContainsKey(1902473845);
        public IEnumerable<Tech> TechtreeRequirements
        {
            get => TechtreeRequirementsRaw.ToIEnumerableTech(this);
            set => TechtreeRequirementsRaw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsLevelsRaw
        {
            get => _modifications.GetModification(1634824821).ValueAsString;
            set => _modifications[1634824821] = new SimpleObjectDataModification{Id = 1634824821, Type = ObjectDataType.String, Value = value};
        }

        public bool IsTechtreeRequirementsLevelsModified => _modifications.ContainsKey(1634824821);
        public IEnumerable<int> TechtreeRequirementsLevels
        {
            get => TechtreeRequirementsLevelsRaw.ToIEnumerableInt(this);
            set => TechtreeRequirementsLevelsRaw = value.ToRaw(null, null);
        }

        public string TextTooltipBasic
        {
            get => _modifications.GetModification(1885959285).ValueAsString;
            set => _modifications[1885959285] = new SimpleObjectDataModification{Id = 1885959285, Type = ObjectDataType.String, Value = value};
        }

        public bool IsTextTooltipBasicModified => _modifications.ContainsKey(1885959285);
        public string TextTooltipExtended
        {
            get => _modifications.GetModification(1651864693).ValueAsString;
            set => _modifications[1651864693] = new SimpleObjectDataModification{Id = 1651864693, Type = ObjectDataType.String, Value = value};
        }

        public bool IsTextTooltipExtendedModified => _modifications.ContainsKey(1651864693);
        public static explicit operator SimpleObjectModification(Item item) => new SimpleObjectModification{OldId = item.OldId, NewId = item.NewId, Modifications = item.Modifications.ToList()};
        internal override bool TryGetSimpleModifications([NotNullWhen(true)] out SimpleObjectDataModifications? modifications)
        {
            modifications = _modifications;
            return true;
        }

        public void AddModifications(List<SimpleObjectDataModification> modifications)
        {
            foreach (var modification in modifications)
                _modifications[modification.Id] = modification;
        }
    }
}