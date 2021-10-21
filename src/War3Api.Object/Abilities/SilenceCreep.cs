using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SilenceCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAttacksPreventedRaw;
        private readonly Lazy<ObjectProperty<SilenceFlags>> _dataAttacksPrevented;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToMiss;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedModifier;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedModifier;
        public SilenceCreep(): base(1769161537)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
        }

        public SilenceCreep(int newId): base(1769161537, newId)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
        }

        public SilenceCreep(string newRawcode): base(1769161537, newRawcode)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
        }

        public SilenceCreep(ObjectDatabase db): base(1769161537, db)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
        }

        public SilenceCreep(int newId, ObjectDatabase db): base(1769161537, newId, db)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
        }

        public SilenceCreep(string newRawcode, ObjectDatabase db): base(1769161537, newRawcode, db)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
        }

        public ObjectProperty<int> DataAttacksPreventedRaw => _dataAttacksPreventedRaw.Value;
        public ObjectProperty<SilenceFlags> DataAttacksPrevented => _dataAttacksPrevented.Value;
        public ObjectProperty<float> DataChanceToMiss => _dataChanceToMiss.Value;
        public ObjectProperty<float> DataMovementSpeedModifier => _dataMovementSpeedModifier.Value;
        public ObjectProperty<float> DataAttackSpeedModifier => _dataAttackSpeedModifier.Value;
        private int GetDataAttacksPreventedRaw(int level)
        {
            return _modifications[828994382, level].ValueAsInt;
        }

        private void SetDataAttacksPreventedRaw(int level, int value)
        {
            _modifications[828994382, level] = new LevelObjectDataModification{Id = 828994382, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private SilenceFlags GetDataAttacksPrevented(int level)
        {
            return GetDataAttacksPreventedRaw(level).ToSilenceFlags(this);
        }

        private void SetDataAttacksPrevented(int level, SilenceFlags value)
        {
            SetDataAttacksPreventedRaw(level, value.ToRaw(0, 15));
        }

        private float GetDataChanceToMiss(int level)
        {
            return _modifications[845771598, level].ValueAsFloat;
        }

        private void SetDataChanceToMiss(int level, float value)
        {
            _modifications[845771598, level] = new LevelObjectDataModification{Id = 845771598, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataMovementSpeedModifier(int level)
        {
            return _modifications[862548814, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedModifier(int level, float value)
        {
            _modifications[862548814, level] = new LevelObjectDataModification{Id = 862548814, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataAttackSpeedModifier(int level)
        {
            return _modifications[879326030, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedModifier(int level, float value)
        {
            _modifications[879326030, level] = new LevelObjectDataModification{Id = 879326030, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}