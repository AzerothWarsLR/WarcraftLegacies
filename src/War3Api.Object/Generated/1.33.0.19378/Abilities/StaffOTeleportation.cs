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
    public sealed class StaffOTeleportation : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfUnitsTeleported;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfUnitsTeleportedModified;
        private readonly Lazy<ObjectProperty<float>> _dataCastingDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCastingDelayModified;
        private readonly Lazy<ObjectProperty<int>> _dataUseTeleportClusteringRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUseTeleportClusteringModified;
        private readonly Lazy<ObjectProperty<bool>> _dataUseTeleportClustering;
        public StaffOTeleportation(): base(1953319233)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _isDataNumberOfUnitsTeleportedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsTeleportedModified));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _isDataCastingDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelayModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public StaffOTeleportation(int newId): base(1953319233, newId)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _isDataNumberOfUnitsTeleportedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsTeleportedModified));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _isDataCastingDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelayModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public StaffOTeleportation(string newRawcode): base(1953319233, newRawcode)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _isDataNumberOfUnitsTeleportedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsTeleportedModified));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _isDataCastingDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelayModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public StaffOTeleportation(ObjectDatabaseBase db): base(1953319233, db)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _isDataNumberOfUnitsTeleportedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsTeleportedModified));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _isDataCastingDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelayModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public StaffOTeleportation(int newId, ObjectDatabaseBase db): base(1953319233, newId, db)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _isDataNumberOfUnitsTeleportedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsTeleportedModified));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _isDataCastingDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelayModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public StaffOTeleportation(string newRawcode, ObjectDatabaseBase db): base(1953319233, newRawcode, db)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _isDataNumberOfUnitsTeleportedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsTeleportedModified));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _isDataCastingDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCastingDelayModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ObjectProperty<int> DataNumberOfUnitsTeleported => _dataNumberOfUnitsTeleported.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfUnitsTeleportedModified => _isDataNumberOfUnitsTeleportedModified.Value;
        public ObjectProperty<float> DataCastingDelay => _dataCastingDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataCastingDelayModified => _isDataCastingDelayModified.Value;
        public ObjectProperty<int> DataUseTeleportClusteringRaw => _dataUseTeleportClusteringRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUseTeleportClusteringModified => _isDataUseTeleportClusteringModified.Value;
        public ObjectProperty<bool> DataUseTeleportClustering => _dataUseTeleportClustering.Value;
        private int GetDataNumberOfUnitsTeleported(int level)
        {
            return _modifications.GetModification(829713736, level).ValueAsInt;
        }

        private void SetDataNumberOfUnitsTeleported(int level, int value)
        {
            _modifications[829713736, level] = new LevelObjectDataModification{Id = 829713736, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfUnitsTeleportedModified(int level)
        {
            return _modifications.ContainsKey(829713736, level);
        }

        private float GetDataCastingDelay(int level)
        {
            return _modifications.GetModification(846490952, level).ValueAsFloat;
        }

        private void SetDataCastingDelay(int level, float value)
        {
            _modifications[846490952, level] = new LevelObjectDataModification{Id = 846490952, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataCastingDelayModified(int level)
        {
            return _modifications.ContainsKey(846490952, level);
        }

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
    }
}