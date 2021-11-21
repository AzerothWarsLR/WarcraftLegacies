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
    public sealed class HealCreepHigh : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsGainedModified;
        public HealCreepHigh(): base(845704769)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public HealCreepHigh(int newId): base(845704769, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public HealCreepHigh(string newRawcode): base(845704769, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public HealCreepHigh(ObjectDatabaseBase db): base(845704769, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public HealCreepHigh(int newId, ObjectDatabaseBase db): base(845704769, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public HealCreepHigh(string newRawcode, ObjectDatabaseBase db): base(845704769, newRawcode, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public ObjectProperty<float> DataHitPointsGained => _dataHitPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointsGainedModified => _isDataHitPointsGainedModified.Value;
        private float GetDataHitPointsGained(int level)
        {
            return _modifications.GetModification(828466504, level).ValueAsFloat;
        }

        private void SetDataHitPointsGained(int level, float value)
        {
            _modifications[828466504, level] = new LevelObjectDataModification{Id = 828466504, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataHitPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(828466504, level);
        }
    }
}