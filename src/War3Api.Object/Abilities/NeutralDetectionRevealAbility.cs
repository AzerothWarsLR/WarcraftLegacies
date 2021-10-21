using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class NeutralDetectionRevealAbility : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataGoldCost;
        private readonly Lazy<ObjectProperty<int>> _dataLumberCost;
        private readonly Lazy<ObjectProperty<int>> _dataDetectionTypeRaw;
        private readonly Lazy<ObjectProperty<DetectionType>> _dataDetectionType;
        public NeutralDetectionRevealAbility(): base(1952738881)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralDetectionRevealAbility(int newId): base(1952738881, newId)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralDetectionRevealAbility(string newRawcode): base(1952738881, newRawcode)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralDetectionRevealAbility(ObjectDatabase db): base(1952738881, db)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralDetectionRevealAbility(int newId, ObjectDatabase db): base(1952738881, newId, db)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralDetectionRevealAbility(string newRawcode, ObjectDatabase db): base(1952738881, newRawcode, db)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public ObjectProperty<int> DataGoldCost => _dataGoldCost.Value;
        public ObjectProperty<int> DataLumberCost => _dataLumberCost.Value;
        public ObjectProperty<int> DataDetectionTypeRaw => _dataDetectionTypeRaw.Value;
        public ObjectProperty<DetectionType> DataDetectionType => _dataDetectionType.Value;
        private int GetDataGoldCost(int level)
        {
            return _modifications[829711438, level].ValueAsInt;
        }

        private void SetDataGoldCost(int level, int value)
        {
            _modifications[829711438, level] = new LevelObjectDataModification{Id = 829711438, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataLumberCost(int level)
        {
            return _modifications[846488654, level].ValueAsInt;
        }

        private void SetDataLumberCost(int level, int value)
        {
            _modifications[846488654, level] = new LevelObjectDataModification{Id = 846488654, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataDetectionTypeRaw(int level)
        {
            return _modifications[863265870, level].ValueAsInt;
        }

        private void SetDataDetectionTypeRaw(int level, int value)
        {
            _modifications[863265870, level] = new LevelObjectDataModification{Id = 863265870, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
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