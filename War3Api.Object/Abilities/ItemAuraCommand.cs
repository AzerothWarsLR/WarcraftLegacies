using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemAuraCommand : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataMeleeBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMeleeBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRangedBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRangedBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataFlatBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFlatBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackDamageIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackDamageIncreaseModified;
        public ItemAuraCommand(): base(1684228417)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
        }

        public ItemAuraCommand(int newId): base(1684228417, newId)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
        }

        public ItemAuraCommand(string newRawcode): base(1684228417, newRawcode)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
        }

        public ItemAuraCommand(ObjectDatabase db): base(1684228417, db)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
        }

        public ItemAuraCommand(int newId, ObjectDatabase db): base(1684228417, newId, db)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
        }

        public ItemAuraCommand(string newRawcode, ObjectDatabase db): base(1684228417, newRawcode, db)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
        }

        public ObjectProperty<bool> DataMeleeBonus => _dataMeleeBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataMeleeBonusModified => _isDataMeleeBonusModified.Value;
        public ObjectProperty<bool> DataRangedBonus => _dataRangedBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataRangedBonusModified => _isDataRangedBonusModified.Value;
        public ObjectProperty<bool> DataFlatBonus => _dataFlatBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataFlatBonusModified => _isDataFlatBonusModified.Value;
        public ObjectProperty<float> DataAttackDamageIncrease => _dataAttackDamageIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackDamageIncreaseModified => _isDataAttackDamageIncreaseModified.Value;
        private bool GetDataMeleeBonus(int level)
        {
            return _modifications[846356805, level].ValueAsBool;
        }

        private void SetDataMeleeBonus(int level, bool value)
        {
            _modifications[846356805, level] = new LevelObjectDataModification{Id = 846356805, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMeleeBonusModified(int level)
        {
            return _modifications.ContainsKey(846356805, level);
        }

        private bool GetDataRangedBonus(int level)
        {
            return _modifications[863134021, level].ValueAsBool;
        }

        private void SetDataRangedBonus(int level, bool value)
        {
            _modifications[863134021, level] = new LevelObjectDataModification{Id = 863134021, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataRangedBonusModified(int level)
        {
            return _modifications.ContainsKey(863134021, level);
        }

        private bool GetDataFlatBonus(int level)
        {
            return _modifications[879911237, level].ValueAsBool;
        }

        private void SetDataFlatBonus(int level, bool value)
        {
            _modifications[879911237, level] = new LevelObjectDataModification{Id = 879911237, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataFlatBonusModified(int level)
        {
            return _modifications.ContainsKey(879911237, level);
        }

        private float GetDataAttackDamageIncrease(int level)
        {
            return _modifications[828596547, level].ValueAsFloat;
        }

        private void SetDataAttackDamageIncrease(int level, float value)
        {
            _modifications[828596547, level] = new LevelObjectDataModification{Id = 828596547, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAttackDamageIncreaseModified(int level)
        {
            return _modifications.ContainsKey(828596547, level);
        }
    }
}