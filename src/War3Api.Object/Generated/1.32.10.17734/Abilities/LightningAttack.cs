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
    public sealed class LightningAttack : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataGraphicDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGraphicDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataGraphicDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGraphicDurationModified;
        public LightningAttack(): base(1953066049)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
        }

        public LightningAttack(int newId): base(1953066049, newId)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
        }

        public LightningAttack(string newRawcode): base(1953066049, newRawcode)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
        }

        public LightningAttack(ObjectDatabaseBase db): base(1953066049, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
        }

        public LightningAttack(int newId, ObjectDatabaseBase db): base(1953066049, newId, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
        }

        public LightningAttack(string newRawcode, ObjectDatabaseBase db): base(1953066049, newRawcode, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
        }

        public ObjectProperty<float> DataGraphicDelay => _dataGraphicDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataGraphicDelayModified => _isDataGraphicDelayModified.Value;
        public ObjectProperty<float> DataGraphicDuration => _dataGraphicDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataGraphicDurationModified => _isDataGraphicDurationModified.Value;
        private float GetDataGraphicDelay(int level)
        {
            return _modifications.GetModification(829712716, level).ValueAsFloat;
        }

        private void SetDataGraphicDelay(int level, float value)
        {
            _modifications[829712716, level] = new LevelObjectDataModification{Id = 829712716, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataGraphicDelayModified(int level)
        {
            return _modifications.ContainsKey(829712716, level);
        }

        private float GetDataGraphicDuration(int level)
        {
            return _modifications.GetModification(846489932, level).ValueAsFloat;
        }

        private void SetDataGraphicDuration(int level, float value)
        {
            _modifications[846489932, level] = new LevelObjectDataModification{Id = 846489932, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataGraphicDurationModified(int level)
        {
            return _modifications.ContainsKey(846489932, level);
        }
    }
}