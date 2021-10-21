using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FlakCannon : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMediumDamageRadius;
        private readonly Lazy<ObjectProperty<float>> _dataSmallDamageRadius;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageAmount;
        private readonly Lazy<ObjectProperty<float>> _dataMediumDamageAmount;
        private readonly Lazy<ObjectProperty<float>> _dataSmallDamageAmount;
        public FlakCannon(): base(1802266177)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
        }

        public FlakCannon(int newId): base(1802266177, newId)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
        }

        public FlakCannon(string newRawcode): base(1802266177, newRawcode)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
        }

        public FlakCannon(ObjectDatabase db): base(1802266177, db)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
        }

        public FlakCannon(int newId, ObjectDatabase db): base(1802266177, newId, db)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
        }

        public FlakCannon(string newRawcode, ObjectDatabase db): base(1802266177, newRawcode, db)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
        }

        public ObjectProperty<float> DataMediumDamageRadius => _dataMediumDamageRadius.Value;
        public ObjectProperty<float> DataSmallDamageRadius => _dataSmallDamageRadius.Value;
        public ObjectProperty<float> DataFullDamageAmount => _dataFullDamageAmount.Value;
        public ObjectProperty<float> DataMediumDamageAmount => _dataMediumDamageAmount.Value;
        public ObjectProperty<float> DataSmallDamageAmount => _dataSmallDamageAmount.Value;
        private float GetDataMediumDamageRadius(int level)
        {
            return _modifications[829123686, level].ValueAsFloat;
        }

        private void SetDataMediumDamageRadius(int level, float value)
        {
            _modifications[829123686, level] = new LevelObjectDataModification{Id = 829123686, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataSmallDamageRadius(int level)
        {
            return _modifications[845900902, level].ValueAsFloat;
        }

        private void SetDataSmallDamageRadius(int level, float value)
        {
            _modifications[845900902, level] = new LevelObjectDataModification{Id = 845900902, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataFullDamageAmount(int level)
        {
            return _modifications[862678118, level].ValueAsFloat;
        }

        private void SetDataFullDamageAmount(int level, float value)
        {
            _modifications[862678118, level] = new LevelObjectDataModification{Id = 862678118, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataMediumDamageAmount(int level)
        {
            return _modifications[879455334, level].ValueAsFloat;
        }

        private void SetDataMediumDamageAmount(int level, float value)
        {
            _modifications[879455334, level] = new LevelObjectDataModification{Id = 879455334, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataSmallDamageAmount(int level)
        {
            return _modifications[896232550, level].ValueAsFloat;
        }

        private void SetDataSmallDamageAmount(int level, float value)
        {
            _modifications[896232550, level] = new LevelObjectDataModification{Id = 896232550, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}