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
    public sealed class OrbOfAnnihilation : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataMediumDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMediumDamageFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataSmallDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSmallDamageFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFullDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataHalfDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHalfDamageRadiusModified;
        public OrbOfAnnihilation(): base(1801545281)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _isDataMediumDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageFactorModified));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _isDataSmallDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageFactorModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public OrbOfAnnihilation(int newId): base(1801545281, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _isDataMediumDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageFactorModified));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _isDataSmallDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageFactorModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public OrbOfAnnihilation(string newRawcode): base(1801545281, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _isDataMediumDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageFactorModified));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _isDataSmallDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageFactorModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public OrbOfAnnihilation(ObjectDatabaseBase db): base(1801545281, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _isDataMediumDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageFactorModified));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _isDataSmallDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageFactorModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public OrbOfAnnihilation(int newId, ObjectDatabaseBase db): base(1801545281, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _isDataMediumDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageFactorModified));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _isDataSmallDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageFactorModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public OrbOfAnnihilation(string newRawcode, ObjectDatabaseBase db): base(1801545281, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataMediumDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageFactor, SetDataMediumDamageFactor));
            _isDataMediumDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageFactorModified));
            _dataSmallDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageFactor, SetDataSmallDamageFactor));
            _isDataSmallDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageFactorModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<float> DataMediumDamageFactor => _dataMediumDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataMediumDamageFactorModified => _isDataMediumDamageFactorModified.Value;
        public ObjectProperty<float> DataSmallDamageFactor => _dataSmallDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataSmallDamageFactorModified => _isDataSmallDamageFactorModified.Value;
        public ObjectProperty<float> DataFullDamageRadius => _dataFullDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataFullDamageRadiusModified => _isDataFullDamageRadiusModified.Value;
        public ObjectProperty<float> DataHalfDamageRadius => _dataHalfDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataHalfDamageRadiusModified => _isDataHalfDamageRadiusModified.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications.GetModification(829120870, level).ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[829120870, level] = new LevelObjectDataModification{Id = 829120870, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageBonusModified(int level)
        {
            return _modifications.ContainsKey(829120870, level);
        }

        private float GetDataMediumDamageFactor(int level)
        {
            return _modifications.GetModification(845898086, level).ValueAsFloat;
        }

        private void SetDataMediumDamageFactor(int level, float value)
        {
            _modifications[845898086, level] = new LevelObjectDataModification{Id = 845898086, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMediumDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(845898086, level);
        }

        private float GetDataSmallDamageFactor(int level)
        {
            return _modifications.GetModification(862675302, level).ValueAsFloat;
        }

        private void SetDataSmallDamageFactor(int level, float value)
        {
            _modifications[862675302, level] = new LevelObjectDataModification{Id = 862675302, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataSmallDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(862675302, level);
        }

        private float GetDataFullDamageRadius(int level)
        {
            return _modifications.GetModification(879452518, level).ValueAsFloat;
        }

        private void SetDataFullDamageRadius(int level, float value)
        {
            _modifications[879452518, level] = new LevelObjectDataModification{Id = 879452518, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataFullDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(879452518, level);
        }

        private float GetDataHalfDamageRadius(int level)
        {
            return _modifications.GetModification(896229734, level).ValueAsFloat;
        }

        private void SetDataHalfDamageRadius(int level, float value)
        {
            _modifications[896229734, level] = new LevelObjectDataModification{Id = 896229734, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataHalfDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(896229734, level);
        }
    }
}