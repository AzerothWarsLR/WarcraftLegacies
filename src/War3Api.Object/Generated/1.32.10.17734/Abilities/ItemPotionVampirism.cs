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
    public sealed class ItemPotionVampirism : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataLifeStealAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeStealAmountModified;
        private readonly Lazy<ObjectProperty<int>> _dataAmountIsRawValueRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAmountIsRawValueModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAmountIsRawValue;
        public ItemPotionVampirism(): base(1987070273)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _isDataLifeStealAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeStealAmountModified));
            _dataAmountIsRawValueRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAmountIsRawValueRaw, SetDataAmountIsRawValueRaw));
            _isDataAmountIsRawValueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountIsRawValueModified));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ItemPotionVampirism(int newId): base(1987070273, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _isDataLifeStealAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeStealAmountModified));
            _dataAmountIsRawValueRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAmountIsRawValueRaw, SetDataAmountIsRawValueRaw));
            _isDataAmountIsRawValueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountIsRawValueModified));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ItemPotionVampirism(string newRawcode): base(1987070273, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _isDataLifeStealAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeStealAmountModified));
            _dataAmountIsRawValueRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAmountIsRawValueRaw, SetDataAmountIsRawValueRaw));
            _isDataAmountIsRawValueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountIsRawValueModified));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ItemPotionVampirism(ObjectDatabaseBase db): base(1987070273, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _isDataLifeStealAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeStealAmountModified));
            _dataAmountIsRawValueRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAmountIsRawValueRaw, SetDataAmountIsRawValueRaw));
            _isDataAmountIsRawValueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountIsRawValueModified));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ItemPotionVampirism(int newId, ObjectDatabaseBase db): base(1987070273, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _isDataLifeStealAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeStealAmountModified));
            _dataAmountIsRawValueRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAmountIsRawValueRaw, SetDataAmountIsRawValueRaw));
            _isDataAmountIsRawValueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountIsRawValueModified));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ItemPotionVampirism(string newRawcode, ObjectDatabaseBase db): base(1987070273, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _isDataLifeStealAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeStealAmountModified));
            _dataAmountIsRawValueRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAmountIsRawValueRaw, SetDataAmountIsRawValueRaw));
            _isDataAmountIsRawValueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountIsRawValueModified));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<float> DataLifeStealAmount => _dataLifeStealAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeStealAmountModified => _isDataLifeStealAmountModified.Value;
        public ObjectProperty<int> DataAmountIsRawValueRaw => _dataAmountIsRawValueRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAmountIsRawValueModified => _isDataAmountIsRawValueModified.Value;
        public ObjectProperty<bool> DataAmountIsRawValue => _dataAmountIsRawValue.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications.GetModification(829845609, level).ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[829845609, level] = new LevelObjectDataModification{Id = 829845609, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageBonusModified(int level)
        {
            return _modifications.ContainsKey(829845609, level);
        }

        private float GetDataLifeStealAmount(int level)
        {
            return _modifications.GetModification(846622825, level).ValueAsFloat;
        }

        private void SetDataLifeStealAmount(int level, float value)
        {
            _modifications[846622825, level] = new LevelObjectDataModification{Id = 846622825, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLifeStealAmountModified(int level)
        {
            return _modifications.ContainsKey(846622825, level);
        }

        private int GetDataAmountIsRawValueRaw(int level)
        {
            return _modifications.GetModification(863400041, level).ValueAsInt;
        }

        private void SetDataAmountIsRawValueRaw(int level, int value)
        {
            _modifications[863400041, level] = new LevelObjectDataModification{Id = 863400041, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAmountIsRawValueModified(int level)
        {
            return _modifications.ContainsKey(863400041, level);
        }

        private bool GetDataAmountIsRawValue(int level)
        {
            return GetDataAmountIsRawValueRaw(level).ToBool(this);
        }

        private void SetDataAmountIsRawValue(int level, bool value)
        {
            SetDataAmountIsRawValueRaw(level, value.ToRaw(null, null));
        }
    }
}