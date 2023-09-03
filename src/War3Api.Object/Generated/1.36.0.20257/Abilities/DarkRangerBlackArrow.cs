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
    public sealed class DarkRangerBlackArrow : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfSummonedUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfSummonedUnitsModified;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDurationseconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitDurationsecondsModified;
        private readonly Lazy<ObjectProperty<string>> _dataSummonedUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataSummonedUnitType;
        public DarkRangerBlackArrow(): base(1633832513)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitDurationseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDurationseconds, SetDataSummonedUnitDurationseconds));
            _isDataSummonedUnitDurationsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDurationsecondsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public DarkRangerBlackArrow(int newId): base(1633832513, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitDurationseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDurationseconds, SetDataSummonedUnitDurationseconds));
            _isDataSummonedUnitDurationsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDurationsecondsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public DarkRangerBlackArrow(string newRawcode): base(1633832513, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitDurationseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDurationseconds, SetDataSummonedUnitDurationseconds));
            _isDataSummonedUnitDurationsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDurationsecondsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public DarkRangerBlackArrow(ObjectDatabaseBase db): base(1633832513, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitDurationseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDurationseconds, SetDataSummonedUnitDurationseconds));
            _isDataSummonedUnitDurationsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDurationsecondsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public DarkRangerBlackArrow(int newId, ObjectDatabaseBase db): base(1633832513, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitDurationseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDurationseconds, SetDataSummonedUnitDurationseconds));
            _isDataSummonedUnitDurationsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDurationsecondsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public DarkRangerBlackArrow(string newRawcode, ObjectDatabaseBase db): base(1633832513, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataNumberOfSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfSummonedUnits, SetDataNumberOfSummonedUnits));
            _isDataNumberOfSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfSummonedUnitsModified));
            _dataSummonedUnitDurationseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDurationseconds, SetDataSummonedUnitDurationseconds));
            _isDataSummonedUnitDurationsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDurationsecondsModified));
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<int> DataNumberOfSummonedUnits => _dataNumberOfSummonedUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfSummonedUnitsModified => _isDataNumberOfSummonedUnitsModified.Value;
        public ObjectProperty<float> DataSummonedUnitDurationseconds => _dataSummonedUnitDurationseconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedUnitDurationsecondsModified => _isDataSummonedUnitDurationsecondsModified.Value;
        public ObjectProperty<string> DataSummonedUnitTypeRaw => _dataSummonedUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedUnitTypeModified => _isDataSummonedUnitTypeModified.Value;
        public ObjectProperty<Unit> DataSummonedUnitType => _dataSummonedUnitType.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications.GetModification(828465742, level).ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[828465742, level] = new LevelObjectDataModification{Id = 828465742, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageBonusModified(int level)
        {
            return _modifications.ContainsKey(828465742, level);
        }

        private int GetDataNumberOfSummonedUnits(int level)
        {
            return _modifications.GetModification(845242958, level).ValueAsInt;
        }

        private void SetDataNumberOfSummonedUnits(int level, int value)
        {
            _modifications[845242958, level] = new LevelObjectDataModification{Id = 845242958, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataNumberOfSummonedUnitsModified(int level)
        {
            return _modifications.ContainsKey(845242958, level);
        }

        private float GetDataSummonedUnitDurationseconds(int level)
        {
            return _modifications.GetModification(862020174, level).ValueAsFloat;
        }

        private void SetDataSummonedUnitDurationseconds(int level, float value)
        {
            _modifications[862020174, level] = new LevelObjectDataModification{Id = 862020174, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataSummonedUnitDurationsecondsModified(int level)
        {
            return _modifications.ContainsKey(862020174, level);
        }

        private string GetDataSummonedUnitTypeRaw(int level)
        {
            return _modifications.GetModification(1969316430, level).ValueAsString;
        }

        private void SetDataSummonedUnitTypeRaw(int level, string value)
        {
            _modifications[1969316430, level] = new LevelObjectDataModification{Id = 1969316430, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataSummonedUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(1969316430, level);
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