using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TornadoSpin : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAirTimeSeconds;
        private readonly Lazy<ObjectProperty<float>> _dataMinimumHitIntervalSeconds;
        public TornadoSpin(): base(1886614593)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
        }

        public TornadoSpin(int newId): base(1886614593, newId)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
        }

        public TornadoSpin(string newRawcode): base(1886614593, newRawcode)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
        }

        public TornadoSpin(ObjectDatabase db): base(1886614593, db)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
        }

        public TornadoSpin(int newId, ObjectDatabase db): base(1886614593, newId, db)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
        }

        public TornadoSpin(string newRawcode, ObjectDatabase db): base(1886614593, newRawcode, db)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
        }

        public ObjectProperty<float> DataAirTimeSeconds => _dataAirTimeSeconds.Value;
        public ObjectProperty<float> DataMinimumHitIntervalSeconds => _dataMinimumHitIntervalSeconds.Value;
        private float GetDataAirTimeSeconds(int level)
        {
            return _modifications[829453140, level].ValueAsFloat;
        }

        private void SetDataAirTimeSeconds(int level, float value)
        {
            _modifications[829453140, level] = new LevelObjectDataModification{Id = 829453140, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMinimumHitIntervalSeconds(int level)
        {
            return _modifications[846230356, level].ValueAsFloat;
        }

        private void SetDataMinimumHitIntervalSeconds(int level, float value)
        {
            _modifications[846230356, level] = new LevelObjectDataModification{Id = 846230356, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}