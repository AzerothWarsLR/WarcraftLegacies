using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CryptLordLocustSwarm : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfSwarmUnits;
        private readonly Lazy<ObjectProperty<float>> _dataUnitReleaseIntervalSeconds;
        private readonly Lazy<ObjectProperty<int>> _dataMaxSwarmUnitsPerTarget;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReturnFactor;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReturnThreshold;
        private readonly Lazy<ObjectProperty<string>> _dataSwarmUnitTypeRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataSwarmUnitType;
        public CryptLordLocustSwarm(): base(1936479553)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _dataUnitReleaseIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalSeconds, SetDataUnitReleaseIntervalSeconds));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public CryptLordLocustSwarm(int newId): base(1936479553, newId)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _dataUnitReleaseIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalSeconds, SetDataUnitReleaseIntervalSeconds));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public CryptLordLocustSwarm(string newRawcode): base(1936479553, newRawcode)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _dataUnitReleaseIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalSeconds, SetDataUnitReleaseIntervalSeconds));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public CryptLordLocustSwarm(ObjectDatabase db): base(1936479553, db)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _dataUnitReleaseIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalSeconds, SetDataUnitReleaseIntervalSeconds));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public CryptLordLocustSwarm(int newId, ObjectDatabase db): base(1936479553, newId, db)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _dataUnitReleaseIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalSeconds, SetDataUnitReleaseIntervalSeconds));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public CryptLordLocustSwarm(string newRawcode, ObjectDatabase db): base(1936479553, newRawcode, db)
        {
            _dataNumberOfSwarmUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSwarmUnits, SetDataNumberOfSwarmUnits));
            _dataUnitReleaseIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitReleaseIntervalSeconds, SetDataUnitReleaseIntervalSeconds));
            _dataMaxSwarmUnitsPerTarget = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxSwarmUnitsPerTarget, SetDataMaxSwarmUnitsPerTarget));
            _dataDamageReturnFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnFactor, SetDataDamageReturnFactor));
            _dataDamageReturnThreshold = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReturnThreshold, SetDataDamageReturnThreshold));
            _dataSwarmUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSwarmUnitTypeRaw, SetDataSwarmUnitTypeRaw));
            _dataSwarmUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSwarmUnitType, SetDataSwarmUnitType));
        }

        public ObjectProperty<int> DataNumberOfSwarmUnits => _dataNumberOfSwarmUnits.Value;
        public ObjectProperty<float> DataUnitReleaseIntervalSeconds => _dataUnitReleaseIntervalSeconds.Value;
        public ObjectProperty<int> DataMaxSwarmUnitsPerTarget => _dataMaxSwarmUnitsPerTarget.Value;
        public ObjectProperty<float> DataDamageReturnFactor => _dataDamageReturnFactor.Value;
        public ObjectProperty<float> DataDamageReturnThreshold => _dataDamageReturnThreshold.Value;
        public ObjectProperty<string> DataSwarmUnitTypeRaw => _dataSwarmUnitTypeRaw.Value;
        public ObjectProperty<Unit> DataSwarmUnitType => _dataSwarmUnitType.Value;
        private int GetDataNumberOfSwarmUnits(int level)
        {
            return _modifications[829647957, level].ValueAsInt;
        }

        private void SetDataNumberOfSwarmUnits(int level, int value)
        {
            _modifications[829647957, level] = new LevelObjectDataModification{Id = 829647957, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataUnitReleaseIntervalSeconds(int level)
        {
            return _modifications[846425173, level].ValueAsFloat;
        }

        private void SetDataUnitReleaseIntervalSeconds(int level, float value)
        {
            _modifications[846425173, level] = new LevelObjectDataModification{Id = 846425173, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataMaxSwarmUnitsPerTarget(int level)
        {
            return _modifications[863202389, level].ValueAsInt;
        }

        private void SetDataMaxSwarmUnitsPerTarget(int level, int value)
        {
            _modifications[863202389, level] = new LevelObjectDataModification{Id = 863202389, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataDamageReturnFactor(int level)
        {
            return _modifications[879979605, level].ValueAsFloat;
        }

        private void SetDataDamageReturnFactor(int level, float value)
        {
            _modifications[879979605, level] = new LevelObjectDataModification{Id = 879979605, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataDamageReturnThreshold(int level)
        {
            return _modifications[896756821, level].ValueAsFloat;
        }

        private void SetDataDamageReturnThreshold(int level, float value)
        {
            _modifications[896756821, level] = new LevelObjectDataModification{Id = 896756821, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private string GetDataSwarmUnitTypeRaw(int level)
        {
            return _modifications[1970498645, level].ValueAsString;
        }

        private void SetDataSwarmUnitTypeRaw(int level, string value)
        {
            _modifications[1970498645, level] = new LevelObjectDataModification{Id = 1970498645, Type = ObjectDataType.String, Value = value, Level = level};
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