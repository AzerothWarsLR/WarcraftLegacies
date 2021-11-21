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
    public sealed class MindRot : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaDrainedPerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaDrainedPerSecondModified;
        public MindRot(): base(1919766081)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
        }

        public MindRot(int newId): base(1919766081, newId)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
        }

        public MindRot(string newRawcode): base(1919766081, newRawcode)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
        }

        public MindRot(ObjectDatabaseBase db): base(1919766081, db)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
        }

        public MindRot(int newId, ObjectDatabaseBase db): base(1919766081, newId, db)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
        }

        public MindRot(string newRawcode, ObjectDatabaseBase db): base(1919766081, newRawcode, db)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
        }

        public ObjectProperty<float> DataManaDrainedPerSecond => _dataManaDrainedPerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaDrainedPerSecondModified => _isDataManaDrainedPerSecondModified.Value;
        private float GetDataManaDrainedPerSecond(int level)
        {
            return _modifications.GetModification(829582670, level).ValueAsFloat;
        }

        private void SetDataManaDrainedPerSecond(int level, float value)
        {
            _modifications[829582670, level] = new LevelObjectDataModification{Id = 829582670, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataManaDrainedPerSecondModified(int level)
        {
            return _modifications.ContainsKey(829582670, level);
        }
    }
}