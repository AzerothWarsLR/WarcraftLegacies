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
    public sealed class SpiderAttack : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataSpiderCapacity;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSpiderCapacityModified;
        public SpiderAttack(): base(1634759489)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
            _isDataSpiderCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpiderCapacityModified));
        }

        public SpiderAttack(int newId): base(1634759489, newId)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
            _isDataSpiderCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpiderCapacityModified));
        }

        public SpiderAttack(string newRawcode): base(1634759489, newRawcode)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
            _isDataSpiderCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpiderCapacityModified));
        }

        public SpiderAttack(ObjectDatabaseBase db): base(1634759489, db)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
            _isDataSpiderCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpiderCapacityModified));
        }

        public SpiderAttack(int newId, ObjectDatabaseBase db): base(1634759489, newId, db)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
            _isDataSpiderCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpiderCapacityModified));
        }

        public SpiderAttack(string newRawcode, ObjectDatabaseBase db): base(1634759489, newRawcode, db)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
            _isDataSpiderCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpiderCapacityModified));
        }

        public ObjectProperty<int> DataSpiderCapacity => _dataSpiderCapacity.Value;
        public ReadOnlyObjectProperty<bool> IsDataSpiderCapacityModified => _isDataSpiderCapacityModified.Value;
        private int GetDataSpiderCapacity(int level)
        {
            return _modifications.GetModification(828469331, level).ValueAsInt;
        }

        private void SetDataSpiderCapacity(int level, int value)
        {
            _modifications[828469331, level] = new LevelObjectDataModification{Id = 828469331, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataSpiderCapacityModified(int level)
        {
            return _modifications.ContainsKey(828469331, level);
        }
    }
}