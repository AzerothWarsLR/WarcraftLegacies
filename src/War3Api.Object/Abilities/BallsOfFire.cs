using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BallsOfFire : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageDealt;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageInterval;
        private readonly Lazy<ObjectProperty<float>> _dataHalfDamageDealt;
        private readonly Lazy<ObjectProperty<float>> _dataHalfDamageInterval;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingReduction;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumDamage;
        public BallsOfFire(): base(1718575681)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public BallsOfFire(int newId): base(1718575681, newId)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public BallsOfFire(string newRawcode): base(1718575681, newRawcode)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public BallsOfFire(ObjectDatabase db): base(1718575681, db)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public BallsOfFire(int newId, ObjectDatabase db): base(1718575681, newId, db)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public BallsOfFire(string newRawcode, ObjectDatabase db): base(1718575681, newRawcode, db)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public ObjectProperty<float> DataFullDamageDealt => _dataFullDamageDealt.Value;
        public ObjectProperty<float> DataFullDamageInterval => _dataFullDamageInterval.Value;
        public ObjectProperty<float> DataHalfDamageDealt => _dataHalfDamageDealt.Value;
        public ObjectProperty<float> DataHalfDamageInterval => _dataHalfDamageInterval.Value;
        public ObjectProperty<float> DataBuildingReduction => _dataBuildingReduction.Value;
        public ObjectProperty<float> DataMaximumDamage => _dataMaximumDamage.Value;
        private float GetDataFullDamageDealt(int level)
        {
            return _modifications[829646408, level].ValueAsFloat;
        }

        private void SetDataFullDamageDealt(int level, float value)
        {
            _modifications[829646408, level] = new LevelObjectDataModification{Id = 829646408, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataFullDamageInterval(int level)
        {
            return _modifications[846423624, level].ValueAsFloat;
        }

        private void SetDataFullDamageInterval(int level, float value)
        {
            _modifications[846423624, level] = new LevelObjectDataModification{Id = 846423624, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataHalfDamageDealt(int level)
        {
            return _modifications[863200840, level].ValueAsFloat;
        }

        private void SetDataHalfDamageDealt(int level, float value)
        {
            _modifications[863200840, level] = new LevelObjectDataModification{Id = 863200840, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataHalfDamageInterval(int level)
        {
            return _modifications[879978056, level].ValueAsFloat;
        }

        private void SetDataHalfDamageInterval(int level, float value)
        {
            _modifications[879978056, level] = new LevelObjectDataModification{Id = 879978056, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataBuildingReduction(int level)
        {
            return _modifications[896755272, level].ValueAsFloat;
        }

        private void SetDataBuildingReduction(int level, float value)
        {
            _modifications[896755272, level] = new LevelObjectDataModification{Id = 896755272, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataMaximumDamage(int level)
        {
            return _modifications[913532488, level].ValueAsFloat;
        }

        private void SetDataMaximumDamage(int level, float value)
        {
            _modifications[913532488, level] = new LevelObjectDataModification{Id = 913532488, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }
    }
}