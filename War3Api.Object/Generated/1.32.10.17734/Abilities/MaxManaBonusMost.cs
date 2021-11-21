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
    public sealed class MaxManaBonusMost : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaxManaGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxManaGainedModified;
        public MaxManaBonusMost(): base(1835157825)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
            _isDataMaxManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaGainedModified));
        }

        public MaxManaBonusMost(int newId): base(1835157825, newId)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
            _isDataMaxManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaGainedModified));
        }

        public MaxManaBonusMost(string newRawcode): base(1835157825, newRawcode)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
            _isDataMaxManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaGainedModified));
        }

        public MaxManaBonusMost(ObjectDatabaseBase db): base(1835157825, db)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
            _isDataMaxManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaGainedModified));
        }

        public MaxManaBonusMost(int newId, ObjectDatabaseBase db): base(1835157825, newId, db)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
            _isDataMaxManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaGainedModified));
        }

        public MaxManaBonusMost(string newRawcode, ObjectDatabaseBase db): base(1835157825, newRawcode, db)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
            _isDataMaxManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaGainedModified));
        }

        public ObjectProperty<int> DataMaxManaGained => _dataMaxManaGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxManaGainedModified => _isDataMaxManaGainedModified.Value;
        private int GetDataMaxManaGained(int level)
        {
            return _modifications.GetModification(1851878729, level).ValueAsInt;
        }

        private void SetDataMaxManaGained(int level, int value)
        {
            _modifications[1851878729, level] = new LevelObjectDataModification{Id = 1851878729, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaxManaGainedModified(int level)
        {
            return _modifications.ContainsKey(1851878729, level);
        }
    }
}