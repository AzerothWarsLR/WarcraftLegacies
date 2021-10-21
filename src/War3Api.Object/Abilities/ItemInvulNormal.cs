using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemInvulNormal : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataIsMagicImmune;
        public ItemInvulNormal(): base(1970686273)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ItemInvulNormal(int newId): base(1970686273, newId)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ItemInvulNormal(string newRawcode): base(1970686273, newRawcode)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ItemInvulNormal(ObjectDatabase db): base(1970686273, db)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ItemInvulNormal(int newId, ObjectDatabase db): base(1970686273, newId, db)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ItemInvulNormal(string newRawcode, ObjectDatabase db): base(1970686273, newRawcode, db)
        {
            _dataIsMagicImmune = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIsMagicImmune, SetDataIsMagicImmune));
        }

        public ObjectProperty<bool> DataIsMagicImmune => _dataIsMagicImmune.Value;
        private bool GetDataIsMagicImmune(int level)
        {
            return _modifications[1970686273, level].ValueAsBool;
        }

        private void SetDataIsMagicImmune(int level, bool value)
        {
            _modifications[1970686273, level] = new LevelObjectDataModification{Id = 1970686273, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 1};
        }
    }
}