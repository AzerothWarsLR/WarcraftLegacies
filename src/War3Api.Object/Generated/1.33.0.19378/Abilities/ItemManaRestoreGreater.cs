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
    public sealed class ItemManaRestoreGreater : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataManaPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaPointsGainedModified;
        public ItemManaRestoreGreater(): base(846022977)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ItemManaRestoreGreater(int newId): base(846022977, newId)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ItemManaRestoreGreater(string newRawcode): base(846022977, newRawcode)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ItemManaRestoreGreater(ObjectDatabaseBase db): base(846022977, db)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ItemManaRestoreGreater(int newId, ObjectDatabaseBase db): base(846022977, newId, db)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ItemManaRestoreGreater(string newRawcode, ObjectDatabaseBase db): base(846022977, newRawcode, db)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ObjectProperty<int> DataManaPointsGained => _dataManaPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaPointsGainedModified => _isDataManaPointsGainedModified.Value;
        private int GetDataManaPointsGained(int level)
        {
            return _modifications.GetModification(1735421257, level).ValueAsInt;
        }

        private void SetDataManaPointsGained(int level, int value)
        {
            _modifications[1735421257, level] = new LevelObjectDataModification{Id = 1735421257, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataManaPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(1735421257, level);
        }
    }
}