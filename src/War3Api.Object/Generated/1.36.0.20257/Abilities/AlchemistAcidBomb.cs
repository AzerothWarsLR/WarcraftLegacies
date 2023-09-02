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
    public sealed class AlchemistAcidBomb : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedReductionModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedReductionModified;
        private readonly Lazy<ObjectProperty<int>> _dataArmorPenalty;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataArmorPenaltyModified;
        private readonly Lazy<ObjectProperty<float>> _dataPrimaryDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPrimaryDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataSecondaryDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSecondaryDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageIntervalModified;
        public AlchemistAcidBomb(): base(1650544193)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _isDataPrimaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPrimaryDamageModified));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _isDataSecondaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSecondaryDamageModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
        }

        public AlchemistAcidBomb(int newId): base(1650544193, newId)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _isDataPrimaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPrimaryDamageModified));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _isDataSecondaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSecondaryDamageModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
        }

        public AlchemistAcidBomb(string newRawcode): base(1650544193, newRawcode)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _isDataPrimaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPrimaryDamageModified));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _isDataSecondaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSecondaryDamageModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
        }

        public AlchemistAcidBomb(ObjectDatabaseBase db): base(1650544193, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _isDataPrimaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPrimaryDamageModified));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _isDataSecondaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSecondaryDamageModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
        }

        public AlchemistAcidBomb(int newId, ObjectDatabaseBase db): base(1650544193, newId, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _isDataPrimaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPrimaryDamageModified));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _isDataSecondaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSecondaryDamageModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
        }

        public AlchemistAcidBomb(string newRawcode, ObjectDatabaseBase db): base(1650544193, newRawcode, db)
        {
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataPrimaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPrimaryDamage, SetDataPrimaryDamage));
            _isDataPrimaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPrimaryDamageModified));
            _dataSecondaryDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSecondaryDamage, SetDataSecondaryDamage));
            _isDataSecondaryDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSecondaryDamageModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
        }

        public ObjectProperty<float> DataMovementSpeedReduction => _dataMovementSpeedReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedReductionModified => _isDataMovementSpeedReductionModified.Value;
        public ObjectProperty<float> DataAttackSpeedReduction => _dataAttackSpeedReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedReductionModified => _isDataAttackSpeedReductionModified.Value;
        public ObjectProperty<int> DataArmorPenalty => _dataArmorPenalty.Value;
        public ReadOnlyObjectProperty<bool> IsDataArmorPenaltyModified => _isDataArmorPenaltyModified.Value;
        public ObjectProperty<float> DataPrimaryDamage => _dataPrimaryDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataPrimaryDamageModified => _isDataPrimaryDamageModified.Value;
        public ObjectProperty<float> DataSecondaryDamage => _dataSecondaryDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataSecondaryDamageModified => _isDataSecondaryDamageModified.Value;
        public ObjectProperty<float> DataDamageInterval => _dataDamageInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageIntervalModified => _isDataDamageIntervalModified.Value;
        private float GetDataMovementSpeedReduction(int level)
        {
            return _modifications.GetModification(828531022, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedReduction(int level, float value)
        {
            _modifications[828531022, level] = new LevelObjectDataModification{Id = 828531022, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMovementSpeedReductionModified(int level)
        {
            return _modifications.ContainsKey(828531022, level);
        }

        private float GetDataAttackSpeedReduction(int level)
        {
            return _modifications.GetModification(845308238, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedReduction(int level, float value)
        {
            _modifications[845308238, level] = new LevelObjectDataModification{Id = 845308238, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAttackSpeedReductionModified(int level)
        {
            return _modifications.ContainsKey(845308238, level);
        }

        private int GetDataArmorPenalty(int level)
        {
            return _modifications.GetModification(862085454, level).ValueAsInt;
        }

        private void SetDataArmorPenalty(int level, int value)
        {
            _modifications[862085454, level] = new LevelObjectDataModification{Id = 862085454, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataArmorPenaltyModified(int level)
        {
            return _modifications.ContainsKey(862085454, level);
        }

        private float GetDataPrimaryDamage(int level)
        {
            return _modifications.GetModification(878862670, level).ValueAsFloat;
        }

        private void SetDataPrimaryDamage(int level, float value)
        {
            _modifications[878862670, level] = new LevelObjectDataModification{Id = 878862670, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataPrimaryDamageModified(int level)
        {
            return _modifications.ContainsKey(878862670, level);
        }

        private float GetDataSecondaryDamage(int level)
        {
            return _modifications.GetModification(895639886, level).ValueAsFloat;
        }

        private void SetDataSecondaryDamage(int level, float value)
        {
            _modifications[895639886, level] = new LevelObjectDataModification{Id = 895639886, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataSecondaryDamageModified(int level)
        {
            return _modifications.ContainsKey(895639886, level);
        }

        private float GetDataDamageInterval(int level)
        {
            return _modifications.GetModification(912417102, level).ValueAsFloat;
        }

        private void SetDataDamageInterval(int level, float value)
        {
            _modifications[912417102, level] = new LevelObjectDataModification{Id = 912417102, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataDamageIntervalModified(int level)
        {
            return _modifications.ContainsKey(912417102, level);
        }
    }
}