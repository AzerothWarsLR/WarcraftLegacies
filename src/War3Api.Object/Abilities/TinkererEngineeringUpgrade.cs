using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TinkererEngineeringUpgrade : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMoveSpeedBonus;
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ObjectProperty<string>> _dataAbilityUpgrade1Raw;
        private readonly Lazy<ObjectProperty<IEnumerable<Ability>>> _dataAbilityUpgrade1;
        private readonly Lazy<ObjectProperty<string>> _dataAbilityUpgrade2Raw;
        private readonly Lazy<ObjectProperty<IEnumerable<Ability>>> _dataAbilityUpgrade2;
        private readonly Lazy<ObjectProperty<string>> _dataAbilityUpgrade3Raw;
        private readonly Lazy<ObjectProperty<IEnumerable<Ability>>> _dataAbilityUpgrade3;
        private readonly Lazy<ObjectProperty<string>> _dataAbilityUpgrade4Raw;
        private readonly Lazy<ObjectProperty<IEnumerable<Ability>>> _dataAbilityUpgrade4;
        public TinkererEngineeringUpgrade(): base(1734692417)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public TinkererEngineeringUpgrade(int newId): base(1734692417, newId)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public TinkererEngineeringUpgrade(string newRawcode): base(1734692417, newRawcode)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public TinkererEngineeringUpgrade(ObjectDatabase db): base(1734692417, db)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public TinkererEngineeringUpgrade(int newId, ObjectDatabase db): base(1734692417, newId, db)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public TinkererEngineeringUpgrade(string newRawcode, ObjectDatabase db): base(1734692417, newRawcode, db)
        {
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataAbilityUpgrade1Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade1Raw, SetDataAbilityUpgrade1Raw));
            _dataAbilityUpgrade1 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade1, SetDataAbilityUpgrade1));
            _dataAbilityUpgrade2Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade2Raw, SetDataAbilityUpgrade2Raw));
            _dataAbilityUpgrade2 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade2, SetDataAbilityUpgrade2));
            _dataAbilityUpgrade3Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade3Raw, SetDataAbilityUpgrade3Raw));
            _dataAbilityUpgrade3 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade3, SetDataAbilityUpgrade3));
            _dataAbilityUpgrade4Raw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityUpgrade4Raw, SetDataAbilityUpgrade4Raw));
            _dataAbilityUpgrade4 = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataAbilityUpgrade4, SetDataAbilityUpgrade4));
        }

        public ObjectProperty<float> DataMoveSpeedBonus => _dataMoveSpeedBonus.Value;
        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ObjectProperty<string> DataAbilityUpgrade1Raw => _dataAbilityUpgrade1Raw.Value;
        public ObjectProperty<IEnumerable<Ability>> DataAbilityUpgrade1 => _dataAbilityUpgrade1.Value;
        public ObjectProperty<string> DataAbilityUpgrade2Raw => _dataAbilityUpgrade2Raw.Value;
        public ObjectProperty<IEnumerable<Ability>> DataAbilityUpgrade2 => _dataAbilityUpgrade2.Value;
        public ObjectProperty<string> DataAbilityUpgrade3Raw => _dataAbilityUpgrade3Raw.Value;
        public ObjectProperty<IEnumerable<Ability>> DataAbilityUpgrade3 => _dataAbilityUpgrade3.Value;
        public ObjectProperty<string> DataAbilityUpgrade4Raw => _dataAbilityUpgrade4Raw.Value;
        public ObjectProperty<IEnumerable<Ability>> DataAbilityUpgrade4 => _dataAbilityUpgrade4.Value;
        private float GetDataMoveSpeedBonus(int level)
        {
            return _modifications[828859726, level].ValueAsFloat;
        }

        private void SetDataMoveSpeedBonus(int level, float value)
        {
            _modifications[828859726, level] = new LevelObjectDataModification{Id = 828859726, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageBonus(int level)
        {
            return _modifications[845636942, level].ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[845636942, level] = new LevelObjectDataModification{Id = 845636942, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private string GetDataAbilityUpgrade1Raw(int level)
        {
            return _modifications[862414158, level].ValueAsString;
        }

        private void SetDataAbilityUpgrade1Raw(int level, string value)
        {
            _modifications[862414158, level] = new LevelObjectDataModification{Id = 862414158, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 3};
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
            return _modifications[879191374, level].ValueAsString;
        }

        private void SetDataAbilityUpgrade2Raw(int level, string value)
        {
            _modifications[879191374, level] = new LevelObjectDataModification{Id = 879191374, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 4};
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
            return _modifications[895968590, level].ValueAsString;
        }

        private void SetDataAbilityUpgrade3Raw(int level, string value)
        {
            _modifications[895968590, level] = new LevelObjectDataModification{Id = 895968590, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 5};
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
            return _modifications[912745806, level].ValueAsString;
        }

        private void SetDataAbilityUpgrade4Raw(int level, string value)
        {
            _modifications[912745806, level] = new LevelObjectDataModification{Id = 912745806, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 6};
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