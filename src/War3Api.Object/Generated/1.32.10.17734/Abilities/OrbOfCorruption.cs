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
    public sealed class OrbOfCorruption : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDamageBonusDice;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusDiceModified;
        private readonly Lazy<ObjectProperty<int>> _dataArmorPenalty;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataArmorPenaltyModified;
        private readonly Lazy<ObjectProperty<int>> _dataEnabledAttackIndex;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataEnabledAttackIndexModified;
        public OrbOfCorruption(): base(1650673985)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public OrbOfCorruption(int newId): base(1650673985, newId)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public OrbOfCorruption(string newRawcode): base(1650673985, newRawcode)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public OrbOfCorruption(ObjectDatabaseBase db): base(1650673985, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public OrbOfCorruption(int newId, ObjectDatabaseBase db): base(1650673985, newId, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public OrbOfCorruption(string newRawcode, ObjectDatabaseBase db): base(1650673985, newRawcode, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _isDataDamageBonusDiceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusDiceModified));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _isDataArmorPenaltyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorPenaltyModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
        }

        public ObjectProperty<int> DataDamageBonusDice => _dataDamageBonusDice.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusDiceModified => _isDataDamageBonusDiceModified.Value;
        public ObjectProperty<int> DataArmorPenalty => _dataArmorPenalty.Value;
        public ReadOnlyObjectProperty<bool> IsDataArmorPenaltyModified => _isDataArmorPenaltyModified.Value;
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

        private int GetDataArmorPenalty(int level)
        {
            return _modifications.GetModification(1886544201, level).ValueAsInt;
        }

        private void SetDataArmorPenalty(int level, int value)
        {
            _modifications[1886544201, level] = new LevelObjectDataModification{Id = 1886544201, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataArmorPenaltyModified(int level)
        {
            return _modifications.ContainsKey(1886544201, level);
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