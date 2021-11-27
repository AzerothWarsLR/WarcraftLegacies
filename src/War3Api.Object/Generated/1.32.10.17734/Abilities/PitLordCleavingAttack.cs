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
    public sealed class PitLordCleavingAttack : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDistributedDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDistributedDamageFactorModified;
        public PitLordCleavingAttack(): base(1633898049)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public PitLordCleavingAttack(int newId): base(1633898049, newId)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public PitLordCleavingAttack(string newRawcode): base(1633898049, newRawcode)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public PitLordCleavingAttack(ObjectDatabaseBase db): base(1633898049, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public PitLordCleavingAttack(int newId, ObjectDatabaseBase db): base(1633898049, newId, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public PitLordCleavingAttack(string newRawcode, ObjectDatabaseBase db): base(1633898049, newRawcode, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
            _isDataDistributedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistributedDamageFactorModified));
        }

        public ObjectProperty<float> DataDistributedDamageFactor => _dataDistributedDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataDistributedDamageFactorModified => _isDataDistributedDamageFactorModified.Value;
        private float GetDataDistributedDamageFactor(int level)
        {
            return _modifications.GetModification(828466030, level).ValueAsFloat;
        }

        private void SetDataDistributedDamageFactor(int level, float value)
        {
            _modifications[828466030, level] = new LevelObjectDataModification{Id = 828466030, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDistributedDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(828466030, level);
        }
    }
}