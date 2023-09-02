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
    public sealed class OrbOfDarkness : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataEnabledAttackIndex;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataEnabledAttackIndexModified;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToHitUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToHitUnitsModified;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToHitHeros;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToHitHerosModified;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToHitSummons;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToHitSummonsModified;
        private readonly Lazy<ObjectProperty<string>> _dataEffectAbilityRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataEffectAbilityModified;
        private readonly Lazy<ObjectProperty<Ability>> _dataEffectAbility;
        public OrbOfDarkness(): base(1717848385)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _isDataChanceToHitUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitUnitsModified));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _isDataChanceToHitHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitHerosModified));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _isDataChanceToHitSummonsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitSummonsModified));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _isDataEffectAbilityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectAbilityModified));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public OrbOfDarkness(int newId): base(1717848385, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _isDataChanceToHitUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitUnitsModified));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _isDataChanceToHitHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitHerosModified));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _isDataChanceToHitSummonsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitSummonsModified));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _isDataEffectAbilityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectAbilityModified));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public OrbOfDarkness(string newRawcode): base(1717848385, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _isDataChanceToHitUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitUnitsModified));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _isDataChanceToHitHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitHerosModified));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _isDataChanceToHitSummonsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitSummonsModified));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _isDataEffectAbilityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectAbilityModified));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public OrbOfDarkness(ObjectDatabaseBase db): base(1717848385, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _isDataChanceToHitUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitUnitsModified));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _isDataChanceToHitHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitHerosModified));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _isDataChanceToHitSummonsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitSummonsModified));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _isDataEffectAbilityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectAbilityModified));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public OrbOfDarkness(int newId, ObjectDatabaseBase db): base(1717848385, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _isDataChanceToHitUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitUnitsModified));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _isDataChanceToHitHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitHerosModified));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _isDataChanceToHitSummonsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitSummonsModified));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _isDataEffectAbilityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectAbilityModified));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public OrbOfDarkness(string newRawcode, ObjectDatabaseBase db): base(1717848385, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataChanceToHitUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitUnits, SetDataChanceToHitUnits));
            _isDataChanceToHitUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitUnitsModified));
            _dataChanceToHitHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitHeros, SetDataChanceToHitHeros));
            _isDataChanceToHitHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitHerosModified));
            _dataChanceToHitSummons = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToHitSummons, SetDataChanceToHitSummons));
            _isDataChanceToHitSummonsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToHitSummonsModified));
            _dataEffectAbilityRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataEffectAbilityRaw, SetDataEffectAbilityRaw));
            _isDataEffectAbilityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectAbilityModified));
            _dataEffectAbility = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataEffectAbility, SetDataEffectAbility));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<int> DataEnabledAttackIndex => _dataEnabledAttackIndex.Value;
        public ReadOnlyObjectProperty<bool> IsDataEnabledAttackIndexModified => _isDataEnabledAttackIndexModified.Value;
        public ObjectProperty<float> DataChanceToHitUnits => _dataChanceToHitUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToHitUnitsModified => _isDataChanceToHitUnitsModified.Value;
        public ObjectProperty<float> DataChanceToHitHeros => _dataChanceToHitHeros.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToHitHerosModified => _isDataChanceToHitHerosModified.Value;
        public ObjectProperty<float> DataChanceToHitSummons => _dataChanceToHitSummons.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToHitSummonsModified => _isDataChanceToHitSummonsModified.Value;
        public ObjectProperty<string> DataEffectAbilityRaw => _dataEffectAbilityRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataEffectAbilityModified => _isDataEffectAbilityModified.Value;
        public ObjectProperty<Ability> DataEffectAbility => _dataEffectAbility.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications.GetModification(1835099209, level).ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[1835099209, level] = new LevelObjectDataModification{Id = 1835099209, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageBonusModified(int level)
        {
            return _modifications.ContainsKey(1835099209, level);
        }

        private int GetDataEnabledAttackIndex(int level)
        {
            return _modifications.GetModification(895643465, level).ValueAsInt;
        }

        private void SetDataEnabledAttackIndex(int level, int value)
        {
            _modifications[895643465, level] = new LevelObjectDataModification{Id = 895643465, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataEnabledAttackIndexModified(int level)
        {
            return _modifications.ContainsKey(895643465, level);
        }

        private float GetDataChanceToHitUnits(int level)
        {
            return _modifications.GetModification(845311817, level).ValueAsFloat;
        }

        private void SetDataChanceToHitUnits(int level, float value)
        {
            _modifications[845311817, level] = new LevelObjectDataModification{Id = 845311817, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataChanceToHitUnitsModified(int level)
        {
            return _modifications.ContainsKey(845311817, level);
        }

        private float GetDataChanceToHitHeros(int level)
        {
            return _modifications.GetModification(862089033, level).ValueAsFloat;
        }

        private void SetDataChanceToHitHeros(int level, float value)
        {
            _modifications[862089033, level] = new LevelObjectDataModification{Id = 862089033, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataChanceToHitHerosModified(int level)
        {
            return _modifications.ContainsKey(862089033, level);
        }

        private float GetDataChanceToHitSummons(int level)
        {
            return _modifications.GetModification(878866249, level).ValueAsFloat;
        }

        private void SetDataChanceToHitSummons(int level, float value)
        {
            _modifications[878866249, level] = new LevelObjectDataModification{Id = 878866249, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataChanceToHitSummonsModified(int level)
        {
            return _modifications.ContainsKey(878866249, level);
        }

        private string GetDataEffectAbilityRaw(int level)
        {
            return _modifications.GetModification(1969385289, level).ValueAsString;
        }

        private void SetDataEffectAbilityRaw(int level, string value)
        {
            _modifications[1969385289, level] = new LevelObjectDataModification{Id = 1969385289, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataEffectAbilityModified(int level)
        {
            return _modifications.ContainsKey(1969385289, level);
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