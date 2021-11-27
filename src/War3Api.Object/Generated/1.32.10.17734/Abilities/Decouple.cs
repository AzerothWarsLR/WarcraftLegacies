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
    public sealed class Decouple : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataPartnerUnitTypeOneRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPartnerUnitTypeOneModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataPartnerUnitTypeOne;
        private readonly Lazy<ObjectProperty<string>> _dataPartnerUnitTypeTwoRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPartnerUnitTypeTwoModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataPartnerUnitTypeTwo;
        public Decouple(): base(1667589185)
        {
            _dataPartnerUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeOneRaw, SetDataPartnerUnitTypeOneRaw));
            _isDataPartnerUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeOneModified));
            _dataPartnerUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeOne, SetDataPartnerUnitTypeOne));
            _dataPartnerUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeTwoRaw, SetDataPartnerUnitTypeTwoRaw));
            _isDataPartnerUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeTwoModified));
            _dataPartnerUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeTwo, SetDataPartnerUnitTypeTwo));
        }

        public Decouple(int newId): base(1667589185, newId)
        {
            _dataPartnerUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeOneRaw, SetDataPartnerUnitTypeOneRaw));
            _isDataPartnerUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeOneModified));
            _dataPartnerUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeOne, SetDataPartnerUnitTypeOne));
            _dataPartnerUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeTwoRaw, SetDataPartnerUnitTypeTwoRaw));
            _isDataPartnerUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeTwoModified));
            _dataPartnerUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeTwo, SetDataPartnerUnitTypeTwo));
        }

        public Decouple(string newRawcode): base(1667589185, newRawcode)
        {
            _dataPartnerUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeOneRaw, SetDataPartnerUnitTypeOneRaw));
            _isDataPartnerUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeOneModified));
            _dataPartnerUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeOne, SetDataPartnerUnitTypeOne));
            _dataPartnerUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeTwoRaw, SetDataPartnerUnitTypeTwoRaw));
            _isDataPartnerUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeTwoModified));
            _dataPartnerUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeTwo, SetDataPartnerUnitTypeTwo));
        }

        public Decouple(ObjectDatabaseBase db): base(1667589185, db)
        {
            _dataPartnerUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeOneRaw, SetDataPartnerUnitTypeOneRaw));
            _isDataPartnerUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeOneModified));
            _dataPartnerUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeOne, SetDataPartnerUnitTypeOne));
            _dataPartnerUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeTwoRaw, SetDataPartnerUnitTypeTwoRaw));
            _isDataPartnerUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeTwoModified));
            _dataPartnerUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeTwo, SetDataPartnerUnitTypeTwo));
        }

        public Decouple(int newId, ObjectDatabaseBase db): base(1667589185, newId, db)
        {
            _dataPartnerUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeOneRaw, SetDataPartnerUnitTypeOneRaw));
            _isDataPartnerUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeOneModified));
            _dataPartnerUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeOne, SetDataPartnerUnitTypeOne));
            _dataPartnerUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeTwoRaw, SetDataPartnerUnitTypeTwoRaw));
            _isDataPartnerUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeTwoModified));
            _dataPartnerUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeTwo, SetDataPartnerUnitTypeTwo));
        }

        public Decouple(string newRawcode, ObjectDatabaseBase db): base(1667589185, newRawcode, db)
        {
            _dataPartnerUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeOneRaw, SetDataPartnerUnitTypeOneRaw));
            _isDataPartnerUnitTypeOneModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeOneModified));
            _dataPartnerUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeOne, SetDataPartnerUnitTypeOne));
            _dataPartnerUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeTwoRaw, SetDataPartnerUnitTypeTwoRaw));
            _isDataPartnerUnitTypeTwoModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeTwoModified));
            _dataPartnerUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitTypeTwo, SetDataPartnerUnitTypeTwo));
        }

        public ObjectProperty<string> DataPartnerUnitTypeOneRaw => _dataPartnerUnitTypeOneRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPartnerUnitTypeOneModified => _isDataPartnerUnitTypeOneModified.Value;
        public ObjectProperty<Unit> DataPartnerUnitTypeOne => _dataPartnerUnitTypeOne.Value;
        public ObjectProperty<string> DataPartnerUnitTypeTwoRaw => _dataPartnerUnitTypeTwoRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPartnerUnitTypeTwoModified => _isDataPartnerUnitTypeTwoModified.Value;
        public ObjectProperty<Unit> DataPartnerUnitTypeTwo => _dataPartnerUnitTypeTwo.Value;
        private string GetDataPartnerUnitTypeOneRaw(int level)
        {
            return _modifications.GetModification(829449060, level).ValueAsString;
        }

        private void SetDataPartnerUnitTypeOneRaw(int level, string value)
        {
            _modifications[829449060, level] = new LevelObjectDataModification{Id = 829449060, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataPartnerUnitTypeOneModified(int level)
        {
            return _modifications.ContainsKey(829449060, level);
        }

        private Unit GetDataPartnerUnitTypeOne(int level)
        {
            return GetDataPartnerUnitTypeOneRaw(level).ToUnit(this);
        }

        private void SetDataPartnerUnitTypeOne(int level, Unit value)
        {
            SetDataPartnerUnitTypeOneRaw(level, value.ToRaw(null, null));
        }

        private string GetDataPartnerUnitTypeTwoRaw(int level)
        {
            return _modifications.GetModification(846226276, level).ValueAsString;
        }

        private void SetDataPartnerUnitTypeTwoRaw(int level, string value)
        {
            _modifications[846226276, level] = new LevelObjectDataModification{Id = 846226276, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataPartnerUnitTypeTwoModified(int level)
        {
            return _modifications.ContainsKey(846226276, level);
        }

        private Unit GetDataPartnerUnitTypeTwo(int level)
        {
            return GetDataPartnerUnitTypeTwoRaw(level).ToUnit(this);
        }

        private void SetDataPartnerUnitTypeTwo(int level, Unit value)
        {
            SetDataPartnerUnitTypeTwoRaw(level, value.ToRaw(null, null));
        }
    }
}