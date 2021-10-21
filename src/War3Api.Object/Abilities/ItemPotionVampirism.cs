using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemPotionVampirism : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ObjectProperty<float>> _dataLifeStealAmount;
        private readonly Lazy<ObjectProperty<bool>> _dataAmountIsRawValue;
        public ItemPotionVampirism(): base(1987070273)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ItemPotionVampirism(int newId): base(1987070273, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ItemPotionVampirism(string newRawcode): base(1987070273, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ItemPotionVampirism(ObjectDatabase db): base(1987070273, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ItemPotionVampirism(int newId, ObjectDatabase db): base(1987070273, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ItemPotionVampirism(string newRawcode, ObjectDatabase db): base(1987070273, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataLifeStealAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStealAmount, SetDataLifeStealAmount));
            _dataAmountIsRawValue = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAmountIsRawValue, SetDataAmountIsRawValue));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ObjectProperty<float> DataLifeStealAmount => _dataLifeStealAmount.Value;
        public ObjectProperty<bool> DataAmountIsRawValue => _dataAmountIsRawValue.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications[829845609, level].ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[829845609, level] = new LevelObjectDataModification{Id = 829845609, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataLifeStealAmount(int level)
        {
            return _modifications[846622825, level].ValueAsFloat;
        }

        private void SetDataLifeStealAmount(int level, float value)
        {
            _modifications[846622825, level] = new LevelObjectDataModification{Id = 846622825, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetDataAmountIsRawValue(int level)
        {
            return _modifications[863400041, level].ValueAsBool;
        }

        private void SetDataAmountIsRawValue(int level, bool value)
        {
            _modifications[863400041, level] = new LevelObjectDataModification{Id = 863400041, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }
    }
}