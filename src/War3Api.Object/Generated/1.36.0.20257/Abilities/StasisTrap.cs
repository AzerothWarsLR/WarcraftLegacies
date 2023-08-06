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
    public sealed class StasisTrap : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataActivationDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataActivationDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataDetectionRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDetectionRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataDetonationRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDetonationRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataStunDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataStunDurationModified;
        private readonly Lazy<ObjectProperty<float>> _dataDetonationDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDetonationDelayModified;
        private readonly Lazy<ObjectProperty<string>> _dataWardUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataWardUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataWardUnitType;
        public StasisTrap(): base(1635021633)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _isDataDetonationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationRadiusModified));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _isDataDetonationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationDelayModified));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public StasisTrap(int newId): base(1635021633, newId)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _isDataDetonationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationRadiusModified));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _isDataDetonationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationDelayModified));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public StasisTrap(string newRawcode): base(1635021633, newRawcode)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _isDataDetonationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationRadiusModified));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _isDataDetonationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationDelayModified));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public StasisTrap(ObjectDatabaseBase db): base(1635021633, db)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _isDataDetonationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationRadiusModified));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _isDataDetonationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationDelayModified));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public StasisTrap(int newId, ObjectDatabaseBase db): base(1635021633, newId, db)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _isDataDetonationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationRadiusModified));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _isDataDetonationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationDelayModified));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public StasisTrap(string newRawcode, ObjectDatabaseBase db): base(1635021633, newRawcode, db)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _isDataDetonationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationRadiusModified));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _isDataDetonationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetonationDelayModified));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _isDataWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWardUnitTypeModified));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public ObjectProperty<float> DataActivationDelay => _dataActivationDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataActivationDelayModified => _isDataActivationDelayModified.Value;
        public ObjectProperty<float> DataDetectionRadius => _dataDetectionRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataDetectionRadiusModified => _isDataDetectionRadiusModified.Value;
        public ObjectProperty<float> DataDetonationRadius => _dataDetonationRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataDetonationRadiusModified => _isDataDetonationRadiusModified.Value;
        public ObjectProperty<float> DataStunDuration => _dataStunDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataStunDurationModified => _isDataStunDurationModified.Value;
        public ObjectProperty<float> DataDetonationDelay => _dataDetonationDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataDetonationDelayModified => _isDataDetonationDelayModified.Value;
        public ObjectProperty<string> DataWardUnitTypeRaw => _dataWardUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataWardUnitTypeModified => _isDataWardUnitTypeModified.Value;
        public ObjectProperty<Unit> DataWardUnitType => _dataWardUnitType.Value;
        private float GetDataActivationDelay(int level)
        {
            return _modifications.GetModification(828470355, level).ValueAsFloat;
        }

        private void SetDataActivationDelay(int level, float value)
        {
            _modifications[828470355, level] = new LevelObjectDataModification{Id = 828470355, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataActivationDelayModified(int level)
        {
            return _modifications.ContainsKey(828470355, level);
        }

        private float GetDataDetectionRadius(int level)
        {
            return _modifications.GetModification(845247571, level).ValueAsFloat;
        }

        private void SetDataDetectionRadius(int level, float value)
        {
            _modifications[845247571, level] = new LevelObjectDataModification{Id = 845247571, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDetectionRadiusModified(int level)
        {
            return _modifications.ContainsKey(845247571, level);
        }

        private float GetDataDetonationRadius(int level)
        {
            return _modifications.GetModification(862024787, level).ValueAsFloat;
        }

        private void SetDataDetonationRadius(int level, float value)
        {
            _modifications[862024787, level] = new LevelObjectDataModification{Id = 862024787, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDetonationRadiusModified(int level)
        {
            return _modifications.ContainsKey(862024787, level);
        }

        private float GetDataStunDuration(int level)
        {
            return _modifications.GetModification(878802003, level).ValueAsFloat;
        }

        private void SetDataStunDuration(int level, float value)
        {
            _modifications[878802003, level] = new LevelObjectDataModification{Id = 878802003, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataStunDurationModified(int level)
        {
            return _modifications.ContainsKey(878802003, level);
        }

        private float GetDataDetonationDelay(int level)
        {
            return _modifications.GetModification(895579219, level).ValueAsFloat;
        }

        private void SetDataDetonationDelay(int level, float value)
        {
            _modifications[895579219, level] = new LevelObjectDataModification{Id = 895579219, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataDetonationDelayModified(int level)
        {
            return _modifications.ContainsKey(895579219, level);
        }

        private string GetDataWardUnitTypeRaw(int level)
        {
            return _modifications.GetModification(1969321043, level).ValueAsString;
        }

        private void SetDataWardUnitTypeRaw(int level, string value)
        {
            _modifications[1969321043, level] = new LevelObjectDataModification{Id = 1969321043, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataWardUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(1969321043, level);
        }

        private Unit GetDataWardUnitType(int level)
        {
            return GetDataWardUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataWardUnitType(int level, Unit value)
        {
            SetDataWardUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}