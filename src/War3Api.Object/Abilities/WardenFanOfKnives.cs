using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class WardenFanOfKnives : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerTarget;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumTotalDamage;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumNumberOfTargets;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumSpeedAdjustment;
        public WardenFanOfKnives(): base(1801864513)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
        }

        public WardenFanOfKnives(int newId): base(1801864513, newId)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
        }

        public WardenFanOfKnives(string newRawcode): base(1801864513, newRawcode)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
        }

        public WardenFanOfKnives(ObjectDatabase db): base(1801864513, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
        }

        public WardenFanOfKnives(int newId, ObjectDatabase db): base(1801864513, newId, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
        }

        public WardenFanOfKnives(string newRawcode, ObjectDatabase db): base(1801864513, newRawcode, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _dataMaximumSpeedAdjustment = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumSpeedAdjustment, SetDataMaximumSpeedAdjustment));
        }

        public ObjectProperty<float> DataDamagePerTarget => _dataDamagePerTarget.Value;
        public ObjectProperty<float> DataMaximumTotalDamage => _dataMaximumTotalDamage.Value;
        public ObjectProperty<int> DataMaximumNumberOfTargets => _dataMaximumNumberOfTargets.Value;
        public ObjectProperty<float> DataMaximumSpeedAdjustment => _dataMaximumSpeedAdjustment.Value;
        private float GetDataDamagePerTarget(int level)
        {
            return _modifications[829122117, level].ValueAsFloat;
        }

        private void SetDataDamagePerTarget(int level, float value)
        {
            _modifications[829122117, level] = new LevelObjectDataModification{Id = 829122117, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMaximumTotalDamage(int level)
        {
            return _modifications[845899333, level].ValueAsFloat;
        }

        private void SetDataMaximumTotalDamage(int level, float value)
        {
            _modifications[845899333, level] = new LevelObjectDataModification{Id = 845899333, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataMaximumNumberOfTargets(int level)
        {
            return _modifications[862676549, level].ValueAsInt;
        }

        private void SetDataMaximumNumberOfTargets(int level, int value)
        {
            _modifications[862676549, level] = new LevelObjectDataModification{Id = 862676549, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataMaximumSpeedAdjustment(int level)
        {
            return _modifications[879453765, level].ValueAsFloat;
        }

        private void SetDataMaximumSpeedAdjustment(int level, float value)
        {
            _modifications[879453765, level] = new LevelObjectDataModification{Id = 879453765, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}