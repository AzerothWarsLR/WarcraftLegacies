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
    public sealed class FlareGun : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDetectionTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDetectionTypeModified;
        private readonly Lazy<ObjectProperty<DetectionType>> _dataDetectionType;
        private readonly Lazy<ObjectProperty<float>> _dataDelayForTargetEffect;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDelayForTargetEffectModified;
        public FlareGun(): base(1634093377)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataDelayForTargetEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDelayForTargetEffect, SetDataDelayForTargetEffect));
            _isDataDelayForTargetEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayForTargetEffectModified));
        }

        public FlareGun(int newId): base(1634093377, newId)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataDelayForTargetEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDelayForTargetEffect, SetDataDelayForTargetEffect));
            _isDataDelayForTargetEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayForTargetEffectModified));
        }

        public FlareGun(string newRawcode): base(1634093377, newRawcode)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataDelayForTargetEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDelayForTargetEffect, SetDataDelayForTargetEffect));
            _isDataDelayForTargetEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayForTargetEffectModified));
        }

        public FlareGun(ObjectDatabaseBase db): base(1634093377, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataDelayForTargetEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDelayForTargetEffect, SetDataDelayForTargetEffect));
            _isDataDelayForTargetEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayForTargetEffectModified));
        }

        public FlareGun(int newId, ObjectDatabaseBase db): base(1634093377, newId, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataDelayForTargetEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDelayForTargetEffect, SetDataDelayForTargetEffect));
            _isDataDelayForTargetEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayForTargetEffectModified));
        }

        public FlareGun(string newRawcode, ObjectDatabaseBase db): base(1634093377, newRawcode, db)
        {
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
            _dataDelayForTargetEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDelayForTargetEffect, SetDataDelayForTargetEffect));
            _isDataDelayForTargetEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayForTargetEffectModified));
        }

        public ObjectProperty<int> DataDetectionTypeRaw => _dataDetectionTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDetectionTypeModified => _isDataDetectionTypeModified.Value;
        public ObjectProperty<DetectionType> DataDetectionType => _dataDetectionType.Value;
        public ObjectProperty<float> DataDelayForTargetEffect => _dataDelayForTargetEffect.Value;
        public ReadOnlyObjectProperty<bool> IsDataDelayForTargetEffectModified => _isDataDelayForTargetEffectModified.Value;
        private int GetDataDetectionTypeRaw(int level)
        {
            return _modifications.GetModification(828466761, level).ValueAsInt;
        }

        private void SetDataDetectionTypeRaw(int level, int value)
        {
            _modifications[828466761, level] = new LevelObjectDataModification{Id = 828466761, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDetectionTypeModified(int level)
        {
            return _modifications.ContainsKey(828466761, level);
        }

        private DetectionType GetDataDetectionType(int level)
        {
            return GetDataDetectionTypeRaw(level).ToDetectionType(this);
        }

        private void SetDataDetectionType(int level, DetectionType value)
        {
            SetDataDetectionTypeRaw(level, value.ToRaw(null, null));
        }

        private float GetDataDelayForTargetEffect(int level)
        {
            return _modifications.GetModification(1818584137, level).ValueAsFloat;
        }

        private void SetDataDelayForTargetEffect(int level, float value)
        {
            _modifications[1818584137, level] = new LevelObjectDataModification{Id = 1818584137, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDelayForTargetEffectModified(int level)
        {
            return _modifications.ContainsKey(1818584137, level);
        }
    }
}