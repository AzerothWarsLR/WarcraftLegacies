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
    public sealed class CryptLordCarrionScarabs : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataUnitsSummonedTypeOne;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitsSummonedTypeOneModified;
        private readonly Lazy<ObjectProperty<int>> _dataUnitsSummonedTypeTwo;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitsSummonedTypeTwoModified;
        private readonly Lazy<ObjectProperty<string>> _dataUnitTypeOneRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitTypeOneModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataUnitTypeOne;
        private readonly Lazy<ObjectProperty<string>> _dataUnitTypeTwoRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitTypeTwoModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataUnitTypeTwo;
        private readonly Lazy<ObjectProperty<int>> _dataMaxUnitsSummoned;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxUnitsSummonedModified;
        private readonly Lazy<ObjectProperty<int>> _dataKillOnCasterDeathRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataKillOnCasterDeathModified;
        private readonly Lazy<ObjectProperty<bool>> _dataKillOnCasterDeath;
        public CryptLordCarrionScarabs(): base(1650677057)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _isDataUnitsSummonedTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeOneModified));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _isDataUnitsSummonedTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeTwoModified));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _isDataUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeOneModified));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _isDataUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeTwoModified));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _isDataMaxUnitsSummonedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsSummonedModified));
            _dataKillOnCasterDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataKillOnCasterDeathRaw, SetDataKillOnCasterDeathRaw));
            _isDataKillOnCasterDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataKillOnCasterDeathModified));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public CryptLordCarrionScarabs(int newId): base(1650677057, newId)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _isDataUnitsSummonedTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeOneModified));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _isDataUnitsSummonedTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeTwoModified));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _isDataUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeOneModified));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _isDataUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeTwoModified));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _isDataMaxUnitsSummonedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsSummonedModified));
            _dataKillOnCasterDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataKillOnCasterDeathRaw, SetDataKillOnCasterDeathRaw));
            _isDataKillOnCasterDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataKillOnCasterDeathModified));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public CryptLordCarrionScarabs(string newRawcode): base(1650677057, newRawcode)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _isDataUnitsSummonedTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeOneModified));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _isDataUnitsSummonedTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeTwoModified));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _isDataUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeOneModified));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _isDataUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeTwoModified));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _isDataMaxUnitsSummonedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsSummonedModified));
            _dataKillOnCasterDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataKillOnCasterDeathRaw, SetDataKillOnCasterDeathRaw));
            _isDataKillOnCasterDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataKillOnCasterDeathModified));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public CryptLordCarrionScarabs(ObjectDatabaseBase db): base(1650677057, db)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _isDataUnitsSummonedTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeOneModified));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _isDataUnitsSummonedTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeTwoModified));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _isDataUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeOneModified));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _isDataUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeTwoModified));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _isDataMaxUnitsSummonedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsSummonedModified));
            _dataKillOnCasterDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataKillOnCasterDeathRaw, SetDataKillOnCasterDeathRaw));
            _isDataKillOnCasterDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataKillOnCasterDeathModified));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public CryptLordCarrionScarabs(int newId, ObjectDatabaseBase db): base(1650677057, newId, db)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _isDataUnitsSummonedTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeOneModified));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _isDataUnitsSummonedTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeTwoModified));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _isDataUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeOneModified));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _isDataUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeTwoModified));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _isDataMaxUnitsSummonedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsSummonedModified));
            _dataKillOnCasterDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataKillOnCasterDeathRaw, SetDataKillOnCasterDeathRaw));
            _isDataKillOnCasterDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataKillOnCasterDeathModified));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public CryptLordCarrionScarabs(string newRawcode, ObjectDatabaseBase db): base(1650677057, newRawcode, db)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _isDataUnitsSummonedTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeOneModified));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _isDataUnitsSummonedTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitsSummonedTypeTwoModified));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _isDataUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeOneModified));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _isDataUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeTwoModified));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _isDataMaxUnitsSummonedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxUnitsSummonedModified));
            _dataKillOnCasterDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataKillOnCasterDeathRaw, SetDataKillOnCasterDeathRaw));
            _isDataKillOnCasterDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataKillOnCasterDeathModified));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public ObjectProperty<int> DataUnitsSummonedTypeOne => _dataUnitsSummonedTypeOne.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitsSummonedTypeOneModified => _isDataUnitsSummonedTypeOneModified.Value;
        public ObjectProperty<int> DataUnitsSummonedTypeTwo => _dataUnitsSummonedTypeTwo.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitsSummonedTypeTwoModified => _isDataUnitsSummonedTypeTwoModified.Value;
        public ObjectProperty<string> DataUnitTypeOneRaw => _dataUnitTypeOneRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitTypeOneModified => _isDataUnitTypeOneModified.Value;
        public ObjectProperty<Unit> DataUnitTypeOne => _dataUnitTypeOne.Value;
        public ObjectProperty<string> DataUnitTypeTwoRaw => _dataUnitTypeTwoRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitTypeTwoModified => _isDataUnitTypeTwoModified.Value;
        public ObjectProperty<Unit> DataUnitTypeTwo => _dataUnitTypeTwo.Value;
        public ObjectProperty<int> DataMaxUnitsSummoned => _dataMaxUnitsSummoned.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxUnitsSummonedModified => _isDataMaxUnitsSummonedModified.Value;
        public ObjectProperty<int> DataKillOnCasterDeathRaw => _dataKillOnCasterDeathRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataKillOnCasterDeathModified => _isDataKillOnCasterDeathModified.Value;
        public ObjectProperty<bool> DataKillOnCasterDeath => _dataKillOnCasterDeath.Value;
        private int GetDataUnitsSummonedTypeOne(int level)
        {
            return _modifications.GetModification(828989778, level).ValueAsInt;
        }

        private void SetDataUnitsSummonedTypeOne(int level, int value)
        {
            _modifications[828989778, level] = new LevelObjectDataModification{Id = 828989778, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataUnitsSummonedTypeOneModified(int level)
        {
            return _modifications.ContainsKey(828989778, level);
        }

        private int GetDataUnitsSummonedTypeTwo(int level)
        {
            return _modifications.GetModification(845766994, level).ValueAsInt;
        }

        private void SetDataUnitsSummonedTypeTwo(int level, int value)
        {
            _modifications[845766994, level] = new LevelObjectDataModification{Id = 845766994, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataUnitsSummonedTypeTwoModified(int level)
        {
            return _modifications.ContainsKey(845766994, level);
        }

        private string GetDataUnitTypeOneRaw(int level)
        {
            return _modifications.GetModification(862544210, level).ValueAsString;
        }

        private void SetDataUnitTypeOneRaw(int level, string value)
        {
            _modifications[862544210, level] = new LevelObjectDataModification{Id = 862544210, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataUnitTypeOneModified(int level)
        {
            return _modifications.ContainsKey(862544210, level);
        }

        private Unit GetDataUnitTypeOne(int level)
        {
            return GetDataUnitTypeOneRaw(level).ToUnit(this);
        }

        private void SetDataUnitTypeOne(int level, Unit value)
        {
            SetDataUnitTypeOneRaw(level, value.ToRaw(null, null));
        }

        private string GetDataUnitTypeTwoRaw(int level)
        {
            return _modifications.GetModification(879321426, level).ValueAsString;
        }

        private void SetDataUnitTypeTwoRaw(int level, string value)
        {
            _modifications[879321426, level] = new LevelObjectDataModification{Id = 879321426, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataUnitTypeTwoModified(int level)
        {
            return _modifications.ContainsKey(879321426, level);
        }

        private Unit GetDataUnitTypeTwo(int level)
        {
            return GetDataUnitTypeTwoRaw(level).ToUnit(this);
        }

        private void SetDataUnitTypeTwo(int level, Unit value)
        {
            SetDataUnitTypeTwoRaw(level, value.ToRaw(null, null));
        }

        private int GetDataMaxUnitsSummoned(int level)
        {
            return _modifications.GetModification(895640405, level).ValueAsInt;
        }

        private void SetDataMaxUnitsSummoned(int level, int value)
        {
            _modifications[895640405, level] = new LevelObjectDataModification{Id = 895640405, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataMaxUnitsSummonedModified(int level)
        {
            return _modifications.ContainsKey(895640405, level);
        }

        private int GetDataKillOnCasterDeathRaw(int level)
        {
            return _modifications.GetModification(912417621, level).ValueAsInt;
        }

        private void SetDataKillOnCasterDeathRaw(int level, int value)
        {
            _modifications[912417621, level] = new LevelObjectDataModification{Id = 912417621, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataKillOnCasterDeathModified(int level)
        {
            return _modifications.ContainsKey(912417621, level);
        }

        private bool GetDataKillOnCasterDeath(int level)
        {
            return GetDataKillOnCasterDeathRaw(level).ToBool(this);
        }

        private void SetDataKillOnCasterDeath(int level, bool value)
        {
            SetDataKillOnCasterDeathRaw(level, value.ToRaw(0, 1));
        }
    }
}