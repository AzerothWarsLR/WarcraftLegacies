using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BattlestationsChaos : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataAllowedUnitTypeRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataAllowedUnitType;
        private readonly Lazy<ObjectProperty<bool>> _dataSummonBusyUnits;
        public BattlestationsChaos(): base(1819566675)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public BattlestationsChaos(int newId): base(1819566675, newId)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public BattlestationsChaos(string newRawcode): base(1819566675, newRawcode)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public BattlestationsChaos(ObjectDatabase db): base(1819566675, db)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public BattlestationsChaos(int newId, ObjectDatabase db): base(1819566675, newId, db)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public BattlestationsChaos(string newRawcode, ObjectDatabase db): base(1819566675, newRawcode, db)
        {
            _dataAllowedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAllowedUnitTypeRaw, SetDataAllowedUnitTypeRaw));
            _dataAllowedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAllowedUnitType, SetDataAllowedUnitType));
            _dataSummonBusyUnits = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSummonBusyUnits, SetDataSummonBusyUnits));
        }

        public ObjectProperty<string> DataAllowedUnitTypeRaw => _dataAllowedUnitTypeRaw.Value;
        public ObjectProperty<Unit> DataAllowedUnitType => _dataAllowedUnitType.Value;
        public ObjectProperty<bool> DataSummonBusyUnits => _dataSummonBusyUnits.Value;
        private string GetDataAllowedUnitTypeRaw(int level)
        {
            return _modifications[829191234, level].ValueAsString;
        }

        private void SetDataAllowedUnitTypeRaw(int level, string value)
        {
            _modifications[829191234, level] = new LevelObjectDataModification{Id = 829191234, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private Unit GetDataAllowedUnitType(int level)
        {
            return GetDataAllowedUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataAllowedUnitType(int level, Unit value)
        {
            SetDataAllowedUnitTypeRaw(level, value.ToRaw(null, null));
        }

        private bool GetDataSummonBusyUnits(int level)
        {
            return _modifications[845968450, level].ValueAsBool;
        }

        private void SetDataSummonBusyUnits(int level, bool value)
        {
            _modifications[845968450, level] = new LevelObjectDataModification{Id = 845968450, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }
    }
}