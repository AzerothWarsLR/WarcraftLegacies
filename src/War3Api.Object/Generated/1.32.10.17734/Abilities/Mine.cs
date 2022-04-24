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
    public sealed class Mine : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataActivationDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataActivationDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataInvisibilityTransitionTime;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInvisibilityTransitionTimeModified;
        public Mine(): base(1852403009)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataInvisibilityTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInvisibilityTransitionTime, SetDataInvisibilityTransitionTime));
            _isDataInvisibilityTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInvisibilityTransitionTimeModified));
        }

        public Mine(int newId): base(1852403009, newId)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataInvisibilityTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInvisibilityTransitionTime, SetDataInvisibilityTransitionTime));
            _isDataInvisibilityTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInvisibilityTransitionTimeModified));
        }

        public Mine(string newRawcode): base(1852403009, newRawcode)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataInvisibilityTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInvisibilityTransitionTime, SetDataInvisibilityTransitionTime));
            _isDataInvisibilityTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInvisibilityTransitionTimeModified));
        }

        public Mine(ObjectDatabaseBase db): base(1852403009, db)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataInvisibilityTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInvisibilityTransitionTime, SetDataInvisibilityTransitionTime));
            _isDataInvisibilityTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInvisibilityTransitionTimeModified));
        }

        public Mine(int newId, ObjectDatabaseBase db): base(1852403009, newId, db)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataInvisibilityTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInvisibilityTransitionTime, SetDataInvisibilityTransitionTime));
            _isDataInvisibilityTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInvisibilityTransitionTimeModified));
        }

        public Mine(string newRawcode, ObjectDatabaseBase db): base(1852403009, newRawcode, db)
        {
            _dataActivationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationDelay, SetDataActivationDelay));
            _isDataActivationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationDelayModified));
            _dataInvisibilityTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInvisibilityTransitionTime, SetDataInvisibilityTransitionTime));
            _isDataInvisibilityTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInvisibilityTransitionTimeModified));
        }

        public ObjectProperty<float> DataActivationDelay => _dataActivationDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataActivationDelayModified => _isDataActivationDelayModified.Value;
        public ObjectProperty<float> DataInvisibilityTransitionTime => _dataInvisibilityTransitionTime.Value;
        public ReadOnlyObjectProperty<bool> IsDataInvisibilityTransitionTimeModified => _isDataInvisibilityTransitionTimeModified.Value;
        private float GetDataActivationDelay(int level)
        {
            return _modifications.GetModification(829319501, level).ValueAsFloat;
        }

        private void SetDataActivationDelay(int level, float value)
        {
            _modifications[829319501, level] = new LevelObjectDataModification{Id = 829319501, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataActivationDelayModified(int level)
        {
            return _modifications.ContainsKey(829319501, level);
        }

        private float GetDataInvisibilityTransitionTime(int level)
        {
            return _modifications.GetModification(846096717, level).ValueAsFloat;
        }

        private void SetDataInvisibilityTransitionTime(int level, float value)
        {
            _modifications[846096717, level] = new LevelObjectDataModification{Id = 846096717, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataInvisibilityTransitionTimeModified(int level)
        {
            return _modifications.ContainsKey(846096717, level);
        }
    }
}