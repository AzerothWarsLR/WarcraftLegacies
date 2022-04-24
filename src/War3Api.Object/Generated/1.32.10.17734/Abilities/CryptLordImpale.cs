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
    public sealed class CryptLordImpale : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataWaveDistance;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataWaveDistanceModified;
        private readonly Lazy<ObjectProperty<float>> _dataWaveTimeseconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataWaveTimesecondsModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealt;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageDealtModified;
        private readonly Lazy<ObjectProperty<float>> _dataAirTimeseconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAirTimesecondsModified;
        private readonly Lazy<ObjectProperty<int>> _dataUninterruptibleRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUninterruptibleModified;
        private readonly Lazy<ObjectProperty<bool>> _dataUninterruptible;
        private readonly Lazy<ObjectProperty<int>> _dataAirborneTargetsVulnerableRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAirborneTargetsVulnerableModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAirborneTargetsVulnerable;
        public CryptLordImpale(): base(1835619649)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _isDataWaveDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveDistanceModified));
            _dataWaveTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeseconds, SetDataWaveTimeseconds));
            _isDataWaveTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveTimesecondsModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataUninterruptibleRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUninterruptibleRaw, SetDataUninterruptibleRaw));
            _isDataUninterruptibleModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUninterruptibleModified));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAirborneTargetsVulnerableRaw, SetDataAirborneTargetsVulnerableRaw));
            _isDataAirborneTargetsVulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirborneTargetsVulnerableModified));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public CryptLordImpale(int newId): base(1835619649, newId)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _isDataWaveDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveDistanceModified));
            _dataWaveTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeseconds, SetDataWaveTimeseconds));
            _isDataWaveTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveTimesecondsModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataUninterruptibleRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUninterruptibleRaw, SetDataUninterruptibleRaw));
            _isDataUninterruptibleModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUninterruptibleModified));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAirborneTargetsVulnerableRaw, SetDataAirborneTargetsVulnerableRaw));
            _isDataAirborneTargetsVulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirborneTargetsVulnerableModified));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public CryptLordImpale(string newRawcode): base(1835619649, newRawcode)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _isDataWaveDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveDistanceModified));
            _dataWaveTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeseconds, SetDataWaveTimeseconds));
            _isDataWaveTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveTimesecondsModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataUninterruptibleRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUninterruptibleRaw, SetDataUninterruptibleRaw));
            _isDataUninterruptibleModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUninterruptibleModified));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAirborneTargetsVulnerableRaw, SetDataAirborneTargetsVulnerableRaw));
            _isDataAirborneTargetsVulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirborneTargetsVulnerableModified));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public CryptLordImpale(ObjectDatabaseBase db): base(1835619649, db)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _isDataWaveDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveDistanceModified));
            _dataWaveTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeseconds, SetDataWaveTimeseconds));
            _isDataWaveTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveTimesecondsModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataUninterruptibleRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUninterruptibleRaw, SetDataUninterruptibleRaw));
            _isDataUninterruptibleModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUninterruptibleModified));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAirborneTargetsVulnerableRaw, SetDataAirborneTargetsVulnerableRaw));
            _isDataAirborneTargetsVulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirborneTargetsVulnerableModified));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public CryptLordImpale(int newId, ObjectDatabaseBase db): base(1835619649, newId, db)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _isDataWaveDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveDistanceModified));
            _dataWaveTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeseconds, SetDataWaveTimeseconds));
            _isDataWaveTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveTimesecondsModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataUninterruptibleRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUninterruptibleRaw, SetDataUninterruptibleRaw));
            _isDataUninterruptibleModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUninterruptibleModified));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAirborneTargetsVulnerableRaw, SetDataAirborneTargetsVulnerableRaw));
            _isDataAirborneTargetsVulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirborneTargetsVulnerableModified));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public CryptLordImpale(string newRawcode, ObjectDatabaseBase db): base(1835619649, newRawcode, db)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _isDataWaveDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveDistanceModified));
            _dataWaveTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeseconds, SetDataWaveTimeseconds));
            _isDataWaveTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveTimesecondsModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataUninterruptibleRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUninterruptibleRaw, SetDataUninterruptibleRaw));
            _isDataUninterruptibleModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUninterruptibleModified));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAirborneTargetsVulnerableRaw, SetDataAirborneTargetsVulnerableRaw));
            _isDataAirborneTargetsVulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirborneTargetsVulnerableModified));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public ObjectProperty<float> DataWaveDistance => _dataWaveDistance.Value;
        public ReadOnlyObjectProperty<bool> IsDataWaveDistanceModified => _isDataWaveDistanceModified.Value;
        public ObjectProperty<float> DataWaveTimeseconds => _dataWaveTimeseconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataWaveTimesecondsModified => _isDataWaveTimesecondsModified.Value;
        public ObjectProperty<float> DataDamageDealt => _dataDamageDealt.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageDealtModified => _isDataDamageDealtModified.Value;
        public ObjectProperty<float> DataAirTimeseconds => _dataAirTimeseconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataAirTimesecondsModified => _isDataAirTimesecondsModified.Value;
        public ObjectProperty<int> DataUninterruptibleRaw => _dataUninterruptibleRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUninterruptibleModified => _isDataUninterruptibleModified.Value;
        public ObjectProperty<bool> DataUninterruptible => _dataUninterruptible.Value;
        public ObjectProperty<int> DataAirborneTargetsVulnerableRaw => _dataAirborneTargetsVulnerableRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAirborneTargetsVulnerableModified => _isDataAirborneTargetsVulnerableModified.Value;
        public ObjectProperty<bool> DataAirborneTargetsVulnerable => _dataAirborneTargetsVulnerable.Value;
        private float GetDataWaveDistance(int level)
        {
            return _modifications.GetModification(829253973, level).ValueAsFloat;
        }

        private void SetDataWaveDistance(int level, float value)
        {
            _modifications[829253973, level] = new LevelObjectDataModification{Id = 829253973, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataWaveDistanceModified(int level)
        {
            return _modifications.ContainsKey(829253973, level);
        }

        private float GetDataWaveTimeseconds(int level)
        {
            return _modifications.GetModification(846031189, level).ValueAsFloat;
        }

        private void SetDataWaveTimeseconds(int level, float value)
        {
            _modifications[846031189, level] = new LevelObjectDataModification{Id = 846031189, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataWaveTimesecondsModified(int level)
        {
            return _modifications.ContainsKey(846031189, level);
        }

        private float GetDataDamageDealt(int level)
        {
            return _modifications.GetModification(862808405, level).ValueAsFloat;
        }

        private void SetDataDamageDealt(int level, float value)
        {
            _modifications[862808405, level] = new LevelObjectDataModification{Id = 862808405, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageDealtModified(int level)
        {
            return _modifications.ContainsKey(862808405, level);
        }

        private float GetDataAirTimeseconds(int level)
        {
            return _modifications.GetModification(879585621, level).ValueAsFloat;
        }

        private void SetDataAirTimeseconds(int level, float value)
        {
            _modifications[879585621, level] = new LevelObjectDataModification{Id = 879585621, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataAirTimesecondsModified(int level)
        {
            return _modifications.ContainsKey(879585621, level);
        }

        private int GetDataUninterruptibleRaw(int level)
        {
            return _modifications.GetModification(896362837, level).ValueAsInt;
        }

        private void SetDataUninterruptibleRaw(int level, int value)
        {
            _modifications[896362837, level] = new LevelObjectDataModification{Id = 896362837, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataUninterruptibleModified(int level)
        {
            return _modifications.ContainsKey(896362837, level);
        }

        private bool GetDataUninterruptible(int level)
        {
            return GetDataUninterruptibleRaw(level).ToBool(this);
        }

        private void SetDataUninterruptible(int level, bool value)
        {
            SetDataUninterruptibleRaw(level, value.ToRaw(null, null));
        }

        private int GetDataAirborneTargetsVulnerableRaw(int level)
        {
            return _modifications.GetModification(913140053, level).ValueAsInt;
        }

        private void SetDataAirborneTargetsVulnerableRaw(int level, int value)
        {
            _modifications[913140053, level] = new LevelObjectDataModification{Id = 913140053, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataAirborneTargetsVulnerableModified(int level)
        {
            return _modifications.ContainsKey(913140053, level);
        }

        private bool GetDataAirborneTargetsVulnerable(int level)
        {
            return GetDataAirborneTargetsVulnerableRaw(level).ToBool(this);
        }

        private void SetDataAirborneTargetsVulnerable(int level, bool value)
        {
            SetDataAirborneTargetsVulnerableRaw(level, value.ToRaw(null, null));
        }
    }
}