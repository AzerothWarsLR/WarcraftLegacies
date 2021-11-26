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
    public sealed class ItemAuraVampiric : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAttackDamageStolen;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackDamageStolenModified;
        public ItemAuraVampiric(): base(1986087233)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public ItemAuraVampiric(int newId): base(1986087233, newId)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public ItemAuraVampiric(string newRawcode): base(1986087233, newRawcode)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public ItemAuraVampiric(ObjectDatabaseBase db): base(1986087233, db)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public ItemAuraVampiric(int newId, ObjectDatabaseBase db): base(1986087233, newId, db)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public ItemAuraVampiric(string newRawcode, ObjectDatabaseBase db): base(1986087233, newRawcode, db)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public ObjectProperty<float> DataAttackDamageStolen => _dataAttackDamageStolen.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackDamageStolenModified => _isDataAttackDamageStolenModified.Value;
        private float GetDataAttackDamageStolen(int level)
        {
            return _modifications.GetModification(829841749, level).ValueAsFloat;
        }

        private void SetDataAttackDamageStolen(int level, float value)
        {
            _modifications[829841749, level] = new LevelObjectDataModification{Id = 829841749, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAttackDamageStolenModified(int level)
        {
            return _modifications.ContainsKey(829841749, level);
        }
    }
}