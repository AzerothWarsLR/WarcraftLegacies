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
    public sealed class HealingWardCreep : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataWardUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataWardUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataWardUnitType;
        public HealingWardCreep(): base(2003321665)
        {
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public HealingWardCreep(int newId): base(2003321665, newId)
        {
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public HealingWardCreep(string newRawcode): base(2003321665, newRawcode)
        {
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public HealingWardCreep(ObjectDatabaseBase db): base(2003321665, db)
        {
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public HealingWardCreep(int newId, ObjectDatabaseBase db): base(2003321665, newId, db)
        {
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public HealingWardCreep(string newRawcode, ObjectDatabaseBase db): base(2003321665, newRawcode, db)
        {
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public ObjectProperty<string> DataWardUnitTypeRaw => _dataWardUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataWardUnitTypeModified => _isDataWardUnitTypeModified.Value;
        public ObjectProperty<Unit> DataWardUnitType => _dataWardUnitType.Value;
        private string GetDataWardUnitTypeRaw(int level)
        {
            return _modifications.GetModification(1969518440, level).ValueAsString;
        }

        private void SetDataWardUnitTypeRaw(int level, string value)
        {
            _modifications[1969518440, level] = new LevelObjectDataModification{Id = 1969518440, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataWardUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(1969518440, level);
        }

        private Unit GetDataWardUnitType(int level)
        {
            return GetDataWardUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataWardUnitType(int level, Unit value)
        {
            SetDataWardUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}