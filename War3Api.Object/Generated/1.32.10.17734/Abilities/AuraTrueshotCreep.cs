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
    public sealed class AuraTrueshotCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataMeleeBonusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMeleeBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataMeleeBonus;
        private readonly Lazy<ObjectProperty<int>> _dataRangedBonusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRangedBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRangedBonus;
        private readonly Lazy<ObjectProperty<int>> _dataFlatBonusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFlatBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataFlatBonus;
        public AuraTrueshotCreep(): base(1952531265)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
        }

        public AuraTrueshotCreep(int newId): base(1952531265, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
        }

        public AuraTrueshotCreep(string newRawcode): base(1952531265, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
        }

        public AuraTrueshotCreep(ObjectDatabaseBase db): base(1952531265, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
        }

        public AuraTrueshotCreep(int newId, ObjectDatabaseBase db): base(1952531265, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
        }

        public AuraTrueshotCreep(string newRawcode, ObjectDatabaseBase db): base(1952531265, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<int> DataMeleeBonusRaw => _dataMeleeBonusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataMeleeBonusModified => _isDataMeleeBonusModified.Value;
        public ObjectProperty<bool> DataMeleeBonus => _dataMeleeBonus.Value;
        public ObjectProperty<int> DataRangedBonusRaw => _dataRangedBonusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataRangedBonusModified => _isDataRangedBonusModified.Value;
        public ObjectProperty<bool> DataRangedBonus => _dataRangedBonus.Value;
        public ObjectProperty<int> DataFlatBonusRaw => _dataFlatBonusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataFlatBonusModified => _isDataFlatBonusModified.Value;
        public ObjectProperty<bool> DataFlatBonus => _dataFlatBonus.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications.GetModification(829579589, level).ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[829579589, level] = new LevelObjectDataModification{Id = 829579589, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageBonusModified(int level)
        {
            return _modifications.ContainsKey(829579589, level);
        }

        private int GetDataMeleeBonusRaw(int level)
        {
            return _modifications.GetModification(846356805, level).ValueAsInt;
        }

        private void SetDataMeleeBonusRaw(int level, int value)
        {
            _modifications[846356805, level] = new LevelObjectDataModification{Id = 846356805, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMeleeBonusModified(int level)
        {
            return _modifications.ContainsKey(846356805, level);
        }

        private bool GetDataMeleeBonus(int level)
        {
            return GetDataMeleeBonusRaw(level).ToBool(this);
        }

        private void SetDataMeleeBonus(int level, bool value)
        {
            SetDataMeleeBonusRaw(level, value.ToRaw(0, 1));
        }

        private int GetDataRangedBonusRaw(int level)
        {
            return _modifications.GetModification(863134021, level).ValueAsInt;
        }

        private void SetDataRangedBonusRaw(int level, int value)
        {
            _modifications[863134021, level] = new LevelObjectDataModification{Id = 863134021, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataRangedBonusModified(int level)
        {
            return _modifications.ContainsKey(863134021, level);
        }

        private bool GetDataRangedBonus(int level)
        {
            return GetDataRangedBonusRaw(level).ToBool(this);
        }

        private void SetDataRangedBonus(int level, bool value)
        {
            SetDataRangedBonusRaw(level, value.ToRaw(0, 1));
        }

        private int GetDataFlatBonusRaw(int level)
        {
            return _modifications.GetModification(879911237, level).ValueAsInt;
        }

        private void SetDataFlatBonusRaw(int level, int value)
        {
            _modifications[879911237, level] = new LevelObjectDataModification{Id = 879911237, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataFlatBonusModified(int level)
        {
            return _modifications.ContainsKey(879911237, level);
        }

        private bool GetDataFlatBonus(int level)
        {
            return GetDataFlatBonusRaw(level).ToBool(this);
        }

        private void SetDataFlatBonus(int level, bool value)
        {
            SetDataFlatBonusRaw(level, value.ToRaw(0, 1));
        }
    }
}