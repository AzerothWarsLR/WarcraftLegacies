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
    public sealed class Preservation : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataBuildingTypesAllowedRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBuildingTypesAllowedModified;
        private readonly Lazy<ObjectProperty<PickFlags>> _dataBuildingTypesAllowed;
        public Preservation(): base(1919962689)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
        }

        public Preservation(int newId): base(1919962689, newId)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
        }

        public Preservation(string newRawcode): base(1919962689, newRawcode)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
        }

        public Preservation(ObjectDatabaseBase db): base(1919962689, db)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
        }

        public Preservation(int newId, ObjectDatabaseBase db): base(1919962689, newId, db)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
        }

        public Preservation(string newRawcode, ObjectDatabaseBase db): base(1919962689, newRawcode, db)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
        }

        public ObjectProperty<int> DataBuildingTypesAllowedRaw => _dataBuildingTypesAllowedRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataBuildingTypesAllowedModified => _isDataBuildingTypesAllowedModified.Value;
        public ObjectProperty<PickFlags> DataBuildingTypesAllowed => _dataBuildingTypesAllowed.Value;
        private int GetDataBuildingTypesAllowedRaw(int level)
        {
            return _modifications.GetModification(829583438, level).ValueAsInt;
        }

        private void SetDataBuildingTypesAllowedRaw(int level, int value)
        {
            _modifications[829583438, level] = new LevelObjectDataModification{Id = 829583438, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataBuildingTypesAllowedModified(int level)
        {
            return _modifications.ContainsKey(829583438, level);
        }

        private PickFlags GetDataBuildingTypesAllowed(int level)
        {
            return GetDataBuildingTypesAllowedRaw(level).ToPickFlags(this);
        }

        private void SetDataBuildingTypesAllowed(int level, PickFlags value)
        {
            SetDataBuildingTypesAllowedRaw(level, value.ToRaw(null, null));
        }
    }
}