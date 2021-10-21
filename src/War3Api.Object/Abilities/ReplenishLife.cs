using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ReplenishLife : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        private readonly Lazy<ObjectProperty<float>> _dataMinimumLifeRequired;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumUnitsChargedToCaster;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumUnitsAffected;
        public ReplenishLife(): base(1819308609)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
        }

        public ReplenishLife(int newId): base(1819308609, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
        }

        public ReplenishLife(string newRawcode): base(1819308609, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
        }

        public ReplenishLife(ObjectDatabase db): base(1819308609, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
        }

        public ReplenishLife(int newId, ObjectDatabase db): base(1819308609, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
        }

        public ReplenishLife(string newRawcode, ObjectDatabase db): base(1819308609, newRawcode, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
        }

        public ObjectProperty<float> DataHitPointsGained => _dataHitPointsGained.Value;
        public ObjectProperty<float> DataMinimumLifeRequired => _dataMinimumLifeRequired.Value;
        public ObjectProperty<int> DataMaximumUnitsChargedToCaster => _dataMaximumUnitsChargedToCaster.Value;
        public ObjectProperty<int> DataMaximumUnitsAffected => _dataMaximumUnitsAffected.Value;
        private float GetDataHitPointsGained(int level)
        {
            return _modifications[829056338, level].ValueAsFloat;
        }

        private void SetDataHitPointsGained(int level, float value)
        {
            _modifications[829056338, level] = new LevelObjectDataModification{Id = 829056338, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMinimumLifeRequired(int level)
        {
            return _modifications[862089298, level].ValueAsFloat;
        }

        private void SetDataMinimumLifeRequired(int level, float value)
        {
            _modifications[862089298, level] = new LevelObjectDataModification{Id = 862089298, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private int GetDataMaximumUnitsChargedToCaster(int level)
        {
            return _modifications[895643730, level].ValueAsInt;
        }

        private void SetDataMaximumUnitsChargedToCaster(int level, int value)
        {
            _modifications[895643730, level] = new LevelObjectDataModification{Id = 895643730, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private int GetDataMaximumUnitsAffected(int level)
        {
            return _modifications[912420946, level].ValueAsInt;
        }

        private void SetDataMaximumUnitsAffected(int level, int value)
        {
            _modifications[912420946, level] = new LevelObjectDataModification{Id = 912420946, Type = ObjectDataType.Int, Value = value, Level = level};
        }
    }
}