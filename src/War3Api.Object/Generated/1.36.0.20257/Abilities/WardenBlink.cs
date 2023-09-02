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
    public sealed class WardenBlink : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMaximumRange;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumRangeModified;
        private readonly Lazy<ObjectProperty<float>> _dataMinimumRange;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMinimumRangeModified;
        public WardenBlink(): base(1818379585)
        {
            _dataMaximumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumRange, SetDataMaximumRange));
            _isDataMaximumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumRangeModified));
            _dataMinimumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumRange, SetDataMinimumRange));
            _isDataMinimumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumRangeModified));
        }

        public WardenBlink(int newId): base(1818379585, newId)
        {
            _dataMaximumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumRange, SetDataMaximumRange));
            _isDataMaximumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumRangeModified));
            _dataMinimumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumRange, SetDataMinimumRange));
            _isDataMinimumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumRangeModified));
        }

        public WardenBlink(string newRawcode): base(1818379585, newRawcode)
        {
            _dataMaximumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumRange, SetDataMaximumRange));
            _isDataMaximumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumRangeModified));
            _dataMinimumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumRange, SetDataMinimumRange));
            _isDataMinimumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumRangeModified));
        }

        public WardenBlink(ObjectDatabaseBase db): base(1818379585, db)
        {
            _dataMaximumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumRange, SetDataMaximumRange));
            _isDataMaximumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumRangeModified));
            _dataMinimumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumRange, SetDataMinimumRange));
            _isDataMinimumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumRangeModified));
        }

        public WardenBlink(int newId, ObjectDatabaseBase db): base(1818379585, newId, db)
        {
            _dataMaximumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumRange, SetDataMaximumRange));
            _isDataMaximumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumRangeModified));
            _dataMinimumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumRange, SetDataMinimumRange));
            _isDataMinimumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumRangeModified));
        }

        public WardenBlink(string newRawcode, ObjectDatabaseBase db): base(1818379585, newRawcode, db)
        {
            _dataMaximumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumRange, SetDataMaximumRange));
            _isDataMaximumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumRangeModified));
            _dataMinimumRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumRange, SetDataMinimumRange));
            _isDataMinimumRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumRangeModified));
        }

        public ObjectProperty<float> DataMaximumRange => _dataMaximumRange.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumRangeModified => _isDataMaximumRangeModified.Value;
        public ObjectProperty<float> DataMinimumRange => _dataMinimumRange.Value;
        public ReadOnlyObjectProperty<bool> IsDataMinimumRangeModified => _isDataMinimumRangeModified.Value;
        private float GetDataMaximumRange(int level)
        {
            return _modifications.GetModification(829186629, level).ValueAsFloat;
        }

        private void SetDataMaximumRange(int level, float value)
        {
            _modifications[829186629, level] = new LevelObjectDataModification{Id = 829186629, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaximumRangeModified(int level)
        {
            return _modifications.ContainsKey(829186629, level);
        }

        private float GetDataMinimumRange(int level)
        {
            return _modifications.GetModification(845963845, level).ValueAsFloat;
        }

        private void SetDataMinimumRange(int level, float value)
        {
            _modifications[845963845, level] = new LevelObjectDataModification{Id = 845963845, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMinimumRangeModified(int level)
        {
            return _modifications.ContainsKey(845963845, level);
        }
    }
}