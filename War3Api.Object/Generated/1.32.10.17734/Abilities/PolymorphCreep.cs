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
    public sealed class PolymorphCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumCreepLevel;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumCreepLevelModified;
        private readonly Lazy<ObjectProperty<string>> _dataMorphUnitsGroundRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMorphUnitsGroundModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataMorphUnitsGround;
        private readonly Lazy<ObjectProperty<string>> _dataMorphUnitsAirRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMorphUnitsAirModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataMorphUnitsAir;
        private readonly Lazy<ObjectProperty<string>> _dataMorphUnitsAmphibiousRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMorphUnitsAmphibiousModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataMorphUnitsAmphibious;
        private readonly Lazy<ObjectProperty<string>> _dataMorphUnitsWaterRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMorphUnitsWaterModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataMorphUnitsWater;
        public PolymorphCreep(): base(2037400385)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _isDataMorphUnitsGroundModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsGroundModified));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _isDataMorphUnitsAirModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAirModified));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _isDataMorphUnitsAmphibiousModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAmphibiousModified));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _isDataMorphUnitsWaterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsWaterModified));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public PolymorphCreep(int newId): base(2037400385, newId)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _isDataMorphUnitsGroundModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsGroundModified));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _isDataMorphUnitsAirModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAirModified));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _isDataMorphUnitsAmphibiousModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAmphibiousModified));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _isDataMorphUnitsWaterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsWaterModified));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public PolymorphCreep(string newRawcode): base(2037400385, newRawcode)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _isDataMorphUnitsGroundModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsGroundModified));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _isDataMorphUnitsAirModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAirModified));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _isDataMorphUnitsAmphibiousModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAmphibiousModified));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _isDataMorphUnitsWaterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsWaterModified));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public PolymorphCreep(ObjectDatabaseBase db): base(2037400385, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _isDataMorphUnitsGroundModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsGroundModified));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _isDataMorphUnitsAirModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAirModified));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _isDataMorphUnitsAmphibiousModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAmphibiousModified));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _isDataMorphUnitsWaterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsWaterModified));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public PolymorphCreep(int newId, ObjectDatabaseBase db): base(2037400385, newId, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _isDataMorphUnitsGroundModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsGroundModified));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _isDataMorphUnitsAirModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAirModified));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _isDataMorphUnitsAmphibiousModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAmphibiousModified));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _isDataMorphUnitsWaterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsWaterModified));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public PolymorphCreep(string newRawcode, ObjectDatabaseBase db): base(2037400385, newRawcode, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _isDataMorphUnitsGroundModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsGroundModified));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _isDataMorphUnitsAirModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAirModified));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _isDataMorphUnitsAmphibiousModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsAmphibiousModified));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _isDataMorphUnitsWaterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphUnitsWaterModified));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public ObjectProperty<int> DataMaximumCreepLevel => _dataMaximumCreepLevel.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumCreepLevelModified => _isDataMaximumCreepLevelModified.Value;
        public ObjectProperty<string> DataMorphUnitsGroundRaw => _dataMorphUnitsGroundRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataMorphUnitsGroundModified => _isDataMorphUnitsGroundModified.Value;
        public ObjectProperty<IEnumerable<Unit>> DataMorphUnitsGround => _dataMorphUnitsGround.Value;
        public ObjectProperty<string> DataMorphUnitsAirRaw => _dataMorphUnitsAirRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataMorphUnitsAirModified => _isDataMorphUnitsAirModified.Value;
        public ObjectProperty<IEnumerable<Unit>> DataMorphUnitsAir => _dataMorphUnitsAir.Value;
        public ObjectProperty<string> DataMorphUnitsAmphibiousRaw => _dataMorphUnitsAmphibiousRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataMorphUnitsAmphibiousModified => _isDataMorphUnitsAmphibiousModified.Value;
        public ObjectProperty<IEnumerable<Unit>> DataMorphUnitsAmphibious => _dataMorphUnitsAmphibious.Value;
        public ObjectProperty<string> DataMorphUnitsWaterRaw => _dataMorphUnitsWaterRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataMorphUnitsWaterModified => _isDataMorphUnitsWaterModified.Value;
        public ObjectProperty<IEnumerable<Unit>> DataMorphUnitsWater => _dataMorphUnitsWater.Value;
        private int GetDataMaximumCreepLevel(int level)
        {
            return _modifications.GetModification(830041168, level).ValueAsInt;
        }

        private void SetDataMaximumCreepLevel(int level, int value)
        {
            _modifications[830041168, level] = new LevelObjectDataModification{Id = 830041168, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaximumCreepLevelModified(int level)
        {
            return _modifications.ContainsKey(830041168, level);
        }

        private string GetDataMorphUnitsGroundRaw(int level)
        {
            return _modifications.GetModification(846818384, level).ValueAsString;
        }

        private void SetDataMorphUnitsGroundRaw(int level, string value)
        {
            _modifications[846818384, level] = new LevelObjectDataModification{Id = 846818384, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMorphUnitsGroundModified(int level)
        {
            return _modifications.ContainsKey(846818384, level);
        }

        private IEnumerable<Unit> GetDataMorphUnitsGround(int level)
        {
            return GetDataMorphUnitsGroundRaw(level).ToIEnumerableUnit(this);
        }

        private void SetDataMorphUnitsGround(int level, IEnumerable<Unit> value)
        {
            SetDataMorphUnitsGroundRaw(level, value.ToRaw(null, null));
        }

        private string GetDataMorphUnitsAirRaw(int level)
        {
            return _modifications.GetModification(863595600, level).ValueAsString;
        }

        private void SetDataMorphUnitsAirRaw(int level, string value)
        {
            _modifications[863595600, level] = new LevelObjectDataModification{Id = 863595600, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMorphUnitsAirModified(int level)
        {
            return _modifications.ContainsKey(863595600, level);
        }

        private IEnumerable<Unit> GetDataMorphUnitsAir(int level)
        {
            return GetDataMorphUnitsAirRaw(level).ToIEnumerableUnit(this);
        }

        private void SetDataMorphUnitsAir(int level, IEnumerable<Unit> value)
        {
            SetDataMorphUnitsAirRaw(level, value.ToRaw(null, null));
        }

        private string GetDataMorphUnitsAmphibiousRaw(int level)
        {
            return _modifications.GetModification(880372816, level).ValueAsString;
        }

        private void SetDataMorphUnitsAmphibiousRaw(int level, string value)
        {
            _modifications[880372816, level] = new LevelObjectDataModification{Id = 880372816, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataMorphUnitsAmphibiousModified(int level)
        {
            return _modifications.ContainsKey(880372816, level);
        }

        private IEnumerable<Unit> GetDataMorphUnitsAmphibious(int level)
        {
            return GetDataMorphUnitsAmphibiousRaw(level).ToIEnumerableUnit(this);
        }

        private void SetDataMorphUnitsAmphibious(int level, IEnumerable<Unit> value)
        {
            SetDataMorphUnitsAmphibiousRaw(level, value.ToRaw(null, null));
        }

        private string GetDataMorphUnitsWaterRaw(int level)
        {
            return _modifications.GetModification(897150032, level).ValueAsString;
        }

        private void SetDataMorphUnitsWaterRaw(int level, string value)
        {
            _modifications[897150032, level] = new LevelObjectDataModification{Id = 897150032, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataMorphUnitsWaterModified(int level)
        {
            return _modifications.ContainsKey(897150032, level);
        }

        private IEnumerable<Unit> GetDataMorphUnitsWater(int level)
        {
            return GetDataMorphUnitsWaterRaw(level).ToIEnumerableUnit(this);
        }

        private void SetDataMorphUnitsWater(int level, IEnumerable<Unit> value)
        {
            SetDataMorphUnitsWaterRaw(level, value.ToRaw(null, null));
        }
    }
}