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
    public sealed class LoadEntangledGoldMine : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataAllowedUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAllowedUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataAllowedUnitType;
        public LoadEntangledGoldMine(): base(846163027)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
        }

        public LoadEntangledGoldMine(int newId): base(846163027, newId)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
        }

        public LoadEntangledGoldMine(string newRawcode): base(846163027, newRawcode)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
        }

        public LoadEntangledGoldMine(ObjectDatabaseBase db): base(846163027, db)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
        }

        public LoadEntangledGoldMine(int newId, ObjectDatabaseBase db): base(846163027, newId, db)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
        }

        public LoadEntangledGoldMine(string newRawcode, ObjectDatabaseBase db): base(846163027, newRawcode, db)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
        }

        public ObjectProperty<string> DataAllowedUnitTypeRaw => _dataAllowedUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAllowedUnitTypeModified => _isDataAllowedUnitTypeModified.Value;
        public ObjectProperty<Unit> DataAllowedUnitType => _dataAllowedUnitType.Value;
        private string GetDataAllowedUnitTypeRaw(int level)
        {
            return _modifications.GetModification(828469068, level).ValueAsString;
        }

        private void SetDataAllowedUnitTypeRaw(int level, string value)
        {
            _modifications[828469068, level] = new LevelObjectDataModification{Id = 828469068, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataAllowedUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(828469068, level);
        }

        private Unit GetDataAllowedUnitType(int level)
        {
            return GetDataAllowedUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataAllowedUnitType(int level, Unit value)
        {
            SetDataAllowedUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}