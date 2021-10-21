using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Rejuvination : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        private readonly Lazy<ObjectProperty<float>> _dataManaPointsGained;
        private readonly Lazy<ObjectProperty<int>> _dataAllowWhenFullRaw;
        private readonly Lazy<ObjectProperty<FullFlags>> _dataAllowWhenFull;
        private readonly Lazy<ObjectProperty<bool>> _dataNoTargetRequired;
        public Rejuvination(): base(1785033281)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public Rejuvination(int newId): base(1785033281, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public Rejuvination(string newRawcode): base(1785033281, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public Rejuvination(ObjectDatabase db): base(1785033281, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public Rejuvination(int newId, ObjectDatabase db): base(1785033281, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public Rejuvination(string newRawcode, ObjectDatabase db): base(1785033281, newRawcode, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
        }

        public ObjectProperty<float> DataHitPointsGained => _dataHitPointsGained.Value;
        public ObjectProperty<float> DataManaPointsGained => _dataManaPointsGained.Value;
        public ObjectProperty<int> DataAllowWhenFullRaw => _dataAllowWhenFullRaw.Value;
        public ObjectProperty<FullFlags> DataAllowWhenFull => _dataAllowWhenFull.Value;
        public ObjectProperty<bool> DataNoTargetRequired => _dataNoTargetRequired.Value;
        private float GetDataHitPointsGained(int level)
        {
            return _modifications[829056338, level].ValueAsFloat;
        }

        private void SetDataHitPointsGained(int level, float value)
        {
            _modifications[829056338, level] = new LevelObjectDataModification{Id = 829056338, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataManaPointsGained(int level)
        {
            return _modifications[845833554, level].ValueAsFloat;
        }

        private void SetDataManaPointsGained(int level, float value)
        {
            _modifications[845833554, level] = new LevelObjectDataModification{Id = 845833554, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataAllowWhenFullRaw(int level)
        {
            return _modifications[862610770, level].ValueAsInt;
        }

        private void SetDataAllowWhenFullRaw(int level, int value)
        {
            _modifications[862610770, level] = new LevelObjectDataModification{Id = 862610770, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private FullFlags GetDataAllowWhenFull(int level)
        {
            return GetDataAllowWhenFullRaw(level).ToFullFlags(this);
        }

        private void SetDataAllowWhenFull(int level, FullFlags value)
        {
            SetDataAllowWhenFullRaw(level, value.ToRaw(null, null));
        }

        private bool GetDataNoTargetRequired(int level)
        {
            return _modifications[879387986, level].ValueAsBool;
        }

        private void SetDataNoTargetRequired(int level, bool value)
        {
            _modifications[879387986, level] = new LevelObjectDataModification{Id = 879387986, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }
    }
}