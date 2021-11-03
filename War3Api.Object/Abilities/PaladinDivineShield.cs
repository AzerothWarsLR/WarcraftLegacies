using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PaladinDivineShield : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataCanDeactivate;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCanDeactivateModified;
        public PaladinDivineShield(): base(1935951937)
        {
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
        }

        public PaladinDivineShield(int newId): base(1935951937, newId)
        {
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
        }

        public PaladinDivineShield(string newRawcode): base(1935951937, newRawcode)
        {
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
        }

        public PaladinDivineShield(ObjectDatabase db): base(1935951937, db)
        {
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
        }

        public PaladinDivineShield(int newId, ObjectDatabase db): base(1935951937, newId, db)
        {
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
        }

        public PaladinDivineShield(string newRawcode, ObjectDatabase db): base(1935951937, newRawcode, db)
        {
            _dataCanDeactivate = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDeactivate, SetDataCanDeactivate));
            _isDataCanDeactivateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDeactivateModified));
        }

        public ObjectProperty<bool> DataCanDeactivate => _dataCanDeactivate.Value;
        public ReadOnlyObjectProperty<bool> IsDataCanDeactivateModified => _isDataCanDeactivateModified.Value;
        private bool GetDataCanDeactivate(int level)
        {
            return _modifications[829645896, level].ValueAsBool;
        }

        private void SetDataCanDeactivate(int level, bool value)
        {
            _modifications[829645896, level] = new LevelObjectDataModification{Id = 829645896, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataCanDeactivateModified(int level)
        {
            return _modifications.ContainsKey(829645896, level);
        }
    }
}