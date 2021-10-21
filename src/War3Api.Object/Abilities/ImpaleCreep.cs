using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ImpaleCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataWaveDistance;
        private readonly Lazy<ObjectProperty<float>> _dataWaveTimeSeconds;
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealt;
        private readonly Lazy<ObjectProperty<float>> _dataAirTimeSeconds;
        private readonly Lazy<ObjectProperty<bool>> _dataUninterruptible;
        private readonly Lazy<ObjectProperty<bool>> _dataAirborneTargetsVulnerable;
        public ImpaleCreep(): base(1886208833)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _dataWaveTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeSeconds, SetDataWaveTimeSeconds));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public ImpaleCreep(int newId): base(1886208833, newId)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _dataWaveTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeSeconds, SetDataWaveTimeSeconds));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public ImpaleCreep(string newRawcode): base(1886208833, newRawcode)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _dataWaveTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeSeconds, SetDataWaveTimeSeconds));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public ImpaleCreep(ObjectDatabase db): base(1886208833, db)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _dataWaveTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeSeconds, SetDataWaveTimeSeconds));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public ImpaleCreep(int newId, ObjectDatabase db): base(1886208833, newId, db)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _dataWaveTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeSeconds, SetDataWaveTimeSeconds));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public ImpaleCreep(string newRawcode, ObjectDatabase db): base(1886208833, newRawcode, db)
        {
            _dataWaveDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveDistance, SetDataWaveDistance));
            _dataWaveTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveTimeSeconds, SetDataWaveTimeSeconds));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataUninterruptible = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUninterruptible, SetDataUninterruptible));
            _dataAirborneTargetsVulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAirborneTargetsVulnerable, SetDataAirborneTargetsVulnerable));
        }

        public ObjectProperty<float> DataWaveDistance => _dataWaveDistance.Value;
        public ObjectProperty<float> DataWaveTimeSeconds => _dataWaveTimeSeconds.Value;
        public ObjectProperty<float> DataDamageDealt => _dataDamageDealt.Value;
        public ObjectProperty<float> DataAirTimeSeconds => _dataAirTimeSeconds.Value;
        public ObjectProperty<bool> DataUninterruptible => _dataUninterruptible.Value;
        public ObjectProperty<bool> DataAirborneTargetsVulnerable => _dataAirborneTargetsVulnerable.Value;
        private float GetDataWaveDistance(int level)
        {
            return _modifications[829253973, level].ValueAsFloat;
        }

        private void SetDataWaveDistance(int level, float value)
        {
            _modifications[829253973, level] = new LevelObjectDataModification{Id = 829253973, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataWaveTimeSeconds(int level)
        {
            return _modifications[846031189, level].ValueAsFloat;
        }

        private void SetDataWaveTimeSeconds(int level, float value)
        {
            _modifications[846031189, level] = new LevelObjectDataModification{Id = 846031189, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamageDealt(int level)
        {
            return _modifications[862808405, level].ValueAsFloat;
        }

        private void SetDataDamageDealt(int level, float value)
        {
            _modifications[862808405, level] = new LevelObjectDataModification{Id = 862808405, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataAirTimeSeconds(int level)
        {
            return _modifications[879585621, level].ValueAsFloat;
        }

        private void SetDataAirTimeSeconds(int level, float value)
        {
            _modifications[879585621, level] = new LevelObjectDataModification{Id = 879585621, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataUninterruptible(int level)
        {
            return _modifications[896362837, level].ValueAsBool;
        }

        private void SetDataUninterruptible(int level, bool value)
        {
            _modifications[896362837, level] = new LevelObjectDataModification{Id = 896362837, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private bool GetDataAirborneTargetsVulnerable(int level)
        {
            return _modifications[913140053, level].ValueAsBool;
        }

        private void SetDataAirborneTargetsVulnerable(int level, bool value)
        {
            _modifications[913140053, level] = new LevelObjectDataModification{Id = 913140053, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 6};
        }
    }
}