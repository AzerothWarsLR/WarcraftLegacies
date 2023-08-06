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
    public sealed class FarseerChainLightning : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerTarget;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerTargetModified;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfTargetsHit;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfTargetsHitModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReductionPerTarget;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageReductionPerTargetModified;
        public FarseerChainLightning(): base(1818447681)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
            _isDataDamageReductionPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionPerTargetModified));
        }

        public FarseerChainLightning(int newId): base(1818447681, newId)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
            _isDataDamageReductionPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionPerTargetModified));
        }

        public FarseerChainLightning(string newRawcode): base(1818447681, newRawcode)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
            _isDataDamageReductionPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionPerTargetModified));
        }

        public FarseerChainLightning(ObjectDatabaseBase db): base(1818447681, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
            _isDataDamageReductionPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionPerTargetModified));
        }

        public FarseerChainLightning(int newId, ObjectDatabaseBase db): base(1818447681, newId, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
            _isDataDamageReductionPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionPerTargetModified));
        }

        public FarseerChainLightning(string newRawcode, ObjectDatabaseBase db): base(1818447681, newRawcode, db)
        {
            _dataDamagePerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerTarget, SetDataDamagePerTarget));
            _isDataDamagePerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerTargetModified));
            _dataNumberOfTargetsHit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfTargetsHit, SetDataNumberOfTargetsHit));
            _isDataNumberOfTargetsHitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfTargetsHitModified));
            _dataDamageReductionPerTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReductionPerTarget, SetDataDamageReductionPerTarget));
            _isDataDamageReductionPerTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionPerTargetModified));
        }

        public ObjectProperty<float> DataDamagePerTarget => _dataDamagePerTarget.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerTargetModified => _isDataDamagePerTargetModified.Value;
        public ObjectProperty<int> DataNumberOfTargetsHit => _dataNumberOfTargetsHit.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfTargetsHitModified => _isDataNumberOfTargetsHitModified.Value;
        public ObjectProperty<float> DataDamageReductionPerTarget => _dataDamageReductionPerTarget.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageReductionPerTargetModified => _isDataDamageReductionPerTargetModified.Value;
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

        private float GetDataDamageReductionPerTarget(int level)
        {
            return _modifications.GetModification(862741327, level).ValueAsFloat;
        }

        private void SetDataDamageReductionPerTarget(int level, float value)
        {
            _modifications[862741327, level] = new LevelObjectDataModification{Id = 862741327, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageReductionPerTargetModified(int level)
        {
            return _modifications.ContainsKey(862741327, level);
        }
    }
}