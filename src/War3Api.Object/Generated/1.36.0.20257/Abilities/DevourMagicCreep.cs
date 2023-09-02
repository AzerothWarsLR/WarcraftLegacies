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
    public sealed class DevourMagicCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataIgnoreFriendlyBuffsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIgnoreFriendlyBuffsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataIgnoreFriendlyBuffs;
        public DevourMagicCreep(): base(1701069633)
        {
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagicCreep(int newId): base(1701069633, newId)
        {
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagicCreep(string newRawcode): base(1701069633, newRawcode)
        {
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagicCreep(ObjectDatabaseBase db): base(1701069633, db)
        {
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagicCreep(int newId, ObjectDatabaseBase db): base(1701069633, newId, db)
        {
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagicCreep(string newRawcode, ObjectDatabaseBase db): base(1701069633, newRawcode, db)
        {
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public ObjectProperty<int> DataIgnoreFriendlyBuffsRaw => _dataIgnoreFriendlyBuffsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataIgnoreFriendlyBuffsModified => _isDataIgnoreFriendlyBuffsModified.Value;
        public ObjectProperty<bool> DataIgnoreFriendlyBuffs => _dataIgnoreFriendlyBuffs.Value;
        private int GetDataIgnoreFriendlyBuffsRaw(int level)
        {
            return _modifications.GetModification(913143396, level).ValueAsInt;
        }

        private void SetDataIgnoreFriendlyBuffsRaw(int level, int value)
        {
            _modifications[913143396, level] = new LevelObjectDataModification{Id = 913143396, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataIgnoreFriendlyBuffsModified(int level)
        {
            return _modifications.ContainsKey(913143396, level);
        }

        private bool GetDataIgnoreFriendlyBuffs(int level)
        {
            return GetDataIgnoreFriendlyBuffsRaw(level).ToBool(this);
        }

        private void SetDataIgnoreFriendlyBuffs(int level, bool value)
        {
            SetDataIgnoreFriendlyBuffsRaw(level, value.ToRaw(0, 99999));
        }
    }
}