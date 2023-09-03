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
    public sealed class ThunderClapThunderLizard : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataExtraDamageToTarget;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataExtraDamageToTargetModified;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedReductionModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedReductionModified;
        public ThunderClapThunderLizard(): base(846480193)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _isDataExtraDamageToTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageToTargetModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public ThunderClapThunderLizard(int newId): base(846480193, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _isDataExtraDamageToTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageToTargetModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public ThunderClapThunderLizard(string newRawcode): base(846480193, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _isDataExtraDamageToTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageToTargetModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public ThunderClapThunderLizard(ObjectDatabaseBase db): base(846480193, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _isDataExtraDamageToTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageToTargetModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public ThunderClapThunderLizard(int newId, ObjectDatabaseBase db): base(846480193, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _isDataExtraDamageToTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageToTargetModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public ThunderClapThunderLizard(string newRawcode, ObjectDatabaseBase db): base(846480193, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _isDataExtraDamageToTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraDamageToTargetModified));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _isDataMovementSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedReductionModified));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _isDataAttackSpeedReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedReductionModified));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageModified => _isDataDamageModified.Value;
        public ObjectProperty<float> DataExtraDamageToTarget => _dataExtraDamageToTarget.Value;
        public ReadOnlyObjectProperty<bool> IsDataExtraDamageToTargetModified => _isDataExtraDamageToTargetModified.Value;
        public ObjectProperty<float> DataMovementSpeedReduction => _dataMovementSpeedReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedReductionModified => _isDataMovementSpeedReductionModified.Value;
        public ObjectProperty<float> DataAttackSpeedReduction => _dataAttackSpeedReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedReductionModified => _isDataAttackSpeedReductionModified.Value;
        private float GetDataDamage(int level)
        {
            return _modifications.GetModification(828601411, level).ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[828601411, level] = new LevelObjectDataModification{Id = 828601411, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageModified(int level)
        {
            return _modifications.ContainsKey(828601411, level);
        }

        private float GetDataExtraDamageToTarget(int level)
        {
            return _modifications.GetModification(845378627, level).ValueAsFloat;
        }

        private void SetDataExtraDamageToTarget(int level, float value)
        {
            _modifications[845378627, level] = new LevelObjectDataModification{Id = 845378627, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataExtraDamageToTargetModified(int level)
        {
            return _modifications.ContainsKey(845378627, level);
        }

        private float GetDataMovementSpeedReduction(int level)
        {
            return _modifications.GetModification(862155843, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedReduction(int level, float value)
        {
            _modifications[862155843, level] = new LevelObjectDataModification{Id = 862155843, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMovementSpeedReductionModified(int level)
        {
            return _modifications.ContainsKey(862155843, level);
        }

        private float GetDataAttackSpeedReduction(int level)
        {
            return _modifications.GetModification(878933059, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedReduction(int level, float value)
        {
            _modifications[878933059, level] = new LevelObjectDataModification{Id = 878933059, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataAttackSpeedReductionModified(int level)
        {
            return _modifications.ContainsKey(878933059, level);
        }
    }
}