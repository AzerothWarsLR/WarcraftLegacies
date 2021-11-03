using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Cyclone_Acyc : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataCanBeDispelled;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCanBeDispelledModified;
        public Cyclone_Acyc(): base(1668899649)
        {
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
        }

        public Cyclone_Acyc(int newId): base(1668899649, newId)
        {
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
        }

        public Cyclone_Acyc(string newRawcode): base(1668899649, newRawcode)
        {
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
        }

        public Cyclone_Acyc(ObjectDatabase db): base(1668899649, db)
        {
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
        }

        public Cyclone_Acyc(int newId, ObjectDatabase db): base(1668899649, newId, db)
        {
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
        }

        public Cyclone_Acyc(string newRawcode, ObjectDatabase db): base(1668899649, newRawcode, db)
        {
            _dataCanBeDispelled = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCanBeDispelled, SetDataCanBeDispelled));
            _isDataCanBeDispelledModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCanBeDispelledModified));
        }

        public ObjectProperty<bool> DataCanBeDispelled => _dataCanBeDispelled.Value;
        public ReadOnlyObjectProperty<bool> IsDataCanBeDispelledModified => _isDataCanBeDispelledModified.Value;
        private bool GetDataCanBeDispelled(int level)
        {
            return _modifications[828602723, level].ValueAsBool;
        }

        private void SetDataCanBeDispelled(int level, bool value)
        {
            _modifications[828602723, level] = new LevelObjectDataModification{Id = 828602723, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataCanBeDispelledModified(int level)
        {
            return _modifications.ContainsKey(828602723, level);
        }
    }
}