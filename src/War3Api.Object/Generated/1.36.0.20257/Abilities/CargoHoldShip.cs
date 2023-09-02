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
    public sealed class CargoHoldShip : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataCargoCapacity;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCargoCapacityModified;
        public CargoHoldShip(): base(896033619)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public CargoHoldShip(int newId): base(896033619, newId)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public CargoHoldShip(string newRawcode): base(896033619, newRawcode)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public CargoHoldShip(ObjectDatabaseBase db): base(896033619, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public CargoHoldShip(int newId, ObjectDatabaseBase db): base(896033619, newId, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
        }

        public CargoHoldShip(string newRawcode, ObjectDatabaseBase db): base(896033619, newRawcode, db)
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