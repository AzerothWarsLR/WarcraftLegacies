using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ControlMagic : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumCreepLevel;
        private readonly Lazy<ObjectProperty<float>> _dataManaPerSummonedHitpoint;
        private readonly Lazy<ObjectProperty<float>> _dataChargeForCurrentLife;
        public ControlMagic(): base(1735222081)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
        }

        public ControlMagic(int newId): base(1735222081, newId)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
        }

        public ControlMagic(string newRawcode): base(1735222081, newRawcode)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
        }

        public ControlMagic(ObjectDatabase db): base(1735222081, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
        }

        public ControlMagic(int newId, ObjectDatabase db): base(1735222081, newId, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
        }

        public ControlMagic(string newRawcode, ObjectDatabase db): base(1735222081, newRawcode, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
        }

        public ObjectProperty<int> DataMaximumCreepLevel => _dataMaximumCreepLevel.Value;
        public ObjectProperty<float> DataManaPerSummonedHitpoint => _dataManaPerSummonedHitpoint.Value;
        public ObjectProperty<float> DataChargeForCurrentLife => _dataChargeForCurrentLife.Value;
        private int GetDataMaximumCreepLevel(int level)
        {
            return _modifications[828924750, level].ValueAsInt;
        }

        private void SetDataMaximumCreepLevel(int level, int value)
        {
            _modifications[828924750, level] = new LevelObjectDataModification{Id = 828924750, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataManaPerSummonedHitpoint(int level)
        {
            return _modifications[845638979, level].ValueAsFloat;
        }

        private void SetDataManaPerSummonedHitpoint(int level, float value)
        {
            _modifications[845638979, level] = new LevelObjectDataModification{Id = 845638979, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataChargeForCurrentLife(int level)
        {
            return _modifications[862416195, level].ValueAsFloat;
        }

        private void SetDataChargeForCurrentLife(int level, float value)
        {
            _modifications[862416195, level] = new LevelObjectDataModification{Id = 862416195, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}