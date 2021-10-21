using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BlightedGoldMine : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataGoldPerInterval;
        private readonly Lazy<ObjectProperty<float>> _dataIntervalDuration;
        private readonly Lazy<ObjectProperty<int>> _dataMaxNumberOfMiners;
        private readonly Lazy<ObjectProperty<float>> _dataRadiusOfMiningRing;
        public BlightedGoldMine(): base(1835491905)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
        }

        public BlightedGoldMine(int newId): base(1835491905, newId)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
        }

        public BlightedGoldMine(string newRawcode): base(1835491905, newRawcode)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
        }

        public BlightedGoldMine(ObjectDatabase db): base(1835491905, db)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
        }

        public BlightedGoldMine(int newId, ObjectDatabase db): base(1835491905, newId, db)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
        }

        public BlightedGoldMine(string newRawcode, ObjectDatabase db): base(1835491905, newRawcode, db)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
        }

        public ObjectProperty<int> DataGoldPerInterval => _dataGoldPerInterval.Value;
        public ObjectProperty<float> DataIntervalDuration => _dataIntervalDuration.Value;
        public ObjectProperty<int> DataMaxNumberOfMiners => _dataMaxNumberOfMiners.Value;
        public ObjectProperty<float> DataRadiusOfMiningRing => _dataRadiusOfMiningRing.Value;
        private int GetDataGoldPerInterval(int level)
        {
            return _modifications[829253442, level].ValueAsInt;
        }

        private void SetDataGoldPerInterval(int level, int value)
        {
            _modifications[829253442, level] = new LevelObjectDataModification{Id = 829253442, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataIntervalDuration(int level)
        {
            return _modifications[846030658, level].ValueAsFloat;
        }

        private void SetDataIntervalDuration(int level, float value)
        {
            _modifications[846030658, level] = new LevelObjectDataModification{Id = 846030658, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataMaxNumberOfMiners(int level)
        {
            return _modifications[862807874, level].ValueAsInt;
        }

        private void SetDataMaxNumberOfMiners(int level, int value)
        {
            _modifications[862807874, level] = new LevelObjectDataModification{Id = 862807874, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataRadiusOfMiningRing(int level)
        {
            return _modifications[879585090, level].ValueAsFloat;
        }

        private void SetDataRadiusOfMiningRing(int level, float value)
        {
            _modifications[879585090, level] = new LevelObjectDataModification{Id = 879585090, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}