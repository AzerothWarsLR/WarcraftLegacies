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
    public sealed class AuraSlow : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedFactorModified;
        private readonly Lazy<ObjectProperty<int>> _dataAlwaysAutocastRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAlwaysAutocastModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAlwaysAutocast;
        public AuraSlow(): base(1819500865)
        {
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public AuraSlow(int newId): base(1819500865, newId)
        {
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public AuraSlow(string newRawcode): base(1819500865, newRawcode)
        {
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public AuraSlow(ObjectDatabaseBase db): base(1819500865, db)
        {
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public AuraSlow(int newId, ObjectDatabaseBase db): base(1819500865, newId, db)
        {
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public AuraSlow(string newRawcode, ObjectDatabaseBase db): base(1819500865, newRawcode, db)
        {
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public ObjectProperty<float> DataMovementSpeedFactor => _dataMovementSpeedFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedFactorModified => _isDataMovementSpeedFactorModified.Value;
        public ObjectProperty<float> DataAttackSpeedFactor => _dataAttackSpeedFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedFactorModified => _isDataAttackSpeedFactorModified.Value;
        public ObjectProperty<int> DataAlwaysAutocastRaw => _dataAlwaysAutocastRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAlwaysAutocastModified => _isDataAlwaysAutocastModified.Value;
        public ObjectProperty<bool> DataAlwaysAutocast => _dataAlwaysAutocast.Value;
        private float GetDataMovementSpeedFactor(int level)
        {
            return _modifications.GetModification(829385811, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedFactor(int level, float value)
        {
            _modifications[829385811, level] = new LevelObjectDataModification{Id = 829385811, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMovementSpeedFactorModified(int level)
        {
            return _modifications.ContainsKey(829385811, level);
        }

        private float GetDataAttackSpeedFactor(int level)
        {
            return _modifications.GetModification(846163027, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedFactor(int level, float value)
        {
            _modifications[846163027, level] = new LevelObjectDataModification{Id = 846163027, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAttackSpeedFactorModified(int level)
        {
            return _modifications.ContainsKey(846163027, level);
        }

        private int GetDataAlwaysAutocastRaw(int level)
        {
            return _modifications.GetModification(862940243, level).ValueAsInt;
        }

        private void SetDataAlwaysAutocastRaw(int level, int value)
        {
            _modifications[862940243, level] = new LevelObjectDataModification{Id = 862940243, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAlwaysAutocastModified(int level)
        {
            return _modifications.ContainsKey(862940243, level);
        }

        private bool GetDataAlwaysAutocast(int level)
        {
            return GetDataAlwaysAutocastRaw(level).ToBool(this);
        }

        private void SetDataAlwaysAutocast(int level, bool value)
        {
            SetDataAlwaysAutocastRaw(level, value.ToRaw(0, 1));
        }
    }
}