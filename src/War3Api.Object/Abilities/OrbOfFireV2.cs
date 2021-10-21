using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class OrbOfFireV2 : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ObjectProperty<int>> _dataEnabledAttackIndex;
        private readonly Lazy<ObjectProperty<float>> _dataHealingMultiplier;
        public OrbOfFireV2(): base(845564225)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
        }

        public OrbOfFireV2(int newId): base(845564225, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
        }

        public OrbOfFireV2(string newRawcode): base(845564225, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
        }

        public OrbOfFireV2(ObjectDatabase db): base(845564225, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
        }

        public OrbOfFireV2(int newId, ObjectDatabase db): base(845564225, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
        }

        public OrbOfFireV2(string newRawcode, ObjectDatabase db): base(845564225, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ObjectProperty<int> DataEnabledAttackIndex => _dataEnabledAttackIndex.Value;
        public ObjectProperty<float> DataHealingMultiplier => _dataHealingMultiplier.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications[1835099209, level].ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[1835099209, level] = new LevelObjectDataModification{Id = 1835099209, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataEnabledAttackIndex(int level)
        {
            return _modifications[895643465, level].ValueAsInt;
        }

        private void SetDataEnabledAttackIndex(int level, int value)
        {
            _modifications[895643465, level] = new LevelObjectDataModification{Id = 895643465, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataHealingMultiplier(int level)
        {
            return _modifications[1919315785, level].ValueAsFloat;
        }

        private void SetDataHealingMultiplier(int level, float value)
        {
            _modifications[1919315785, level] = new LevelObjectDataModification{Id = 1919315785, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}