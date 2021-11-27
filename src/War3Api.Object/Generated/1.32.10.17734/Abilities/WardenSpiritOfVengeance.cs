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
    public sealed class WardenSpiritOfVengeance : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfSummonedUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfSummonedUnitsModified;
        private readonly Lazy<ObjectProperty<string>> _dataSummonedUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataSummonedUnitType;
        public WardenSpiritOfVengeance(): base(1987265857)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public WardenSpiritOfVengeance(int newId): base(1987265857, newId)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public WardenSpiritOfVengeance(string newRawcode): base(1987265857, newRawcode)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public WardenSpiritOfVengeance(ObjectDatabaseBase db): base(1987265857, db)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public WardenSpiritOfVengeance(int newId, ObjectDatabaseBase db): base(1987265857, newId, db)
        {
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public WardenSpiritOfVengeance(string newRawcode, ObjectDatabaseBase db): base(1987265857, newRawcode, db)
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
            return _modifications.GetModification(829846341, level).ValueAsInt;
        }

        private void SetDataNumberOfSummonedUnits(int level, int value)
        {
            _modifications[829846341, level] = new LevelObjectDataModification{Id = 829846341, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfSummonedUnitsModified(int level)
        {
            return _modifications.ContainsKey(829846341, level);
        }

        private string GetDataSummonedUnitTypeRaw(int level)
        {
            return _modifications.GetModification(1970697029, level).ValueAsString;
        }

        private void SetDataSummonedUnitTypeRaw(int level, string value)
        {
            _modifications[1970697029, level] = new LevelObjectDataModification{Id = 1970697029, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataSummonedUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(1970697029, level);
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