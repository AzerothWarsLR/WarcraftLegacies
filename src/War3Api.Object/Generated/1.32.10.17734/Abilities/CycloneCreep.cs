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
    public sealed class CycloneCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataCanBeDispelledRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCanBeDispelledModified;
        private readonly Lazy<ObjectProperty<bool>> _dataCanBeDispelled;
        public CycloneCreep(): base(2036548417)
        {
            _dataCanBeDispelledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanBeDispelledRaw, SetDataCanBeDispelledRaw));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
        }

        public CycloneCreep(int newId): base(2036548417, newId)
        {
            _dataCanBeDispelledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanBeDispelledRaw, SetDataCanBeDispelledRaw));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
        }

        public CycloneCreep(string newRawcode): base(2036548417, newRawcode)
        {
            _dataCanBeDispelledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanBeDispelledRaw, SetDataCanBeDispelledRaw));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
        }

        public CycloneCreep(ObjectDatabaseBase db): base(2036548417, db)
        {
            _dataCanBeDispelledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanBeDispelledRaw, SetDataCanBeDispelledRaw));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
        }

        public CycloneCreep(int newId, ObjectDatabaseBase db): base(2036548417, newId, db)
        {
            _dataCanBeDispelledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanBeDispelledRaw, SetDataCanBeDispelledRaw));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
        }

        public CycloneCreep(string newRawcode, ObjectDatabaseBase db): base(2036548417, newRawcode, db)
        {
            _dataCanBeDispelledRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanBeDispelledRaw, SetDataCanBeDispelledRaw));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
        }

        public ObjectProperty<int> DataCanBeDispelledRaw => _dataCanBeDispelledRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataCanBeDispelledModified => _isDataCanBeDispelledModified.Value;
        public ObjectProperty<bool> DataCanBeDispelled => _dataCanBeDispelled.Value;
        private int GetDataCanBeDispelledRaw(int level)
        {
            return _modifications.GetModification(828602723, level).ValueAsInt;
        }

        private void SetDataCanBeDispelledRaw(int level, int value)
        {
            _modifications[828602723, level] = new LevelObjectDataModification{Id = 828602723, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataCanBeDispelledModified(int level)
        {
            return _modifications.ContainsKey(828602723, level);
        }

        private bool GetDataCanBeDispelled(int level)
        {
            return GetDataCanBeDispelledRaw(level).ToBool(this);
        }

        private void SetDataCanBeDispelled(int level, bool value)
        {
            SetDataCanBeDispelledRaw(level, value.ToRaw(null, null));
        }
    }
}