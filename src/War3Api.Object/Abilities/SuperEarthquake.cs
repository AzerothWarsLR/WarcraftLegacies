using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SuperEarthquake : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataEffectDelay;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecondToBuildings;
        private readonly Lazy<ObjectProperty<float>> _dataUnitsSlowed;
        private readonly Lazy<ObjectProperty<float>> _dataFinalArea;
        public SuperEarthquake(): base(1902464595)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
        }

        public SuperEarthquake(int newId): base(1902464595, newId)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
        }

        public SuperEarthquake(string newRawcode): base(1902464595, newRawcode)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
        }

        public SuperEarthquake(ObjectDatabase db): base(1902464595, db)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
        }

        public SuperEarthquake(int newId, ObjectDatabase db): base(1902464595, newId, db)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
        }

        public SuperEarthquake(string newRawcode, ObjectDatabase db): base(1902464595, newRawcode, db)
        {
            _dataEffectDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataEffectDelay, SetDataEffectDelay));
            _dataDamagePerSecondToBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecondToBuildings, SetDataDamagePerSecondToBuildings));
            _dataUnitsSlowed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitsSlowed, SetDataUnitsSlowed));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
        }

        public ObjectProperty<float> DataEffectDelay => _dataEffectDelay.Value;
        public ObjectProperty<float> DataDamagePerSecondToBuildings => _dataDamagePerSecondToBuildings.Value;
        public ObjectProperty<float> DataUnitsSlowed => _dataUnitsSlowed.Value;
        public ObjectProperty<float> DataFinalArea => _dataFinalArea.Value;
        private float GetDataEffectDelay(int level)
        {
            return _modifications[829515087, level].ValueAsFloat;
        }

        private void SetDataEffectDelay(int level, float value)
        {
            _modifications[829515087, level] = new LevelObjectDataModification{Id = 829515087, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamagePerSecondToBuildings(int level)
        {
            return _modifications[846292303, level].ValueAsFloat;
        }

        private void SetDataDamagePerSecondToBuildings(int level, float value)
        {
            _modifications[846292303, level] = new LevelObjectDataModification{Id = 846292303, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataUnitsSlowed(int level)
        {
            return _modifications[863069519, level].ValueAsFloat;
        }

        private void SetDataUnitsSlowed(int level, float value)
        {
            _modifications[863069519, level] = new LevelObjectDataModification{Id = 863069519, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataFinalArea(int level)
        {
            return _modifications[879846735, level].ValueAsFloat;
        }

        private void SetDataFinalArea(int level, float value)
        {
            _modifications[879846735, level] = new LevelObjectDataModification{Id = 879846735, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}