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
    public sealed class ItemMonsterLure : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfLures;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfLuresModified;
        private readonly Lazy<ObjectProperty<float>> _dataActivationDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataActivationDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataLureIntervalseconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLureIntervalsecondsModified;
        private readonly Lazy<ObjectProperty<string>> _dataLureUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLureUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataLureUnitType;
        public ItemMonsterLure(): base(1869433153)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _isDataNumberOfLuresModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfLuresModified));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataLureIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalseconds, SetDataLureIntervalseconds));
            _isDataLureIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureIntervalsecondsModified));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _isDataLureUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureUnitTypeModified));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ItemMonsterLure(int newId): base(1869433153, newId)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _isDataNumberOfLuresModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfLuresModified));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataLureIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalseconds, SetDataLureIntervalseconds));
            _isDataLureIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureIntervalsecondsModified));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _isDataLureUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureUnitTypeModified));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ItemMonsterLure(string newRawcode): base(1869433153, newRawcode)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _isDataNumberOfLuresModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfLuresModified));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataLureIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalseconds, SetDataLureIntervalseconds));
            _isDataLureIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureIntervalsecondsModified));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _isDataLureUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureUnitTypeModified));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ItemMonsterLure(ObjectDatabaseBase db): base(1869433153, db)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _isDataNumberOfLuresModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfLuresModified));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataLureIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalseconds, SetDataLureIntervalseconds));
            _isDataLureIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureIntervalsecondsModified));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _isDataLureUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureUnitTypeModified));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ItemMonsterLure(int newId, ObjectDatabaseBase db): base(1869433153, newId, db)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _isDataNumberOfLuresModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfLuresModified));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataLureIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalseconds, SetDataLureIntervalseconds));
            _isDataLureIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureIntervalsecondsModified));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _isDataLureUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureUnitTypeModified));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ItemMonsterLure(string newRawcode, ObjectDatabaseBase db): base(1869433153, newRawcode, db)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _isDataNumberOfLuresModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfLuresModified));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataLureIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalseconds, SetDataLureIntervalseconds));
            _isDataLureIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureIntervalsecondsModified));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _isDataLureUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLureUnitTypeModified));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ObjectProperty<int> DataNumberOfLures => _dataNumberOfLures.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfLuresModified => _isDataNumberOfLuresModified.Value;
        public ObjectProperty<float> DataActivationDelay => _dataActivationDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataActivationDelayModified => _isDataActivationDelayModified.Value;
        public ObjectProperty<float> DataLureIntervalseconds => _dataLureIntervalseconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataLureIntervalsecondsModified => _isDataLureIntervalsecondsModified.Value;
        public ObjectProperty<string> DataLureUnitTypeRaw => _dataLureUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataLureUnitTypeModified => _isDataLureUnitTypeModified.Value;
        public ObjectProperty<Unit> DataLureUnitType => _dataLureUnitType.Value;
        private int GetDataNumberOfLures(int level)
        {
            return _modifications.GetModification(829386089, level).ValueAsInt;
        }

        private void SetDataNumberOfLures(int level, int value)
        {
            _modifications[829386089, level] = new LevelObjectDataModification{Id = 829386089, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfLuresModified(int level)
        {
            return _modifications.ContainsKey(829386089, level);
        }

        private float GetDataActivationDelay(int level)
        {
            return _modifications.GetModification(846163305, level).ValueAsFloat;
        }

        private void SetDataActivationDelay(int level, float value)
        {
            _modifications[846163305, level] = new LevelObjectDataModification{Id = 846163305, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataActivationDelayModified(int level)
        {
            return _modifications.ContainsKey(846163305, level);
        }

        private float GetDataLureIntervalseconds(int level)
        {
            return _modifications.GetModification(862940521, level).ValueAsFloat;
        }

        private void SetDataLureIntervalseconds(int level, float value)
        {
            _modifications[862940521, level] = new LevelObjectDataModification{Id = 862940521, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataLureIntervalsecondsModified(int level)
        {
            return _modifications.ContainsKey(862940521, level);
        }

        private string GetDataLureUnitTypeRaw(int level)
        {
            return _modifications.GetModification(1970236777, level).ValueAsString;
        }

        private void SetDataLureUnitTypeRaw(int level, string value)
        {
            _modifications[1970236777, level] = new LevelObjectDataModification{Id = 1970236777, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataLureUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(1970236777, level);
        }

        private Unit GetDataLureUnitType(int level)
        {
            return GetDataLureUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataLureUnitType(int level, Unit value)
        {
            SetDataLureUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}