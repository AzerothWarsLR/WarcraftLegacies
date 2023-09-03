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
    public sealed class ItemInvulNormal : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataIsMagicImmuneRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIsMagicImmuneModified;
        private readonly Lazy<ObjectProperty<bool>> _dataIsMagicImmune;
        public ItemInvulNormal(): base(1970686273)
        {
            _dataIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIsMagicImmuneRaw, SetDataIsMagicImmuneRaw));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ItemInvulNormal(int newId): base(1970686273, newId)
        {
            _dataIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIsMagicImmuneRaw, SetDataIsMagicImmuneRaw));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ItemInvulNormal(string newRawcode): base(1970686273, newRawcode)
        {
            _dataIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIsMagicImmuneRaw, SetDataIsMagicImmuneRaw));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ItemInvulNormal(ObjectDatabaseBase db): base(1970686273, db)
        {
            _dataIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIsMagicImmuneRaw, SetDataIsMagicImmuneRaw));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ItemInvulNormal(int newId, ObjectDatabaseBase db): base(1970686273, newId, db)
        {
            _dataIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIsMagicImmuneRaw, SetDataIsMagicImmuneRaw));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ItemInvulNormal(string newRawcode, ObjectDatabaseBase db): base(1970686273, newRawcode, db)
        {
            _dataIsMagicImmuneRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIsMagicImmuneRaw, SetDataIsMagicImmuneRaw));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ObjectProperty<int> DataIsMagicImmuneRaw => _dataIsMagicImmuneRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataIsMagicImmuneModified => _isDataIsMagicImmuneModified.Value;
        public ObjectProperty<bool> DataIsMagicImmune => _dataIsMagicImmune.Value;
        private int GetDataIsMagicImmuneRaw(int level)
        {
            return _modifications.GetModification(1970686273, level).ValueAsInt;
        }

        private void SetDataIsMagicImmuneRaw(int level, int value)
        {
            _modifications[1970686273, level] = new LevelObjectDataModification{Id = 1970686273, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataIsMagicImmuneModified(int level)
        {
            return _modifications.ContainsKey(1970686273, level);
        }

        private bool GetDataIsMagicImmune(int level)
        {
            return GetDataIsMagicImmuneRaw(level).ToBool(this);
        }

        private void SetDataIsMagicImmune(int level, bool value)
        {
            SetDataIsMagicImmuneRaw(level, value.ToRaw(0, 1));
        }
    }
}