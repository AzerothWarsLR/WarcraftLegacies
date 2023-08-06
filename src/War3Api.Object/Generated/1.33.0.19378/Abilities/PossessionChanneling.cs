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
    public sealed class PossessionChanneling : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumCreepLevel;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumCreepLevelModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageAmplification;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageAmplificationModified;
        private readonly Lazy<ObjectProperty<int>> _dataTargetIsInvulnerableRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTargetIsInvulnerableModified;
        private readonly Lazy<ObjectProperty<bool>> _dataTargetIsInvulnerable;
        private readonly Lazy<ObjectProperty<int>> _dataTargetIsMagicImmuneRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTargetIsMagicImmuneModified;
        private readonly Lazy<ObjectProperty<bool>> _dataTargetIsMagicImmune;
        public PossessionChanneling(): base(846426177)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsInvulnerableRaw, SetDataTargetIsInvulnerableRaw));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsMagicImmuneRaw, SetDataTargetIsMagicImmuneRaw));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public PossessionChanneling(int newId): base(846426177, newId)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsInvulnerableRaw, SetDataTargetIsInvulnerableRaw));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsMagicImmuneRaw, SetDataTargetIsMagicImmuneRaw));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public PossessionChanneling(string newRawcode): base(846426177, newRawcode)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsInvulnerableRaw, SetDataTargetIsInvulnerableRaw));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsMagicImmuneRaw, SetDataTargetIsMagicImmuneRaw));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public PossessionChanneling(ObjectDatabaseBase db): base(846426177, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsInvulnerableRaw, SetDataTargetIsInvulnerableRaw));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsMagicImmuneRaw, SetDataTargetIsMagicImmuneRaw));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public PossessionChanneling(int newId, ObjectDatabaseBase db): base(846426177, newId, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsInvulnerableRaw, SetDataTargetIsInvulnerableRaw));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsMagicImmuneRaw, SetDataTargetIsMagicImmuneRaw));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public PossessionChanneling(string newRawcode, ObjectDatabaseBase db): base(846426177, newRawcode, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataDamageAmplification = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmplification, SetDataDamageAmplification));
            _isDataDamageAmplificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmplificationModified));
            _dataTargetIsInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsInvulnerableRaw, SetDataTargetIsInvulnerableRaw));
            _isDataTargetIsInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsInvulnerableModified));
            _dataTargetIsInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsInvulnerable, SetDataTargetIsInvulnerable));
            _dataTargetIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetIsMagicImmuneRaw, SetDataTargetIsMagicImmuneRaw));
            _isDataTargetIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetIsMagicImmuneModified));
            _dataTargetIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataTargetIsMagicImmune, SetDataTargetIsMagicImmune));
        }

        public ObjectProperty<int> DataMaximumCreepLevel => _dataMaximumCreepLevel.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumCreepLevelModified => _isDataMaximumCreepLevelModified.Value;
        public ObjectProperty<float> DataDamageAmplification => _dataDamageAmplification.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageAmplificationModified => _isDataDamageAmplificationModified.Value;
        public ObjectProperty<int> DataTargetIsInvulnerableRaw => _dataTargetIsInvulnerableRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataTargetIsInvulnerableModified => _isDataTargetIsInvulnerableModified.Value;
        public ObjectProperty<bool> DataTargetIsInvulnerable => _dataTargetIsInvulnerable.Value;
        public ObjectProperty<int> DataTargetIsMagicImmuneRaw => _dataTargetIsMagicImmuneRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataTargetIsMagicImmuneModified => _isDataTargetIsMagicImmuneModified.Value;
        public ObjectProperty<bool> DataTargetIsMagicImmune => _dataTargetIsMagicImmune.Value;
        private int GetDataMaximumCreepLevel(int level)
        {
            return _modifications.GetModification(829648720, level).ValueAsInt;
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
            return _modifications.GetModification(846425936, level).ValueAsFloat;
        }

        private void SetDataDamageAmplification(int level, float value)
        {
            _modifications[846425936, level] = new LevelObjectDataModification{Id = 846425936, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageAmplificationModified(int level)
        {
            return _modifications.ContainsKey(846425936, level);
        }

        private int GetDataTargetIsInvulnerableRaw(int level)
        {
            return _modifications.GetModification(863203152, level).ValueAsInt;
        }

        private void SetDataTargetIsInvulnerableRaw(int level, int value)
        {
            _modifications[863203152, level] = new LevelObjectDataModification{Id = 863203152, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataTargetIsInvulnerableModified(int level)
        {
            return _modifications.ContainsKey(863203152, level);
        }

        private bool GetDataTargetIsInvulnerable(int level)
        {
            return GetDataTargetIsInvulnerableRaw(level).ToBool(this);
        }

        private void SetDataTargetIsInvulnerable(int level, bool value)
        {
            SetDataTargetIsInvulnerableRaw(level, value.ToRaw(null, null));
        }

        private int GetDataTargetIsMagicImmuneRaw(int level)
        {
            return _modifications.GetModification(879980368, level).ValueAsInt;
        }

        private void SetDataTargetIsMagicImmuneRaw(int level, int value)
        {
            _modifications[879980368, level] = new LevelObjectDataModification{Id = 879980368, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataTargetIsMagicImmuneModified(int level)
        {
            return _modifications.ContainsKey(879980368, level);
        }

        private bool GetDataTargetIsMagicImmune(int level)
        {
            return GetDataTargetIsMagicImmuneRaw(level).ToBool(this);
        }

        private void SetDataTargetIsMagicImmune(int level, bool value)
        {
            SetDataTargetIsMagicImmuneRaw(level, value.ToRaw(null, null));
        }
    }
}