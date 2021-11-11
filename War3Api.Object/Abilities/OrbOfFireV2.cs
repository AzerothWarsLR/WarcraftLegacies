using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class OrbOfFireV2 : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataEnabledAttackIndex;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataEnabledAttackIndexModified;
        private readonly Lazy<ObjectProperty<float>> _dataHealingMultiplier;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHealingMultiplierModified;
        public OrbOfFireV2(): base(845564225)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public OrbOfFireV2(int newId): base(845564225, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public OrbOfFireV2(string newRawcode): base(845564225, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public OrbOfFireV2(ObjectDatabase db): base(845564225, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public OrbOfFireV2(int newId, ObjectDatabase db): base(845564225, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public OrbOfFireV2(string newRawcode, ObjectDatabase db): base(845564225, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<int> DataEnabledAttackIndex => _dataEnabledAttackIndex.Value;
        public ReadOnlyObjectProperty<bool> IsDataEnabledAttackIndexModified => _isDataEnabledAttackIndexModified.Value;
        public ObjectProperty<float> DataHealingMultiplier => _dataHealingMultiplier.Value;
        public ReadOnlyObjectProperty<bool> IsDataHealingMultiplierModified => _isDataHealingMultiplierModified.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications[1835099209, level].ValueAsFloat;
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
            return _modifications[895643465, level].ValueAsInt;
        }

        private void SetDataEnabledAttackIndex(int level, int value)
        {
            _modifications[895643465, level] = new LevelObjectDataModification{Id = 895643465, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataEnabledAttackIndexModified(int level)
        {
            return _modifications.ContainsKey(895643465, level);
        }

        private float GetDataHealingMultiplier(int level)
        {
            return _modifications[1919315785, level].ValueAsFloat;
        }

        private void SetDataHealingMultiplier(int level, float value)
        {
            _modifications[1919315785, level] = new LevelObjectDataModification{Id = 1919315785, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataHealingMultiplierModified(int level)
        {
            return _modifications.ContainsKey(1919315785, level);
        }
    }
}