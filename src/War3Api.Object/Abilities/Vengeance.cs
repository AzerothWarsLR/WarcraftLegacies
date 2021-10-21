using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Vengeance : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataUnitsSummonedTypeOne;
        private readonly Lazy<ObjectProperty<int>> _dataUnitsSummonedTypeTwo;
        private readonly Lazy<ObjectProperty<string>> _dataUnitTypeOneRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataUnitTypeOne;
        private readonly Lazy<ObjectProperty<string>> _dataUnitTypeTwoRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataUnitTypeTwo;
        private readonly Lazy<ObjectProperty<string>> _dataUnitTypeForLimitCheckRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataUnitTypeForLimitCheck;
        private readonly Lazy<ObjectProperty<int>> _dataMaxUnitsSummoned;
        private readonly Lazy<ObjectProperty<bool>> _dataKillOnCasterDeath;
        public Vengeance(): base(1735292481)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public Vengeance(int newId): base(1735292481, newId)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public Vengeance(string newRawcode): base(1735292481, newRawcode)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public Vengeance(ObjectDatabase db): base(1735292481, db)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public Vengeance(int newId, ObjectDatabase db): base(1735292481, newId, db)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public Vengeance(string newRawcode, ObjectDatabase db): base(1735292481, newRawcode, db)
        {
            _dataUnitsSummonedTypeOne = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeOne, SetDataUnitsSummonedTypeOne));
            _dataUnitsSummonedTypeTwo = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUnitsSummonedTypeTwo, SetDataUnitsSummonedTypeTwo));
            _dataUnitTypeOneRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeOneRaw, SetDataUnitTypeOneRaw));
            _dataUnitTypeOne = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeOne, SetDataUnitTypeOne));
            _dataUnitTypeTwoRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeTwoRaw, SetDataUnitTypeTwoRaw));
            _dataUnitTypeTwo = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeTwo, SetDataUnitTypeTwo));
            _dataUnitTypeForLimitCheckRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeForLimitCheckRaw, SetDataUnitTypeForLimitCheckRaw));
            _dataUnitTypeForLimitCheck = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitTypeForLimitCheck, SetDataUnitTypeForLimitCheck));
            _dataMaxUnitsSummoned = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnitsSummoned, SetDataMaxUnitsSummoned));
            _dataKillOnCasterDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataKillOnCasterDeath, SetDataKillOnCasterDeath));
        }

        public ObjectProperty<int> DataUnitsSummonedTypeOne => _dataUnitsSummonedTypeOne.Value;
        public ObjectProperty<int> DataUnitsSummonedTypeTwo => _dataUnitsSummonedTypeTwo.Value;
        public ObjectProperty<string> DataUnitTypeOneRaw => _dataUnitTypeOneRaw.Value;
        public ObjectProperty<Unit> DataUnitTypeOne => _dataUnitTypeOne.Value;
        public ObjectProperty<string> DataUnitTypeTwoRaw => _dataUnitTypeTwoRaw.Value;
        public ObjectProperty<Unit> DataUnitTypeTwo => _dataUnitTypeTwo.Value;
        public ObjectProperty<string> DataUnitTypeForLimitCheckRaw => _dataUnitTypeForLimitCheckRaw.Value;
        public ObjectProperty<Unit> DataUnitTypeForLimitCheck => _dataUnitTypeForLimitCheck.Value;
        public ObjectProperty<int> DataMaxUnitsSummoned => _dataMaxUnitsSummoned.Value;
        public ObjectProperty<bool> DataKillOnCasterDeath => _dataKillOnCasterDeath.Value;
        private int GetDataUnitsSummonedTypeOne(int level)
        {
            return _modifications[828989778, level].ValueAsInt;
        }

        private void SetDataUnitsSummonedTypeOne(int level, int value)
        {
            _modifications[828989778, level] = new LevelObjectDataModification{Id = 828989778, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataUnitsSummonedTypeTwo(int level)
        {
            return _modifications[845766994, level].ValueAsInt;
        }

        private void SetDataUnitsSummonedTypeTwo(int level, int value)
        {
            _modifications[845766994, level] = new LevelObjectDataModification{Id = 845766994, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private string GetDataUnitTypeOneRaw(int level)
        {
            return _modifications[862544210, level].ValueAsString;
        }

        private void SetDataUnitTypeOneRaw(int level, string value)
        {
            _modifications[862544210, level] = new LevelObjectDataModification{Id = 862544210, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 3};
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
            return _modifications[879321426, level].ValueAsString;
        }

        private void SetDataUnitTypeTwoRaw(int level, string value)
        {
            _modifications[879321426, level] = new LevelObjectDataModification{Id = 879321426, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 4};
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
            return _modifications[1969840466, level].ValueAsString;
        }

        private void SetDataUnitTypeForLimitCheckRaw(int level, string value)
        {
            _modifications[1969840466, level] = new LevelObjectDataModification{Id = 1969840466, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private Unit GetDataUnitTypeForLimitCheck(int level)
        {
            return GetDataUnitTypeForLimitCheckRaw(level).ToUnit(this);
        }

        private void SetDataUnitTypeForLimitCheck(int level, Unit value)
        {
            SetDataUnitTypeForLimitCheckRaw(level, value.ToRaw(null, null));
        }

        private int GetDataMaxUnitsSummoned(int level)
        {
            return _modifications[895640405, level].ValueAsInt;
        }

        private void SetDataMaxUnitsSummoned(int level, int value)
        {
            _modifications[895640405, level] = new LevelObjectDataModification{Id = 895640405, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetDataKillOnCasterDeath(int level)
        {
            return _modifications[912417621, level].ValueAsBool;
        }

        private void SetDataKillOnCasterDeath(int level, bool value)
        {
            _modifications[912417621, level] = new LevelObjectDataModification{Id = 912417621, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 6};
        }
    }
}