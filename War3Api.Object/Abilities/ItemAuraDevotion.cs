using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemAuraDevotion : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataArmorBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataArmorBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPercentBonusModified;
        public ItemAuraDevotion(): base(1684097345)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public ItemAuraDevotion(int newId): base(1684097345, newId)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public ItemAuraDevotion(string newRawcode): base(1684097345, newRawcode)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public ItemAuraDevotion(ObjectDatabase db): base(1684097345, db)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public ItemAuraDevotion(int newId, ObjectDatabase db): base(1684097345, newId, db)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public ItemAuraDevotion(string newRawcode, ObjectDatabase db): base(1684097345, newRawcode, db)
        {
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public ObjectProperty<float> DataArmorBonus => _dataArmorBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataArmorBonusModified => _isDataArmorBonusModified.Value;
        public ObjectProperty<bool> DataPercentBonus => _dataPercentBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataPercentBonusModified => _isDataPercentBonusModified.Value;
        private float GetDataArmorBonus(int level)
        {
            return _modifications[828662088, level].ValueAsFloat;
        }

        private void SetDataArmorBonus(int level, float value)
        {
            _modifications[828662088, level] = new LevelObjectDataModification{Id = 828662088, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataArmorBonusModified(int level)
        {
            return _modifications.ContainsKey(828662088, level);
        }

        private bool GetDataPercentBonus(int level)
        {
            return _modifications[845439304, level].ValueAsBool;
        }

        private void SetDataPercentBonus(int level, bool value)
        {
            _modifications[845439304, level] = new LevelObjectDataModification{Id = 845439304, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataPercentBonusModified(int level)
        {
            return _modifications.ContainsKey(845439304, level);
        }
    }
}