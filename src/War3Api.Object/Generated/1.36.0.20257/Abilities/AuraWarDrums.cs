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
    public sealed class AuraWarDrums : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMeleeBonusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMeleeBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataMeleeBonus;
        private readonly Lazy<ObjectProperty<int>> _dataRangedBonusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRangedBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRangedBonus;
        private readonly Lazy<ObjectProperty<int>> _dataFlatBonusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFlatBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataFlatBonus;
        private readonly Lazy<ObjectProperty<float>> _dataAttackDamageIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackDamageIncreaseModified;
        private readonly Lazy<ObjectProperty<int>> _dataPlayChannelAnimationRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPlayChannelAnimationModified;
        private readonly Lazy<ObjectProperty<bool>> _dataPlayChannelAnimation;
        public AuraWarDrums(): base(1651204417)
        {
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
            _dataPlayChannelAnimationRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPlayChannelAnimationRaw, SetDataPlayChannelAnimationRaw));
            _isDataPlayChannelAnimationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlayChannelAnimationModified));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public AuraWarDrums(int newId): base(1651204417, newId)
        {
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
            _dataPlayChannelAnimationRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPlayChannelAnimationRaw, SetDataPlayChannelAnimationRaw));
            _isDataPlayChannelAnimationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlayChannelAnimationModified));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public AuraWarDrums(string newRawcode): base(1651204417, newRawcode)
        {
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
            _dataPlayChannelAnimationRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPlayChannelAnimationRaw, SetDataPlayChannelAnimationRaw));
            _isDataPlayChannelAnimationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlayChannelAnimationModified));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public AuraWarDrums(ObjectDatabaseBase db): base(1651204417, db)
        {
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
            _dataPlayChannelAnimationRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPlayChannelAnimationRaw, SetDataPlayChannelAnimationRaw));
            _isDataPlayChannelAnimationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlayChannelAnimationModified));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public AuraWarDrums(int newId, ObjectDatabaseBase db): base(1651204417, newId, db)
        {
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
            _dataPlayChannelAnimationRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPlayChannelAnimationRaw, SetDataPlayChannelAnimationRaw));
            _isDataPlayChannelAnimationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlayChannelAnimationModified));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public AuraWarDrums(string newRawcode, ObjectDatabaseBase db): base(1651204417, newRawcode, db)
        {
            _dataMeleeBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMeleeBonusRaw, SetDataMeleeBonusRaw));
            _isDataMeleeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeBonusModified));
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRangedBonusRaw, SetDataRangedBonusRaw));
            _isDataRangedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRangedBonusModified));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlatBonusRaw, SetDataFlatBonusRaw));
            _isDataFlatBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlatBonusModified));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _isDataAttackDamageIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageIncreaseModified));
            _dataPlayChannelAnimationRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPlayChannelAnimationRaw, SetDataPlayChannelAnimationRaw));
            _isDataPlayChannelAnimationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlayChannelAnimationModified));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public ObjectProperty<int> DataMeleeBonusRaw => _dataMeleeBonusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataMeleeBonusModified => _isDataMeleeBonusModified.Value;
        public ObjectProperty<bool> DataMeleeBonus => _dataMeleeBonus.Value;
        public ObjectProperty<int> DataRangedBonusRaw => _dataRangedBonusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataRangedBonusModified => _isDataRangedBonusModified.Value;
        public ObjectProperty<bool> DataRangedBonus => _dataRangedBonus.Value;
        public ObjectProperty<int> DataFlatBonusRaw => _dataFlatBonusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataFlatBonusModified => _isDataFlatBonusModified.Value;
        public ObjectProperty<bool> DataFlatBonus => _dataFlatBonus.Value;
        public ObjectProperty<float> DataAttackDamageIncrease => _dataAttackDamageIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackDamageIncreaseModified => _isDataAttackDamageIncreaseModified.Value;
        public ObjectProperty<int> DataPlayChannelAnimationRaw => _dataPlayChannelAnimationRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPlayChannelAnimationModified => _isDataPlayChannelAnimationModified.Value;
        public ObjectProperty<bool> DataPlayChannelAnimation => _dataPlayChannelAnimation.Value;
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

        private float GetDataAttackDamageIncrease(int level)
        {
            return _modifications.GetModification(828533569, level).ValueAsFloat;
        }

        private void SetDataAttackDamageIncrease(int level, float value)
        {
            _modifications[828533569, level] = new LevelObjectDataModification{Id = 828533569, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAttackDamageIncreaseModified(int level)
        {
            return _modifications.ContainsKey(828533569, level);
        }

        private int GetDataPlayChannelAnimationRaw(int level)
        {
            return _modifications.GetModification(845310785, level).ValueAsInt;
        }

        private void SetDataPlayChannelAnimationRaw(int level, int value)
        {
            _modifications[845310785, level] = new LevelObjectDataModification{Id = 845310785, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataPlayChannelAnimationModified(int level)
        {
            return _modifications.ContainsKey(845310785, level);
        }

        private bool GetDataPlayChannelAnimation(int level)
        {
            return GetDataPlayChannelAnimationRaw(level).ToBool(this);
        }

        private void SetDataPlayChannelAnimation(int level, bool value)
        {
            SetDataPlayChannelAnimationRaw(level, value.ToRaw(0, 1));
        }
    }
}