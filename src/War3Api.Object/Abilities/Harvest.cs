using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Harvest : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDamageToTree;
        private readonly Lazy<ObjectProperty<int>> _dataLumberCapacity;
        private readonly Lazy<ObjectProperty<int>> _dataGoldCapacity;
        public Harvest(): base(1918986305)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
        }

        public Harvest(int newId): base(1918986305, newId)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
        }

        public Harvest(string newRawcode): base(1918986305, newRawcode)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
        }

        public Harvest(ObjectDatabase db): base(1918986305, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
        }

        public Harvest(int newId, ObjectDatabase db): base(1918986305, newId, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
        }

        public Harvest(string newRawcode, ObjectDatabase db): base(1918986305, newRawcode, db)
        {
            _dataDamageToTree = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToTree, SetDataDamageToTree));
            _dataLumberCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCapacity, SetDataLumberCapacity));
            _dataGoldCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCapacity, SetDataGoldCapacity));
        }

        public ObjectProperty<int> DataDamageToTree => _dataDamageToTree.Value;
        public ObjectProperty<int> DataLumberCapacity => _dataLumberCapacity.Value;
        public ObjectProperty<int> DataGoldCapacity => _dataGoldCapacity.Value;
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

        private int GetDataGoldCapacity(int level)
        {
            return _modifications[863134024, level].ValueAsInt;
        }

        private void SetDataGoldCapacity(int level, int value)
        {
            _modifications[863134024, level] = new LevelObjectDataModification{Id = 863134024, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }
    }
}