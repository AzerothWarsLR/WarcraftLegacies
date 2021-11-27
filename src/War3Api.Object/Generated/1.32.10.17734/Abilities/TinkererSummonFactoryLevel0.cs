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
    public sealed class TinkererSummonFactoryLevel0 : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataSpawnInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSpawnIntervalModified;
        private readonly Lazy<ObjectProperty<string>> _dataSpawnUnitIDRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSpawnUnitIDModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataSpawnUnitID;
        private readonly Lazy<ObjectProperty<float>> _dataSpawnUnitDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSpawnUnitDurationModified;
        private readonly Lazy<ObjectProperty<float>> _dataSpawnUnitOffset;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSpawnUnitOffsetModified;
        private readonly Lazy<ObjectProperty<float>> _dataLeashRange;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLeashRangeModified;
        private readonly Lazy<ObjectProperty<string>> _dataFactoryUnitIDRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFactoryUnitIDModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataFactoryUnitID;
        public TinkererSummonFactoryLevel0(): base(2037599809)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _isDataSpawnUnitDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitDurationModified));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _isDataSpawnUnitOffsetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitOffsetModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _isDataFactoryUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFactoryUnitIDModified));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public TinkererSummonFactoryLevel0(int newId): base(2037599809, newId)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _isDataSpawnUnitDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitDurationModified));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _isDataSpawnUnitOffsetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitOffsetModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _isDataFactoryUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFactoryUnitIDModified));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public TinkererSummonFactoryLevel0(string newRawcode): base(2037599809, newRawcode)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _isDataSpawnUnitDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitDurationModified));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _isDataSpawnUnitOffsetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitOffsetModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _isDataFactoryUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFactoryUnitIDModified));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public TinkererSummonFactoryLevel0(ObjectDatabaseBase db): base(2037599809, db)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _isDataSpawnUnitDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitDurationModified));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _isDataSpawnUnitOffsetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitOffsetModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _isDataFactoryUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFactoryUnitIDModified));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public TinkererSummonFactoryLevel0(int newId, ObjectDatabaseBase db): base(2037599809, newId, db)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _isDataSpawnUnitDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitDurationModified));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _isDataSpawnUnitOffsetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitOffsetModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _isDataFactoryUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFactoryUnitIDModified));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public TinkererSummonFactoryLevel0(string newRawcode, ObjectDatabaseBase db): base(2037599809, newRawcode, db)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _isDataSpawnUnitDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitDurationModified));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _isDataSpawnUnitOffsetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitOffsetModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _isDataFactoryUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFactoryUnitIDModified));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public ObjectProperty<float> DataSpawnInterval => _dataSpawnInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataSpawnIntervalModified => _isDataSpawnIntervalModified.Value;
        public ObjectProperty<string> DataSpawnUnitIDRaw => _dataSpawnUnitIDRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSpawnUnitIDModified => _isDataSpawnUnitIDModified.Value;
        public ObjectProperty<Unit> DataSpawnUnitID => _dataSpawnUnitID.Value;
        public ObjectProperty<float> DataSpawnUnitDuration => _dataSpawnUnitDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataSpawnUnitDurationModified => _isDataSpawnUnitDurationModified.Value;
        public ObjectProperty<float> DataSpawnUnitOffset => _dataSpawnUnitOffset.Value;
        public ReadOnlyObjectProperty<bool> IsDataSpawnUnitOffsetModified => _isDataSpawnUnitOffsetModified.Value;
        public ObjectProperty<float> DataLeashRange => _dataLeashRange.Value;
        public ReadOnlyObjectProperty<bool> IsDataLeashRangeModified => _isDataLeashRangeModified.Value;
        public ObjectProperty<string> DataFactoryUnitIDRaw => _dataFactoryUnitIDRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataFactoryUnitIDModified => _isDataFactoryUnitIDModified.Value;
        public ObjectProperty<Unit> DataFactoryUnitID => _dataFactoryUnitID.Value;
        private float GetDataSpawnInterval(int level)
        {
            return _modifications.GetModification(830042958, level).ValueAsFloat;
        }

        private void SetDataSpawnInterval(int level, float value)
        {
            _modifications[830042958, level] = new LevelObjectDataModification{Id = 830042958, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataSpawnIntervalModified(int level)
        {
            return _modifications.ContainsKey(830042958, level);
        }

        private string GetDataSpawnUnitIDRaw(int level)
        {
            return _modifications.GetModification(846820174, level).ValueAsString;
        }

        private void SetDataSpawnUnitIDRaw(int level, string value)
        {
            _modifications[846820174, level] = new LevelObjectDataModification{Id = 846820174, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataSpawnUnitIDModified(int level)
        {
            return _modifications.ContainsKey(846820174, level);
        }

        private Unit GetDataSpawnUnitID(int level)
        {
            return GetDataSpawnUnitIDRaw(level).ToUnit(this);
        }

        private void SetDataSpawnUnitID(int level, Unit value)
        {
            SetDataSpawnUnitIDRaw(level, value.ToRaw(null, null));
        }

        private float GetDataSpawnUnitDuration(int level)
        {
            return _modifications.GetModification(863597390, level).ValueAsFloat;
        }

        private void SetDataSpawnUnitDuration(int level, float value)
        {
            _modifications[863597390, level] = new LevelObjectDataModification{Id = 863597390, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataSpawnUnitDurationModified(int level)
        {
            return _modifications.ContainsKey(863597390, level);
        }

        private float GetDataSpawnUnitOffset(int level)
        {
            return _modifications.GetModification(880374606, level).ValueAsFloat;
        }

        private void SetDataSpawnUnitOffset(int level, float value)
        {
            _modifications[880374606, level] = new LevelObjectDataModification{Id = 880374606, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataSpawnUnitOffsetModified(int level)
        {
            return _modifications.ContainsKey(880374606, level);
        }

        private float GetDataLeashRange(int level)
        {
            return _modifications.GetModification(897151822, level).ValueAsFloat;
        }

        private void SetDataLeashRange(int level, float value)
        {
            _modifications[897151822, level] = new LevelObjectDataModification{Id = 897151822, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataLeashRangeModified(int level)
        {
            return _modifications.ContainsKey(897151822, level);
        }

        private string GetDataFactoryUnitIDRaw(int level)
        {
            return _modifications.GetModification(1970893646, level).ValueAsString;
        }

        private void SetDataFactoryUnitIDRaw(int level, string value)
        {
            _modifications[1970893646, level] = new LevelObjectDataModification{Id = 1970893646, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataFactoryUnitIDModified(int level)
        {
            return _modifications.ContainsKey(1970893646, level);
        }

        private Unit GetDataFactoryUnitID(int level)
        {
            return GetDataFactoryUnitIDRaw(level).ToUnit(this);
        }

        private void SetDataFactoryUnitID(int level, Unit value)
        {
            SetDataFactoryUnitIDRaw(level, value.ToRaw(null, null));
        }
    }
}