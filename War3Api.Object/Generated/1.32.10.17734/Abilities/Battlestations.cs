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
    public sealed class Battlestations : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataAllowedUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAllowedUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataAllowedUnitType;
        private readonly Lazy<ObjectProperty<int>> _dataSummonBusyUnitsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonBusyUnitsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataSummonBusyUnits;
        public Battlestations(): base(1819566657)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnitsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonBusyUnitsRaw, SetDataSummonBusyUnitsRaw));
            _isDataSummonBusyUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonBusyUnitsModified));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public Battlestations(int newId): base(1819566657, newId)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnitsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonBusyUnitsRaw, SetDataSummonBusyUnitsRaw));
            _isDataSummonBusyUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonBusyUnitsModified));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public Battlestations(string newRawcode): base(1819566657, newRawcode)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnitsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonBusyUnitsRaw, SetDataSummonBusyUnitsRaw));
            _isDataSummonBusyUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonBusyUnitsModified));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public Battlestations(ObjectDatabaseBase db): base(1819566657, db)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnitsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonBusyUnitsRaw, SetDataSummonBusyUnitsRaw));
            _isDataSummonBusyUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonBusyUnitsModified));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public Battlestations(int newId, ObjectDatabaseBase db): base(1819566657, newId, db)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnitsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonBusyUnitsRaw, SetDataSummonBusyUnitsRaw));
            _isDataSummonBusyUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonBusyUnitsModified));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public Battlestations(string newRawcode, ObjectDatabaseBase db): base(1819566657, newRawcode, db)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _isDataAllowedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowedUnitTypeModified));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnitsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonBusyUnitsRaw, SetDataSummonBusyUnitsRaw));
            _isDataSummonBusyUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonBusyUnitsModified));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public ObjectProperty<string> DataAllowedUnitTypeRaw => _dataAllowedUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAllowedUnitTypeModified => _isDataAllowedUnitTypeModified.Value;
        public ObjectProperty<Unit> DataAllowedUnitType => _dataAllowedUnitType.Value;
        public ObjectProperty<int> DataSummonBusyUnitsRaw => _dataSummonBusyUnitsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonBusyUnitsModified => _isDataSummonBusyUnitsModified.Value;
        public ObjectProperty<bool> DataSummonBusyUnits => _dataSummonBusyUnits.Value;
        private string GetDataAllowedUnitTypeRaw(int level)
        {
            return _modifications.GetModification(829191234, level).ValueAsString;
        }

        private void SetDataAllowedUnitTypeRaw(int level, string value)
        {
            _modifications[829191234, level] = new LevelObjectDataModification{Id = 829191234, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataAllowedUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(829191234, level);
        }

        private Unit GetDataAllowedUnitType(int level)
        {
            return GetDataAllowedUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataAllowedUnitType(int level, Unit value)
        {
            SetDataAllowedUnitTypeRaw(level, value.ToRaw(null, null));
        }

        private int GetDataSummonBusyUnitsRaw(int level)
        {
            return _modifications.GetModification(845968450, level).ValueAsInt;
        }

        private void SetDataSummonBusyUnitsRaw(int level, int value)
        {
            _modifications[845968450, level] = new LevelObjectDataModification{Id = 845968450, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataSummonBusyUnitsModified(int level)
        {
            return _modifications.ContainsKey(845968450, level);
        }

        private bool GetDataSummonBusyUnits(int level)
        {
            return GetDataSummonBusyUnitsRaw(level).ToBool(this);
        }

        private void SetDataSummonBusyUnits(int level, bool value)
        {
            SetDataSummonBusyUnitsRaw(level, value.ToRaw(0, 1));
        }
    }
}