using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class WarStompCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ObjectProperty<float>> _dataTerrainDeformationAmplitude;
        private readonly Lazy<ObjectProperty<int>> _dataTerrainDeformationDurationMs;
        public WarStompCreep(): base(1936881473)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
        }

        public WarStompCreep(int newId): base(1936881473, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
        }

        public WarStompCreep(string newRawcode): base(1936881473, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
        }

        public WarStompCreep(ObjectDatabase db): base(1936881473, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
        }

        public WarStompCreep(int newId, ObjectDatabase db): base(1936881473, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
        }

        public WarStompCreep(string newRawcode, ObjectDatabase db): base(1936881473, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ObjectProperty<float> DataTerrainDeformationAmplitude => _dataTerrainDeformationAmplitude.Value;
        public ObjectProperty<int> DataTerrainDeformationDurationMs => _dataTerrainDeformationDurationMs.Value;
        private float GetDataDamage(int level)
        {
            return _modifications[829649495, level].ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[829649495, level] = new LevelObjectDataModification{Id = 829649495, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataTerrainDeformationAmplitude(int level)
        {
            return _modifications[846426711, level].ValueAsFloat;
        }

        private void SetDataTerrainDeformationAmplitude(int level, float value)
        {
            _modifications[846426711, level] = new LevelObjectDataModification{Id = 846426711, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataTerrainDeformationDurationMs(int level)
        {
            return _modifications[863203927, level].ValueAsInt;
        }

        private void SetDataTerrainDeformationDurationMs(int level, int value)
        {
            _modifications[863203927, level] = new LevelObjectDataModification{Id = 863203927, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }
    }
}