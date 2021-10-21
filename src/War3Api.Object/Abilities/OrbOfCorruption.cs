using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class OrbOfCorruption : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDamageBonusDice;
        private readonly Lazy<ObjectProperty<int>> _dataArmorPenalty;
        private readonly Lazy<ObjectProperty<int>> _dataEnabledAttackIndex;
        public OrbOfCorruption(): base(1650673985)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public OrbOfCorruption(int newId): base(1650673985, newId)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public OrbOfCorruption(string newRawcode): base(1650673985, newRawcode)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public OrbOfCorruption(ObjectDatabase db): base(1650673985, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public OrbOfCorruption(int newId, ObjectDatabase db): base(1650673985, newId, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public OrbOfCorruption(string newRawcode, ObjectDatabase db): base(1650673985, newRawcode, db)
        {
            _dataDamageBonusDice = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageBonusDice, SetDataDamageBonusDice));
            _dataArmorPenalty = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataArmorPenalty, SetDataArmorPenalty));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
        }

        public ObjectProperty<int> DataDamageBonusDice => _dataDamageBonusDice.Value;
        public ObjectProperty<int> DataArmorPenalty => _dataArmorPenalty.Value;
        public ObjectProperty<int> DataEnabledAttackIndex => _dataEnabledAttackIndex.Value;
        private int GetDataDamageBonusDice(int level)
        {
            return _modifications[1667851337, level].ValueAsInt;
        }

        private void SetDataDamageBonusDice(int level, int value)
        {
            _modifications[1667851337, level] = new LevelObjectDataModification{Id = 1667851337, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataArmorPenalty(int level)
        {
            return _modifications[1886544201, level].ValueAsInt;
        }

        private void SetDataArmorPenalty(int level, int value)
        {
            _modifications[1886544201, level] = new LevelObjectDataModification{Id = 1886544201, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
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