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
    public sealed class RaiseDeadCreep : Ability
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
        private readonly Lazy<ObjectProperty<string>> _dataUnitTypeForLimitCheckRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitTypeForLimitCheckModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataUnitTypeForLimitCheck;
        public RaiseDeadCreep(): base(1685209921)
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
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _isDataUnitTypeForLimitCheckModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeForLimitCheckModified));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
        }

        public RaiseDeadCreep(int newId): base(1685209921, newId)
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
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _isDataUnitTypeForLimitCheckModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeForLimitCheckModified));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
        }

        public RaiseDeadCreep(string newRawcode): base(1685209921, newRawcode)
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
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _isDataUnitTypeForLimitCheckModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeForLimitCheckModified));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
        }

        public RaiseDeadCreep(ObjectDatabaseBase db): base(1685209921, db)
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
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _isDataUnitTypeForLimitCheckModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeForLimitCheckModified));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
        }

        public RaiseDeadCreep(int newId, ObjectDatabaseBase db): base(1685209921, newId, db)
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
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _isDataUnitTypeForLimitCheckModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeForLimitCheckModified));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
        }

        public RaiseDeadCreep(string newRawcode, ObjectDatabaseBase db): base(1685209921, newRawcode, db)
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
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _isDataUnitTypeForLimitCheckModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitTypeForLimitCheckModified));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
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
        public ObjectProperty<string> DataUnitTypeForLimitCheckRaw => _dataUnitTypeForLimitCheckRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitTypeForLimitCheckModified => _isDataUnitTypeForLimitCheckModified.Value;
        public ObjectProperty<Unit> DataUnitTypeForLimitCheck => _dataUnitTypeForLimitCheck.Value;
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

        private string GetDataUnitTypeForLimitCheckRaw(int level)
        {
            return _modifications.GetModification(1969840466, level).ValueAsString;
        }

        private void SetDataUnitTypeForLimitCheckRaw(int level, string value)
        {
            _modifications[1969840466, level] = new LevelObjectDataModification{Id = 1969840466, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataUnitTypeForLimitCheckModified(int level)
        {
            return _modifications.ContainsKey(1969840466, level);
        }

        private Unit GetDataUnitTypeForLimitCheck(int level)
        {
            return GetDataUnitTypeForLimitCheckRaw(level).ToUnit(this);
        }

        private void SetDataUnitTypeForLimitCheck(int level, Unit value)
        {
            SetDataUnitTypeForLimitCheckRaw(level, value.ToRaw(null, null));
        }
    }
}