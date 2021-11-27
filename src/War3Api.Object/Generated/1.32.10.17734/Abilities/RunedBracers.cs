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
    public sealed class RunedBracers : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageReductionModified;
        public RunedBracers(): base(1920158017)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public RunedBracers(int newId): base(1920158017, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public RunedBracers(string newRawcode): base(1920158017, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public RunedBracers(ObjectDatabaseBase db): base(1920158017, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public RunedBracers(int newId, ObjectDatabaseBase db): base(1920158017, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public RunedBracers(string newRawcode, ObjectDatabaseBase db): base(1920158017, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<float> DataDamageReduction => _dataDamageReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageReductionModified => _isDataDamageReductionModified.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications.GetModification(829584233, level).ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[829584233, level] = new LevelObjectDataModification{Id = 829584233, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageBonusModified(int level)
        {
            return _modifications.ContainsKey(829584233, level);
        }

        private float GetDataDamageReduction(int level)
        {
            return _modifications.GetModification(846361449, level).ValueAsFloat;
        }

        private void SetDataDamageReduction(int level, float value)
        {
            _modifications[846361449, level] = new LevelObjectDataModification{Id = 846361449, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageReductionModified(int level)
        {
            return _modifications.ContainsKey(846361449, level);
        }
    }
}