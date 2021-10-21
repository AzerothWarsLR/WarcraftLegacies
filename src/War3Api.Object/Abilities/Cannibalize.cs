using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Cannibalize : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsPerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataMaxHitPoints;
        public Cannibalize(): base(1851876161)
        {
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _dataMaxHitPoints = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitPoints, SetDataMaxHitPoints));
        }

        public Cannibalize(int newId): base(1851876161, newId)
        {
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _dataMaxHitPoints = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitPoints, SetDataMaxHitPoints));
        }

        public Cannibalize(string newRawcode): base(1851876161, newRawcode)
        {
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _dataMaxHitPoints = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitPoints, SetDataMaxHitPoints));
        }

        public Cannibalize(ObjectDatabase db): base(1851876161, db)
        {
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _dataMaxHitPoints = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitPoints, SetDataMaxHitPoints));
        }

        public Cannibalize(int newId, ObjectDatabase db): base(1851876161, newId, db)
        {
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _dataMaxHitPoints = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitPoints, SetDataMaxHitPoints));
        }

        public Cannibalize(string newRawcode, ObjectDatabase db): base(1851876161, newRawcode, db)
        {
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _dataMaxHitPoints = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitPoints, SetDataMaxHitPoints));
        }

        public ObjectProperty<float> DataHitPointsPerSecond => _dataHitPointsPerSecond.Value;
        public ObjectProperty<float> DataMaxHitPoints => _dataMaxHitPoints.Value;
        private float GetDataHitPointsPerSecond(int level)
        {
            return _modifications[829317443, level].ValueAsFloat;
        }

        private void SetDataHitPointsPerSecond(int level, float value)
        {
            _modifications[829317443, level] = new LevelObjectDataModification{Id = 829317443, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMaxHitPoints(int level)
        {
            return _modifications[846094659, level].ValueAsFloat;
        }

        private void SetDataMaxHitPoints(int level, float value)
        {
            _modifications[846094659, level] = new LevelObjectDataModification{Id = 846094659, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}