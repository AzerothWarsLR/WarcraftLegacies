using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PaladinDevotionAura : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataArmorBonus;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentBonus;
        public PaladinDevotionAura(): base(1684097089)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public PaladinDevotionAura(int newId): base(1684097089, newId)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public PaladinDevotionAura(string newRawcode): base(1684097089, newRawcode)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public PaladinDevotionAura(ObjectDatabase db): base(1684097089, db)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public PaladinDevotionAura(int newId, ObjectDatabase db): base(1684097089, newId, db)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public PaladinDevotionAura(string newRawcode, ObjectDatabase db): base(1684097089, newRawcode, db)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public ObjectProperty<float> DataArmorBonus => _dataArmorBonus.Value;
        public ObjectProperty<bool> DataPercentBonus => _dataPercentBonus.Value;
        private float GetDataArmorBonus(int level)
        {
            return _modifications[828662088, level].ValueAsFloat;
        }

        private void SetDataArmorBonus(int level, float value)
        {
            _modifications[828662088, level] = new LevelObjectDataModification{Id = 828662088, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataPercentBonus(int level)
        {
            return _modifications[845439304, level].ValueAsBool;
        }

        private void SetDataPercentBonus(int level, bool value)
        {
            _modifications[845439304, level] = new LevelObjectDataModification{Id = 845439304, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }
    }
}