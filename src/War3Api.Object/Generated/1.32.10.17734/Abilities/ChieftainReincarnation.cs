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
    public sealed class ChieftainReincarnation : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataReincarnationDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataReincarnationDelayModified;
        public ChieftainReincarnation(): base(1701990209)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
            _isDataReincarnationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReincarnationDelayModified));
        }

        public ChieftainReincarnation(int newId): base(1701990209, newId)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
            _isDataReincarnationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReincarnationDelayModified));
        }

        public ChieftainReincarnation(string newRawcode): base(1701990209, newRawcode)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
            _isDataReincarnationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReincarnationDelayModified));
        }

        public ChieftainReincarnation(ObjectDatabaseBase db): base(1701990209, db)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
            _isDataReincarnationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReincarnationDelayModified));
        }

        public ChieftainReincarnation(int newId, ObjectDatabaseBase db): base(1701990209, newId, db)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
            _isDataReincarnationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReincarnationDelayModified));
        }

        public ChieftainReincarnation(string newRawcode, ObjectDatabaseBase db): base(1701990209, newRawcode, db)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
            _isDataReincarnationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReincarnationDelayModified));
        }

        public ObjectProperty<float> DataReincarnationDelay => _dataReincarnationDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataReincarnationDelayModified => _isDataReincarnationDelayModified.Value;
        private float GetDataReincarnationDelay(int level)
        {
            return _modifications.GetModification(828731983, level).ValueAsFloat;
        }

        private void SetDataReincarnationDelay(int level, float value)
        {
            _modifications[828731983, level] = new LevelObjectDataModification{Id = 828731983, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataReincarnationDelayModified(int level)
        {
            return _modifications.ContainsKey(828731983, level);
        }
    }
}