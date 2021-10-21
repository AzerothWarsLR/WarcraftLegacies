using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemRestoreAoe : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsRestored;
        private readonly Lazy<ObjectProperty<int>> _dataManaPointsRestored;
        public ItemRestoreAoe(): base(1634879809)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ItemRestoreAoe(int newId): base(1634879809, newId)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ItemRestoreAoe(string newRawcode): base(1634879809, newRawcode)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ItemRestoreAoe(ObjectDatabase db): base(1634879809, db)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ItemRestoreAoe(int newId, ObjectDatabase db): base(1634879809, newId, db)
        {
            _dataHitPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRestored, SetDataHitPointsRestored));
            _dataManaPointsRestored = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsRestored, SetDataManaPointsRestored));
        }

        public ItemRestoreAoe(string newRawcode, ObjectDatabase db): base(1634879809, newRawcode, db)
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