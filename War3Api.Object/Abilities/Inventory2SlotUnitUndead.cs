using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Inventory2SlotUnitUndead : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataItemCapacity;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataItemCapacityModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDropItemsOnDeath;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDropItemsOnDeathModified;
        private readonly Lazy<ObjectProperty<bool>> _dataCanUseItems;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCanUseItemsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataCanGetItems;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCanGetItemsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataCanDropItems;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCanDropItemsModified;
        public Inventory2SlotUnitUndead(): base(1853188417)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
        }

        public Inventory2SlotUnitUndead(int newId): base(1853188417, newId)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
        }

        public Inventory2SlotUnitUndead(string newRawcode): base(1853188417, newRawcode)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
        }

        public Inventory2SlotUnitUndead(ObjectDatabase db): base(1853188417, db)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
        }

        public Inventory2SlotUnitUndead(int newId, ObjectDatabase db): base(1853188417, newId, db)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
        }

        public Inventory2SlotUnitUndead(string newRawcode, ObjectDatabase db): base(1853188417, newRawcode, db)
        {
            _dataItemCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataItemCapacity, SetDataItemCapacity));
            _isDataItemCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataItemCapacityModified));
            _dataDropItemsOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDropItemsOnDeath, SetDataDropItemsOnDeath));
            _isDataDropItemsOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDropItemsOnDeathModified));
            _dataCanUseItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanUseItems, SetDataCanUseItems));
            _isDataCanUseItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanUseItemsModified));
            _dataCanGetItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanGetItems, SetDataCanGetItems));
            _isDataCanGetItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanGetItemsModified));
            _dataCanDropItems = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanDropItems, SetDataCanDropItems));
            _isDataCanDropItemsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanDropItemsModified));
        }

        public ObjectProperty<int> DataItemCapacity => _dataItemCapacity.Value;
        public ReadOnlyObjectProperty<bool> IsDataItemCapacityModified => _isDataItemCapacityModified.Value;
        public ObjectProperty<bool> DataDropItemsOnDeath => _dataDropItemsOnDeath.Value;
        public ReadOnlyObjectProperty<bool> IsDataDropItemsOnDeathModified => _isDataDropItemsOnDeathModified.Value;
        public ObjectProperty<bool> DataCanUseItems => _dataCanUseItems.Value;
        public ReadOnlyObjectProperty<bool> IsDataCanUseItemsModified => _isDataCanUseItemsModified.Value;
        public ObjectProperty<bool> DataCanGetItems => _dataCanGetItems.Value;
        public ReadOnlyObjectProperty<bool> IsDataCanGetItemsModified => _isDataCanGetItemsModified.Value;
        public ObjectProperty<bool> DataCanDropItems => _dataCanDropItems.Value;
        public ReadOnlyObjectProperty<bool> IsDataCanDropItemsModified => _isDataCanDropItemsModified.Value;
        private int GetDataItemCapacity(int level)
        {
            return _modifications[829845097, level].ValueAsInt;
        }

        private void SetDataItemCapacity(int level, int value)
        {
            _modifications[829845097, level] = new LevelObjectDataModification{Id = 829845097, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataItemCapacityModified(int level)
        {
            return _modifications.ContainsKey(829845097, level);
        }

        private bool GetDataDropItemsOnDeath(int level)
        {
            return _modifications[846622313, level].ValueAsBool;
        }

        private void SetDataDropItemsOnDeath(int level, bool value)
        {
            _modifications[846622313, level] = new LevelObjectDataModification{Id = 846622313, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDropItemsOnDeathModified(int level)
        {
            return _modifications.ContainsKey(846622313, level);
        }

        private bool GetDataCanUseItems(int level)
        {
            return _modifications[863399529, level].ValueAsBool;
        }

        private void SetDataCanUseItems(int level, bool value)
        {
            _modifications[863399529, level] = new LevelObjectDataModification{Id = 863399529, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataCanUseItemsModified(int level)
        {
            return _modifications.ContainsKey(863399529, level);
        }

        private bool GetDataCanGetItems(int level)
        {
            return _modifications[880176745, level].ValueAsBool;
        }

        private void SetDataCanGetItems(int level, bool value)
        {
            _modifications[880176745, level] = new LevelObjectDataModification{Id = 880176745, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataCanGetItemsModified(int level)
        {
            return _modifications.ContainsKey(880176745, level);
        }

        private bool GetDataCanDropItems(int level)
        {
            return _modifications[896953961, level].ValueAsBool;
        }

        private void SetDataCanDropItems(int level, bool value)
        {
            _modifications[896953961, level] = new LevelObjectDataModification{Id = 896953961, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataCanDropItemsModified(int level)
        {
            return _modifications.ContainsKey(896953961, level);
        }
    }
}