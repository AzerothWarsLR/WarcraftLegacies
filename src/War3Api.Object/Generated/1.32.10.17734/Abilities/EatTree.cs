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
    public sealed class EatTree : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataRipDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRipDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataEatDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataEatDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsGainedModified;
        public EatTree(): base(1952539969)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _isDataRipDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRipDelayModified));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _isDataEatDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEatDelayModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public EatTree(int newId): base(1952539969, newId)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _isDataRipDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRipDelayModified));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _isDataEatDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEatDelayModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public EatTree(string newRawcode): base(1952539969, newRawcode)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _isDataRipDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRipDelayModified));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _isDataEatDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEatDelayModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public EatTree(ObjectDatabaseBase db): base(1952539969, db)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _isDataRipDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRipDelayModified));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _isDataEatDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEatDelayModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public EatTree(int newId, ObjectDatabaseBase db): base(1952539969, newId, db)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _isDataRipDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRipDelayModified));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _isDataEatDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEatDelayModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public EatTree(string newRawcode, ObjectDatabaseBase db): base(1952539969, newRawcode, db)
        {
            _dataRipDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRipDelay, SetDataRipDelay));
            _isDataRipDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRipDelayModified));
            _dataEatDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEatDelay, SetDataEatDelay));
            _isDataEatDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEatDelayModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
        }

        public ObjectProperty<float> DataRipDelay => _dataRipDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataRipDelayModified => _isDataRipDelayModified.Value;
        public ObjectProperty<float> DataEatDelay => _dataEatDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataEatDelayModified => _isDataEatDelayModified.Value;
        public ObjectProperty<float> DataHitPointsGained => _dataHitPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointsGainedModified => _isDataHitPointsGainedModified.Value;
        private float GetDataRipDelay(int level)
        {
            return _modifications.GetModification(829710661, level).ValueAsFloat;
        }

        private void SetDataRipDelay(int level, float value)
        {
            _modifications[829710661, level] = new LevelObjectDataModification{Id = 829710661, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataRipDelayModified(int level)
        {
            return _modifications.ContainsKey(829710661, level);
        }

        private float GetDataEatDelay(int level)
        {
            return _modifications.GetModification(846487877, level).ValueAsFloat;
        }

        private void SetDataEatDelay(int level, float value)
        {
            _modifications[846487877, level] = new LevelObjectDataModification{Id = 846487877, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataEatDelayModified(int level)
        {
            return _modifications.ContainsKey(846487877, level);
        }

        private float GetDataHitPointsGained(int level)
        {
            return _modifications.GetModification(863265093, level).ValueAsFloat;
        }

        private void SetDataHitPointsGained(int level, float value)
        {
            _modifications[863265093, level] = new LevelObjectDataModification{Id = 863265093, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataHitPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(863265093, level);
        }
    }
}