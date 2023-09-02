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
    public sealed class AttackTargetPriority : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataInitiallyEnabledRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInitiallyEnabledModified;
        private readonly Lazy<ObjectProperty<bool>> _dataInitiallyEnabled;
        public AttackTargetPriority(): base(1886675265)
        {
            _dataInitiallyEnabledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInitiallyEnabledRaw, SetDataInitiallyEnabledRaw));
            _isDataInitiallyEnabledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitiallyEnabledModified));
            _dataInitiallyEnabled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInitiallyEnabled, SetDataInitiallyEnabled));
        }

        public AttackTargetPriority(int newId): base(1886675265, newId)
        {
            _dataInitiallyEnabledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInitiallyEnabledRaw, SetDataInitiallyEnabledRaw));
            _isDataInitiallyEnabledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitiallyEnabledModified));
            _dataInitiallyEnabled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInitiallyEnabled, SetDataInitiallyEnabled));
        }

        public AttackTargetPriority(string newRawcode): base(1886675265, newRawcode)
        {
            _dataInitiallyEnabledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInitiallyEnabledRaw, SetDataInitiallyEnabledRaw));
            _isDataInitiallyEnabledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitiallyEnabledModified));
            _dataInitiallyEnabled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInitiallyEnabled, SetDataInitiallyEnabled));
        }

        public AttackTargetPriority(ObjectDatabaseBase db): base(1886675265, db)
        {
            _dataInitiallyEnabledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInitiallyEnabledRaw, SetDataInitiallyEnabledRaw));
            _isDataInitiallyEnabledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitiallyEnabledModified));
            _dataInitiallyEnabled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInitiallyEnabled, SetDataInitiallyEnabled));
        }

        public AttackTargetPriority(int newId, ObjectDatabaseBase db): base(1886675265, newId, db)
        {
            _dataInitiallyEnabledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInitiallyEnabledRaw, SetDataInitiallyEnabledRaw));
            _isDataInitiallyEnabledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitiallyEnabledModified));
            _dataInitiallyEnabled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInitiallyEnabled, SetDataInitiallyEnabled));
        }

        public AttackTargetPriority(string newRawcode, ObjectDatabaseBase db): base(1886675265, newRawcode, db)
        {
            _dataInitiallyEnabledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInitiallyEnabledRaw, SetDataInitiallyEnabledRaw));
            _isDataInitiallyEnabledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitiallyEnabledModified));
            _dataInitiallyEnabled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInitiallyEnabled, SetDataInitiallyEnabled));
        }

        public ObjectProperty<int> DataInitiallyEnabledRaw => _dataInitiallyEnabledRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataInitiallyEnabledModified => _isDataInitiallyEnabledModified.Value;
        public ObjectProperty<bool> DataInitiallyEnabled => _dataInitiallyEnabled.Value;
        private int GetDataInitiallyEnabledRaw(int level)
        {
            return _modifications.GetModification(829710657, level).ValueAsInt;
        }

        private void SetDataInitiallyEnabledRaw(int level, int value)
        {
            _modifications[829710657, level] = new LevelObjectDataModification{Id = 829710657, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataInitiallyEnabledModified(int level)
        {
            return _modifications.ContainsKey(829710657, level);
        }

        private bool GetDataInitiallyEnabled(int level)
        {
            return GetDataInitiallyEnabledRaw(level).ToBool(this);
        }

        private void SetDataInitiallyEnabled(int level, bool value)
        {
            SetDataInitiallyEnabledRaw(level, value.ToRaw(0, 1));
        }
    }
}