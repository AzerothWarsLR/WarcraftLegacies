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
    public sealed class SuperDeathAndDecay : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMaxLifeDrainedPerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxLifeDrainedPerSecondModified;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBuildingReductionModified;
        public SuperDeathAndDecay(): base(1684295251)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _isDataMaxLifeDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeDrainedPerSecondModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public SuperDeathAndDecay(int newId): base(1684295251, newId)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _isDataMaxLifeDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeDrainedPerSecondModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public SuperDeathAndDecay(string newRawcode): base(1684295251, newRawcode)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _isDataMaxLifeDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeDrainedPerSecondModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public SuperDeathAndDecay(ObjectDatabaseBase db): base(1684295251, db)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _isDataMaxLifeDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeDrainedPerSecondModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public SuperDeathAndDecay(int newId, ObjectDatabaseBase db): base(1684295251, newId, db)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _isDataMaxLifeDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeDrainedPerSecondModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public SuperDeathAndDecay(string newRawcode, ObjectDatabaseBase db): base(1684295251, newRawcode, db)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _isDataMaxLifeDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeDrainedPerSecondModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public ObjectProperty<float> DataMaxLifeDrainedPerSecond => _dataMaxLifeDrainedPerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxLifeDrainedPerSecondModified => _isDataMaxLifeDrainedPerSecondModified.Value;
        public ObjectProperty<float> DataBuildingReduction => _dataBuildingReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataBuildingReductionModified => _isDataBuildingReductionModified.Value;
        private float GetDataMaxLifeDrainedPerSecond(int level)
        {
            return _modifications.GetModification(828662869, level).ValueAsFloat;
        }

        private void SetDataMaxLifeDrainedPerSecond(int level, float value)
        {
            _modifications[828662869, level] = new LevelObjectDataModification{Id = 828662869, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaxLifeDrainedPerSecondModified(int level)
        {
            return _modifications.ContainsKey(828662869, level);
        }

        private float GetDataBuildingReduction(int level)
        {
            return _modifications.GetModification(845440085, level).ValueAsFloat;
        }

        private void SetDataBuildingReduction(int level, float value)
        {
            _modifications[845440085, level] = new LevelObjectDataModification{Id = 845440085, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataBuildingReductionModified(int level)
        {
            return _modifications.ContainsKey(845440085, level);
        }
    }
}