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
    public sealed class FigurineIceRevenant : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataSummon1Amount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummon1AmountModified;
        private readonly Lazy<ObjectProperty<string>> _dataSummon1UnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummon1UnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataSummon1UnitType;
        private readonly Lazy<ObjectProperty<int>> _dataSummon2Amount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummon2AmountModified;
        private readonly Lazy<ObjectProperty<string>> _dataSummon2UnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummon2UnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataSummon2UnitType;
        public FigurineIceRevenant(): base(1919502657)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _isDataSummon1AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1AmountModified));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _isDataSummon1UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1UnitTypeModified));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _isDataSummon2AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2AmountModified));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _isDataSummon2UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2UnitTypeModified));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public FigurineIceRevenant(int newId): base(1919502657, newId)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _isDataSummon1AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1AmountModified));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _isDataSummon1UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1UnitTypeModified));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _isDataSummon2AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2AmountModified));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _isDataSummon2UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2UnitTypeModified));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public FigurineIceRevenant(string newRawcode): base(1919502657, newRawcode)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _isDataSummon1AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1AmountModified));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _isDataSummon1UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1UnitTypeModified));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _isDataSummon2AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2AmountModified));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _isDataSummon2UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2UnitTypeModified));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public FigurineIceRevenant(ObjectDatabaseBase db): base(1919502657, db)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _isDataSummon1AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1AmountModified));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _isDataSummon1UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1UnitTypeModified));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _isDataSummon2AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2AmountModified));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _isDataSummon2UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2UnitTypeModified));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public FigurineIceRevenant(int newId, ObjectDatabaseBase db): base(1919502657, newId, db)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _isDataSummon1AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1AmountModified));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _isDataSummon1UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1UnitTypeModified));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _isDataSummon2AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2AmountModified));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _isDataSummon2UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2UnitTypeModified));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public FigurineIceRevenant(string newRawcode, ObjectDatabaseBase db): base(1919502657, newRawcode, db)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _isDataSummon1AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1AmountModified));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _isDataSummon1UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon1UnitTypeModified));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _isDataSummon2AmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2AmountModified));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _isDataSummon2UnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummon2UnitTypeModified));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public ObjectProperty<int> DataSummon1Amount => _dataSummon1Amount.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummon1AmountModified => _isDataSummon1AmountModified.Value;
        public ObjectProperty<string> DataSummon1UnitTypeRaw => _dataSummon1UnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummon1UnitTypeModified => _isDataSummon1UnitTypeModified.Value;
        public ObjectProperty<Unit> DataSummon1UnitType => _dataSummon1UnitType.Value;
        public ObjectProperty<int> DataSummon2Amount => _dataSummon2Amount.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummon2AmountModified => _isDataSummon2AmountModified.Value;
        public ObjectProperty<string> DataSummon2UnitTypeRaw => _dataSummon2UnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummon2UnitTypeModified => _isDataSummon2UnitTypeModified.Value;
        public ObjectProperty<Unit> DataSummon2UnitType => _dataSummon2UnitType.Value;
        private int GetDataSummon1Amount(int level)
        {
            return _modifications.GetModification(829322057, level).ValueAsInt;
        }

        private void SetDataSummon1Amount(int level, int value)
        {
            _modifications[829322057, level] = new LevelObjectDataModification{Id = 829322057, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataSummon1AmountModified(int level)
        {
            return _modifications.ContainsKey(829322057, level);
        }

        private string GetDataSummon1UnitTypeRaw(int level)
        {
            return _modifications.GetModification(829715273, level).ValueAsString;
        }

        private void SetDataSummon1UnitTypeRaw(int level, string value)
        {
            _modifications[829715273, level] = new LevelObjectDataModification{Id = 829715273, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataSummon1UnitTypeModified(int level)
        {
            return _modifications.ContainsKey(829715273, level);
        }

        private Unit GetDataSummon1UnitType(int level)
        {
            return GetDataSummon1UnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataSummon1UnitType(int level, Unit value)
        {
            SetDataSummon1UnitTypeRaw(level, value.ToRaw(null, null));
        }

        private int GetDataSummon2Amount(int level)
        {
            return _modifications.GetModification(846099273, level).ValueAsInt;
        }

        private void SetDataSummon2Amount(int level, int value)
        {
            _modifications[846099273, level] = new LevelObjectDataModification{Id = 846099273, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataSummon2AmountModified(int level)
        {
            return _modifications.ContainsKey(846099273, level);
        }

        private string GetDataSummon2UnitTypeRaw(int level)
        {
            return _modifications.GetModification(846492489, level).ValueAsString;
        }

        private void SetDataSummon2UnitTypeRaw(int level, string value)
        {
            _modifications[846492489, level] = new LevelObjectDataModification{Id = 846492489, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataSummon2UnitTypeModified(int level)
        {
            return _modifications.ContainsKey(846492489, level);
        }

        private Unit GetDataSummon2UnitType(int level)
        {
            return GetDataSummon2UnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataSummon2UnitType(int level, Unit value)
        {
            SetDataSummon2UnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}