using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SuperDeathAndDecay : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMaxLifeDrainedPerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingReduction;
        public SuperDeathAndDecay(): base(1684295251)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
        }

        public SuperDeathAndDecay(int newId): base(1684295251, newId)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
        }

        public SuperDeathAndDecay(string newRawcode): base(1684295251, newRawcode)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
        }

        public SuperDeathAndDecay(ObjectDatabase db): base(1684295251, db)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
        }

        public SuperDeathAndDecay(int newId, ObjectDatabase db): base(1684295251, newId, db)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
        }

        public SuperDeathAndDecay(string newRawcode, ObjectDatabase db): base(1684295251, newRawcode, db)
        {
            _dataMaxLifeDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxLifeDrainedPerSecond, SetDataMaxLifeDrainedPerSecond));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
        }

        public ObjectProperty<float> DataMaxLifeDrainedPerSecond => _dataMaxLifeDrainedPerSecond.Value;
        public ObjectProperty<float> DataBuildingReduction => _dataBuildingReduction.Value;
        private float GetDataMaxLifeDrainedPerSecond(int level)
        {
            return _modifications[828662869, level].ValueAsFloat;
        }

        private void SetDataMaxLifeDrainedPerSecond(int level, float value)
        {
            _modifications[828662869, level] = new LevelObjectDataModification{Id = 828662869, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataBuildingReduction(int level)
        {
            return _modifications[845440085, level].ValueAsFloat;
        }

        private void SetDataBuildingReduction(int level, float value)
        {
            _modifications[845440085, level] = new LevelObjectDataModification{Id = 845440085, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}