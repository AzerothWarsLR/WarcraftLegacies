using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ChainLightningCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerTarget;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfTargetsHit;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReductionPerTarget;
        public ChainLightningCreep(): base(1818444609)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
        }

        public ChainLightningCreep(int newId): base(1818444609, newId)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
        }

        public ChainLightningCreep(string newRawcode): base(1818444609, newRawcode)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
        }

        public ChainLightningCreep(ObjectDatabase db): base(1818444609, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
        }

        public ChainLightningCreep(int newId, ObjectDatabase db): base(1818444609, newId, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
        }

        public ChainLightningCreep(string newRawcode, ObjectDatabase db): base(1818444609, newRawcode, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
        }

        public ObjectProperty<float> DataDamagePerTarget => _dataDamagePerTarget.Value;
        public ObjectProperty<int> DataNumberOfTargetsHit => _dataNumberOfTargetsHit.Value;
        public ObjectProperty<float> DataDamageReductionPerTarget => _dataDamageReductionPerTarget.Value;
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

        private float GetDataDamageReductionPerTarget(int level)
        {
            return _modifications[862741327, level].ValueAsFloat;
        }

        private void SetDataDamageReductionPerTarget(int level, float value)
        {
            _modifications[862741327, level] = new LevelObjectDataModification{Id = 862741327, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}