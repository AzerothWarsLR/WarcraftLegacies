using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemInvulNormal : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataIsMagicImmune;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIsMagicImmuneModified;
        public ItemInvulNormal(): base(1970686273)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
        }

        public ItemInvulNormal(int newId): base(1970686273, newId)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
        }

        public ItemInvulNormal(string newRawcode): base(1970686273, newRawcode)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
        }

        public ItemInvulNormal(ObjectDatabase db): base(1970686273, db)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
        }

        public ItemInvulNormal(int newId, ObjectDatabase db): base(1970686273, newId, db)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
        }

        public ItemInvulNormal(string newRawcode, ObjectDatabase db): base(1970686273, newRawcode, db)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
            _isDataIsMagicImmuneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIsMagicImmuneModified));
        }

        public ObjectProperty<bool> DataIsMagicImmune => _dataIsMagicImmune.Value;
        public ReadOnlyObjectProperty<bool> IsDataIsMagicImmuneModified => _isDataIsMagicImmuneModified.Value;
        private bool GetDataIsMagicImmune(int level)
        {
            return _modifications[1970686273, level].ValueAsBool;
        }

        private void SetDataIsMagicImmune(int level, bool value)
        {
            _modifications[1970686273, level] = new LevelObjectDataModification{Id = 1970686273, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataIsMagicImmuneModified(int level)
        {
            return _modifications.ContainsKey(1970686273, level);
        }
    }
}