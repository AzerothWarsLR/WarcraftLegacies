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
    public sealed class PaladinDivineShield : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataCanDeactivateRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCanDeactivateModified;
        private readonly Lazy<ObjectProperty<bool>> _dataCanDeactivate;
        public PaladinDivineShield(): base(1935951937)
        {
            _dataCanDeactivateRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDeactivateRaw, SetDataCanDeactivateRaw));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
        }

        public PaladinDivineShield(int newId): base(1935951937, newId)
        {
            _dataCanDeactivateRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDeactivateRaw, SetDataCanDeactivateRaw));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
        }

        public PaladinDivineShield(string newRawcode): base(1935951937, newRawcode)
        {
            _dataCanDeactivateRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDeactivateRaw, SetDataCanDeactivateRaw));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
        }

        public PaladinDivineShield(ObjectDatabaseBase db): base(1935951937, db)
        {
            _dataCanDeactivateRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDeactivateRaw, SetDataCanDeactivateRaw));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
        }

        public PaladinDivineShield(int newId, ObjectDatabaseBase db): base(1935951937, newId, db)
        {
            _dataCanDeactivateRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDeactivateRaw, SetDataCanDeactivateRaw));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
        }

        public PaladinDivineShield(string newRawcode, ObjectDatabaseBase db): base(1935951937, newRawcode, db)
        {
            _dataCanDeactivateRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDeactivateRaw, SetDataCanDeactivateRaw));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
        }

        public ObjectProperty<int> DataCanDeactivateRaw => _dataCanDeactivateRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataCanDeactivateModified => _isDataCanDeactivateModified.Value;
        public ObjectProperty<bool> DataCanDeactivate => _dataCanDeactivate.Value;
        private int GetDataCanDeactivateRaw(int level)
        {
            return _modifications.GetModification(829645896, level).ValueAsInt;
        }

        private void SetDataCanDeactivateRaw(int level, int value)
        {
            _modifications[829645896, level] = new LevelObjectDataModification{Id = 829645896, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataCanDeactivateModified(int level)
        {
            return _modifications.ContainsKey(829645896, level);
        }

        private bool GetDataCanDeactivate(int level)
        {
            return GetDataCanDeactivateRaw(level).ToBool(this);
        }

        private void SetDataCanDeactivate(int level, bool value)
        {
            SetDataCanDeactivateRaw(level, value.ToRaw(0, 1));
        }
    }
}