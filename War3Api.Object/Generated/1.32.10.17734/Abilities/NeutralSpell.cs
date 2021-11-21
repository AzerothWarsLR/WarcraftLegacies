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
    public sealed class NeutralSpell : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataGoldCost;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGoldCostModified;
        private readonly Lazy<ObjectProperty<int>> _dataLumberCost;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLumberCostModified;
        private readonly Lazy<ObjectProperty<string>> _dataBaseOrderIDRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBaseOrderIDModified;
        private readonly Lazy<ObjectProperty<string>> _dataBaseOrderID;
        private readonly Lazy<ObjectProperty<int>> _dataChargeOwningPlayerRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChargeOwningPlayerModified;
        private readonly Lazy<ObjectProperty<bool>> _dataChargeOwningPlayer;
        public NeutralSpell(): base(1936605505)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
            _dataChargeOwningPlayerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataChargeOwningPlayerRaw, SetDataChargeOwningPlayerRaw));
            _isDataChargeOwningPlayerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeOwningPlayerModified));
            _dataChargeOwningPlayer = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataChargeOwningPlayer, SetDataChargeOwningPlayer));
        }

        public NeutralSpell(int newId): base(1936605505, newId)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
            _dataChargeOwningPlayerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataChargeOwningPlayerRaw, SetDataChargeOwningPlayerRaw));
            _isDataChargeOwningPlayerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeOwningPlayerModified));
            _dataChargeOwningPlayer = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataChargeOwningPlayer, SetDataChargeOwningPlayer));
        }

        public NeutralSpell(string newRawcode): base(1936605505, newRawcode)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
            _dataChargeOwningPlayerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataChargeOwningPlayerRaw, SetDataChargeOwningPlayerRaw));
            _isDataChargeOwningPlayerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeOwningPlayerModified));
            _dataChargeOwningPlayer = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataChargeOwningPlayer, SetDataChargeOwningPlayer));
        }

        public NeutralSpell(ObjectDatabaseBase db): base(1936605505, db)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
            _dataChargeOwningPlayerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataChargeOwningPlayerRaw, SetDataChargeOwningPlayerRaw));
            _isDataChargeOwningPlayerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeOwningPlayerModified));
            _dataChargeOwningPlayer = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataChargeOwningPlayer, SetDataChargeOwningPlayer));
        }

        public NeutralSpell(int newId, ObjectDatabaseBase db): base(1936605505, newId, db)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
            _dataChargeOwningPlayerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataChargeOwningPlayerRaw, SetDataChargeOwningPlayerRaw));
            _isDataChargeOwningPlayerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeOwningPlayerModified));
            _dataChargeOwningPlayer = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataChargeOwningPlayer, SetDataChargeOwningPlayer));
        }

        public NeutralSpell(string newRawcode, ObjectDatabaseBase db): base(1936605505, newRawcode, db)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
            _dataChargeOwningPlayerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataChargeOwningPlayerRaw, SetDataChargeOwningPlayerRaw));
            _isDataChargeOwningPlayerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChargeOwningPlayerModified));
            _dataChargeOwningPlayer = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataChargeOwningPlayer, SetDataChargeOwningPlayer));
        }

        public ObjectProperty<int> DataGoldCost => _dataGoldCost.Value;
        public ReadOnlyObjectProperty<bool> IsDataGoldCostModified => _isDataGoldCostModified.Value;
        public ObjectProperty<int> DataLumberCost => _dataLumberCost.Value;
        public ReadOnlyObjectProperty<bool> IsDataLumberCostModified => _isDataLumberCostModified.Value;
        public ObjectProperty<string> DataBaseOrderIDRaw => _dataBaseOrderIDRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataBaseOrderIDModified => _isDataBaseOrderIDModified.Value;
        public ObjectProperty<string> DataBaseOrderID => _dataBaseOrderID.Value;
        public ObjectProperty<int> DataChargeOwningPlayerRaw => _dataChargeOwningPlayerRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataChargeOwningPlayerModified => _isDataChargeOwningPlayerModified.Value;
        public ObjectProperty<bool> DataChargeOwningPlayer => _dataChargeOwningPlayer.Value;
        private int GetDataGoldCost(int level)
        {
            return _modifications.GetModification(829711438, level).ValueAsInt;
        }

        private void SetDataGoldCost(int level, int value)
        {
            _modifications[829711438, level] = new LevelObjectDataModification{Id = 829711438, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataGoldCostModified(int level)
        {
            return _modifications.ContainsKey(829711438, level);
        }

        private int GetDataLumberCost(int level)
        {
            return _modifications.GetModification(846488654, level).ValueAsInt;
        }

        private void SetDataLumberCost(int level, int value)
        {
            _modifications[846488654, level] = new LevelObjectDataModification{Id = 846488654, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLumberCostModified(int level)
        {
            return _modifications.ContainsKey(846488654, level);
        }

        private string GetDataBaseOrderIDRaw(int level)
        {
            return _modifications.GetModification(896757313, level).ValueAsString;
        }

        private void SetDataBaseOrderIDRaw(int level, string value)
        {
            _modifications[896757313, level] = new LevelObjectDataModification{Id = 896757313, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataBaseOrderIDModified(int level)
        {
            return _modifications.ContainsKey(896757313, level);
        }

        private string GetDataBaseOrderID(int level)
        {
            return GetDataBaseOrderIDRaw(level).ToString(this);
        }

        private void SetDataBaseOrderID(int level, string value)
        {
            SetDataBaseOrderIDRaw(level, value.ToRaw(null, 32));
        }

        private int GetDataChargeOwningPlayerRaw(int level)
        {
            return _modifications.GetModification(913534529, level).ValueAsInt;
        }

        private void SetDataChargeOwningPlayerRaw(int level, int value)
        {
            _modifications[913534529, level] = new LevelObjectDataModification{Id = 913534529, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataChargeOwningPlayerModified(int level)
        {
            return _modifications.ContainsKey(913534529, level);
        }

        private bool GetDataChargeOwningPlayer(int level)
        {
            return GetDataChargeOwningPlayerRaw(level).ToBool(this);
        }

        private void SetDataChargeOwningPlayer(int level, bool value)
        {
            SetDataChargeOwningPlayerRaw(level, value.ToRaw(0, 1));
        }
    }
}