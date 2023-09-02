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
    public sealed class OrbOfLightningOld : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDamageBonusDice;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusDiceModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataEnabledAttackIndex;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataEnabledAttackIndexModified;
        public OrbOfLightningOld(): base(1651263809)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public OrbOfLightningOld(int newId): base(1651263809, newId)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public OrbOfLightningOld(string newRawcode): base(1651263809, newRawcode)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public OrbOfLightningOld(ObjectDatabaseBase db): base(1651263809, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public OrbOfLightningOld(int newId, ObjectDatabaseBase db): base(1651263809, newId, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public OrbOfLightningOld(string newRawcode, ObjectDatabaseBase db): base(1651263809, newRawcode, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public ObjectProperty<int> DataDamageBonusDice => _dataDamageBonusDice.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusDiceModified => _isDataDamageBonusDiceModified.Value;
        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<int> DataEnabledAttackIndex => _dataEnabledAttackIndex.Value;
        public ReadOnlyObjectProperty<bool> IsDataEnabledAttackIndexModified => _isDataEnabledAttackIndexModified.Value;
        private int GetDataDamageBonusDice(int level)
        {
            return _modifications.GetModification(1667851337, level).ValueAsInt;
        }

        private void SetDataDamageBonusDice(int level, int value)
        {
            _modifications[1667851337, level] = new LevelObjectDataModification{Id = 1667851337, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageBonusDiceModified(int level)
        {
            return _modifications.ContainsKey(1667851337, level);
        }

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
    }
}