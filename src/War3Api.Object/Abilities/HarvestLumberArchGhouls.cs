using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class HarvestLumberArchGhouls : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDamageToTree;
        private readonly Lazy<ObjectProperty<int>> _dataLumberCapacity;
        public HarvestLumberArchGhouls(): base(846358593)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
        }

        public HarvestLumberArchGhouls(int newId): base(846358593, newId)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
        }

        public HarvestLumberArchGhouls(string newRawcode): base(846358593, newRawcode)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
        }

        public HarvestLumberArchGhouls(ObjectDatabase db): base(846358593, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
        }

        public HarvestLumberArchGhouls(int newId, ObjectDatabase db): base(846358593, newId, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
        }

        public HarvestLumberArchGhouls(string newRawcode, ObjectDatabase db): base(846358593, newRawcode, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
        }

        public ObjectProperty<int> DataDamageToTree => _dataDamageToTree.Value;
        public ObjectProperty<int> DataLumberCapacity => _dataLumberCapacity.Value;
        private int GetDataDamageToTree(int level)
        {
            return _modifications[829579592, level].ValueAsInt;
        }

        private void SetDataDamageToTree(int level, int value)
        {
            _modifications[829579592, level] = new LevelObjectDataModification{Id = 829579592, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataLumberCapacity(int level)
        {
            return _modifications[846356808, level].ValueAsInt;
        }

        private void SetDataLumberCapacity(int level, int value)
        {
            _modifications[846356808, level] = new LevelObjectDataModification{Id = 846356808, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }
    }
}