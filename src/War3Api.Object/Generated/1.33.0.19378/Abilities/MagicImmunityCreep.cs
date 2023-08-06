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
    public sealed class MagicImmunityCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMagicDamageFactorModified;
        public MagicImmunityCreep(): base(1768768321)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public MagicImmunityCreep(int newId): base(1768768321, newId)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public MagicImmunityCreep(string newRawcode): base(1768768321, newRawcode)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public MagicImmunityCreep(ObjectDatabaseBase db): base(1768768321, db)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public MagicImmunityCreep(int newId, ObjectDatabaseBase db): base(1768768321, newId, db)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public MagicImmunityCreep(string newRawcode, ObjectDatabaseBase db): base(1768768321, newRawcode, db)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public ObjectProperty<float> DataMagicDamageFactor => _dataMagicDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataMagicDamageFactorModified => _isDataMagicDamageFactorModified.Value;
        private float GetDataMagicDamageFactor(int level)
        {
            return _modifications.GetModification(829253997, level).ValueAsFloat;
        }

        private void SetDataMagicDamageFactor(int level, float value)
        {
            _modifications[829253997, level] = new LevelObjectDataModification{Id = 829253997, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMagicDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(829253997, level);
        }
    }
}