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
    public sealed class ColdArrows : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataExtraDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataExtraDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedFactorModified;
        private readonly Lazy<ObjectProperty<int>> _dataStackFlagsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataStackFlagsModified;
        private readonly Lazy<ObjectProperty<StackFlags>> _dataStackFlags;
        public ColdArrows(): base(1633896513)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _isDataExtraDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackFlagsRaw, SetDataStackFlagsRaw));
            _isDataStackFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackFlagsModified));
            _dataStackFlags = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackFlags, SetDataStackFlags));
        }

        public ColdArrows(int newId): base(1633896513, newId)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _isDataExtraDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackFlagsRaw, SetDataStackFlagsRaw));
            _isDataStackFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackFlagsModified));
            _dataStackFlags = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackFlags, SetDataStackFlags));
        }

        public ColdArrows(string newRawcode): base(1633896513, newRawcode)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _isDataExtraDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackFlagsRaw, SetDataStackFlagsRaw));
            _isDataStackFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackFlagsModified));
            _dataStackFlags = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackFlags, SetDataStackFlags));
        }

        public ColdArrows(ObjectDatabaseBase db): base(1633896513, db)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _isDataExtraDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackFlagsRaw, SetDataStackFlagsRaw));
            _isDataStackFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackFlagsModified));
            _dataStackFlags = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackFlags, SetDataStackFlags));
        }

        public ColdArrows(int newId, ObjectDatabaseBase db): base(1633896513, newId, db)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _isDataExtraDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackFlagsRaw, SetDataStackFlagsRaw));
            _isDataStackFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackFlagsModified));
            _dataStackFlags = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackFlags, SetDataStackFlags));
        }

        public ColdArrows(string newRawcode, ObjectDatabaseBase db): base(1633896513, newRawcode, db)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _isDataExtraDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataStackFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackFlagsRaw, SetDataStackFlagsRaw));
            _isDataStackFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStackFlagsModified));
            _dataStackFlags = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackFlags, SetDataStackFlags));
        }

        public ObjectProperty<float> DataExtraDamage => _dataExtraDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataExtraDamageModified => _isDataExtraDamageModified.Value;
        public ObjectProperty<float> DataMovementSpeedFactor => _dataMovementSpeedFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedFactorModified => _isDataMovementSpeedFactorModified.Value;
        public ObjectProperty<float> DataAttackSpeedFactor => _dataAttackSpeedFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedFactorModified => _isDataAttackSpeedFactorModified.Value;
        public ObjectProperty<int> DataStackFlagsRaw => _dataStackFlagsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataStackFlagsModified => _isDataStackFlagsModified.Value;
        public ObjectProperty<StackFlags> DataStackFlags => _dataStackFlags.Value;
        private float GetDataExtraDamage(int level)
        {
            return _modifications.GetModification(828465992, level).ValueAsFloat;
        }

        private void SetDataExtraDamage(int level, float value)
        {
            _modifications[828465992, level] = new LevelObjectDataModification{Id = 828465992, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataExtraDamageModified(int level)
        {
            return _modifications.ContainsKey(828465992, level);
        }

        private float GetDataMovementSpeedFactor(int level)
        {
            return _modifications.GetModification(845243208, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedFactor(int level, float value)
        {
            _modifications[845243208, level] = new LevelObjectDataModification{Id = 845243208, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMovementSpeedFactorModified(int level)
        {
            return _modifications.ContainsKey(845243208, level);
        }

        private float GetDataAttackSpeedFactor(int level)
        {
            return _modifications.GetModification(862020424, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedFactor(int level, float value)
        {
            _modifications[862020424, level] = new LevelObjectDataModification{Id = 862020424, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAttackSpeedFactorModified(int level)
        {
            return _modifications.ContainsKey(862020424, level);
        }

        private int GetDataStackFlagsRaw(int level)
        {
            return _modifications.GetModification(878797640, level).ValueAsInt;
        }

        private void SetDataStackFlagsRaw(int level, int value)
        {
            _modifications[878797640, level] = new LevelObjectDataModification{Id = 878797640, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataStackFlagsModified(int level)
        {
            return _modifications.ContainsKey(878797640, level);
        }

        private StackFlags GetDataStackFlags(int level)
        {
            return GetDataStackFlagsRaw(level).ToStackFlags(this);
        }

        private void SetDataStackFlags(int level, StackFlags value)
        {
            SetDataStackFlagsRaw(level, value.ToRaw(null, null));
        }
    }
}