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
    public sealed class Invisibility : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataTransitionTimeSeconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTransitionTimeSecondsModified;
        public Invisibility(): base(1937140033)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
            _isDataTransitionTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeSecondsModified));
        }

        public Invisibility(int newId): base(1937140033, newId)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
            _isDataTransitionTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeSecondsModified));
        }

        public Invisibility(string newRawcode): base(1937140033, newRawcode)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
            _isDataTransitionTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeSecondsModified));
        }

        public Invisibility(ObjectDatabaseBase db): base(1937140033, db)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
            _isDataTransitionTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeSecondsModified));
        }

        public Invisibility(int newId, ObjectDatabaseBase db): base(1937140033, newId, db)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
            _isDataTransitionTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeSecondsModified));
        }

        public Invisibility(string newRawcode, ObjectDatabaseBase db): base(1937140033, newRawcode, db)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
            _isDataTransitionTimeSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeSecondsModified));
        }

        public ObjectProperty<float> DataTransitionTimeSeconds => _dataTransitionTimeSeconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataTransitionTimeSecondsModified => _isDataTransitionTimeSecondsModified.Value;
        private float GetDataTransitionTimeSeconds(int level)
        {
            return _modifications.GetModification(829650505, level).ValueAsFloat;
        }

        private void SetDataTransitionTimeSeconds(int level, float value)
        {
            _modifications[829650505, level] = new LevelObjectDataModification{Id = 829650505, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataTransitionTimeSecondsModified(int level)
        {
            return _modifications.ContainsKey(829650505, level);
        }
    }
}