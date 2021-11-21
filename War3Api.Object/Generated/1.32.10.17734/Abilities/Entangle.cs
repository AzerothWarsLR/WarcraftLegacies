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
    public sealed class Entangle : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataResultingUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataResultingUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataResultingUnitType;
        public Entangle(): base(1953391937)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
        }

        public Entangle(int newId): base(1953391937, newId)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
        }

        public Entangle(string newRawcode): base(1953391937, newRawcode)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
        }

        public Entangle(ObjectDatabaseBase db): base(1953391937, db)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
        }

        public Entangle(int newId, ObjectDatabaseBase db): base(1953391937, newId, db)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
        }

        public Entangle(string newRawcode, ObjectDatabaseBase db): base(1953391937, newRawcode, db)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
        }

        public ObjectProperty<string> DataResultingUnitTypeRaw => _dataResultingUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataResultingUnitTypeModified => _isDataResultingUnitTypeModified.Value;
        public ObjectProperty<Unit> DataResultingUnitType => _dataResultingUnitType.Value;
        private string GetDataResultingUnitTypeRaw(int level)
        {
            return _modifications.GetModification(829714021, level).ValueAsString;
        }

        private void SetDataResultingUnitTypeRaw(int level, string value)
        {
            _modifications[829714021, level] = new LevelObjectDataModification{Id = 829714021, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataResultingUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(829714021, level);
        }

        private Unit GetDataResultingUnitType(int level)
        {
            return GetDataResultingUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataResultingUnitType(int level, Unit value)
        {
            SetDataResultingUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}