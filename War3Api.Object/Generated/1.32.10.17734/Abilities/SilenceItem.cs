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
    public sealed class SilenceItem : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAttacksPreventedRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttacksPreventedModified;
        private readonly Lazy<ObjectProperty<SilenceFlags>> _dataAttacksPrevented;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToMiss;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToMissModified;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedModifier;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedModifierModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedModifier;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedModifierModified;
        public SilenceItem(): base(1702054209)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _isDataAttacksPreventedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttacksPreventedModified));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _isDataMovementSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedModifierModified));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
            _isDataAttackSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedModifierModified));
        }

        public SilenceItem(int newId): base(1702054209, newId)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _isDataAttacksPreventedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttacksPreventedModified));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _isDataMovementSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedModifierModified));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
            _isDataAttackSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedModifierModified));
        }

        public SilenceItem(string newRawcode): base(1702054209, newRawcode)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _isDataAttacksPreventedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttacksPreventedModified));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _isDataMovementSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedModifierModified));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
            _isDataAttackSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedModifierModified));
        }

        public SilenceItem(ObjectDatabaseBase db): base(1702054209, db)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _isDataAttacksPreventedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttacksPreventedModified));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _isDataMovementSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedModifierModified));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
            _isDataAttackSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedModifierModified));
        }

        public SilenceItem(int newId, ObjectDatabaseBase db): base(1702054209, newId, db)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _isDataAttacksPreventedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttacksPreventedModified));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _isDataMovementSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedModifierModified));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
            _isDataAttackSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedModifierModified));
        }

        public SilenceItem(string newRawcode, ObjectDatabaseBase db): base(1702054209, newRawcode, db)
        {
            _dataAttacksPreventedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttacksPreventedRaw, SetDataAttacksPreventedRaw));
            _isDataAttacksPreventedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttacksPreventedModified));
            _dataAttacksPrevented = new Lazy<ObjectProperty<SilenceFlags>>(() => new ObjectProperty<SilenceFlags>(GetDataAttacksPrevented, SetDataAttacksPrevented));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataMovementSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedModifier, SetDataMovementSpeedModifier));
            _isDataMovementSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedModifierModified));
            _dataAttackSpeedModifier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedModifier, SetDataAttackSpeedModifier));
            _isDataAttackSpeedModifierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedModifierModified));
        }

        public ObjectProperty<int> DataAttacksPreventedRaw => _dataAttacksPreventedRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttacksPreventedModified => _isDataAttacksPreventedModified.Value;
        public ObjectProperty<SilenceFlags> DataAttacksPrevented => _dataAttacksPrevented.Value;
        public ObjectProperty<float> DataChanceToMiss => _dataChanceToMiss.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToMissModified => _isDataChanceToMissModified.Value;
        public ObjectProperty<float> DataMovementSpeedModifier => _dataMovementSpeedModifier.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedModifierModified => _isDataMovementSpeedModifierModified.Value;
        public ObjectProperty<float> DataAttackSpeedModifier => _dataAttackSpeedModifier.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedModifierModified => _isDataAttackSpeedModifierModified.Value;
        private int GetDataAttacksPreventedRaw(int level)
        {
            return _modifications.GetModification(828994382, level).ValueAsInt;
        }

        private void SetDataAttacksPreventedRaw(int level, int value)
        {
            _modifications[828994382, level] = new LevelObjectDataModification{Id = 828994382, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAttacksPreventedModified(int level)
        {
            return _modifications.ContainsKey(828994382, level);
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
            return _modifications.GetModification(845771598, level).ValueAsFloat;
        }

        private void SetDataChanceToMiss(int level, float value)
        {
            _modifications[845771598, level] = new LevelObjectDataModification{Id = 845771598, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataChanceToMissModified(int level)
        {
            return _modifications.ContainsKey(845771598, level);
        }

        private float GetDataMovementSpeedModifier(int level)
        {
            return _modifications.GetModification(862548814, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedModifier(int level, float value)
        {
            _modifications[862548814, level] = new LevelObjectDataModification{Id = 862548814, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMovementSpeedModifierModified(int level)
        {
            return _modifications.ContainsKey(862548814, level);
        }

        private float GetDataAttackSpeedModifier(int level)
        {
            return _modifications.GetModification(879326030, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedModifier(int level, float value)
        {
            _modifications[879326030, level] = new LevelObjectDataModification{Id = 879326030, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataAttackSpeedModifierModified(int level)
        {
            return _modifications.ContainsKey(879326030, level);
        }
    }
}