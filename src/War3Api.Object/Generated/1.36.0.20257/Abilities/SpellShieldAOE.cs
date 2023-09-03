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
    public sealed class SpellShieldAOE : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataShieldCooldownTime;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataShieldCooldownTimeModified;
        public SpellShieldAOE(): base(1702055489)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
            _isDataShieldCooldownTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShieldCooldownTimeModified));
        }

        public SpellShieldAOE(int newId): base(1702055489, newId)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
            _isDataShieldCooldownTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShieldCooldownTimeModified));
        }

        public SpellShieldAOE(string newRawcode): base(1702055489, newRawcode)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
            _isDataShieldCooldownTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShieldCooldownTimeModified));
        }

        public SpellShieldAOE(ObjectDatabaseBase db): base(1702055489, db)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
            _isDataShieldCooldownTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShieldCooldownTimeModified));
        }

        public SpellShieldAOE(int newId, ObjectDatabaseBase db): base(1702055489, newId, db)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
            _isDataShieldCooldownTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShieldCooldownTimeModified));
        }

        public SpellShieldAOE(string newRawcode, ObjectDatabaseBase db): base(1702055489, newRawcode, db)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
            _isDataShieldCooldownTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShieldCooldownTimeModified));
        }

        public ObjectProperty<float> DataShieldCooldownTime => _dataShieldCooldownTime.Value;
        public ReadOnlyObjectProperty<bool> IsDataShieldCooldownTimeModified => _isDataShieldCooldownTimeModified.Value;
        private float GetDataShieldCooldownTime(int level)
        {
            return _modifications.GetModification(828732238, level).ValueAsFloat;
        }

        private void SetDataShieldCooldownTime(int level, float value)
        {
            _modifications[828732238, level] = new LevelObjectDataModification{Id = 828732238, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataShieldCooldownTimeModified(int level)
        {
            return _modifications.ContainsKey(828732238, level);
        }
    }
}