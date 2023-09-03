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
    public sealed class CarrionSwarmCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaxDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataDistance;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDistanceModified;
        private readonly Lazy<ObjectProperty<float>> _dataFinalArea;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFinalAreaModified;
        public CarrionSwarmCreep(): base(1633895233)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public CarrionSwarmCreep(int newId): base(1633895233, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public CarrionSwarmCreep(string newRawcode): base(1633895233, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public CarrionSwarmCreep(ObjectDatabaseBase db): base(1633895233, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public CarrionSwarmCreep(int newId, ObjectDatabaseBase db): base(1633895233, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public CarrionSwarmCreep(string newRawcode, ObjectDatabaseBase db): base(1633895233, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageModified => _isDataDamageModified.Value;
        public ObjectProperty<float> DataMaxDamage => _dataMaxDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxDamageModified => _isDataMaxDamageModified.Value;
        public ObjectProperty<float> DataDistance => _dataDistance.Value;
        public ReadOnlyObjectProperty<bool> IsDataDistanceModified => _isDataDistanceModified.Value;
        public ObjectProperty<float> DataFinalArea => _dataFinalArea.Value;
        public ReadOnlyObjectProperty<bool> IsDataFinalAreaModified => _isDataFinalAreaModified.Value;
        private float GetDataDamage(int level)
        {
            return _modifications.GetModification(829645653, level).ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[829645653, level] = new LevelObjectDataModification{Id = 829645653, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageModified(int level)
        {
            return _modifications.ContainsKey(829645653, level);
        }

        private float GetDataMaxDamage(int level)
        {
            return _modifications.GetModification(846422869, level).ValueAsFloat;
        }

        private void SetDataMaxDamage(int level, float value)
        {
            _modifications[846422869, level] = new LevelObjectDataModification{Id = 846422869, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMaxDamageModified(int level)
        {
            return _modifications.ContainsKey(846422869, level);
        }

        private float GetDataDistance(int level)
        {
            return _modifications.GetModification(863200085, level).ValueAsFloat;
        }

        private void SetDataDistance(int level, float value)
        {
            _modifications[863200085, level] = new LevelObjectDataModification{Id = 863200085, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDistanceModified(int level)
        {
            return _modifications.ContainsKey(863200085, level);
        }

        private float GetDataFinalArea(int level)
        {
            return _modifications.GetModification(879977301, level).ValueAsFloat;
        }

        private void SetDataFinalArea(int level, float value)
        {
            _modifications[879977301, level] = new LevelObjectDataModification{Id = 879977301, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataFinalAreaModified(int level)
        {
            return _modifications.ContainsKey(879977301, level);
        }
    }
}