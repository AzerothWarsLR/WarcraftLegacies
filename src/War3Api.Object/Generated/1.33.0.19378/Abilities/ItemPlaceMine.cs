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
    public sealed class ItemPlaceMine : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataUnitType;
        public ItemPlaceMine(): base(1836075329)
        {
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _isDataUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeModified));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public ItemPlaceMine(int newId): base(1836075329, newId)
        {
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _isDataUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeModified));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public ItemPlaceMine(string newRawcode): base(1836075329, newRawcode)
        {
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _isDataUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeModified));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public ItemPlaceMine(ObjectDatabaseBase db): base(1836075329, db)
        {
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _isDataUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeModified));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public ItemPlaceMine(int newId, ObjectDatabaseBase db): base(1836075329, newId, db)
        {
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _isDataUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeModified));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public ItemPlaceMine(string newRawcode, ObjectDatabaseBase db): base(1836075329, newRawcode, db)
        {
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _isDataUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeModified));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public ObjectProperty<string> DataUnitTypeRaw => _dataUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitTypeModified => _isDataUnitTypeModified.Value;
        public ObjectProperty<Unit> DataUnitType => _dataUnitType.Value;
        private string GetDataUnitTypeRaw(int level)
        {
            return _modifications.GetModification(1970106473, level).ValueAsString;
        }

        private void SetDataUnitTypeRaw(int level, string value)
        {
            _modifications[1970106473, level] = new LevelObjectDataModification{Id = 1970106473, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(1970106473, level);
        }

        private Unit GetDataUnitType(int level)
        {
            return GetDataUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataUnitType(int level, Unit value)
        {
            SetDataUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}