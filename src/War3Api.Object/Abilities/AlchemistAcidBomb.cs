using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AlchemistAcidBomb : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedReduction;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedReduction;
        private readonly Lazy<ObjectProperty<int>> _dataArmorPenalty;
        private readonly Lazy<ObjectProperty<float>> _dataPrimaryDamage;
        private readonly Lazy<ObjectProperty<float>> _dataSecondaryDamage;
        private readonly Lazy<ObjectProperty<float>> _dataDamageInterval;
        public AlchemistAcidBomb(): base(1650544193)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
        }

        public AlchemistAcidBomb(int newId): base(1650544193, newId)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
        }

        public AlchemistAcidBomb(string newRawcode): base(1650544193, newRawcode)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
        }

        public AlchemistAcidBomb(ObjectDatabase db): base(1650544193, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
        }

        public AlchemistAcidBomb(int newId, ObjectDatabase db): base(1650544193, newId, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
        }

        public AlchemistAcidBomb(string newRawcode, ObjectDatabase db): base(1650544193, newRawcode, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
        }

        public ObjectProperty<float> DataMovementSpeedReduction => _dataMovementSpeedReduction.Value;
        public ObjectProperty<float> DataAttackSpeedReduction => _dataAttackSpeedReduction.Value;
        public ObjectProperty<int> DataArmorPenalty => _dataArmorPenalty.Value;
        public ObjectProperty<float> DataPrimaryDamage => _dataPrimaryDamage.Value;
        public ObjectProperty<float> DataSecondaryDamage => _dataSecondaryDamage.Value;
        public ObjectProperty<float> DataDamageInterval => _dataDamageInterval.Value;
        private float GetDataMovementSpeedReduction(int level)
        {
            return _modifications[828531022, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedReduction(int level, float value)
        {
            _modifications[828531022, level] = new LevelObjectDataModification{Id = 828531022, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataAttackSpeedReduction(int level)
        {
            return _modifications[845308238, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedReduction(int level, float value)
        {
            _modifications[845308238, level] = new LevelObjectDataModification{Id = 845308238, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataArmorPenalty(int level)
        {
            return _modifications[862085454, level].ValueAsInt;
        }

        private void SetDataArmorPenalty(int level, int value)
        {
            _modifications[862085454, level] = new LevelObjectDataModification{Id = 862085454, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataPrimaryDamage(int level)
        {
            return _modifications[878862670, level].ValueAsFloat;
        }

        private void SetDataPrimaryDamage(int level, float value)
        {
            _modifications[878862670, level] = new LevelObjectDataModification{Id = 878862670, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataSecondaryDamage(int level)
        {
            return _modifications[895639886, level].ValueAsFloat;
        }

        private void SetDataSecondaryDamage(int level, float value)
        {
            _modifications[895639886, level] = new LevelObjectDataModification{Id = 895639886, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataDamageInterval(int level)
        {
            return _modifications[912417102, level].ValueAsFloat;
        }

        private void SetDataDamageInterval(int level, float value)
        {
            _modifications[912417102, level] = new LevelObjectDataModification{Id = 912417102, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }
    }
}