using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TinkererEngineeringUpgrade : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMoveSpeedBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMoveSpeedBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<string>> _dataAbilityUpgrade1Raw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAbilityUpgrade1Modified;
        private readonly Lazy<ObjectProperty<IEnumerable<Ability>>> _dataAbilityUpgrade1;
        private readonly Lazy<ObjectProperty<string>> _dataAbilityUpgrade2Raw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAbilityUpgrade2Modified;
        private readonly Lazy<ObjectProperty<IEnumerable<Ability>>> _dataAbilityUpgrade2;
        private readonly Lazy<ObjectProperty<string>> _dataAbilityUpgrade3Raw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAbilityUpgrade3Modified;
        private readonly Lazy<ObjectProperty<IEnumerable<Ability>>> _dataAbilityUpgrade3;
        private readonly Lazy<ObjectProperty<string>> _dataAbilityUpgrade4Raw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAbilityUpgrade4Modified;
        private readonly Lazy<ObjectProperty<IEnumerable<Ability>>> _dataAbilityUpgrade4;
        public TinkererEngineeringUpgrade(): base(1734692417)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _isDataAbilityUpgrade1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade1Modified));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _isDataAbilityUpgrade2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade2Modified));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _isDataAbilityUpgrade3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade3Modified));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _isDataAbilityUpgrade4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade4Modified));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public TinkererEngineeringUpgrade(int newId): base(1734692417, newId)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _isDataAbilityUpgrade1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade1Modified));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _isDataAbilityUpgrade2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade2Modified));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _isDataAbilityUpgrade3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade3Modified));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _isDataAbilityUpgrade4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade4Modified));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public TinkererEngineeringUpgrade(string newRawcode): base(1734692417, newRawcode)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _isDataAbilityUpgrade1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade1Modified));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _isDataAbilityUpgrade2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade2Modified));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _isDataAbilityUpgrade3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade3Modified));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _isDataAbilityUpgrade4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade4Modified));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public TinkererEngineeringUpgrade(ObjectDatabaseBase db): base(1734692417, db)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _isDataAbilityUpgrade1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade1Modified));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _isDataAbilityUpgrade2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade2Modified));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _isDataAbilityUpgrade3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade3Modified));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _isDataAbilityUpgrade4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade4Modified));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public TinkererEngineeringUpgrade(int newId, ObjectDatabaseBase db): base(1734692417, newId, db)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _isDataAbilityUpgrade1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade1Modified));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _isDataAbilityUpgrade2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade2Modified));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _isDataAbilityUpgrade3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade3Modified));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _isDataAbilityUpgrade4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade4Modified));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public TinkererEngineeringUpgrade(string newRawcode, ObjectDatabaseBase db): base(1734692417, newRawcode, db)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _isDataAbilityUpgrade1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade1Modified));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _isDataAbilityUpgrade2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade2Modified));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _isDataAbilityUpgrade3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade3Modified));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _isDataAbilityUpgrade4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityUpgrade4Modified));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public ObjectProperty<float> DataMoveSpeedBonus => _dataMoveSpeedBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataMoveSpeedBonusModified => _isDataMoveSpeedBonusModified.Value;
        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<string> DataAbilityUpgrade1Raw => _dataAbilityUpgrade1Raw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAbilityUpgrade1Modified => _isDataAbilityUpgrade1Modified.Value;
        public ObjectProperty<IEnumerable<Ability>> DataAbilityUpgrade1 => _dataAbilityUpgrade1.Value;
        public ObjectProperty<string> DataAbilityUpgrade2Raw => _dataAbilityUpgrade2Raw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAbilityUpgrade2Modified => _isDataAbilityUpgrade2Modified.Value;
        public ObjectProperty<IEnumerable<Ability>> DataAbilityUpgrade2 => _dataAbilityUpgrade2.Value;
        public ObjectProperty<string> DataAbilityUpgrade3Raw => _dataAbilityUpgrade3Raw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAbilityUpgrade3Modified => _isDataAbilityUpgrade3Modified.Value;
        public ObjectProperty<IEnumerable<Ability>> DataAbilityUpgrade3 => _dataAbilityUpgrade3.Value;
        public ObjectProperty<string> DataAbilityUpgrade4Raw => _dataAbilityUpgrade4Raw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAbilityUpgrade4Modified => _isDataAbilityUpgrade4Modified.Value;
        public ObjectProperty<IEnumerable<Ability>> DataAbilityUpgrade4 => _dataAbilityUpgrade4.Value;
        private float GetDataMoveSpeedBonus(int level)
        {
            return _modifications.GetModification(828859726, level).ValueAsFloat;
        }

        private void SetDataMoveSpeedBonus(int level, float value)
        {
            _modifications[828859726, level] = new LevelObjectDataModification{Id = 828859726, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMoveSpeedBonusModified(int level)
        {
            return _modifications.ContainsKey(828859726, level);
        }

        private float GetDataDamageBonus(int level)
        {
            return _modifications.GetModification(845636942, level).ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[845636942, level] = new LevelObjectDataModification{Id = 845636942, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageBonusModified(int level)
        {
            return _modifications.ContainsKey(845636942, level);
        }

        private string GetDataAbilityUpgrade1Raw(int level)
        {
            return _modifications.GetModification(862414158, level).ValueAsString;
        }

        private void SetDataAbilityUpgrade1Raw(int level, string value)
        {
            _modifications[862414158, level] = new LevelObjectDataModification{Id = 862414158, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAbilityUpgrade1Modified(int level)
        {
            return _modifications.ContainsKey(862414158, level);
        }

        private IEnumerable<Ability> GetDataAbilityUpgrade1(int level)
        {
            return GetDataAbilityUpgrade1Raw(level).ToIEnumerableAbility(this);
        }

        private void SetDataAbilityUpgrade1(int level, IEnumerable<Ability> value)
        {
            SetDataAbilityUpgrade1Raw(level, value.ToRaw(null, 2));
        }

        private string GetDataAbilityUpgrade2Raw(int level)
        {
            return _modifications.GetModification(879191374, level).ValueAsString;
        }

        private void SetDataAbilityUpgrade2Raw(int level, string value)
        {
            _modifications[879191374, level] = new LevelObjectDataModification{Id = 879191374, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataAbilityUpgrade2Modified(int level)
        {
            return _modifications.ContainsKey(879191374, level);
        }

        private IEnumerable<Ability> GetDataAbilityUpgrade2(int level)
        {
            return GetDataAbilityUpgrade2Raw(level).ToIEnumerableAbility(this);
        }

        private void SetDataAbilityUpgrade2(int level, IEnumerable<Ability> value)
        {
            SetDataAbilityUpgrade2Raw(level, value.ToRaw(null, 2));
        }

        private string GetDataAbilityUpgrade3Raw(int level)
        {
            return _modifications.GetModification(895968590, level).ValueAsString;
        }

        private void SetDataAbilityUpgrade3Raw(int level, string value)
        {
            _modifications[895968590, level] = new LevelObjectDataModification{Id = 895968590, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataAbilityUpgrade3Modified(int level)
        {
            return _modifications.ContainsKey(895968590, level);
        }

        private IEnumerable<Ability> GetDataAbilityUpgrade3(int level)
        {
            return GetDataAbilityUpgrade3Raw(level).ToIEnumerableAbility(this);
        }

        private void SetDataAbilityUpgrade3(int level, IEnumerable<Ability> value)
        {
            SetDataAbilityUpgrade3Raw(level, value.ToRaw(null, 2));
        }

        private string GetDataAbilityUpgrade4Raw(int level)
        {
            return _modifications.GetModification(912745806, level).ValueAsString;
        }

        private void SetDataAbilityUpgrade4Raw(int level, string value)
        {
            _modifications[912745806, level] = new LevelObjectDataModification{Id = 912745806, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataAbilityUpgrade4Modified(int level)
        {
            return _modifications.ContainsKey(912745806, level);
        }

        private IEnumerable<Ability> GetDataAbilityUpgrade4(int level)
        {
            return GetDataAbilityUpgrade4Raw(level).ToIEnumerableAbility(this);
        }

        private void SetDataAbilityUpgrade4(int level, IEnumerable<Ability> value)
        {
            SetDataAbilityUpgrade4Raw(level, value.ToRaw(null, 2));
        }
    }
}