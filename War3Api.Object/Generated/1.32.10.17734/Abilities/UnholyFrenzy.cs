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
    public sealed class UnholyFrenzy : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerSecondModified;
        public UnholyFrenzy(): base(1718121793)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _isDataAttackSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedBonusModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public UnholyFrenzy(int newId): base(1718121793, newId)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _isDataAttackSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedBonusModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public UnholyFrenzy(string newRawcode): base(1718121793, newRawcode)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _isDataAttackSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedBonusModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public UnholyFrenzy(ObjectDatabaseBase db): base(1718121793, db)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _isDataAttackSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedBonusModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public UnholyFrenzy(int newId, ObjectDatabaseBase db): base(1718121793, newId, db)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _isDataAttackSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedBonusModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public UnholyFrenzy(string newRawcode, ObjectDatabaseBase db): base(1718121793, newRawcode, db)
        {
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _isDataAttackSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedBonusModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public ObjectProperty<float> DataAttackSpeedBonus => _dataAttackSpeedBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedBonusModified => _isDataAttackSpeedBonusModified.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerSecondModified => _isDataDamagePerSecondModified.Value;
        private float GetDataAttackSpeedBonus(int level)
        {
            return _modifications.GetModification(828794965, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedBonus(int level, float value)
        {
            _modifications[828794965, level] = new LevelObjectDataModification{Id = 828794965, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAttackSpeedBonusModified(int level)
        {
            return _modifications.ContainsKey(828794965, level);
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications.GetModification(845572181, level).ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[845572181, level] = new LevelObjectDataModification{Id = 845572181, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamagePerSecondModified(int level)
        {
            return _modifications.ContainsKey(845572181, level);
        }
    }
}