using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class OrbOfLightning : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ObjectProperty<int>> _dataEnabledAttackIndex;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToHitUnits;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToHitHeros;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToHitSummons;
        private readonly Lazy<ObjectProperty<string>> _dataEffectAbilityRaw;
        private readonly Lazy<ObjectProperty<Ability>> _dataEffectAbility;
        public OrbOfLightning(): base(1819035969)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public OrbOfLightning(int newId): base(1819035969, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public OrbOfLightning(string newRawcode): base(1819035969, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public OrbOfLightning(ObjectDatabase db): base(1819035969, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public OrbOfLightning(int newId, ObjectDatabase db): base(1819035969, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public OrbOfLightning(string newRawcode, ObjectDatabase db): base(1819035969, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ObjectProperty<int> DataEnabledAttackIndex => _dataEnabledAttackIndex.Value;
        public ObjectProperty<float> DataChanceToHitUnits => _dataChanceToHitUnits.Value;
        public ObjectProperty<float> DataChanceToHitHeros => _dataChanceToHitHeros.Value;
        public ObjectProperty<float> DataChanceToHitSummons => _dataChanceToHitSummons.Value;
        public ObjectProperty<string> DataEffectAbilityRaw => _dataEffectAbilityRaw.Value;
        public ObjectProperty<Ability> DataEffectAbility => _dataEffectAbility.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications[1835099209, level].ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[1835099209, level] = new LevelObjectDataModification{Id = 1835099209, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataEnabledAttackIndex(int level)
        {
            return _modifications[895643465, level].ValueAsInt;
        }

        private void SetDataEnabledAttackIndex(int level, int value)
        {
            _modifications[895643465, level] = new LevelObjectDataModification{Id = 895643465, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataChanceToHitUnits(int level)
        {
            return _modifications[845311817, level].ValueAsFloat;
        }

        private void SetDataChanceToHitUnits(int level, float value)
        {
            _modifications[845311817, level] = new LevelObjectDataModification{Id = 845311817, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataChanceToHitHeros(int level)
        {
            return _modifications[862089033, level].ValueAsFloat;
        }

        private void SetDataChanceToHitHeros(int level, float value)
        {
            _modifications[862089033, level] = new LevelObjectDataModification{Id = 862089033, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataChanceToHitSummons(int level)
        {
            return _modifications[878866249, level].ValueAsFloat;
        }

        private void SetDataChanceToHitSummons(int level, float value)
        {
            _modifications[878866249, level] = new LevelObjectDataModification{Id = 878866249, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private string GetDataEffectAbilityRaw(int level)
        {
            return _modifications[1969385289, level].ValueAsString;
        }

        private void SetDataEffectAbilityRaw(int level, string value)
        {
            _modifications[1969385289, level] = new LevelObjectDataModification{Id = 1969385289, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private Ability GetDataEffectAbility(int level)
        {
            return GetDataEffectAbilityRaw(level).ToAbility(this);
        }

        private void SetDataEffectAbility(int level, Ability value)
        {
            SetDataEffectAbilityRaw(level, value.ToRaw(null, null));
        }
    }
}