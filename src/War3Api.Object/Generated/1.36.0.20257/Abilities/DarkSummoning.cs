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
    public sealed class DarkSummoning : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataUseTeleportClusteringRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUseTeleportClusteringModified;
        private readonly Lazy<ObjectProperty<bool>> _dataUseTeleportClustering;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumUnitsModified;
        private readonly Lazy<ObjectProperty<float>> _dataCastingDelayseconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCastingDelaysecondsModified;
        public DarkSummoning(): base(1935955265)
        {
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _isDataMaximumUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsModified));
            _dataCastingDelayseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelayseconds, SetDataCastingDelayseconds));
            _isDataCastingDelaysecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelaysecondsModified));
        }

        public DarkSummoning(int newId): base(1935955265, newId)
        {
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _isDataMaximumUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsModified));
            _dataCastingDelayseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelayseconds, SetDataCastingDelayseconds));
            _isDataCastingDelaysecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelaysecondsModified));
        }

        public DarkSummoning(string newRawcode): base(1935955265, newRawcode)
        {
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _isDataMaximumUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsModified));
            _dataCastingDelayseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelayseconds, SetDataCastingDelayseconds));
            _isDataCastingDelaysecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelaysecondsModified));
        }

        public DarkSummoning(ObjectDatabaseBase db): base(1935955265, db)
        {
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _isDataMaximumUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsModified));
            _dataCastingDelayseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelayseconds, SetDataCastingDelayseconds));
            _isDataCastingDelaysecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelaysecondsModified));
        }

        public DarkSummoning(int newId, ObjectDatabaseBase db): base(1935955265, newId, db)
        {
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _isDataMaximumUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsModified));
            _dataCastingDelayseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelayseconds, SetDataCastingDelayseconds));
            _isDataCastingDelaysecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelaysecondsModified));
        }

        public DarkSummoning(string newRawcode, ObjectDatabaseBase db): base(1935955265, newRawcode, db)
        {
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _dataMaximumUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnits, SetDataMaximumUnits));
            _isDataMaximumUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsModified));
            _dataCastingDelayseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelayseconds, SetDataCastingDelayseconds));
            _isDataCastingDelaysecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelaysecondsModified));
        }

        public ObjectProperty<int> DataUseTeleportClusteringRaw => _dataUseTeleportClusteringRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUseTeleportClusteringModified => _isDataUseTeleportClusteringModified.Value;
        public ObjectProperty<bool> DataUseTeleportClustering => _dataUseTeleportClustering.Value;
        public ObjectProperty<int> DataMaximumUnits => _dataMaximumUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumUnitsModified => _isDataMaximumUnitsModified.Value;
        public ObjectProperty<float> DataCastingDelayseconds => _dataCastingDelayseconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataCastingDelaysecondsModified => _isDataCastingDelaysecondsModified.Value;
        private int GetDataUseTeleportClusteringRaw(int level)
        {
            return _modifications.GetModification(863268168, level).ValueAsInt;
        }

        private void SetDataUseTeleportClusteringRaw(int level, int value)
        {
            _modifications[863268168, level] = new LevelObjectDataModification{Id = 863268168, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataUseTeleportClusteringModified(int level)
        {
            return _modifications.ContainsKey(863268168, level);
        }

        private bool GetDataUseTeleportClustering(int level)
        {
            return GetDataUseTeleportClusteringRaw(level).ToBool(this);
        }

        private void SetDataUseTeleportClustering(int level, bool value)
        {
            SetDataUseTeleportClusteringRaw(level, value.ToRaw(null, null));
        }

        private int GetDataMaximumUnits(int level)
        {
            return _modifications.GetModification(829645909, level).ValueAsInt;
        }

        private void SetDataMaximumUnits(int level, int value)
        {
            _modifications[829645909, level] = new LevelObjectDataModification{Id = 829645909, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaximumUnitsModified(int level)
        {
            return _modifications.ContainsKey(829645909, level);
        }

        private float GetDataCastingDelayseconds(int level)
        {
            return _modifications.GetModification(846423125, level).ValueAsFloat;
        }

        private void SetDataCastingDelayseconds(int level, float value)
        {
            _modifications[846423125, level] = new LevelObjectDataModification{Id = 846423125, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataCastingDelaysecondsModified(int level)
        {
            return _modifications.ContainsKey(846423125, level);
        }
    }
}