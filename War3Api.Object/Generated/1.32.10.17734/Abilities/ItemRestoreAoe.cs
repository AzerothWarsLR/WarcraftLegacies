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
    public sealed class ItemRestoreAoe : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsRestored;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsRestoredModified;
        private readonly Lazy<ObjectProperty<int>> _dataManaPointsRestored;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaPointsRestoredModified;
        public ItemRestoreAoe(): base(1634879809)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _isDataHitPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRestoredModified));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
            _isDataManaPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsRestoredModified));
        }

        public ItemRestoreAoe(int newId): base(1634879809, newId)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _isDataHitPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRestoredModified));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
            _isDataManaPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsRestoredModified));
        }

        public ItemRestoreAoe(string newRawcode): base(1634879809, newRawcode)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _isDataHitPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRestoredModified));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
            _isDataManaPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsRestoredModified));
        }

        public ItemRestoreAoe(ObjectDatabaseBase db): base(1634879809, db)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _isDataHitPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRestoredModified));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
            _isDataManaPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsRestoredModified));
        }

        public ItemRestoreAoe(int newId, ObjectDatabaseBase db): base(1634879809, newId, db)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _isDataHitPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRestoredModified));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
            _isDataManaPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsRestoredModified));
        }

        public ItemRestoreAoe(string newRawcode, ObjectDatabaseBase db): base(1634879809, newRawcode, db)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _isDataHitPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRestoredModified));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
            _isDataManaPointsRestoredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsRestoredModified));
        }

        public ObjectProperty<int> DataHitPointsRestored => _dataHitPointsRestored.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointsRestoredModified => _isDataHitPointsRestoredModified.Value;
        public ObjectProperty<int> DataManaPointsRestored => _dataManaPointsRestored.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaPointsRestoredModified => _isDataManaPointsRestoredModified.Value;
        private int GetDataHitPointsRestored(int level)
        {
            return _modifications.GetModification(1936746569, level).ValueAsInt;
        }

        private void SetDataHitPointsRestored(int level, int value)
        {
            _modifications[1936746569, level] = new LevelObjectDataModification{Id = 1936746569, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataHitPointsRestoredModified(int level)
        {
            return _modifications.ContainsKey(1936746569, level);
        }

        private int GetDataManaPointsRestored(int level)
        {
            return _modifications.GetModification(1936747849, level).ValueAsInt;
        }

        private void SetDataManaPointsRestored(int level, int value)
        {
            _modifications[1936747849, level] = new LevelObjectDataModification{Id = 1936747849, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataManaPointsRestoredModified(int level)
        {
            return _modifications.ContainsKey(1936747849, level);
        }
    }
}