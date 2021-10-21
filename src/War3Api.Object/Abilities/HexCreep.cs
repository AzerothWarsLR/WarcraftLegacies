using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class HexCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumCreepLevel;
        private readonly Lazy<ObjectProperty<string>> _dataMorphUnitsGroundRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataMorphUnitsGround;
        private readonly Lazy<ObjectProperty<string>> _dataMorphUnitsAirRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataMorphUnitsAir;
        private readonly Lazy<ObjectProperty<string>> _dataMorphUnitsAmphibiousRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataMorphUnitsAmphibious;
        private readonly Lazy<ObjectProperty<string>> _dataMorphUnitsWaterRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataMorphUnitsWater;
        public HexCreep(): base(2020098881)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public HexCreep(int newId): base(2020098881, newId)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public HexCreep(string newRawcode): base(2020098881, newRawcode)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public HexCreep(ObjectDatabase db): base(2020098881, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public HexCreep(int newId, ObjectDatabase db): base(2020098881, newId, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public HexCreep(string newRawcode, ObjectDatabase db): base(2020098881, newRawcode, db)
        {
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _dataMorphUnitsGroundRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsGroundRaw, SetDataMorphUnitsGroundRaw));
            _dataMorphUnitsGround = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsGround, SetDataMorphUnitsGround));
            _dataMorphUnitsAirRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAirRaw, SetDataMorphUnitsAirRaw));
            _dataMorphUnitsAir = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAir, SetDataMorphUnitsAir));
            _dataMorphUnitsAmphibiousRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsAmphibiousRaw, SetDataMorphUnitsAmphibiousRaw));
            _dataMorphUnitsAmphibious = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsAmphibious, SetDataMorphUnitsAmphibious));
            _dataMorphUnitsWaterRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataMorphUnitsWaterRaw, SetDataMorphUnitsWaterRaw));
            _dataMorphUnitsWater = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataMorphUnitsWater, SetDataMorphUnitsWater));
        }

        public ObjectProperty<int> DataMaximumCreepLevel => _dataMaximumCreepLevel.Value;
        public ObjectProperty<string> DataMorphUnitsGroundRaw => _dataMorphUnitsGroundRaw.Value;
        public ObjectProperty<IEnumerable<Unit>> DataMorphUnitsGround => _dataMorphUnitsGround.Value;
        public ObjectProperty<string> DataMorphUnitsAirRaw => _dataMorphUnitsAirRaw.Value;
        public ObjectProperty<IEnumerable<Unit>> DataMorphUnitsAir => _dataMorphUnitsAir.Value;
        public ObjectProperty<string> DataMorphUnitsAmphibiousRaw => _dataMorphUnitsAmphibiousRaw.Value;
        public ObjectProperty<IEnumerable<Unit>> DataMorphUnitsAmphibious => _dataMorphUnitsAmphibious.Value;
        public ObjectProperty<string> DataMorphUnitsWaterRaw => _dataMorphUnitsWaterRaw.Value;
        public ObjectProperty<IEnumerable<Unit>> DataMorphUnitsWater => _dataMorphUnitsWater.Value;
        private int GetDataMaximumCreepLevel(int level)
        {
            return _modifications[830041168, level].ValueAsInt;
        }

        private void SetDataMaximumCreepLevel(int level, int value)
        {
            _modifications[830041168, level] = new LevelObjectDataModification{Id = 830041168, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private string GetDataMorphUnitsGroundRaw(int level)
        {
            return _modifications[846818384, level].ValueAsString;
        }

        private void SetDataMorphUnitsGroundRaw(int level, string value)
        {
            _modifications[846818384, level] = new LevelObjectDataModification{Id = 846818384, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 2};
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
            return _modifications[863595600, level].ValueAsString;
        }

        private void SetDataMorphUnitsAirRaw(int level, string value)
        {
            _modifications[863595600, level] = new LevelObjectDataModification{Id = 863595600, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 3};
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
            return _modifications[880372816, level].ValueAsString;
        }

        private void SetDataMorphUnitsAmphibiousRaw(int level, string value)
        {
            _modifications[880372816, level] = new LevelObjectDataModification{Id = 880372816, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 4};
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
            return _modifications[897150032, level].ValueAsString;
        }

        private void SetDataMorphUnitsWaterRaw(int level, string value)
        {
            _modifications[897150032, level] = new LevelObjectDataModification{Id = 897150032, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 5};
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