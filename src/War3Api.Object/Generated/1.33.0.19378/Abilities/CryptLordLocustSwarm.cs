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
    public sealed class CryptLordLocustSwarm : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfSwarmUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfSwarmUnitsModified;
        private readonly Lazy<ObjectProperty<float>> _dataUnitReleaseIntervalseconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitReleaseIntervalsecondsModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaxSwarmUnitsPerTarget;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxSwarmUnitsPerTargetModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReturnFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageReturnFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReturnThreshold;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageReturnThresholdModified;
        private readonly Lazy<ObjectProperty<string>> _dataSwarmUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSwarmUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataSwarmUnitType;
        public CryptLordLocustSwarm(): base(1936479553)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _isDataNumberOfSwarmUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSwarmUnitsModified));
            _dataUnitReleaseIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalseconds, SetDataUnitReleaseIntervalseconds));
            _isDataUnitReleaseIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitReleaseIntervalsecondsModified));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _isDataMaxSwarmUnitsPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxSwarmUnitsPerTargetModified));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _isDataDamageReturnFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnFactorModified));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _isDataDamageReturnThresholdModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnThresholdModified));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _isDataSwarmUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSwarmUnitTypeModified));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public CryptLordLocustSwarm(int newId): base(1936479553, newId)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _isDataNumberOfSwarmUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSwarmUnitsModified));
            _dataUnitReleaseIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalseconds, SetDataUnitReleaseIntervalseconds));
            _isDataUnitReleaseIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitReleaseIntervalsecondsModified));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _isDataMaxSwarmUnitsPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxSwarmUnitsPerTargetModified));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _isDataDamageReturnFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnFactorModified));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _isDataDamageReturnThresholdModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnThresholdModified));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _isDataSwarmUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSwarmUnitTypeModified));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public CryptLordLocustSwarm(string newRawcode): base(1936479553, newRawcode)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _isDataNumberOfSwarmUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSwarmUnitsModified));
            _dataUnitReleaseIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalseconds, SetDataUnitReleaseIntervalseconds));
            _isDataUnitReleaseIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitReleaseIntervalsecondsModified));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _isDataMaxSwarmUnitsPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxSwarmUnitsPerTargetModified));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _isDataDamageReturnFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnFactorModified));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _isDataDamageReturnThresholdModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnThresholdModified));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _isDataSwarmUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSwarmUnitTypeModified));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public CryptLordLocustSwarm(ObjectDatabaseBase db): base(1936479553, db)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _isDataNumberOfSwarmUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSwarmUnitsModified));
            _dataUnitReleaseIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalseconds, SetDataUnitReleaseIntervalseconds));
            _isDataUnitReleaseIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitReleaseIntervalsecondsModified));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _isDataMaxSwarmUnitsPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxSwarmUnitsPerTargetModified));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _isDataDamageReturnFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnFactorModified));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _isDataDamageReturnThresholdModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnThresholdModified));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _isDataSwarmUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSwarmUnitTypeModified));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public CryptLordLocustSwarm(int newId, ObjectDatabaseBase db): base(1936479553, newId, db)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _isDataNumberOfSwarmUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSwarmUnitsModified));
            _dataUnitReleaseIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalseconds, SetDataUnitReleaseIntervalseconds));
            _isDataUnitReleaseIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitReleaseIntervalsecondsModified));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _isDataMaxSwarmUnitsPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxSwarmUnitsPerTargetModified));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _isDataDamageReturnFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnFactorModified));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _isDataDamageReturnThresholdModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnThresholdModified));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _isDataSwarmUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSwarmUnitTypeModified));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public CryptLordLocustSwarm(string newRawcode, ObjectDatabaseBase db): base(1936479553, newRawcode, db)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _isDataNumberOfSwarmUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSwarmUnitsModified));
            _dataUnitReleaseIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalseconds, SetDataUnitReleaseIntervalseconds));
            _isDataUnitReleaseIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitReleaseIntervalsecondsModified));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _isDataMaxSwarmUnitsPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxSwarmUnitsPerTargetModified));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _isDataDamageReturnFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnFactorModified));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _isDataDamageReturnThresholdModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReturnThresholdModified));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _isDataSwarmUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSwarmUnitTypeModified));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public ObjectProperty<int> DataNumberOfSwarmUnits => _dataNumberOfSwarmUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfSwarmUnitsModified => _isDataNumberOfSwarmUnitsModified.Value;
        public ObjectProperty<float> DataUnitReleaseIntervalseconds => _dataUnitReleaseIntervalseconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitReleaseIntervalsecondsModified => _isDataUnitReleaseIntervalsecondsModified.Value;
        public ObjectProperty<int> DataMaxSwarmUnitsPerTarget => _dataMaxSwarmUnitsPerTarget.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxSwarmUnitsPerTargetModified => _isDataMaxSwarmUnitsPerTargetModified.Value;
        public ObjectProperty<float> DataDamageReturnFactor => _dataDamageReturnFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageReturnFactorModified => _isDataDamageReturnFactorModified.Value;
        public ObjectProperty<float> DataDamageReturnThreshold => _dataDamageReturnThreshold.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageReturnThresholdModified => _isDataDamageReturnThresholdModified.Value;
        public ObjectProperty<string> DataSwarmUnitTypeRaw => _dataSwarmUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSwarmUnitTypeModified => _isDataSwarmUnitTypeModified.Value;
        public ObjectProperty<Unit> DataSwarmUnitType => _dataSwarmUnitType.Value;
        private int GetDataNumberOfSwarmUnits(int level)
        {
            return _modifications.GetModification(829647957, level).ValueAsInt;
        }

        private void SetDataNumberOfSwarmUnits(int level, int value)
        {
            _modifications[829647957, level] = new LevelObjectDataModification{Id = 829647957, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfSwarmUnitsModified(int level)
        {
            return _modifications.ContainsKey(829647957, level);
        }

        private float GetDataUnitReleaseIntervalseconds(int level)
        {
            return _modifications.GetModification(846425173, level).ValueAsFloat;
        }

        private void SetDataUnitReleaseIntervalseconds(int level, float value)
        {
            _modifications[846425173, level] = new LevelObjectDataModification{Id = 846425173, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataUnitReleaseIntervalsecondsModified(int level)
        {
            return _modifications.ContainsKey(846425173, level);
        }

        private int GetDataMaxSwarmUnitsPerTarget(int level)
        {
            return _modifications.GetModification(863202389, level).ValueAsInt;
        }

        private void SetDataMaxSwarmUnitsPerTarget(int level, int value)
        {
            _modifications[863202389, level] = new LevelObjectDataModification{Id = 863202389, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMaxSwarmUnitsPerTargetModified(int level)
        {
            return _modifications.ContainsKey(863202389, level);
        }

        private float GetDataDamageReturnFactor(int level)
        {
            return _modifications.GetModification(879979605, level).ValueAsFloat;
        }

        private void SetDataDamageReturnFactor(int level, float value)
        {
            _modifications[879979605, level] = new LevelObjectDataModification{Id = 879979605, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataDamageReturnFactorModified(int level)
        {
            return _modifications.ContainsKey(879979605, level);
        }

        private float GetDataDamageReturnThreshold(int level)
        {
            return _modifications.GetModification(896756821, level).ValueAsFloat;
        }

        private void SetDataDamageReturnThreshold(int level, float value)
        {
            _modifications[896756821, level] = new LevelObjectDataModification{Id = 896756821, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataDamageReturnThresholdModified(int level)
        {
            return _modifications.ContainsKey(896756821, level);
        }

        private string GetDataSwarmUnitTypeRaw(int level)
        {
            return _modifications.GetModification(1970498645, level).ValueAsString;
        }

        private void SetDataSwarmUnitTypeRaw(int level, string value)
        {
            _modifications[1970498645, level] = new LevelObjectDataModification{Id = 1970498645, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataSwarmUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(1970498645, level);
        }

        private Unit GetDataSwarmUnitType(int level)
        {
            return GetDataSwarmUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataSwarmUnitType(int level, Unit value)
        {
            SetDataSwarmUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}