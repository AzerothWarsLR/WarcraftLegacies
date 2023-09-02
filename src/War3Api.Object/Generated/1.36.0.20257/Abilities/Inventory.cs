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
    public sealed class Inventory : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataItemCapacity;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataItemCapacityModified;
        private readonly Lazy<ObjectProperty<int>> _dataDropItemsOnDeathRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDropItemsOnDeathModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDropItemsOnDeath;
        private readonly Lazy<ObjectProperty<int>> _dataCanUseItemsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCanUseItemsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataCanUseItems;
        private readonly Lazy<ObjectProperty<int>> _dataCanGetItemsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCanGetItemsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataCanGetItems;
        private readonly Lazy<ObjectProperty<int>> _dataCanDropItemsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCanDropItemsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataCanDropItems;
        public Inventory(): base(1986939201)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDropItemsOnDeathRaw, SetDataDropItemsOnDeathRaw));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanUseItemsRaw, SetDataCanUseItemsRaw));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanGetItemsRaw, SetDataCanGetItemsRaw));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDropItemsRaw, SetDataCanDropItemsRaw));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public Inventory(int newId): base(1986939201, newId)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDropItemsOnDeathRaw, SetDataDropItemsOnDeathRaw));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanUseItemsRaw, SetDataCanUseItemsRaw));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanGetItemsRaw, SetDataCanGetItemsRaw));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDropItemsRaw, SetDataCanDropItemsRaw));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public Inventory(string newRawcode): base(1986939201, newRawcode)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDropItemsOnDeathRaw, SetDataDropItemsOnDeathRaw));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanUseItemsRaw, SetDataCanUseItemsRaw));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanGetItemsRaw, SetDataCanGetItemsRaw));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDropItemsRaw, SetDataCanDropItemsRaw));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public Inventory(ObjectDatabaseBase db): base(1986939201, db)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDropItemsOnDeathRaw, SetDataDropItemsOnDeathRaw));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanUseItemsRaw, SetDataCanUseItemsRaw));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanGetItemsRaw, SetDataCanGetItemsRaw));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDropItemsRaw, SetDataCanDropItemsRaw));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public Inventory(int newId, ObjectDatabaseBase db): base(1986939201, newId, db)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDropItemsOnDeathRaw, SetDataDropItemsOnDeathRaw));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanUseItemsRaw, SetDataCanUseItemsRaw));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanGetItemsRaw, SetDataCanGetItemsRaw));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDropItemsRaw, SetDataCanDropItemsRaw));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public Inventory(string newRawcode, ObjectDatabaseBase db): base(1986939201, newRawcode, db)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDropItemsOnDeathRaw, SetDataDropItemsOnDeathRaw));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanUseItemsRaw, SetDataCanUseItemsRaw));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanGetItemsRaw, SetDataCanGetItemsRaw));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItemsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCanDropItemsRaw, SetDataCanDropItemsRaw));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public ObjectProperty<int> DataItemCapacity => _dataItemCapacity.Value;
        public ReadOnlyObjectProperty<bool> IsDataItemCapacityModified => _isDataItemCapacityModified.Value;
        public ObjectProperty<int> DataDropItemsOnDeathRaw => _dataDropItemsOnDeathRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDropItemsOnDeathModified => _isDataDropItemsOnDeathModified.Value;
        public ObjectProperty<bool> DataDropItemsOnDeath => _dataDropItemsOnDeath.Value;
        public ObjectProperty<int> DataCanUseItemsRaw => _dataCanUseItemsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataCanUseItemsModified => _isDataCanUseItemsModified.Value;
        public ObjectProperty<bool> DataCanUseItems => _dataCanUseItems.Value;
        public ObjectProperty<int> DataCanGetItemsRaw => _dataCanGetItemsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataCanGetItemsModified => _isDataCanGetItemsModified.Value;
        public ObjectProperty<bool> DataCanGetItems => _dataCanGetItems.Value;
        public ObjectProperty<int> DataCanDropItemsRaw => _dataCanDropItemsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataCanDropItemsModified => _isDataCanDropItemsModified.Value;
        public ObjectProperty<bool> DataCanDropItems => _dataCanDropItems.Value;
        private int GetDataItemCapacity(int level)
        {
            return _modifications.GetModification(829845097, level).ValueAsInt;
        }

        private void SetDataItemCapacity(int level, int value)
        {
            _modifications[829845097, level] = new LevelObjectDataModification{Id = 829845097, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataItemCapacityModified(int level)
        {
            return _modifications.ContainsKey(829845097, level);
        }

        private int GetDataDropItemsOnDeathRaw(int level)
        {
            return _modifications.GetModification(846622313, level).ValueAsInt;
        }

        private void SetDataDropItemsOnDeathRaw(int level, int value)
        {
            _modifications[846622313, level] = new LevelObjectDataModification{Id = 846622313, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDropItemsOnDeathModified(int level)
        {
            return _modifications.ContainsKey(846622313, level);
        }

        private bool GetDataDropItemsOnDeath(int level)
        {
            return GetDataDropItemsOnDeathRaw(level).ToBool(this);
        }

        private void SetDataDropItemsOnDeath(int level, bool value)
        {
            SetDataDropItemsOnDeathRaw(level, value.ToRaw(null, null));
        }

        private int GetDataCanUseItemsRaw(int level)
        {
            return _modifications.GetModification(863399529, level).ValueAsInt;
        }

        private void SetDataCanUseItemsRaw(int level, int value)
        {
            _modifications[863399529, level] = new LevelObjectDataModification{Id = 863399529, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataCanUseItemsModified(int level)
        {
            return _modifications.ContainsKey(863399529, level);
        }

        private bool GetDataCanUseItems(int level)
        {
            return GetDataCanUseItemsRaw(level).ToBool(this);
        }

        private void SetDataCanUseItems(int level, bool value)
        {
            SetDataCanUseItemsRaw(level, value.ToRaw(null, null));
        }

        private int GetDataCanGetItemsRaw(int level)
        {
            return _modifications.GetModification(880176745, level).ValueAsInt;
        }

        private void SetDataCanGetItemsRaw(int level, int value)
        {
            _modifications[880176745, level] = new LevelObjectDataModification{Id = 880176745, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataCanGetItemsModified(int level)
        {
            return _modifications.ContainsKey(880176745, level);
        }

        private bool GetDataCanGetItems(int level)
        {
            return GetDataCanGetItemsRaw(level).ToBool(this);
        }

        private void SetDataCanGetItems(int level, bool value)
        {
            SetDataCanGetItemsRaw(level, value.ToRaw(null, null));
        }

        private int GetDataCanDropItemsRaw(int level)
        {
            return _modifications.GetModification(896953961, level).ValueAsInt;
        }

        private void SetDataCanDropItemsRaw(int level, int value)
        {
            _modifications[896953961, level] = new LevelObjectDataModification{Id = 896953961, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataCanDropItemsModified(int level)
        {
            return _modifications.ContainsKey(896953961, level);
        }

        private bool GetDataCanDropItems(int level)
        {
            return GetDataCanDropItemsRaw(level).ToBool(this);
        }

        private void SetDataCanDropItems(int level, bool value)
        {
            SetDataCanDropItemsRaw(level, value.ToRaw(null, null));
        }
    }
}