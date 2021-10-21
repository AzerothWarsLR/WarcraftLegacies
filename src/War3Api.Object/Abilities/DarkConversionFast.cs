using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DarkConversionFast : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataRaceToConvertRaw;
        private readonly Lazy<ObjectProperty<UnitRace>> _dataRaceToConvert;
        private readonly Lazy<ObjectProperty<string>> _dataConversionUnitRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataConversionUnit;
        public DarkConversionFast(): base(1667518035)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public DarkConversionFast(int newId): base(1667518035, newId)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public DarkConversionFast(string newRawcode): base(1667518035, newRawcode)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public DarkConversionFast(ObjectDatabase db): base(1667518035, db)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public DarkConversionFast(int newId, ObjectDatabase db): base(1667518035, newId, db)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public DarkConversionFast(string newRawcode, ObjectDatabase db): base(1667518035, newRawcode, db)
        {
            _dataRaceToConvertRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataRaceToConvertRaw, SetDataRaceToConvertRaw));
            _dataRaceToConvert = new Lazy<ObjectProperty<UnitRace>>(() => new ObjectProperty<UnitRace>(GetDataRaceToConvert, SetDataRaceToConvert));
            _dataConversionUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataConversionUnitRaw, SetDataConversionUnitRaw));
            _dataConversionUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataConversionUnit, SetDataConversionUnit));
        }

        public ObjectProperty<string> DataRaceToConvertRaw => _dataRaceToConvertRaw.Value;
        public ObjectProperty<UnitRace> DataRaceToConvert => _dataRaceToConvert.Value;
        public ObjectProperty<string> DataConversionUnitRaw => _dataConversionUnitRaw.Value;
        public ObjectProperty<Unit> DataConversionUnit => _dataConversionUnit.Value;
        private string GetDataRaceToConvertRaw(int level)
        {
            return _modifications[828597326, level].ValueAsString;
        }

        private void SetDataRaceToConvertRaw(int level, string value)
        {
            _modifications[828597326, level] = new LevelObjectDataModification{Id = 828597326, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
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
            return _modifications[845374542, level].ValueAsString;
        }

        private void SetDataConversionUnitRaw(int level, string value)
        {
            _modifications[845374542, level] = new LevelObjectDataModification{Id = 845374542, Type = ObjectDataType.String, Value = value, Level = level};
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