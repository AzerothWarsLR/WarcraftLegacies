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
    public sealed class Ensnare : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAirUnitLowerDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAirUnitLowerDurationModified;
        private readonly Lazy<ObjectProperty<float>> _dataAirUnitHeight;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAirUnitHeightModified;
        private readonly Lazy<ObjectProperty<float>> _dataMeleeAttackRange;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMeleeAttackRangeModified;
        public Ensnare(): base(1936614721)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _isDataAirUnitLowerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitLowerDurationModified));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _isDataAirUnitHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitHeightModified));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
            _isDataMeleeAttackRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeAttackRangeModified));
        }

        public Ensnare(int newId): base(1936614721, newId)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _isDataAirUnitLowerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitLowerDurationModified));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _isDataAirUnitHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitHeightModified));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
            _isDataMeleeAttackRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeAttackRangeModified));
        }

        public Ensnare(string newRawcode): base(1936614721, newRawcode)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _isDataAirUnitLowerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitLowerDurationModified));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _isDataAirUnitHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitHeightModified));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
            _isDataMeleeAttackRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeAttackRangeModified));
        }

        public Ensnare(ObjectDatabaseBase db): base(1936614721, db)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _isDataAirUnitLowerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitLowerDurationModified));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _isDataAirUnitHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitHeightModified));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
            _isDataMeleeAttackRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeAttackRangeModified));
        }

        public Ensnare(int newId, ObjectDatabaseBase db): base(1936614721, newId, db)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _isDataAirUnitLowerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitLowerDurationModified));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _isDataAirUnitHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitHeightModified));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
            _isDataMeleeAttackRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeAttackRangeModified));
        }

        public Ensnare(string newRawcode, ObjectDatabaseBase db): base(1936614721, newRawcode, db)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _isDataAirUnitLowerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitLowerDurationModified));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _isDataAirUnitHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAirUnitHeightModified));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
            _isDataMeleeAttackRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMeleeAttackRangeModified));
        }

        public ObjectProperty<float> DataAirUnitLowerDuration => _dataAirUnitLowerDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataAirUnitLowerDurationModified => _isDataAirUnitLowerDurationModified.Value;
        public ObjectProperty<float> DataAirUnitHeight => _dataAirUnitHeight.Value;
        public ReadOnlyObjectProperty<bool> IsDataAirUnitHeightModified => _isDataAirUnitHeightModified.Value;
        public ObjectProperty<float> DataMeleeAttackRange => _dataMeleeAttackRange.Value;
        public ReadOnlyObjectProperty<bool> IsDataMeleeAttackRangeModified => _isDataMeleeAttackRangeModified.Value;
        private float GetDataAirUnitLowerDuration(int level)
        {
            return _modifications.GetModification(829648453, level).ValueAsFloat;
        }

        private void SetDataAirUnitLowerDuration(int level, float value)
        {
            _modifications[829648453, level] = new LevelObjectDataModification{Id = 829648453, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAirUnitLowerDurationModified(int level)
        {
            return _modifications.ContainsKey(829648453, level);
        }

        private float GetDataAirUnitHeight(int level)
        {
            return _modifications.GetModification(846425669, level).ValueAsFloat;
        }

        private void SetDataAirUnitHeight(int level, float value)
        {
            _modifications[846425669, level] = new LevelObjectDataModification{Id = 846425669, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAirUnitHeightModified(int level)
        {
            return _modifications.ContainsKey(846425669, level);
        }

        private float GetDataMeleeAttackRange(int level)
        {
            return _modifications.GetModification(863202885, level).ValueAsFloat;
        }

        private void SetDataMeleeAttackRange(int level, float value)
        {
            _modifications[863202885, level] = new LevelObjectDataModification{Id = 863202885, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMeleeAttackRangeModified(int level)
        {
            return _modifications.ContainsKey(863202885, level);
        }
    }
}