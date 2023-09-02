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
    public sealed class Factory : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataSpawnInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSpawnIntervalModified;
        private readonly Lazy<ObjectProperty<float>> _dataLeashRange;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLeashRangeModified;
        private readonly Lazy<ObjectProperty<string>> _dataSpawnUnitIDRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSpawnUnitIDModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataSpawnUnitID;
        public Factory(): base(2036747841)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
        }

        public Factory(int newId): base(2036747841, newId)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
        }

        public Factory(string newRawcode): base(2036747841, newRawcode)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
        }

        public Factory(ObjectDatabaseBase db): base(2036747841, db)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
        }

        public Factory(int newId, ObjectDatabaseBase db): base(2036747841, newId, db)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
        }

        public Factory(string newRawcode, ObjectDatabaseBase db): base(2036747841, newRawcode, db)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _isDataSpawnIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnIntervalModified));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _isDataLeashRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeashRangeModified));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _isDataSpawnUnitIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpawnUnitIDModified));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
        }

        public ObjectProperty<float> DataSpawnInterval => _dataSpawnInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataSpawnIntervalModified => _isDataSpawnIntervalModified.Value;
        public ObjectProperty<float> DataLeashRange => _dataLeashRange.Value;
        public ReadOnlyObjectProperty<bool> IsDataLeashRangeModified => _isDataLeashRangeModified.Value;
        public ObjectProperty<string> DataSpawnUnitIDRaw => _dataSpawnUnitIDRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSpawnUnitIDModified => _isDataSpawnUnitIDModified.Value;
        public ObjectProperty<Unit> DataSpawnUnitID => _dataSpawnUnitID.Value;
        private float GetDataSpawnInterval(int level)
        {
            return _modifications.GetModification(830039630, level).ValueAsFloat;
        }

        private void SetDataSpawnInterval(int level, float value)
        {
            _modifications[830039630, level] = new LevelObjectDataModification{Id = 830039630, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataSpawnIntervalModified(int level)
        {
            return _modifications.ContainsKey(830039630, level);
        }

        private float GetDataLeashRange(int level)
        {
            return _modifications.GetModification(846816846, level).ValueAsFloat;
        }

        private void SetDataLeashRange(int level, float value)
        {
            _modifications[846816846, level] = new LevelObjectDataModification{Id = 846816846, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLeashRangeModified(int level)
        {
            return _modifications.ContainsKey(846816846, level);
        }

        private string GetDataSpawnUnitIDRaw(int level)
        {
            return _modifications.GetModification(1970890318, level).ValueAsString;
        }

        private void SetDataSpawnUnitIDRaw(int level, string value)
        {
            _modifications[1970890318, level] = new LevelObjectDataModification{Id = 1970890318, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataSpawnUnitIDModified(int level)
        {
            return _modifications.ContainsKey(1970890318, level);
        }

        private Unit GetDataSpawnUnitID(int level)
        {
            return GetDataSpawnUnitIDRaw(level).ToUnit(this);
        }

        private void SetDataSpawnUnitID(int level, Unit value)
        {
            SetDataSpawnUnitIDRaw(level, value.ToRaw(null, null));
        }
    }
}