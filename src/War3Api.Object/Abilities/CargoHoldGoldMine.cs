using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CargoHoldGoldMine : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataCargoCapacity;
        public CargoHoldGoldMine(): base(1668179265)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldGoldMine(int newId): base(1668179265, newId)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldGoldMine(string newRawcode): base(1668179265, newRawcode)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldGoldMine(ObjectDatabase db): base(1668179265, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldGoldMine(int newId, ObjectDatabase db): base(1668179265, newId, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldGoldMine(string newRawcode, ObjectDatabase db): base(1668179265, newRawcode, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public ObjectProperty<int> DataCargoCapacity => _dataCargoCapacity.Value;
        private int GetDataCargoCapacity(int level)
        {
            return _modifications[829579587, level].ValueAsInt;
        }

        private void SetDataCargoCapacity(int level, int value)
        {
            _modifications[829579587, level] = new LevelObjectDataModification{Id = 829579587, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}