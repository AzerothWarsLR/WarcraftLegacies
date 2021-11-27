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
    public sealed class ChaosKodo : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataNewUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNewUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataNewUnitType;
        public ChaosKodo(): base(878797651)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public ChaosKodo(int newId): base(878797651, newId)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public ChaosKodo(string newRawcode): base(878797651, newRawcode)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public ChaosKodo(ObjectDatabaseBase db): base(878797651, db)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public ChaosKodo(int newId, ObjectDatabaseBase db): base(878797651, newId, db)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public ChaosKodo(string newRawcode, ObjectDatabaseBase db): base(878797651, newRawcode, db)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public ObjectProperty<string> DataNewUnitTypeRaw => _dataNewUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataNewUnitTypeModified => _isDataNewUnitTypeModified.Value;
        public ObjectProperty<Unit> DataNewUnitType => _dataNewUnitType.Value;
        private string GetDataNewUnitTypeRaw(int level)
        {
            return _modifications.GetModification(828467267, level).ValueAsString;
        }

        private void SetDataNewUnitTypeRaw(int level, string value)
        {
            _modifications[828467267, level] = new LevelObjectDataModification{Id = 828467267, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataNewUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(828467267, level);
        }

        private Unit GetDataNewUnitType(int level)
        {
            return GetDataNewUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataNewUnitType(int level, Unit value)
        {
            SetDataNewUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}