using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PoisonArrows : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataExtraDamage;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedFactor;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedFactor;
        private readonly Lazy<ObjectProperty<int>> _dataStackingTypeRaw;
        private readonly Lazy<ObjectProperty<StackFlags>> _dataStackingType;
        public PoisonArrows(): base(1634747713)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public PoisonArrows(int newId): base(1634747713, newId)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public PoisonArrows(string newRawcode): base(1634747713, newRawcode)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public PoisonArrows(ObjectDatabase db): base(1634747713, db)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public PoisonArrows(int newId, ObjectDatabase db): base(1634747713, newId, db)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public PoisonArrows(string newRawcode, ObjectDatabase db): base(1634747713, newRawcode, db)
        {
            _dataExtraDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamage, SetDataExtraDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataStackingTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStackingTypeRaw, SetDataStackingTypeRaw));
            _dataStackingType = new Lazy<ObjectProperty<StackFlags>>(() => new ObjectProperty<StackFlags>(GetDataStackingType, SetDataStackingType));
        }

        public ObjectProperty<float> DataExtraDamage => _dataExtraDamage.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ObjectProperty<float> DataMovementSpeedFactor => _dataMovementSpeedFactor.Value;
        public ObjectProperty<float> DataAttackSpeedFactor => _dataAttackSpeedFactor.Value;
        public ObjectProperty<int> DataStackingTypeRaw => _dataStackingTypeRaw.Value;
        public ObjectProperty<StackFlags> DataStackingType => _dataStackingType.Value;
        private float GetDataExtraDamage(int level)
        {
            return _modifications[828469072, level].ValueAsFloat;
        }

        private void SetDataExtraDamage(int level, float value)
        {
            _modifications[828469072, level] = new LevelObjectDataModification{Id = 828469072, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications[845246288, level].ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[845246288, level] = new LevelObjectDataModification{Id = 845246288, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataMovementSpeedFactor(int level)
        {
            return _modifications[862023504, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedFactor(int level, float value)
        {
            _modifications[862023504, level] = new LevelObjectDataModification{Id = 862023504, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataAttackSpeedFactor(int level)
        {
            return _modifications[878800720, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedFactor(int level, float value)
        {
            _modifications[878800720, level] = new LevelObjectDataModification{Id = 878800720, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private int GetDataStackingTypeRaw(int level)
        {
            return _modifications[895577936, level].ValueAsInt;
        }

        private void SetDataStackingTypeRaw(int level, int value)
        {
            _modifications[895577936, level] = new LevelObjectDataModification{Id = 895577936, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private StackFlags GetDataStackingType(int level)
        {
            return GetDataStackingTypeRaw(level).ToStackFlags(this);
        }

        private void SetDataStackingType(int level, StackFlags value)
        {
            SetDataStackingTypeRaw(level, value.ToRaw(null, null));
        }
    }
}