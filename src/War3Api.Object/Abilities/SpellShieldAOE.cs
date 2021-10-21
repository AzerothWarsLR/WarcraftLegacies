using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SpellShieldAOE : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataShieldCooldownTime;
        public SpellShieldAOE(): base(1702055489)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
        }

        public SpellShieldAOE(int newId): base(1702055489, newId)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
        }

        public SpellShieldAOE(string newRawcode): base(1702055489, newRawcode)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
        }

        public SpellShieldAOE(ObjectDatabase db): base(1702055489, db)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
        }

        public SpellShieldAOE(int newId, ObjectDatabase db): base(1702055489, newId, db)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
        }

        public SpellShieldAOE(string newRawcode, ObjectDatabase db): base(1702055489, newRawcode, db)
        {
            _dataShieldCooldownTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataShieldCooldownTime, SetDataShieldCooldownTime));
        }

        public ObjectProperty<float> DataShieldCooldownTime => _dataShieldCooldownTime.Value;
        private float GetDataShieldCooldownTime(int level)
        {
            return _modifications[828732238, level].ValueAsFloat;
        }

        private void SetDataShieldCooldownTime(int level, float value)
        {
            _modifications[828732238, level] = new LevelObjectDataModification{Id = 828732238, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}