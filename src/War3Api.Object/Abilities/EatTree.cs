using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class EatTree : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataRipDelay;
        private readonly Lazy<ObjectProperty<float>> _dataEatDelay;
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        public EatTree(): base(1952539969)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public EatTree(int newId): base(1952539969, newId)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public EatTree(string newRawcode): base(1952539969, newRawcode)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public EatTree(ObjectDatabase db): base(1952539969, db)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public EatTree(int newId, ObjectDatabase db): base(1952539969, newId, db)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public EatTree(string newRawcode, ObjectDatabase db): base(1952539969, newRawcode, db)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ObjectProperty<float> DataRipDelay => _dataRipDelay.Value;
        public ObjectProperty<float> DataEatDelay => _dataEatDelay.Value;
        public ObjectProperty<float> DataHitPointsGained => _dataHitPointsGained.Value;
        private float GetDataRipDelay(int level)
        {
            return _modifications[829710661, level].ValueAsFloat;
        }

        private void SetDataRipDelay(int level, float value)
        {
            _modifications[829710661, level] = new LevelObjectDataModification{Id = 829710661, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataEatDelay(int level)
        {
            return _modifications[846487877, level].ValueAsFloat;
        }

        private void SetDataEatDelay(int level, float value)
        {
            _modifications[846487877, level] = new LevelObjectDataModification{Id = 846487877, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataHitPointsGained(int level)
        {
            return _modifications[863265093, level].ValueAsFloat;
        }

        private void SetDataHitPointsGained(int level, float value)
        {
            _modifications[863265093, level] = new LevelObjectDataModification{Id = 863265093, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}