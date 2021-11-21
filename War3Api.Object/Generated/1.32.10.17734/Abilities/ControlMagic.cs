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
    public sealed class ControlMagic : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumCreepLevel;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumCreepLevelModified;
        private readonly Lazy<ObjectProperty<float>> _dataManaPerSummonedHitpoint;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaPerSummonedHitpointModified;
        private readonly Lazy<ObjectProperty<float>> _dataChargeForCurrentLife;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChargeForCurrentLifeModified;
        public ControlMagic(): base(1735222081)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _isDataManaPerSummonedHitpointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerSummonedHitpointModified));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
            _isDataChargeForCurrentLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeForCurrentLifeModified));
        }

        public ControlMagic(int newId): base(1735222081, newId)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _isDataManaPerSummonedHitpointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerSummonedHitpointModified));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
            _isDataChargeForCurrentLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeForCurrentLifeModified));
        }

        public ControlMagic(string newRawcode): base(1735222081, newRawcode)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _isDataManaPerSummonedHitpointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerSummonedHitpointModified));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
            _isDataChargeForCurrentLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeForCurrentLifeModified));
        }

        public ControlMagic(ObjectDatabaseBase db): base(1735222081, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _isDataManaPerSummonedHitpointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerSummonedHitpointModified));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
            _isDataChargeForCurrentLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeForCurrentLifeModified));
        }

        public ControlMagic(int newId, ObjectDatabaseBase db): base(1735222081, newId, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _isDataManaPerSummonedHitpointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerSummonedHitpointModified));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
            _isDataChargeForCurrentLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeForCurrentLifeModified));
        }

        public ControlMagic(string newRawcode, ObjectDatabaseBase db): base(1735222081, newRawcode, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataManaPerSummonedHitpoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerSummonedHitpoint, SetDataManaPerSummonedHitpoint));
            _isDataManaPerSummonedHitpointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerSummonedHitpointModified));
            _dataChargeForCurrentLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChargeForCurrentLife, SetDataChargeForCurrentLife));
            _isDataChargeForCurrentLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeForCurrentLifeModified));
        }

        public ObjectProperty<int> DataMaximumCreepLevel => _dataMaximumCreepLevel.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumCreepLevelModified => _isDataMaximumCreepLevelModified.Value;
        public ObjectProperty<float> DataManaPerSummonedHitpoint => _dataManaPerSummonedHitpoint.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaPerSummonedHitpointModified => _isDataManaPerSummonedHitpointModified.Value;
        public ObjectProperty<float> DataChargeForCurrentLife => _dataChargeForCurrentLife.Value;
        public ReadOnlyObjectProperty<bool> IsDataChargeForCurrentLifeModified => _isDataChargeForCurrentLifeModified.Value;
        private int GetDataMaximumCreepLevel(int level)
        {
            return _modifications.GetModification(828924750, level).ValueAsInt;
        }

        private void SetDataMaximumCreepLevel(int level, int value)
        {
            _modifications[828924750, level] = new LevelObjectDataModification{Id = 828924750, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaximumCreepLevelModified(int level)
        {
            return _modifications.ContainsKey(828924750, level);
        }

        private float GetDataManaPerSummonedHitpoint(int level)
        {
            return _modifications.GetModification(845638979, level).ValueAsFloat;
        }

        private void SetDataManaPerSummonedHitpoint(int level, float value)
        {
            _modifications[845638979, level] = new LevelObjectDataModification{Id = 845638979, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataManaPerSummonedHitpointModified(int level)
        {
            return _modifications.ContainsKey(845638979, level);
        }

        private float GetDataChargeForCurrentLife(int level)
        {
            return _modifications.GetModification(862416195, level).ValueAsFloat;
        }

        private void SetDataChargeForCurrentLife(int level, float value)
        {
            _modifications[862416195, level] = new LevelObjectDataModification{Id = 862416195, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataChargeForCurrentLifeModified(int level)
        {
            return _modifications.ContainsKey(862416195, level);
        }
    }
}