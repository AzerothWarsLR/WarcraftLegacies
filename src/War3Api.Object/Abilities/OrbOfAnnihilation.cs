using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class OrbOfAnnihilation : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ObjectProperty<float>> _dataMediumDamageFactor;
        private readonly Lazy<ObjectProperty<float>> _dataSmallDamageFactor;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageRadius;
        private readonly Lazy<ObjectProperty<float>> _dataHalfDamageRadius;
        public OrbOfAnnihilation(): base(1801545281)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public OrbOfAnnihilation(int newId): base(1801545281, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public OrbOfAnnihilation(string newRawcode): base(1801545281, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public OrbOfAnnihilation(ObjectDatabase db): base(1801545281, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public OrbOfAnnihilation(int newId, ObjectDatabase db): base(1801545281, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public OrbOfAnnihilation(string newRawcode, ObjectDatabase db): base(1801545281, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ObjectProperty<float> DataMediumDamageFactor => _dataMediumDamageFactor.Value;
        public ObjectProperty<float> DataSmallDamageFactor => _dataSmallDamageFactor.Value;
        public ObjectProperty<float> DataFullDamageRadius => _dataFullDamageRadius.Value;
        public ObjectProperty<float> DataHalfDamageRadius => _dataHalfDamageRadius.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications[829120870, level].ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[829120870, level] = new LevelObjectDataModification{Id = 829120870, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMediumDamageFactor(int level)
        {
            return _modifications[845898086, level].ValueAsFloat;
        }

        private void SetDataMediumDamageFactor(int level, float value)
        {
            _modifications[845898086, level] = new LevelObjectDataModification{Id = 845898086, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataSmallDamageFactor(int level)
        {
            return _modifications[862675302, level].ValueAsFloat;
        }

        private void SetDataSmallDamageFactor(int level, float value)
        {
            _modifications[862675302, level] = new LevelObjectDataModification{Id = 862675302, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataFullDamageRadius(int level)
        {
            return _modifications[879452518, level].ValueAsFloat;
        }

        private void SetDataFullDamageRadius(int level, float value)
        {
            _modifications[879452518, level] = new LevelObjectDataModification{Id = 879452518, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataHalfDamageRadius(int level)
        {
            return _modifications[896229734, level].ValueAsFloat;
        }

        private void SetDataHalfDamageRadius(int level, float value)
        {
            _modifications[896229734, level] = new LevelObjectDataModification{Id = 896229734, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}