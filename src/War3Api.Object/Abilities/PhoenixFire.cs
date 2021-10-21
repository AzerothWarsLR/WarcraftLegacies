using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PhoenixFire : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataInitialDamage;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        public PhoenixFire(): base(1719169089)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public PhoenixFire(int newId): base(1719169089, newId)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public PhoenixFire(string newRawcode): base(1719169089, newRawcode)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public PhoenixFire(ObjectDatabase db): base(1719169089, db)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public PhoenixFire(int newId, ObjectDatabase db): base(1719169089, newId, db)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public PhoenixFire(string newRawcode, ObjectDatabase db): base(1719169089, newRawcode, db)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public ObjectProperty<float> DataInitialDamage => _dataInitialDamage.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        private float GetDataInitialDamage(int level)
        {
            return _modifications[828799088, level].ValueAsFloat;
        }

        private void SetDataInitialDamage(int level, float value)
        {
            _modifications[828799088, level] = new LevelObjectDataModification{Id = 828799088, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications[845576304, level].ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[845576304, level] = new LevelObjectDataModification{Id = 845576304, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}