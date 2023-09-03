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
    public sealed class VampiricAuraCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAttackDamageStolen;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackDamageStolenModified;
        public VampiricAuraCreep(): base(1886798657)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public VampiricAuraCreep(int newId): base(1886798657, newId)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public VampiricAuraCreep(string newRawcode): base(1886798657, newRawcode)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public VampiricAuraCreep(ObjectDatabaseBase db): base(1886798657, db)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public VampiricAuraCreep(int newId, ObjectDatabaseBase db): base(1886798657, newId, db)
        {
            _dataAttackDamageStolen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackDamageStolen, SetDataAttackDamageStolen));
            _isDataAttackDamageStolenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackDamageStolenModified));
        }

        public VampiricAuraCreep(string newRawcode, ObjectDatabaseBase db): base(1886798657, newRawcode, db)
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