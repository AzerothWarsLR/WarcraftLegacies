using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TauntCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataPreferHostiles;
        private readonly Lazy<ObjectProperty<int>> _dataPreferFriendlies;
        private readonly Lazy<ObjectProperty<int>> _dataMaxUnits;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfPulses;
        private readonly Lazy<ObjectProperty<float>> _dataIntervalBetweenPulses;
        public TauntCreep(): base(1635012161)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
        }

        public TauntCreep(int newId): base(1635012161, newId)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
        }

        public TauntCreep(string newRawcode): base(1635012161, newRawcode)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
        }

        public TauntCreep(ObjectDatabase db): base(1635012161, db)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
        }

        public TauntCreep(int newId, ObjectDatabase db): base(1635012161, newId, db)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
        }

        public TauntCreep(string newRawcode, ObjectDatabase db): base(1635012161, newRawcode, db)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
        }

        public ObjectProperty<int> DataPreferHostiles => _dataPreferHostiles.Value;
        public ObjectProperty<int> DataPreferFriendlies => _dataPreferFriendlies.Value;
        public ObjectProperty<int> DataMaxUnits => _dataMaxUnits.Value;
        public ObjectProperty<int> DataNumberOfPulses => _dataNumberOfPulses.Value;
        public ObjectProperty<float> DataIntervalBetweenPulses => _dataIntervalBetweenPulses.Value;
        private int GetDataPreferHostiles(int level)
        {
            return _modifications[829776212, level].ValueAsInt;
        }

        private void SetDataPreferHostiles(int level, int value)
        {
            _modifications[829776212, level] = new LevelObjectDataModification{Id = 829776212, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataPreferFriendlies(int level)
        {
            return _modifications[846553428, level].ValueAsInt;
        }

        private void SetDataPreferFriendlies(int level, int value)
        {
            _modifications[846553428, level] = new LevelObjectDataModification{Id = 846553428, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataMaxUnits(int level)
        {
            return _modifications[863330644, level].ValueAsInt;
        }

        private void SetDataMaxUnits(int level, int value)
        {
            _modifications[863330644, level] = new LevelObjectDataModification{Id = 863330644, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private int GetDataNumberOfPulses(int level)
        {
            return _modifications[880107860, level].ValueAsInt;
        }

        private void SetDataNumberOfPulses(int level, int value)
        {
            _modifications[880107860, level] = new LevelObjectDataModification{Id = 880107860, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataIntervalBetweenPulses(int level)
        {
            return _modifications[896885076, level].ValueAsFloat;
        }

        private void SetDataIntervalBetweenPulses(int level, float value)
        {
            _modifications[896885076, level] = new LevelObjectDataModification{Id = 896885076, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}