using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class UnholyFrenzyWarlock : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedBonus;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        public UnholyFrenzyWarlock(): base(1718121811)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public UnholyFrenzyWarlock(int newId): base(1718121811, newId)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public UnholyFrenzyWarlock(string newRawcode): base(1718121811, newRawcode)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public UnholyFrenzyWarlock(ObjectDatabase db): base(1718121811, db)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public UnholyFrenzyWarlock(int newId, ObjectDatabase db): base(1718121811, newId, db)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public UnholyFrenzyWarlock(string newRawcode, ObjectDatabase db): base(1718121811, newRawcode, db)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public ObjectProperty<float> DataAttackSpeedBonus => _dataAttackSpeedBonus.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        private float GetDataAttackSpeedBonus(int level)
        {
            return _modifications[828794965, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedBonus(int level, float value)
        {
            _modifications[828794965, level] = new LevelObjectDataModification{Id = 828794965, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications[845572181, level].ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[845572181, level] = new LevelObjectDataModification{Id = 845572181, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}