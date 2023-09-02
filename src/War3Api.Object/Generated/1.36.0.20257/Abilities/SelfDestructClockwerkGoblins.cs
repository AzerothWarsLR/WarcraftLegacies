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
    public sealed class SelfDestructClockwerkGoblins : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataExplodesOnDeathRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataExplodesOnDeathModified;
        private readonly Lazy<ObjectProperty<bool>> _dataExplodesOnDeath;
        public SelfDestructClockwerkGoblins(): base(1734636353)
        {
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestructClockwerkGoblins(int newId): base(1734636353, newId)
        {
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestructClockwerkGoblins(string newRawcode): base(1734636353, newRawcode)
        {
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestructClockwerkGoblins(ObjectDatabaseBase db): base(1734636353, db)
        {
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestructClockwerkGoblins(int newId, ObjectDatabaseBase db): base(1734636353, newId, db)
        {
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestructClockwerkGoblins(string newRawcode, ObjectDatabaseBase db): base(1734636353, newRawcode, db)
        {
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public ObjectProperty<int> DataExplodesOnDeathRaw => _dataExplodesOnDeathRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataExplodesOnDeathModified => _isDataExplodesOnDeathModified.Value;
        public ObjectProperty<bool> DataExplodesOnDeath => _dataExplodesOnDeath.Value;
        private int GetDataExplodesOnDeathRaw(int level)
        {
            return _modifications.GetModification(913531987, level).ValueAsInt;
        }

        private void SetDataExplodesOnDeathRaw(int level, int value)
        {
            _modifications[913531987, level] = new LevelObjectDataModification{Id = 913531987, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataExplodesOnDeathModified(int level)
        {
            return _modifications.ContainsKey(913531987, level);
        }

        private bool GetDataExplodesOnDeath(int level)
        {
            return GetDataExplodesOnDeathRaw(level).ToBool(this);
        }

        private void SetDataExplodesOnDeath(int level, bool value)
        {
            SetDataExplodesOnDeathRaw(level, value.ToRaw(0, 1));
        }
    }
}