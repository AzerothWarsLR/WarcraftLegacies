using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ArchMageMassTeleport : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfUnitsTeleported;
        private readonly Lazy<ObjectProperty<float>> _dataCastingDelay;
        private readonly Lazy<ObjectProperty<bool>> _dataUseTeleportClustering;
        public ArchMageMassTeleport(): base(1953318977)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ArchMageMassTeleport(int newId): base(1953318977, newId)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ArchMageMassTeleport(string newRawcode): base(1953318977, newRawcode)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ArchMageMassTeleport(ObjectDatabase db): base(1953318977, db)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ArchMageMassTeleport(int newId, ObjectDatabase db): base(1953318977, newId, db)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ArchMageMassTeleport(string newRawcode, ObjectDatabase db): base(1953318977, newRawcode, db)
        {
            _dataNumberOfUnitsTeleported = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsTeleported, SetDataNumberOfUnitsTeleported));
            _dataCastingDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataCastingDelay, SetDataCastingDelay));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ObjectProperty<int> DataNumberOfUnitsTeleported => _dataNumberOfUnitsTeleported.Value;
        public ObjectProperty<float> DataCastingDelay => _dataCastingDelay.Value;
        public ObjectProperty<bool> DataUseTeleportClustering => _dataUseTeleportClustering.Value;
        private int GetDataNumberOfUnitsTeleported(int level)
        {
            return _modifications[829713736, level].ValueAsInt;
        }

        private void SetDataNumberOfUnitsTeleported(int level, int value)
        {
            _modifications[829713736, level] = new LevelObjectDataModification{Id = 829713736, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataCastingDelay(int level)
        {
            return _modifications[846490952, level].ValueAsFloat;
        }

        private void SetDataCastingDelay(int level, float value)
        {
            _modifications[846490952, level] = new LevelObjectDataModification{Id = 846490952, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetDataUseTeleportClustering(int level)
        {
            return _modifications[863268168, level].ValueAsBool;
        }

        private void SetDataUseTeleportClustering(int level, bool value)
        {
            _modifications[863268168, level] = new LevelObjectDataModification{Id = 863268168, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }
    }
}