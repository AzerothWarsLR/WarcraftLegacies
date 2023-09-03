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
    public sealed class RejuvinationCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsGainedModified;
        private readonly Lazy<ObjectProperty<float>> _dataManaPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaPointsGainedModified;
        private readonly Lazy<ObjectProperty<int>> _dataAllowWhenFullRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAllowWhenFullModified;
        private readonly Lazy<ObjectProperty<FullFlags>> _dataAllowWhenFull;
        private readonly Lazy<ObjectProperty<int>> _dataNoTargetRequiredRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNoTargetRequiredModified;
        private readonly Lazy<ObjectProperty<bool>> _dataNoTargetRequired;
        public RejuvinationCreep(): base(1785873217)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public RejuvinationCreep(int newId): base(1785873217, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public RejuvinationCreep(string newRawcode): base(1785873217, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public RejuvinationCreep(ObjectDatabaseBase db): base(1785873217, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public RejuvinationCreep(int newId, ObjectDatabaseBase db): base(1785873217, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public RejuvinationCreep(string newRawcode, ObjectDatabaseBase db): base(1785873217, newRawcode, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public ObjectProperty<float> DataHitPointsGained => _dataHitPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointsGainedModified => _isDataHitPointsGainedModified.Value;
        public ObjectProperty<float> DataManaPointsGained => _dataManaPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaPointsGainedModified => _isDataManaPointsGainedModified.Value;
        public ObjectProperty<int> DataAllowWhenFullRaw => _dataAllowWhenFullRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAllowWhenFullModified => _isDataAllowWhenFullModified.Value;
        public ObjectProperty<FullFlags> DataAllowWhenFull => _dataAllowWhenFull.Value;
        public ObjectProperty<int> DataNoTargetRequiredRaw => _dataNoTargetRequiredRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataNoTargetRequiredModified => _isDataNoTargetRequiredModified.Value;
        public ObjectProperty<bool> DataNoTargetRequired => _dataNoTargetRequired.Value;
        private float GetDataHitPointsGained(int level)
        {
            return _modifications.GetModification(829056338, level).ValueAsFloat;
        }

        private void SetDataHitPointsGained(int level, float value)
        {
            _modifications[829056338, level] = new LevelObjectDataModification{Id = 829056338, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataHitPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(829056338, level);
        }

        private float GetDataManaPointsGained(int level)
        {
            return _modifications.GetModification(845833554, level).ValueAsFloat;
        }

        private void SetDataManaPointsGained(int level, float value)
        {
            _modifications[845833554, level] = new LevelObjectDataModification{Id = 845833554, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataManaPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(845833554, level);
        }

        private int GetDataAllowWhenFullRaw(int level)
        {
            return _modifications.GetModification(862610770, level).ValueAsInt;
        }

        private void SetDataAllowWhenFullRaw(int level, int value)
        {
            _modifications[862610770, level] = new LevelObjectDataModification{Id = 862610770, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAllowWhenFullModified(int level)
        {
            return _modifications.ContainsKey(862610770, level);
        }

        private FullFlags GetDataAllowWhenFull(int level)
        {
            return GetDataAllowWhenFullRaw(level).ToFullFlags(this);
        }

        private void SetDataAllowWhenFull(int level, FullFlags value)
        {
            SetDataAllowWhenFullRaw(level, value.ToRaw(null, null));
        }

        private int GetDataNoTargetRequiredRaw(int level)
        {
            return _modifications.GetModification(879387986, level).ValueAsInt;
        }

        private void SetDataNoTargetRequiredRaw(int level, int value)
        {
            _modifications[879387986, level] = new LevelObjectDataModification{Id = 879387986, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataNoTargetRequiredModified(int level)
        {
            return _modifications.ContainsKey(879387986, level);
        }

        private bool GetDataNoTargetRequired(int level)
        {
            return GetDataNoTargetRequiredRaw(level).ToBool(this);
        }

        private void SetDataNoTargetRequired(int level, bool value)
        {
            SetDataNoTargetRequiredRaw(level, value.ToRaw(null, null));
        }
    }
}