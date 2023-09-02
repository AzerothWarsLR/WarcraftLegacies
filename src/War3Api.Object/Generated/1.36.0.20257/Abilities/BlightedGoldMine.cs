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
    public sealed class BlightedGoldMine : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataGoldPerInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGoldPerIntervalModified;
        private readonly Lazy<ObjectProperty<float>> _dataIntervalDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIntervalDurationModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaxNumberOfMiners;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxNumberOfMinersModified;
        private readonly Lazy<ObjectProperty<float>> _dataRadiusOfMiningRing;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRadiusOfMiningRingModified;
        public BlightedGoldMine(): base(1835491905)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _isDataMaxNumberOfMinersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxNumberOfMinersModified));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
            _isDataRadiusOfMiningRingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRadiusOfMiningRingModified));
        }

        public BlightedGoldMine(int newId): base(1835491905, newId)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _isDataMaxNumberOfMinersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxNumberOfMinersModified));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
            _isDataRadiusOfMiningRingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRadiusOfMiningRingModified));
        }

        public BlightedGoldMine(string newRawcode): base(1835491905, newRawcode)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _isDataMaxNumberOfMinersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxNumberOfMinersModified));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
            _isDataRadiusOfMiningRingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRadiusOfMiningRingModified));
        }

        public BlightedGoldMine(ObjectDatabaseBase db): base(1835491905, db)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _isDataMaxNumberOfMinersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxNumberOfMinersModified));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
            _isDataRadiusOfMiningRingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRadiusOfMiningRingModified));
        }

        public BlightedGoldMine(int newId, ObjectDatabaseBase db): base(1835491905, newId, db)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _isDataMaxNumberOfMinersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxNumberOfMinersModified));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
            _isDataRadiusOfMiningRingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRadiusOfMiningRingModified));
        }

        public BlightedGoldMine(string newRawcode, ObjectDatabaseBase db): base(1835491905, newRawcode, db)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
            _dataMaxNumberOfMiners = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxNumberOfMiners, SetDataMaxNumberOfMiners));
            _isDataMaxNumberOfMinersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxNumberOfMinersModified));
            _dataRadiusOfMiningRing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfMiningRing, SetDataRadiusOfMiningRing));
            _isDataRadiusOfMiningRingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRadiusOfMiningRingModified));
        }

        public ObjectProperty<int> DataGoldPerInterval => _dataGoldPerInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataGoldPerIntervalModified => _isDataGoldPerIntervalModified.Value;
        public ObjectProperty<float> DataIntervalDuration => _dataIntervalDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataIntervalDurationModified => _isDataIntervalDurationModified.Value;
        public ObjectProperty<int> DataMaxNumberOfMiners => _dataMaxNumberOfMiners.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxNumberOfMinersModified => _isDataMaxNumberOfMinersModified.Value;
        public ObjectProperty<float> DataRadiusOfMiningRing => _dataRadiusOfMiningRing.Value;
        public ReadOnlyObjectProperty<bool> IsDataRadiusOfMiningRingModified => _isDataRadiusOfMiningRingModified.Value;
        private int GetDataGoldPerInterval(int level)
        {
            return _modifications.GetModification(829253442, level).ValueAsInt;
        }

        private void SetDataGoldPerInterval(int level, int value)
        {
            _modifications[829253442, level] = new LevelObjectDataModification{Id = 829253442, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataGoldPerIntervalModified(int level)
        {
            return _modifications.ContainsKey(829253442, level);
        }

        private float GetDataIntervalDuration(int level)
        {
            return _modifications.GetModification(846030658, level).ValueAsFloat;
        }

        private void SetDataIntervalDuration(int level, float value)
        {
            _modifications[846030658, level] = new LevelObjectDataModification{Id = 846030658, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataIntervalDurationModified(int level)
        {
            return _modifications.ContainsKey(846030658, level);
        }

        private int GetDataMaxNumberOfMiners(int level)
        {
            return _modifications.GetModification(862807874, level).ValueAsInt;
        }

        private void SetDataMaxNumberOfMiners(int level, int value)
        {
            _modifications[862807874, level] = new LevelObjectDataModification{Id = 862807874, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMaxNumberOfMinersModified(int level)
        {
            return _modifications.ContainsKey(862807874, level);
        }

        private float GetDataRadiusOfMiningRing(int level)
        {
            return _modifications.GetModification(879585090, level).ValueAsFloat;
        }

        private void SetDataRadiusOfMiningRing(int level, float value)
        {
            _modifications[879585090, level] = new LevelObjectDataModification{Id = 879585090, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataRadiusOfMiningRingModified(int level)
        {
            return _modifications.ContainsKey(879585090, level);
        }
    }
}