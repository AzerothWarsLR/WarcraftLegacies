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
    public sealed class FingerOfDeath_ANfd : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataGraphicDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGraphicDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataGraphicDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGraphicDurationModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageModified;
        public FingerOfDeath_ANfd(): base(1684426305)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
        }

        public FingerOfDeath_ANfd(int newId): base(1684426305, newId)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
        }

        public FingerOfDeath_ANfd(string newRawcode): base(1684426305, newRawcode)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
        }

        public FingerOfDeath_ANfd(ObjectDatabaseBase db): base(1684426305, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
        }

        public FingerOfDeath_ANfd(int newId, ObjectDatabaseBase db): base(1684426305, newId, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
        }

        public FingerOfDeath_ANfd(string newRawcode, ObjectDatabaseBase db): base(1684426305, newRawcode, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _isDataGraphicDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDelayModified));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _isDataGraphicDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGraphicDurationModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
        }

        public ObjectProperty<float> DataGraphicDelay => _dataGraphicDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataGraphicDelayModified => _isDataGraphicDelayModified.Value;
        public ObjectProperty<float> DataGraphicDuration => _dataGraphicDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataGraphicDurationModified => _isDataGraphicDurationModified.Value;
        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageModified => _isDataDamageModified.Value;
        private float GetDataGraphicDelay(int level)
        {
            return _modifications.GetModification(828663374, level).ValueAsFloat;
        }

        private void SetDataGraphicDelay(int level, float value)
        {
            _modifications[828663374, level] = new LevelObjectDataModification{Id = 828663374, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataGraphicDelayModified(int level)
        {
            return _modifications.ContainsKey(828663374, level);
        }

        private float GetDataGraphicDuration(int level)
        {
            return _modifications.GetModification(845440590, level).ValueAsFloat;
        }

        private void SetDataGraphicDuration(int level, float value)
        {
            _modifications[845440590, level] = new LevelObjectDataModification{Id = 845440590, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataGraphicDurationModified(int level)
        {
            return _modifications.ContainsKey(845440590, level);
        }

        private float GetDataDamage(int level)
        {
            return _modifications.GetModification(862217806, level).ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[862217806, level] = new LevelObjectDataModification{Id = 862217806, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageModified(int level)
        {
            return _modifications.ContainsKey(862217806, level);
        }
    }
}