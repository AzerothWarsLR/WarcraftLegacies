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
    public sealed class ChieftainShockWave : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataDistance;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDistanceModified;
        private readonly Lazy<ObjectProperty<float>> _dataFinalArea;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFinalAreaModified;
        public ChieftainShockWave(): base(1752387393)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public ChieftainShockWave(int newId): base(1752387393, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public ChieftainShockWave(string newRawcode): base(1752387393, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public ChieftainShockWave(ObjectDatabaseBase db): base(1752387393, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public ChieftainShockWave(int newId, ObjectDatabaseBase db): base(1752387393, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public ChieftainShockWave(string newRawcode, ObjectDatabaseBase db): base(1752387393, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _isDataDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
            _dataDistance = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistance, SetDataDistance));
            _isDataDistanceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDistanceModified));
            _dataFinalArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFinalArea, SetDataFinalArea));
            _isDataFinalAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFinalAreaModified));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageModified => _isDataDamageModified.Value;
        public ObjectProperty<float> DataMaximumDamage => _dataMaximumDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumDamageModified => _isDataMaximumDamageModified.Value;
        public ObjectProperty<float> DataDistance => _dataDistance.Value;
        public ReadOnlyObjectProperty<bool> IsDataDistanceModified => _isDataDistanceModified.Value;
        public ObjectProperty<float> DataFinalArea => _dataFinalArea.Value;
        public ReadOnlyObjectProperty<bool> IsDataFinalAreaModified => _isDataFinalAreaModified.Value;
        private float GetDataDamage(int level)
        {
            return _modifications.GetModification(828928847, level).ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[828928847, level] = new LevelObjectDataModification{Id = 828928847, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageModified(int level)
        {
            return _modifications.ContainsKey(828928847, level);
        }

        private float GetDataMaximumDamage(int level)
        {
            return _modifications.GetModification(845706063, level).ValueAsFloat;
        }

        private void SetDataMaximumDamage(int level, float value)
        {
            _modifications[845706063, level] = new LevelObjectDataModification{Id = 845706063, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMaximumDamageModified(int level)
        {
            return _modifications.ContainsKey(845706063, level);
        }

        private float GetDataDistance(int level)
        {
            return _modifications.GetModification(862483279, level).ValueAsFloat;
        }

        private void SetDataDistance(int level, float value)
        {
            _modifications[862483279, level] = new LevelObjectDataModification{Id = 862483279, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDistanceModified(int level)
        {
            return _modifications.ContainsKey(862483279, level);
        }

        private float GetDataFinalArea(int level)
        {
            return _modifications.GetModification(879260495, level).ValueAsFloat;
        }

        private void SetDataFinalArea(int level, float value)
        {
            _modifications[879260495, level] = new LevelObjectDataModification{Id = 879260495, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataFinalAreaModified(int level)
        {
            return _modifications.ContainsKey(879260495, level);
        }
    }
}