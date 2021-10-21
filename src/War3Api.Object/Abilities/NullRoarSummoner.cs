using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class NullRoarSummoner : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaRegen;
        private readonly Lazy<ObjectProperty<bool>> _dataPreferHostiles;
        private readonly Lazy<ObjectProperty<bool>> _dataPreferFriendlies;
        private readonly Lazy<ObjectProperty<int>> _dataMaxUnits;
        public NullRoarSummoner(): base(1819174977)
        {
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
        }

        public NullRoarSummoner(int newId): base(1819174977, newId)
        {
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
        }

        public NullRoarSummoner(string newRawcode): base(1819174977, newRawcode)
        {
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
        }

        public NullRoarSummoner(ObjectDatabase db): base(1819174977, db)
        {
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
        }

        public NullRoarSummoner(int newId, ObjectDatabase db): base(1819174977, newId, db)
        {
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
        }

        public NullRoarSummoner(string newRawcode, ObjectDatabase db): base(1819174977, newRawcode, db)
        {
            _dataManaRegen = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegen, SetDataManaRegen));
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
        }

        public ObjectProperty<float> DataManaRegen => _dataManaRegen.Value;
        public ObjectProperty<bool> DataPreferHostiles => _dataPreferHostiles.Value;
        public ObjectProperty<bool> DataPreferFriendlies => _dataPreferFriendlies.Value;
        public ObjectProperty<int> DataMaxUnits => _dataMaxUnits.Value;
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
    }
}