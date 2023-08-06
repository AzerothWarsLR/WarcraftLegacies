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
    public sealed class Sentinel : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataInFlightSightRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInFlightSightRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataHoveringSightRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHoveringSightRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataHoveringHeight;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHoveringHeightModified;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfOwls;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfOwlsModified;
        private readonly Lazy<ObjectProperty<float>> _dataDurationOfOwls;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDurationOfOwlsModified;
        public Sentinel(): base(1853056321)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _isDataInFlightSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInFlightSightRadiusModified));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _isDataHoveringSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringSightRadiusModified));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _isDataHoveringHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringHeightModified));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _isDataNumberOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfOwlsModified));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
            _isDataDurationOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfOwlsModified));
        }

        public Sentinel(int newId): base(1853056321, newId)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _isDataInFlightSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInFlightSightRadiusModified));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _isDataHoveringSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringSightRadiusModified));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _isDataHoveringHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringHeightModified));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _isDataNumberOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfOwlsModified));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
            _isDataDurationOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfOwlsModified));
        }

        public Sentinel(string newRawcode): base(1853056321, newRawcode)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _isDataInFlightSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInFlightSightRadiusModified));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _isDataHoveringSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringSightRadiusModified));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _isDataHoveringHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringHeightModified));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _isDataNumberOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfOwlsModified));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
            _isDataDurationOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfOwlsModified));
        }

        public Sentinel(ObjectDatabaseBase db): base(1853056321, db)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _isDataInFlightSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInFlightSightRadiusModified));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _isDataHoveringSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringSightRadiusModified));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _isDataHoveringHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringHeightModified));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _isDataNumberOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfOwlsModified));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
            _isDataDurationOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfOwlsModified));
        }

        public Sentinel(int newId, ObjectDatabaseBase db): base(1853056321, newId, db)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _isDataInFlightSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInFlightSightRadiusModified));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _isDataHoveringSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringSightRadiusModified));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _isDataHoveringHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringHeightModified));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _isDataNumberOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfOwlsModified));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
            _isDataDurationOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfOwlsModified));
        }

        public Sentinel(string newRawcode, ObjectDatabaseBase db): base(1853056321, newRawcode, db)
        {
            _dataInFlightSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInFlightSightRadius, SetDataInFlightSightRadius));
            _isDataInFlightSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInFlightSightRadiusModified));
            _dataHoveringSightRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringSightRadius, SetDataHoveringSightRadius));
            _isDataHoveringSightRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringSightRadiusModified));
            _dataHoveringHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHoveringHeight, SetDataHoveringHeight));
            _isDataHoveringHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHoveringHeightModified));
            _dataNumberOfOwls = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfOwls, SetDataNumberOfOwls));
            _isDataNumberOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfOwlsModified));
            _dataDurationOfOwls = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfOwls, SetDataDurationOfOwls));
            _isDataDurationOfOwlsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfOwlsModified));
        }

        public ObjectProperty<float> DataInFlightSightRadius => _dataInFlightSightRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataInFlightSightRadiusModified => _isDataInFlightSightRadiusModified.Value;
        public ObjectProperty<float> DataHoveringSightRadius => _dataHoveringSightRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataHoveringSightRadiusModified => _isDataHoveringSightRadiusModified.Value;
        public ObjectProperty<float> DataHoveringHeight => _dataHoveringHeight.Value;
        public ReadOnlyObjectProperty<bool> IsDataHoveringHeightModified => _isDataHoveringHeightModified.Value;
        public ObjectProperty<int> DataNumberOfOwls => _dataNumberOfOwls.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfOwlsModified => _isDataNumberOfOwlsModified.Value;
        public ObjectProperty<float> DataDurationOfOwls => _dataDurationOfOwls.Value;
        public ReadOnlyObjectProperty<bool> IsDataDurationOfOwlsModified => _isDataDurationOfOwlsModified.Value;
        private float GetDataInFlightSightRadius(int level)
        {
            return _modifications.GetModification(829322053, level).ValueAsFloat;
        }

        private void SetDataInFlightSightRadius(int level, float value)
        {
            _modifications[829322053, level] = new LevelObjectDataModification{Id = 829322053, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataInFlightSightRadiusModified(int level)
        {
            return _modifications.ContainsKey(829322053, level);
        }

        private float GetDataHoveringSightRadius(int level)
        {
            return _modifications.GetModification(846099269, level).ValueAsFloat;
        }

        private void SetDataHoveringSightRadius(int level, float value)
        {
            _modifications[846099269, level] = new LevelObjectDataModification{Id = 846099269, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataHoveringSightRadiusModified(int level)
        {
            return _modifications.ContainsKey(846099269, level);
        }

        private float GetDataHoveringHeight(int level)
        {
            return _modifications.GetModification(862876485, level).ValueAsFloat;
        }

        private void SetDataHoveringHeight(int level, float value)
        {
            _modifications[862876485, level] = new LevelObjectDataModification{Id = 862876485, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataHoveringHeightModified(int level)
        {
            return _modifications.ContainsKey(862876485, level);
        }

        private int GetDataNumberOfOwls(int level)
        {
            return _modifications.GetModification(879653701, level).ValueAsInt;
        }

        private void SetDataNumberOfOwls(int level, int value)
        {
            _modifications[879653701, level] = new LevelObjectDataModification{Id = 879653701, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataNumberOfOwlsModified(int level)
        {
            return _modifications.ContainsKey(879653701, level);
        }

        private float GetDataDurationOfOwls(int level)
        {
            return _modifications.GetModification(896430917, level).ValueAsFloat;
        }

        private void SetDataDurationOfOwls(int level, float value)
        {
            _modifications[896430917, level] = new LevelObjectDataModification{Id = 896430917, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataDurationOfOwlsModified(int level)
        {
            return _modifications.ContainsKey(896430917, level);
        }
    }
}