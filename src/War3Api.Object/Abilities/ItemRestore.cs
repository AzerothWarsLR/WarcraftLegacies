using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemRestore : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsRestored;
        private readonly Lazy<ObjectProperty<int>> _dataManaPointsRestored;
        public ItemRestore(): base(1701988673)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ItemRestore(int newId): base(1701988673, newId)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ItemRestore(string newRawcode): base(1701988673, newRawcode)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ItemRestore(ObjectDatabase db): base(1701988673, db)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ItemRestore(int newId, ObjectDatabase db): base(1701988673, newId, db)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ItemRestore(string newRawcode, ObjectDatabase db): base(1701988673, newRawcode, db)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ObjectProperty<int> DataHitPointsRestored => _dataHitPointsRestored.Value;
        public ObjectProperty<int> DataManaPointsRestored => _dataManaPointsRestored.Value;
        private int GetDataHitPointsRestored(int level)
        {
            return _modifications[1936746569, level].ValueAsInt;
        }

        private void SetDataHitPointsRestored(int level, int value)
        {
            _modifications[1936746569, level] = new LevelObjectDataModification{Id = 1936746569, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataManaPointsRestored(int level)
        {
            return _modifications[1936747849, level].ValueAsInt;
        }

        private void SetDataManaPointsRestored(int level, int value)
        {
            _modifications[1936747849, level] = new LevelObjectDataModification{Id = 1936747849, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }
    }
}