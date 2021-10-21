using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class RocketAttack : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerTarget;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumTotalDamage;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumNumberOfTargets;
        public RocketAttack(): base(1668248129)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
        }

        public RocketAttack(int newId): base(1668248129, newId)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
        }

        public RocketAttack(string newRawcode): base(1668248129, newRawcode)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
        }

        public RocketAttack(ObjectDatabase db): base(1668248129, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
        }

        public RocketAttack(int newId, ObjectDatabase db): base(1668248129, newId, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
        }

        public RocketAttack(string newRawcode, ObjectDatabase db): base(1668248129, newRawcode, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataMaximumTotalDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumTotalDamage, SetDataMaximumTotalDamage));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
        }

        public ObjectProperty<float> DataDamagePerTarget => _dataDamagePerTarget.Value;
        public ObjectProperty<float> DataMaximumTotalDamage => _dataMaximumTotalDamage.Value;
        public ObjectProperty<int> DataMaximumNumberOfTargets => _dataMaximumNumberOfTargets.Value;
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
    }
}