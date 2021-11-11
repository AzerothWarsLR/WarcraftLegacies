using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class WarStompHydra : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataTerrainDeformationAmplitude;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTerrainDeformationAmplitudeModified;
        private readonly Lazy<ObjectProperty<int>> _dataTerrainDeformationDurationMs;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTerrainDeformationDurationMsModified;
        public WarStompHydra(): base(1752332097)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
            _isDataTerrainDeformationDurationMsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationMsModified));
        }

        public WarStompHydra(int newId): base(1752332097, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
            _isDataTerrainDeformationDurationMsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationMsModified));
        }

        public WarStompHydra(string newRawcode): base(1752332097, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
            _isDataTerrainDeformationDurationMsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationMsModified));
        }

        public WarStompHydra(ObjectDatabase db): base(1752332097, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
            _isDataTerrainDeformationDurationMsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationMsModified));
        }

        public WarStompHydra(int newId, ObjectDatabase db): base(1752332097, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
            _isDataTerrainDeformationDurationMsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationMsModified));
        }

        public WarStompHydra(string newRawcode, ObjectDatabase db): base(1752332097, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationMs = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationMs, SetDataTerrainDeformationDurationMs));
            _isDataTerrainDeformationDurationMsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationMsModified));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageModified => _isDataDamageModified.Value;
        public ObjectProperty<float> DataTerrainDeformationAmplitude => _dataTerrainDeformationAmplitude.Value;
        public ReadOnlyObjectProperty<bool> IsDataTerrainDeformationAmplitudeModified => _isDataTerrainDeformationAmplitudeModified.Value;
        public ObjectProperty<int> DataTerrainDeformationDurationMs => _dataTerrainDeformationDurationMs.Value;
        public ReadOnlyObjectProperty<bool> IsDataTerrainDeformationDurationMsModified => _isDataTerrainDeformationDurationMsModified.Value;
        private float GetDataDamage(int level)
        {
            return _modifications[829649495, level].ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[829649495, level] = new LevelObjectDataModification{Id = 829649495, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageModified(int level)
        {
            return _modifications.ContainsKey(829649495, level);
        }

        private float GetDataTerrainDeformationAmplitude(int level)
        {
            return _modifications[846426711, level].ValueAsFloat;
        }

        private void SetDataTerrainDeformationAmplitude(int level, float value)
        {
            _modifications[846426711, level] = new LevelObjectDataModification{Id = 846426711, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataTerrainDeformationAmplitudeModified(int level)
        {
            return _modifications.ContainsKey(846426711, level);
        }

        private int GetDataTerrainDeformationDurationMs(int level)
        {
            return _modifications[863203927, level].ValueAsInt;
        }

        private void SetDataTerrainDeformationDurationMs(int level, int value)
        {
            _modifications[863203927, level] = new LevelObjectDataModification{Id = 863203927, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataTerrainDeformationDurationMsModified(int level)
        {
            return _modifications.ContainsKey(863203927, level);
        }
    }
}