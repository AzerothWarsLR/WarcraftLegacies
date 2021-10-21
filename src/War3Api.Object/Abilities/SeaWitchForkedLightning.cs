using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SeaWitchForkedLightning : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDistance;
        private readonly Lazy<ObjectProperty<float>> _dataFinalArea;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerTarget;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfTargetsHit;
        public SeaWitchForkedLightning(): base(1818644033)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
        }

        public SeaWitchForkedLightning(int newId): base(1818644033, newId)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
        }

        public SeaWitchForkedLightning(string newRawcode): base(1818644033, newRawcode)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
        }

        public SeaWitchForkedLightning(ObjectDatabase db): base(1818644033, db)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
        }

        public SeaWitchForkedLightning(int newId, ObjectDatabase db): base(1818644033, newId, db)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
        }

        public SeaWitchForkedLightning(string newRawcode, ObjectDatabase db): base(1818644033, newRawcode, db)
        {
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
        }

        public ObjectProperty<float> DataDistance => _dataDistance.Value;
        public ObjectProperty<float> DataFinalArea => _dataFinalArea.Value;
        public ObjectProperty<float> DataDamagePerTarget => _dataDamagePerTarget.Value;
        public ObjectProperty<int> DataNumberOfTargetsHit => _dataNumberOfTargetsHit.Value;
        private float GetDataDistance(int level)
        {
            return _modifications[863200085, level].ValueAsFloat;
        }

        private void SetDataDistance(int level, float value)
        {
            _modifications[863200085, level] = new LevelObjectDataModification{Id = 863200085, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataFinalArea(int level)
        {
            return _modifications[879977301, level].ValueAsFloat;
        }

        private void SetDataFinalArea(int level, float value)
        {
            _modifications[879977301, level] = new LevelObjectDataModification{Id = 879977301, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataDamagePerTarget(int level)
        {
            return _modifications[829186895, level].ValueAsFloat;
        }

        private void SetDataDamagePerTarget(int level, float value)
        {
            _modifications[829186895, level] = new LevelObjectDataModification{Id = 829186895, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataNumberOfTargetsHit(int level)
        {
            return _modifications[845964111, level].ValueAsInt;
        }

        private void SetDataNumberOfTargetsHit(int level, int value)
        {
            _modifications[845964111, level] = new LevelObjectDataModification{Id = 845964111, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }
    }
}