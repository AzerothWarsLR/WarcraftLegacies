using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BattleRoar : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDefenseIncrease;
        private readonly Lazy<ObjectProperty<float>> _dataLifeRegenerationRate;
        private readonly Lazy<ObjectProperty<float>> _dataManaRegen;
        private readonly Lazy<ObjectProperty<bool>> _dataPreferHostiles;
        private readonly Lazy<ObjectProperty<bool>> _dataPreferFriendlies;
        private readonly Lazy<ObjectProperty<int>> _dataMaxUnits;
        private readonly Lazy<ObjectProperty<float>> _dataDamageIncrease;
        public BattleRoar(): base(1919045185)
        {
            _dataDefenseIncrease = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseIncrease, SetDataDefenseIncrease));
            _dataLifeRegenerationRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationRate, SetDataLifeRegenerationRate));
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageIncrease, SetDataDamageIncrease));
        }

        public BattleRoar(int newId): base(1919045185, newId)
        {
            _dataDefenseIncrease = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseIncrease, SetDataDefenseIncrease));
            _dataLifeRegenerationRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationRate, SetDataLifeRegenerationRate));
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageIncrease, SetDataDamageIncrease));
        }

        public BattleRoar(string newRawcode): base(1919045185, newRawcode)
        {
            _dataDefenseIncrease = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseIncrease, SetDataDefenseIncrease));
            _dataLifeRegenerationRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationRate, SetDataLifeRegenerationRate));
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageIncrease, SetDataDamageIncrease));
        }

        public BattleRoar(ObjectDatabase db): base(1919045185, db)
        {
            _dataDefenseIncrease = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseIncrease, SetDataDefenseIncrease));
            _dataLifeRegenerationRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationRate, SetDataLifeRegenerationRate));
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageIncrease, SetDataDamageIncrease));
        }

        public BattleRoar(int newId, ObjectDatabase db): base(1919045185, newId, db)
        {
            _dataDefenseIncrease = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseIncrease, SetDataDefenseIncrease));
            _dataLifeRegenerationRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationRate, SetDataLifeRegenerationRate));
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageIncrease, SetDataDamageIncrease));
        }

        public BattleRoar(string newRawcode, ObjectDatabase db): base(1919045185, newRawcode, db)
        {
            _dataDefenseIncrease = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseIncrease, SetDataDefenseIncrease));
            _dataLifeRegenerationRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationRate, SetDataLifeRegenerationRate));
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataDamageIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageIncrease, SetDataDamageIncrease));
        }

        public ObjectProperty<int> DataDefenseIncrease => _dataDefenseIncrease.Value;
        public ObjectProperty<float> DataLifeRegenerationRate => _dataLifeRegenerationRate.Value;
        public ObjectProperty<float> DataManaRegen => _dataManaRegen.Value;
        public ObjectProperty<bool> DataPreferHostiles => _dataPreferHostiles.Value;
        public ObjectProperty<bool> DataPreferFriendlies => _dataPreferFriendlies.Value;
        public ObjectProperty<int> DataMaxUnits => _dataMaxUnits.Value;
        public ObjectProperty<float> DataDamageIncrease => _dataDamageIncrease.Value;
        private int GetDataDefenseIncrease(int level)
        {
            return _modifications[845246290, level].ValueAsInt;
        }

        private void SetDataDefenseIncrease(int level, int value)
        {
            _modifications[845246290, level] = new LevelObjectDataModification{Id = 845246290, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataLifeRegenerationRate(int level)
        {
            return _modifications[862023506, level].ValueAsFloat;
        }

        private void SetDataLifeRegenerationRate(int level, float value)
        {
            _modifications[862023506, level] = new LevelObjectDataModification{Id = 862023506, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataManaRegen(int level)
        {
            return _modifications[878800722, level].ValueAsFloat;
        }

        private void SetDataManaRegen(int level, float value)
        {
            _modifications[878800722, level] = new LevelObjectDataModification{Id = 878800722, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataPreferHostiles(int level)
        {
            return _modifications[895577938, level].ValueAsBool;
        }

        private void SetDataPreferHostiles(int level, bool value)
        {
            _modifications[895577938, level] = new LevelObjectDataModification{Id = 895577938, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private bool GetDataPreferFriendlies(int level)
        {
            return _modifications[912355154, level].ValueAsBool;
        }

        private void SetDataPreferFriendlies(int level, bool value)
        {
            _modifications[912355154, level] = new LevelObjectDataModification{Id = 912355154, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 6};
        }

        private int GetDataMaxUnits(int level)
        {
            return _modifications[929132370, level].ValueAsInt;
        }

        private void SetDataMaxUnits(int level, int value)
        {
            _modifications[929132370, level] = new LevelObjectDataModification{Id = 929132370, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 7};
        }

        private float GetDataDamageIncrease(int level)
        {
            return _modifications[829579854, level].ValueAsFloat;
        }

        private void SetDataDamageIncrease(int level, float value)
        {
            _modifications[829579854, level] = new LevelObjectDataModification{Id = 829579854, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}