using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class StasisTrap : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataActivationDelay;
        private readonly Lazy<ObjectProperty<float>> _dataDetectionRadius;
        private readonly Lazy<ObjectProperty<float>> _dataDetonationRadius;
        private readonly Lazy<ObjectProperty<float>> _dataStunDuration;
        private readonly Lazy<ObjectProperty<float>> _dataDetonationDelay;
        private readonly Lazy<ObjectProperty<string>> _dataWardUnitTypeRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataWardUnitType;
        public StasisTrap(): base(1635021633)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public StasisTrap(int newId): base(1635021633, newId)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public StasisTrap(string newRawcode): base(1635021633, newRawcode)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public StasisTrap(ObjectDatabase db): base(1635021633, db)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public StasisTrap(int newId, ObjectDatabase db): base(1635021633, newId, db)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public StasisTrap(string newRawcode, ObjectDatabase db): base(1635021633, newRawcode, db)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataDetectionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetectionRadius, SetDataDetectionRadius));
            _dataDetonationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationRadius, SetDataDetonationRadius));
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _dataDetonationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDetonationDelay, SetDataDetonationDelay));
            _dataWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataWardUnitTypeRaw, SetDataWardUnitTypeRaw));
            _dataWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataWardUnitType, SetDataWardUnitType));
        }

        public ObjectProperty<float> DataActivationDelay => _dataActivationDelay.Value;
        public ObjectProperty<float> DataDetectionRadius => _dataDetectionRadius.Value;
        public ObjectProperty<float> DataDetonationRadius => _dataDetonationRadius.Value;
        public ObjectProperty<float> DataStunDuration => _dataStunDuration.Value;
        public ObjectProperty<float> DataDetonationDelay => _dataDetonationDelay.Value;
        public ObjectProperty<string> DataWardUnitTypeRaw => _dataWardUnitTypeRaw.Value;
        public ObjectProperty<Unit> DataWardUnitType => _dataWardUnitType.Value;
        private float GetDataActivationDelay(int level)
        {
            return _modifications[828470355, level].ValueAsFloat;
        }

        private void SetDataActivationDelay(int level, float value)
        {
            _modifications[828470355, level] = new LevelObjectDataModification{Id = 828470355, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDetectionRadius(int level)
        {
            return _modifications[845247571, level].ValueAsFloat;
        }

        private void SetDataDetectionRadius(int level, float value)
        {
            _modifications[845247571, level] = new LevelObjectDataModification{Id = 845247571, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDetonationRadius(int level)
        {
            return _modifications[862024787, level].ValueAsFloat;
        }

        private void SetDataDetonationRadius(int level, float value)
        {
            _modifications[862024787, level] = new LevelObjectDataModification{Id = 862024787, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataStunDuration(int level)
        {
            return _modifications[878802003, level].ValueAsFloat;
        }

        private void SetDataStunDuration(int level, float value)
        {
            _modifications[878802003, level] = new LevelObjectDataModification{Id = 878802003, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataDetonationDelay(int level)
        {
            return _modifications[895579219, level].ValueAsFloat;
        }

        private void SetDataDetonationDelay(int level, float value)
        {
            _modifications[895579219, level] = new LevelObjectDataModification{Id = 895579219, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private string GetDataWardUnitTypeRaw(int level)
        {
            return _modifications[1969321043, level].ValueAsString;
        }

        private void SetDataWardUnitTypeRaw(int level, string value)
        {
            _modifications[1969321043, level] = new LevelObjectDataModification{Id = 1969321043, Type = ObjectDataType.String, Value = value, Level = level};
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