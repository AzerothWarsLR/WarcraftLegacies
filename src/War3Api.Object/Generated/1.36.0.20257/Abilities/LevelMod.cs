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
    public sealed class LevelMod : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataLevelsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLevelsGainedModified;
        public LevelMod(): base(1835813185)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
            _isDataLevelsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLevelsGainedModified));
        }

        public LevelMod(int newId): base(1835813185, newId)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
            _isDataLevelsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLevelsGainedModified));
        }

        public LevelMod(string newRawcode): base(1835813185, newRawcode)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
            _isDataLevelsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLevelsGainedModified));
        }

        public LevelMod(ObjectDatabaseBase db): base(1835813185, db)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
            _isDataLevelsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLevelsGainedModified));
        }

        public LevelMod(int newId, ObjectDatabaseBase db): base(1835813185, newId, db)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
            _isDataLevelsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLevelsGainedModified));
        }

        public LevelMod(string newRawcode, ObjectDatabaseBase db): base(1835813185, newRawcode, db)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
            _isDataLevelsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLevelsGainedModified));
        }

        public ObjectProperty<int> DataLevelsGained => _dataLevelsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataLevelsGainedModified => _isDataLevelsGainedModified.Value;
        private int GetDataLevelsGained(int level)
        {
            return _modifications.GetModification(1986358345, level).ValueAsInt;
        }

        private void SetDataLevelsGained(int level, int value)
        {
            _modifications[1986358345, level] = new LevelObjectDataModification{Id = 1986358345, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataLevelsGainedModified(int level)
        {
            return _modifications.ContainsKey(1986358345, level);
        }
    }
}