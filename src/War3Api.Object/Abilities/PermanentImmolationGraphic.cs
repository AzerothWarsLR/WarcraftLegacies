using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PermanentImmolationGraphic : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerInterval;
        private readonly Lazy<ObjectProperty<float>> _dataManaDrainedPerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataBufferManaRequired;
        public PermanentImmolationGraphic(): base(1734963265)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
        }

        public PermanentImmolationGraphic(int newId): base(1734963265, newId)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
        }

        public PermanentImmolationGraphic(string newRawcode): base(1734963265, newRawcode)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
        }

        public PermanentImmolationGraphic(ObjectDatabase db): base(1734963265, db)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
        }

        public PermanentImmolationGraphic(int newId, ObjectDatabase db): base(1734963265, newId, db)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
        }

        public PermanentImmolationGraphic(string newRawcode, ObjectDatabase db): base(1734963265, newRawcode, db)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
        }

        public ObjectProperty<float> DataDamagePerInterval => _dataDamagePerInterval.Value;
        public ObjectProperty<float> DataManaDrainedPerSecond => _dataManaDrainedPerSecond.Value;
        public ObjectProperty<float> DataBufferManaRequired => _dataBufferManaRequired.Value;
        private float GetDataDamagePerInterval(int level)
        {
            return _modifications[829253957, level].ValueAsFloat;
        }

        private void SetDataDamagePerInterval(int level, float value)
        {
            _modifications[829253957, level] = new LevelObjectDataModification{Id = 829253957, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataManaDrainedPerSecond(int level)
        {
            return _modifications[846031173, level].ValueAsFloat;
        }

        private void SetDataManaDrainedPerSecond(int level, float value)
        {
            _modifications[846031173, level] = new LevelObjectDataModification{Id = 846031173, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataBufferManaRequired(int level)
        {
            return _modifications[862808389, level].ValueAsFloat;
        }

        private void SetDataBufferManaRequired(int level, float value)
        {
            _modifications[862808389, level] = new LevelObjectDataModification{Id = 862808389, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}