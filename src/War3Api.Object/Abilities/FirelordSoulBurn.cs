using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FirelordSoulBurn : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageAmount;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePeriod;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePenalty;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedReduction;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedReduction;
        public FirelordSoulBurn(): base(1869827649)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public FirelordSoulBurn(int newId): base(1869827649, newId)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public FirelordSoulBurn(string newRawcode): base(1869827649, newRawcode)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public FirelordSoulBurn(ObjectDatabase db): base(1869827649, db)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public FirelordSoulBurn(int newId, ObjectDatabase db): base(1869827649, newId, db)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public FirelordSoulBurn(string newRawcode, ObjectDatabase db): base(1869827649, newRawcode, db)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamagePeriod = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePeriod, SetDataDamagePeriod));
            _dataDamagePenalty = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePenalty, SetDataDamagePenalty));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public ObjectProperty<float> DataDamageAmount => _dataDamageAmount.Value;
        public ObjectProperty<float> DataDamagePeriod => _dataDamagePeriod.Value;
        public ObjectProperty<float> DataDamagePenalty => _dataDamagePenalty.Value;
        public ObjectProperty<float> DataMovementSpeedReduction => _dataMovementSpeedReduction.Value;
        public ObjectProperty<float> DataAttackSpeedReduction => _dataAttackSpeedReduction.Value;
        private float GetDataDamageAmount(int level)
        {
            return _modifications[829387598, level].ValueAsFloat;
        }

        private void SetDataDamageAmount(int level, float value)
        {
            _modifications[829387598, level] = new LevelObjectDataModification{Id = 829387598, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamagePeriod(int level)
        {
            return _modifications[846164814, level].ValueAsFloat;
        }

        private void SetDataDamagePeriod(int level, float value)
        {
            _modifications[846164814, level] = new LevelObjectDataModification{Id = 846164814, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamagePenalty(int level)
        {
            return _modifications[862942030, level].ValueAsFloat;
        }

        private void SetDataDamagePenalty(int level, float value)
        {
            _modifications[862942030, level] = new LevelObjectDataModification{Id = 862942030, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataMovementSpeedReduction(int level)
        {
            return _modifications[879719246, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedReduction(int level, float value)
        {
            _modifications[879719246, level] = new LevelObjectDataModification{Id = 879719246, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataAttackSpeedReduction(int level)
        {
            return _modifications[896496462, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedReduction(int level, float value)
        {
            _modifications[896496462, level] = new LevelObjectDataModification{Id = 896496462, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}