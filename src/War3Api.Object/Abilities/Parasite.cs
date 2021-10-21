using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Parasite : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedFactor;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedFactor;
        private readonly Lazy<ObjectProperty<int>> _dataStackingTypeRaw;
        private readonly Lazy<ObjectProperty<StackFlags>> _dataStackingType;
        private readonly Lazy<ObjectProperty<string>> _dataUnitTypeRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataUnitType;
        private readonly Lazy<ObjectProperty<int>> _dataSummonedUnitCount;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDuration;
        public Parasite(): base(1634750017)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _dataSummonedUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDuration, SetDataSummonedUnitDuration));
        }

        public Parasite(int newId): base(1634750017, newId)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _dataSummonedUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDuration, SetDataSummonedUnitDuration));
        }

        public Parasite(string newRawcode): base(1634750017, newRawcode)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _dataSummonedUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDuration, SetDataSummonedUnitDuration));
        }

        public Parasite(ObjectDatabase db): base(1634750017, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _dataSummonedUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDuration, SetDataSummonedUnitDuration));
        }

        public Parasite(int newId, ObjectDatabase db): base(1634750017, newId, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _dataSummonedUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDuration, SetDataSummonedUnitDuration));
        }

        public Parasite(string newRawcode, ObjectDatabase db): base(1634750017, newRawcode, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _dataSummonedUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDuration, SetDataSummonedUnitDuration));
        }

        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ObjectProperty<float> DataMovementSpeedFactor => _dataMovementSpeedFactor.Value;
        public ObjectProperty<float> DataAttackSpeedFactor => _dataAttackSpeedFactor.Value;
        public ObjectProperty<int> DataStackingTypeRaw => _dataStackingTypeRaw.Value;
        public ObjectProperty<StackFlags> DataStackingType => _dataStackingType.Value;
        public ObjectProperty<string> DataUnitTypeRaw => _dataUnitTypeRaw.Value;
        public ObjectProperty<Unit> DataUnitType => _dataUnitType.Value;
        public ObjectProperty<int> DataSummonedUnitCount => _dataSummonedUnitCount.Value;
        public ObjectProperty<float> DataSummonedUnitDuration => _dataSummonedUnitDuration.Value;
        private float GetDataDamagePerSecond(int level)
        {
            return _modifications[828993360, level].ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[828993360, level] = new LevelObjectDataModification{Id = 828993360, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMovementSpeedFactor(int level)
        {
            return _modifications[845770576, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedFactor(int level, float value)
        {
            _modifications[845770576, level] = new LevelObjectDataModification{Id = 845770576, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataAttackSpeedFactor(int level)
        {
            return _modifications[862547792, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedFactor(int level, float value)
        {
            _modifications[862547792, level] = new LevelObjectDataModification{Id = 862547792, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private int GetDataStackingTypeRaw(int level)
        {
            return _modifications[879325008, level].ValueAsInt;
        }

        private void SetDataStackingTypeRaw(int level, int value)
        {
            _modifications[879325008, level] = new LevelObjectDataModification{Id = 879325008, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private StackFlags GetDataStackingType(int level)
        {
            return GetDataStackingTypeRaw(level).ToStackFlags(this);
        }

        private void SetDataStackingType(int level, StackFlags value)
        {
            SetDataStackingTypeRaw(level, value.ToRaw(null, null));
        }

        private string GetDataUnitTypeRaw(int level)
        {
            return _modifications[1970106473, level].ValueAsString;
        }

        private void SetDataUnitTypeRaw(int level, string value)
        {
            _modifications[1970106473, level] = new LevelObjectDataModification{Id = 1970106473, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private Unit GetDataUnitType(int level)
        {
            return GetDataUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataUnitType(int level, Unit value)
        {
            SetDataUnitTypeRaw(level, value.ToRaw(null, null));
        }

        private int GetDataSummonedUnitCount(int level)
        {
            return _modifications[895578190, level].ValueAsInt;
        }

        private void SetDataSummonedUnitCount(int level, int value)
        {
            _modifications[895578190, level] = new LevelObjectDataModification{Id = 895578190, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataSummonedUnitDuration(int level)
        {
            return _modifications[912355406, level].ValueAsFloat;
        }

        private void SetDataSummonedUnitDuration(int level, float value)
        {
            _modifications[912355406, level] = new LevelObjectDataModification{Id = 912355406, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }
    }
}