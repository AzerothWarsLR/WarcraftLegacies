using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ChieftainWarStomp : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        public ChieftainWarStomp(): base(1937198913)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public ChieftainWarStomp(int newId): base(1937198913, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public ChieftainWarStomp(string newRawcode): base(1937198913, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public ChieftainWarStomp(ObjectDatabase db): base(1937198913, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public ChieftainWarStomp(int newId, ObjectDatabase db): base(1937198913, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public ChieftainWarStomp(string newRawcode, ObjectDatabase db): base(1937198913, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        private float GetDataDamage(int level)
        {
            return _modifications[829649495, level].ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[829649495, level] = new LevelObjectDataModification{Id = 829649495, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}