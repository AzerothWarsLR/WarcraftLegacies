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
    public sealed class HarvestLumberShredder : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDamageToTree;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageToTreeModified;
        private readonly Lazy<ObjectProperty<int>> _dataLumberCapacity;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLumberCapacityModified;
        public HarvestLumberShredder(): base(863135809)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
        }

        public HarvestLumberShredder(int newId): base(863135809, newId)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
        }

        public HarvestLumberShredder(string newRawcode): base(863135809, newRawcode)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
        }

        public HarvestLumberShredder(ObjectDatabaseBase db): base(863135809, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
        }

        public HarvestLumberShredder(int newId, ObjectDatabaseBase db): base(863135809, newId, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
        }

        public HarvestLumberShredder(string newRawcode, ObjectDatabaseBase db): base(863135809, newRawcode, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
        }

        public ObjectProperty<int> DataDamageToTree => _dataDamageToTree.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageToTreeModified => _isDataDamageToTreeModified.Value;
        public ObjectProperty<int> DataLumberCapacity => _dataLumberCapacity.Value;
        public ReadOnlyObjectProperty<bool> IsDataLumberCapacityModified => _isDataLumberCapacityModified.Value;
        private int GetDataDamageToTree(int level)
        {
            return _modifications.GetModification(829579592, level).ValueAsInt;
        }

        private void SetDataDamageToTree(int level, int value)
        {
            _modifications[829579592, level] = new LevelObjectDataModification{Id = 829579592, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageToTreeModified(int level)
        {
            return _modifications.ContainsKey(829579592, level);
        }

        private int GetDataLumberCapacity(int level)
        {
            return _modifications.GetModification(846356808, level).ValueAsInt;
        }

        private void SetDataLumberCapacity(int level, int value)
        {
            _modifications[846356808, level] = new LevelObjectDataModification{Id = 846356808, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLumberCapacityModified(int level)
        {
            return _modifications.ContainsKey(846356808, level);
        }
    }
}