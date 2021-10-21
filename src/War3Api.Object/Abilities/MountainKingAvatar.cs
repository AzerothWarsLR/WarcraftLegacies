using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MountainKingAvatar : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDefenseBonus;
        private readonly Lazy<ObjectProperty<float>> _dataHitPointBonus;
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageReduction;
        public MountainKingAvatar(): base(1986086977)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public MountainKingAvatar(int newId): base(1986086977, newId)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public MountainKingAvatar(string newRawcode): base(1986086977, newRawcode)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public MountainKingAvatar(ObjectDatabase db): base(1986086977, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public MountainKingAvatar(int newId, ObjectDatabase db): base(1986086977, newId, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public MountainKingAvatar(string newRawcode, ObjectDatabase db): base(1986086977, newRawcode, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointBonus, SetDataHitPointBonus));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public ObjectProperty<float> DataDefenseBonus => _dataDefenseBonus.Value;
        public ObjectProperty<float> DataHitPointBonus => _dataHitPointBonus.Value;
        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ObjectProperty<float> DataMagicDamageReduction => _dataMagicDamageReduction.Value;
        private float GetDataDefenseBonus(int level)
        {
            return _modifications[829841736, level].ValueAsFloat;
        }

        private void SetDataDefenseBonus(int level, float value)
        {
            _modifications[829841736, level] = new LevelObjectDataModification{Id = 829841736, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataHitPointBonus(int level)
        {
            return _modifications[846618952, level].ValueAsFloat;
        }

        private void SetDataHitPointBonus(int level, float value)
        {
            _modifications[846618952, level] = new LevelObjectDataModification{Id = 846618952, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamageBonus(int level)
        {
            return _modifications[863396168, level].ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[863396168, level] = new LevelObjectDataModification{Id = 863396168, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataMagicDamageReduction(int level)
        {
            return _modifications[880173384, level].ValueAsFloat;
        }

        private void SetDataMagicDamageReduction(int level, float value)
        {
            _modifications[880173384, level] = new LevelObjectDataModification{Id = 880173384, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}