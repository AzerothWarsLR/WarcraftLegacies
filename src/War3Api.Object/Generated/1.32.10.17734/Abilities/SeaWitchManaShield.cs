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
    public sealed class SeaWitchManaShield : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaPerHitPoint;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaPerHitPointModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageAbsorbed;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageAbsorbedModified;
        public SeaWitchManaShield(): base(1936543297)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _isDataManaPerHitPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerHitPointModified));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
            _isDataDamageAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAbsorbedModified));
        }

        public SeaWitchManaShield(int newId): base(1936543297, newId)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _isDataManaPerHitPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerHitPointModified));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
            _isDataDamageAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAbsorbedModified));
        }

        public SeaWitchManaShield(string newRawcode): base(1936543297, newRawcode)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _isDataManaPerHitPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerHitPointModified));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
            _isDataDamageAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAbsorbedModified));
        }

        public SeaWitchManaShield(ObjectDatabaseBase db): base(1936543297, db)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _isDataManaPerHitPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerHitPointModified));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
            _isDataDamageAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAbsorbedModified));
        }

        public SeaWitchManaShield(int newId, ObjectDatabaseBase db): base(1936543297, newId, db)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _isDataManaPerHitPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerHitPointModified));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
            _isDataDamageAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAbsorbedModified));
        }

        public SeaWitchManaShield(string newRawcode, ObjectDatabaseBase db): base(1936543297, newRawcode, db)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _isDataManaPerHitPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerHitPointModified));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
            _isDataDamageAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAbsorbedModified));
        }

        public ObjectProperty<float> DataManaPerHitPoint => _dataManaPerHitPoint.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaPerHitPointModified => _isDataManaPerHitPointModified.Value;
        public ObjectProperty<float> DataDamageAbsorbed => _dataDamageAbsorbed.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageAbsorbedModified => _isDataDamageAbsorbedModified.Value;
        private float GetDataManaPerHitPoint(int level)
        {
            return _modifications.GetModification(829648206, level).ValueAsFloat;
        }

        private void SetDataManaPerHitPoint(int level, float value)
        {
            _modifications[829648206, level] = new LevelObjectDataModification{Id = 829648206, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataManaPerHitPointModified(int level)
        {
            return _modifications.ContainsKey(829648206, level);
        }

        private float GetDataDamageAbsorbed(int level)
        {
            return _modifications.GetModification(846425422, level).ValueAsFloat;
        }

        private void SetDataDamageAbsorbed(int level, float value)
        {
            _modifications[846425422, level] = new LevelObjectDataModification{Id = 846425422, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageAbsorbedModified(int level)
        {
            return _modifications.ContainsKey(846425422, level);
        }
    }
}