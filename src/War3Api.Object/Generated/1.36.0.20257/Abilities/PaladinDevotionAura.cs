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
    public sealed class PaladinDevotionAura : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataArmorBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataArmorBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataPercentBonusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPercentBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentBonus;
        public PaladinDevotionAura(): base(1684097089)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public PaladinDevotionAura(int newId): base(1684097089, newId)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public PaladinDevotionAura(string newRawcode): base(1684097089, newRawcode)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public PaladinDevotionAura(ObjectDatabaseBase db): base(1684097089, db)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public PaladinDevotionAura(int newId, ObjectDatabaseBase db): base(1684097089, newId, db)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public PaladinDevotionAura(string newRawcode, ObjectDatabaseBase db): base(1684097089, newRawcode, db)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public ObjectProperty<float> DataArmorBonus => _dataArmorBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataArmorBonusModified => _isDataArmorBonusModified.Value;
        public ObjectProperty<int> DataPercentBonusRaw => _dataPercentBonusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPercentBonusModified => _isDataPercentBonusModified.Value;
        public ObjectProperty<bool> DataPercentBonus => _dataPercentBonus.Value;
        private float GetDataArmorBonus(int level)
        {
            return _modifications.GetModification(828662088, level).ValueAsFloat;
        }

        private void SetDataArmorBonus(int level, float value)
        {
            _modifications[828662088, level] = new LevelObjectDataModification{Id = 828662088, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataArmorBonusModified(int level)
        {
            return _modifications.ContainsKey(828662088, level);
        }

        private int GetDataPercentBonusRaw(int level)
        {
            return _modifications.GetModification(845439304, level).ValueAsInt;
        }

        private void SetDataPercentBonusRaw(int level, int value)
        {
            _modifications[845439304, level] = new LevelObjectDataModification{Id = 845439304, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataPercentBonusModified(int level)
        {
            return _modifications.ContainsKey(845439304, level);
        }

        private bool GetDataPercentBonus(int level)
        {
            return GetDataPercentBonusRaw(level).ToBool(this);
        }

        private void SetDataPercentBonus(int level, bool value)
        {
            SetDataPercentBonusRaw(level, value.ToRaw(0, 1));
        }
    }
}