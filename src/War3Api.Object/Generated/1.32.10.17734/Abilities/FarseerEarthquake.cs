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
    public sealed class FarseerEarthquake : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataEffectDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataEffectDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecondToBuildings;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerSecondToBuildingsModified;
        private readonly Lazy<ObjectProperty<float>> _dataUnitsSlowed;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitsSlowedModified;
        private readonly Lazy<ObjectProperty<float>> _dataFinalArea;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFinalAreaModified;
        public FarseerEarthquake(): base(1902464833)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _isDataDamagePerSecondToBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondToBuildingsModified));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _isDataUnitsSlowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSlowedModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public FarseerEarthquake(int newId): base(1902464833, newId)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _isDataDamagePerSecondToBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondToBuildingsModified));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _isDataUnitsSlowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSlowedModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public FarseerEarthquake(string newRawcode): base(1902464833, newRawcode)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _isDataDamagePerSecondToBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondToBuildingsModified));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _isDataUnitsSlowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSlowedModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public FarseerEarthquake(ObjectDatabaseBase db): base(1902464833, db)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _isDataDamagePerSecondToBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondToBuildingsModified));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _isDataUnitsSlowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSlowedModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public FarseerEarthquake(int newId, ObjectDatabaseBase db): base(1902464833, newId, db)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _isDataDamagePerSecondToBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondToBuildingsModified));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _isDataUnitsSlowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSlowedModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public FarseerEarthquake(string newRawcode, ObjectDatabaseBase db): base(1902464833, newRawcode, db)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _isDataEffectDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEffectDelayModified));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _isDataDamagePerSecondToBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondToBuildingsModified));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _isDataUnitsSlowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSlowedModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public ObjectProperty<float> DataEffectDelay => _dataEffectDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataEffectDelayModified => _isDataEffectDelayModified.Value;
        public ObjectProperty<float> DataDamagePerSecondToBuildings => _dataDamagePerSecondToBuildings.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerSecondToBuildingsModified => _isDataDamagePerSecondToBuildingsModified.Value;
        public ObjectProperty<float> DataUnitsSlowed => _dataUnitsSlowed.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitsSlowedModified => _isDataUnitsSlowedModified.Value;
        public ObjectProperty<float> DataFinalArea => _dataFinalArea.Value;
        public ReadOnlyObjectProperty<bool> IsDataFinalAreaModified => _isDataFinalAreaModified.Value;
        private float GetDataEffectDelay(int level)
        {
            return _modifications.GetModification(829515087, level).ValueAsFloat;
        }

        private void SetDataEffectDelay(int level, float value)
        {
            _modifications[829515087, level] = new LevelObjectDataModification{Id = 829515087, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataEffectDelayModified(int level)
        {
            return _modifications.ContainsKey(829515087, level);
        }

        private float GetDataDamagePerSecondToBuildings(int level)
        {
            return _modifications.GetModification(846292303, level).ValueAsFloat;
        }

        private void SetDataDamagePerSecondToBuildings(int level, float value)
        {
            _modifications[846292303, level] = new LevelObjectDataModification{Id = 846292303, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamagePerSecondToBuildingsModified(int level)
        {
            return _modifications.ContainsKey(846292303, level);
        }

        private float GetDataUnitsSlowed(int level)
        {
            return _modifications.GetModification(863069519, level).ValueAsFloat;
        }

        private void SetDataUnitsSlowed(int level, float value)
        {
            _modifications[863069519, level] = new LevelObjectDataModification{Id = 863069519, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataUnitsSlowedModified(int level)
        {
            return _modifications.ContainsKey(863069519, level);
        }

        private float GetDataFinalArea(int level)
        {
            return _modifications.GetModification(879846735, level).ValueAsFloat;
        }

        private void SetDataFinalArea(int level, float value)
        {
            _modifications[879846735, level] = new LevelObjectDataModification{Id = 879846735, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataFinalAreaModified(int level)
        {
            return _modifications.ContainsKey(879846735, level);
        }
    }
}