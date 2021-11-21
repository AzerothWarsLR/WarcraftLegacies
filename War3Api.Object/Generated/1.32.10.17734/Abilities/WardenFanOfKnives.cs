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
    public sealed class WardenFanOfKnives : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerTarget;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerTargetModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumTotalDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumTotalDamageModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumNumberOfTargets;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumNumberOfTargetsModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumSpeedAdjustment;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumSpeedAdjustmentModified;
        public WardenFanOfKnives(): base(1801864513)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _isDataMaximumTotalDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumTotalDamageModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
            _isDataMaximumSpeedAdjustmentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumSpeedAdjustmentModified));
        }

        public WardenFanOfKnives(int newId): base(1801864513, newId)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _isDataMaximumTotalDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumTotalDamageModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
            _isDataMaximumSpeedAdjustmentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumSpeedAdjustmentModified));
        }

        public WardenFanOfKnives(string newRawcode): base(1801864513, newRawcode)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _isDataMaximumTotalDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumTotalDamageModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
            _isDataMaximumSpeedAdjustmentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumSpeedAdjustmentModified));
        }

        public WardenFanOfKnives(ObjectDatabaseBase db): base(1801864513, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _isDataMaximumTotalDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumTotalDamageModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
            _isDataMaximumSpeedAdjustmentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumSpeedAdjustmentModified));
        }

        public WardenFanOfKnives(int newId, ObjectDatabaseBase db): base(1801864513, newId, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _isDataMaximumTotalDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumTotalDamageModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
            _isDataMaximumSpeedAdjustmentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumSpeedAdjustmentModified));
        }

        public WardenFanOfKnives(string newRawcode, ObjectDatabaseBase db): base(1801864513, newRawcode, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _isDataMaximumTotalDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumTotalDamageModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
            _isDataMaximumSpeedAdjustmentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumSpeedAdjustmentModified));
        }

        public ObjectProperty<float> DataDamagePerTarget => _dataDamagePerTarget.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerTargetModified => _isDataDamagePerTargetModified.Value;
        public ObjectProperty<float> DataMaximumTotalDamage => _dataMaximumTotalDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumTotalDamageModified => _isDataMaximumTotalDamageModified.Value;
        public ObjectProperty<int> DataMaximumNumberOfTargets => _dataMaximumNumberOfTargets.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumNumberOfTargetsModified => _isDataMaximumNumberOfTargetsModified.Value;
        public ObjectProperty<float> DataMaximumSpeedAdjustment => _dataMaximumSpeedAdjustment.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumSpeedAdjustmentModified => _isDataMaximumSpeedAdjustmentModified.Value;
        private float GetDataDamagePerTarget(int level)
        {
            return _modifications.GetModification(829122117, level).ValueAsFloat;
        }

        private void SetDataDamagePerTarget(int level, float value)
        {
            _modifications[829122117, level] = new LevelObjectDataModification{Id = 829122117, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamagePerTargetModified(int level)
        {
            return _modifications.ContainsKey(829122117, level);
        }

        private float GetDataMaximumTotalDamage(int level)
        {
            return _modifications.GetModification(845899333, level).ValueAsFloat;
        }

        private void SetDataMaximumTotalDamage(int level, float value)
        {
            _modifications[845899333, level] = new LevelObjectDataModification{Id = 845899333, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMaximumTotalDamageModified(int level)
        {
            return _modifications.ContainsKey(845899333, level);
        }

        private int GetDataMaximumNumberOfTargets(int level)
        {
            return _modifications.GetModification(862676549, level).ValueAsInt;
        }

        private void SetDataMaximumNumberOfTargets(int level, int value)
        {
            _modifications[862676549, level] = new LevelObjectDataModification{Id = 862676549, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMaximumNumberOfTargetsModified(int level)
        {
            return _modifications.ContainsKey(862676549, level);
        }

        private float GetDataMaximumSpeedAdjustment(int level)
        {
            return _modifications.GetModification(879453765, level).ValueAsFloat;
        }

        private void SetDataMaximumSpeedAdjustment(int level, float value)
        {
            _modifications[879453765, level] = new LevelObjectDataModification{Id = 879453765, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataMaximumSpeedAdjustmentModified(int level)
        {
            return _modifications.ContainsKey(879453765, level);
        }
    }
}