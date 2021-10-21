using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PossessionChanneling : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumCreepLevel;
        private readonly Lazy<ObjectProperty<float>> _dataDamageAmplification;
        private readonly Lazy<ObjectProperty<bool>> _dataTargetIsInvulnerable;
        private readonly Lazy<ObjectProperty<bool>> _dataTargetIsMagicImmune;
        public PossessionChanneling(): base(846426177)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public PossessionChanneling(int newId): base(846426177, newId)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public PossessionChanneling(string newRawcode): base(846426177, newRawcode)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public PossessionChanneling(ObjectDatabase db): base(846426177, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public PossessionChanneling(int newId, ObjectDatabase db): base(846426177, newId, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public PossessionChanneling(string newRawcode, ObjectDatabase db): base(846426177, newRawcode, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public ObjectProperty<int> DataMaximumCreepLevel => _dataMaximumCreepLevel.Value;
        public ObjectProperty<float> DataDamageAmplification => _dataDamageAmplification.Value;
        public ObjectProperty<bool> DataTargetIsInvulnerable => _dataTargetIsInvulnerable.Value;
        public ObjectProperty<bool> DataTargetIsMagicImmune => _dataTargetIsMagicImmune.Value;
        private int GetDataMaximumCreepLevel(int level)
        {
            return _modifications[829648720, level].ValueAsInt;
        }

        private void SetDataMaximumCreepLevel(int level, int value)
        {
            _modifications[829648720, level] = new LevelObjectDataModification{Id = 829648720, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageAmplification(int level)
        {
            return _modifications[846425936, level].ValueAsFloat;
        }

        private void SetDataDamageAmplification(int level, float value)
        {
            _modifications[846425936, level] = new LevelObjectDataModification{Id = 846425936, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetDataTargetIsInvulnerable(int level)
        {
            return _modifications[863203152, level].ValueAsBool;
        }

        private void SetDataTargetIsInvulnerable(int level, bool value)
        {
            _modifications[863203152, level] = new LevelObjectDataModification{Id = 863203152, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataTargetIsMagicImmune(int level)
        {
            return _modifications[879980368, level].ValueAsBool;
        }

        private void SetDataTargetIsMagicImmune(int level, bool value)
        {
            _modifications[879980368, level] = new LevelObjectDataModification{Id = 879980368, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }
    }
}