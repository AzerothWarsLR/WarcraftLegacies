using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SeaWitchManaShield : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaPerHitPoint;
        private readonly Lazy<ObjectProperty<float>> _dataDamageAbsorbed;
        public SeaWitchManaShield(): base(1936543297)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
        }

        public SeaWitchManaShield(int newId): base(1936543297, newId)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
        }

        public SeaWitchManaShield(string newRawcode): base(1936543297, newRawcode)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
        }

        public SeaWitchManaShield(ObjectDatabase db): base(1936543297, db)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
        }

        public SeaWitchManaShield(int newId, ObjectDatabase db): base(1936543297, newId, db)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
        }

        public SeaWitchManaShield(string newRawcode, ObjectDatabase db): base(1936543297, newRawcode, db)
        {
            _dataManaPerHitPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerHitPoint, SetDataManaPerHitPoint));
            _dataDamageAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAbsorbed, SetDataDamageAbsorbed));
        }

        public ObjectProperty<float> DataManaPerHitPoint => _dataManaPerHitPoint.Value;
        public ObjectProperty<float> DataDamageAbsorbed => _dataDamageAbsorbed.Value;
        private float GetDataManaPerHitPoint(int level)
        {
            return _modifications[829648206, level].ValueAsFloat;
        }

        private void SetDataManaPerHitPoint(int level, float value)
        {
            _modifications[829648206, level] = new LevelObjectDataModification{Id = 829648206, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageAbsorbed(int level)
        {
            return _modifications[846425422, level].ValueAsFloat;
        }

        private void SetDataDamageAbsorbed(int level, float value)
        {
            _modifications[846425422, level] = new LevelObjectDataModification{Id = 846425422, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}