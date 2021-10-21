using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CargoHoldBurrow : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataCargoCapacity;
        public CargoHoldBurrow(): base(1853186625)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldBurrow(int newId): base(1853186625, newId)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldBurrow(string newRawcode): base(1853186625, newRawcode)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldBurrow(ObjectDatabase db): base(1853186625, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldBurrow(int newId, ObjectDatabase db): base(1853186625, newId, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldBurrow(string newRawcode, ObjectDatabase db): base(1853186625, newRawcode, db)
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