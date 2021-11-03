using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PossessionChanneling : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumCreepLevel;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumCreepLevelModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageAmplification;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageAmplificationModified;
        private readonly Lazy<ObjectProperty<bool>> _dataTargetIsInvulnerable;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTargetIsInvulnerableModified;
        private readonly Lazy<ObjectProperty<bool>> _dataTargetIsMagicImmune;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTargetIsMagicImmuneModified;
        public PossessionChanneling(): base(846426177)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
        }

        public PossessionChanneling(int newId): base(846426177, newId)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
        }

        public PossessionChanneling(string newRawcode): base(846426177, newRawcode)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
        }

        public PossessionChanneling(ObjectDatabase db): base(846426177, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
        }

        public PossessionChanneling(int newId, ObjectDatabase db): base(846426177, newId, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
        }

        public PossessionChanneling(string newRawcode, ObjectDatabase db): base(846426177, newRawcode, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
        }

        public ObjectProperty<int> DataMaximumCreepLevel => _dataMaximumCreepLevel.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumCreepLevelModified => _isDataMaximumCreepLevelModified.Value;
        public ObjectProperty<float> DataDamageAmplification => _dataDamageAmplification.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageAmplificationModified => _isDataDamageAmplificationModified.Value;
        public ObjectProperty<bool> DataTargetIsInvulnerable => _dataTargetIsInvulnerable.Value;
        public ReadOnlyObjectProperty<bool> IsDataTargetIsInvulnerableModified => _isDataTargetIsInvulnerableModified.Value;
        public ObjectProperty<bool> DataTargetIsMagicImmune => _dataTargetIsMagicImmune.Value;
        public ReadOnlyObjectProperty<bool> IsDataTargetIsMagicImmuneModified => _isDataTargetIsMagicImmuneModified.Value;
        private int GetDataMaximumCreepLevel(int level)
        {
            return _modifications[829648720, level].ValueAsInt;
        }

        private void SetDataMaximumCreepLevel(int level, int value)
        {
            _modifications[829648720, level] = new LevelObjectDataModification{Id = 829648720, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaximumCreepLevelModified(int level)
        {
            return _modifications.ContainsKey(829648720, level);
        }

        private float GetDataDamageAmplification(int level)
        {
            return _modifications[846425936, level].ValueAsFloat;
        }

        private void SetDataDamageAmplification(int level, float value)
        {
            _modifications[846425936, level] = new LevelObjectDataModification{Id = 846425936, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageAmplificationModified(int level)
        {
            return _modifications.ContainsKey(846425936, level);
        }

        private bool GetDataTargetIsInvulnerable(int level)
        {
            return _modifications[863203152, level].ValueAsBool;
        }

        private void SetDataTargetIsInvulnerable(int level, bool value)
        {
            _modifications[863203152, level] = new LevelObjectDataModification{Id = 863203152, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataTargetIsInvulnerableModified(int level)
        {
            return _modifications.ContainsKey(863203152, level);
        }

        private bool GetDataTargetIsMagicImmune(int level)
        {
            return _modifications[879980368, level].ValueAsBool;
        }

        private void SetDataTargetIsMagicImmune(int level, bool value)
        {
            _modifications[879980368, level] = new LevelObjectDataModification{Id = 879980368, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataTargetIsMagicImmuneModified(int level)
        {
            return _modifications.ContainsKey(879980368, level);
        }
    }
}