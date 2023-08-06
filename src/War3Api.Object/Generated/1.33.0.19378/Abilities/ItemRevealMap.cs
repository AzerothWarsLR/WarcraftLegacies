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
    public sealed class ItemRevealMap : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDetectionTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDetectionTypeModified;
        private readonly Lazy<ObjectProperty<DetectionType>> _dataDetectionType;
        public ItemRevealMap(): base(1987201345)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public ItemRevealMap(int newId): base(1987201345, newId)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public ItemRevealMap(string newRawcode): base(1987201345, newRawcode)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public ItemRevealMap(ObjectDatabaseBase db): base(1987201345, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public ItemRevealMap(int newId, ObjectDatabaseBase db): base(1987201345, newId, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public ItemRevealMap(string newRawcode, ObjectDatabaseBase db): base(1987201345, newRawcode, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public ObjectProperty<int> DataDetectionTypeRaw => _dataDetectionTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDetectionTypeModified => _isDataDetectionTypeModified.Value;
        public ObjectProperty<DetectionType> DataDetectionType => _dataDetectionType.Value;
        private int GetDataDetectionTypeRaw(int level)
        {
            return _modifications.GetModification(829711684, level).ValueAsInt;
        }

        private void SetDataDetectionTypeRaw(int level, int value)
        {
            _modifications[829711684, level] = new LevelObjectDataModification{Id = 829711684, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDetectionTypeModified(int level)
        {
            return _modifications.ContainsKey(829711684, level);
        }

        private DetectionType GetDataDetectionType(int level)
        {
            return GetDataDetectionTypeRaw(level).ToDetectionType(this);
        }

        private void SetDataDetectionType(int level, DetectionType value)
        {
            SetDataDetectionTypeRaw(level, value.ToRaw(null, null));
        }
    }
}