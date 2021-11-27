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
    public sealed class TankUpgrade : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataNewUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNewUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataNewUnitType;
        public TankUpgrade(): base(1953788499)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public TankUpgrade(int newId): base(1953788499, newId)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public TankUpgrade(string newRawcode): base(1953788499, newRawcode)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public TankUpgrade(ObjectDatabaseBase db): base(1953788499, db)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public TankUpgrade(int newId, ObjectDatabaseBase db): base(1953788499, newId, db)
        {
            _dataNewUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNewUnitTypeRaw, SetDataNewUnitTypeRaw));
            _isDataNewUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewUnitTypeModified));
            _dataNewUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNewUnitType, SetDataNewUnitType));
        }

        public TankUpgrade(string newRawcode, ObjectDatabaseBase db): base(1953788499, newRawcode, db)
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