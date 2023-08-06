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
    public sealed class CargoHoldGoldMine : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataCargoCapacity;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCargoCapacityModified;
        public CargoHoldGoldMine(): base(1668179265)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public CargoHoldGoldMine(int newId): base(1668179265, newId)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public CargoHoldGoldMine(string newRawcode): base(1668179265, newRawcode)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public CargoHoldGoldMine(ObjectDatabaseBase db): base(1668179265, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public CargoHoldGoldMine(int newId, ObjectDatabaseBase db): base(1668179265, newId, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public CargoHoldGoldMine(string newRawcode, ObjectDatabaseBase db): base(1668179265, newRawcode, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public ObjectProperty<int> DataCargoCapacity => _dataCargoCapacity.Value;
        public ReadOnlyObjectProperty<bool> IsDataCargoCapacityModified => _isDataCargoCapacityModified.Value;
        private int GetDataCargoCapacity(int level)
        {
            return _modifications.GetModification(829579587, level).ValueAsInt;
        }

        private void SetDataCargoCapacity(int level, int value)
        {
            _modifications[829579587, level] = new LevelObjectDataModification{Id = 829579587, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataCargoCapacityModified(int level)
        {
            return _modifications.ContainsKey(829579587, level);
        }
    }
}