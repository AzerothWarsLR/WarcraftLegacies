using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class WebCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAirUnitLowerDuration;
        private readonly Lazy<ObjectProperty<float>> _dataAirUnitHeight;
        private readonly Lazy<ObjectProperty<float>> _dataMeleeAttackRange;
        public WebCreep(): base(1651983169)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
        }

        public WebCreep(int newId): base(1651983169, newId)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
        }

        public WebCreep(string newRawcode): base(1651983169, newRawcode)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
        }

        public WebCreep(ObjectDatabase db): base(1651983169, db)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
        }

        public WebCreep(int newId, ObjectDatabase db): base(1651983169, newId, db)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
        }

        public WebCreep(string newRawcode, ObjectDatabase db): base(1651983169, newRawcode, db)
        {
            _dataAirUnitLowerDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitLowerDuration, SetDataAirUnitLowerDuration));
            _dataAirUnitHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAirUnitHeight, SetDataAirUnitHeight));
            _dataMeleeAttackRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMeleeAttackRange, SetDataMeleeAttackRange));
        }

        public ObjectProperty<float> DataAirUnitLowerDuration => _dataAirUnitLowerDuration.Value;
        public ObjectProperty<float> DataAirUnitHeight => _dataAirUnitHeight.Value;
        public ObjectProperty<float> DataMeleeAttackRange => _dataMeleeAttackRange.Value;
        private float GetDataAirUnitLowerDuration(int level)
        {
            return _modifications[829648453, level].ValueAsFloat;
        }

        private void SetDataAirUnitLowerDuration(int level, float value)
        {
            _modifications[829648453, level] = new LevelObjectDataModification{Id = 829648453, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataAirUnitHeight(int level)
        {
            return _modifications[846425669, level].ValueAsFloat;
        }

        private void SetDataAirUnitHeight(int level, float value)
        {
            _modifications[846425669, level] = new LevelObjectDataModification{Id = 846425669, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataMeleeAttackRange(int level)
        {
            return _modifications[863202885, level].ValueAsFloat;
        }

        private void SetDataMeleeAttackRange(int level, float value)
        {
            _modifications[863202885, level] = new LevelObjectDataModification{Id = 863202885, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}