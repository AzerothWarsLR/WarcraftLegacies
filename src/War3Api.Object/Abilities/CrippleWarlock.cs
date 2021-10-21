using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CrippleWarlock : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedReduction;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedReduction;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReduction;
        public CrippleWarlock(): base(1769104211)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
        }

        public CrippleWarlock(int newId): base(1769104211, newId)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
        }

        public CrippleWarlock(string newRawcode): base(1769104211, newRawcode)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
        }

        public CrippleWarlock(ObjectDatabase db): base(1769104211, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
        }

        public CrippleWarlock(int newId, ObjectDatabase db): base(1769104211, newId, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
        }

        public CrippleWarlock(string newRawcode, ObjectDatabase db): base(1769104211, newRawcode, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
        }

        public ObjectProperty<float> DataMovementSpeedReduction => _dataMovementSpeedReduction.Value;
        public ObjectProperty<float> DataAttackSpeedReduction => _dataAttackSpeedReduction.Value;
        public ObjectProperty<float> DataDamageReduction => _dataDamageReduction.Value;
        private float GetDataMovementSpeedReduction(int level)
        {
            return _modifications[828994115, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedReduction(int level, float value)
        {
            _modifications[828994115, level] = new LevelObjectDataModification{Id = 828994115, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataAttackSpeedReduction(int level)
        {
            return _modifications[845771331, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedReduction(int level, float value)
        {
            _modifications[845771331, level] = new LevelObjectDataModification{Id = 845771331, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamageReduction(int level)
        {
            return _modifications[862548547, level].ValueAsFloat;
        }

        private void SetDataDamageReduction(int level, float value)
        {
            _modifications[862548547, level] = new LevelObjectDataModification{Id = 862548547, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}