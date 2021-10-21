using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Sentinel : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataInFlightSightRadius;
        private readonly Lazy<ObjectProperty<float>> _dataHoveringSightRadius;
        private readonly Lazy<ObjectProperty<float>> _dataHoveringHeight;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfOwls;
        private readonly Lazy<ObjectProperty<float>> _dataDurationOfOwls;
        public Sentinel(): base(1853056321)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
        }

        public Sentinel(int newId): base(1853056321, newId)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
        }

        public Sentinel(string newRawcode): base(1853056321, newRawcode)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
        }

        public Sentinel(ObjectDatabase db): base(1853056321, db)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
        }

        public Sentinel(int newId, ObjectDatabase db): base(1853056321, newId, db)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
        }

        public Sentinel(string newRawcode, ObjectDatabase db): base(1853056321, newRawcode, db)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
        }

        public ObjectProperty<float> DataInFlightSightRadius => _dataInFlightSightRadius.Value;
        public ObjectProperty<float> DataHoveringSightRadius => _dataHoveringSightRadius.Value;
        public ObjectProperty<float> DataHoveringHeight => _dataHoveringHeight.Value;
        public ObjectProperty<int> DataNumberOfOwls => _dataNumberOfOwls.Value;
        public ObjectProperty<float> DataDurationOfOwls => _dataDurationOfOwls.Value;
        private float GetDataInFlightSightRadius(int level)
        {
            return _modifications[829322053, level].ValueAsFloat;
        }

        private void SetDataInFlightSightRadius(int level, float value)
        {
            _modifications[829322053, level] = new LevelObjectDataModification{Id = 829322053, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataHoveringSightRadius(int level)
        {
            return _modifications[846099269, level].ValueAsFloat;
        }

        private void SetDataHoveringSightRadius(int level, float value)
        {
            _modifications[846099269, level] = new LevelObjectDataModification{Id = 846099269, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataHoveringHeight(int level)
        {
            return _modifications[862876485, level].ValueAsFloat;
        }

        private void SetDataHoveringHeight(int level, float value)
        {
            _modifications[862876485, level] = new LevelObjectDataModification{Id = 862876485, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private int GetDataNumberOfOwls(int level)
        {
            return _modifications[879653701, level].ValueAsInt;
        }

        private void SetDataNumberOfOwls(int level, int value)
        {
            _modifications[879653701, level] = new LevelObjectDataModification{Id = 879653701, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataDurationOfOwls(int level)
        {
            return _modifications[896430917, level].ValueAsFloat;
        }

        private void SetDataDurationOfOwls(int level, float value)
        {
            _modifications[896430917, level] = new LevelObjectDataModification{Id = 896430917, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}