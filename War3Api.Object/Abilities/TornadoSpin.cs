using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TornadoSpin : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAirTimeSeconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAirTimeSecondsModified;
        private readonly Lazy<ObjectProperty<float>> _dataMinimumHitIntervalSeconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMinimumHitIntervalSecondsModified;
        public TornadoSpin(): base(1886614593)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _isDataAirTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimeSecondsModified));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
            _isDataMinimumHitIntervalSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalSecondsModified));
        }

        public TornadoSpin(int newId): base(1886614593, newId)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _isDataAirTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimeSecondsModified));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
            _isDataMinimumHitIntervalSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalSecondsModified));
        }

        public TornadoSpin(string newRawcode): base(1886614593, newRawcode)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _isDataAirTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimeSecondsModified));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
            _isDataMinimumHitIntervalSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalSecondsModified));
        }

        public TornadoSpin(ObjectDatabase db): base(1886614593, db)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _isDataAirTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimeSecondsModified));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
            _isDataMinimumHitIntervalSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalSecondsModified));
        }

        public TornadoSpin(int newId, ObjectDatabase db): base(1886614593, newId, db)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _isDataAirTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimeSecondsModified));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
            _isDataMinimumHitIntervalSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalSecondsModified));
        }

        public TornadoSpin(string newRawcode, ObjectDatabase db): base(1886614593, newRawcode, db)
        {
            _dataAirTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeSeconds, SetDataAirTimeSeconds));
            _isDataAirTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimeSecondsModified));
            _dataMinimumHitIntervalSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalSeconds, SetDataMinimumHitIntervalSeconds));
            _isDataMinimumHitIntervalSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalSecondsModified));
        }

        public ObjectProperty<float> DataAirTimeSeconds => _dataAirTimeSeconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataAirTimeSecondsModified => _isDataAirTimeSecondsModified.Value;
        public ObjectProperty<float> DataMinimumHitIntervalSeconds => _dataMinimumHitIntervalSeconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataMinimumHitIntervalSecondsModified => _isDataMinimumHitIntervalSecondsModified.Value;
        private float GetDataAirTimeSeconds(int level)
        {
            return _modifications[829453140, level].ValueAsFloat;
        }

        private void SetDataAirTimeSeconds(int level, float value)
        {
            _modifications[829453140, level] = new LevelObjectDataModification{Id = 829453140, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAirTimeSecondsModified(int level)
        {
            return _modifications.ContainsKey(829453140, level);
        }

        private float GetDataMinimumHitIntervalSeconds(int level)
        {
            return _modifications[846230356, level].ValueAsFloat;
        }

        private void SetDataMinimumHitIntervalSeconds(int level, float value)
        {
            _modifications[846230356, level] = new LevelObjectDataModification{Id = 846230356, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMinimumHitIntervalSecondsModified(int level)
        {
            return _modifications.ContainsKey(846230356, level);
        }
    }
}