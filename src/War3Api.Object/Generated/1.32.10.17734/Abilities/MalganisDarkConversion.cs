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
    public sealed class MalganisDarkConversion : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataRaceToConvertRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRaceToConvertModified;
        private readonly Lazy<ObjectProperty<UnitRace>> _dataRaceToConvert;
        private readonly Lazy<ObjectProperty<string>> _dataConversionUnitRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataConversionUnitModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataConversionUnit;
        public MalganisDarkConversion(): base(1667518017)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _isDataRaceToConvertModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaceToConvertModified));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _isDataConversionUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataConversionUnitModified));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public MalganisDarkConversion(int newId): base(1667518017, newId)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _isDataRaceToConvertModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaceToConvertModified));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _isDataConversionUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataConversionUnitModified));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public MalganisDarkConversion(string newRawcode): base(1667518017, newRawcode)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _isDataRaceToConvertModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaceToConvertModified));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _isDataConversionUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataConversionUnitModified));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public MalganisDarkConversion(ObjectDatabaseBase db): base(1667518017, db)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _isDataRaceToConvertModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaceToConvertModified));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _isDataConversionUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataConversionUnitModified));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public MalganisDarkConversion(int newId, ObjectDatabaseBase db): base(1667518017, newId, db)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _isDataRaceToConvertModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaceToConvertModified));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _isDataConversionUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataConversionUnitModified));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public MalganisDarkConversion(string newRawcode, ObjectDatabaseBase db): base(1667518017, newRawcode, db)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _isDataRaceToConvertModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaceToConvertModified));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _isDataConversionUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataConversionUnitModified));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public ObjectProperty<string> DataRaceToConvertRaw => _dataRaceToConvertRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataRaceToConvertModified => _isDataRaceToConvertModified.Value;
        public ObjectProperty<UnitRace> DataRaceToConvert => _dataRaceToConvert.Value;
        public ObjectProperty<string> DataConversionUnitRaw => _dataConversionUnitRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataConversionUnitModified => _isDataConversionUnitModified.Value;
        public ObjectProperty<Unit> DataConversionUnit => _dataConversionUnit.Value;
        private string GetDataRaceToConvertRaw(int level)
        {
            return _modifications.GetModification(828597326, level).ValueAsString;
        }

        private void SetDataRaceToConvertRaw(int level, string value)
        {
            _modifications[828597326, level] = new LevelObjectDataModification{Id = 828597326, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataRaceToConvertModified(int level)
        {
            return _modifications.ContainsKey(828597326, level);
        }

        private UnitRace GetDataRaceToConvert(int level)
        {
            return GetDataRaceToConvertRaw(level).ToUnitRace(this);
        }

        private void SetDataRaceToConvert(int level, UnitRace value)
        {
            SetDataRaceToConvertRaw(level, value.ToRaw(null, null));
        }

        private string GetDataConversionUnitRaw(int level)
        {
            return _modifications.GetModification(845374542, level).ValueAsString;
        }

        private void SetDataConversionUnitRaw(int level, string value)
        {
            _modifications[845374542, level] = new LevelObjectDataModification{Id = 845374542, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataConversionUnitModified(int level)
        {
            return _modifications.ContainsKey(845374542, level);
        }

        private Unit GetDataConversionUnit(int level)
        {
            return GetDataConversionUnitRaw(level).ToUnit(this);
        }

        private void SetDataConversionUnit(int level, Unit value)
        {
            SetDataConversionUnitRaw(level, value.ToRaw(null, null));
        }
    }
}