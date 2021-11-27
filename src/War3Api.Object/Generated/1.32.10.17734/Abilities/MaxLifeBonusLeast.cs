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
    public sealed class MaxLifeBonusLeast : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaxLifeGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxLifeGainedModified;
        public MaxLifeBonusLeast(): base(1718372673)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public MaxLifeBonusLeast(int newId): base(1718372673, newId)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public MaxLifeBonusLeast(string newRawcode): base(1718372673, newRawcode)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public MaxLifeBonusLeast(ObjectDatabaseBase db): base(1718372673, db)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public MaxLifeBonusLeast(int newId, ObjectDatabaseBase db): base(1718372673, newId, db)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public MaxLifeBonusLeast(string newRawcode, ObjectDatabaseBase db): base(1718372673, newRawcode, db)
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