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
    public sealed class BlizzardCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfWaves;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfWavesModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageModified;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfShards;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfShardsModified;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBuildingReductionModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerSecondModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumDamagePerWave;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumDamagePerWaveModified;
        public BlizzardCreep(): base(2053260097)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _isDataNumberOfWavesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfWavesModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _isDataNumberOfShardsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfShardsModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
            _isDataMaximumDamagePerWaveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamagePerWaveModified));
        }

        public BlizzardCreep(int newId): base(2053260097, newId)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _isDataNumberOfWavesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfWavesModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _isDataNumberOfShardsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfShardsModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
            _isDataMaximumDamagePerWaveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamagePerWaveModified));
        }

        public BlizzardCreep(string newRawcode): base(2053260097, newRawcode)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _isDataNumberOfWavesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfWavesModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _isDataNumberOfShardsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfShardsModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
            _isDataMaximumDamagePerWaveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamagePerWaveModified));
        }

        public BlizzardCreep(ObjectDatabaseBase db): base(2053260097, db)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _isDataNumberOfWavesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfWavesModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _isDataNumberOfShardsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfShardsModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
            _isDataMaximumDamagePerWaveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamagePerWaveModified));
        }

        public BlizzardCreep(int newId, ObjectDatabaseBase db): base(2053260097, newId, db)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _isDataNumberOfWavesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfWavesModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _isDataNumberOfShardsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfShardsModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
            _isDataMaximumDamagePerWaveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamagePerWaveModified));
        }

        public BlizzardCreep(string newRawcode, ObjectDatabaseBase db): base(2053260097, newRawcode, db)
        {
            _dataNumberOfWaves = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfWaves, SetDataNumberOfWaves));
            _isDataNumberOfWavesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfWavesModified));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataNumberOfShards = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfShards, SetDataNumberOfShards));
            _isDataNumberOfShardsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfShardsModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumDamagePerWave = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamagePerWave, SetDataMaximumDamagePerWave));
            _isDataMaximumDamagePerWaveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamagePerWaveModified));
        }

        public ObjectProperty<int> DataNumberOfWaves => _dataNumberOfWaves.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfWavesModified => _isDataNumberOfWavesModified.Value;
        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageModified => _isDataDamageModified.Value;
        public ObjectProperty<int> DataNumberOfShards => _dataNumberOfShards.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfShardsModified => _isDataNumberOfShardsModified.Value;
        public ObjectProperty<float> DataBuildingReduction => _dataBuildingReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataBuildingReductionModified => _isDataBuildingReductionModified.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerSecondModified => _isDataDamagePerSecondModified.Value;
        public ObjectProperty<float> DataMaximumDamagePerWave => _dataMaximumDamagePerWave.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumDamagePerWaveModified => _isDataMaximumDamagePerWaveModified.Value;
        private int GetDataNumberOfWaves(int level)
        {
            return _modifications.GetModification(830104136, level).ValueAsInt;
        }

        private void SetDataNumberOfWaves(int level, int value)
        {
            _modifications[830104136, level] = new LevelObjectDataModification{Id = 830104136, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfWavesModified(int level)
        {
            return _modifications.ContainsKey(830104136, level);
        }

        private float GetDataDamage(int level)
        {
            return _modifications.GetModification(846881352, level).ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[846881352, level] = new LevelObjectDataModification{Id = 846881352, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageModified(int level)
        {
            return _modifications.ContainsKey(846881352, level);
        }

        private int GetDataNumberOfShards(int level)
        {
            return _modifications.GetModification(863658568, level).ValueAsInt;
        }

        private void SetDataNumberOfShards(int level, int value)
        {
            _modifications[863658568, level] = new LevelObjectDataModification{Id = 863658568, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataNumberOfShardsModified(int level)
        {
            return _modifications.ContainsKey(863658568, level);
        }

        private float GetDataBuildingReduction(int level)
        {
            return _modifications.GetModification(880435784, level).ValueAsFloat;
        }

        private void SetDataBuildingReduction(int level, float value)
        {
            _modifications[880435784, level] = new LevelObjectDataModification{Id = 880435784, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataBuildingReductionModified(int level)
        {
            return _modifications.ContainsKey(880435784, level);
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications.GetModification(897213000, level).ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[897213000, level] = new LevelObjectDataModification{Id = 897213000, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataDamagePerSecondModified(int level)
        {
            return _modifications.ContainsKey(897213000, level);
        }

        private float GetDataMaximumDamagePerWave(int level)
        {
            return _modifications.GetModification(913990216, level).ValueAsFloat;
        }

        private void SetDataMaximumDamagePerWave(int level, float value)
        {
            _modifications[913990216, level] = new LevelObjectDataModification{Id = 913990216, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataMaximumDamagePerWaveModified(int level)
        {
            return _modifications.ContainsKey(913990216, level);
        }
    }
}