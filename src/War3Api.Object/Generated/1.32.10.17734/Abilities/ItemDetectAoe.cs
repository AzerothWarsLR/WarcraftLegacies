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
    public sealed class ItemDetectAoe : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDetectionRadiusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDetectionRadiusModified;
        private readonly Lazy<ObjectProperty<DetectionType>> _dataDetectionRadius;
        public ItemDetectAoe(): base(1635010881)
        {
            _dataDetectionRadiusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionRadiusRaw, SetDataDetectionRadiusRaw));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionRadius, SetDataDetectionRadius));
        }

        public ItemDetectAoe(int newId): base(1635010881, newId)
        {
            _dataDetectionRadiusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionRadiusRaw, SetDataDetectionRadiusRaw));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionRadius, SetDataDetectionRadius));
        }

        public ItemDetectAoe(string newRawcode): base(1635010881, newRawcode)
        {
            _dataDetectionRadiusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionRadiusRaw, SetDataDetectionRadiusRaw));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionRadius, SetDataDetectionRadius));
        }

        public ItemDetectAoe(ObjectDatabaseBase db): base(1635010881, db)
        {
            _dataDetectionRadiusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionRadiusRaw, SetDataDetectionRadiusRaw));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionRadius, SetDataDetectionRadius));
        }

        public ItemDetectAoe(int newId, ObjectDatabaseBase db): base(1635010881, newId, db)
        {
            _dataDetectionRadiusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionRadiusRaw, SetDataDetectionRadiusRaw));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionRadius, SetDataDetectionRadius));
        }

        public ItemDetectAoe(string newRawcode, ObjectDatabaseBase db): base(1635010881, newRawcode, db)
        {
            _dataDetectionRadiusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionRadiusRaw, SetDataDetectionRadiusRaw));
            _isDataDetectionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionRadiusModified));
            _dataDetectionRadius = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionRadius, SetDataDetectionRadius));
        }

        public ObjectProperty<int> DataDetectionRadiusRaw => _dataDetectionRadiusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDetectionRadiusModified => _isDataDetectionRadiusModified.Value;
        public ObjectProperty<DetectionType> DataDetectionRadius => _dataDetectionRadius.Value;
        private int GetDataDetectionRadiusRaw(int level)
        {
            return _modifications.GetModification(1952801865, level).ValueAsInt;
        }

        private void SetDataDetectionRadiusRaw(int level, int value)
        {
            _modifications[1952801865, level] = new LevelObjectDataModification{Id = 1952801865, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDetectionRadiusModified(int level)
        {
            return _modifications.ContainsKey(1952801865, level);
        }

        private DetectionType GetDataDetectionRadius(int level)
        {
            return GetDataDetectionRadiusRaw(level).ToDetectionType(this);
        }

        private void SetDataDetectionRadius(int level, DetectionType value)
        {
            SetDataDetectionRadiusRaw(level, value.ToRaw(0, 99999));
        }
    }
}