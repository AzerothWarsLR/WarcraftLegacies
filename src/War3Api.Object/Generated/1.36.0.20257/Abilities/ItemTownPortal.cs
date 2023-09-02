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
    public sealed class ItemTownPortal : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumNumberOfUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumNumberOfUnitsModified;
        private readonly Lazy<ObjectProperty<int>> _dataUseTeleportClusteringRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUseTeleportClusteringModified;
        private readonly Lazy<ObjectProperty<bool>> _dataUseTeleportClustering;
        public ItemTownPortal(): base(1886669121)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ItemTownPortal(int newId): base(1886669121, newId)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ItemTownPortal(string newRawcode): base(1886669121, newRawcode)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ItemTownPortal(ObjectDatabaseBase db): base(1886669121, db)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ItemTownPortal(int newId, ObjectDatabaseBase db): base(1886669121, newId, db)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ItemTownPortal(string newRawcode, ObjectDatabaseBase db): base(1886669121, newRawcode, db)
        {
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
            _isDataMaximumNumberOfUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfUnitsModified));
            _dataUseTeleportClusteringRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUseTeleportClusteringRaw, SetDataUseTeleportClusteringRaw));
            _isDataUseTeleportClusteringModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUseTeleportClusteringModified));
            _dataUseTeleportClustering = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataUseTeleportClustering, SetDataUseTeleportClustering));
        }

        public ObjectProperty<int> DataMaximumNumberOfUnits => _dataMaximumNumberOfUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumNumberOfUnitsModified => _isDataMaximumNumberOfUnitsModified.Value;
        public ObjectProperty<int> DataUseTeleportClusteringRaw => _dataUseTeleportClusteringRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUseTeleportClusteringModified => _isDataUseTeleportClusteringModified.Value;
        public ObjectProperty<bool> DataUseTeleportClustering => _dataUseTeleportClustering.Value;
        private int GetDataMaximumNumberOfUnits(int level)
        {
            return _modifications.GetModification(1836086345, level).ValueAsInt;
        }

        private void SetDataMaximumNumberOfUnits(int level, int value)
        {
            _modifications[1836086345, level] = new LevelObjectDataModification{Id = 1836086345, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaximumNumberOfUnitsModified(int level)
        {
            return _modifications.ContainsKey(1836086345, level);
        }

        private int GetDataUseTeleportClusteringRaw(int level)
        {
            return _modifications.GetModification(846230601, level).ValueAsInt;
        }

        private void SetDataUseTeleportClusteringRaw(int level, int value)
        {
            _modifications[846230601, level] = new LevelObjectDataModification{Id = 846230601, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataUseTeleportClusteringModified(int level)
        {
            return _modifications.ContainsKey(846230601, level);
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