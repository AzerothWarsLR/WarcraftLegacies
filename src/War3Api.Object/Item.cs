using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public sealed class Item : BaseObject
    {
        private readonly SimpleObjectDataModifications _modifications = new SimpleObjectDataModifications();
        public Item(ItemType baseItemType): this((int)baseItemType)
        {
        }

        public Item(ItemType baseItemType, int newId): this((int)baseItemType, newId)
        {
        }

        public Item(ItemType baseItemType, string newRawcode): this((int)baseItemType, newRawcode)
        {
        }

        public Item(ItemType baseItemType, ObjectDatabase db): this((int)baseItemType, db)
        {
        }

        public Item(ItemType baseItemType, int newId, ObjectDatabase db): this((int)baseItemType, newId, db)
        {
        }

        public Item(ItemType baseItemType, string newRawcode, ObjectDatabase db): this((int)baseItemType, newRawcode, db)
        {
        }

        private Item(int oldId): base(oldId)
        {
        }

        private Item(int oldId, int newId): base(oldId, newId)
        {
        }

        private Item(int oldId, string newRawcode): base(oldId, newRawcode)
        {
        }

        private Item(int oldId, ObjectDatabase db): base(oldId, db)
        {
        }

        private Item(int oldId, int newId, ObjectDatabase db): base(oldId, newId, db)
        {
        }

        private Item(int oldId, string newRawcode, ObjectDatabase db): base(oldId, newRawcode, db)
        {
        }

        public SimpleObjectDataModifications Modifications => _modifications;
        public string AbilitiesAbilitiesRaw
        {
            get => _modifications[1768055145].ValueAsString;
            set => _modifications[1768055145] = new SimpleObjectDataModification{Id = 1768055145, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Ability> AbilitiesAbilities
        {
            get => AbilitiesAbilitiesRaw.ToIEnumerableAbility(this);
            set => AbilitiesAbilitiesRaw = value.ToRaw(null, 4);
        }

        public string CombatArmorTypeRaw
        {
            get => _modifications[1836212585].ValueAsString;
            set => _modifications[1836212585] = new SimpleObjectDataModification{Id = 1836212585, Type = ObjectDataType.String, Value = value};
        }

        public ArmorType CombatArmorType
        {
            get => CombatArmorTypeRaw.ToArmorType(this);
            set => CombatArmorTypeRaw = value.ToRaw(null, null);
        }

        public string StatsClassificationRaw
        {
            get => _modifications[1634493289].ValueAsString;
            set => _modifications[1634493289] = new SimpleObjectDataModification{Id = 1634493289, Type = ObjectDataType.String, Value = value};
        }

        public ItemClass StatsClassification
        {
            get => StatsClassificationRaw.ToItemClass(this);
            set => StatsClassificationRaw = value.ToRaw(null, null);
        }

        public int ArtTintingColor3Blue
        {
            get => _modifications[1651270505].ValueAsInt;
            set => _modifications[1651270505] = new SimpleObjectDataModification{Id = 1651270505, Type = ObjectDataType.Int, Value = value};
        }

        public int ArtTintingColor2Green
        {
            get => _modifications[1735156585].ValueAsInt;
            set => _modifications[1735156585] = new SimpleObjectDataModification{Id = 1735156585, Type = ObjectDataType.Int, Value = value};
        }

        public int ArtTintingColor1Red
        {
            get => _modifications[1919705961].ValueAsInt;
            set => _modifications[1919705961] = new SimpleObjectDataModification{Id = 1919705961, Type = ObjectDataType.Int, Value = value};
        }

        public string StatsCooldownGroupRaw
        {
            get => _modifications[1684628329].ValueAsString;
            set => _modifications[1684628329] = new SimpleObjectDataModification{Id = 1684628329, Type = ObjectDataType.String, Value = value};
        }

        public Ability StatsCooldownGroup
        {
            get => StatsCooldownGroupRaw.ToAbility(this);
            set => StatsCooldownGroupRaw = value.ToRaw(null, null);
        }

        public bool StatsDroppedWhenCarrierDies
        {
            get => _modifications[1886545001].ValueAsBool;
            set => _modifications[1886545001] = new SimpleObjectDataModification{Id = 1886545001, Type = ObjectDataType.Bool, Value = value};
        }

        public bool StatsCanBeDropped
        {
            get => _modifications[1869767785].ValueAsBool;
            set => _modifications[1869767785] = new SimpleObjectDataModification{Id = 1869767785, Type = ObjectDataType.Bool, Value = value};
        }

        public string ArtModelUsedRaw
        {
            get => _modifications[1818846825].ValueAsString;
            set => _modifications[1818846825] = new SimpleObjectDataModification{Id = 1818846825, Type = ObjectDataType.String, Value = value};
        }

        public string ArtModelUsed
        {
            get => ArtModelUsedRaw.ToString(this);
            set => ArtModelUsedRaw = value.ToRaw(null, null);
        }

        public int StatsGoldCost
        {
            get => _modifications[1819240297].ValueAsInt;
            set => _modifications[1819240297] = new SimpleObjectDataModification{Id = 1819240297, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsHitPoints
        {
            get => _modifications[1886677097].ValueAsInt;
            set => _modifications[1886677097] = new SimpleObjectDataModification{Id = 1886677097, Type = ObjectDataType.Int, Value = value};
        }

        public bool StatsIgnoreCooldown
        {
            get => _modifications[1684236649].ValueAsBool;
            set => _modifications[1684236649] = new SimpleObjectDataModification{Id = 1684236649, Type = ObjectDataType.Bool, Value = value};
        }

        public int StatsLevel
        {
            get => _modifications[1986358377].ValueAsInt;
            set => _modifications[1986358377] = new SimpleObjectDataModification{Id = 1986358377, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsLumberCost
        {
            get => _modifications[1836412009].ValueAsInt;
            set => _modifications[1836412009] = new SimpleObjectDataModification{Id = 1836412009, Type = ObjectDataType.Int, Value = value};
        }

        public bool StatsValidTargetForTransformation
        {
            get => _modifications[1919905129].ValueAsBool;
            set => _modifications[1919905129] = new SimpleObjectDataModification{Id = 1919905129, Type = ObjectDataType.Bool, Value = value};
        }

        public int StatsLevelUnclassified
        {
            get => _modifications[1870031977].ValueAsInt;
            set => _modifications[1870031977] = new SimpleObjectDataModification{Id = 1870031977, Type = ObjectDataType.Int, Value = value};
        }

        public bool StatsPerishable
        {
            get => _modifications[1919250537].ValueAsBool;
            set => _modifications[1919250537] = new SimpleObjectDataModification{Id = 1919250537, Type = ObjectDataType.Bool, Value = value};
        }

        public bool StatsIncludeAsRandomChoice
        {
            get => _modifications[1852993641].ValueAsBool;
            set => _modifications[1852993641] = new SimpleObjectDataModification{Id = 1852993641, Type = ObjectDataType.Bool, Value = value};
        }

        public bool StatsUseAutomaticallyWhenAcquired
        {
            get => _modifications[2003791977].ValueAsBool;
            set => _modifications[2003791977] = new SimpleObjectDataModification{Id = 2003791977, Type = ObjectDataType.Bool, Value = value};
        }

        public int StatsPriority
        {
            get => _modifications[1769107561].ValueAsInt;
            set => _modifications[1769107561] = new SimpleObjectDataModification{Id = 1769107561, Type = ObjectDataType.Int, Value = value};
        }

        public float ArtScalingValue
        {
            get => _modifications[1633907561].ValueAsFloat;
            set => _modifications[1633907561] = new SimpleObjectDataModification{Id = 1633907561, Type = ObjectDataType.Real, Value = value};
        }

        public float ArtSelectionSizeEditor
        {
            get => _modifications[1668510569].ValueAsFloat;
            set => _modifications[1668510569] = new SimpleObjectDataModification{Id = 1668510569, Type = ObjectDataType.Real, Value = value};
        }

        public bool StatsCanBeSoldByMerchants
        {
            get => _modifications[1818588009].ValueAsBool;
            set => _modifications[1818588009] = new SimpleObjectDataModification{Id = 1818588009, Type = ObjectDataType.Bool, Value = value};
        }

        public bool StatsCanBeSoldToMerchants
        {
            get => _modifications[2002874473].ValueAsBool;
            set => _modifications[2002874473] = new SimpleObjectDataModification{Id = 2002874473, Type = ObjectDataType.Bool, Value = value};
        }

        public int StatsStockMaximum
        {
            get => _modifications[1869902697].ValueAsInt;
            set => _modifications[1869902697] = new SimpleObjectDataModification{Id = 1869902697, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsStockReplenishInterval
        {
            get => _modifications[1920234345].ValueAsInt;
            set => _modifications[1920234345] = new SimpleObjectDataModification{Id = 1920234345, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsStockStartDelay
        {
            get => _modifications[1953723241].ValueAsInt;
            set => _modifications[1953723241] = new SimpleObjectDataModification{Id = 1953723241, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsStockInitialAfterStartDelay
        {
            get => _modifications[1953067881].ValueAsInt;
            set => _modifications[1953067881] = new SimpleObjectDataModification{Id = 1953067881, Type = ObjectDataType.Int, Value = value};
        }

        public bool StatsActivelyUsed
        {
            get => _modifications[1634956649].ValueAsBool;
            set => _modifications[1634956649] = new SimpleObjectDataModification{Id = 1634956649, Type = ObjectDataType.Bool, Value = value};
        }

        public int StatsNumberOfCharges
        {
            get => _modifications[1702065513].ValueAsInt;
            set => _modifications[1702065513] = new SimpleObjectDataModification{Id = 1702065513, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsMaxStacks
        {
            get => _modifications[1635021673].ValueAsInt;
            set => _modifications[1635021673] = new SimpleObjectDataModification{Id = 1635021673, Type = ObjectDataType.Int, Value = value};
        }

        public string ArtInterfaceIconRaw
        {
            get => _modifications[1868786025].ValueAsString;
            set => _modifications[1868786025] = new SimpleObjectDataModification{Id = 1868786025, Type = ObjectDataType.String, Value = value};
        }

        public string ArtInterfaceIcon
        {
            get => ArtInterfaceIconRaw.ToString(this);
            set => ArtInterfaceIconRaw = value.ToRaw(null, null);
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

        public string TextDescription
        {
            get => _modifications[1936024681].ValueAsString;
            set => _modifications[1936024681] = new SimpleObjectDataModification{Id = 1936024681, Type = ObjectDataType.String, Value = value};
        }

        public char TextHotkey
        {
            get => _modifications[1953458293].ValueAsChar;
            set => _modifications[1953458293] = new SimpleObjectDataModification{Id = 1953458293, Type = ObjectDataType.Char, Value = value};
        }

        public string TextName
        {
            get => _modifications[1835101813].ValueAsString;
            set => _modifications[1835101813] = new SimpleObjectDataModification{Id = 1835101813, Type = ObjectDataType.String, Value = value};
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

        public string TextTooltipBasic
        {
            get => _modifications[1885959285].ValueAsString;
            set => _modifications[1885959285] = new SimpleObjectDataModification{Id = 1885959285, Type = ObjectDataType.String, Value = value};
        }

        public string TextTooltipExtended
        {
            get => _modifications[1651864693].ValueAsString;
            set => _modifications[1651864693] = new SimpleObjectDataModification{Id = 1651864693, Type = ObjectDataType.String, Value = value};
        }

        public static explicit operator SimpleObjectModification(Item item) => new SimpleObjectModification{OldId = item.OldId, NewId = item.NewId, Modifications = item.Modifications.ToList()};
    }
}