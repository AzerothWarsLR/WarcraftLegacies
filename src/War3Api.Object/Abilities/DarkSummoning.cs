using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DarkSummoning : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataUseTeleportClustering;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumUnits;
        private readonly Lazy<ObjectProperty<float>> _dataCastingDelaySeconds;
        public DarkSummoning(): base(1935955265)
        {
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _dataCastingDelaySeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelaySeconds, SetDataCastingDelaySeconds));
        }

        public DarkSummoning(int newId): base(1935955265, newId)
        {
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _dataCastingDelaySeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelaySeconds, SetDataCastingDelaySeconds));
        }

        public DarkSummoning(string newRawcode): base(1935955265, newRawcode)
        {
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _dataCastingDelaySeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelaySeconds, SetDataCastingDelaySeconds));
        }

        public DarkSummoning(ObjectDatabase db): base(1935955265, db)
        {
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _dataCastingDelaySeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelaySeconds, SetDataCastingDelaySeconds));
        }

        public DarkSummoning(int newId, ObjectDatabase db): base(1935955265, newId, db)
        {
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _dataCastingDelaySeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelaySeconds, SetDataCastingDelaySeconds));
        }

        public DarkSummoning(string newRawcode, ObjectDatabase db): base(1935955265, newRawcode, db)
        {
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _dataCastingDelaySeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelaySeconds, SetDataCastingDelaySeconds));
        }

        public ObjectProperty<bool> DataUseTeleportClustering => _dataUseTeleportClustering.Value;
        public ObjectProperty<int> DataMaximumUnits => _dataMaximumUnits.Value;
        public ObjectProperty<float> DataCastingDelaySeconds => _dataCastingDelaySeconds.Value;
        private bool GetDataUseTeleportClustering(int level)
        {
            return _modifications[863268168, level].ValueAsBool;
        }

        private void SetDataUseTeleportClustering(int level, bool value)
        {
            _modifications[863268168, level] = new LevelObjectDataModification{Id = 863268168, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private int GetDataMaximumUnits(int level)
        {
            return _modifications[829645909, level].ValueAsInt;
        }

        private void SetDataMaximumUnits(int level, int value)
        {
            _modifications[829645909, level] = new LevelObjectDataModification{Id = 829645909, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataCastingDelaySeconds(int level)
        {
            return _modifications[846423125, level].ValueAsFloat;
        }

        private void SetDataCastingDelaySeconds(int level, float value)
        {
            _modifications[846423125, level] = new LevelObjectDataModification{Id = 846423125, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}