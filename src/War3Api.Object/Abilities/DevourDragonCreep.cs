using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DevourDragonCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaxCreepLevel;
        public DevourDragonCreep(): base(1986282305)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
        }

        public DevourDragonCreep(int newId): base(1986282305, newId)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
        }

        public DevourDragonCreep(string newRawcode): base(1986282305, newRawcode)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
        }

        public DevourDragonCreep(ObjectDatabase db): base(1986282305, db)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
        }

        public DevourDragonCreep(int newId, ObjectDatabase db): base(1986282305, newId, db)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
        }

        public DevourDragonCreep(string newRawcode, ObjectDatabase db): base(1986282305, newRawcode, db)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
        }

        public ObjectProperty<int> DataMaxCreepLevel => _dataMaxCreepLevel.Value;
        private int GetDataMaxCreepLevel(int level)
        {
            return _modifications[829842756, level].ValueAsInt;
        }

        private void SetDataMaxCreepLevel(int level, int value)
        {
            _modifications[829842756, level] = new LevelObjectDataModification{Id = 829842756, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}