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
    public sealed class ItemCommand : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumCreepLevel;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumCreepLevelModified;
        public ItemCommand(): base(1868777793)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public ItemCommand(int newId): base(1868777793, newId)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public ItemCommand(string newRawcode): base(1868777793, newRawcode)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public ItemCommand(ObjectDatabaseBase db): base(1868777793, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public ItemCommand(int newId, ObjectDatabaseBase db): base(1868777793, newId, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public ItemCommand(string newRawcode, ObjectDatabaseBase db): base(1868777793, newRawcode, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public ObjectProperty<int> DataMaximumCreepLevel => _dataMaximumCreepLevel.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumCreepLevelModified => _isDataMaximumCreepLevelModified.Value;
        private int GetDataMaximumCreepLevel(int level)
        {
            return _modifications.GetModification(1701995337, level).ValueAsInt;
        }

        private void SetDataMaximumCreepLevel(int level, int value)
        {
            _modifications[1701995337, level] = new LevelObjectDataModification{Id = 1701995337, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaximumCreepLevelModified(int level)
        {
            return _modifications.ContainsKey(1701995337, level);
        }
    }
}