using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TinkererSummonFactoryLevel2 : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataSpawnInterval;
        private readonly Lazy<ObjectProperty<string>> _dataSpawnUnitIDRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataSpawnUnitID;
        private readonly Lazy<ObjectProperty<float>> _dataSpawnUnitDuration;
        private readonly Lazy<ObjectProperty<float>> _dataSpawnUnitOffset;
        private readonly Lazy<ObjectProperty<float>> _dataLeashRange;
        private readonly Lazy<ObjectProperty<string>> _dataFactoryUnitIDRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataFactoryUnitID;
        public TinkererSummonFactoryLevel2(): base(846417473)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public TinkererSummonFactoryLevel2(int newId): base(846417473, newId)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public TinkererSummonFactoryLevel2(string newRawcode): base(846417473, newRawcode)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public TinkererSummonFactoryLevel2(ObjectDatabase db): base(846417473, db)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public TinkererSummonFactoryLevel2(int newId, ObjectDatabase db): base(846417473, newId, db)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public TinkererSummonFactoryLevel2(string newRawcode, ObjectDatabase db): base(846417473, newRawcode, db)
        {
            _dataSpawnInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnInterval, SetDataSpawnInterval));
            _dataSpawnUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnUnitIDRaw, SetDataSpawnUnitIDRaw));
            _dataSpawnUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSpawnUnitID, SetDataSpawnUnitID));
            _dataSpawnUnitDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitDuration, SetDataSpawnUnitDuration));
            _dataSpawnUnitOffset = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpawnUnitOffset, SetDataSpawnUnitOffset));
            _dataLeashRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLeashRange, SetDataLeashRange));
            _dataFactoryUnitIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataFactoryUnitIDRaw, SetDataFactoryUnitIDRaw));
            _dataFactoryUnitID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataFactoryUnitID, SetDataFactoryUnitID));
        }

        public ObjectProperty<float> DataSpawnInterval => _dataSpawnInterval.Value;
        public ObjectProperty<string> DataSpawnUnitIDRaw => _dataSpawnUnitIDRaw.Value;
        public ObjectProperty<Unit> DataSpawnUnitID => _dataSpawnUnitID.Value;
        public ObjectProperty<float> DataSpawnUnitDuration => _dataSpawnUnitDuration.Value;
        public ObjectProperty<float> DataSpawnUnitOffset => _dataSpawnUnitOffset.Value;
        public ObjectProperty<float> DataLeashRange => _dataLeashRange.Value;
        public ObjectProperty<string> DataFactoryUnitIDRaw => _dataFactoryUnitIDRaw.Value;
        public ObjectProperty<Unit> DataFactoryUnitID => _dataFactoryUnitID.Value;
        private float GetDataSpawnInterval(int level)
        {
            return _modifications[830042958, level].ValueAsFloat;
        }

        private void SetDataSpawnInterval(int level, float value)
        {
            _modifications[830042958, level] = new LevelObjectDataModification{Id = 830042958, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private string GetDataSpawnUnitIDRaw(int level)
        {
            return _modifications[846820174, level].ValueAsString;
        }

        private void SetDataSpawnUnitIDRaw(int level, string value)
        {
            _modifications[846820174, level] = new LevelObjectDataModification{Id = 846820174, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 2};
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
            return _modifications[863597390, level].ValueAsFloat;
        }

        private void SetDataSpawnUnitDuration(int level, float value)
        {
            _modifications[863597390, level] = new LevelObjectDataModification{Id = 863597390, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataSpawnUnitOffset(int level)
        {
            return _modifications[880374606, level].ValueAsFloat;
        }

        private void SetDataSpawnUnitOffset(int level, float value)
        {
            _modifications[880374606, level] = new LevelObjectDataModification{Id = 880374606, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataLeashRange(int level)
        {
            return _modifications[897151822, level].ValueAsFloat;
        }

        private void SetDataLeashRange(int level, float value)
        {
            _modifications[897151822, level] = new LevelObjectDataModification{Id = 897151822, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private string GetDataFactoryUnitIDRaw(int level)
        {
            return _modifications[1970893646, level].ValueAsString;
        }

        private void SetDataFactoryUnitIDRaw(int level, string value)
        {
            _modifications[1970893646, level] = new LevelObjectDataModification{Id = 1970893646, Type = ObjectDataType.String, Value = value, Level = level};
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