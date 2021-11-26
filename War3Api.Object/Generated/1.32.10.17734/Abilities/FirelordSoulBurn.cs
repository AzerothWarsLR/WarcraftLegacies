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
    public sealed class FirelordSoulBurn : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePeriod;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePeriodModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePenalty;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePenaltyModified;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedReductionModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedReductionModified;
        public FirelordSoulBurn(): base(1869827649)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _isDataDamagePeriodModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePeriodModified));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _isDataDamagePenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePenaltyModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public FirelordSoulBurn(int newId): base(1869827649, newId)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _isDataDamagePeriodModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePeriodModified));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _isDataDamagePenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePenaltyModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public FirelordSoulBurn(string newRawcode): base(1869827649, newRawcode)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _isDataDamagePeriodModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePeriodModified));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _isDataDamagePenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePenaltyModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public FirelordSoulBurn(ObjectDatabaseBase db): base(1869827649, db)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _isDataDamagePeriodModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePeriodModified));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _isDataDamagePenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePenaltyModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public FirelordSoulBurn(int newId, ObjectDatabaseBase db): base(1869827649, newId, db)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _isDataDamagePeriodModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePeriodModified));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _isDataDamagePenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePenaltyModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public FirelordSoulBurn(string newRawcode, ObjectDatabaseBase db): base(1869827649, newRawcode, db)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _isDataDamagePeriodModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePeriodModified));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _isDataDamagePenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePenaltyModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public ObjectProperty<float> DataDamageAmount => _dataDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageAmountModified => _isDataDamageAmountModified.Value;
        public ObjectProperty<float> DataDamagePeriod => _dataDamagePeriod.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePeriodModified => _isDataDamagePeriodModified.Value;
        public ObjectProperty<float> DataDamagePenalty => _dataDamagePenalty.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePenaltyModified => _isDataDamagePenaltyModified.Value;
        public ObjectProperty<float> DataMovementSpeedReduction => _dataMovementSpeedReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedReductionModified => _isDataMovementSpeedReductionModified.Value;
        public ObjectProperty<float> DataAttackSpeedReduction => _dataAttackSpeedReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedReductionModified => _isDataAttackSpeedReductionModified.Value;
        private float GetDataDamageAmount(int level)
        {
            return _modifications.GetModification(829387598, level).ValueAsFloat;
        }

        private void SetDataDamageAmount(int level, float value)
        {
            _modifications[829387598, level] = new LevelObjectDataModification{Id = 829387598, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageAmountModified(int level)
        {
            return _modifications.ContainsKey(829387598, level);
        }

        private float GetDataDamagePeriod(int level)
        {
            return _modifications.GetModification(846164814, level).ValueAsFloat;
        }

        private void SetDataDamagePeriod(int level, float value)
        {
            _modifications[846164814, level] = new LevelObjectDataModification{Id = 846164814, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamagePeriodModified(int level)
        {
            return _modifications.ContainsKey(846164814, level);
        }

        private float GetDataDamagePenalty(int level)
        {
            return _modifications.GetModification(862942030, level).ValueAsFloat;
        }

        private void SetDataDamagePenalty(int level, float value)
        {
            _modifications[862942030, level] = new LevelObjectDataModification{Id = 862942030, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamagePenaltyModified(int level)
        {
            return _modifications.ContainsKey(862942030, level);
        }

        private float GetDataMovementSpeedReduction(int level)
        {
            return _modifications.GetModification(879719246, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedReduction(int level, float value)
        {
            _modifications[879719246, level] = new LevelObjectDataModification{Id = 879719246, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataMovementSpeedReductionModified(int level)
        {
            return _modifications.ContainsKey(879719246, level);
        }

        private float GetDataAttackSpeedReduction(int level)
        {
            return _modifications.GetModification(896496462, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedReduction(int level, float value)
        {
            _modifications[896496462, level] = new LevelObjectDataModification{Id = 896496462, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataAttackSpeedReductionModified(int level)
        {
            return _modifications.ContainsKey(896496462, level);
        }
    }
}