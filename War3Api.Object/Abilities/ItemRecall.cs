using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemRecall : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumNumberOfUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumNumberOfUnitsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataUseTeleportClustering;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUseTeleportClusteringModified;
        public ItemRecall(): base(1953646913)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
        }

        public ItemRecall(int newId): base(1953646913, newId)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
        }

        public ItemRecall(string newRawcode): base(1953646913, newRawcode)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
        }

        public ItemRecall(ObjectDatabase db): base(1953646913, db)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
        }

        public ItemRecall(int newId, ObjectDatabase db): base(1953646913, newId, db)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
        }

        public ItemRecall(string newRawcode, ObjectDatabase db): base(1953646913, newRawcode, db)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
        }

        public ObjectProperty<int> DataMaximumNumberOfUnits => _dataMaximumNumberOfUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumNumberOfUnitsModified => _isDataMaximumNumberOfUnitsModified.Value;
        public ObjectProperty<bool> DataUseTeleportClustering => _dataUseTeleportClustering.Value;
        public ReadOnlyObjectProperty<bool> IsDataUseTeleportClusteringModified => _isDataUseTeleportClusteringModified.Value;
        private int GetDataMaximumNumberOfUnits(int level)
        {
            return _modifications[1667592777, level].ValueAsInt;
        }

        private void SetDataMaximumNumberOfUnits(int level, int value)
        {
            _modifications[1667592777, level] = new LevelObjectDataModification{Id = 1667592777, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaximumNumberOfUnitsModified(int level)
        {
            return _modifications.ContainsKey(1667592777, level);
        }

        private bool GetDataUseTeleportClustering(int level)
        {
            return _modifications[846230601, level].ValueAsBool;
        }

        private void SetDataUseTeleportClustering(int level, bool value)
        {
            _modifications[846230601, level] = new LevelObjectDataModification{Id = 846230601, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataUseTeleportClusteringModified(int level)
        {
            return _modifications.ContainsKey(846230601, level);
        }
    }
}