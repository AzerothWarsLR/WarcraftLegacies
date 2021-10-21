using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FrostBolt : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        public FrostBolt(): base(1650672449)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FrostBolt(int newId): base(1650672449, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FrostBolt(string newRawcode): base(1650672449, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FrostBolt(ObjectDatabase db): base(1650672449, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FrostBolt(int newId, ObjectDatabase db): base(1650672449, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FrostBolt(string newRawcode, ObjectDatabase db): base(1650672449, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        private float GetDataDamage(int level)
        {
            return _modifications[828535880, level].ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[828535880, level] = new LevelObjectDataModification{Id = 828535880, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}