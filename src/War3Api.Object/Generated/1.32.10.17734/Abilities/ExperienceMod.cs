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
    public sealed class ExperienceMod : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataExperienceGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataExperienceGainedModified;
        public ExperienceMod(): base(1835354433)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
            _isDataExperienceGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExperienceGainedModified));
        }

        public ExperienceMod(int newId): base(1835354433, newId)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
            _isDataExperienceGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExperienceGainedModified));
        }

        public ExperienceMod(string newRawcode): base(1835354433, newRawcode)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
            _isDataExperienceGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExperienceGainedModified));
        }

        public ExperienceMod(ObjectDatabaseBase db): base(1835354433, db)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
            _isDataExperienceGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExperienceGainedModified));
        }

        public ExperienceMod(int newId, ObjectDatabaseBase db): base(1835354433, newId, db)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
            _isDataExperienceGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExperienceGainedModified));
        }

        public ExperienceMod(string newRawcode, ObjectDatabaseBase db): base(1835354433, newRawcode, db)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
            _isDataExperienceGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExperienceGainedModified));
        }

        public ObjectProperty<int> DataExperienceGained => _dataExperienceGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataExperienceGainedModified => _isDataExperienceGainedModified.Value;
        private int GetDataExperienceGained(int level)
        {
            return _modifications.GetModification(1735424073, level).ValueAsInt;
        }

        private void SetDataExperienceGained(int level, int value)
        {
            _modifications[1735424073, level] = new LevelObjectDataModification{Id = 1735424073, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataExperienceGainedModified(int level)
        {
            return _modifications.ContainsKey(1735424073, level);
        }
    }
}