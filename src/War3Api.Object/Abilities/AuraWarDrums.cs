using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AuraWarDrums : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataMeleeBonus;
        private readonly Lazy<ObjectProperty<bool>> _dataRangedBonus;
        private readonly Lazy<ObjectProperty<bool>> _dataFlatBonus;
        private readonly Lazy<ObjectProperty<float>> _dataAttackDamageIncrease;
        private readonly Lazy<ObjectProperty<bool>> _dataPlayChannelAnimation;
        public AuraWarDrums(): base(1651204417)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public AuraWarDrums(int newId): base(1651204417, newId)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public AuraWarDrums(string newRawcode): base(1651204417, newRawcode)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public AuraWarDrums(ObjectDatabase db): base(1651204417, db)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public AuraWarDrums(int newId, ObjectDatabase db): base(1651204417, newId, db)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public AuraWarDrums(string newRawcode, ObjectDatabase db): base(1651204417, newRawcode, db)
        {
            _dataMeleeBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMeleeBonus, SetDataMeleeBonus));
            _dataRangedBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRangedBonus, SetDataRangedBonus));
            _dataFlatBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataFlatBonus, SetDataFlatBonus));
            _dataAttackDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageIncrease, SetDataAttackDamageIncrease));
            _dataPlayChannelAnimation = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPlayChannelAnimation, SetDataPlayChannelAnimation));
        }

        public ObjectProperty<bool> DataMeleeBonus => _dataMeleeBonus.Value;
        public ObjectProperty<bool> DataRangedBonus => _dataRangedBonus.Value;
        public ObjectProperty<bool> DataFlatBonus => _dataFlatBonus.Value;
        public ObjectProperty<float> DataAttackDamageIncrease => _dataAttackDamageIncrease.Value;
        public ObjectProperty<bool> DataPlayChannelAnimation => _dataPlayChannelAnimation.Value;
        private bool GetDataMeleeBonus(int level)
        {
            return _modifications[846356805, level].ValueAsBool;
        }

        private void SetDataMeleeBonus(int level, bool value)
        {
            _modifications[846356805, level] = new LevelObjectDataModification{Id = 846356805, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetDataRangedBonus(int level)
        {
            return _modifications[863134021, level].ValueAsBool;
        }

        private void SetDataRangedBonus(int level, bool value)
        {
            _modifications[863134021, level] = new LevelObjectDataModification{Id = 863134021, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataFlatBonus(int level)
        {
            return _modifications[879911237, level].ValueAsBool;
        }

        private void SetDataFlatBonus(int level, bool value)
        {
            _modifications[879911237, level] = new LevelObjectDataModification{Id = 879911237, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataAttackDamageIncrease(int level)
        {
            return _modifications[828533569, level].ValueAsFloat;
        }

        private void SetDataAttackDamageIncrease(int level, float value)
        {
            _modifications[828533569, level] = new LevelObjectDataModification{Id = 828533569, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataPlayChannelAnimation(int level)
        {
            return _modifications[845310785, level].ValueAsBool;
        }

        private void SetDataPlayChannelAnimation(int level, bool value)
        {
            _modifications[845310785, level] = new LevelObjectDataModification{Id = 845310785, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }
    }
}