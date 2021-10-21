using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TinkererClusterRocketsLevel3 : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageAmount;
        private readonly Lazy<ObjectProperty<float>> _dataDamageInterval;
        private readonly Lazy<ObjectProperty<int>> _dataMissileCount;
        private readonly Lazy<ObjectProperty<float>> _dataMaxDamage;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingDamageFactor;
        private readonly Lazy<ObjectProperty<float>> _dataEffectDuration;
        public TinkererClusterRocketsLevel3(): base(862146113)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataEffectDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDuration, SetDataEffectDuration));
        }

        public TinkererClusterRocketsLevel3(int newId): base(862146113, newId)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataEffectDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDuration, SetDataEffectDuration));
        }

        public TinkererClusterRocketsLevel3(string newRawcode): base(862146113, newRawcode)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataEffectDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDuration, SetDataEffectDuration));
        }

        public TinkererClusterRocketsLevel3(ObjectDatabase db): base(862146113, db)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataEffectDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDuration, SetDataEffectDuration));
        }

        public TinkererClusterRocketsLevel3(int newId, ObjectDatabase db): base(862146113, newId, db)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataEffectDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDuration, SetDataEffectDuration));
        }

        public TinkererClusterRocketsLevel3(string newRawcode, ObjectDatabase db): base(862146113, newRawcode, db)
        {
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _dataMissileCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMissileCount, SetDataMissileCount));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataEffectDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDuration, SetDataEffectDuration));
        }

        public ObjectProperty<float> DataDamageAmount => _dataDamageAmount.Value;
        public ObjectProperty<float> DataDamageInterval => _dataDamageInterval.Value;
        public ObjectProperty<int> DataMissileCount => _dataMissileCount.Value;
        public ObjectProperty<float> DataMaxDamage => _dataMaxDamage.Value;
        public ObjectProperty<float> DataBuildingDamageFactor => _dataBuildingDamageFactor.Value;
        public ObjectProperty<float> DataEffectDuration => _dataEffectDuration.Value;
        private float GetDataDamageAmount(int level)
        {
            return _modifications[829645646, level].ValueAsFloat;
        }

        private void SetDataDamageAmount(int level, float value)
        {
            _modifications[829645646, level] = new LevelObjectDataModification{Id = 829645646, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageInterval(int level)
        {
            return _modifications[846422862, level].ValueAsFloat;
        }

        private void SetDataDamageInterval(int level, float value)
        {
            _modifications[846422862, level] = new LevelObjectDataModification{Id = 846422862, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataMissileCount(int level)
        {
            return _modifications[863200078, level].ValueAsInt;
        }

        private void SetDataMissileCount(int level, int value)
        {
            _modifications[863200078, level] = new LevelObjectDataModification{Id = 863200078, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataMaxDamage(int level)
        {
            return _modifications[879977294, level].ValueAsFloat;
        }

        private void SetDataMaxDamage(int level, float value)
        {
            _modifications[879977294, level] = new LevelObjectDataModification{Id = 879977294, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataBuildingDamageFactor(int level)
        {
            return _modifications[896754510, level].ValueAsFloat;
        }

        private void SetDataBuildingDamageFactor(int level, float value)
        {
            _modifications[896754510, level] = new LevelObjectDataModification{Id = 896754510, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataEffectDuration(int level)
        {
            return _modifications[913531726, level].ValueAsFloat;
        }

        private void SetDataEffectDuration(int level, float value)
        {
            _modifications[913531726, level] = new LevelObjectDataModification{Id = 913531726, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }
    }
}