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
    public sealed class TauntCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataPreferHostiles;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPreferHostilesModified;
        private readonly Lazy<ObjectProperty<int>> _dataPreferFriendlies;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPreferFriendliesModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaxUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxUnitsModified;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfPulses;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfPulsesModified;
        private readonly Lazy<ObjectProperty<float>> _dataIntervalBetweenPulses;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIntervalBetweenPulsesModified;
        public TauntCreep(): base(1635012161)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _isDataPreferHostilesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferHostilesModified));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _isDataPreferFriendliesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferFriendliesModified));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _isDataMaxUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsModified));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _isDataNumberOfPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfPulsesModified));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
            _isDataIntervalBetweenPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalBetweenPulsesModified));
        }

        public TauntCreep(int newId): base(1635012161, newId)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _isDataPreferHostilesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferHostilesModified));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _isDataPreferFriendliesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferFriendliesModified));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _isDataMaxUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsModified));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _isDataNumberOfPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfPulsesModified));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
            _isDataIntervalBetweenPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalBetweenPulsesModified));
        }

        public TauntCreep(string newRawcode): base(1635012161, newRawcode)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _isDataPreferHostilesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferHostilesModified));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _isDataPreferFriendliesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferFriendliesModified));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _isDataMaxUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsModified));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _isDataNumberOfPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfPulsesModified));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
            _isDataIntervalBetweenPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalBetweenPulsesModified));
        }

        public TauntCreep(ObjectDatabaseBase db): base(1635012161, db)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _isDataPreferHostilesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferHostilesModified));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _isDataPreferFriendliesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferFriendliesModified));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _isDataMaxUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsModified));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _isDataNumberOfPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfPulsesModified));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
            _isDataIntervalBetweenPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalBetweenPulsesModified));
        }

        public TauntCreep(int newId, ObjectDatabaseBase db): base(1635012161, newId, db)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _isDataPreferHostilesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferHostilesModified));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _isDataPreferFriendliesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferFriendliesModified));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _isDataMaxUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsModified));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _isDataNumberOfPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfPulsesModified));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
            _isDataIntervalBetweenPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalBetweenPulsesModified));
        }

        public TauntCreep(string newRawcode, ObjectDatabaseBase db): base(1635012161, newRawcode, db)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferHostiles, SetDataPreferHostiles));
            _isDataPreferHostilesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferHostilesModified));
            _dataPreferFriendlies = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _isDataPreferFriendliesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPreferFriendliesModified));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _isDataMaxUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsModified));
            _dataNumberOfPulses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfPulses, SetDataNumberOfPulses));
            _isDataNumberOfPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfPulsesModified));
            _dataIntervalBetweenPulses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIntervalBetweenPulses, SetDataIntervalBetweenPulses));
            _isDataIntervalBetweenPulsesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalBetweenPulsesModified));
        }

        public ObjectProperty<int> DataPreferHostiles => _dataPreferHostiles.Value;
        public ReadOnlyObjectProperty<bool> IsDataPreferHostilesModified => _isDataPreferHostilesModified.Value;
        public ObjectProperty<int> DataPreferFriendlies => _dataPreferFriendlies.Value;
        public ReadOnlyObjectProperty<bool> IsDataPreferFriendliesModified => _isDataPreferFriendliesModified.Value;
        public ObjectProperty<int> DataMaxUnits => _dataMaxUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxUnitsModified => _isDataMaxUnitsModified.Value;
        public ObjectProperty<int> DataNumberOfPulses => _dataNumberOfPulses.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfPulsesModified => _isDataNumberOfPulsesModified.Value;
        public ObjectProperty<float> DataIntervalBetweenPulses => _dataIntervalBetweenPulses.Value;
        public ReadOnlyObjectProperty<bool> IsDataIntervalBetweenPulsesModified => _isDataIntervalBetweenPulsesModified.Value;
        private int GetDataPreferHostiles(int level)
        {
            return _modifications.GetModification(829776212, level).ValueAsInt;
        }

        private void SetDataPreferHostiles(int level, int value)
        {
            _modifications[829776212, level] = new LevelObjectDataModification{Id = 829776212, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataPreferHostilesModified(int level)
        {
            return _modifications.ContainsKey(829776212, level);
        }

        private int GetDataPreferFriendlies(int level)
        {
            return _modifications.GetModification(846553428, level).ValueAsInt;
        }

        private void SetDataPreferFriendlies(int level, int value)
        {
            _modifications[846553428, level] = new LevelObjectDataModification{Id = 846553428, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataPreferFriendliesModified(int level)
        {
            return _modifications.ContainsKey(846553428, level);
        }

        private int GetDataMaxUnits(int level)
        {
            return _modifications.GetModification(863330644, level).ValueAsInt;
        }

        private void SetDataMaxUnits(int level, int value)
        {
            _modifications[863330644, level] = new LevelObjectDataModification{Id = 863330644, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMaxUnitsModified(int level)
        {
            return _modifications.ContainsKey(863330644, level);
        }

        private int GetDataNumberOfPulses(int level)
        {
            return _modifications.GetModification(880107860, level).ValueAsInt;
        }

        private void SetDataNumberOfPulses(int level, int value)
        {
            _modifications[880107860, level] = new LevelObjectDataModification{Id = 880107860, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataNumberOfPulsesModified(int level)
        {
            return _modifications.ContainsKey(880107860, level);
        }

        private float GetDataIntervalBetweenPulses(int level)
        {
            return _modifications.GetModification(896885076, level).ValueAsFloat;
        }

        private void SetDataIntervalBetweenPulses(int level, float value)
        {
            _modifications[896885076, level] = new LevelObjectDataModification{Id = 896885076, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataIntervalBetweenPulsesModified(int level)
        {
            return _modifications.ContainsKey(896885076, level);
        }
    }
}