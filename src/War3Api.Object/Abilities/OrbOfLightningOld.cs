using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class OrbOfLightningOld : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDamageBonusDice;
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ObjectProperty<int>> _dataEnabledAttackIndex;
        public OrbOfLightningOld(): base(1651263809)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public OrbOfLightningOld(int newId): base(1651263809, newId)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public OrbOfLightningOld(string newRawcode): base(1651263809, newRawcode)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public OrbOfLightningOld(ObjectDatabase db): base(1651263809, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public OrbOfLightningOld(int newId, ObjectDatabase db): base(1651263809, newId, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public OrbOfLightningOld(string newRawcode, ObjectDatabase db): base(1651263809, newRawcode, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public ObjectProperty<int> DataDamageBonusDice => _dataDamageBonusDice.Value;
        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ObjectProperty<int> DataEnabledAttackIndex => _dataEnabledAttackIndex.Value;
        private int GetDataDamageBonusDice(int level)
        {
            return _modifications[1667851337, level].ValueAsInt;
        }

        private void SetDataDamageBonusDice(int level, int value)
        {
            _modifications[1667851337, level] = new LevelObjectDataModification{Id = 1667851337, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

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
    }
}