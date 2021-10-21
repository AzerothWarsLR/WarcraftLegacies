using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FaerieFire_Afae : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDefenseReduction;
        private readonly Lazy<ObjectProperty<bool>> _dataAlwaysAutocast;
        public FaerieFire_Afae(): base(1700881985)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public FaerieFire_Afae(int newId): base(1700881985, newId)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public FaerieFire_Afae(string newRawcode): base(1700881985, newRawcode)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public FaerieFire_Afae(ObjectDatabase db): base(1700881985, db)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public FaerieFire_Afae(int newId, ObjectDatabase db): base(1700881985, newId, db)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public FaerieFire_Afae(string newRawcode, ObjectDatabase db): base(1700881985, newRawcode, db)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public ObjectProperty<int> DataDefenseReduction => _dataDefenseReduction.Value;
        public ObjectProperty<bool> DataAlwaysAutocast => _dataAlwaysAutocast.Value;
        private int GetDataDefenseReduction(int level)
        {
            return _modifications[828727622, level].ValueAsInt;
        }

        private void SetDataDefenseReduction(int level, int value)
        {
            _modifications[828727622, level] = new LevelObjectDataModification{Id = 828727622, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataAlwaysAutocast(int level)
        {
            return _modifications[845504838, level].ValueAsBool;
        }

        private void SetDataAlwaysAutocast(int level, bool value)
        {
            _modifications[845504838, level] = new LevelObjectDataModification{Id = 845504838, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }
    }
}