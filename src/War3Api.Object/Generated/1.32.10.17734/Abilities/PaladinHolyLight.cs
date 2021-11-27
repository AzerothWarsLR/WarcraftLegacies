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
    public sealed class PaladinHolyLight : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAmountHealedDamaged;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAmountHealedDamagedModified;
        public PaladinHolyLight(): base(1651001409)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
            _isDataAmountHealedDamagedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountHealedDamagedModified));
        }

        public PaladinHolyLight(int newId): base(1651001409, newId)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
            _isDataAmountHealedDamagedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountHealedDamagedModified));
        }

        public PaladinHolyLight(string newRawcode): base(1651001409, newRawcode)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
            _isDataAmountHealedDamagedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountHealedDamagedModified));
        }

        public PaladinHolyLight(ObjectDatabaseBase db): base(1651001409, db)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
            _isDataAmountHealedDamagedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountHealedDamagedModified));
        }

        public PaladinHolyLight(int newId, ObjectDatabaseBase db): base(1651001409, newId, db)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
            _isDataAmountHealedDamagedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountHealedDamagedModified));
        }

        public PaladinHolyLight(string newRawcode, ObjectDatabaseBase db): base(1651001409, newRawcode, db)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
            _isDataAmountHealedDamagedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountHealedDamagedModified));
        }

        public ObjectProperty<float> DataAmountHealedDamaged => _dataAmountHealedDamaged.Value;
        public ReadOnlyObjectProperty<bool> IsDataAmountHealedDamagedModified => _isDataAmountHealedDamagedModified.Value;
        private float GetDataAmountHealedDamaged(int level)
        {
            return _modifications.GetModification(828532808, level).ValueAsFloat;
        }

        private void SetDataAmountHealedDamaged(int level, float value)
        {
            _modifications[828532808, level] = new LevelObjectDataModification{Id = 828532808, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAmountHealedDamagedModified(int level)
        {
            return _modifications.ContainsKey(828532808, level);
        }
    }
}