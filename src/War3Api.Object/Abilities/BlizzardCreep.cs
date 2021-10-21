using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BlizzardCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfWaves;
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfShards;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingReduction;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumDamagePerWave;
        public BlizzardCreep(): base(2053260097)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
        }

        public BlizzardCreep(int newId): base(2053260097, newId)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
        }

        public BlizzardCreep(string newRawcode): base(2053260097, newRawcode)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
        }

        public BlizzardCreep(ObjectDatabase db): base(2053260097, db)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
        }

        public BlizzardCreep(int newId, ObjectDatabase db): base(2053260097, newId, db)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
        }

        public BlizzardCreep(string newRawcode, ObjectDatabase db): base(2053260097, newRawcode, db)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
        }

        public ObjectProperty<int> DataNumberOfWaves => _dataNumberOfWaves.Value;
        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ObjectProperty<int> DataNumberOfShards => _dataNumberOfShards.Value;
        public ObjectProperty<float> DataBuildingReduction => _dataBuildingReduction.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ObjectProperty<float> DataMaximumDamagePerWave => _dataMaximumDamagePerWave.Value;
        private int GetDataNumberOfWaves(int level)
        {
            return _modifications[830104136, level].ValueAsInt;
        }

        private void SetDataNumberOfWaves(int level, int value)
        {
            _modifications[830104136, level] = new LevelObjectDataModification{Id = 830104136, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamage(int level)
        {
            return _modifications[846881352, level].ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[846881352, level] = new LevelObjectDataModification{Id = 846881352, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataNumberOfShards(int level)
        {
            return _modifications[863658568, level].ValueAsInt;
        }

        private void SetDataNumberOfShards(int level, int value)
        {
            _modifications[863658568, level] = new LevelObjectDataModification{Id = 863658568, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataBuildingReduction(int level)
        {
            return _modifications[880435784, level].ValueAsFloat;
        }

        private void SetDataBuildingReduction(int level, float value)
        {
            _modifications[880435784, level] = new LevelObjectDataModification{Id = 880435784, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications[897213000, level].ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[897213000, level] = new LevelObjectDataModification{Id = 897213000, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataMaximumDamagePerWave(int level)
        {
            return _modifications[913990216, level].ValueAsFloat;
        }

        private void SetDataMaximumDamagePerWave(int level, float value)
        {
            _modifications[913990216, level] = new LevelObjectDataModification{Id = 913990216, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }
    }
}