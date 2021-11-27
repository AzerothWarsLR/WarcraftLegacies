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
    public sealed class PoisonAttack : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerSecondModified;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedFactorModified;
        private readonly Lazy<ObjectProperty<int>> _dataStackingTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataStackingTypeModified;
        private readonly Lazy<ObjectProperty<StackFlags>> _dataStackingType;
        public PoisonAttack(): base(1768910913)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _isDataStackingTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackingTypeModified));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public PoisonAttack(int newId): base(1768910913, newId)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _isDataStackingTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackingTypeModified));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public PoisonAttack(string newRawcode): base(1768910913, newRawcode)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _isDataStackingTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackingTypeModified));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public PoisonAttack(ObjectDatabaseBase db): base(1768910913, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _isDataStackingTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackingTypeModified));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public PoisonAttack(int newId, ObjectDatabaseBase db): base(1768910913, newId, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _isDataStackingTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackingTypeModified));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public PoisonAttack(string newRawcode, ObjectDatabaseBase db): base(1768910913, newRawcode, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _isDataStackingTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackingTypeModified));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerSecondModified => _isDataDamagePerSecondModified.Value;
        public ObjectProperty<float> DataMovementSpeedFactor => _dataMovementSpeedFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedFactorModified => _isDataMovementSpeedFactorModified.Value;
        public ObjectProperty<float> DataAttackSpeedFactor => _dataAttackSpeedFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedFactorModified => _isDataAttackSpeedFactorModified.Value;
        public ObjectProperty<int> DataStackingTypeRaw => _dataStackingTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataStackingTypeModified => _isDataStackingTypeModified.Value;
        public ObjectProperty<StackFlags> DataStackingType => _dataStackingType.Value;
        private float GetDataDamagePerSecond(int level)
        {
            return _modifications.GetModification(828993360, level).ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[828993360, level] = new LevelObjectDataModification{Id = 828993360, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamagePerSecondModified(int level)
        {
            return _modifications.ContainsKey(828993360, level);
        }

        private float GetDataMovementSpeedFactor(int level)
        {
            return _modifications.GetModification(845770576, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedFactor(int level, float value)
        {
            _modifications[845770576, level] = new LevelObjectDataModification{Id = 845770576, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMovementSpeedFactorModified(int level)
        {
            return _modifications.ContainsKey(845770576, level);
        }

        private float GetDataAttackSpeedFactor(int level)
        {
            return _modifications.GetModification(862547792, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedFactor(int level, float value)
        {
            _modifications[862547792, level] = new LevelObjectDataModification{Id = 862547792, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAttackSpeedFactorModified(int level)
        {
            return _modifications.ContainsKey(862547792, level);
        }

        private int GetDataStackingTypeRaw(int level)
        {
            return _modifications.GetModification(879325008, level).ValueAsInt;
        }

        private void SetDataStackingTypeRaw(int level, int value)
        {
            _modifications[879325008, level] = new LevelObjectDataModification{Id = 879325008, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataStackingTypeModified(int level)
        {
            return _modifications.ContainsKey(879325008, level);
        }

        private StackFlags GetDataStackingType(int level)
        {
            return GetDataStackingTypeRaw(level).ToStackFlags(this);
        }

        private void SetDataStackingType(int level, StackFlags value)
        {
            SetDataStackingTypeRaw(level, value.ToRaw(null, null));
        }
    }
}