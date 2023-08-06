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
    public sealed class TornadoSpin : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAirTimeseconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAirTimesecondsModified;
        private readonly Lazy<ObjectProperty<float>> _dataMinimumHitIntervalseconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMinimumHitIntervalsecondsModified;
        public TornadoSpin(): base(1886614593)
        {
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataMinimumHitIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalseconds, SetDataMinimumHitIntervalseconds));
            _isDataMinimumHitIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalsecondsModified));
        }

        public TornadoSpin(int newId): base(1886614593, newId)
        {
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataMinimumHitIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalseconds, SetDataMinimumHitIntervalseconds));
            _isDataMinimumHitIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalsecondsModified));
        }

        public TornadoSpin(string newRawcode): base(1886614593, newRawcode)
        {
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataMinimumHitIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalseconds, SetDataMinimumHitIntervalseconds));
            _isDataMinimumHitIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalsecondsModified));
        }

        public TornadoSpin(ObjectDatabaseBase db): base(1886614593, db)
        {
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataMinimumHitIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalseconds, SetDataMinimumHitIntervalseconds));
            _isDataMinimumHitIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalsecondsModified));
        }

        public TornadoSpin(int newId, ObjectDatabaseBase db): base(1886614593, newId, db)
        {
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataMinimumHitIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalseconds, SetDataMinimumHitIntervalseconds));
            _isDataMinimumHitIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalsecondsModified));
        }

        public TornadoSpin(string newRawcode, ObjectDatabaseBase db): base(1886614593, newRawcode, db)
        {
            _dataAirTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirTimeseconds, SetDataAirTimeseconds));
            _isDataAirTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirTimesecondsModified));
            _dataMinimumHitIntervalseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumHitIntervalseconds, SetDataMinimumHitIntervalseconds));
            _isDataMinimumHitIntervalsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumHitIntervalsecondsModified));
        }

        public ObjectProperty<float> DataAirTimeseconds => _dataAirTimeseconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataAirTimesecondsModified => _isDataAirTimesecondsModified.Value;
        public ObjectProperty<float> DataMinimumHitIntervalseconds => _dataMinimumHitIntervalseconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataMinimumHitIntervalsecondsModified => _isDataMinimumHitIntervalsecondsModified.Value;
        private float GetDataAirTimeseconds(int level)
        {
            return _modifications.GetModification(829453140, level).ValueAsFloat;
        }

        private void SetDataAirTimeseconds(int level, float value)
        {
            _modifications[829453140, level] = new LevelObjectDataModification{Id = 829453140, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAirTimesecondsModified(int level)
        {
            return _modifications.ContainsKey(829453140, level);
        }

        private float GetDataMinimumHitIntervalseconds(int level)
        {
            return _modifications.GetModification(846230356, level).ValueAsFloat;
        }

        private void SetDataMinimumHitIntervalseconds(int level, float value)
        {
            _modifications[846230356, level] = new LevelObjectDataModification{Id = 846230356, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMinimumHitIntervalsecondsModified(int level)
        {
            return _modifications.ContainsKey(846230356, level);
        }
    }
}