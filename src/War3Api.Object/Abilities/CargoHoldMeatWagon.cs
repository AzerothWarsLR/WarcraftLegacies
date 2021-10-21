using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CargoHoldMeatWagon : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataCargoCapacity;
        public CargoHoldMeatWagon(): base(845701971)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldMeatWagon(int newId): base(845701971, newId)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldMeatWagon(string newRawcode): base(845701971, newRawcode)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldMeatWagon(ObjectDatabase db): base(845701971, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldMeatWagon(int newId, ObjectDatabase db): base(845701971, newId, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
        }

        public CargoHoldMeatWagon(string newRawcode, ObjectDatabase db): base(845701971, newRawcode, db)
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