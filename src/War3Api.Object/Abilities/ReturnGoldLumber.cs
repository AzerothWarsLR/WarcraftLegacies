using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ReturnGoldLumber : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataAcceptsGold;
        private readonly Lazy<ObjectProperty<bool>> _dataAcceptsLumber;
        public ReturnGoldLumber(): base(1818718785)
        {
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ReturnGoldLumber(int newId): base(1818718785, newId)
        {
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ReturnGoldLumber(string newRawcode): base(1818718785, newRawcode)
        {
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ReturnGoldLumber(ObjectDatabase db): base(1818718785, db)
        {
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ReturnGoldLumber(int newId, ObjectDatabase db): base(1818718785, newId, db)
        {
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ReturnGoldLumber(string newRawcode, ObjectDatabase db): base(1818718785, newRawcode, db)
        {
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ObjectProperty<bool> DataAcceptsGold => _dataAcceptsGold.Value;
        public ObjectProperty<bool> DataAcceptsLumber => _dataAcceptsLumber.Value;
        private bool GetDataAcceptsGold(int level)
        {
            return _modifications[829322322, level].ValueAsBool;
        }

        private void SetDataAcceptsGold(int level, bool value)
        {
            _modifications[829322322, level] = new LevelObjectDataModification{Id = 829322322, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataAcceptsLumber(int level)
        {
            return _modifications[846099538, level].ValueAsBool;
        }

        private void SetDataAcceptsLumber(int level, bool value)
        {
            _modifications[846099538, level] = new LevelObjectDataModification{Id = 846099538, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }
    }
}