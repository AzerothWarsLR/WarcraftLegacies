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
    public sealed class AlchemistHealingSpray : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataWaveCount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataWaveCountModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageIntervalModified;
        private readonly Lazy<ObjectProperty<int>> _dataMissileCount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMissileCountModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaxDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBuildingDamageFactorModified;
        public AlchemistHealingSpray(): base(1936215617)
        {
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _isDataMissileCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMissileCountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
        }

        public AlchemistHealingSpray(int newId): base(1936215617, newId)
        {
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _isDataMissileCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMissileCountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
        }

        public AlchemistHealingSpray(string newRawcode): base(1936215617, newRawcode)
        {
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _isDataMissileCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMissileCountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
        }

        public AlchemistHealingSpray(ObjectDatabaseBase db): base(1936215617, db)
        {
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _isDataMissileCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMissileCountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
        }

        public AlchemistHealingSpray(int newId, ObjectDatabaseBase db): base(1936215617, newId, db)
        {
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _isDataMissileCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMissileCountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
        }

        public AlchemistHealingSpray(string newRawcode, ObjectDatabaseBase db): base(1936215617, newRawcode, db)
        {
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _isDataMissileCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMissileCountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
        }

        public ObjectProperty<int> DataWaveCount => _dataWaveCount.Value;
        public ReadOnlyObjectProperty<bool> IsDataWaveCountModified => _isDataWaveCountModified.Value;
        public ObjectProperty<float> DataDamageAmount => _dataDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageAmountModified => _isDataDamageAmountModified.Value;
        public ObjectProperty<float> DataDamageInterval => _dataDamageInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageIntervalModified => _isDataDamageIntervalModified.Value;
        public ObjectProperty<int> DataMissileCount => _dataMissileCount.Value;
        public ReadOnlyObjectProperty<bool> IsDataMissileCountModified => _isDataMissileCountModified.Value;
        public ObjectProperty<float> DataMaxDamage => _dataMaxDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxDamageModified => _isDataMaxDamageModified.Value;
        public ObjectProperty<float> DataBuildingDamageFactor => _dataBuildingDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataBuildingDamageFactorModified => _isDataBuildingDamageFactorModified.Value;
        private int GetDataWaveCount(int level)
        {
            return _modifications.GetModification(913533006, level).ValueAsInt;
        }

        private void SetDataWaveCount(int level, int value)
        {
            _modifications[913533006, level] = new LevelObjectDataModification{Id = 913533006, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataWaveCountModified(int level)
        {
            return _modifications.ContainsKey(913533006, level);
        }

        private float GetDataDamageAmount(int level)
        {
            return _modifications.GetModification(829645646, level).ValueAsFloat;
        }

        private void SetDataDamageAmount(int level, float value)
        {
            _modifications[829645646, level] = new LevelObjectDataModification{Id = 829645646, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageAmountModified(int level)
        {
            return _modifications.ContainsKey(829645646, level);
        }

        private float GetDataDamageInterval(int level)
        {
            return _modifications.GetModification(846422862, level).ValueAsFloat;
        }

        private void SetDataDamageInterval(int level, float value)
        {
            _modifications[846422862, level] = new LevelObjectDataModification{Id = 846422862, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageIntervalModified(int level)
        {
            return _modifications.ContainsKey(846422862, level);
        }

        private int GetDataMissileCount(int level)
        {
            return _modifications.GetModification(863200078, level).ValueAsInt;
        }

        private void SetDataMissileCount(int level, int value)
        {
            _modifications[863200078, level] = new LevelObjectDataModification{Id = 863200078, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMissileCountModified(int level)
        {
            return _modifications.ContainsKey(863200078, level);
        }

        private float GetDataMaxDamage(int level)
        {
            return _modifications.GetModification(879977294, level).ValueAsFloat;
        }

        private void SetDataMaxDamage(int level, float value)
        {
            _modifications[879977294, level] = new LevelObjectDataModification{Id = 879977294, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataMaxDamageModified(int level)
        {
            return _modifications.ContainsKey(879977294, level);
        }

        private float GetDataBuildingDamageFactor(int level)
        {
            return _modifications.GetModification(896754510, level).ValueAsFloat;
        }

        private void SetDataBuildingDamageFactor(int level, float value)
        {
            _modifications[896754510, level] = new LevelObjectDataModification{Id = 896754510, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataBuildingDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(896754510, level);
        }
    }
}