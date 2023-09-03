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
    public sealed class SpiritLink : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDistributedDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDistributedDamageFactorModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumNumberOfTargets;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumNumberOfTargetsModified;
        public SpiritLink(): base(1819308865)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
        }

        public SpiritLink(int newId): base(1819308865, newId)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
        }

        public SpiritLink(string newRawcode): base(1819308865, newRawcode)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
        }

        public SpiritLink(ObjectDatabaseBase db): base(1819308865, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
        }

        public SpiritLink(int newId, ObjectDatabaseBase db): base(1819308865, newId, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
        }

        public SpiritLink(string newRawcode, ObjectDatabaseBase db): base(1819308865, newRawcode, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
            _dataMaximumNumberOfTargets = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfTargets, SetDataMaximumNumberOfTargets));
            _isDataMaximumNumberOfTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumNumberOfTargetsModified));
        }

        public ObjectProperty<float> DataDistributedDamageFactor => _dataDistributedDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataDistributedDamageFactorModified => _isDataDistributedDamageFactorModified.Value;
        public ObjectProperty<int> DataMaximumNumberOfTargets => _dataMaximumNumberOfTargets.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumNumberOfTargetsModified => _isDataMaximumNumberOfTargetsModified.Value;
        private float GetDataDistributedDamageFactor(int level)
        {
            return _modifications.GetModification(829190259, level).ValueAsFloat;
        }

        private void SetDataDistributedDamageFactor(int level, float value)
        {
            _modifications[829190259, level] = new LevelObjectDataModification{Id = 829190259, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDistributedDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(829190259, level);
        }

        private int GetDataMaximumNumberOfTargets(int level)
        {
            return _modifications.GetModification(845967475, level).ValueAsInt;
        }

        private void SetDataMaximumNumberOfTargets(int level, int value)
        {
            _modifications[845967475, level] = new LevelObjectDataModification{Id = 845967475, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMaximumNumberOfTargetsModified(int level)
        {
            return _modifications.ContainsKey(845967475, level);
        }
    }
}