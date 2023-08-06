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
    public sealed class Harvest : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDamageToTree;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageToTreeModified;
        private readonly Lazy<ObjectProperty<int>> _dataLumberCapacity;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLumberCapacityModified;
        private readonly Lazy<ObjectProperty<int>> _dataGoldCapacity;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGoldCapacityModified;
        public Harvest(): base(1918986305)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
            _isDataGoldCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCapacityModified));
        }

        public Harvest(int newId): base(1918986305, newId)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
            _isDataGoldCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCapacityModified));
        }

        public Harvest(string newRawcode): base(1918986305, newRawcode)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
            _isDataGoldCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCapacityModified));
        }

        public Harvest(ObjectDatabaseBase db): base(1918986305, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
            _isDataGoldCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCapacityModified));
        }

        public Harvest(int newId, ObjectDatabaseBase db): base(1918986305, newId, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
            _isDataGoldCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCapacityModified));
        }

        public Harvest(string newRawcode, ObjectDatabaseBase db): base(1918986305, newRawcode, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _isDataDamageToTreeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToTreeModified));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _isDataLumberCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCapacityModified));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
            _isDataGoldCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCapacityModified));
        }

        public ObjectProperty<int> DataDamageToTree => _dataDamageToTree.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageToTreeModified => _isDataDamageToTreeModified.Value;
        public ObjectProperty<int> DataLumberCapacity => _dataLumberCapacity.Value;
        public ReadOnlyObjectProperty<bool> IsDataLumberCapacityModified => _isDataLumberCapacityModified.Value;
        public ObjectProperty<int> DataGoldCapacity => _dataGoldCapacity.Value;
        public ReadOnlyObjectProperty<bool> IsDataGoldCapacityModified => _isDataGoldCapacityModified.Value;
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

        private int GetDataGoldCapacity(int level)
        {
            return _modifications.GetModification(863134024, level).ValueAsInt;
        }

        private void SetDataGoldCapacity(int level, int value)
        {
            _modifications[863134024, level] = new LevelObjectDataModification{Id = 863134024, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataGoldCapacityModified(int level)
        {
            return _modifications.ContainsKey(863134024, level);
        }
    }
}