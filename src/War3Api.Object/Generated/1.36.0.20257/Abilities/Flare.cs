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
    public sealed class Flare : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDetectionTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDetectionTypeModified;
        private readonly Lazy<ObjectProperty<DetectionType>> _dataDetectionType;
        private readonly Lazy<ObjectProperty<float>> _dataEffectDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataEffectDelayModified;
        private readonly Lazy<ObjectProperty<int>> _dataFlareCount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFlareCountModified;
        public Flare(): base(1634494017)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataFlareCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlareCount, SetDataFlareCount));
            _isDataFlareCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlareCountModified));
        }

        public Flare(int newId): base(1634494017, newId)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataFlareCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlareCount, SetDataFlareCount));
            _isDataFlareCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlareCountModified));
        }

        public Flare(string newRawcode): base(1634494017, newRawcode)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataFlareCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlareCount, SetDataFlareCount));
            _isDataFlareCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlareCountModified));
        }

        public Flare(ObjectDatabaseBase db): base(1634494017, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataFlareCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlareCount, SetDataFlareCount));
            _isDataFlareCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlareCountModified));
        }

        public Flare(int newId, ObjectDatabaseBase db): base(1634494017, newId, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataFlareCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlareCount, SetDataFlareCount));
            _isDataFlareCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlareCountModified));
        }

        public Flare(string newRawcode, ObjectDatabaseBase db): base(1634494017, newRawcode, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataFlareCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataFlareCount, SetDataFlareCount));
            _isDataFlareCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFlareCountModified));
        }

        public ObjectProperty<int> DataDetectionTypeRaw => _dataDetectionTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDetectionTypeModified => _isDataDetectionTypeModified.Value;
        public ObjectProperty<DetectionType> DataDetectionType => _dataDetectionType.Value;
        public ObjectProperty<float> DataEffectDelay => _dataEffectDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataEffectDelayModified => _isDataEffectDelayModified.Value;
        public ObjectProperty<int> DataFlareCount => _dataFlareCount.Value;
        public ReadOnlyObjectProperty<bool> IsDataFlareCountModified => _isDataFlareCountModified.Value;
        private int GetDataDetectionTypeRaw(int level)
        {
            return _modifications.GetModification(828468294, level).ValueAsInt;
        }

        private void SetDataDetectionTypeRaw(int level, int value)
        {
            _modifications[828468294, level] = new LevelObjectDataModification{Id = 828468294, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDetectionTypeModified(int level)
        {
            return _modifications.ContainsKey(828468294, level);
        }

        private DetectionType GetDataDetectionType(int level)
        {
            return GetDataDetectionTypeRaw(level).ToDetectionType(this);
        }

        private void SetDataDetectionType(int level, DetectionType value)
        {
            SetDataDetectionTypeRaw(level, value.ToRaw(null, null));
        }

        private float GetDataEffectDelay(int level)
        {
            return _modifications.GetModification(845245510, level).ValueAsFloat;
        }

        private void SetDataEffectDelay(int level, float value)
        {
            _modifications[845245510, level] = new LevelObjectDataModification{Id = 845245510, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataEffectDelayModified(int level)
        {
            return _modifications.ContainsKey(845245510, level);
        }

        private int GetDataFlareCount(int level)
        {
            return _modifications.GetModification(862022726, level).ValueAsInt;
        }

        private void SetDataFlareCount(int level, int value)
        {
            _modifications[862022726, level] = new LevelObjectDataModification{Id = 862022726, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataFlareCountModified(int level)
        {
            return _modifications.ContainsKey(862022726, level);
        }
    }
}