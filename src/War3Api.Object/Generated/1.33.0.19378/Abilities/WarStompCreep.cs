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
    public sealed class WarStompCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataTerrainDeformationAmplitude;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTerrainDeformationAmplitudeModified;
        private readonly Lazy<ObjectProperty<int>> _dataTerrainDeformationDurationms;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTerrainDeformationDurationmsModified;
        public WarStompCreep(): base(1936881473)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationms = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationms, SetDataTerrainDeformationDurationms));
            _isDataTerrainDeformationDurationmsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationmsModified));
        }

        public WarStompCreep(int newId): base(1936881473, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationms = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationms, SetDataTerrainDeformationDurationms));
            _isDataTerrainDeformationDurationmsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationmsModified));
        }

        public WarStompCreep(string newRawcode): base(1936881473, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationms = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationms, SetDataTerrainDeformationDurationms));
            _isDataTerrainDeformationDurationmsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationmsModified));
        }

        public WarStompCreep(ObjectDatabaseBase db): base(1936881473, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationms = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationms, SetDataTerrainDeformationDurationms));
            _isDataTerrainDeformationDurationmsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationmsModified));
        }

        public WarStompCreep(int newId, ObjectDatabaseBase db): base(1936881473, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationms = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationms, SetDataTerrainDeformationDurationms));
            _isDataTerrainDeformationDurationmsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationmsModified));
        }

        public WarStompCreep(string newRawcode, ObjectDatabaseBase db): base(1936881473, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataTerrainDeformationAmplitude = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTerrainDeformationAmplitude, SetDataTerrainDeformationAmplitude));
            _isDataTerrainDeformationAmplitudeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationAmplitudeModified));
            _dataTerrainDeformationDurationms = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTerrainDeformationDurationms, SetDataTerrainDeformationDurationms));
            _isDataTerrainDeformationDurationmsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTerrainDeformationDurationmsModified));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageModified => _isDataDamageModified.Value;
        public ObjectProperty<float> DataTerrainDeformationAmplitude => _dataTerrainDeformationAmplitude.Value;
        public ReadOnlyObjectProperty<bool> IsDataTerrainDeformationAmplitudeModified => _isDataTerrainDeformationAmplitudeModified.Value;
        public ObjectProperty<int> DataTerrainDeformationDurationms => _dataTerrainDeformationDurationms.Value;
        public ReadOnlyObjectProperty<bool> IsDataTerrainDeformationDurationmsModified => _isDataTerrainDeformationDurationmsModified.Value;
        private float GetDataDamage(int level)
        {
            return _modifications.GetModification(829649495, level).ValueAsFloat;
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
            return _modifications.GetModification(846426711, level).ValueAsFloat;
        }

        private void SetDataTerrainDeformationAmplitude(int level, float value)
        {
            _modifications[846426711, level] = new LevelObjectDataModification{Id = 846426711, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataTerrainDeformationAmplitudeModified(int level)
        {
            return _modifications.ContainsKey(846426711, level);
        }

        private int GetDataTerrainDeformationDurationms(int level)
        {
            return _modifications.GetModification(863203927, level).ValueAsInt;
        }

        private void SetDataTerrainDeformationDurationms(int level, int value)
        {
            _modifications[863203927, level] = new LevelObjectDataModification{Id = 863203927, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataTerrainDeformationDurationmsModified(int level)
        {
            return _modifications.ContainsKey(863203927, level);
        }
    }
}