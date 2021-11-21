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
    public sealed class DetectGeneral : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDetectionTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDetectionTypeModified;
        private readonly Lazy<ObjectProperty<DetectionType>> _dataDetectionType;
        public DetectGeneral(): base(1735681089)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public DetectGeneral(int newId): base(1735681089, newId)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public DetectGeneral(string newRawcode): base(1735681089, newRawcode)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public DetectGeneral(ObjectDatabaseBase db): base(1735681089, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public DetectGeneral(int newId, ObjectDatabaseBase db): base(1735681089, newId, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public DetectGeneral(string newRawcode, ObjectDatabaseBase db): base(1735681089, newRawcode, db)
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