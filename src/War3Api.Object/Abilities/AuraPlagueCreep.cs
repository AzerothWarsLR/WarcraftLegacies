using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AuraPlagueCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAuraDuration;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataDurationOfPlagueWard;
        private readonly Lazy<ObjectProperty<string>> _dataPlagueWardUnitTypeRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataPlagueWardUnitType;
        public AuraPlagueCreep(): base(863002945)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public AuraPlagueCreep(int newId): base(863002945, newId)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public AuraPlagueCreep(string newRawcode): base(863002945, newRawcode)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public AuraPlagueCreep(ObjectDatabase db): base(863002945, db)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public AuraPlagueCreep(int newId, ObjectDatabase db): base(863002945, newId, db)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public AuraPlagueCreep(string newRawcode, ObjectDatabase db): base(863002945, newRawcode, db)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public ObjectProperty<float> DataAuraDuration => _dataAuraDuration.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ObjectProperty<float> DataDurationOfPlagueWard => _dataDurationOfPlagueWard.Value;
        public ObjectProperty<string> DataPlagueWardUnitTypeRaw => _dataPlagueWardUnitTypeRaw.Value;
        public ObjectProperty<Unit> DataPlagueWardUnitType => _dataPlagueWardUnitType.Value;
        private float GetDataAuraDuration(int level)
        {
            return _modifications[829190209, level].ValueAsFloat;
        }

        private void SetDataAuraDuration(int level, float value)
        {
            _modifications[829190209, level] = new LevelObjectDataModification{Id = 829190209, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications[845967425, level].ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[845967425, level] = new LevelObjectDataModification{Id = 845967425, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDurationOfPlagueWard(int level)
        {
            return _modifications[862744641, level].ValueAsFloat;
        }

        private void SetDataDurationOfPlagueWard(int level, float value)
        {
            _modifications[862744641, level] = new LevelObjectDataModification{Id = 862744641, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private string GetDataPlagueWardUnitTypeRaw(int level)
        {
            return _modifications[1970040897, level].ValueAsString;
        }

        private void SetDataPlagueWardUnitTypeRaw(int level, string value)
        {
            _modifications[1970040897, level] = new LevelObjectDataModification{Id = 1970040897, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private Unit GetDataPlagueWardUnitType(int level)
        {
            return GetDataPlagueWardUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataPlagueWardUnitType(int level, Unit value)
        {
            SetDataPlagueWardUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}