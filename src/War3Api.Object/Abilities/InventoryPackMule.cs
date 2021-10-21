using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class InventoryPackMule : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataItemCapacity;
        private readonly Lazy<ObjectProperty<bool>> _dataDropItemsOnDeath;
        private readonly Lazy<ObjectProperty<bool>> _dataCanUseItems;
        private readonly Lazy<ObjectProperty<bool>> _dataCanGetItems;
        private readonly Lazy<ObjectProperty<bool>> _dataCanDropItems;
        public InventoryPackMule(): base(1801547841)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public InventoryPackMule(int newId): base(1801547841, newId)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public InventoryPackMule(string newRawcode): base(1801547841, newRawcode)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public InventoryPackMule(ObjectDatabase db): base(1801547841, db)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public InventoryPackMule(int newId, ObjectDatabase db): base(1801547841, newId, db)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public InventoryPackMule(string newRawcode, ObjectDatabase db): base(1801547841, newRawcode, db)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
        }

        public ObjectProperty<int> DataItemCapacity => _dataItemCapacity.Value;
        public ObjectProperty<bool> DataDropItemsOnDeath => _dataDropItemsOnDeath.Value;
        public ObjectProperty<bool> DataCanUseItems => _dataCanUseItems.Value;
        public ObjectProperty<bool> DataCanGetItems => _dataCanGetItems.Value;
        public ObjectProperty<bool> DataCanDropItems => _dataCanDropItems.Value;
        private int GetDataItemCapacity(int level)
        {
            return _modifications[829845097, level].ValueAsInt;
        }

        private void SetDataItemCapacity(int level, int value)
        {
            _modifications[829845097, level] = new LevelObjectDataModification{Id = 829845097, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataDropItemsOnDeath(int level)
        {
            return _modifications[846622313, level].ValueAsBool;
        }

        private void SetDataDropItemsOnDeath(int level, bool value)
        {
            _modifications[846622313, level] = new LevelObjectDataModification{Id = 846622313, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetDataCanUseItems(int level)
        {
            return _modifications[863399529, level].ValueAsBool;
        }

        private void SetDataCanUseItems(int level, bool value)
        {
            _modifications[863399529, level] = new LevelObjectDataModification{Id = 863399529, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataCanGetItems(int level)
        {
            return _modifications[880176745, level].ValueAsBool;
        }

        private void SetDataCanGetItems(int level, bool value)
        {
            _modifications[880176745, level] = new LevelObjectDataModification{Id = 880176745, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataCanDropItems(int level)
        {
            return _modifications[896953961, level].ValueAsBool;
        }

        private void SetDataCanDropItems(int level, bool value)
        {
            _modifications[896953961, level] = new LevelObjectDataModification{Id = 896953961, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }
    }
}