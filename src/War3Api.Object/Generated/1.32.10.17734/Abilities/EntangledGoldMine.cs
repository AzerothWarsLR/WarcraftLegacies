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
    public sealed class EntangledGoldMine : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataGoldPerInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGoldPerIntervalModified;
        private readonly Lazy<ObjectProperty<float>> _dataIntervalDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIntervalDurationModified;
        public EntangledGoldMine(): base(1835492673)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
        }

        public EntangledGoldMine(int newId): base(1835492673, newId)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
        }

        public EntangledGoldMine(string newRawcode): base(1835492673, newRawcode)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
        }

        public EntangledGoldMine(ObjectDatabaseBase db): base(1835492673, db)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
        }

        public EntangledGoldMine(int newId, ObjectDatabaseBase db): base(1835492673, newId, db)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
        }

        public EntangledGoldMine(string newRawcode, ObjectDatabaseBase db): base(1835492673, newRawcode, db)
        {
            _dataGoldPerInterval = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldPerInterval, SetDataGoldPerInterval));
            _isDataGoldPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldPerIntervalModified));
            _dataIntervalDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalDuration, SetDataIntervalDuration));
            _isDataIntervalDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalDurationModified));
        }

        public ObjectProperty<int> DataGoldPerInterval => _dataGoldPerInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataGoldPerIntervalModified => _isDataGoldPerIntervalModified.Value;
        public ObjectProperty<float> DataIntervalDuration => _dataIntervalDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataIntervalDurationModified => _isDataIntervalDurationModified.Value;
        private int GetDataGoldPerInterval(int level)
        {
            return _modifications.GetModification(829253445, level).ValueAsInt;
        }

        private void SetDataGoldPerInterval(int level, int value)
        {
            _modifications[829253445, level] = new LevelObjectDataModification{Id = 829253445, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataGoldPerIntervalModified(int level)
        {
            return _modifications.ContainsKey(829253445, level);
        }

        private float GetDataIntervalDuration(int level)
        {
            return _modifications.GetModification(846030661, level).ValueAsFloat;
        }

        private void SetDataIntervalDuration(int level, float value)
        {
            _modifications[846030661, level] = new LevelObjectDataModification{Id = 846030661, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataIntervalDurationModified(int level)
        {
            return _modifications.ContainsKey(846030661, level);
        }
    }
}