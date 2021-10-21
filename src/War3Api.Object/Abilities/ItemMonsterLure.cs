using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemMonsterLure : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfLures;
        private readonly Lazy<ObjectProperty<float>> _dataActivationDelay;
        private readonly Lazy<ObjectProperty<float>> _dataLureIntervalSeconds;
        private readonly Lazy<ObjectProperty<string>> _dataLureUnitTypeRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataLureUnitType;
        public ItemMonsterLure(): base(1869433153)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataLureIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalSeconds, SetDataLureIntervalSeconds));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ItemMonsterLure(int newId): base(1869433153, newId)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataLureIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalSeconds, SetDataLureIntervalSeconds));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ItemMonsterLure(string newRawcode): base(1869433153, newRawcode)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataLureIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalSeconds, SetDataLureIntervalSeconds));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ItemMonsterLure(ObjectDatabase db): base(1869433153, db)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataLureIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalSeconds, SetDataLureIntervalSeconds));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ItemMonsterLure(int newId, ObjectDatabase db): base(1869433153, newId, db)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataLureIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalSeconds, SetDataLureIntervalSeconds));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ItemMonsterLure(string newRawcode, ObjectDatabase db): base(1869433153, newRawcode, db)
        {
            _dataNumberOfLures = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfLures, SetDataNumberOfLures));
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _dataLureIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLureIntervalSeconds, SetDataLureIntervalSeconds));
            _dataLureUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataLureUnitTypeRaw, SetDataLureUnitTypeRaw));
            _dataLureUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataLureUnitType, SetDataLureUnitType));
        }

        public ObjectProperty<int> DataNumberOfLures => _dataNumberOfLures.Value;
        public ObjectProperty<float> DataActivationDelay => _dataActivationDelay.Value;
        public ObjectProperty<float> DataLureIntervalSeconds => _dataLureIntervalSeconds.Value;
        public ObjectProperty<string> DataLureUnitTypeRaw => _dataLureUnitTypeRaw.Value;
        public ObjectProperty<Unit> DataLureUnitType => _dataLureUnitType.Value;
        private int GetDataNumberOfLures(int level)
        {
            return _modifications[829386089, level].ValueAsInt;
        }

        private void SetDataNumberOfLures(int level, int value)
        {
            _modifications[829386089, level] = new LevelObjectDataModification{Id = 829386089, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataActivationDelay(int level)
        {
            return _modifications[846163305, level].ValueAsFloat;
        }

        private void SetDataActivationDelay(int level, float value)
        {
            _modifications[846163305, level] = new LevelObjectDataModification{Id = 846163305, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataLureIntervalSeconds(int level)
        {
            return _modifications[862940521, level].ValueAsFloat;
        }

        private void SetDataLureIntervalSeconds(int level, float value)
        {
            _modifications[862940521, level] = new LevelObjectDataModification{Id = 862940521, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private string GetDataLureUnitTypeRaw(int level)
        {
            return _modifications[1970236777, level].ValueAsString;
        }

        private void SetDataLureUnitTypeRaw(int level, string value)
        {
            _modifications[1970236777, level] = new LevelObjectDataModification{Id = 1970236777, Type = ObjectDataType.String, Value = value, Level = level};
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