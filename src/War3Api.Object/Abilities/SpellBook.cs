using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SpellBook : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataSpellListRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Ability>>> _dataSpellList;
        private readonly Lazy<ObjectProperty<bool>> _dataSharedSpellCooldown;
        private readonly Lazy<ObjectProperty<int>> _dataMinimumSpells;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumSpells;
        private readonly Lazy<ObjectProperty<string>> _dataBaseOrderIDRaw;
        private readonly Lazy<ObjectProperty<string>> _dataBaseOrderID;
        public SpellBook(): base(1651536705)
        {
            _dataSpellListRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpellListRaw, SetDataSpellListRaw));
            _dataSpellList = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataSpellList, SetDataSpellList));
            _dataSharedSpellCooldown = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSharedSpellCooldown, SetDataSharedSpellCooldown));
            _dataMinimumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumSpells, SetDataMinimumSpells));
            _dataMaximumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumSpells, SetDataMaximumSpells));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public SpellBook(int newId): base(1651536705, newId)
        {
            _dataSpellListRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpellListRaw, SetDataSpellListRaw));
            _dataSpellList = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataSpellList, SetDataSpellList));
            _dataSharedSpellCooldown = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSharedSpellCooldown, SetDataSharedSpellCooldown));
            _dataMinimumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumSpells, SetDataMinimumSpells));
            _dataMaximumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumSpells, SetDataMaximumSpells));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public SpellBook(string newRawcode): base(1651536705, newRawcode)
        {
            _dataSpellListRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpellListRaw, SetDataSpellListRaw));
            _dataSpellList = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataSpellList, SetDataSpellList));
            _dataSharedSpellCooldown = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSharedSpellCooldown, SetDataSharedSpellCooldown));
            _dataMinimumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumSpells, SetDataMinimumSpells));
            _dataMaximumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumSpells, SetDataMaximumSpells));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public SpellBook(ObjectDatabase db): base(1651536705, db)
        {
            _dataSpellListRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpellListRaw, SetDataSpellListRaw));
            _dataSpellList = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataSpellList, SetDataSpellList));
            _dataSharedSpellCooldown = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSharedSpellCooldown, SetDataSharedSpellCooldown));
            _dataMinimumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumSpells, SetDataMinimumSpells));
            _dataMaximumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumSpells, SetDataMaximumSpells));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public SpellBook(int newId, ObjectDatabase db): base(1651536705, newId, db)
        {
            _dataSpellListRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpellListRaw, SetDataSpellListRaw));
            _dataSpellList = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataSpellList, SetDataSpellList));
            _dataSharedSpellCooldown = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSharedSpellCooldown, SetDataSharedSpellCooldown));
            _dataMinimumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumSpells, SetDataMinimumSpells));
            _dataMaximumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumSpells, SetDataMaximumSpells));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public SpellBook(string newRawcode, ObjectDatabase db): base(1651536705, newRawcode, db)
        {
            _dataSpellListRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpellListRaw, SetDataSpellListRaw));
            _dataSpellList = new Lazy<ObjectProperty<IEnumerable<Ability>>>(() => new ObjectProperty<IEnumerable<Ability>>(GetDataSpellList, SetDataSpellList));
            _dataSharedSpellCooldown = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSharedSpellCooldown, SetDataSharedSpellCooldown));
            _dataMinimumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumSpells, SetDataMinimumSpells));
            _dataMaximumSpells = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumSpells, SetDataMaximumSpells));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public ObjectProperty<string> DataSpellListRaw => _dataSpellListRaw.Value;
        public ObjectProperty<IEnumerable<Ability>> DataSpellList => _dataSpellList.Value;
        public ObjectProperty<bool> DataSharedSpellCooldown => _dataSharedSpellCooldown.Value;
        public ObjectProperty<int> DataMinimumSpells => _dataMinimumSpells.Value;
        public ObjectProperty<int> DataMaximumSpells => _dataMaximumSpells.Value;
        public ObjectProperty<string> DataBaseOrderIDRaw => _dataBaseOrderIDRaw.Value;
        public ObjectProperty<string> DataBaseOrderID => _dataBaseOrderID.Value;
        private string GetDataSpellListRaw(int level)
        {
            return _modifications[828534899, level].ValueAsString;
        }

        private void SetDataSpellListRaw(int level, string value)
        {
            _modifications[828534899, level] = new LevelObjectDataModification{Id = 828534899, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
        }

        private IEnumerable<Ability> GetDataSpellList(int level)
        {
            return GetDataSpellListRaw(level).ToIEnumerableAbility(this);
        }

        private void SetDataSpellList(int level, IEnumerable<Ability> value)
        {
            SetDataSpellListRaw(level, value.ToRaw(null, null));
        }

        private bool GetDataSharedSpellCooldown(int level)
        {
            return _modifications[845312115, level].ValueAsBool;
        }

        private void SetDataSharedSpellCooldown(int level, bool value)
        {
            _modifications[845312115, level] = new LevelObjectDataModification{Id = 845312115, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataMinimumSpells(int level)
        {
            return _modifications[862089331, level].ValueAsInt;
        }

        private void SetDataMinimumSpells(int level, int value)
        {
            _modifications[862089331, level] = new LevelObjectDataModification{Id = 862089331, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private int GetDataMaximumSpells(int level)
        {
            return _modifications[878866547, level].ValueAsInt;
        }

        private void SetDataMaximumSpells(int level, int value)
        {
            _modifications[878866547, level] = new LevelObjectDataModification{Id = 878866547, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private string GetDataBaseOrderIDRaw(int level)
        {
            return _modifications[895643763, level].ValueAsString;
        }

        private void SetDataBaseOrderIDRaw(int level, string value)
        {
            _modifications[895643763, level] = new LevelObjectDataModification{Id = 895643763, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 5};
        }

        private string GetDataBaseOrderID(int level)
        {
            return GetDataBaseOrderIDRaw(level).ToString(this);
        }

        private void SetDataBaseOrderID(int level, string value)
        {
            SetDataBaseOrderIDRaw(level, value.ToRaw(null, 32));
        }
    }
}