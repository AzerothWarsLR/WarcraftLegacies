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
    public sealed class ShadowStrikeCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDecayingDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDecayingDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataDecayPower;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDecayPowerModified;
        private readonly Lazy<ObjectProperty<float>> _dataInitialDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInitialDamageModified;
        public ShadowStrikeCreep(): base(1936933697)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _isDataDecayingDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayingDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _isDataDecayPowerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayPowerModified));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
        }

        public ShadowStrikeCreep(int newId): base(1936933697, newId)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _isDataDecayingDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayingDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _isDataDecayPowerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayPowerModified));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
        }

        public ShadowStrikeCreep(string newRawcode): base(1936933697, newRawcode)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _isDataDecayingDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayingDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _isDataDecayPowerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayPowerModified));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
        }

        public ShadowStrikeCreep(ObjectDatabaseBase db): base(1936933697, db)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _isDataDecayingDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayingDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _isDataDecayPowerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayPowerModified));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
        }

        public ShadowStrikeCreep(int newId, ObjectDatabaseBase db): base(1936933697, newId, db)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _isDataDecayingDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayingDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _isDataDecayPowerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayPowerModified));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
        }

        public ShadowStrikeCreep(string newRawcode, ObjectDatabaseBase db): base(1936933697, newRawcode, db)
        {
            _dataDecayingDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayingDamage, SetDataDecayingDamage));
            _isDataDecayingDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayingDamageModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataDecayPower = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDecayPower, SetDataDecayPower));
            _isDataDecayPowerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDecayPowerModified));
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
        }

        public ObjectProperty<float> DataDecayingDamage => _dataDecayingDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataDecayingDamageModified => _isDataDecayingDamageModified.Value;
        public ObjectProperty<float> DataMovementSpeedFactor => _dataMovementSpeedFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedFactorModified => _isDataMovementSpeedFactorModified.Value;
        public ObjectProperty<float> DataAttackSpeedFactor => _dataAttackSpeedFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedFactorModified => _isDataAttackSpeedFactorModified.Value;
        public ObjectProperty<float> DataDecayPower => _dataDecayPower.Value;
        public ReadOnlyObjectProperty<bool> IsDataDecayPowerModified => _isDataDecayPowerModified.Value;
        public ObjectProperty<float> DataInitialDamage => _dataInitialDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataInitialDamageModified => _isDataInitialDamageModified.Value;
        private float GetDataDecayingDamage(int level)
        {
            return _modifications.GetModification(828928837, level).ValueAsFloat;
        }

        private void SetDataDecayingDamage(int level, float value)
        {
            _modifications[828928837, level] = new LevelObjectDataModification{Id = 828928837, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDecayingDamageModified(int level)
        {
            return _modifications.ContainsKey(828928837, level);
        }

        private float GetDataMovementSpeedFactor(int level)
        {
            return _modifications.GetModification(845706053, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedFactor(int level, float value)
        {
            _modifications[845706053, level] = new LevelObjectDataModification{Id = 845706053, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMovementSpeedFactorModified(int level)
        {
            return _modifications.ContainsKey(845706053, level);
        }

        private float GetDataAttackSpeedFactor(int level)
        {
            return _modifications.GetModification(862483269, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedFactor(int level, float value)
        {
            _modifications[862483269, level] = new LevelObjectDataModification{Id = 862483269, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAttackSpeedFactorModified(int level)
        {
            return _modifications.ContainsKey(862483269, level);
        }

        private float GetDataDecayPower(int level)
        {
            return _modifications.GetModification(879260485, level).ValueAsFloat;
        }

        private void SetDataDecayPower(int level, float value)
        {
            _modifications[879260485, level] = new LevelObjectDataModification{Id = 879260485, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataDecayPowerModified(int level)
        {
            return _modifications.ContainsKey(879260485, level);
        }

        private float GetDataInitialDamage(int level)
        {
            return _modifications.GetModification(896037701, level).ValueAsFloat;
        }

        private void SetDataInitialDamage(int level, float value)
        {
            _modifications[896037701, level] = new LevelObjectDataModification{Id = 896037701, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataInitialDamageModified(int level)
        {
            return _modifications.ContainsKey(896037701, level);
        }
    }
}