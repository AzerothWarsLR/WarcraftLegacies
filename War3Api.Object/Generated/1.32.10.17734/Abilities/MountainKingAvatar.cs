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
    public sealed class MountainKingAvatar : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDefenseBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDefenseBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataHitPointBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMagicDamageReductionModified;
        public MountainKingAvatar(): base(1986086977)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _isDataHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
        }

        public MountainKingAvatar(int newId): base(1986086977, newId)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _isDataHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
        }

        public MountainKingAvatar(string newRawcode): base(1986086977, newRawcode)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _isDataHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
        }

        public MountainKingAvatar(ObjectDatabaseBase db): base(1986086977, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _isDataHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
        }

        public MountainKingAvatar(int newId, ObjectDatabaseBase db): base(1986086977, newId, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _isDataHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
        }

        public MountainKingAvatar(string newRawcode, ObjectDatabaseBase db): base(1986086977, newRawcode, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _isDataHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointBonusModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
        }

        public ObjectProperty<float> DataDefenseBonus => _dataDefenseBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDefenseBonusModified => _isDataDefenseBonusModified.Value;
        public ObjectProperty<float> DataHitPointBonus => _dataHitPointBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointBonusModified => _isDataHitPointBonusModified.Value;
        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<float> DataMagicDamageReduction => _dataMagicDamageReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataMagicDamageReductionModified => _isDataMagicDamageReductionModified.Value;
        private float GetDataDefenseBonus(int level)
        {
            return _modifications.GetModification(829841736, level).ValueAsFloat;
        }

        private void SetDataDefenseBonus(int level, float value)
        {
            _modifications[829841736, level] = new LevelObjectDataModification{Id = 829841736, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDefenseBonusModified(int level)
        {
            return _modifications.ContainsKey(829841736, level);
        }

        private float GetDataHitPointBonus(int level)
        {
            return _modifications.GetModification(846618952, level).ValueAsFloat;
        }

        private void SetDataHitPointBonus(int level, float value)
        {
            _modifications[846618952, level] = new LevelObjectDataModification{Id = 846618952, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataHitPointBonusModified(int level)
        {
            return _modifications.ContainsKey(846618952, level);
        }

        private float GetDataDamageBonus(int level)
        {
            return _modifications.GetModification(863396168, level).ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[863396168, level] = new LevelObjectDataModification{Id = 863396168, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageBonusModified(int level)
        {
            return _modifications.ContainsKey(863396168, level);
        }

        private float GetDataMagicDamageReduction(int level)
        {
            return _modifications.GetModification(880173384, level).ValueAsFloat;
        }

        private void SetDataMagicDamageReduction(int level, float value)
        {
            _modifications[880173384, level] = new LevelObjectDataModification{Id = 880173384, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataMagicDamageReductionModified(int level)
        {
            return _modifications.ContainsKey(880173384, level);
        }
    }
}