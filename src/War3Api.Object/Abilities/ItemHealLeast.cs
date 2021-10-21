using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemHealLeast : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsGained;
        public ItemHealLeast(): base(862472513)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealLeast(int newId): base(862472513, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealLeast(string newRawcode): base(862472513, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealLeast(ObjectDatabase db): base(862472513, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealLeast(int newId, ObjectDatabase db): base(862472513, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealLeast(string newRawcode, ObjectDatabase db): base(862472513, newRawcode, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ObjectProperty<int> DataHitPointsGained => _dataHitPointsGained.Value;
        private int GetDataHitPointsGained(int level)
        {
            return _modifications[1735419977, level].ValueAsInt;
        }

        private void SetDataHitPointsGained(int level, int value)
        {
            _modifications[1735419977, level] = new LevelObjectDataModification{Id = 1735419977, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}