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
    public sealed class SeaWitchForkedLightning : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDistance;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDistanceModified;
        private readonly Lazy<ObjectProperty<float>> _dataFinalArea;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFinalAreaModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerTarget;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerTargetModified;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfTargetsHit;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfTargetsHitModified;
        public SeaWitchForkedLightning(): base(1818644033)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
        }

        public SeaWitchForkedLightning(int newId): base(1818644033, newId)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
        }

        public SeaWitchForkedLightning(string newRawcode): base(1818644033, newRawcode)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
        }

        public SeaWitchForkedLightning(ObjectDatabaseBase db): base(1818644033, db)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
        }

        public SeaWitchForkedLightning(int newId, ObjectDatabaseBase db): base(1818644033, newId, db)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
        }

        public SeaWitchForkedLightning(string newRawcode, ObjectDatabaseBase db): base(1818644033, newRawcode, db)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
        }

        public ObjectProperty<float> DataDistance => _dataDistance.Value;
        public ReadOnlyObjectProperty<bool> IsDataDistanceModified => _isDataDistanceModified.Value;
        public ObjectProperty<float> DataFinalArea => _dataFinalArea.Value;
        public ReadOnlyObjectProperty<bool> IsDataFinalAreaModified => _isDataFinalAreaModified.Value;
        public ObjectProperty<float> DataDamagePerTarget => _dataDamagePerTarget.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerTargetModified => _isDataDamagePerTargetModified.Value;
        public ObjectProperty<int> DataNumberOfTargetsHit => _dataNumberOfTargetsHit.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfTargetsHitModified => _isDataNumberOfTargetsHitModified.Value;
        private float GetDataDistance(int level)
        {
            return _modifications.GetModification(863200085, level).ValueAsFloat;
        }

        private void SetDataDistance(int level, float value)
        {
            _modifications[863200085, level] = new LevelObjectDataModification{Id = 863200085, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDistanceModified(int level)
        {
            return _modifications.ContainsKey(863200085, level);
        }

        private float GetDataFinalArea(int level)
        {
            return _modifications.GetModification(879977301, level).ValueAsFloat;
        }

        private void SetDataFinalArea(int level, float value)
        {
            _modifications[879977301, level] = new LevelObjectDataModification{Id = 879977301, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataFinalAreaModified(int level)
        {
            return _modifications.ContainsKey(879977301, level);
        }

        private float GetDataDamagePerTarget(int level)
        {
            return _modifications.GetModification(829186895, level).ValueAsFloat;
        }

        private void SetDataDamagePerTarget(int level, float value)
        {
            _modifications[829186895, level] = new LevelObjectDataModification{Id = 829186895, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamagePerTargetModified(int level)
        {
            return _modifications.ContainsKey(829186895, level);
        }

        private int GetDataNumberOfTargetsHit(int level)
        {
            return _modifications.GetModification(845964111, level).ValueAsInt;
        }

        private void SetDataNumberOfTargetsHit(int level, int value)
        {
            _modifications[845964111, level] = new LevelObjectDataModification{Id = 845964111, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataNumberOfTargetsHitModified(int level)
        {
            return _modifications.ContainsKey(845964111, level);
        }
    }
}