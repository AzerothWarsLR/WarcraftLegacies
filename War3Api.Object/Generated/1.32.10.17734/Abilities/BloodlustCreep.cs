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
    public sealed class BloodlustCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedIncreaseModified;
        private readonly Lazy<ObjectProperty<float>> _dataScalingFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataScalingFactorModified;
        public BloodlustCreep(): base(1818379073)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public BloodlustCreep(int newId): base(1818379073, newId)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public BloodlustCreep(string newRawcode): base(1818379073, newRawcode)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public BloodlustCreep(ObjectDatabaseBase db): base(1818379073, db)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public BloodlustCreep(int newId, ObjectDatabaseBase db): base(1818379073, newId, db)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public BloodlustCreep(string newRawcode, ObjectDatabaseBase db): base(1818379073, newRawcode, db)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public ObjectProperty<float> DataAttackSpeedIncrease => _dataAttackSpeedIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedIncreaseModified => _isDataAttackSpeedIncreaseModified.Value;
        public ObjectProperty<float> DataScalingFactor => _dataScalingFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataScalingFactorModified => _isDataScalingFactorModified.Value;
        private float GetDataAttackSpeedIncrease(int level)
        {
            return _modifications.GetModification(829385794, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedIncrease(int level, float value)
        {
            _modifications[829385794, level] = new LevelObjectDataModification{Id = 829385794, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAttackSpeedIncreaseModified(int level)
        {
            return _modifications.ContainsKey(829385794, level);
        }

        private float GetDataScalingFactor(int level)
        {
            return _modifications.GetModification(862940226, level).ValueAsFloat;
        }

        private void SetDataScalingFactor(int level, float value)
        {
            _modifications[862940226, level] = new LevelObjectDataModification{Id = 862940226, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataScalingFactorModified(int level)
        {
            return _modifications.ContainsKey(862940226, level);
        }
    }
}