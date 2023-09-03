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
    public sealed class DreadlordInferno : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDurationModified;
        private readonly Lazy<ObjectProperty<float>> _dataImpactDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataImpactDelayModified;
        private readonly Lazy<ObjectProperty<string>> _dataSummonedUnitRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataSummonedUnit;
        public DreadlordInferno(): base(1852396865)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDuration, SetDataDuration));
            _isDataDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationModified));
            _dataImpactDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataImpactDelay, SetDataImpactDelay));
            _isDataImpactDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImpactDelayModified));
            _dataSummonedUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitRaw, SetDataSummonedUnitRaw));
            _isDataSummonedUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitModified));
            _dataSummonedUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnit, SetDataSummonedUnit));
        }

        public DreadlordInferno(int newId): base(1852396865, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDuration, SetDataDuration));
            _isDataDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationModified));
            _dataImpactDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataImpactDelay, SetDataImpactDelay));
            _isDataImpactDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImpactDelayModified));
            _dataSummonedUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitRaw, SetDataSummonedUnitRaw));
            _isDataSummonedUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitModified));
            _dataSummonedUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnit, SetDataSummonedUnit));
        }

        public DreadlordInferno(string newRawcode): base(1852396865, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDuration, SetDataDuration));
            _isDataDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationModified));
            _dataImpactDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataImpactDelay, SetDataImpactDelay));
            _isDataImpactDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImpactDelayModified));
            _dataSummonedUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitRaw, SetDataSummonedUnitRaw));
            _isDataSummonedUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitModified));
            _dataSummonedUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnit, SetDataSummonedUnit));
        }

        public DreadlordInferno(ObjectDatabaseBase db): base(1852396865, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDuration, SetDataDuration));
            _isDataDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationModified));
            _dataImpactDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataImpactDelay, SetDataImpactDelay));
            _isDataImpactDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImpactDelayModified));
            _dataSummonedUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitRaw, SetDataSummonedUnitRaw));
            _isDataSummonedUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitModified));
            _dataSummonedUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnit, SetDataSummonedUnit));
        }

        public DreadlordInferno(int newId, ObjectDatabaseBase db): base(1852396865, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDuration, SetDataDuration));
            _isDataDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationModified));
            _dataImpactDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataImpactDelay, SetDataImpactDelay));
            _isDataImpactDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImpactDelayModified));
            _dataSummonedUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitRaw, SetDataSummonedUnitRaw));
            _isDataSummonedUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitModified));
            _dataSummonedUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnit, SetDataSummonedUnit));
        }

        public DreadlordInferno(string newRawcode, ObjectDatabaseBase db): base(1852396865, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDuration, SetDataDuration));
            _isDataDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationModified));
            _dataImpactDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataImpactDelay, SetDataImpactDelay));
            _isDataImpactDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImpactDelayModified));
            _dataSummonedUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitRaw, SetDataSummonedUnitRaw));
            _isDataSummonedUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitModified));
            _dataSummonedUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnit, SetDataSummonedUnit));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageModified => _isDataDamageModified.Value;
        public ObjectProperty<float> DataDuration => _dataDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataDurationModified => _isDataDurationModified.Value;
        public ObjectProperty<float> DataImpactDelay => _dataImpactDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataImpactDelayModified => _isDataImpactDelayModified.Value;
        public ObjectProperty<string> DataSummonedUnitRaw => _dataSummonedUnitRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedUnitModified => _isDataSummonedUnitModified.Value;
        public ObjectProperty<Unit> DataSummonedUnit => _dataSummonedUnit.Value;
        private float GetDataDamage(int level)
        {
            return _modifications.GetModification(829319509, level).ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[829319509, level] = new LevelObjectDataModification{Id = 829319509, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageModified(int level)
        {
            return _modifications.ContainsKey(829319509, level);
        }

        private float GetDataDuration(int level)
        {
            return _modifications.GetModification(846096725, level).ValueAsFloat;
        }

        private void SetDataDuration(int level, float value)
        {
            _modifications[846096725, level] = new LevelObjectDataModification{Id = 846096725, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDurationModified(int level)
        {
            return _modifications.ContainsKey(846096725, level);
        }

        private float GetDataImpactDelay(int level)
        {
            return _modifications.GetModification(862873941, level).ValueAsFloat;
        }

        private void SetDataImpactDelay(int level, float value)
        {
            _modifications[862873941, level] = new LevelObjectDataModification{Id = 862873941, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataImpactDelayModified(int level)
        {
            return _modifications.ContainsKey(862873941, level);
        }

        private string GetDataSummonedUnitRaw(int level)
        {
            return _modifications.GetModification(879651157, level).ValueAsString;
        }

        private void SetDataSummonedUnitRaw(int level, string value)
        {
            _modifications[879651157, level] = new LevelObjectDataModification{Id = 879651157, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataSummonedUnitModified(int level)
        {
            return _modifications.ContainsKey(879651157, level);
        }

        private Unit GetDataSummonedUnit(int level)
        {
            return GetDataSummonedUnitRaw(level).ToUnit(this);
        }

        private void SetDataSummonedUnit(int level, Unit value)
        {
            SetDataSummonedUnitRaw(level, value.ToRaw(null, null));
        }
    }
}