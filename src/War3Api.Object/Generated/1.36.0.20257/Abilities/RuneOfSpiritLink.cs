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
    public sealed class RuneOfSpiritLink : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDistributedDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDistributedDamageFactorModified;
        public RuneOfSpiritLink(): base(1886417729)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public RuneOfSpiritLink(int newId): base(1886417729, newId)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public RuneOfSpiritLink(string newRawcode): base(1886417729, newRawcode)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public RuneOfSpiritLink(ObjectDatabaseBase db): base(1886417729, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public RuneOfSpiritLink(int newId, ObjectDatabaseBase db): base(1886417729, newId, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public RuneOfSpiritLink(string newRawcode, ObjectDatabaseBase db): base(1886417729, newRawcode, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public ObjectProperty<float> DataDistributedDamageFactor => _dataDistributedDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataDistributedDamageFactorModified => _isDataDistributedDamageFactorModified.Value;
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
    }
}