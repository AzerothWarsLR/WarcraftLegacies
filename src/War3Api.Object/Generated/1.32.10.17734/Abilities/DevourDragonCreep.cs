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
    public sealed class DevourDragonCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaxCreepLevel;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxCreepLevelModified;
        public DevourDragonCreep(): base(1986282305)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
        }

        public DevourDragonCreep(int newId): base(1986282305, newId)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
        }

        public DevourDragonCreep(string newRawcode): base(1986282305, newRawcode)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
        }

        public DevourDragonCreep(ObjectDatabaseBase db): base(1986282305, db)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
        }

        public DevourDragonCreep(int newId, ObjectDatabaseBase db): base(1986282305, newId, db)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
        }

        public DevourDragonCreep(string newRawcode, ObjectDatabaseBase db): base(1986282305, newRawcode, db)
        {
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
        }

        public ObjectProperty<int> DataMaxCreepLevel => _dataMaxCreepLevel.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxCreepLevelModified => _isDataMaxCreepLevelModified.Value;
        private int GetDataMaxCreepLevel(int level)
        {
            return _modifications.GetModification(829842756, level).ValueAsInt;
        }

        private void SetDataMaxCreepLevel(int level, int value)
        {
            _modifications[829842756, level] = new LevelObjectDataModification{Id = 829842756, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaxCreepLevelModified(int level)
        {
            return _modifications.ContainsKey(829842756, level);
        }
    }
}