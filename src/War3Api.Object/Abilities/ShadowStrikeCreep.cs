using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ShadowStrikeCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDecayingDamage;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedFactor;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedFactor;
        private readonly Lazy<ObjectProperty<float>> _dataDecayPower;
        private readonly Lazy<ObjectProperty<float>> _dataInitialDamage;
        public ShadowStrikeCreep(): base(1936933697)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
        }

        public ShadowStrikeCreep(int newId): base(1936933697, newId)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
        }

        public ShadowStrikeCreep(string newRawcode): base(1936933697, newRawcode)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
        }

        public ShadowStrikeCreep(ObjectDatabase db): base(1936933697, db)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
        }

        public ShadowStrikeCreep(int newId, ObjectDatabase db): base(1936933697, newId, db)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
        }

        public ShadowStrikeCreep(string newRawcode, ObjectDatabase db): base(1936933697, newRawcode, db)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
        }

        public ObjectProperty<float> DataDecayingDamage => _dataDecayingDamage.Value;
        public ObjectProperty<float> DataMovementSpeedFactor => _dataMovementSpeedFactor.Value;
        public ObjectProperty<float> DataAttackSpeedFactor => _dataAttackSpeedFactor.Value;
        public ObjectProperty<float> DataDecayPower => _dataDecayPower.Value;
        public ObjectProperty<float> DataInitialDamage => _dataInitialDamage.Value;
        private float GetDataDecayingDamage(int level)
        {
            return _modifications[828928837, level].ValueAsFloat;
        }

        private void SetDataDecayingDamage(int level, float value)
        {
            _modifications[828928837, level] = new LevelObjectDataModification{Id = 828928837, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMovementSpeedFactor(int level)
        {
            return _modifications[845706053, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedFactor(int level, float value)
        {
            _modifications[845706053, level] = new LevelObjectDataModification{Id = 845706053, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataAttackSpeedFactor(int level)
        {
            return _modifications[862483269, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedFactor(int level, float value)
        {
            _modifications[862483269, level] = new LevelObjectDataModification{Id = 862483269, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataDecayPower(int level)
        {
            return _modifications[879260485, level].ValueAsFloat;
        }

        private void SetDataDecayPower(int level, float value)
        {
            _modifications[879260485, level] = new LevelObjectDataModification{Id = 879260485, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataInitialDamage(int level)
        {
            return _modifications[896037701, level].ValueAsFloat;
        }

        private void SetDataInitialDamage(int level, float value)
        {
            _modifications[896037701, level] = new LevelObjectDataModification{Id = 896037701, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}