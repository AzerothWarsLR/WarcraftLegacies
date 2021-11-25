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
        private readonly Lazy<ObjectProperty<float>> _dataTransitionTimeseconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTransitionTimesecondsModified;
        public Invisibility(): base(1937140033)
        {
            _dataTransitionTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeseconds, SetDataTransitionTimeseconds));
            _isDataTransitionTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimesecondsModified));
        }

        public Invisibility(int newId): base(1937140033, newId)
        {
            _dataTransitionTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeseconds, SetDataTransitionTimeseconds));
            _isDataTransitionTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimesecondsModified));
        }

        public Invisibility(string newRawcode): base(1937140033, newRawcode)
        {
            _dataTransitionTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeseconds, SetDataTransitionTimeseconds));
            _isDataTransitionTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimesecondsModified));
        }

        public Invisibility(ObjectDatabaseBase db): base(1937140033, db)
        {
            _dataTransitionTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeseconds, SetDataTransitionTimeseconds));
            _isDataTransitionTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimesecondsModified));
        }

        public Invisibility(int newId, ObjectDatabaseBase db): base(1937140033, newId, db)
        {
            _dataTransitionTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeseconds, SetDataTransitionTimeseconds));
            _isDataTransitionTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimesecondsModified));
        }

        public Invisibility(string newRawcode, ObjectDatabaseBase db): base(1937140033, newRawcode, db)
        {
            _dataTransitionTimeseconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeseconds, SetDataTransitionTimeseconds));
            _isDataTransitionTimesecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimesecondsModified));
        }

        public ObjectProperty<float> DataTransitionTimeseconds => _dataTransitionTimeseconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataTransitionTimesecondsModified => _isDataTransitionTimesecondsModified.Value;
        private float GetDataTransitionTimeseconds(int level)
        {
            return _modifications.GetModification(829650505, level).ValueAsFloat;
        }

        private void SetDataTransitionTimeseconds(int level, float value)
        {
            _modifications[829650505, level] = new LevelObjectDataModification{Id = 829650505, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataTransitionTimesecondsModified(int level)
        {
            return _modifications.ContainsKey(829650505, level);
        }
    }
}