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
    public sealed class CrippleCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedReductionModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedReductionModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageReductionModified;
        public CrippleCreep(): base(1919107905)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public CrippleCreep(int newId): base(1919107905, newId)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public CrippleCreep(string newRawcode): base(1919107905, newRawcode)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public CrippleCreep(ObjectDatabaseBase db): base(1919107905, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public CrippleCreep(int newId, ObjectDatabaseBase db): base(1919107905, newId, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public CrippleCreep(string newRawcode, ObjectDatabaseBase db): base(1919107905, newRawcode, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public ObjectProperty<float> DataMovementSpeedReduction => _dataMovementSpeedReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedReductionModified => _isDataMovementSpeedReductionModified.Value;
        public ObjectProperty<float> DataAttackSpeedReduction => _dataAttackSpeedReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedReductionModified => _isDataAttackSpeedReductionModified.Value;
        public ObjectProperty<float> DataDamageReduction => _dataDamageReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageReductionModified => _isDataDamageReductionModified.Value;
        private float GetDataMovementSpeedReduction(int level)
        {
            return _modifications.GetModification(828994115, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedReduction(int level, float value)
        {
            _modifications[828994115, level] = new LevelObjectDataModification{Id = 828994115, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMovementSpeedReductionModified(int level)
        {
            return _modifications.ContainsKey(828994115, level);
        }

        private float GetDataAttackSpeedReduction(int level)
        {
            return _modifications.GetModification(845771331, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedReduction(int level, float value)
        {
            _modifications[845771331, level] = new LevelObjectDataModification{Id = 845771331, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAttackSpeedReductionModified(int level)
        {
            return _modifications.ContainsKey(845771331, level);
        }

        private float GetDataDamageReduction(int level)
        {
            return _modifications.GetModification(862548547, level).ValueAsFloat;
        }

        private void SetDataDamageReduction(int level, float value)
        {
            _modifications[862548547, level] = new LevelObjectDataModification{Id = 862548547, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageReductionModified(int level)
        {
            return _modifications.ContainsKey(862548547, level);
        }
    }
}