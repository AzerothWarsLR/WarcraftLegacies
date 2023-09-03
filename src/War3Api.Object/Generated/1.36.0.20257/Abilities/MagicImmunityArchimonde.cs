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
    public sealed class MagicImmunityArchimonde : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMagicDamageFactorModified;
        public MagicImmunityArchimonde(): base(846021441)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public MagicImmunityArchimonde(int newId): base(846021441, newId)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public MagicImmunityArchimonde(string newRawcode): base(846021441, newRawcode)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public MagicImmunityArchimonde(ObjectDatabaseBase db): base(846021441, db)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public MagicImmunityArchimonde(int newId, ObjectDatabaseBase db): base(846021441, newId, db)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
            _isDataMagicDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageFactorModified));
        }

        public MagicImmunityArchimonde(string newRawcode, ObjectDatabaseBase db): base(846021441, newRawcode, db)
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