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
    public sealed class ForceOfNatureCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfSummonedUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfSummonedUnitsModified;
        private readonly Lazy<ObjectProperty<string>> _dataSummonedUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataSummonedUnitType;
        public ForceOfNatureCreep(): base(1919304513)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public ForceOfNatureCreep(int newId): base(1919304513, newId)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public ForceOfNatureCreep(string newRawcode): base(1919304513, newRawcode)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public ForceOfNatureCreep(ObjectDatabaseBase db): base(1919304513, db)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public ForceOfNatureCreep(int newId, ObjectDatabaseBase db): base(1919304513, newId, db)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public ForceOfNatureCreep(string newRawcode, ObjectDatabaseBase db): base(1919304513, newRawcode, db)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public ObjectProperty<int> DataNumberOfSummonedUnits => _dataNumberOfSummonedUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfSummonedUnitsModified => _isDataNumberOfSummonedUnitsModified.Value;
        public ObjectProperty<string> DataSummonedUnitTypeRaw => _dataSummonedUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedUnitTypeModified => _isDataSummonedUnitTypeModified.Value;
        public ObjectProperty<Unit> DataSummonedUnitType => _dataSummonedUnitType.Value;
        private int GetDataNumberOfSummonedUnits(int level)
        {
            return _modifications.GetModification(829318725, level).ValueAsInt;
        }

        private void SetDataNumberOfSummonedUnits(int level, int value)
        {
            _modifications[829318725, level] = new LevelObjectDataModification{Id = 829318725, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfSummonedUnitsModified(int level)
        {
            return _modifications.ContainsKey(829318725, level);
        }

        private string GetDataSummonedUnitTypeRaw(int level)
        {
            return _modifications.GetModification(1970169413, level).ValueAsString;
        }

        private void SetDataSummonedUnitTypeRaw(int level, string value)
        {
            _modifications[1970169413, level] = new LevelObjectDataModification{Id = 1970169413, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataSummonedUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(1970169413, level);
        }

        private Unit GetDataSummonedUnitType(int level)
        {
            return GetDataSummonedUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataSummonedUnitType(int level, Unit value)
        {
            SetDataSummonedUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}