using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemHealLesser : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsGained;
        public ItemHealLesser(): base(828918081)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealLesser(int newId): base(828918081, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealLesser(string newRawcode): base(828918081, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealLesser(ObjectDatabase db): base(828918081, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealLesser(int newId, ObjectDatabase db): base(828918081, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealLesser(string newRawcode, ObjectDatabase db): base(828918081, newRawcode, db)
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