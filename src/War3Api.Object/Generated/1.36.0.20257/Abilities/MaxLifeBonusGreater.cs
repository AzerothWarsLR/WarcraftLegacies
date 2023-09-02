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
    public sealed class MaxLifeBonusGreater : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaxLifeGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxLifeGainedModified;
        public MaxLifeBonusGreater(): base(845957441)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public MaxLifeBonusGreater(int newId): base(845957441, newId)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public MaxLifeBonusGreater(string newRawcode): base(845957441, newRawcode)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public MaxLifeBonusGreater(ObjectDatabaseBase db): base(845957441, db)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public MaxLifeBonusGreater(int newId, ObjectDatabaseBase db): base(845957441, newId, db)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public MaxLifeBonusGreater(string newRawcode, ObjectDatabaseBase db): base(845957441, newRawcode, db)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public ObjectProperty<int> DataMaxLifeGained => _dataMaxLifeGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxLifeGainedModified => _isDataMaxLifeGainedModified.Value;
        private int GetDataMaxLifeGained(int level)
        {
            return _modifications.GetModification(1718185033, level).ValueAsInt;
        }

        private void SetDataMaxLifeGained(int level, int value)
        {
            _modifications[1718185033, level] = new LevelObjectDataModification{Id = 1718185033, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaxLifeGainedModified(int level)
        {
            return _modifications.ContainsKey(1718185033, level);
        }
    }
}